﻿using System;
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
[assembly: WebResource("cnn.plugin.giaoThuong.User.DanhSachTinGiaoThuong.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.giaoThuong.User.DanhSachTinGiaoThuong.htm.htm", "text/html", PerformSubstitution = true)]

namespace cnn.plugin.giaoThuong.User.DanhSachTinGiaoThuong
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
            GiaoThuong Item;
            List<GiaoThuong> List = new List<GiaoThuong>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
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
                            ,item.Active.ToString()
                            ,item.Publish.ToString()
                        }));
                    }
                    jgrid gridlang = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "1", listpg.Count.ToString(), ListRowgetByLangBasedId);
                    sb.Append(JavaScriptConvert.SerializeObject(gridlang));
                    break;
                    #endregion
                case "get":
                    #region lấy dữ liệu cho grid
                    
                    Pager<GiaoThuong> PagerGet = GiaoThuongDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _dm, Security.Username, "True", _publish, _Lang, Convert.ToInt32(jgRows), _dmkv, _muaban,_trangthai);

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
                case "DKDVVIP":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        GiaoThuongDal.DKDVVIP(_ID);
                    }
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.User.DanhSachTinGiaoThuong.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                 <div id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-main"">   
                    <div id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-head"" class=""mdl-head"">
                        <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-GiaoThuongUserDanhSachTinGiaoThuong"" />
                        </span>
                        <a class=""mdl-head-btn mdl-head-edit"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-editBtn"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.edit();"">Sửa</a>
                        <a class=""mdl-head-btn mdl-head-del"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-delBtn"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.del();"" >Xóa</a>
                        <select class=""slt"" onchange=""GiaoThuongUserDanhSachTinGiaoThuongFn.search();"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-changeLangSlt""></select>
                        <select class=""muaban"" onchange=""GiaoThuongUserDanhSachTinGiaoThuongFn.search();"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-muaban""></select>
                        <select class=""TrangThai"" onchange=""GiaoThuongUserDanhSachTinGiaoThuongFn.search();"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-TrangThai""></select>

                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucGiaoThuongUserDanhSachTinGiaoThuong""/>
                        </span>
                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterKhuVucGiaoThuongUserDanhSachTinGiaoThuong""/>
                        </span>
                        <a class=""mdl-head-btn mdl-head-edit"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-DKDVVIPBtn"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.DKDVVIP();"">Đăng ký vip</a>
                    </div>
                    <table id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-List"" class=""mdl-list""></table>
                    <div id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-Pager""></div>
                    <h3 style=""color: #2E6E9E;"">Ngôn ngữ khác, Thông tin về tin giao thương</h3>
                    <div class=""sub-mdl-list"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subMdl"">
                        <ul>
                            <li><a href=""#GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subLangMdl"">Ngôn ngữ</a></li>
                            <li><a href=""#GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subNhomMdl"">Nhóm</a></li>
                            <li><a href=""#GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subAnhMdl"">Ảnh</a></li>
                        </ul>
                        <div  id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subLangMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <a class=""mdl-head-btn mdl-head-AddLang"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-AddLangBtn"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.AddLang();"">Thêm ngôn ngữ khác</a>
                                <a class=""mdl-head-btn mdl-head-EditLang"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-EditLang"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.EditLang();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-DelLang"" id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-DelLang"" href=""javascript:"" onclick=""GiaoThuongUserDanhSachTinGiaoThuongFn.DelLang();"">Xóa</a>
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinNhomMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subLangMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subNhomMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinTopicMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subNhomMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subAnhMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinBinhLuanMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongUserDanhSachTinGiaoThuongFnMdl-subAnhMdl-List"" class=""mdl-list""></table>
                        </div>
                    </div>
                </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.User.DanhSachTinGiaoThuong.JScript1.js")
                    , "{GiaoThuongUserDanhSachTinGiaoThuongFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }

}
