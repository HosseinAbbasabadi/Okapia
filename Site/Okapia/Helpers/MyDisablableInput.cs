using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Okapia.Helpers
{
    [HtmlTargetElement("input")]
    public class MyDisablableInput : TagHelper
    {
        [HtmlAttributeName("asp-is-disabled")]
        public string CardValue { set; get; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(CardValue))
            {
                var d = new TagHelperAttribute("disabled", "disabled");
                output.Attributes.Add(d);
            }
            base.Process(context, output);
        }
    }
}
