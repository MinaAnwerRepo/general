using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UberReportingTool.CustomHelpers
{
    public static class CustomHTMLHelpers
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }

        public static IHtmlString Image(this HtmlHelper helper, string src, string alt, object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);

            if (htmlAttributes != null)
            {
                foreach (
                    System.ComponentModel.PropertyDescriptor property in
                    System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes))
                {
                    tb.Attributes.Add(property.Name, property.GetValue(htmlAttributes).ToString());
                }
            }
            string htmlResult = tb.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(htmlResult);
        }

        public static IHtmlString Trip(this HtmlHelper helper)
        {




            string src =string.Format(@"<div class='row'>
    <div class='col-md-7'>
        <a href = '#' >
            <img class='img-fluid rounded mb-3 mb-md-0' src='http://placehold.it/700x300' alt=''>
        </a>
    </div>
    <div class='col-md-5'>
        <h3>Project One</h3>
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.Laudantium veniam exercitationem expedita laborum at voluptate.Labore, voluptates totam at aut nemo deserunt rem magni pariatur quos perspiciatis atque eveniet unde.</p>
        <a class='btn btn-primary' href='#'>View Project</a>
    </div>
</div>");
           


            return  new MvcHtmlString(src);
        }



        public static IHtmlString Line(this HtmlHelper helper)
        {
            return new MvcHtmlString("<hr/>"); 
        }
    }
}