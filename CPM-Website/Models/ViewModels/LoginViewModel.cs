using Common;

namespace CPM_Website.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        private string password;
        public string Password{get { return this.password; } set { this.password = value.ToMD5(); } }

        public bool RememberMe { get; set; }
        public string ComfirmPassword { get; set; }
    }
}