using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh;
using linh.common;
using docsoft;
using cnn.entities;
using docsoft.entities;
using System.Web;
using System.Web.UI;
using linh.json;
using linh.controls;
using System.Globalization;
[assembly: WebResource("cnn.plugin.doanhNghiep.chuaDuyet.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.doanhNghiep.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.doanhNghiep.chuaDuyet
{
    public class Class1 : docPlugUI
    {

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            switch (subAct)
            {

                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.doanhNghiep.doanhNghiep.js"));
                    break;
                    #endregion

                default:
                    #region Nap
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div id=""doanhNghiepChuaDuyetMdl-Main-NewDlg"">
      <div id=""doanhNghiepChuaDuyetMdl-head"" class=""mdl-head mdl-headTask ui-accordion-header ui-helper-reset ui-state-default ui-widget ui-corner-all"">                                                                            
                     <a class=""mdl-head-btn mdl-head-del"" id=""del"" href=""javascript:"" onclick=""doanhNghiepChuaDuyetFn.del();"" >Xóa</a>
                    <a class=""mdl-head-btn mdl-head-boxacnhan"" id=""xacnhan"" href=""javascript:""  onclick=""doanhNghiepChuaDuyetFn.xacnhan();"">Xác nhận</a>
                    <a class=""mdl-head-btn mdl-head-khoa"" id=""khoa"" href=""javascript:""  onclick=""doanhNghiepChuaDuyetFn.active();"">Khóa</a>
                    <a class=""mdl-head-btn mdl-head-nangcapthanhvien"" id=""NCTV"" href=""javascript:""  onclick=""doanhNghiepChuaDuyetFn.nangCapTV();"">Nâng cấp thành viên</a>
                <span>                                                         
                    <input type=""text"" _value="""" class=""admtxt-da ui-corner-all mdl-head-filterNhomSP"" /><button class=""admfilter-btn"" tabindex=""-1""></button>
                </span>                        
                <span>                           
                    <input type=""text"" _value="""" class=""admtxt-da ui-corner-all mdl-head-filterKhuVuc"" /><button class=""admfilter-btn"" tabindex=""-1""></button>                                    
                </span>
                <span>                                               
                    <input type=""text"" class=""admtxt-da ui-corner-all mdl-head-search-doanhNghiepTVBMdl"" /><button class=""admSearch-btn"" tabindex=""-1""></button>                            
                </span>               
      </div>
       <table id=""doanhNghiepChuaDuyetMdl-List"" class=""mdl-list""></table>
       <div id=""doanhNghiepChuaDuyetMdl-Pager""></div>


       <div id=""doanhNghiepChuaDuyetMdl-Body-NewDlg""></div>
       <div id=""doanhNghiepChuaDuyetMdl-ChungChi-NewDlg""></div>
       <div id=""doanhNghiepChuaDuyetMdl-Video-NewDlg""></div>
       <div id=""doanhNghiepChuaDuyetMdl-Flash-NewDlg""></div>
       <div id=""doanhNghiepChuaDuyetMdl-HinhAnh-NewDlg""></div>
       <div id=""doanhNghiepChuaDuyetMdl-NangCapTV-NewDlg""></div>

</div>                                                                      
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.doanhNghiep.chuaDuyet.JScript1.js")
                        , "{doanhNghiepChuaDuyetFn.NapdoanhNghiepFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
