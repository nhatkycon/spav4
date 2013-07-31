using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
public partial class lib_aspx_sys_UploadWc : System.Web.UI.Page
{
    string SaveDirAnh = HttpContext.Current.Server.MapPath("~/lib/up/");
    string Anh = HttpContext.Current.Request["Anh"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Anh != null)
        {
            Request.Files[0].SaveAs(SaveDirAnh + Anh);
        }
    }
}