#pragma checksum "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "299f283b9e63da98f0c0402ae4cbe17479df3e5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DetailsStrongly), @"mvc.1.0.view", @"/Views/Home/DetailsStrongly.cshtml")]
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
#line 13 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\_ViewImports.cshtml"
using WebApp_mvc.Moddels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\_ViewImports.cshtml"
using WebApp_mvc.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"299f283b9e63da98f0c0402ae4cbe17479df3e5d", @"/Views/Home/DetailsStrongly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"037a0dc1a7f1bc78870b24386985725f1ec0491a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DetailsStrongly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp_mvc.Moddels.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml"
  
    //Layout = "~/Views/Shared/_Layout.cshtml";
    //l
    ViewBag.Title = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("<h1>");
#nullable restore
#line 12 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml"
Write(ViewBag.PageTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<p>\r\n    name : ");
#nullable restore
#line 14 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<p>\r\n    email : ");
#nullable restore
#line 17 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml"
       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<p>\r\n    department : ");
#nullable restore
#line 20 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Home\DetailsStrongly.cshtml"
            Write(Model.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp_mvc.Moddels.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
