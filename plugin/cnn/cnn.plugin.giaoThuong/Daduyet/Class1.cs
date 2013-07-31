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
[assembly: WebResource("cnn.plugin.giaoThuong.Daduyet.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.giaoThuong.Daduyet.htm.htm", "text/html", PerformSubstitution = true)]

namespace cnn.plugin.giaoThuong.Daduyet
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _q = Request["q"];
            string _dm = Request["dm"];
            string _active = Request["active"];
            string _publish = Request["publish"];
            string _Lang = Request["Lang"];
            string _dmkv = Request["dmkv"];
            string _LangBased = Request["LangBased"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _ckbMua = Request["ckbMua"];
            string _Anh = Request["Anh"];
            string _Ten = Request["Ten"];
            string _MoTa = Request["MoTa"];
            string _NoiDung = Request["NoiDung"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _XuatXu = Request["XuatXu"];
            string _Active = Request["Active"];
            string _Publish = Request["Publish"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Hot3 = Request["Hot3"];
            string _Hot4 = Request["Hot4"];
            string _muaban = Request["muaban"];
            string _trangthai = Request["trangthai"];
            string _dungFn = Request["dungFn"];
            GiaoThuong Item;
            List<GiaoThuong> List = new List<GiaoThuong>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "DungFn":
                    #region duyệt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        GiaoThuongDal.DuyetList(_ID, "",_dungFn);
                    }
                    break;
                    #endregion
                case "getByLangBasedId":
                    #region lấy dữ liệu ngôn ngữ phụ

                    List<GiaoThuong> listpg = GiaoThuongDal.SelectgetByLangBasedId(Convert.ToInt32(_LangBased_ID));
                    List<jgridRow> ListRowgetByLangBasedId = new List<jgridRow>();
                    foreach (GiaoThuong item in listpg)
                    {
                        ListRowgetByLangBasedId.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item.Lang
                            ,string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh,"50x50"))
                            ,item.Ten
                            ,item.NoiDung
                            ,item._DM_Ten
                            ,item.XuatXu
                            ,item.NgayTao.ToString("dd/MM/yyyy")
                            ,item.NguoiTao
                            ,item.Publish.ToString()
                            ,item.Active.ToString()
                        }));
                    }
                    jgrid gridlang = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "1", listpg.Count.ToString(), ListRowgetByLangBasedId);
                    sb.Append(JavaScriptConvert.SerializeObject(gridlang));
                    break;
                    #endregion
                case "get":
                    #region lấy dữ liệu cho grid

                    Pager<GiaoThuong> PagerGet = GiaoThuongDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _dm, "", "True", _publish, _Lang, Convert.ToInt32(jgRows), _dmkv, _muaban, _trangthai);

                    foreach (GiaoThuong item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item.Lang
                            ,string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh,"50x50"))
                            ,item.Ten
                            ,item.NoiDung
                            ,item._DM_Ten
                            ,item.XuatXu
                            ,item.NgayTao.ToString("dd/MM/yyyy")
                            ,item.NguoiTao
                            ,item.Publish.ToString()
                            ,item.Active.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , List.Count.ToString()
                        , List.Count.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        GiaoThuongDal.DeleteByIdList(_ID);
                    }
                    break;
                    #endregion
                case "CountLang":
                    #region
                    //GiaoThuongDal.SelectCountLang(int.Parse(_ID),_Lang);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GiaoThuongDal.SelectCountLang(int.Parse(_ID), _Lang)));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GiaoThuongDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = GiaoThuongDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new GiaoThuong();
                    }
                    Item.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        Item.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    }
                    if (!string.IsNullOrEmpty(_dm))
                    {
                        Item.DM_ID = Convert.ToInt32(_dm);
                    }
                    if (!string.IsNullOrEmpty(_dmkv))
                    {
                        Item.KV_ID = Convert.ToInt32(_dmkv);
                    }
                    Item.Mua = Convert.ToBoolean(_ckbMua);
                    Item.Lang = _Lang;
                    Item.Ten = _Ten;
                    Item.MoTa = _MoTa;
                    Item.NoiDung = _NoiDung;
                    Item.XuatXu = _XuatXu;
                    Item.Anh = _Anh;
                    Item.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-vn"));
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiCapNhat = Security.Username;
                    //Item.Active = Convert.ToBoolean(_Active);
                    Item.Publish = Convert.ToBoolean(_Publish);
                    //Item.Hot1 = Convert.ToBoolean(_Hot1);
                    //Item.Hot2 = Convert.ToBoolean(_Hot2);
                    //Item.Hot3 = Convert.ToBoolean(_Hot3);
                    //Item.Hot4 = Convert.ToBoolean(_Hot4);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = GiaoThuongDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item.NguoiTao = Security.Username;
                        Item = GiaoThuongDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.Daduyet.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                        //<a class=""mdl-head-btn mdl-head-del"" id=""GiaoThuongDaduyetFnMdl-delBtn"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.DungFn('True');"" >Dừng</a>
                    sb.Append(@"
                 <div id=""GiaoThuongDaduyetFnMdl-main"">   
                    <div id=""GiaoThuongDaduyetFnMdl-head"" class=""mdl-head"">
                        <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-GiaoThuongDaduyet"" />
                        </span>
                        <a class=""mdl-head-btn mdl-head-edit"" id=""GiaoThuongDaduyetFnMdl-editBtn"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.edit();"">Sửa</a>
                        <a class=""mdl-head-btn mdl-head-del"" id=""GiaoThuongDaduyetFnMdl-delBtn"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.del();"" >Xóa</a>
                        <select class=""slt"" onchange=""GiaoThuongDaduyetFn.search();"" id=""GiaoThuongDaduyetFnMdl-changeLangSlt""></select>
                        <select class=""TrangThai"" onchange=""GiaoThuongDaduyetFn.search();"" id=""GiaoThuongDaduyetFnMdl-TrangThai""></select>
                        <select class=""muaban"" onchange=""GiaoThuongDaduyetFn.search();"" id=""GiaoThuongDaduyetFnMdl-muaban""></select>

                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucGiaoThuongDaduyet""/>
                        </span>
                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterKhuVucGiaoThuongDaduyet""/>
                        </span>
                        
                    </div>
                    <table id=""GiaoThuongDaduyetFnMdl-List"" class=""mdl-list""></table>
                    <div id=""GiaoThuongDaduyetFnMdl-Pager""></div>
                    <h3 style=""color: #2E6E9E;"">Ngôn ngữ khác, Thông tin về tin giao thương</h3>
                    <div class=""sub-mdl-list"" id=""GiaoThuongDaduyetFnMdl-subMdl"">
                        <ul>
                            <li><a href=""#GiaoThuongDaduyetFnMdl-subLangMdl"">Ngôn ngữ</a></li>
                            <li><a href=""#GiaoThuongDaduyetFnMdl-subNhomMdl"">Nhóm</a></li>
                            <li><a href=""#GiaoThuongDaduyetFnMdl-subAnhMdl"">Ảnh</a></li>
                        </ul>
                        <div  id=""GiaoThuongDaduyetFnMdl-subLangMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <a class=""mdl-head-btn mdl-head-AddLang"" id=""GiaoThuongDaduyetFnMdl-AddLangBtn"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.AddLang();"">Thêm ngôn ngữ khác</a>
                                <a class=""mdl-head-btn mdl-head-EditLang"" id=""GiaoThuongDaduyetFnMdl-EditLang"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.EditLang();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-DelLang"" id=""GiaoThuongDaduyetFnMdl-DelLang"" href=""javascript:"" onclick=""GiaoThuongDaduyetFn.DelLang();"">Xóa</a>
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinNhomMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongDaduyetFnMdl-subLangMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongDaduyetFnMdl-subNhomMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinTopicMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongDaduyetFnMdl-subNhomMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongDaduyetFnMdl-subAnhMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinBinhLuanMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongDaduyetFnMdl-subAnhMdl-List"" class=""mdl-list""></table>
                        </div>
                    </div>
                </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.Daduyet.JScript1.js")
                    , "{GiaoThuongDaduyetFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
