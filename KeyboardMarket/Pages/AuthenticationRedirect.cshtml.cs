using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KeyboardMarket.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyboardMarket.Pages
{
    public class AuthenticationRedirectModel : PageModel
    {
        private string Email { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Email = User.FindFirstValue(ClaimTypes.Email);

                if (UserIsRegistered() == false)
                {
                    RedirectTo("register-user");
                }
                else
                {
                    RedirectTo("index");
                }
            }
            else
            {
                 RedirectTo("index");
            }
        }

        private void RedirectTo(string page)
        {
            Response.Redirect(page);
        }

        private bool UserIsRegistered()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE Email = '{Email}'"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            return dt.Rows.Count != 0;
        }
    }
}