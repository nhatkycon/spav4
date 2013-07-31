﻿using System;
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
[assembly: WebResource("cnn.plugin.quangCao.hetHan.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.quangCao.hetHan.htm.htm", "text/html")]
namespace cnn.plugin.quangCao.hetHan
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Url = Request["QUrl"];
            string _q = Request["q"];
            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ADV_ThuTu";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<QuangCao> pager = QuangCaoDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _PID);

                    ListRow = new List<jgridRow>();
                    foreach (QuangCao item in pager.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.ThuTu.ToString()
                            ,string.Format("<img src=\"../up/i/{0}\"/>",Lib.imgSize(item.Anh,"50x50"))
                            ,item.Ten
                            ,item.Url
                            ,item.ViTri.ToString()
                            ,item.ViTri_Ten
                            ,item.Active.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pager.TotalPages.ToString(), pager.Total.ToString(), ListRow);
                    // jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "add":
                    #region thêm mới
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(QuangCaoDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        QuangCaoDal.DeleteMultiById(_ID);
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt quảng cáo hàng loạt
                    QuangCao ItemDuyet = new QuangCao();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        QuangCaoDal.UpdateMulti(_ID);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "save":
                    #region lưu
                    QuangCao ItemSave = new QuangCao();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = QuangCaoDal.SelectById(Convert.ToInt32(_ID));
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.ViTri = Int32.Parse(_PID);
                    ItemSave.ViTri_Ten = _PTen;
                    ItemSave.Anh = _Anh;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "1";
                    }
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.Url = _Url;

                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = QuangCaoDal.Update(ItemSave);
                    }
                    else
                    {
                        //ItemSave.NguoiTao = Security.Username;
                        //ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = QuangCaoDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.quangCao.hetHan.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-quangcaohh"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""quangcaomdlhh-addBtn"" href=""javascript:quangcaohhfn.add();"">Thêm mới</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""quangcaomdlhh-editBtn"" href=""javascript:quangcaohhfn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""quangcaomdlhh-delBtn"" href=""javascript:quangcaohhfn.del();"">Xóa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""quangcaomdlhh-delBtn"" href=""javascript:quangcaohhfn.duyet();"">Duyệt quảng cáo</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterdanhmucqcaohh""/>
</span>
</div>
<table id=""quangcaomdlhh-List"" class=""mdl-list""></table>
<div id=""quangcaomdlhh-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.quangCao.hetHan.JScript1.js")
                        , "{quangcaohhfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




