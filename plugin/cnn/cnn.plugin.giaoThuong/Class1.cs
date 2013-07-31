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
[assembly: WebResource("cnn.plugin.giaoThuong.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.giaoThuong.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.giaoThuong
{
    public class Class1: docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _q = Request["q"];
            string _dm= Request["dm"];
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
            //List<jgridRow> ListRow;
            GiaoThuong Item;
            List<GiaoThuong> List = new List<GiaoThuong>();
            List<jgridRow> ListRow = new List<jgridRow>();
            //List<jgridRow> ListRowgetByLangBasedId = new List<jgridRow>();
            #endregion
            switch (subAct)
            {
                case "PheDuyet":
                    #region duyệt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        GiaoThuongDal.DuyetList(_ID, _active, "");
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



                    Pager<GiaoThuong> PagerGet = GiaoThuongDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _dm, "", _active, _publish, _Lang, Convert.ToInt32(jgRows), _dmkv, _muaban,_trangthai);

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
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GiaoThuongDal.SelectCountLang(int.Parse(_ID),_Lang)));
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    //GiaoThuong itemgt = GiaoThuongDal.SelectByUser(Security.Username);

                    //if (itemgt._CQ_ID == 0 || itemgt._CQ_ID == null)
                    //{
                    //    sb.Append(@"<div class=""ThongBaoms""></div>");
                    //    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.JScript1.js")
                    //    , "{GiaoThuongFn.thongbao();}");
                    //}
                    //else
                    //{
                        sb.Append(@"
                 <div id=""GiaoThuongFnMdl-main"">   
                    <div id=""GiaoThuongFnMdl-head"" class=""mdl-head"">
                        <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-GiaoThuong"" />
                        </span>
                        <a class=""mdl-head-btn mdl-head-add"" id=""GiaoThuongFnMdl-addBtn"" href=""javascript:"" onclick=""GiaoThuongFn.add();"">Thêm</a>
                        <a class=""mdl-head-btn mdl-head-edit"" id=""GiaoThuongFnMdl-editBtn"" href=""javascript:"" onclick=""GiaoThuongFn.edit();"">Sửa</a>
                        <a class=""mdl-head-btn mdl-head-del"" id=""GiaoThuongFnMdl-delBtn"" href=""javascript:"" onclick=""GiaoThuongFn.del();"" >Xóa</a>
                        <a class=""mdl-head-btn mdl-head-del"" id=""GiaoThuongFnMdl-PheDuyetBtn"" href=""javascript:"" onclick=""GiaoThuongFn.PheDuyet('True');"" >PheDuyet</a>
                        <select class=""slt"" onchange=""GiaoThuongFn.search();"" id=""GiaoThuongFnMdl-changeLangSlt""></select>
                        <select class=""TrangThai"" onchange=""GiaoThuongFn.search();"" id=""GiaoThuongFnMdl-TrangThai""></select>
                        <select class=""muaban"" onchange=""GiaoThuongFn.search();"" id=""GiaoThuongFnMdl-muaban""></select>

                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucGiaoThuong""/>
                        </span>
                        <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                            <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterKhuVucGiaoThuong""/>
                        </span>
                        
                    </div>
                    <table id=""GiaoThuongFnMdl-List"" class=""mdl-list""></table>
                    <div id=""GiaoThuongFnMdl-Pager""></div>
                    <h3 style=""color: #2E6E9E;"">Ngôn ngữ khác, Thông tin về tin giao thương</h3>
                    <div class=""sub-mdl-list"" id=""GiaoThuongFnMdl-subMdl"">
                        <ul>
                            <li><a href=""#GiaoThuongFnMdl-subLangMdl"">Ngôn ngữ</a></li>
                            <li><a href=""#GiaoThuongFnMdl-subNhomMdl"">Nhóm</a></li>
                            <li><a href=""#GiaoThuongFnMdl-subAnhMdl"">Ảnh</a></li>
                        </ul>
                        <div  id=""GiaoThuongFnMdl-subLangMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <a class=""mdl-head-btn mdl-head-AddLang"" id=""GiaoThuongFnMdl-AddLangBtn"" href=""javascript:"" onclick=""GiaoThuongFn.AddLang();"">Thêm ngôn ngữ khác</a>
                                <a class=""mdl-head-btn mdl-head-EditLang"" id=""GiaoThuongFnMdl-EditLang"" href=""javascript:"" onclick=""GiaoThuongFn.EditLang();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-DelLang"" id=""GiaoThuongFnMdl-DelLang"" href=""javascript:"" onclick=""GiaoThuongFn.DelLang();"">Xóa</a>
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinNhomMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongFnMdl-subLangMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongFnMdl-subNhomMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinTopicMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongFnMdl-subNhomMdl-List"" class=""mdl-list""></table>
                        </div>
                        <div id=""GiaoThuongFnMdl-subAnhMdl"" class=""sub-mdl-list-item"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinBinhLuanMdl"" />
                                </span>            
                            </div>
                            <table id=""GiaoThuongFnMdl-subAnhMdl-List"" class=""mdl-list""></table>
                        </div>
                    </div>
                </div>
                    ");
                        sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.JScript1.js")
                        , "{GiaoThuongFn.loadgrid();}");
                    //}
                   

                    
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion

            }
            //<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"">
            //                <span class=""mdl-headTask-Loc-Title"">
            //                    <span class=""ui-icon ui-icon-triangle-1-s""></span>        
            //                        Lọc tin 
            //                    <span class=""mdl-headTask-Loc-Title-Display""></span>
            //                </span>
            //                <span class=""mdl-headTask-Loc-Box"">
            //                    <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
            //                        <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
            //                            <span onclick=""javascript:GiaoThuongFn.filterfn('true','');"">Tin kích hoạt</span>
            //                            <span onclick=""javascript:GiaoThuongFn.filterfn('false','');"">Chưa kích hoạt</span>
            //                            <span onclick=""javascript:GiaoThuongFn.filterfn('','true');"">Hiển thị</span>
            //                            <span onclick=""javascript:GiaoThuongFn.filterfn('','false');"">Ẩn</span>
            //                        </span>
            //                    </span>
            //                </span>
            //            </a>
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
