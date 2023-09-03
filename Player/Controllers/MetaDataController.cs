using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;
using Player.ViewModel;
using System.IO;

namespace Player.Controllers
{
    public class MetaDataController : Controller
    {   
        // GET: MetaDataController
        public ActionResult Index(int id)
        {            
            
            MetaDataViewModel viewModel = new MetaDataViewModel();
            viewModel.metaDataModels = getMetaDataModels();
            ViewData["EditMode"] = false;

            if (id != 0)
            {
                var metaDataToEdit = viewModel.metaDataModels.FirstOrDefault(m => m.id == id);
                if (metaDataToEdit != null)
                {
                    ViewData["EditMode"] = true;
                    ViewData["Model"] = metaDataToEdit;
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(MetaDataModel model)
        {
            MetaDataViewModel viewModel = new MetaDataViewModel();

            viewModel.metaDataModels = getMetaDataModels();

            if (model.id == 0) // New MetaData
            {
                model.id = viewModel.metaDataModels.Count + 1;
                viewModel.metaDataModels.Add(model);
            }
            else // Edit existing note
            {
                var existing = viewModel.metaDataModels.FirstOrDefault(m => m.id == model.id);
                var index = viewModel.metaDataModels.IndexOf(existing);
                if (existing != null)
                {
                    viewModel.metaDataModels[index] = model;
                }
            }

            System.IO.File.WriteAllText(getFullFilePath(), JsonConvert.SerializeObject(viewModel.metaDataModels));

            return RedirectToAction("Index");
        }
        private string getFullFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "MetaData.json");
            return fullPath;
        }

        private List<MetaDataModel> getMetaDataModels()
        {
            string filePath = getFullFilePath();
            MetaDataViewModel viewModel = new MetaDataViewModel();
            if (System.IO.File.Exists(filePath))
            {
                
                using (StreamReader r = new StreamReader(getFullFilePath()))
                {
                    string json = r.ReadToEnd();
                    viewModel.metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(json).ToList();

                }
            }
            return viewModel.metaDataModels;
        }

        // GET: MetaDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MetaDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetaDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MetaDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MetaDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MetaDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MetaDataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
