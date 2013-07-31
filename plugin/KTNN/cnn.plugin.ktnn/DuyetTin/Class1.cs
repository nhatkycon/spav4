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
using docsoft.entities;
using System.Xml;
using System.Globalization;
using System.IO;
[assembly: WebResource("cnn.plugin.ktnn.DuyetTin.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.ktnn.DuyetTin.htm.htm", "text/html")]
namespace cnn.plugin.ktnn.DuyetTin
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _F_ID = Request["F_ID"];
            string _Lang = Request["Lang"];
            string _Alias = Request["Alias"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _LangBased = Request["LangBased"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDungdb_ktnn = Request["NoiDungdb_ktnn"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _Status = Request["Status"];
            string _Nguon = Request["Nguon"];
            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "KTNN_NgayCapNhat";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    string _NguoiTao = Security.Username;
                    int _acp = 2;
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    Pager<KTNN> PagerGet = KTNNDal.pagerDuyet("", false, jgrsidx + " " + jgrsord, _q, _PID, _NguoiTao, _acp, "KT_NN", _Lang);

                    ListRow = new List<jgridRow>();
                    foreach (KTNN item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.LangBased.ToString()
                            ,item._ID.ToString()
                            ,item.Lang
                            ,item.ThuTu.ToString()
                            ,string.Format("<img src=\"../up/{0}\"/>",("KTNN/"+item.Anh).Replace("KTNN/rss","tintuc/rss"))
                            ,item.Ten
                            ,item.MoTa
                           // ,item.DM_ID.ToString()
                            ,item.DM_Ten
                            ,item.Nguon
                            ,item.Views.ToString()
                            ,item.NguoiTao
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                            ,item.Active.ToString()
                            ,item.Hot.ToString()
                            ,item.HetHan.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getPid":
                    #region danh sách chọn sẵn

                    break;
                    #endregion
                case "add":
                    #region thêm mới
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    KTNN itemGetVanBan = KTNNDal.SelectByIdView(Convert.ToInt32(_ID));
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        if (itemGetVanBan.Filelist.Count > 0)
                        {
                            if (itemGetVanBan.Filelist[0].ID != 0)
                            {
                                foreach (Files item in itemGetVanBan.Filelist)
                                {
                                    itemGetVanBan.FileListStr += string.Format(@"<span _value=""{0}"" class=""adm-token-item"">{1}{2}<a href=""javascript:;"">x</a></span>"
                                        , item.ID, item.Ten, item.MimeType);
                                }
                            }
                            sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan));
                        }
                        // sb.Append("(" + JavaScriptConvert.SerializeObject(TinDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        KTNNDal.DeleteMultiById(_ID, "KTNN_TUC");
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    KTNN ItemDuyet = new KTNN();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemDuyet.multiID = _ID;
                        ItemDuyet.Active = Convert.ToBoolean(_Status);
                        KTNNDal.UpdateMulti(ItemDuyet);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hot":
                    #region Chuyển thành tin hot
                    KTNN ItemHot = new KTNN();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHot.multiID = _ID;
                        ItemHot.Hot = Convert.ToBoolean(_Status);
                        KTNNDal.UpdateHotMulti(ItemHot);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "hethan":
                    #region Hết hạn
                    KTNN ItemHetHan = new KTNN();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemHetHan.multiID = _ID;
                        ItemHetHan.HetHan = Convert.ToBoolean(_Status);
                        if (ItemHetHan.HetHan == true)
                        {
                            ItemHetHan.NgayHetHan = DateTime.Now;
                        }
                        KTNNDal.UpdateHetHanMulti(ItemHetHan);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "save":
                    #region lưu
                    KTNN ItemSave = new KTNN();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = KTNNDal.SelectById(Convert.ToInt32(_ID));
                    }
                    if (!string.IsNullOrEmpty(_Nguon))
                    {
                        ItemSave.Nguon = (_Nguon);
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.DM_ID = Int32.Parse(_PID);
                    // ItemSave.DM_Ten = _PTen;
                    ItemSave.Anh = _Anh;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "0";
                    }
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.MoTa = _Mota;
                    ItemSave.NoiDung = _NoiDungdb_ktnn;
                    ItemSave.KeyWords = _KeyWords;
                    ItemSave.Description = _Description;
                    ItemSave.Alias = _Alias;
                    ItemSave.Lang = _Lang;
                    ItemSave.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        ItemSave.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    }
                    ItemSave.Hot = Convert.ToBoolean(_Hot);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    if (_Public == "1")
                    {
                        ItemSave.NgayDang = DateTime.Now;
                    }
                    ItemSave.NguoiCapNhat = Security.Username;
                    ItemSave.HetHan = Convert.ToBoolean(_HetHan);
                    if (!string.IsNullOrEmpty(_NgayHetHan))
                    {
                        ItemSave.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-Vn"));
                    }
                    if (!string.IsNullOrEmpty(_NgayCapNhat))
                    {
                        DateTime dt = new DateTime();


                        ItemSave.NgayCapNhat = Convert.ToDateTime(_NgayCapNhat, new CultureInfo("vi-Vn"));//.AddHours(dt.Hour).AddMinutes(dt.Minute).AddSeconds(dt.Second);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = KTNNDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = KTNNDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.ktnn.DuyetTin.JScript1.js"));
                    break;
                    #endregion
                case "saveDoc":
                    #region Lưu tài liệu
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        item.VB_ID = Convert.ToInt32(0);
                        Guid g = new Guid(_ID);

                        item.PID = g;
                        item = FilesDal.Update(item);
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        string _directory = Server.MapPath("~/up/d/") + item.ThuMuc;
                        string _files = Server.MapPath("~/up/d/") + item.ThuMuc + "/" + item.Ten + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_files);
                            Directory.Delete(_directory);
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">

