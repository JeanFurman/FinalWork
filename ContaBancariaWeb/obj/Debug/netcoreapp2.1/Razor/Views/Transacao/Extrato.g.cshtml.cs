#pragma checksum "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81f5544f92768427dc7dd92f0032e3799b6d62fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transacao_Extrato), @"mvc.1.0.view", @"/Views/Transacao/Extrato.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Transacao/Extrato.cshtml", typeof(AspNetCore.Views_Transacao_Extrato))]
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
#line 1 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\_ViewImports.cshtml"
using ContaBancariaWeb;

#line default
#line hidden
#line 2 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81f5544f92768427dc7dd92f0032e3799b6d62fe", @"/Views/Transacao/Extrato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7350b46900ff4d9f08e0bda31f4e37cf09281c77", @"/Views/_ViewImports.cshtml")]
    public class Views_Transacao_Extrato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Transacao>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
  
    string Total = ViewBag.SaldoExtrato;
    string Divida = ViewBag.DividaExtrato;


#line default
#line hidden
            BeginContext(119, 349, true);
            WriteLiteral(@"
<h1>Extrato Cliente</h1>

<table class=""table table-hover table-striped"" style=""margin-top:15px; margin-bottom:15px"">
    <thead>
        <tr class=""table-secondary"">
            <th>Numero da Conta</th>
            <th>Valor</th>
            <th>Descrição</th>
            <th>Data</th>
            </tr>

      </thead>
    <tbody>
");
            EndContext();
#line 21 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
         foreach (Transacao item in Model)
        {

#line default
#line hidden
            BeginContext(523, 59, true);
            WriteLiteral("            <tr class=\"table-light\">\r\n                <td> ");
            EndContext();
            BeginContext(583, 16, false);
#line 24 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
                Write(item.NumeroConta);

#line default
#line hidden
            EndContext();
            BeginContext(599, 28, true);
            WriteLiteral("</td>\r\n                <td> ");
            EndContext();
            BeginContext(628, 10, false);
#line 25 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
                Write(item.Valor);

#line default
#line hidden
            EndContext();
            BeginContext(638, 28, true);
            WriteLiteral("</td>\r\n                <td> ");
            EndContext();
            BeginContext(667, 14, false);
#line 26 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
                Write(item.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(681, 28, true);
            WriteLiteral("</td>\r\n                <td> ");
            EndContext();
            BeginContext(710, 9, false);
#line 27 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
                Write(item.Data);

#line default
#line hidden
            EndContext();
            BeginContext(719, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
        }

#line default
#line hidden
            BeginContext(756, 39, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<h3>Saldo: R$");
            EndContext();
            BeginContext(796, 5, false);
#line 33 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
        Write(Total);

#line default
#line hidden
            EndContext();
            BeginContext(801, 49, true);
            WriteLiteral(" </h3><br/>\r\n<p style=\"color: #ff0000\">Divida: R$");
            EndContext();
            BeginContext(851, 6, false);
#line 34 "C:\Users\hiaau\Source\Repos\TRABALHO FINAL\FinalWork\ContaBancariaWeb\Views\Transacao\Extrato.cshtml"
                               Write(Divida);

#line default
#line hidden
            EndContext();
            BeginContext(857, 8, true);
            WriteLiteral("</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Transacao>> Html { get; private set; }
    }
}
#pragma warning restore 1591
