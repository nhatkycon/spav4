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
[assembly: WebResource("cnn.plugin.DangKyDichVu.DKSanPhamMenu.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.DangKyDichVu.DKSanPhamMenu
{
    class Class1: docPlugUI
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSanPhamMenu.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""DKSanPhamMenuFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-DKSanPhamMenuFn"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-add"" id=""DKSanPhamMenuFnMdl-addBtn"" href=""javascript:"" onclick=""DKSanPhamMenuFn.add();"">Thêm</a>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""DKSanPhamMenuFnMdl-editBtn"" href=""javascript:"" onclick=""DKSanPhamMenuFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DKSanPhamMenuFnMdl-delBtn"" href=""javascript:"" onclick=""DKSanPhamMenuFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DKSanPhamMenuFnMdl-delBtn"" href=""javascript:"" onclick=""DKSanPhamMenuFn.DangKySanPhamDacTrung();"" >Đăng ký Sản phẩm Menu</a>
                            </div>
                            <table id=""DKSanPhamMenuFnMdl-List"" class=""mdl-list""></table>
                            <div id=""DKSanPhamMenuFnMdl-Pager""></div>
                            <div id=""DKSanPhamMenuFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""DKSanPhamMenuFnMdl-HangHoatempMdl-DKSanPhamMenu-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSanPhamMenu.JScript1.js")
                        , "{DKSanPhamMenuFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
