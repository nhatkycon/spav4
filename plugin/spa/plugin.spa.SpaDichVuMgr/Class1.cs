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
using docbao.entitites;
using spa.entitites;
[assembly: WebResource("plugin.spa.SpaDichVuMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.SpaDichVuMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.SpaDichVuMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _DM_ID = Request["_DM_ID"];
            string _SPA_ID = Request["_SPA_ID"];
            string _Ten = Request["_Ten"];
            string _Gia = Request["_Gia"];
            string _DonVi = Request["_DonVi"];
            string _MoTa = Request["_MoTa"];
            string _NoiDung = Request["_NoiDung"];
            string _GiaKhuyenMai = Request["_GiaKhuyenMai"];
            string _KM = Request["_KM"];
            string _Hot = Request["_Hot"];
            string _q = Request["_q"];
            SpaDichVu Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            Pager<SpaDichVu> PagerGet;
            #endregion            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SPA_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaDichVuDal.pagerByDichVu(jgrsidx + " " + jgrsord, _q, _DM_ID, _SPA_ID, Convert.ToInt32(jgRows));
                    foreach (SpaDichVu dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                             , dm.Ten
                            , dm._DanhMuc.Ten
                            , dm._Spa.Ten
                            , string.Format("{0:c}",dm.Gia)
                            , dm.KM.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SpaDichVuDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaDichVuDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaDichVuDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SpaDichVu();
                    }
                    Item.Ten = _Ten;
                    Item.MoTa = _MoTa;
                    Item.NoiDung = _NoiDung;
                    Item.DonVi = _DonVi;
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    if (!string.IsNullOrEmpty(_SPA_ID))
                    {
                        Item.SPA_ID = Convert.ToInt32(_SPA_ID);
                    }
                    if (!string.IsNullOrEmpty(_Gia))
                    {
                        Item.Gia = Convert.ToInt32(_Gia);
                    }
                    if (!string.IsNullOrEmpty(_GiaKhuyenMai))
                    {
                        Item.GiaKm = Convert.ToInt32(_GiaKhuyenMai);
                    }
                    Item.KM = Convert.ToBoolean(_KM);
                    Item.NgayCapNhat = DateTime.Now;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaDichVuDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item = SpaDichVuDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaDichVuMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-spaDichVuMgrMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""spaDichVuMgrMdl-addBtn"" href=""javascript:spaDichVuMgrFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""spaDichVuMgrMdl-editBtn"" href=""javascript:spaDichVuMgrFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""spaDichVuMgrMdl-delBtn"" href=""javascript:spaDichVuMgrFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#spaDichVuMgrMdl-List').trigger('reloadGrid');"">Nạp</a>    
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-SpaDichVuFilterByDm""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-SpaDichVuFilterBySpa""/>
    </span>
</div>
<table id=""spaDichVuMgrMdl-List"" class=""mdl-list""></table>
<div id=""spaDichVuMgrMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaDichVuMgr.JScript1.js")
                        , "{spaDichVuMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
