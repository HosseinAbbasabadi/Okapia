#pragma checksum "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b51c32dd0893f973fbd2071fa9f717d4529dc7ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Shared_Components_Navigator_Default), @"mvc.1.0.view", @"/Areas/Customer/Views/Shared/Components/Navigator/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Customer/Views/Shared/Components/Navigator/Default.cshtml", typeof(AspNetCore.Areas_Customer_Views_Shared_Components_Navigator_Default))]
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
#line 1 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\_ViewImports.cshtml"
using Okapia;

#line default
#line hidden
#line 2 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\_ViewImports.cshtml"
using Okapia.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b51c32dd0893f973fbd2071fa9f717d4529dc7ff", @"/Areas/Customer/Views/Shared/Components/Navigator/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb85121d03308b51259151afb2da5bfdb9f0838a", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Shared_Components_Navigator_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("waves-effect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 1 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
  
  var auth = ViewData["Auth"] as Auth;

#line default
#line hidden
            BeginContext(47, 363, true);
            WriteLiteral(@"
<div id=""wrapper"">
  <!-- Top Bar Start -->
  <div class=""topbar"">
    <!-- LOGO -->
    <div class=""topbar-left"">
      <div class=""text-center"">
        <a href=""index.html"" class=""logo""><i class=""md md-terrain""></i> <span> OKAPIA </span></a>
      </div>
    </div>
    <div class=""topbar-left pull-right"">
      <div class=""text-center"">
        ");
            EndContext();
            BeginContext(410, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b51c32dd0893f973fbd2071fa9f717d4529dc7ff6185", async() => {
                BeginContext(479, 58, true);
                WriteLiteral("<i class=\"md md-terrain\"></i><span> بازگشت به سایت </span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(541, 534, true);
            WriteLiteral(@"
      </div>
    </div>
    <!-- Button mobile view to collapse sidebar menu -->
    <div class=""navbar navbar-default"" role=""navigation"">
    </div>
  </div>
  <!-- Top Bar End -->
  <!-- ========== Left Sidebar Start ========== -->
  <div class=""left side-menu"">
    <div class=""sidebar-inner slimscrollleft"">
      <div class=""user-details"">
        <div class=""user-info"">
          <div class=""dropdown"">
            <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"" aria-expanded=""false"">
              ");
            EndContext();
            BeginContext(1076, 14, false);
#line 31 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
         Write(auth?.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1090, 76, true);
            WriteLiteral("\r\n            </a>\r\n          </div>\r\n\r\n          <p class=\"text-muted m-0\">");
            EndContext();
            BeginContext(1167, 10, false);
#line 35 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
                               Write(auth?.Role);

#line default
#line hidden
            EndContext();
            BeginContext(1177, 134, true);
            WriteLiteral("</p>\r\n        </div>\r\n      </div>\r\n      <!--- Divider -->\r\n      <div id=\"sidebar-menu\">\r\n        <ul>\r\n          <li>\r\n            ");
            EndContext();
            BeginContext(1311, 121, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b51c32dd0893f973fbd2071fa9f717d4529dc7ff9602", async() => {
                BeginContext(1375, 53, true);
                WriteLiteral("<i class=\"md md-home\"></i><span> ناحیه کاربری </span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1432, 19, true);
            WriteLiteral("\r\n          </li>\r\n");
            EndContext();
#line 44 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
           if (auth?.Role == "Customer" || auth?.Role == "ShopKeeper")
          {

#line default
#line hidden
            BeginContext(1536, 413, true);
            WriteLiteral(@"            <li>
              <a href=""email-read.html"" class=""waves-effect"">
                <i class=""md md-home""></i>
                <span>معرفی عضو</span>
              </a>
            </li>
            <li>
              <a href=""email-read.html"" class=""waves-effect"">
                <i class=""md md-home""></i>
                <span>گزارش حجم خرید</span>
              </a>
            </li>
");
            EndContext();
#line 58 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
          }

#line default
#line hidden
            BeginContext(1962, 10, true);
            WriteLiteral("          ");
            EndContext();
#line 59 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
           if (auth?.Role == "Administrator")
          {

#line default
#line hidden
            BeginContext(2022, 32, true);
            WriteLiteral("            <li>\r\n              ");
            EndContext();
            BeginContext(2054, 192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b51c32dd0893f973fbd2071fa9f717d4529dc7ff12806", async() => {
                BeginContext(2139, 103, true);
                WriteLiteral("\r\n                <i class=\"md md-home\"></i>\r\n                <span>افزودن مشاغل</span>\r\n              ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2246, 657, true);
            WriteLiteral(@"
            </li>
            <li>
              <a href=""email-compose.html"" class=""waves-effect"">
                <i class=""md md-home""></i>
                <span>گزارشات مدیریت</span>
              </a>
            </li>
            <li>
              <a href=""task-list.html"" class=""waves-effect"">
                <i class=""md md-home""></i>
                <span> تعریف باشگاه مشتریان </span>
              </a>
            </li>
            <li>
              <a href=""task-list.html"" class=""waves-effect"">
                <i class=""md md-home""></i>
                <span> تنظیمات سایت </span>
              </a>
            </li>
");
            EndContext();
#line 85 "C:\Hossein\Projects\Okapia\Okapia\Areas\Customer\Views\Shared\Components\Navigator\Default.cshtml"
          }

#line default
#line hidden
            BeginContext(2916, 93, true);
            WriteLiteral("        </ul>\r\n      </div>\r\n      <div class=\"clearfix\"></div>\r\n    </div>\r\n  </div>\r\n</div>");
            EndContext();
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
