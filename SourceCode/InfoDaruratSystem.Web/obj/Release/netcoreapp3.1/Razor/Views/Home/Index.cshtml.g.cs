#pragma checksum "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0995ea258d29e70d691b45cbcd57c499754a7a42"
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
#line 1 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Authentication.Cookies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
using InfoDaruratSystem.Web.Library.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
using InfoDaruratSystem.Web.Library.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0995ea258d29e70d691b45cbcd57c499754a7a42", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9922e81b2b11cb63f93ab2f703bcb0705b00c63e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/images/Alert.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("70"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("70"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 6 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Dashboard v.1";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .switch-field {
        display: flex;
        margin-bottom: 36px;
        overflow: hidden;
    }

        .switch-field input {
            position: absolute !important;
            clip: rect(0, 0, 0, 0);
            height: 1px;
            width: 1px;
            border: 0;
            overflow: hidden;
        }

        .switch-field label {
            background-color: white;
            color: rgba(0, 0, 0, 0.6);
            font-size: 14px;
            line-height: 1;
            text-align: center;
            padding: 8px 16px;
            margin-right: -1px;
            border: 1px solid rgba(0, 0, 0, 0.2);
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.3), 0 1px rgba(255, 255, 255, 0.1);
            transition: all 0.1s ease-in-out;
        }

            .switch-field label:hover {
                cursor: pointer;
            }

        .switch-field input:checked + label {
            background-color: #F03737;
            box-shad");
            WriteLiteral(@"ow: none;
        }

        .switch-field label:first-of-type {
            border-radius: 4px 0 0 4px;
        }

        .switch-field label:last-of-type {
            border-radius: 0 4px 4px 0;
        }

    /* This is just for CodePen. */

    .form {
        max-width: 600px;
        font-family: ""Lucida Grande"", Tahoma, Verdana, sans-serif;
        font-weight: normal;
        line-height: 1.625;
        margin: 8px auto;
        padding: 16px;
    }

    h2 {
        font-size: 18px;
        margin-bottom: 8px;
    }

</style>


<div class=""content-page"">
    <div class=""content"">

        <!-- Start Content-->
        <div class=""container-fluid"">

            <div class=""row page-title"">
                <div class=""col-md-12"">
");
#nullable restore
#line 84 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                     if (ViewData["vdHeaderName"] != null)
                    {
                        string userName = "";

                        userName = ViewData["vdHeaderName"].ToString();


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"pro-user-name mt-0 mb-0\"><b>Welcome ");
#nullable restore
#line 90 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                                  Write(userName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ! </b></h3>\r\n                        <br />\r\n                        <h6 class=\"pro-user-name mt-0 mb-0\">");
#nullable restore
#line 92 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                       Write(DateTime.Now.ToString("dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 92 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                                                    Write(DateTime.Now.ToString("MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 92 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                                                                                   Write(DateTime.Now.ToString("yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 93 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>

            <span style=""margin-top:50px;""></span>

            <br />

            <div class=""row"" style=""width:75%;"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body"">

                            <div class=""table-responsive"">

                                <table class=""table mb-0 kartuTable"" width=""70%"" style=""overflow:hidden;"">
                                    <thead class=""thead-light"">
                                        <tr>
                                            <th class=""text-left"">No.</th>
                                            <th class=""text-left"">No. Kartu</th>
                                            <th class=""text-left"">Nama Pengunjung</th>
                                            <th class=""text-left"">Keterangan Kartu</th>
                                        </tr>
                                    </thead>
              ");
            WriteLiteral("                      <tbody>\r\n\r\n");
#nullable restore
#line 119 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                         if (ViewData["vdKartuList"] != null)
                                        {
                                            int rowNo = 0;

                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                             foreach (var item in (ViewData["vdKartuList"] as List<KartuEntity.Kartu>))
                                            {
                                                rowNo++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 128 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                   Write(rowNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 131 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                   Write(item.NoKartu);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 134 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                   Write(item.NamaPetugas);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 137 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                                   Write(item.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 140 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"

                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "E:\TrialASPNet\SistemInformasiKeadaanDarurat\SourceCode\InfoDaruratSystem.Web\Views\Home\Index.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </tbody>
                                </table>



                            </div>
                        </div>
                    </div>
                </div>


            </div>




            <div style=""position:absolute; margin-left:794px; margin-top:-205px; 
                     background-color: #FFFFFF; width: 250px; height: 250px;"">

                <div style=""position:absolute; margin-left:85px; margin-top:30px; width:100%;"" >

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0995ea258d29e70d691b45cbcd57c499754a7a4214464", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                    <div style=""position:absolute; margin-left:-40px; margin-top:0px; "">

                        <h5 class=""text-center""><b>Testing Mode</b></h5>

                        <label style=""font-size:11px; text-align:center;"">Aktifkan testing dengan mengklik <br /> tombol dibawah</label>

                        <br />

                        <div class=""switch-field"" style=""margin-left:30px;"">

                            <input type=""radio"" id=""radio-one"" name=""switch-one"" value=""On"" checked />
                            <label for=""radio-one"">On</label>

                            <input type=""radio"" id=""radio-two"" name=""switch-one"" value=""Off"" />
                            <label for=""radio-two"">Off</label>

                        </div>


                    </div>


                </div>

            </div>

");
            WriteLiteral("\r\n\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
