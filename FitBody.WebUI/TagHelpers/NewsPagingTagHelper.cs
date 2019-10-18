using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FitBody.WebUI.TagHelpers
{
    [HtmlTargetElement("news-list-pager")]
    public class NewsPagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder=new StringBuilder();
            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'><a href='/News?page={1}'>{2}</a></li>",i==CurrentPage ? "active": "",i,i);
                   
                
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
           
        }
    }
}
