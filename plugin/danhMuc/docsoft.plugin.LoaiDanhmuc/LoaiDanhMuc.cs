using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
[assembly: WebResource("docsoft.plugin.loaidanhmuc.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.loaidanhmuc.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.loaidanhmuc
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _ThuTu = Request["STT"];
            string _q = Request["q"];
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<LoaiDanhMuc> PagerGet = LoaiDanhMucDal.pagerNormal("", false, "LDM_" + jgrsidx + " " + jgrsord,_q, Request["rows"]);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (LoaiDanhMuc ldm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(ldm.ID.ToString(), 
                            new string[] { ldm.ID.ToString()
                                , ldm.ThuTu.ToString()
                                , ldm.Ma
                                , ldm.KyHieu
                                , ldm.Ten
                                , string.Format("{0:dd/MM/yy}",ldm.NgayCapNhat)
                                , ldm.NguoiTao + "/" + ldm.NguoiSua }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getPid":
                    #region lấy toàn bộ loai danh mục
                    LoaiDanhMuc _LDMItem = new LoaiDanhMuc();
                    _LDMItem.ID = 0;
                    _LDMItem.Ten = "Chọn";
                    LoaiDanhMucCollection ListGetPid = new LoaiDanhMucCollection();
                    ListGetPid = LoaiDanhMucDal.SelectTree(_q);
                    ListGetPid.Insert(0, _LDMItem);
                    sb.Append(JavaScriptConvert.SerializeObject(ListGetPid));
                    break;
                    #endregion
                case "new":
                    break;
                case "save":
                    #region lưu
                    LoaiDanhMuc ItemSave = new LoaiDanhMuc();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = LoaiDanhMucDal.SelectById(Convert.ToInt32(_ID));
                    }                    
                    ItemSave.Ten = _Ten;
                    ItemSave.Ma = _Ma;
                    ItemSave.KyHieu = _KyHieu;
                    ItemSave.ThuTu = Int32.Parse(_ThuTu);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.NguoiTao = Security.Username;
                    ItemSave.NguoiSua = Security.Username;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = LoaiDanhMucDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = LoaiDanhMucDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getdanhmuc":
                    #region lấy danh mục tương ứng
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                        if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                        //if ((jgrsidx != "LDM_Ten") && (jgrsidx != "LDM_ThuTu"))
                        //{
                        //    jgrsidx = "LDM_ThuTu asc" + ", DM_" + jgrsidx;
                        //}
                        //else
                        //{
                        //    if (jgrsidx == "LDM_Ten")
                        //    {
                        //        jgrsidx = "LDM_Ten ";
                        //    }
                        //    else
                        //    {
                        //        jgrsidx = "LDM_ThuTu ";
                        //    }
                        //}
                        //Pager<DanhMuc> PG = DanhMucDal.pagerNormal("", false, jgrsidx + " " + jgrsord, "%", _ID, Request["rows"]);
                        Pager<DanhMuc> PG = DanhMucDal.pagerByLdmId("DM_" + jgrsidx + " " + jgrsord, _q, _ID, jgRows);
                        List<jgridRow> LR = new List<jgridRow>();
                        foreach (DanhMuc dm in PG.List)
                        {
                            LR.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                              dm.ID.ToString()
                            ,  dm.ThuTu.ToString()
                            , dm.LDM_Ten
                            , dm.Ma
                            , dm.KyHieu
                            , dm.GiaTri
                            , dm.Ten
                            , string.Format("{0:dd/MM/yy}",dm.NgayCapNhat)
                            , dm.NguoiTao + "/" + dm.NguoiSua 
                            }));
                        }
                        jgrid gr = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PG.TotalPages.ToString(), PG.Total.ToString(), LR);
                        sb.Append(JavaScriptConvert.SerializeObject(gr));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(LoaiDanhMucDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        LoaiDanhMucDal.UpdateDeletedById(Convert.ToInt32(_ID) , true);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.loaidanhmuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-loaidanhmuc"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""loaidanhmucmdl-addBtn"" href=""javascript:loaidanhmuc.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""loaidanhmucmdl-editBtn"" href=""javascript:loaidanhmuc.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""loaidanhmucmdl-delBtn"" href=""javascript:loaidanhmuc.del();"">Xóa</a>
</div>

<table id=""loaidanhmucmdl-List"" class=""mdl-list""></table>
<div id=""loaidanhmucmdl-Pager""></div>
<div class=""sub-mdl"">
    <div class=""mdl-head"">
        <a class=""mdl-head-btn mdl-head-edit"" id=""danhmucmdl-editBtn"" href=""javascript:loaidanhmuc.editdanhmuc();"">Sửa</a>
        <a class=""mdl-head-btn mdl-head-delete"" id=""danhmucmdl-deleteBtn"" href=""javascript:loaidanhmuc.deletedanhmuc();"">Delete</a>
        <select class=""slt"" onchange=""loaidanhmuc.searchDanhMuc();"" id=""loaidanhmucmdl-danhMucMdl-changeLangSlt""></select>
    </div>
    <table id=""subdanhmucmdl-List"" class=""mdl-list""></table>
</div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.loaidanhmuc.JScript1.js")
                        , "{loaidanhmuc.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn)); 
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
