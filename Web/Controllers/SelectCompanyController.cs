using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Controllers.Security;
using Web.Models.Portal;

namespace Web.Controllers
{
    public class SelectCompanyController : BaseController
    {
        private readonly IConfiguration _configuration;

        public SelectCompanyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult IndexSelect()
        {
            return View();
        }
        public async Task<IActionResult> GetCompaniesSession(int CodUsuario)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.CodUsuario = CodUsuario;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(usuario);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "User/getCompaniesSesion";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }
    }
}
