using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
namespace linh.core
{
    public class BasedPage:Page
    {
        public void rendertext(string txt)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(string txt,string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(sb.ToString());
            Response.End();
        }
        public string domain
        {
            get
            {
                HttpContext c = HttpContext.Current;
                return string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            }
        }
        
    }
    public class BasedUi : System.Web.UI.UserControl
    {

        public void rendertext(string txt)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(string txt, string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(sb.ToString());
            Response.End();
        }
        public void rendertext(StringBuilder sb, string contentType)
        {
            Response.ClearContent();
            Response.ContentType = contentType;
            Response.Write(sb.ToString());
            Response.End();
        }
        public string domain
        {
            get
            {
                HttpContext c = HttpContext.Current;
                return string.Format("http://{0}{1}", c.Request.Url.Host
                    , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (string.IsNullOrEmpty(c.Request.ApplicationPath) ? "" : string.Format("{0}", c.Request.ApplicationPath)));
            }
        }
    }
}
