using System;
using System.Collections.Generic;
using System.Text;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using spa.entitites;
[assembly: WebResource("plugin.spa.quaTangMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.quaTangMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.quaTangMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            var ID = Request["ID"];
            var SPA_ID = Request["SPA_ID"];
            var DV_ID = Request["DV_ID"];
            var Ten = Request["Ten"];
            var MoTa = Request["MoTa"];
            var Anh = Request["Anh"];
            var NoiDung = Request["NoiDung"];
            var Active = Request["Active"];
            var HetHan = Request["HetHan"];
            var Hot = Request["Hot"];
            var TrangChu = Request["TrangChu"];
            QuaTang Item;
            var ListRow = new List<jgridRow>();
            Pager<QuaTang> PagerGet;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "QT_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = QuaTangDal.pagerNormal(string.Empty, false, jgrsidx + " " + jgrsord, SPA_ID,
                                                    Convert.ToInt32(jgRows));
                    foreach (var item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             string.Format("{0}",item.ID)
                            , string.Format("<img style=\"width: 50px;\"  src=\"/lib/up/i/{0}\" />", linh.common.Lib.imgSize(item.Anh,"170x150"))
                            , item.SPA_Ten
                            , item.Ten
                            , item.TongPhieu.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        QuaTangDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(QuaTangDal.SelectById(new Guid(ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(ID))
                    {
                        Item = QuaTangDal.SelectById(new Guid(ID));
                    }
                    else
                    {
                        Item = new QuaTang();
                    }
                    if (!string.IsNullOrEmpty(SPA_ID))
                    {
                        Item.SPA_ID = Convert.ToInt32(SPA_ID);
                    }
                    if (!string.IsNullOrEmpty(DV_ID))
                    {
                        Item.DV_ID = Convert.ToInt32(DV_ID);
                    }
                    Item.Anh = Anh;
                    Item.Ten = Ten;
                    Item.MoTa = string.Empty;
                    Item.Active = Convert.ToBoolean(Active);
                    Item.HetHan = Convert.ToBoolean(HetHan);
                    Item.Hot = Convert.ToBoolean(Hot);
                    Item.TrangChu = Convert.ToBoolean(TrangChu);
                    Item.NoiDung = NoiDung;
                    if (!string.IsNullOrEmpty(ID))
                    {
                        Item = QuaTangDal.Update(Item);
                    }
                    else
                    {
                        Item.ID = Guid.NewGuid();
                        Item.NgayTao = DateTime.Now;
                        Item = QuaTangDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.quaTangMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-quaTangMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""quaTangMdl-addBtn"" href=""javascript:quaTangFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""quaTangMdl-editBtn"" href=""javascript:quaTangFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""quaTangMdl-delBtn"" href=""javascript:quaTangFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#quaTangMdl-List').trigger('reloadGrid');$('.mdl-head-spaAnhFilterBySpa').val('');"">F5</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-spaAnhFilterBySpa""/>
    </span>
</div>
<table id=""quaTangMdl-List"" class=""mdl-list""></table>
<div id=""quaTangMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.quaTangMgr.JScript1.js")
                        , "{quaTangFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
