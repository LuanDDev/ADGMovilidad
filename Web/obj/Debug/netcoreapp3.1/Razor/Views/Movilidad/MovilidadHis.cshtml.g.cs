#pragma checksum "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\Movilidad\MovilidadHis.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2eb3c928dbe8947515f7a1f96d4a264035f2e31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movilidad_MovilidadHis), @"mvc.1.0.view", @"/Views/Movilidad/MovilidadHis.cshtml")]
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
#line 1 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2eb3c928dbe8947515f7a1f96d4a264035f2e31", @"/Views/Movilidad/MovilidadHis.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Movilidad_MovilidadHis : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\Movilidad\MovilidadHis.cshtml"
  
    ViewData["Title"] = "Histórico de Movilidades";
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
    </div>
</div>
<hr />

<div id=""div_table"" class=""table-responsive"">

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        var url_selectCompany = \"");
#nullable restore
#line 44 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\Movilidad\MovilidadHis.cshtml"
                            Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"SelectCompany/IndexSelect\";\r\n\r\n        var url_GetMovilidadesHis = \"");
#nullable restore
#line 46 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\Movilidad\MovilidadHis.cshtml"
                                Write(Url.Content("~/"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" + \"Movilidad/GetMovilidadesHis\";\r\n    </script>\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1645, "\"", 1692, 1);
#nullable restore
#line 49 "C:\Users\ldelacruz\Dev\2022\Desarrollo\ERP\ADGMovilidad\Movilidad\Web\Views\Movilidad\MovilidadHis.cshtml"
WriteAttributeValue("", 1651, Url.Content("~/scripts/MovilidadHis.js"), 1651, 41, false);

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
