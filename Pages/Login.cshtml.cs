using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp3.Pages;

public class LoginModel : PageModel
{
    [AllowAnonymous]
    public async Task<IActionResult> OnGet(string redirectUri)
    {
        if (User.Identity.IsAuthenticated) return Redirect(redirectUri ?? "/");

        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri(redirectUri)
            .WithScope("openid profile email")
            .Build();

        await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);

        return Page();
    }
}