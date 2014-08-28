﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Root.Views.Shared.Partial
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Shared\Partial\ContentsTree.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Partial/ContentsTree.cshtml")]
    public partial class ContentsTree : System.Web.Mvc.WebViewPage<dynamic>
    {
        public ContentsTree()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"bcms-contents-tree-template\"");

WriteLiteral(@">
    <div class=""bcms-scroll-window"">
        <div class=""bcms-padded-content"">
            <div data-bind=""visible: visibleItems().length > 0, with: visibleItems()"">
                <h2 data-bind=""visible: $parent.invisibleItems().length > 0"">TODO: Visible regions</h2>
                <div data-bind='template: { name: ""bcms-contents-tree-list-template"" }'></div>
            </div>
            <div data-bind=""visible: invisibleItems().length > 0, with: invisibleItems()"">
                <h2>TODO: Invisible regions</h2>
                <div data-bind='template: { name: ""bcms-contents-tree-list-template"" }'></div>
            </div>
        </div>
    </div>
</script>

<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(@">
    .bcms-contents-tree-region {
        border: 1px dashed blue;
        margin: 20px;
        padding: 10px;
    }
        .bcms-contents-tree-region:hover {
            background-color: #EFEFEF;
        }

        .bcms-contents-tree-region .bcms-contents-tree-region-icons {
            display: none;
            float: right;
        }

        .bcms-contents-tree-region:hover .bcms-contents-tree-region-icons {
            display: block;
        }

    .bcms-contents-tree-content {
        border: 1px solid black;
        margin: 5px;
        padding: 5px;
    }

        .bcms-contents-tree-content:hover {
            background-color: #EFEFEF;
        }

        .bcms-contents-tree-content .bcms-contents-tree-content-icons {
            display: none;
            float: right;
        }

        .bcms-contents-tree-content:hover .bcms-contents-tree-content-icons {
            display: block;
        }

    .bcms-contents-tree-region-header {
        color: blue;
    }
</style>

<script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"bcms-contents-tree-list-template\"");

WriteLiteral(@">
    <!-- ko if: $data.length > 0 -->
    <!-- ko foreach: $data -->

    <div data-bind=""css: {'bcms-contents-tree-region': type == types.region, 'bcms-contents-tree-content': type == types.content}"">

        <div data-bind=""css: {'bcms-contents-tree-region-header': type == types.region}"">
            <span data-bind=""text: model.title""></span>
            <div data-bind=""css: {'bcms-contents-tree-region-icons': type==types.region, 'bcms-contents-tree-content-icons': type==types.content}"">
                <!-- ko if: type == types.content -->
                <!-- ko if: model.visibleButtons.configure -->
                <a class=""bcms-pointer"" data-bind=""click: configure"">TODO: Configure</a>
                <!-- /ko -->
                <!-- ko if: model.visibleButtons.history -->
                <a class=""bcms-icn-history"" data-bind=""click: history""></a>
                <!-- /ko -->
                <!-- ko if: model.visibleButtons.edit -->
                <a class=""bcms-icn-edit"" data-bind=""click: editItem"">");

            
            #line 78 "..\..\Views\Shared\Partial\ContentsTree.cshtml"
                                                                Write(RootGlobalization.Button_Edit);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                <!-- /ko -->\r\n                <!-- ko if: model.visibleButt" +
"ons.delete -->\r\n                <a class=\"bcms-icn-delete\" data-bind=\"click: del" +
"eteItem\">");

            
            #line 81 "..\..\Views\Shared\Partial\ContentsTree.cshtml"
                                                                    Write(RootGlobalization.Button_Delete);

            
            #line default
            #line hidden
WriteLiteral(@"</a>
                <!-- /ko -->
                <!-- /ko -->
                <!-- ko if: type == types.region -->
                <div class=""bcms-region-button bcms-region-addcontent"" data-bind=""click: addContent""></div>
                <!-- /ko -->
            </div>
        </div>
        
        <div data-bind=""with: items()"">
            <div data-bind=""template: { name: 'bcms-contents-tree-list-template' }""></div>
        </div>
    </div>

    <!-- /ko -->
    <!-- /ko -->
</script>");

        }
    }
}
#pragma warning restore 1591
