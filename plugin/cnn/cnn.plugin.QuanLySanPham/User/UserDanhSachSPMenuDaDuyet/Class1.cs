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
using System.IO;
[assembly: WebResource("cnn.plugin.QuanLySanPham.User.UserDanhSachSPMenuDaDuyet.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.QuanLySanPham.User.UserDanhSachSPMenuDaDuyet
{
    class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            switch (subAct)
            {
                case "scpt1":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Publish.js"));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.User.UserDanhSachSPMenuDaDuyet.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""UserDSSPMenuDaDuyetFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-UserDSSPMenuDaDuyetFn"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""UserDSSPMenuDaDuyetFnMdl-editBtn"" href=""javascript:"" onclick=""UserDSSPMenuDaDuyetFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""UserDSSPMenuDaDuyetFnMdl-delBtn"" href=""javascript:"" onclick=""UserDSSPMenuDaDuyetFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""UserDSSPMenuDaDuyetFnMdl-delBtn"" href=""javascript:"" onclick=""UserDSSPMenuDaDuyetFn.LamMoi();"" >Refresh</a>
                            </div>
                            <table id=""UserDSSPMenuDaDuyetFnMdl-List"" class=""mdl-list""></table>
                            <div id=""UserDSSPMenuDaDuyetFnMdl-Pager""></div>
                            <div id=""UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew""></div>
                            <div id=""UserDSSPMenuDaDuyetFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.User.UserDanhSachSPMenuDaDuyet.JScript1.js")
                        , "{UserDSSPMenuDaDuyetFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
