#pragma checksum "C:\Users\Admin\RiderProjects\ASP.NET\WebApplicationNet5\WebApplicationNet5\Views\Ajax\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "603549f2cd94b011e0eaf6542a6482a0c649f159"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ajax_Index), @"mvc.1.0.view", @"/Views/Ajax/Index.cshtml")]
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
#line 1 "C:\Users\Admin\RiderProjects\ASP.NET\WebApplicationNet5\WebApplicationNet5\Views\_ViewImports.cshtml"
using WebApplicationNet5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\RiderProjects\ASP.NET\WebApplicationNet5\WebApplicationNet5\Views\_ViewImports.cshtml"
using WebApplicationNet5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"603549f2cd94b011e0eaf6542a6482a0c649f159", @"/Views/Ajax/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"109435be5ff4aad5166abc3cc17f6f2308af6d28", @"/Views/_ViewImports.cshtml")]
    public class Views_Ajax_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\RiderProjects\ASP.NET\WebApplicationNet5\WebApplicationNet5\Views\Ajax\Index.cshtml"
  
    ViewData["Title"] = "Ajax Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome Ajax</h1>
</div>

<main id=""main"">

</main>

<div id=""TeachersContainer"">
    Load...
</div>

<div id=""newTeacher"" class=""d-flex justify-content-center mt-5"">
    <div class=""input-group mb-3 w-50"">
        <div class=""input-group-prepend"">
            <span class=""input-group-text"" id=""basic-addon1"">Name</span>
        </div>
        <input id=""inputTeacherName"" type=""text"" class=""form-control"" placeholder=""Name"" aria-label=""Name"" aria-describedby=""basic-addon1"">
        <button type=""button"" class=""btn btn-primary"" id=""btnCreateTeacher"">Create</button>
    </div>
</div>

<div id=""GroupsContainer"">
    Load...
</div>

<div id=""newGroup"" class=""d-flex justify-content-center mt-5"">
    <div class=""input-group mb-3 w-50"">
        <div class=""input-group-prepend"">
            <span class=""input-group-text"" id=""basic-addon2"">Name</span>
        </div>
        <input id=""inputGroupName"" type=""text"" class=""form-control"" pla");
            WriteLiteral(@"ceholder=""Name"" aria-label=""Name"" aria-describedby=""basic-addon2"">
        <select class=""form-select"" id=""selectTeacherForGroup""></select>
        <button type=""button"" class=""btn btn-primary"" id=""btnCreateGroup"">Create</button>
    </div>
</div>

<script src=""js/HtmlTableGenerator.js""></script>

<script>
    console.log(""Ajax Ready"");
    fetchGetTeachers();
    fetchGetGroups();
    fetchGetFreeTeachers()
    document.querySelector(""#btnCreateTeacher"").onclick = function () {
        let newTeacher = {
            id: 0,
            name: document.querySelector(""#inputTeacherName"").value
        };
        Create(newTeacher, ""api/teachers"", fetchGetTeachers)
        document.querySelector(""#inputTeacherName"").value = """";
    }
    
    document.querySelector(""#btnCreateGroup"").onclick = function () {
        let newGroup = {
            id: 0,
            name: document.querySelector(""#inputGroupName"").value,
            teacherId: document.querySelector(""#selectTeacherForGroup"").");
            WriteLiteral(@"value
        };
        Create(newGroup, ""api/groups"", fetchGetGroups)
        document.querySelector(""#inputGroupName"").value = """";
    }
    
    function renderTeachersList(teachers) {
        RenderTable(
                    GetHtmlTable(
                    {
                        collection: teachers,
                        editable: 
                            {
                                name: { type: ""text"" },
                            },
                        path: ""api/teachers/""
                    }
                ), ""TeachersContainer"");
    }
    
    function renderGroupsList(groups) {
        RenderTable(
            GetHtmlTable(
            {
                collection: groups,
                hidden: [""teacherId""],
                editable: {
                        name: { type: ""text"" },
                        teacherName: { 
                            type: ""dropDown"",
                            source: ""api"",
                            ");
            WriteLiteral(@"path: ""/api/teachers/"",
                            defaultValue: ""teacherId"",
                            defaultText: ""teacherName"",
                            value: ""id"",
                            text: ""name"",
                            filter: (t => t.group === ""No group"")
                        }
                },
                path: ""api/groups/""
            }   
        ), ""GroupsContainer"");
    }
    
    function fetchGetTeachers() {
        FetchGetJson(""/api/teachers"", renderTeachersList);
    }
    
    function fetchGetGroups() {  
        FetchGetJson(""/api/groups"", renderGroupsList);
    }
    
    function fetchGetFreeTeachers(teachers) {
        FetchGetJson(""/api/teachers"", (collection) => 
        AddSelectOptions(""selectTeacherForGroup"", collection.filter(t => t.group === ""No group""), ""id"", ""name""));
    }

    
    function AddSelectOptions(selectId ,collection, value, text)
    {
        console.log(collection)
        let select = document.queryS");
            WriteLiteral(@"elector(""#"" + selectId)
        for (const item of collection) {
            let option = document.createElement(""option"");
            option.value = item[value];
            option.innerText = item[text];
            select.append(option);
        }
    }
    
   
</script>");
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
