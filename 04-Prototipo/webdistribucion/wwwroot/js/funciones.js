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
function drawTable(data)
{
    var table = document.getElementById("resultTable");
    var thead = table.querySelector("thead tr");
	var tbody = table.querySelector("tbody");
	var iColumn = 0;

    thead.innerHTML = "";
    tbody.innerHTML = "";

	if (data.length > 0)
	{
		Object.keys(data[0]).forEach(function (key)
		{
            var th = document.createElement("th");
            th.textContent = key;
            thead.appendChild(th);
        });
		data.forEach(function (item)
		{
            var tr = document.createElement("tr");
			Object.values(item).forEach(function (value)
			{
                var td = document.createElement("td");
				
				if (iColumn == 4)
				{
					//td.textContent = value;
					td.innerHTML = "<a href='" + value + "' title='Etiqueta'>" + "<img src='/img/label.gif' style='border: none;'/></a>";
				}
				else
				{
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
function ws_respuesta(tipo_peticion, tipo_data, webmethod, body, token)
{
	var data_result = null;

	$.ajax(
		{
			type: tipo_peticion,
			dataType: tipo_data,
			contentType: "application/json; charset=utf-8",
			contentType: "application/json",
			crossDomain: true,
			async: false,
			url: v_ws_url + webmethod,
			data: body,
			beforeSend: function (xhr, settings) {
				xhr.setRequestHeader('Authorization', 'Bearer ' + token);
			},
			success: function (data) {
				//drawTable(data.listRefCursor);
				data_result = data.listRefCursor;
				return data_result;
			},
			error: function (xhr) {
				console.log(xhr);
				alert('Error [0x0004]: ' + xhr.responseText);
			}
		});

	return data_result;
}
function ws_cursor(param_uno, param_dos) {
	var result = new Object();
	var tblRes = null;
	var token = get_cookie("tkn");
	var tipo_peticion = "Post"
	var tipo_data = "json"
	var webmethod = "refCursor"
	var body = JSON.stringify(
		{
			"parametroUno": param_uno,
			"parametroDos": param_dos
		}
	);

	drawTable(ws_respuesta(tipo_peticion, tipo_data, webmethod, body, token));

	//return result(ws_respuesta);
}
function ws_cursor_dinamico(param_uno, param_dos, param_tres, param_fec_ini, param_fec_fin) {
	var result = new Object();
	var tblRes = null;
	var token = get_cookie("tkn");
	var tipo_peticion = "Post"
	var tipo_data = "json"
	var webmethod = "refCursorDinamico"

	var body = JSON.stringify(
		{
			"parametroUno": param_uno,
			"parametroDos": param_dos,
			"parametroTres": param_tres,
			"fechaInicio": param_fec_ini,
			"fechaFin": param_fec_fin
		}
	);

	drawTable(ws_respuesta(tipo_peticion, tipo_data, webmethod, body, token));

	//return result(ws_respuesta);
}