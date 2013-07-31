using System;
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
using System.IO;
[assembly: WebResource("projectMgr.plugin.backend.taiLieu.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.taiLieu.htm.htm", "text/html")]
namespace projectMgr.plugin.backend.taiLieu
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _File = Request["File"];
            string _F_ID = Request["F_ID"];
            string _ID = Request["ID"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _ThuTu = Request["ThuTu"];
            string _TacGia = Request["TacGia"];
            string _NhaXuatBan = Request["NhaXuatBan"];
            string _NgonNgu = Request["NgonNgu"];
            string _GiaBan = Request["GiaBan"];
            string _KichThuoc = Request["KichThuoc"];
            string _Url = Request["QUrl"];
            string _Anh = Request["Anh"];
            string _q = Request["q"];
            
            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TL_ThuTu";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";

                    Pager<TaiLieu> pager = TaiLieuDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _PID);
                    
                    ListRow = new List<jgridRow>();
                    foreach (TaiLieu item in pager.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.ThuTu.ToString()
                            ,string.Format("<img src=\"../up/i/{0}\"/>",item.Anh)
                            ,item.DM_ID.ToString()
                            ,item.DM_Ten
                            ,item.Ten
                            ,item.TacGia
                            ,item.NhaXuatBan
                            ,item.NgonNgu
                            ,item.GiaBan
                            ,item.Url
                        }));
                    }
                    jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "insert":
                    #region lưu dữ liệu tạm
                    TaiLieu ItemInsert = new TaiLieu();
                    ItemInsert.RowId = Guid.NewGuid();
                    ItemInsert.NgayTao = DateTime.Now;
                    ItemInsert.NguoiTao = Security.Username;
                    ItemInsert.NguoiCapNhat = Security.Username;
                    ItemInsert.NgayCapNhat = DateTime.Now;
                    ItemInsert.Draff = true;
                    ItemInsert = TaiLieuDal.InsertDraff(ItemInsert);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(ItemInsert));
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
                        TaiLieu itemGetVanBan = TaiLieuDal.SelectByIdView(Convert.ToInt32(_ID));
                        if (itemGetVanBan.Filelist.Count > 0)
                        {
                            if (itemGetVanBan.Filelist[0].ID != 0)
                            {
                                foreach (Files item in itemGetVanBan.Filelist)
                                {
                                    itemGetVanBan.FileListStr += string.Format(@"<span _value=""{0}"" class=""adm-token-item"">{1}{2}<a href=""javascript:;"">x</a></span>"
                                        , item.ID, item.Ten,item.MimeType);
                                }
                            }
                            sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan));
                        }
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                       TaiLieuDal.DeleteMultiById(_ID);
                    }
                    break;
                    #endregion
                case "saveDoc":
                    #region Lưu tài liệu
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        item.PID = new Guid(_ID);
                        item = FilesDal.Update(item);
                        sb.AppendFormat(item.Size.ToString());
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        string _directory = Server.MapPath("~/up/d/") + item.ThuMuc;
                        string _files = Server.MapPath("~/up/d/") + item.ThuMuc + "/" + item.Ten + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_files);
                            Directory.Delete(_directory);
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    TaiLieu ItemSave = new TaiLieu();
                    if (string.IsNullOrEmpty(_Ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = TaiLieuDal.SelectById(Convert.ToInt32(_ID));
                    }                    
                    ItemSave.Ten = _Ten;
                    if (string.IsNullOrEmpty(_ThuTu))
                    {
                        _ThuTu = "1";
                    }
                    ItemSave.ThuTu = Convert.ToInt32(_ThuTu);
                    ItemSave.Url = _Url;
                    ItemSave.DM_ID = Convert.ToInt32(_PID);
                    ItemSave.DM_Ten = _PTen;
                    ItemSave.NguoiCapNhat = Security.Username;
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.Draff = false;
                    ItemSave.TacGia = _TacGia;
                    ItemSave.NhaXuatBan = _NhaXuatBan;
                    ItemSave.NgonNgu = _NgonNgu;
                    ItemSave.KichThuoc = _KichThuoc;
                    ItemSave.GiaBan = _GiaBan;
                    ItemSave.Anh = _Anh;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = TaiLieuDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = TaiLieuDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "mpig.plugin.backend.tailieu.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tailieu"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""tailieumdl-addBtn"" href=""javascript:tailieufn.add();"">Thêm mới</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""tailieumdl-editBtn"" href=""javascript:tailieufn.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""tailieumdl-delBtn"" href=""javascript:tailieufn.del();"">Xóa</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterdanhmuc""/>
</span>
</div>
<table id=""tailieumdl-List"" class=""mdl-list""></table>
<div id=""tailieumdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.taiLieu.JScript1.js")
                        , "{tailieufn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




 