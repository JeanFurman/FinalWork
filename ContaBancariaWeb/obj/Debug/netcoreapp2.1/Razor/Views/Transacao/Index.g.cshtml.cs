#pragma checksum "C:\Users\Aluno\source\repos\ContaBancariaWeb\ContaBancariaWeb\Views\Transacao\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "824ba7efb5bf33ccbebc955497b2d40e05904fe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transacao_Index), @"mvc.1.0.view", @"/Views/Transacao/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Transacao/Index.cshtml", typeof(AspNetCore.Views_Transacao_Index))]
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
#line 1 "C:\Users\Aluno\source\repos\ContaBancariaWeb\ContaBancariaWeb\Views\_ViewImports.cshtml"
using ContaBancariaWeb;

#line default
#line hidden
#line 2 "C:\Users\Aluno\source\repos\ContaBancariaWeb\ContaBancariaWeb\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"824ba7efb5bf33ccbebc955497b2d40e05904fe3", @"/Views/Transacao/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7350b46900ff4d9f08e0bda31f4e37cf09281c77", @"/Views/_ViewImports.cshtml")]
    public class Views_Transacao_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Aluno\source\repos\ContaBancariaWeb\ContaBancariaWeb\Views\Transacao\Index.cshtml"
  
    string nome = ViewBag.Nome;

#line default
#line hidden
            BeginContext(42, 16, true);
            WriteLiteral("\r\n<h2>Bem Vindo ");
            EndContext();
            BeginContext(59, 4, false);
#line 6 "C:\Users\Aluno\source\repos\ContaBancariaWeb\ContaBancariaWeb\Views\Transacao\Index.cshtml"
         Write(nome);

#line default
#line hidden
            EndContext();
            BeginContext(63, 10, true);
            WriteLiteral(" </h2>\r\n\r\n");
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