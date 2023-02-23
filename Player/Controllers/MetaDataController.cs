using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;
using Player.ViewModel;

namespace Player.Controllers
{
    public class MetaDataController : Controller
    {
        // GET: MetaDataController
        public ActionResult Index()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "MetaData.json");

            MetaDataViewModel viewModel = new MetaDataViewModel();
            using (StreamReader r = new StreamReader(fullPath))
            {
                string json = r.ReadToEnd();
                viewModel.metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(json).Where(x => x.isActive == true).ToList();

            }

            return View(viewModel);
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
