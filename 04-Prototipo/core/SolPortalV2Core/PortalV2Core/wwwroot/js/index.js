$.ajax({
    url: 'http://192.168.0.181:8085/ServicioLogis/refCursor',
    headers: {
        'Authorization': ftn_GetToken()
    },
    type: 'POST',
    dataType: 'json',
    data: { "parametroUno": "0", "parametroDos": "50" },
})
    .done(function () {
        console.log("success");
    })
    .fail(function () {
        console.log("error");
    })
    .always(function () {
        console.log("complete");
    });