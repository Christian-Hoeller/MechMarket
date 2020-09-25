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
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("authenticationRedirect");
            }
        }

        public async Task OnPostLoginMicrosoft()
        {
            await HttpContext.ChallengeAsync();
        }
    }
}
