#pragma checksum "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26bf4803465584f3108bc3867c0bbb7d514ed266"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__calendarPop), @"mvc.1.0.view", @"/Views/Shared/_calendarPop.cshtml")]
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
#line 1 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\_ViewImports.cshtml"
using HelperlandProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\_ViewImports.cshtml"
using HelperlandProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26bf4803465584f3108bc3867c0bbb7d514ed266", @"/Views/Shared/_calendarPop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47a79becad40becd6c2d0ff999db1ab901c6f6aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__calendarPop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HelperlandProject.Models.Popup>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"col-sm-6\">\r\n    <div class=\"vr\">\r\n        <p class=\"m-0 font-weight-bold\">");
#nullable restore
#line 17 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                   Write(Model.ServiceStartDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Duration : </span> ");
#nullable restore
#line 18 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                               Write(Model.ServiceHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hrs</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>ServiceId : </span>");
#nullable restore
#line 21 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                               Write(Model.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Extras : </span></p>\r\n        <p><span>Total Payment : </span>$");
#nullable restore
#line 23 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                    Write(Model.SubTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>Customer Name : </span>");
#nullable restore
#line 26 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                   Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 26 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                                    Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Service Address : </span>");
#nullable restore
#line 27 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                     Write(Model.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 27 "E:\tatva\rough2\HelperlandProject\HelperlandProject\Views\Shared\_calendarPop.cshtml"
                                                         Write(Model.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Distance : </span>27m</p>\r\n    </div>\r\n    <div class=\"vr\">\r\n        <p><span>Comments</span></p>\r\n        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>\r\n    </div>\r\n");
            WriteLiteral(@"</div>
<div class=""col-sm-6"">
    <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3671.697915724384!2d72.49824711400726!3d23.034861321651203!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395e8352e403437b%3A0xdc9d4dae36889fb9!2sTatvaSoft!5e0!3m2!1sen!2sin!4v1646805036684!5m2!1sen!2sin""
            width=""100%"" height=""400px"" style=""border:0;""");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 2162, "\"", 2180, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"></iframe>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HelperlandProject.Models.Popup> Html { get; private set; }
    }
}
#pragma warning restore 1591