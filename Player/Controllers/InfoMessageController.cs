using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;

namespace Player.Controllers
{
    public class InfoMessageController : Controller
    {
        public IActionResult Index()
        {
            InfoMessageModel infoMessageModel = new InfoMessageModel();
            return View(infoMessageModel.GetInfoMessageModel());
        }

        [HttpPost]        
        public IActionResult Save(InfoMessageModel model)
        {
           
            InfoMessageModel infoMessageModel = new InfoMessageModel();
            infoMessageModel.SaveModel(model);
            

            return RedirectToAction("Index");
        }
    }
}
