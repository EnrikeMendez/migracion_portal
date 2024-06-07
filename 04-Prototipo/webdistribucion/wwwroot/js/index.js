function call_cursor()
{
    ws_cursor("0", "50");
}
function call_filtro()
{

    ws_cursor_dinamico(
        document.getElementById('param1').value,
        document.getElementById('param2').value,
        document.getElementById('param3').value,
        document.getElementById('param4').value,
        document.getElementById('param5').value
    );
}