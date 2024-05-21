using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

[ApiController]
[Route("[Controller]")]
public class DocumentaLTLController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("documentarnui")]
    public WEB_LTL DocumentarNUI(WEB_LTL Info)
    {
        WEB_LTL wel = new WEB_LTL();
        Respuesta resp = new Respuesta();

        resp = wel.ValidaInfo(Info);

        if (resp.Ok == true)
        {
            resp = wel.DocumentaTalon(Info);

            if (resp.Ok == true)
            {
                Info = (WEB_LTL)resp.Objeto;
            }
        }

        return Info;
    }
}