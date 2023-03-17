#pragma checksum "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5ee07d57759d2444790def6b7503e73abb464d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movilidad_Vouchers), @"mvc.1.0.view", @"/Views/Movilidad/Vouchers.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5ee07d57759d2444790def6b7503e73abb464d1", @"/Views/Movilidad/Vouchers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Movilidad_Vouchers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
  
    ViewData["Title"] = "Vouchers";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-auto me-auto"">
            <div class=""row row-cols-auto"">
                <div class=""col"">
                    <div class=""mb-3"">
                        <label for=""fecIni"" class=""form-label"">Fecha Inicial</label>
                        <input type=""date"" class=""form-control"" id=""fecIni"" autocomplete=""off"" />
                    </div>
                </div>
                <div class=""col"">
                    <div class=""mb-3"">
                        <label for=""fecFin"" class=""form-label"">Fecha Final</label>
                        <input type=""date"" class=""form-control"" id=""fecFin"" autocomplete=""off"" />
                    </div>
                </div>
                <div class=""col"">
                    <div class=""mb-3"">
                        <label for=""btnBuscar"" class=""form-label"">&nbsp;</label>
                        <button id=""btnBuscar"" type=""button"" class=""form-control btn btn-primary"">
    ");
            WriteLiteral(@"                        <i class=""ion ion-md-search""></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-auto"">
            <div class=""btn-group"">
                <button id=""btnProcesar"" class=""btn btn-green""><i class=""fa fa-table""></i> Procesar</button>
            </div>
        </div>
    </div>
</div>
<hr />

<div id=""div_table"" class=""table-responsive"">

</div>

<div class=""modal fade"" id=""mVouchersDet"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" tabindex=""-1"" aria-labelledby=""staticBackdropLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-dialog-scrollable modal-xl"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h1 class=""modal-title fs-5"" id=""modalTitle""></h1>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
          ");
            WriteLiteral(@"  <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col"">
                        <div id=""div_tableDet"" class=""table-responsive"">

                        </div>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
");
            WriteLiteral("                <button type=\"button\" class=\"btn btn-danger\" data-bs-dismiss=\"modal\"><i class=\"fa fa-sign-out\"></i> Cerrar</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        var url_selectCompany = \"");
#nullable restore
#line 74 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
                            Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"SelectCompany/IndexSelect\";\r\n\r\n        var url_GetVouchers = \"");
#nullable restore
#line 76 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
                          Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"Movilidad/GetVouchers\";\r\n        var url_GetVouchersDet = \"");
#nullable restore
#line 77 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
                             Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"Movilidad/GetVouchersDet\";\r\n        var url_ProcesarVoucher = \"");
#nullable restore
#line 78 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
                              Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"Movilidad/ProcesarVoucher\";\r\n        var url_ImprimirVoucher = \"");
#nullable restore
#line 79 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
                              Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"Movilidad/ImprimirVoucher\";\r\n    </script>\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 3280, "\"", 3323, 1);
#nullable restore
#line 82 "E:\Dev\Adgeminco\ADGMovilidad\Web\Views\Movilidad\Vouchers.cshtml"
WriteAttributeValue("", 3286, Url.Content("~/scripts/Vouchers.js"), 3286, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
