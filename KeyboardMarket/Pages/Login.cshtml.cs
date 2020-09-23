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

namespace KeyboardMarket.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task OnPostLoginMicrosoft()
        {
            await HttpContext.ChallengeAsync();

        //    DBContext dBContext = new DBContext();
        //    DataTable dt = new DataTable();
             
        //    using(SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Lands]"))
        //    {
        //        dt = dBContext.GetDataReader(cmd);
        //    }

        //    List<string> Lands = new List<string>();


        //    foreach(DataRow row in dt.Rows)
        //    {
        //        Lands.Add(row["Land"].ToString());
        //    }
        //}
    }
}
