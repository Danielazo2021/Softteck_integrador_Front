using Data.Base;
using Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using UmsaSofttekFront.Models;

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
            var baseApi = new BaseApi(_httpClient);
            var response = await baseApi.PostToApi("Login", login);

            if (response is OkObjectResult resultado)
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<LoginResponse>>(resultado.Value.ToString());

                if (apiResponse != null && apiResponse.Status == 200)
                {
                    var resultadoObjeto = apiResponse.Data;
                    ViewBag.UserName=resultadoObjeto.UserName;
                    ViewBag.Email=resultadoObjeto.Email;
                    ViewBag.Token=resultadoObjeto.Token;
                    
                    return View("~/Views/Home/Index.cshtml");
                }
            }

         
            return BadRequest("No se pudo iniciar sesión");
        }


    }
}
