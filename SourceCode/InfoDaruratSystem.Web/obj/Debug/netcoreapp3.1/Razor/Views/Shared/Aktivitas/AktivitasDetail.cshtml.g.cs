#pragma checksum "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59cba655b013066dcbdf95168a6ccdc0acc3397e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Aktivitas_AktivitasDetail), @"mvc.1.0.view", @"/Views/Shared/Aktivitas/AktivitasDetail.cshtml")]
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
#line 1 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\_ViewImports.cshtml"
using InfoDaruratSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\_ViewImports.cshtml"
using InfoDaruratSystem.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
using InfoDaruratSystem.Web.Library.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59cba655b013066dcbdf95168a6ccdc0acc3397e", @"/Views/Shared/Aktivitas/AktivitasDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9922e81b2b11cb63f93ab2f703bcb0705b00c63e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Aktivitas_AktivitasDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
  
    ViewData["Title"] = "Aktivitas Detail Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""modal-form-aktivitasdetail"" class=""modal"" aria-hidden=""true""
     data-keyboard=""false"" data-backdrop=""static""
     style=""top:10%; left:25%; width:50%; overflow:hidden;  "">

    <div class=""modal-dialog"">
        <div class=""modal-content"" style=""width:120%;"">

            <div class=""modal-header btn-primary"" style=""text-align:left; background-color:white;"">
                <h4 class=""modal-title font-bold"" style=""color:#F03737;""><div id=""title""></div></h4>
            </div>

            <div class=""modal-body"" style=""height:300px; padding-left:30px; padding-top:30px;"">

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59cba655b013066dcbdf95168a6ccdc0acc3397e5386", async() => {
                WriteLiteral("\r\n\r\n                    <input type=\"hidden\" id=\"hdnId\"");
                BeginWriteAttribute("value", " value=\"", 813, "\"", 821, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n\r\n                    <div class=\"form-group row\">\r\n                        <label class=\"col-lg-3\">Kartu</label>\r\n                        <div class=\"col-lg-6\">\r\n                            <input id=\"hiddenKartuId\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1059, "\"", 1067, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <select class=\"form-control\" id=\"ddlKartu\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59cba655b013066dcbdf95168a6ccdc0acc3397e6386", async() => {
                    WriteLiteral("-- select kartu --");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 31 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                 foreach (var itemKartu in (ViewData["vdKartuList"] as List<KartuEntity.Kartu>))
                                {
                                    bool isActive = Convert.ToBoolean(itemKartu.IsActive);
                                    string strIsActive = isActive ? "Aktif" : "Tidak Aktif";


#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59cba655b013066dcbdf95168a6ccdc0acc3397e8234", async() => {
#nullable restore
#line 36 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                                             Write(itemKartu.NoKartu);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 36 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                                                                  Write(itemKartu.Desc);

#line default
#line hidden
#nullable disable
                    WriteLiteral(" - ");
#nullable restore
#line 36 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                                                                                    Write(strIsActive);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                       WriteLiteral(itemKartu.ID);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 37 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Shared\Aktivitas\AktivitasDetail.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-3"">Jam Masuk</label>
                        <div class=""col-lg-4"">
                            <input id=""txtJamMasuk"" type=""text"" placeholder=""Jam Masuk"" maxlength=""10"" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 2113, "\"", 2121, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>

                    <div class=""form-group row"">
                        <label class=""col-lg-3"">Jam Keluar</label>
                        <div class=""col-lg-4"">
                            <input id=""txtJamKeluar"" type=""text"" placeholder=""Jam Keluar"" maxlength=""10"" class=""form-control""");
                BeginWriteAttribute("value", " value=\"", 2478, "\"", 2486, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        </div>\r\n                    </div>\r\n\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


            </div>


            <div class=""modal-footer"" style=""width:100%; left:10%;"">
                <button class=""btn btn-primary mt-2 mr-1"" type=""button"" style=""width:20%; left:0; background-color:#F03737;""
                        onclick=""getClose();"">
                    <b>Cancel</b>
                </button>
                <button class=""btn btn-primary mt-2 mr-1"" type=""button"" style=""width:20%; left:0; background-color:#F03737;""
                        onclick=""getSave();"">
                    <b>Save</b>
                </button>

            </div>

        </div>
    </div>
</div>

");
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