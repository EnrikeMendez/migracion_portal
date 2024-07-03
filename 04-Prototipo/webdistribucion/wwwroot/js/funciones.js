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
	var table = null;
	var thead = null;
	var tbody = null;
	var iColumn = 0;
	var th = null;
	var tr = null;
	var td = null;
	
	if (data.length > 0) {
		table = document.getElementById("resultTable");

		if (table != null) {
			thead = table.querySelector("thead tr");
			
			if (thead != null) {
				thead.innerHTML = "";
				tbody = table.querySelector("tbody");

				if (tbody != null) {
					tbody.innerHTML = "";
					Object.keys(data[0]).forEach(function (key) {
						th = document.createElement("th");
						th.textContent = key;
						thead.appendChild(th);
					});
					data.forEach(function (item) {
						tr = document.createElement("tr");
						Object.values(item).forEach(function (value) {
							td = document.createElement("td");

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
		}
	}
	else {
		if (table != null) {
			tbody = table.querySelector("tbody");
			if (tbody != null) {
				$(tbody).find("tr").remove();
			};
		}
	}
}
function clearTable(id) {
	var table = null;
	var tbody = null;
	var arrTR = null;

	if (id != "") {
		table = document.getElementById(id);

		if (table != null) {
			tbody = table.querySelector("tbody");

			if (tbody != null) {
				arrTR = tbody.rows;
				$(tbody).find("tr").remove();
			}
		}
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
	var body = null;
	var token = null;
	var result = null;
	var tblRes = null;
	var tipo_data = null;
	var webmethod = null;
	var tipo_peticion = null;

	result = new Object();
	token = get_cookie("tkn");
	tipo_peticion = "Post";
	tipo_data = "json";

	webmethod = "refCursor";
	body = JSON.stringify(
		{
			"parametroUno": param_uno,
			"parametroDos": param_dos
		}
	);

	drawTable(ws_respuesta(tipo_peticion, tipo_data, webmethod, body, token));

	//return result(ws_respuesta);
}
function ws_cursor_dinamico(param_uno, param_dos, param_tres, param_fec_ini, param_fec_fin) {
	var token = null;
	var result = null;
	var tblRes = null;
	var tipo_data = null;
	var webmethod = null;
	var tipo_peticion = null;

	result = new Object();
	tblRes = null;
	token = get_cookie("tkn");
	tipo_peticion = "Post";
	tipo_data = "json";

	webmethod = "refCursorDinamico";
	body = JSON.stringify(
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
function validate_txt_required(idForm) {
	var res = true;
	var form = null;
	var idInput = null;
	var arrInputs = null;

	form = $("#" + idForm + "");

	if (form != null) {
		arrInputs = $("input.required");

		if (arrInputs.length > 0) {
			arrInputs.each(function (item) {
				idInput = $(this)[0].id;

				if ($("#" + idInput).val() == "") {
					res = false;
					$(this).addClass("alert alert-danger");
					$(this).attr("data-toggle", "tooltip");
					$(this).attr("title", "Dato requerido!");
					$('[data-toggle="tooltip"]').tooltip();
				}
				else {
					$(this).removeClass("alert alert-danger");
					$(this).removeAttr("data-toggle");
					$(this).removeAttr("title");
				}
			});
		}
	}

	return res;
}