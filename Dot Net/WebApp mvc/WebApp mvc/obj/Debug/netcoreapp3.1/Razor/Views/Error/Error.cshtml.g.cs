#pragma checksum "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Error\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64bd4d547276b37f960bc17dad8bc4768f779ea2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Error_Error), @"mvc.1.0.view", @"/Views/Error/Error.cshtml")]
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
#nullable restore
#line 18 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64bd4d547276b37f960bc17dad8bc4768f779ea2", @"/Views/Error/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"074ebe9133e2ad1c1ffadf1e2bfec40751d393f7", @"/Views/_ViewImports.cshtml")]
    public class Views_Error_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h3>
    An occured while processing your request. The support
    team is notified and we are working on the fix
</h3>
<h5>Please contact us on pragim@pragimtech.com</h5>
<hr />
<h3>Exception Details:</h3>
<div class=""alert alert-danger"">
    <h5>Exception Path</h5>
    <hr />
    <p>");
#nullable restore
#line 11 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Error\Error.cshtml"
  Write(ViewBag.ExceptionPath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div class=\"alert alert-danger\">\r\n    <h5>Exception Message</h5>\r\n    <hr />\r\n    <p>");
#nullable restore
#line 17 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Error\Error.cshtml"
  Write(ViewBag.ExceptionMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div class=\"alert alert-danger\">\r\n    <h5>Exception Stack Trace</h5>\r\n    <hr />\r\n    <p>");
#nullable restore
#line 23 "C:\Users\mbark\OneDrive\Documents\GitHub\backend\Dot Net\WebApp mvc\WebApp mvc\Views\Error\Error.cshtml"
  Write(ViewBag.StackTrace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
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
