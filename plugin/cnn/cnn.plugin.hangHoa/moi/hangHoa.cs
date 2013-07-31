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
using linh.common;
using cnn.entities;
using System.Globalization;
[assembly: WebResource("cnn.plugin.hangHoa.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.hangHoa.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.hangHoa
{
    public class hangHoa:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _LangBased = Request["LangBased"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _DM_ID = Request["DM_ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _Alias = Request["Alias"];
            string _Lang = Request["Lang"];
            string _XuatXu_ID = Request["XuatXu_ID"];
            string _DonVi_ID = Request["DonVi_ID"];
            string _SoLuong = Request["SoLuong"];
            string _GNY = Request["GNY"];
            string _GiaNhap = Request["GiaNhap"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _MoTa = Request["MoTa"];
            string _Anh = Request["Anh"];
            string _NoiDung = Request["NoiDung"];
            string _Active = Request["Active"];
            string _Publish = Request["Publish"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Hot3 = Request["Hot3"];
            string _Hot4 = Request["Hot4"];
            string _q = Request["q"];
            HangHoa Item;
            List<HangHoa> List = new List<HangHoa>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    Pager<HangHoa> PagerGet = HangHoaDal.pagerLangBased("HH_" + jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows));
                    foreach (HangHoa item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                              item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            , string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh,"50x50"))
                            , item._DM_Ten
                            , item.Ma
                            , item.Ten
                            , item.GNY.ToString("###.###")                            
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , List.Count.ToString()
                        , List.Count.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        HangHoaDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(HangHoaDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = HangHoaDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new HangHoa();
                    }
                    Item.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        Item.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.Alias = _Alias;
                    Item.Lang = _Lang;
                    if (!string.IsNullOrEmpty(_XuatXu_ID))
                    {
                        Item.XuatXu_ID = Convert.ToInt32(_XuatXu_ID);
                    }
                    if (!string.IsNullOrEmpty(_DonVi_ID))
                    {
                        Item.DonVi_ID = Convert.ToInt32(_DonVi_ID);
                    }
                    if (!string.IsNullOrEmpty(_SoLuong))
                    {
                        Item.GiaNhap = Convert.ToDouble(_GiaNhap);
                    }
                    Item.Keywords = _KeyWords;
                    Item.Description = _Description;
                    Item.Anh = _Anh;
                    Item.NoiDung = _NoiDung;
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Publish = Convert.ToBoolean(_Publish);
                    Item.Hot1 = Convert.ToBoolean(_Hot1);
                    Item.Hot2 = Convert.ToBoolean(_Hot2);
                    Item.Hot3 = Convert.ToBoolean(_Hot3);
                    Item.Hot4 = Convert.ToBoolean(_Hot4);
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiCapNhat = Security.Username;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = HangHoaDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item.NguoiTao = Security.Username;
                        Item = HangHoaDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoCompleteLangBased":
                    #region Lấy danh sách danh mục
                    //Item = new hangHoa();
                    //Item.ID = 0;
                    //Item.Ten = "Chọn";
                    //List = getTree(HangHoaDal.SelectLangBased(_ID));
                    //List.Insert(0, Item);
                    //sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "getByLangBasedId":
                    #region getByLangBasedId: Lấy danh sách các ngôn ngữ khác theo ngôn ngữ gốc

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.hangHoa.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-hangHoa"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""hangHoaMdl-addBtn"" href=""javascript:"" onclick=""hangHoaFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""hangHoaMdl-addBtn"" href=""javascript:"" onclick=""hangHoaFn.addLang();"" >Thêm ngôn ngứ phụ</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""hangHoaMdl-editBtn"" href=""javascript:"" onclick=""hangHoaFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""hangHoaMdl-delBtn"" href=""javascript:"" onclick=""hangHoaFn.del();"" >Xóa</a>
    <select class=""slt"" onchange=""hangHoa.search();"" id=""hangHoaMdl-changeLangSlt""></select>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucHangHoa""/>
    </span>
</div>

<table id=""hangHoaFnMdl-List"" class=""mdl-list""></table>
<div id=""hangHoaFnMdl-Pager""></div>
<div class=""sub-mdl-list"" id=""hangHoaFnMdl-subMdl"">
    <ul>
        <li><a href=""#hangHoaFnMdl-subLangMdl"">Ngôn ngữ</a></li>
        <li><a href=""#hangHoaFnMdl-subNhomMdl"">Nhóm</a></li>
        <li><a href=""#hangHoaFnMdl-subAnhMdl"">Ảnh</a></li>
    </ul>
    <div  id=""hangHoaFnMdl-subLangMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinNhomMdl"" />
            </span>            
        </div>
        <table id=""hangHoaFnMdl-subLangMdl-List"" class=""mdl-list""></table>
    </div>
    <div id=""hangHoaFnMdl-subNhomMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinTopicMdl"" />
            </span>            
        </div>
        <table id=""hangHoaFnMdl-subNhomMdl-List"" class=""mdl-list""></table>
    </div>
    <div id=""hangHoaFnMdl-subAnhMdl"" class=""sub-mdl-list-item"">
        <div class=""mdl-head"">
            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinMdl-subTinBinhLuanMdl"" />
            </span>            
        </div>
        <table id=""hangHoaFnMdl-subAnhMdl-List"" class=""mdl-list""></table>
    </div>
</div
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.hangHoa.JScript1.js")
                        , "{hangHoaFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        
    }
}
