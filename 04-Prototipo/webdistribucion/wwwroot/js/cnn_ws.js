function init_page() {
	create_token();
	validate_session();
}
function create_token() {
	var token = "";
	var body = JSON.stringify(
		{
			"username": v_ws_usr,
			"passwordUsername": v_ws_pwd
		}
	);
	if (get_cookie("tkn") == null) {
		$.ajax(
			{
				type: "POST",
				dataType: "json",
				contentType: "application/json; charset=utf-8",
				contentType: "application/json",
				crossDomain: true,
				url: v_ws_url + "usuario",
				data: body,
				success: function (data) {
					token = data.token;
					console.log('Token => ' + token);
					create_cookie("tkn", token);
				},
				error: function (xhr) {
					console.log(xhr);
					if (xhr.responseText !== undefined) {
						alert('Error [0x0001]: ' + xhr.responseText);
					}
					elseif(xhr.statusText !== undefined)
					{
						alert(xhr.statusText + ' [0x0002]: ' + xhr.status);
					}
					token = "-1";
				}
			}
		);
	}
	else {
		token = get_cookie("tkn");
	}

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
	if (minutes > 30) {
		sessionStorage.removeItem("tkn");
	}
}
function create_cookie(name, value) {
	const cookie_date = new Date();
	sessionStorage.setItem(name, value);
	sessionStorage.setItem(name + "_time", getDateNow());
}
function get_cookie(name) {
	var cookie_value = "";

	try {
		cookie_value = sessionStorage.getItem(name);
	}
	catch ({ errname, errmessage }) {
		console.log("Error [0x0003] " + errname + ": " + errmessage);
	}

	return cookie_value;
}

window.onload = init_page;