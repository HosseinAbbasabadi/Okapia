#pragma checksum "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9f340f77e1e7dda1aa9c04d0a5a75ca9ce32f23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_Job_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/Job/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administrator/Views/Job/Index.cshtml", typeof(AspNetCore.Areas_Administrator_Views_Job_Index))]
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
#line 1 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\_ViewImports.cshtml"
using Okapia;

#line default
#line hidden
#line 2 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\_ViewImports.cshtml"
using Okapia.Models;

#line default
#line hidden
#line 1 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
using Okapia.Areas.Administrator.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9f340f77e1e7dda1aa9c04d0a5a75ca9ce32f23", @"/Areas/Administrator/Views/Job/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb85121d03308b51259151afb2da5bfdb9f0838a", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    public class Areas_Administrator_Views_Job_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Jobs>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(111, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(140, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9f340f77e1e7dda1aa9c04d0a5a75ca9ce32f234058", async() => {
                BeginContext(163, 10, true);
                WriteLiteral("Create New");
                EndContext();
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
            EndContext();
            BeginContext(177, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(270, 41, false);
#line 17 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobId));

#line default
#line hidden
            EndContext();
            BeginContext(311, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(367, 43, false);
#line 20 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobName));

#line default
#line hidden
            EndContext();
            BeginContext(410, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(466, 52, false);
#line 23 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobContactTitile));

#line default
#line hidden
            EndContext();
            BeginContext(518, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(574, 55, false);
#line 26 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobManagerFirstName));

#line default
#line hidden
            EndContext();
            BeginContext(629, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(685, 54, false);
#line 29 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobManagerLastName));

#line default
#line hidden
            EndContext();
            BeginContext(739, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(795, 50, false);
#line 32 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobProvienceId));

#line default
#line hidden
            EndContext();
            BeginContext(845, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(901, 45, false);
#line 35 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.JobCityId));

#line default
#line hidden
            EndContext();
            BeginContext(946, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 41 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1064, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1113, 40, false);
#line 44 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobId));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1209, 42, false);
#line 47 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobName));

#line default
#line hidden
            EndContext();
            BeginContext(1251, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1307, 51, false);
#line 50 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobContactTitile));

#line default
#line hidden
            EndContext();
            BeginContext(1358, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1414, 54, false);
#line 53 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobManagerFirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1468, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1524, 53, false);
#line 56 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobManagerLastName));

#line default
#line hidden
            EndContext();
            BeginContext(1577, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1633, 49, false);
#line 59 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobProvienceId));

#line default
#line hidden
            EndContext();
            BeginContext(1682, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1738, 44, false);
#line 62 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobCityId));

#line default
#line hidden
            EndContext();
            BeginContext(1782, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1838, 45, false);
#line 65 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.JobAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1883, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1939, 65, false);
#line 68 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2004, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2025, 71, false);
#line 69 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2096, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(2117, 69, false);
#line 70 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(2186, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 73 "C:\Hossein\Projects\Okapia\Okapia\Areas\Administrator\Views\Job\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2225, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Jobs>> Html { get; private set; }
    }
}
#pragma warning restore 1591
