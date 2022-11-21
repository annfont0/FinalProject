using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class RegisterModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;

        public RegisterModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            Customers customers = new Customers();

            customers.CustomerName = Request.Form["fname"];
            customers.CustomerUsername = Request.Form["uname"];
            customers.CustomerBirthday = Convert.ToDateTime(Request.Form["bday"]);
            customers.CustomerGender = Request.Form["gender"];
            customers.CustomerNationality = Request.Form["nat"];
            customers.CustomerEmail = Request.Form["email"];
            customers.CustomerPhone = Convert.ToInt16(Request.Form["num"]);
            customers.CustomerPassword = Request.Form["pwd"];

        }
    }
}
