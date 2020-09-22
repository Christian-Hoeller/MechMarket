using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyboardMarket.Pages.Shared
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task OnPostLogout()
        {
            await HttpContext.SignOutAsync();
            Response.Redirect("index");
        }
    }
}
