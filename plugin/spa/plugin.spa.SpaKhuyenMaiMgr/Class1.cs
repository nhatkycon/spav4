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
using System.Globalization;
[assembly: WebResource("plugin.spa.SpaKhuyenMaiMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.SpaKhuyenMaiMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.SpaKhuyenMaiMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _SPA_ID = Request["_SPA_ID"];
            string _Ten = Request["_Ten"];
            string _NgayBatDau = Request["_NgayBatDau"];
            string _NgayKetThuc = Request["_NgayKetThuc"];
            string _GiaKhuyenMai = Request["_GiaKhuyenMai"];
            string _TyLeKhuyenMai = Request["_TyLeKhuyenMai"];
            string _MoTa = Request["_MoTa"];
            string _Active = Request["_Active"];
            string _Hot = Request["_Hot"];
            string _q = Request["_q"];
            string _GiaThiTruong = Request["_GiaThiTruong"];
            string _GiaThuVe = Request["_GiaThuVe"];
            string _SoLuongMua = Request["_SoLuongMua"];
            SpaKhuyenMai Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            Pager<SpaKhuyenMai> PagerGet;
            #endregion            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "KM_NgayBatDau";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaKhuyenMaiDal.pagerSpa(jgrsidx + " " + jgrsord, _q, _SPA_ID, Convert.ToInt32(jgRows));
                    foreach (var dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.Ten
                            , dm._Spa.Ten
                            , string.Format("{0:c}",dm.GiaKhuyenMai)
                            , string.Format("{0}",dm.TyLeKhuyenMai)
                            , dm.NgayBatDau == DateTime.MinValue ? "" : dm.NgayBatDau.ToString("dd/MM/yy")
                            , dm.NgayKetThuc == DateTime.MinValue ? "" : dm.NgayKetThuc.ToString("dd/MM/yy")
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
                        SpaKhuyenMaiDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaKhuyenMaiDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaKhuyenMaiDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SpaKhuyenMai();
                    }
                    Item.Ten = _Ten;
                    Item.MoTa = _MoTa;
                    if (!string.IsNullOrEmpty(_NgayBatDau))
                    {
                        Item.NgayBatDau = Convert.ToDateTime(_NgayBatDau, new CultureInfo("Vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(_NgayKetThuc))
                    {
                        Item.NgayKetThuc = Convert.ToDateTime(_NgayKetThuc, new CultureInfo("Vi-vn"));
                    }                    
                    if (!string.IsNullOrEmpty(_SPA_ID))
                    {
                        Item.SPA_ID = Convert.ToInt32(_SPA_ID);
                    }
                    if (!string.IsNullOrEmpty(_GiaThiTruong))
                    {
                        Item.GiaThiTruong = Convert.ToInt32(_GiaThiTruong);
                    }
                    if (!string.IsNullOrEmpty(_GiaThuVe))
                    {
                        Item.GiaThuVe = Convert.ToInt32(_GiaThuVe);
                    }
                    if (!string.IsNullOrEmpty(_SoLuongMua))
                    {
                        Item.SoLuongMua = Convert.ToInt32(_SoLuongMua);
                    }
                    if (!string.IsNullOrEmpty(_GiaKhuyenMai))
                    {
                        Item.GiaKhuyenMai = Convert.ToInt32(_GiaKhuyenMai);
                    }
                    if (!string.IsNullOrEmpty(_TyLeKhuyenMai))
                    {
                        Item.TyLeKhuyenMai = Convert.ToInt32(_TyLeKhuyenMai);
                    }
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Hot = Convert.ToBoolean(_Hot);
                    Item.NgayCapNhat = DateTime.Now;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaKhuyenMaiDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item = SpaKhuyenMaiDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaKhuyenMaiMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-spaKhuyenMaiMgrMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""spaKhuyenMaiMgrMdl-addBtn"" href=""javascript:spaKhuyenMaiMgrFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""spaKhuyenMaiMgrMdl-editBtn"" href=""javascript:spaKhuyenMaiMgrFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""spaKhuyenMaiMgrMdl-delBtn"" href=""javascript:spaKhuyenMaiMgrFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#spaKhuyenMaiMgrMdl-List').trigger('reloadGrid');$('.mdl-head-SpaKhuyenMaiFilterBySpa').val(''); $('.mdl-head-SpaKhuyenMaiFilterBySpa').attr('_value','');"">Nạp</a>    
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-SpaKhuyenMaiFilterBySpa""/>
    </span>
</div>
<table id=""spaKhuyenMaiMgrMdl-List"" class=""mdl-list""></table>
<div id=""spaKhuyenMaiMgrMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaKhuyenMaiMgr.JScript1.js")
                        , "{spaKhuyenMaiMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
