using Newtonsoft.Json;
using Player.ViewModel;

namespace Player.Models
{
    public class InfoMessageModel
    {
        public string message { get; set; }
        public bool isActive { get; set; }


        private string getFullFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "InfoMessage.json");
            return fullPath;
        }

        public InfoMessageModel GetInfoMessageModel()
        {
            string filePath = getFullFilePath();
            InfoMessageModel model = new InfoMessageModel();
            if (System.IO.File.Exists(filePath))
            {

                using (StreamReader r = new StreamReader(getFullFilePath()))
                {
                    string json = r.ReadToEnd();
                    model = JsonConvert.DeserializeObject<InfoMessageModel>(json);

                }
            }
            return model;
        }

        public void SaveModel(InfoMessageModel model)
        {
            System.IO.File.WriteAllText(getFullFilePath(), JsonConvert.SerializeObject(model));
        }
    }
}
