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
[assembly: WebResource("plugin.spa.SpaKhachHangMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.SpaKhachHangMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.SpaKhachHangMgr
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["_ID"];
            string _Ma = Request["_Ma"];
            string _Ho = Request["_Ho"];
            string _Ten = Request["_Ten"];
            string _Email = Request["_Email"];
            string _Mobile = Request["_Mobile"];
            string _MoTa = Request["_MoTa"];
            string _Active = Request["_Active"];
            string _Readed = Request["_Readed"];
            string _q = Request["_q"];
            SpaKhachHang Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            Pager<SpaKhachHang> PagerGet;
            #endregion            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SPA_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaKhachHangDal.pagerByDichVu(jgrsidx + " " + jgrsord, _q, 10);
                    foreach (SpaKhachHang dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                             , dm.Ten
                            , dm.Email
                            , dm.Mobile
                            , dm.DiaChi
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
                        SpaKhachHangDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaKhachHangDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaKhachHangDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SpaKhachHang();
                    }
                    Item.Ten = _Ten;
                    Item.DiaChi = _MoTa;
                    Item.Ho = _Ho;
                    Item.Email = _Email;
                    Item.Mobile = _MoTa;
                    Item.Ma = _Ma;
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Readed = Convert.ToBoolean(_Readed);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaKhachHangDal.Update(Item);
                    }
                    else
                    {
                        Item = SpaKhachHangDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaKhachHangMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-spaKhachHangMgrMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""spaKhachHangMgrMdl-addBtn"" href=""javascript:spaKhachHangMgrFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""spaKhachHangMgrMdl-editBtn"" href=""javascript:spaKhachHangMgrFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""spaKhachHangMgrMdl-delBtn"" href=""javascript:spaKhachHangMgrFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#spaKhachHangMgrMdl-List').trigger('reloadGrid');"">Nạp</a>    
</div>
<table id=""spaKhachHangMgrMdl-List"" class=""mdl-list""></table>
<div id=""spaKhachHangMgrMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.SpaKhachHangMgr.JScript1.js")
                        , "{spaKhachHangMgrFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
