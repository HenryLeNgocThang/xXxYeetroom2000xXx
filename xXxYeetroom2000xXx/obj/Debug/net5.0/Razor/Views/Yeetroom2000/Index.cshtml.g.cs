#pragma checksum "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f120abd3aa41a0f551afbb79776eb3c61d1fdce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Yeetroom2000_Index), @"mvc.1.0.view", @"/Views/Yeetroom2000/Index.cshtml")]
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
#line 1 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\_ViewImports.cshtml"
using xXxYeetroom2000xXx;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\_ViewImports.cshtml"
using xXxYeetroom2000xXx.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f120abd3aa41a0f551afbb79776eb3c61d1fdce", @"/Views/Yeetroom2000/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b9f866e299af9235f62550df9753b70549f30bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Yeetroom2000_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
   
    foreach (var post in Model.AllePosts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <div style=\"text-align: right; margin-bottom: 0px;\">\r\n");
#nullable restore
#line 12 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
             foreach (Post item in ViewBag.Posts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p> ");
#nullable restore
#line 14 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
               Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 14 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
                        Write(item.Verfasser);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 14 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
                                        Write(item.Eintrag);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 15 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <h4 style=\"border: 1px solid black; margin-bottom: 0px;\"> ");
#nullable restore
#line 25 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
                                                             Write(post.Eintrag);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n");
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 40 "C:\Users\damba\Desktop\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Yeetroom2000\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
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
