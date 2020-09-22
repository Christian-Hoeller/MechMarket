using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}
