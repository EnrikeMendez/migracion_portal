var url_ws = "http://192.168.0.181:8085/ServicioLogis/";
			var token = "";
			
			function test_ws()
			{
				var body = JSON.stringify({
											"username":"MOMK951014PWA",
											"passwordUsername":"Logis2024#"
										});
				$.ajax({
					type: "POST",
					dataType: "json",
					contentType: "application/json; charset=utf-8",
					contentType: "application/json",
					crossDomain: true,
					url: url_ws + "usuario",
					data: body,
					success: function(data){
						console.log(data);
						token = data.token;
						console.log('Token => ' + token);
						create_cookie("tkn",token);
					},
					error: function(xhr){
						console.log('error');
						console.log(xhr.responseText);
						token = "-1";
					}
				});
			}
			function create_cookie(name,value)
			{
				//Cookies.set('nombre','valor',{expires: 5}); //cookie que caduca a los 5 días
				sessionStorage.setItem(name, value);
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
					console.log("Error " + name + ": " + errmessage);
				}
				
				return cookie_value;
			}