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
[assembly: WebResource("cnn.plugin.QuanLySanPham.Admin.AdminSPMoi.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.QuanLySanPham.Admin.AdminSPMoi
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Admin.AdminSPMoi.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""AdminDanhSachSanPhamFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search txtSearch"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""AdminDanhSachSanPhamFnMdl-editBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.add();"">Thêm</a>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""AdminDanhSachSanPhamFnMdl-editBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.DangKySanPhamDacTrung();"" >ĐKSP đặc trưng</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.DangKySanPhamMenu();"" >ĐKSP menu</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.DungTin();"" >Dừng SP</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.LamMoi();"" >F5</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""AdminDanhSachSanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""AdminDanhSachSanPhamFn.ChuyenThanhTinBanGiong();"" >Chuyển tin Bán giống</a>
                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" _value="""" class=""mdl-head-filter FilterDMSP""/>
                                </span>
                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" _value="""" class=""mdl-head-filter FilterGHID""/>
                                </span>
                            </div>
                            <table id=""AdminDanhSachSanPhamFnMdl-List"" class=""mdl-list""></table>
                            <div id=""AdminDanhSachSanPhamFnMdl-Pager""></div>
                            <div id=""AdminDanhSachSanPhamFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""AdminDanhSachSanPhamFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew""></div>
                            <div id=""AdminDanhSachSanPhamFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Admin.AdminSPMoi.JScript1.js")
                        , "{AdminDanhSachSanPhamFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
