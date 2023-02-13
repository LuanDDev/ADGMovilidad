using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Controllers.Security;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    public class MovilidadController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MovilidadController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _webHostEnvironment = env;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovilidadHis()
        {
            return View();
        }
        public IActionResult Vouchers()
        {
            return View();
        }
        public IActionResult VouchersProcesados()
        {
            return View();
        }

        public async Task<IActionResult> GetMovilidades(DateTime fecIni, DateTime fecFin, int companyId)
        {
            try
            {
                Movilidad obj = new Movilidad();
                obj.fecIni = fecIni;
                obj.fecFin = fecFin;
                obj.userId = (int)UsuarioLogueado.userId;
                obj.companyId = companyId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getMovilidades";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }

        public async Task<IActionResult> GetMovilidadesHis(DateTime fecIni, DateTime fecFin, int companyId)
        {
            try
            {
                Movilidad obj = new Movilidad();
                obj.fecIni = fecIni;
                obj.fecFin = fecFin;
                obj.userId = (int)UsuarioLogueado.userId;
                obj.companyId = companyId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getMovilidadesHis";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }

        public async Task<IActionResult> GetMovilidad(int idMov)
        {
            try
            {
                Movilidad obj = new Movilidad();
                obj.idMov = idMov;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getMovilidad";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }
        public async Task<IActionResult> InsertMovilidad(Movilidad obj)
        {
            try
            {
                obj.userId = (int)UsuarioLogueado.userId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/insertMovilidad";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }


        public async Task<IActionResult> CrearVoucher(Voucher obj)
        {
            try
            {
                obj.userId = (int)UsuarioLogueado.userId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/crearVoucher";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
        }

        public async Task<IActionResult> ImprimirVoucher(int id)
        {
            try
            {
                Voucher obj = new Voucher();
                obj.id = id;
                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);

                var request_json = JsonSerializer.Serialize(obj);

                var contentC = new StringContent(request_json, Encoding.UTF8, "application/json");
                var urlC = api + "Movilidad/getVoucher";
                var resultC = await httpClient.PostAsync(urlC, contentC);
                var dataC = await resultC.Content.ReadAsStringAsync();
                //Cambio de Orden para obtener el IdVoucher

                JObject jBodyC = JObject.Parse(dataC);
                List<ReporteCabecera> cabecera = new List<ReporteCabecera>();

                for (int i = 0; i < jBodyC["data"].Count(); i++)
                {
                    ReporteCabecera _bodyC = new ReporteCabecera()
                    {
                        Ruc = (string)jBodyC["data"][i]["Ruc"],
                        RazonSocial = (string)jBodyC["data"][i]["RazonSocial"],
                        Logo = (string)jBodyC["data"][i]["Logo"],
                        NombreCompleto = (string)jBodyC["data"][i]["NombreCompleto"],
                        DNI = (string)jBodyC["data"][i]["DNI"],
                        RutaSignature = (string)jBodyC["data"][i]["RutaSignature"],
                        IdVoucher = (int)jBodyC["data"][i]["IdVoucher"],
                        Correlativo = (string)jBodyC["data"][i]["Correlativo"]
                    };
                    cabecera.Add(_bodyC);
                }


                var contentD = new StringContent(request_json, Encoding.UTF8, "application/json");
                var urlD = api + "Movilidad/getVoucherDetalle";
                var resultD = await httpClient.PostAsync(urlD, contentD);
                var dataD = await resultD.Content.ReadAsStringAsync();
                //Cambio de Orden para obtener el IdVoucher

                JObject jBodyD = JObject.Parse(dataD);
                List<ReporteCuerpo> cuerpo = new List<ReporteCuerpo>();
                var cont = jBodyD["data"].Count();
                for (int i = 0; i < cont; i++)
                {
                    ReporteCuerpo _bodyD = new ReporteCuerpo()
                    {
                        FechaRegistro = (DateTime)jBodyD["data"][i]["FechaRegistro"],
                        Motivo = (string)jBodyD["data"][i]["Motivo"],
                        Origen = (string)jBodyD["data"][i]["Origen"],
                        Destino = (string)jBodyD["data"][i]["Destino"],
                        InstDestino = (string)jBodyD["data"][i]["InstDestino"],
                        Monto = (double)jBodyD["data"][i]["Monto"],
                        CCosto = (string)jBodyD["data"][i]["CCosto"]
                    };
                    cuerpo.Add(_bodyD);
                }

                string imageFirma = "";
                string imageLogo = "";

                string webRootPath = _webHostEnvironment.WebRootPath;

                string _firmaPath = $"{webRootPath}\\Signature\\{cabecera[0].RutaSignature}";
                string _logoPath = $"{webRootPath}\\img\\logos\\{cabecera[0].Logo}";

                var ds = new List<ProcesarDataSource>();

                if (System.IO.File.Exists(_firmaPath))
                {
                    byte[] bytesFirma = System.IO.File.ReadAllBytes(_firmaPath);
                    imageFirma = Convert.ToBase64String(bytesFirma);
                }
                if (System.IO.File.Exists(_logoPath))
                {
                    byte[] bytesLogo = System.IO.File.ReadAllBytes(_logoPath);
                    imageLogo = Convert.ToBase64String(bytesLogo);
                }

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("firma", imageFirma);
                parameters.Add("logo", imageLogo);

                parameters.Add("razonSocial", cabecera[0].RazonSocial);
                parameters.Add("ruc", cabecera[0].Ruc);
                parameters.Add("correlativo", cabecera[0].Correlativo);
                parameters.Add("trabajador", cabecera[0].NombreCompleto);
                parameters.Add("dni", cabecera[0].DNI);


                ds.Add(new ProcesarDataSource() { name = "dsDetalleMovilidad", data = cuerpo });
                ds.Add(new ProcesarDataSource() { name = "dsCabeceraMovilidad", data = cabecera });

                string assemblyfolder = Path.Combine(webRootPath, "Reports");
                string path = Path.Combine(assemblyfolder, "rptGenerarVoucher.rdlc");

                string contentType = "application`/pdf";
                string _fecha = DateTime.Now.ToString("yy");
                string _numero = cabecera[0].Correlativo;//Convert.ToInt32(cabecera[0].IdVoucher).ToString("D6");
                string fileName = "Voucher_" + _fecha + _numero.Trim() + "_" + cabecera[0].NombreCompleto + ".pdf";
                
                string mimeType = "";
                int extension = 1;

                LocalReport localReport = new LocalReport(path);
                
                localReport.AddDataSource("dsCabeceraMovilidad", cabecera);
                localReport.AddDataSource("dsDetalleMovilidad", cuerpo);

                var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);

                return File(result.MainStream, contentType, fileName);
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }
            
        }

        public async Task<IActionResult> GetVouchers(DateTime fecIni, DateTime fecFin, int companyId)
        {
            try
            {
                Movilidad obj = new Movilidad();
                obj.fecIni = fecIni;
                obj.fecFin = fecFin;
                obj.userId = (int)UsuarioLogueado.userId;
                obj.companyId = companyId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getVouchers";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }

        public async Task<IActionResult> GetVouchersDet(int id)
        {
            try
            {
                Voucher obj = new Voucher();
                obj.id = id;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getVouchersDet";

                var result = await httpClient.PostAsync(url, content);
                var data = await result.Content.ReadAsStringAsync();
                return Ok(new { value = data, status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { value = ex.Message, status = false });
            }

        }
        public async Task<IActionResult> GetVouchersProcesados(DateTime fecIni, DateTime fecFin, int companyId)
        {
            try
            {
                Movilidad obj = new Movilidad();
                obj.fecIni = fecIni;
                obj.fecFin = fecFin;
                obj.userId = (int)UsuarioLogueado.userId;
                obj.companyId = companyId;

                var api = _configuration["Api:root"];
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient httpClient = new HttpClient(clientHandler);
                var request_json = JsonSerializer.Serialize(obj);
                var content = new StringContent(request_json, Encoding.UTF8, "application/json");
                var url = api + "Movilidad/getVouchersProcesados";

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
