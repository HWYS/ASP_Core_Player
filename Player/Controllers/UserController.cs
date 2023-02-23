using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;
using Player.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Player.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "Users.json");


            UserViewModel viewModel = new UserViewModel();
            using (StreamReader r = new StreamReader(fullPath))
            {
                string json = r.ReadToEnd();
                viewModel.userModels = JsonConvert.DeserializeObject<List<UserModel>>(json);

            }

            return View(viewModel);
        }
    }
}

