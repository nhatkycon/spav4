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
using spa.entitites;
[assembly: WebResource("plugin.spa.hinhAnhSpaMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.hinhAnhSpaMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.hinhAnhSpaMgr
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
            var Ten = Request["Ten"];
            var MoTa = Request["MoTa"];
            var Anh = Request["Anh"];
            var ThuTu = Request["ThuTu"];
            var NgayTao = Request["NgayTao"];
            var NguoiTao = Request["NguoiTao"];
            var Active = Request["Active"];
            SpaAnh Item;
            var ListRow = new List<jgridRow>();
            Pager<SpaAnh> PagerGet;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SPAHA_NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaAnhDal.pagerBySpa(string.Empty, false, jgrsidx + " " + jgrsord, SPA_ID,
                                                    Convert.ToInt32(jgRows));
                    foreach (SpaAnh dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img style=\"width: 50px;\"  src=\"../up/i/{0}\" />", linh.common.Lib.imgSize(dm.Anh,"170x150"))
                            , dm.Ten
                            , dm.ThuTu.ToString()
                            , dm.SPA_Ten
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
                        SpaAnhDal.DeleteById(new Guid(ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaAnhDal.SelectById(new Guid(ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(ID))
                    {
                        Item = SpaAnhDal.SelectById(new Guid(ID));
                    }
                    else
                    {
                        Item = new SpaAnh();
                    }
                    if (!string.IsNullOrEmpty(SPA_ID))
                    {
                        Item.SPA_ID = Convert.ToInt32(SPA_ID);
                    }
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        Item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    Item.Anh = Anh;
                    Item.Ten = Ten;
                    Item.MoTa = string.Empty;
                    Item.Active = Convert.ToBoolean(Active);
                    if (!string.IsNullOrEmpty(ID))
                    {
                        Item = SpaAnhDal.Update(Item);
                    }
                    else
                    {
                        Item.ID = Guid.NewGuid();
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                        Item = SpaAnhDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.hinhAnhSpaMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-hinhAnhSpaMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""hinhAnhSpaMdl-addBtn"" href=""javascript:hinhAnhSpaFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""hinhAnhSpaMdl-editBtn"" href=""javascript:hinhAnhSpaFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""hinhAnhSpaMdl-delBtn"" href=""javascript:hinhAnhSpaFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#hinhAnhSpaMdl-List').trigger('reloadGrid');$('.mdl-head-spaAnhFilterBySpa').val('');"">F5</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-spaAnhFilterBySpa""/>
    </span>
</div>
<table id=""hinhAnhSpaMdl-List"" class=""mdl-list""></table>
<div id=""hinhAnhSpaMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.hinhAnhSpaMgr.JScript1.js")
                        , "{hinhAnhSpaFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
