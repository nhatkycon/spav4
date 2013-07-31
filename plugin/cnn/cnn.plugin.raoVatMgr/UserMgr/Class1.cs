using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using cnn.entities;
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("cnn.plugin.raoVatMgr.UserMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.raoVatMgr.UserMgr.htm.htm", "text/html")]
namespace cnn.plugin.raoVatMgr.UserMgr
{
    class Class1: docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            #region tham số
            string _ID = Request["ID"];
            string _user = Request["user"];
            string _tungay = Request["tungay"];
            string _denngay = Request["denngay"];

            #endregion

            switch (subAct)
            { 
                case "get":
                    #region tham số
                    break;
            
                    #endregion
                case "save":
                    #region tham số
                    break;

                    #endregion
                case "view":
                    #region tham số
                    break;

                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.UserMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    //<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"" style=""width:100%;"">
                            //</span>
                #region nạp js
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div class=""mdl-head mdl-headTask ui-accordion-header ui-helper-reset ui-state-default ui-widget ui-corner-all"" id=""totrinhmdl-headTask"">
                           Lọc:
                                <input type=""text"" _value="""" class=""admtxt-medium ui-corner-all admtxt mdl-head-filterthanhvien""/><button class=""admfilter-btn""></button>
                                <input type=""text"" _value="""" class=""admtxt-medium ui-corner-all admtxt-medium mdl-head-tungay""/><button class=""admfilter-btn admfilter-btnDate""></button>
                                <input type=""text"" _value="""" class=""admtxt-medium ui-corner-all admtxt-medium mdl-head-denngay""/>
                                <button class=""admfilter-btn admfilter-btnDate""></button>
                        </div>

                        <center>
                            <div class=""username""></div>
                            <div class=""header-count-link"">
                                <a href=""#"">Tin mới<label class=""Newscount""></label></a>
                                <a href=""#"">Tin víp<label class=""Vipcount""></label></a>
                                <a href=""#"">Tin thường<label class=""Normalcount""></label></a>
                                <a href=""#"">Tin hết hạn<label class=""Expiredcount""></label></a>
                            </div>
                        </center>
                        <table id=""RaoVatUserMgrmdl-List""></table>
                        <div id=""MemInfo""></div>
                                ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.UserMgr.JScript1.js")
                        , "{UserMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }

            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
