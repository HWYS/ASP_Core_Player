using System;
namespace Player.Models
{
	public class UserModel
	{
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}

