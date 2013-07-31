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
[assembly: WebResource("plugin.spa.SpaTopMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.SpaTopMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.SpaTopMgr
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
            string _LOAI_ID = Request["_LOAI_ID"];
            string _ThuTu = Request["_ThuTu"];
            string _Active = Request["_Active"];
            string _MoTa = Request["_MoTa"];
            string _NoiDung = Request["_NoiDung"];
            string _Readed = Request["_Readed"];
            string _q = Request["_q"];
            SpaTop Item;
            var ListRow = new List<jgridRow>();
            #endregion            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SPA_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    var PagerGet = SpaTopDal.pagerDanhMuc(jgrsidx + " " + jgrsord, _q, _DM_ID, _LOAI_ID, Convert.ToInt32(jgRows));
                    foreach (SpaTop dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , dm.SPA_Ten
                            , dm.ThuTu.ToString()
                            , dm.DM_Ten
                            , dm.LOAI_Ten
                            , dm.Active.ToString()
                            , dm.Readed.ToString()
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
                        SpaTopDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaTopDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaTopDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SpaTop();
                    }
                    Item.MoTa = _MoTa;
                    Item.NoiDung = _NoiDung;
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    if (!string.IsNullOrEmpty(_SPA_ID))
                    {
                        Item.SPA_ID = Convert.ToInt32(_SPA_ID);
                    }
                    if (!string.IsNullOrEmpty(_LOAI_ID))
                    {
                        Item.LOAI_ID = Convert.ToInt32(_LOAI_ID);
                    }
                    if (!string.IsNullOrEmpty(_ThuTu))
                    {
                        Item.ThuTu = Convert.ToInt32(_ThuTu);
                    }
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Readed = Convert.ToBoolean(_Readed);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaTopDal.Update(Item);
                    }
                    else
                    {
                        Item = SpaTopDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaTopMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-topSpaMgrMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""topSpaMgrMdl-addBtn"" href=""javascript:topSpaMgrFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""topSpaMgrMdl-editBtn"" href=""javascript:topSpaMgrFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""topSpaMgrMdl-delBtn"" href=""javascript:topSpaMgrFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#topSpaMgrMdl-List').trigger('reloadGrid');"">Nạp</a>    
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-topSpaFilterByDm""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-topSpaFilterByLoai""/>
    </span>
</div>
<table id=""topSpaMgrMdl-List"" class=""mdl-list""></table>
<div id=""topSpaMgrMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaTopMgr.JScript1.js")
                        , "{topSpaMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
