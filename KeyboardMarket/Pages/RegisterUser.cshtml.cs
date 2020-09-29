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


        [BindProperty, Required]
        public string Gender { get; set; } = "Male";
        public string[] Genders = new[] { "Male", "Female", "Other" };

        [BindProperty]
        [Required, StringLength(30, MinimumLength = 6, ErrorMessage = "Choose a password between 6 and 30 characters")]
        public string Username { get; set; }

        [BindProperty]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms  ")]
        public bool TermsChecked { get; set; }

        #endregion

        public void OnGet()
        {
        }


        public IActionResult OnPostRegister()
        {
            if (TermsChecked)
            {
                if (!UsernameInDatabase())
                {
                    string email = User.FindFirstValue(ClaimTypes.Email);
                    string commandText = "INSERT INTO Users(Email, Username, Joined, Gender, UserGroup)" +
                        $"VALUES(@email, @username, @joined, @gender, 0)";

                    SqlCommand command = new SqlCommand(commandText);
                    command.Parameters.Add("@email", SqlDbType.VarChar);
                    command.Parameters["@email"].Value = email;
                    command.Parameters.Add("@username", SqlDbType.VarChar);
                    command.Parameters["@username"].Value = Username;
                    command.Parameters.Add("@joined", SqlDbType.VarChar);
                    command.Parameters["@joined"].Value = DateTime.Now;
                    command.Parameters.Add("@gender", SqlDbType.VarChar);
                    command.Parameters["@gender"].Value = Gender[0].ToString();

                    DBContext dBContext = new DBContext();
                    DataTable dt = new DataTable();

                    using (command)
                    {
                        try
                        {
                            dt = dBContext.GetDataReader(command);
                            return new RedirectToPageResult("/index");
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            return Page();
        }

        private bool UsernameInDatabase()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE Username = '{Username}'"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            return dt.Rows.Count != 0;
        }
    }
}
