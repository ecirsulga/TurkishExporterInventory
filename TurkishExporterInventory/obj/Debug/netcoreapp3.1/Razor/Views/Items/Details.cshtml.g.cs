#pragma checksum "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0feae42b17143d00b37d63c75d8bbf6adea6222"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_Details), @"mvc.1.0.view", @"/Views/Items/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0feae42b17143d00b37d63c75d8bbf6adea6222", @"/Views/Items/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"981d9af5371b5bfa2a2a1b7e35e9bc46f6a890a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TurkishExporterInventory.Database.Models.ItemListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ItemList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Item</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PriceTL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.PriceTL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Purpose));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.Purpose));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BuyingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.BuyingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.rlt_Supplier_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.rlt_Supplier_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RecordCreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
       Write(Html.DisplayFor(model => model.RecordCreateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            <span>Eşya Durumu</span>\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 54 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
              


                if (Model.LastUserName == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Eşya daha önce kimseye tahsis edilmemiş.</span>\r\n");
#nullable restore
#line 60 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                }

                else if(Model.ReturnDate == DateTime.MinValue)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Eşya ");
#nullable restore
#line 64 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                          Write(Model.LastUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \'ın elinde.</span>\r\n");
#nullable restore
#line 65 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span>Eşya ");
#nullable restore
#line 68 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                          Write(Model.LastUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" adlı kullanıcı tarafından ");
#nullable restore
#line 68 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                                                                        Write(Model.ReturnDate.Date.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" tarihinde şirkete teslim edilmiş.</span>\r\n");
#nullable restore
#line 69 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                }

            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0feae42b17143d00b37d63c75d8bbf6adea622210704", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\User\Desktop\TurkishExporter\Envanter\TurkishExporterInventory\Views\Items\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0feae42b17143d00b37d63c75d8bbf6adea622212866", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TurkishExporterInventory.Database.Models.ItemListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