<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-ktnn-db"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""dbtinmdlktnn-addBtn"" href=""javascript:dbtinfn.add();"" style='display:none;'>Viết bài</a>
<a class=""mdl-head-btn mdl-head-add"" id=""danhMucMdl-addBtn"" href=""javascript:"" onclick=""dbtinfn.addLang();""  style='display:none;'>Bài viết ngôn ngữ khác</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""dbtinmdlktnn-editBtn"" href=""javascript:dbtinfn.edit();"">Sửa bài viết</a>
<a class=""mdl-head-btn mdl-head-del"" id=""dbtinmdlktnn-delBtn"" href=""javascript:dbtinfn.del();"">Xóa bài viết</a>
<select class=""slt"" onchange=""dbtinfn.search();"" id=""dbtintucdl-changeLangSlt""></select>
<a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbtinfn.duyet('true');"">Duyệt bài viết</a>
<a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbtinfn.tinhot('true');"">Chuyển tin hot</a>

<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"" style='display:none'>
    <span class=""mdl-headTask-Loc-Title"">
        <span class=""ui-icon ui-icon-triangle-1-s""></span>        
        Hết hạn <span class=""mdl-headTask-Loc-Title-Display""></span>
    </span>
    <span class=""mdl-headTask-Loc-Box"" >
        <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
            <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
                <span onclick=""javascript:dbtinfn.hethan('true');"">Chuyển hết hạn</span>
                <span onclick=""javascript:dbtinfn.hethan('false');"">Gia hạn</span>
            </span>
        </span>
    </span>
</a>
<a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"" style=""display:none;"">
    <span class=""mdl-headTask-Loc-Title"">
        <span class=""ui-icon ui-icon-triangle-1-s""></span>        
        Lọc tin <span class=""mdl-headTask-Loc-Title-Display""></span>
    </span>
    <span class=""mdl-headTask-Loc-Box"">
        <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"" >
            <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"" style='display:none'>
                <span onclick=""javascript:dbtinfn.hethan('true');"">Tin kích hoạt</span>
                <span onclick=""javascript:dbtinfn.hethan('false');"">Tin hot</span>
                <span onclick=""javascript:dbtinfn.hethan('false');"">Hết hạn</span>
            </span>
        </span>
    </span>
</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-dbfilterdanhmuc""/>
</span>
</div>
<table id=""dbtinmdlktnn-List"" class=""mdl-list""></table>
<div id=""dbtinmdlktnn-Pagerql""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.ktnn.DuyetTin.JScript1.js")
                        , "{dbtinfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
