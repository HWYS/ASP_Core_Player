using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Player.Models;
using Player.ViewModel;

namespace Player.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var user = getUsers().FirstOrDefault().id == model.id;
            /*if(user.id > 0)
            {
                return View(user);
            }*/
            return View(user);
        }

        private string getFullFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "Users.json");
            return fullPath;
        }

        private List<UserModel> getUsers()
        {
            string filePath = getFullFilePath();
            UserViewModel viewModel = new UserViewModel();
            if (System.IO.File.Exists(filePath))
            {

                using (StreamReader r = new StreamReader(getFullFilePath()))
                {
                    string json = r.ReadToEnd();
                    viewModel.userModels = JsonConvert.DeserializeObject<List<UserModel>>(json).ToList();

                }
            }
            return viewModel.userModels;
        }
    }   


}
