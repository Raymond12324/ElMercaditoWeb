#pragma checksum "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb0c2c0d6579178ffa5b14bf9562d17b3a09535a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_ListUser), @"mvc.1.0.view", @"/Views/Administrador/ListUser.cshtml")]
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
#line 1 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\_ViewImports.cshtml"
using ElMercaditoWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\_ViewImports.cshtml"
using ElMercaditoWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb0c2c0d6579178ffa5b14bf9562d17b3a09535a", @"/Views/Administrador/ListUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5d4954b2033f0ec0ebeff27c97095b8734932eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_ListUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Microsoft.AspNetCore.Identity.IdentityUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n  <div class=\"container\">\r\n");
#nullable restore
#line 4 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"
         if (Model.Any())


        {



#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Lista de usuarios registrados en el sistema</h1>\r\n");
            WriteLiteral(@"            <table class=""table"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">Mail</th>
                        <th scope=""col"">Id</th>
                    </tr>
                </thead>

                <tbody>
");
#nullable restore
#line 22 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"
                     foreach (var user in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">1</th>\r\n                            <td>");
#nullable restore
#line 26 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"
                           Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 27 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"
                           Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 29 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 32 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"


        }
        else
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1 class=\"text-center\">No se encuentra ningun usuario registrado en el sistema</h1>\r\n");
#nullable restore
#line 39 "C:\Users\raymond\source\repos\ElMercaditoWeb\ElMercaditoWeb\Views\Administrador\ListUser.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Microsoft.AspNetCore.Identity.IdentityUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
