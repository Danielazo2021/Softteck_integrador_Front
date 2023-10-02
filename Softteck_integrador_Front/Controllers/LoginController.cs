using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;
using UmsaSofttekFront.Models;
using UmsaSofttekFront.ViewModels;

namespace UmsaSofttekFront.Controllers
{
	public class LoginController : Controller
	{
        private readonly IHttpClientFactory _httpClient;
        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Login()
		{
			return View();
		}


        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            //var baseApi = new BaseApi(_httpClient);
            //var token = await baseApi.PostToApi("Login", login);

            var baseApi = new BaseApi(_httpClient);
            var response = await baseApi.PostToApi("Login", login);

            if (response is OkObjectResult resultado)
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(resultado.Value.ToString());

                if (apiResponse != null && apiResponse.Status == 200)
                {
                    var resultadoObjeto = apiResponse.Data;
                    //ViewBag.UserName=resultadoObjeto.UserName;
                    //ViewBag.Email=resultadoObjeto.Email;
                    //ViewBag.Token=resultadoObjeto.Token;



                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    Claim claimRole = new(ClaimTypes.Role, "Adminitrador");

                    identity.AddClaim(claimRole);

                    var claimPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddHours(1),
                    });

                    HttpContext.Session.SetString("Token", resultadoObjeto.Token);

                    var homeViewModel = new HomeViewModel();
                    homeViewModel.Token = resultadoObjeto.Token;




                    return View("~/Views/Home/Index.cshtml", homeViewModel);
                }
            }

         
            return BadRequest("No se pudo iniciar sesión");
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

    }
}
