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
[assembly: WebResource("cnn.plugin.QuanLySanPham.User.UserDanhSachSPDacTrung.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.QuanLySanPham.User.UserDanhSachSPDacTrung
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.User.UserDanhSachSPDacTrung.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""DanhSachSanPhamDacTrungFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-DanhSachSanPhamDacTrungFn"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""DanhSachSanPhamDacTrungFnMdl-editBtn"" href=""javascript:"" onclick=""DanhSachSanPhamDacTrungFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DanhSachSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DanhSachSanPhamDacTrungFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DanhSachSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DanhSachSanPhamDacTrungFn.DangKySanPhamDacTrung();"" >Đăng ký SP đặc trưng</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DanhSachSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DanhSachSanPhamDacTrungFn.DangKySanPhamMenu();"" >Đăng ký SP Menu</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DanhSachSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DanhSachSanPhamDacTrungFn.LamMoi();"" >Refresh</a>
                            </div>
                            <table id=""DanhSachSanPhamDacTrungFnMdl-List"" class=""mdl-list""></table>
                            <div id=""DanhSachSanPhamDacTrungFnMdl-Pager""></div>
                            <div id=""DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew""></div>
                            <div id=""DanhSachSanPhamDacTrungFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.User.UserDanhSachSPDacTrung.JScript1.js")
                        , "{DanhSachSanPhamDacTrungFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
