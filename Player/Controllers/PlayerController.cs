using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;
using Player.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Player.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        

        public PlayerController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //string filePath = Microsoft.AspNetCore.Server.MapPath("~/Data/Config.json");
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "MetaData.json");

            
            MetaDataViewModel viewModel = new MetaDataViewModel();

            InfoMessageModel infoMessageModel = new InfoMessageModel();
            infoMessageModel = infoMessageModel.GetInfoMessageModel();
            viewModel.message = infoMessageModel.isActive ? infoMessageModel.message : "";

            using (StreamReader r = new StreamReader(fullPath))
            {
                string json = r.ReadToEnd();
                viewModel.metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(json).Where(x => x.isActive == true).ToList();
                
                
            }

            //ViewBag.metaDataModels = metaDataModels;

            return View(viewModel);
        }
    }
}

