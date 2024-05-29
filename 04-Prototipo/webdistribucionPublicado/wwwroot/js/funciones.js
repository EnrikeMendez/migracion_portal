var url_ws = "http://192.168.0.181:8085/ServicioLogis/";

function init_page()
{
	create_token();
	validate_session();
}

function create_token() {
	var token = "";
	var body = JSON.stringify({
										"username": "MOMK951014PWA",
										"passwordUsername": "Logis2024#"
									}
					);
	$.ajax(
			{
				type:	"POST",
				dataType:	"json",
				contentType:	"application/json; charset=utf-8",
				contentType:	"application/json",
				crossDomain:	true,
				url:	url_ws + "usuario",
				data:	body,
				success:	function(data)
							{
								token = data.token;
								/*console.log('Token => ' + token);*/
								create_cookie("tkn",token);
							},
				error:	function(xhr)
						{
							console.log(xhr);
							alert('Error: ' + xhr.responseText);
							token = "-1";
						}
			}
	);
	
	return token;
}

function validate_session() {
	const d = new Date();
	var days = 0;
	var hours = 0;
	var minutes = 0;
	var seconds = 0;
	var total_secs = 0;
	var total_mins = 0;
	var total_days = 0;
	var total_hours = 0;
	var data_number = 0;
	var session_init = "";
	var ini_date = new Date();
	var end_date = new Date();
	session_init = get_cookie("tkn_time");
	/*d.M.y.H.m.s*/
	
	total_secs = 1000 * 60;
	total_mins = 1000 * 60 * 60;
	total_hours = 1000 * 60;
	total_days = 1000 * 60 * 24;
	
	d.setDate(session_init.split(".")[0]);
	d.setMonth(session_init.split(".")[1]);
	d.setFullYear(session_init.split(".")[2]);
	d.setHours(session_init.split(".")[3]);
	d.setMinutes(session_init.split(".")[4]);
	d.setSeconds(session_init.split(".")[5]);
	
	ini_date = d;
	end_date = new Date();
	data_number = end_date - ini_date;
	
	console.log("ini_date: " + ini_date);
	console.log("end_date: " + end_date);
	
	seconds = data_number / 1000;
	minutes = seconds / 60;
	hours = minutes / 60;
	days = hours / 24;
	
	/*
	Estas instrucciones se utilizarán para controlar el tiempo que puede mantenerse activa una sesión:
	if(hours > 3)
	{
		sessionStorage.removeItem("tkn");
	}
	*/
	if(minutes > 30)
	{
		sessionStorage.removeItem("tkn");
	}
}
function create_cookie(name,value)
{
	const cookie_date = new Date();
	sessionStorage.setItem(name, value);
	sessionStorage.setItem(name + "_time", getDateNow());
}
function get_cookie(name)
{
	var cookie_value = "";
	
	try
	{
		cookie_value = sessionStorage.getItem(name);
	}
	catch ({ errname, errmessage })
	{
		console.log("Error " + errname + ": " + errmessage);
	}
	
	return cookie_value;
}
function getDateNow()
{
	var result = "";
	var separator = ".";
	const d = new Date();
	/*Format: d.M.y.H.m.s*/
	
	result += d.getDate().toString();
	result += separator;
	result += d.getMonth().toString();
	result += separator;
	result += d.getFullYear().toString();
	result += separator;
	result += d.getHours().toString();
	result += separator;
	result += d.getMinutes().toString();
	result += separator;
	result += d.getSeconds().toString();
	
	return result;
}

function ws_cursor() {
	var result	=	new Object();
	var tblRes	=	null;
	var token	=	get_cookie("tkn");
    var body	=	JSON.stringify(
								{
        							"parametroUno": "0",
        							"parametroDos": "50"
    							}
				);

	/*
	if(token == null)
	{
		redirect("login");
	}
	*/
	$.ajax(
		{
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
		contentType: "application/json",
        crossDomain: true,
        url: url_ws + "refCursor",
        data: body,
        beforeSend:	function(xhr, settings)
					{
            			xhr.setRequestHeader('Authorization','Bearer ' + token );
        			},
        success:	function(data) 
					{
            drawTable(data.listRefCursor);
        },
        error: function(xhr) {
            console.log(xhr);
            alert('Error: ' + xhr.responseText);
        }
    });

	
	return result;
}


function ws_cursor_dinamico() {
	var result = new Object();
	var tblRes = null;
	var token = get_cookie("tkn");
	var body = JSON.stringify(
		{
			"parametroUno": document.getElementById('param1').value ,
			"parametroDos": document.getElementById('param2').value,
			"parametroTres": document.getElementById('param3').value,
			"fechaInicio": document.getElementById('param4').value,
			"fechaFin": document.getElementById('param5').value
		}
	);

	/*
	if(token == null)
	{
		redirect("login");
	}
	*/
	$.ajax(
		{
			type: "POST",
			dataType: "json",
			contentType: "application/json; charset=utf-8",
			contentType: "application/json",
			crossDomain: true,
			url: url_ws + "refCursorDinamico",
			data: body,
			beforeSend: function (xhr, settings) {
				xhr.setRequestHeader('Authorization', 'Bearer ' + token);
			},
			success: function (data) {
				drawTable(data.listRefCursor);
			},
			error: function (xhr) {
				console.log(xhr);
				alert('Error: ' + xhr.responseText);
			}
		});


	return result;
}




function drawTable(data) {
    var table = document.getElementById("resultTable");
    var thead = table.querySelector("thead tr");
	var tbody = table.querySelector("tbody");
	var iColumn = 0;

    thead.innerHTML = "";
    tbody.innerHTML = "";

    if (data.length > 0) {

        Object.keys(data[0]).forEach(function(key) {
            var th = document.createElement("th");
            th.textContent = key;
            thead.appendChild(th);
        });


        data.forEach(function(item) {
            var tr = document.createElement("tr");
            Object.values(item).forEach(function(value) {
                var td = document.createElement("td");
				
				if (iColumn == 4) {
					//td.textContent = value;
					td.innerHTML = "<a href='" + value + "' title='Etiqueta'>" + "<img src='/img/label.gif' style='border: none;'/></a>";
				}
				else {
					td.textContent = value;
				}
				tr.appendChild(td);
				iColumn++;
            });
			tbody.appendChild(tr);
			iColumn = 0;
        });
    }
}

window.onload = init_page;
