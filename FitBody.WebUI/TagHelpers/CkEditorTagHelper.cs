using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FitBody.WebUI.TagHelpers
{
    [HtmlTargetElement("news-details-pager")]
    public class CkEditorTagHelper:TagHelper
    {
        [HtmlAttributeName("current-details")]
        public string CurrentDetails { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(CurrentDetails);
            

            output.Content.SetHtmlContent(stringBuilder.ToString());



            base.Process(context, output);
        }
    }
}
