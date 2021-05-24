#pragma checksum "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b55f5100c6273f880c8387827430c0b584c3e60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(tax_web.Pages.Home.Views_Home_NewTaxCalculation), @"mvc.1.0.view", @"/Views/Home/NewTaxCalculation.cshtml")]
namespace tax_web.Pages.Home
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
#line 1 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/_ViewImports.cshtml"
using tax_web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/_ViewImports.cshtml"
using tax_web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b55f5100c6273f880c8387827430c0b584c3e60", @"/Views/Home/NewTaxCalculation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c1bd9ac163073a31ed0550a3c006a05817e85bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NewTaxCalculation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TaxCalculation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NewTaxCalculation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
   Layout = "_Layout"; ViewBag.Title = "Add a Reservation";

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n<h2>Calculate Tax</h2>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b55f5100c6273f880c8387827430c0b584c3e604134", async() => {
                WriteLiteral(@"
    <div class=""form-group"">
        <label for=""PostalCode"">Postal Code:</label>
        <input class=""form-control"" name=""PostalCode"" required/>
    </div>
    <div class=""form-group"">
        <label for=""Income"">Income:</label>
        <input class=""form-control"" name=""Income"" required/>
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Calculate</button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n \n");
#nullable restore
#line 19 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <h2>Calculated Tax</h2>
    <table class=""table table-sm table-striped table-bordered m-2"">
        <thead>
            <tr>
                <th>ID</th>
                <th>Postal Code</th>
                <th>Income</th>
                <th>Tax</th>
                <th>Calculated Date & Time</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 34 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
               Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 35 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
               Write(Model.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 36 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
               Write(Model.Income);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td><strong>");
#nullable restore
#line 37 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
                       Write(Model.Tax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\n                <td>");
#nullable restore
#line 38 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
               Write(Model.CalculatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n        </tbody>\n    </table>\n");
#nullable restore
#line 42 "/Volumes/YoungDrive/My Files/Dev/Assignments/TaxCalculator/tax-web/Views/Home/NewTaxCalculation.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TaxCalculation> Html { get; private set; }
    }
}
#pragma warning restore 1591
