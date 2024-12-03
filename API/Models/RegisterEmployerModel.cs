namespace API.Models
{
    public class RegisterEmployerModel
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
