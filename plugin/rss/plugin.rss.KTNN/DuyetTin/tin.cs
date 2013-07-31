using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
//using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using docbao.entitites;

//using docbao.entitites;

[assembly: WebResource("plugin.rss.KTNN.DuyetTin.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.rss.KTNN.DuyetTin
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _DM_ID = Request["DM_ID"];
            string _CM_ID = Request["CM_ID"];
            string _Ten = Request["Ten"];
            string _ThuTu = Request["ThuTu"];
            string _MoTa = Request["MoTa"];
            string _Keywords = Request["Keywords"];
            string _NoiDung = Request["NoiDung"];
            string _Active = Request["Active"];
            string _Home = Request["Home"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _NoiBatHome = Request["NoiBatHome"];
            string _NoiBatDm = Request["NoiBatDm"];
            string _DocNhieu = Request["DocNhieu"];
            string _Hot3 = Request["Hot3"];
            string _Anh = Request["Anh"];
            string _q = Request["q"];
            string _Bao = Request["Bao"];
            string _TpId = Request["TpId"];
            string _Nid = Request["Nid"];
            string _Ngay = Request["Ngay"];
            string _BlId = Request["BlId"];
            string _tag = Request["tag"];
            docbao.entitites.Tin Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "T_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<docbao.entitites.Tin> PagerGet = docbao.entitites.TinDal.pagerKTNNXuLy("", false, Convert.ToInt32(jgRows), jgrsidx + " " + jgrsord, _q, _DM_ID, _CM_ID, _Bao, _TpId, _Nid, _Ngay, _tag, "1");
                    foreach (docbao.entitites.Tin dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img  src=\"http://tintuc.me/lib/up/{0}\" />", linh.common.Lib.imgSize(dm.Anh,"50x50"))
                            , string.Format("<b>{0}</b><br/>{2}",dm.Ten, "", dm.Url)
                            , string.Format("{0} > {1}",dm.CM_Ten,dm.DM_Ten)
                            , dm.NgayTao.ToString("hh:mm - dd/MM/yyyy")
                            , dm.Hot.ToString()
                            , dm.Hot1.ToString()
                            , dm.Hot2.ToString()
                            , dm.Hot3.ToString()
                            , dm.NoiBatDm.ToString()
                            , dm.NoiBatHome.ToString()
                            , dm.DocNhieu.ToString()
                            , dm.Views.ToString()
                            , dm.BinhChon.ToString()
                            , dm.Diem.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
             
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.KTNN.DuyetTin.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    docsoft.entities.FunctionCollection ListFn = docsoft.entities.FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdlds"" />
    </span>
 
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#tinMdlds-List-duyet-ktnn').trigger('reloadGrid');"">Nạp</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByBao""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByDanhMuc""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByNhom""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByTopic""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-tinFilterByNgay""/>
    </span>
</div>
<div class=""message"" style=""color:red;""></div>
<table id=""tinMdlds-List-duyet-ktnn"" class=""mdl-list""></table>
<div id=""tinMdlds-Pager-duyet-ktnn""></div>


</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.rss.KTNN.DuyetTin.JScript1.js")
                        , "{DuyetTin_tinFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
  
    }
}
