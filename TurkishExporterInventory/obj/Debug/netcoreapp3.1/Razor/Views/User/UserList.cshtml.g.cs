#pragma checksum "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f488d4ee6c740c31311dd6a8deeb54196ead93a4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserList), @"mvc.1.0.view", @"/Views/User/UserList.cshtml")]
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
#line 1 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\_ViewImports.cshtml"
using TurkishExporterInventory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\_ViewImports.cshtml"
using TurkishExporterInventory.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f488d4ee6c740c31311dd6a8deeb54196ead93a4", @"/Views/User/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"981d9af5371b5bfa2a2a1b7e35e9bc46f6a890a2", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TurkishExporterInventory.Database.Models.UserListModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/UserForms/Userlist.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
  
    ViewData["Title"] = "UserList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f488d4ee6c740c31311dd6a8deeb54196ead93a44191", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">Tüm Kullanıcılar</h4>

                <table class=""table table-striped table-bordered"">
                    <thead>
                        <tr>
                            <th> Kullanıcı </th>
                            <th> İsim </th>
                            <th> Departman</th>
                            <th> Pozisyon</th>
                            <th> İlerleme </th>
                            <th> Toplam Ürün</th>
                            <th> Miktar </th>
                            <th> Son Ürün </th>
                            <th> Oluşturma Tarihi </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 29 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                         foreach (var user in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td class=\"py-1\">\r\n                                <img src=\"../../../assets/images/faces-clipart/pic-1.png\" alt=\"image\">\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                           Write(Html.DisplayFor(modeluser => user.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 35 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                                                                        Write(Html.DisplayFor(modeluser => user.UserSurname));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 36 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                           Write(Html.DisplayFor(modeluser => user.UserDepartment));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                           Write(Html.DisplayFor(modeluser => user.UserPosition));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                \r\n                                <div class=\"progress\">\r\n                                    <div class=\"progress-bar bg-success style1\"");
            BeginWriteAttribute("style", " style=\"", 1903, "\"", 1945, 2);
            WriteAttributeValue("", 1911, "width:", 1911, 6, true);
#nullable restore
#line 41 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
WriteAttributeValue("", 1917, user.UserItemCount*25+"%", 1917, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"progressbar\" aria-valuenow=\"25\" aria-valuemin=\"0\" aria-valuemax=\"100\"></div>\r\n                                </div>\r\n                            </td>\r\n                            <td class=\"text-danger\">");
#nullable restore
#line 44 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                                               Write(Html.DisplayFor(modeluser => user.UserItemCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"text-primary\">");
#nullable restore
#line 45 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                                                Write(Html.DisplayFor(modeluser => user.UserTotalValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 46 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                           Write(Html.DisplayFor(modeluser => user.UserLastItem));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 47 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                           Write(Html.DisplayFor(modeluser => user.UserRecordCreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 49 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\User\UserList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        \r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TurkishExporterInventory.Database.Models.UserListModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
