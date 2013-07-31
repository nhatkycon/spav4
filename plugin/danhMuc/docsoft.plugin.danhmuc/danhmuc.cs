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
using System.Globalization;
[assembly: WebResource("docsoft.plugin.danhmuc.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.danhmuc.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace docsoft.plugin.danhmuc
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _PID = Request["PID"];
            string _LDMID = Request["LDMID"];
            string _Lang = Request["Lang"];
            string _Ten = Request["Ten"];
            string _Alias = Request["Alias"];
            string _Ma = Request["Ma"];
            string _KyHieu = Request["KyHieu"];
            string _GiaTri = Request["GiaTri"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _LangBased = Request["LangBased"];
            string _q = Request["q"];
            string _LDM_Ma = Request["LDM_Ma"];
            DanhMuc Item;
            List<DanhMuc> List=new List<DanhMuc>();
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (!string.IsNullOrEmpty(Request["s"]))
                    {
                    }
                    List = getTree(DanhMucDal.SelectByDmLang(_LDMID, _Lang));
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (DanhMuc dm in List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                              dm.ID.ToString()
                            , dm.LangBased.ToString()
                            , dm._ID.ToString()
                            , dm.Lang
                            , dm.ThuTu.ToString()
                            , dm.LDM_Ten
                            , dm.Ma
                            , dm.KyHieu
                            , dm.GiaTri
                            , string.Format("<img class=\"adm-fn-icon\" src=\"../up/i/{0}?ref=\" />", string.IsNullOrEmpty(dm.Anh) ? "fn-icon.jpg" :dm.Anh, Guid.NewGuid().ToString().Replace("-",""))
                            , dm.Ten
                            , string.Format("{0:dd/MM/yy}",dm.NgayCapNhat)
                            , dm.NguoiTao + "/" + dm.NguoiSua 
                            , dm.Level.ToString()
                            , dm.PID.ToString()
                            , "true"
                            , "true"
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, List.Count.ToString(), List.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "new":
                    break;
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DanhMucDal.UpdateDeletedById(Convert.ToInt32(_ID), true);
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(DanhMucDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DanhMucDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new DanhMuc();
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.LDM_ID = Int32.Parse(_LDMID);
                    Item.KyHieu = _KyHieu;
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiTao = Security.Username;
                    Item.GiaTri = _GiaTri;
                    Item.ThuTu = Convert.ToInt32(_ThuTu);
                    Item.NguoiSua = Security.Username;
                    Item.KeyWords = _KeyWords;
                    Item.Description = _Description;
                    Item.Alias = _Alias;
                    Item.Lang = _Lang;
                    Item.Anh = _Anh;
                    Item.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        Item.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    }
                    if (!string.IsNullOrEmpty(_PID))
                    {
                        Item.PID = Convert.ToInt32(_PID);
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DanhMucDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item = DanhMucDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "quickSave":
                    #region Lưu nhanh
                    if (!string.IsNullOrEmpty(_Ten))
                    {
                        DanhMuc _dmQS = DanhMucDal.QuickSave(_Ten, _KyHieu, _LDMID);
                        sb.AppendFormat(@"({0})", JavaScriptConvert.SerializeObject(_dmQS));
                    }
                    break;
                    #endregion
                case "getPidByDm":
                    #region Lấy danh sách danh mục
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    DanhMucCollection listgetPidByDm = DanhMucDal.SearchByLDM(_LDMID, _q, _Lang);
                    sb.Append(JavaScriptConvert.SerializeObject(getTree(listgetPidByDm)));
                    break;
                    #endregion
                case "autoCompleteLangBased":
                    #region Lấy danh sách danh mục
                    Item = new DanhMuc();
                    //Item.ID = 0;
                    //Item.Ten = "Chọn";
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    List = getTree(DanhMucDal.SelectLangBased(_ID, _LDM_Ma));
                    //List.Insert(0, Item);
                    sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "autocompleteSelectPidByMa":
                     #region Lấy danh sách danh mục
                    Item = new DanhMuc();
           
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    List = DanhMucDal.SelectPidByMa(_ID, _LDM_Ma);
                   
                    sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "getPidByDmTop":
                    #region Lấy danh sách danh mục
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    DanhMucCollection listgetPidByDmTop = DanhMucDal.SearchByLDM(_LDMID, _q, _Lang);
                    sb.Append(JavaScriptConvert.SerializeObject(getTreeTop(listgetPidByDmTop)));
                    break;
                    #endregion
                case "autoCompleteByLoaiNguoiThao":
                    #region Tìm người thảo
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SearchNguoiThao("20", _q)));
                    break;
                    #endregion
                case "getByLdmAndPID":
                    #region Lấy danh sách danh mục
                    DanhMucCollection listByLdmAndPID = DanhMucDal.ByLdmAndPID(_LDMID, _PID);
                    sb.Append(JavaScriptConvert.SerializeObject(listByLdmAndPID));
                    break;
                    #endregion
                case "getNoiNhanList":
                    #region nơi nhận
                    if (!string.IsNullOrEmpty(_LDMID))
                    {
                        DanhMucCollection listHead = DanhMucDal.NoiGuiListDmGiaTri(_LDMID);
                        DanhMucCollection listDm = DanhMucDal.NoiGuiListDmbyPid(_LDMID,_PID);
                        foreach (DanhMuc item in listHead)
                        {
                            sb.AppendFormat("<div class=\"adm-selectList-item-header\">");
                            sb.AppendFormat("<input dm=\"0\" type=\"checkbox\" /> {0}"
                                , item.Ten);
                            sb.AppendFormat("</div>");
                            var _dml = from _dm in listDm.ToList()
                                       where _dm.GiaTri == item.GiaTri
                                       select _dm;
                            if (_dml.Count() > 0)
                            {
                                sb.AppendFormat("<div class=\"adm-selectList-box\">");
                                foreach (DanhMuc _item in _dml)
                                {
                                    sb.AppendFormat("<span class=\"adm-selectList-item\"><input {0} _role=\"cid\" _value=\"{1}\" type=\"checkbox\" /> <span>{2}</span></span>"
                                        , _item.NguoiTao == "0" ? "" : " checked=\"checked\" "
                                        , _item.RowId
                                        , _item.Ten);
                                }
                                sb.AppendFormat("</div>");
                            }
                        }
                    }
                    break;
                    #endregion
                case "autoCompleteLangBasedByMaDanhMuc":
                    #region Lấy danh sách danh mục
                //    DanhMuc ItemDanhMuc = new DanhMuc();
                   // List<DanhMuc> ListDanhMuc = new List<DanhMuc>();
                    List = getTree(DanhMucDal.SelectLangBasedByMaDanhMuc(_Ma));
                    sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "autoCompleteLangBasedByDM":
                    #region Lấy danh sách danh mục
                    Item = new DanhMuc();
                    //Item.ID = 0;
                    //Item.Ten = "Chọn";
                    if (string.IsNullOrEmpty(_ID))
                    {
                        _ID = "";
                    }
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    List = getTree(DanhMucDal.SelectLangBasedByMa(_ID, _Ma));
                    //List.Insert(0, Item);
                    sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "getTree":
                    #region getTree: lấy sơ đồ cây
                        sb.Append(JavaScriptConvert.SerializeObject(getTree(DanhMucDal.SelectByKyHieu("home"))));
                        break;
                        //if (!string.IsNullOrEmpty(_ID))
                        //{
                        //    sb.Append("(" + JavaScriptConvert.SerializeObject(DanhMucDal.SelectById(Convert.ToInt32(_ID))) + ")");
                        //}
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.danhmuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-danhmuc"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""danhMucMdl-addBtn"" href=""javascript:"" onclick=""danhmuc.add('#danhmucmdl-List');"">Thêm</a>
<a class=""mdl-head-btn mdl-head-add"" id=""danhMucMdl-addBtn"" href=""javascript:"" onclick=""danhmuc.addLang();"" >Thêm ngôn ngứ phụ</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""danhMucMdl-editBtn"" href=""javascript:"" onclick=""danhmuc.edit('#danhmucmdl-List');"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""danhMucMdl-delBtn"" href=""javascript:"" onclick=""danhmuc.del('#danhmucmdl-List');"" >Xóa</a>
<select class=""slt"" onchange=""danhmuc.search();"" id=""danhMucMdl-changeLangSlt""></select>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterloaidanhmuc""/>
</span>
</div>
<table id=""danhmucmdl-List"" class=""mdl-list""></table>
<div id=""danhmucmdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.danhmuc.JScript1.js")
                        , "{danhmuc.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region TreeProcess
        List<DanhMuc> getTree(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            var plist = from c in buildTree(inputList)
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> item in plist)
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<DanhMuc> getTreeTop(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                break;
            }
            return list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            var plist = from c in item.ChildNodes
                        orderby c.Entity.ThuTu ascending
                        select c;
            foreach (HierarchyNode<DanhMuc> _item in plist)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<DanhMuc>> _list = new List<HierarchyNode<DanhMuc>>();
            foreach (HierarchyNode<DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        #endregion
    }
}
