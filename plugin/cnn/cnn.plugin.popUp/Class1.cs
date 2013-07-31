using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using cnn.entities;
using System.Globalization;
[assembly: WebResource("cnn.plugin.popUp.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.popUp.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.popUp
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            List<DanhMuc> List = new List<DanhMuc>();
            string _ID = Request["ID"];
            string _LDM_Ma = Request["LDM_Ma"];
            #endregion
            switch (subAct)
            {

                case "test":
                    #region đếm số task của từng thành viên
                        sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.popUp.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div id=""tinnhanpopupmdl-ListConten"" style=""display:none"">
   11111111111111111111111111

</div>
                   
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.popUp.JScript1.js")
                    , "{tinnhanpopupObj.setup();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
       
    }
}
