const url_ws = "http://192.168.0.181:8085/ServicioLogis";

function fn_GetToken() {
	var token_session = "";
	const xhr = new XMLHttpRequest();
	const url = url_ws + "/usuario";

	xhr.onreadystatechange = function () {
		if (xhr.readyState == XMLHttpRequest.DONE) {
			token_session = xhr.responseText;
		}
	}

	xhr.open("POST", url, true);
	xhr.send();

	return token_session;
}