#pragma checksum "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9288a5cba934c6ef7a6869c447d59851e633c52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\_ViewImports.cshtml"
using xXxYeetroom2000xXx;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\_ViewImports.cshtml"
using xXxYeetroom2000xXx.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9288a5cba934c6ef7a6869c447d59851e633c52", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b9f866e299af9235f62550df9753b70549f30bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Jojo</h1>\r\n<h2>Index</h2>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9288a5cba934c6ef7a6869c447d59851e633c523609", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
  
    foreach (Post post in ViewBag.Posts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <div style=\"text-align: right; margin-bottom: 0px;\">\r\n                ");
#nullable restore
#line 14 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
           Write(post.Verfasser);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sagte am ");
#nullable restore
#line 14 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
                                    Write(post.Datum);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 15 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
                   if (post.Link != "")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 395, "\"", 411, 1);
#nullable restore
#line 17 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
WriteAttributeValue("", 401, post.Link, 401, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 18 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
                    }
                    if (post.Eintrag != "")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p> ");
#nullable restore
#line 21 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
                       Write(post.Eintrag);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 22 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 40 "D:\XAMPP\htdocs\xXxYeetroom2000xXx\xXxYeetroom2000xXx\Views\Home\Index.cshtml"
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
