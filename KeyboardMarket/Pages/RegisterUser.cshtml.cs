using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class RegisterUserModel : PageModel
    {

        #region Properties

        #endregion

        [BindProperty]
        public string Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female", "Other" };

        [BindProperty]
        [Required, StringLength(30, MinimumLength = 6, ErrorMessage = "Choose a password between 6 and 30 characters")]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        public bool Terms { get; set; }

        public void OnGet()
        {
        }


        public async Task OnPostRegister()
        {
            WriteUserInDatabase();
        }

        public void WriteUserInDatabase()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            DateTime joinedDate = DateTime.Now;
            //Username
            //Gender

            string command = "INSERT INTO Users(Email, Username, Joined, Gender, UserGroup)" +
                $"VALUES('{email}', '{Username}', '{DateTime.Now}', '{Gender[0]}', 0)";

            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(command))
            {
                try
                {
                    dt = dBContext.GetDataReader(cmd);
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
