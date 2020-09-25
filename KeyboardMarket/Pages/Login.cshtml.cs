using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using KeyboardMarket.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KeyboardMarket.Pages
{
    public class LoginModel : PageModel
    {

        public IEnumerable<Claim> Claims { get; set; }
        public string EmailClaim { get; set; }

        private string Email { get; set; }

        public void OnGet()
        {

            if (User.Identity.IsAuthenticated)
            {
                Email = User.FindFirstValue(ClaimTypes.Email);

                if (UserIsRegistered() == false)
                {
                    RegisterUser();
                }
                else
                {
                    Response.Redirect("index");
                }
            }
            else
            {
                //user is not authenticated
            }
        }

        private void RegisterUser()
        {
            throw new NotImplementedException();
        }

        private bool UserIsRegistered()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE Email = {Email}"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            return dt.Rows.Count != 0;
        }

        public async Task OnPostLoginMicrosoft()
        {
            await HttpContext.ChallengeAsync();

           
        }
    }
}
