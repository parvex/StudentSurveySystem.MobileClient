using StudentSurveySystem.ApiClient.Model;

namespace MobileClient.Models
{
    public class UserRegister
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public UserRole UserRole { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}