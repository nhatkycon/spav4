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
[assembly: WebResource("cnn.plugin.DangKyDichVu.DKSPDacTrungNew.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.DangKyDichVu.DKSPDacTrungNew
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSPDacTrungNew.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""DKSanPhamDacTrungFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-DKSanPhamDacTrungFn"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-add"" id=""DKSanPhamDacTrungFnMdl-addBtn"" href=""javascript:"" onclick=""DKSanPhamDacTrungFn.add();"">Thêm</a>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""DKSanPhamDacTrungFnMdl-editBtn"" href=""javascript:"" onclick=""DKSanPhamDacTrungFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DKSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DKSanPhamDacTrungFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DKSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""DKSanPhamDacTrungFn.DangKySanPhamDacTrung();"" >Đăng ký Sản phẩm đặc trưng</a>
                            </div>
                            <table id=""DKSanPhamDacTrungFnMdl-List"" class=""mdl-list""></table>
                            <div id=""DKSanPhamDacTrungFnMdl-Pager""></div>
                            <div id=""DKSanPhamDacTrungFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""DKSanPhamDacTrungFnMdl-HangHoatempMdl-DKSanPhamDacTrung-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSPDacTrungNew.JScript1.js")
                        , "{DKSanPhamDacTrungFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
