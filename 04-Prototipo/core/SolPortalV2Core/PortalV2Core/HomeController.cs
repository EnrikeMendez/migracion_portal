using Microsoft.AspNetCore.Mvc;

namespace PortalV2Core
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Redirigir()//string parametroUno, string parametroDos)
        {
            // Aquí puedes manejar los parámetros enviados desde el formulario
            // y redirigir a la acción "Destino" en este mismo controlador
            return RedirectToAction("Destino");//, new { parametroUno, parametroDos });
        }

        public IActionResult Destino()
        {
           
            return View("Consulta");
        }
    }
}