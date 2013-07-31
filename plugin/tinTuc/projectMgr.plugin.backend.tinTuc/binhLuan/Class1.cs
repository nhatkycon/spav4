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
using System.Globalization;
using System.IO;
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("projectMgr.plugin.backend.tinTuc.binhLuan.htm.htm", "text/html")]
namespace projectMgr.plugin.backend.tinTuc.binhLuan
{
    public class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "Milan", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _F_ID = Request["F_ID"];
            string _Lang = Request["Lang"];
            string _Alias = Request["Alias"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _LangBased = Request["LangBased"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDung = Request["NoiDung"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _Status = Request["Status"];
            string _Nguon = Request["Nguon"];
            List<jgridRow> ListRow;
            #endregion
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    string _NguoiTao = Security.Username;
                    int _acp = 2;
                    if (string.IsNullOrEmpty(_Lang))
                    {
                        _Lang = "Vi-vn";
                    }
                    Pager<Comment> PagerGet = CommentDal.pagerNormal( _q);

                    ListRow = new List<jgridRow>();
                    foreach (Comment item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.KH_Ten
                            ,item.KH_Email
                            ,item.KH_Mobile
                            ,item.NoiDung
                            ,item.Active.ToString()
                            ,item.PID == 0 ? "" : string.Format(@"<a href=""../pages/TinTuc_Tin_ChiTiet.aspx?ID={0}"" target=""_blank"">></a>", item.PID)
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    //jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "add":
                    #region thêm mới
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    Comment itemGetVanBan = CommentDal.SelectById(Convert.ToInt32(_ID));
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemGetVanBan));
                    break;
                    #endregion
                case "send":
                    #region chỉnh sửa
                    Comment itemSend = CommentDal.SelectById(Convert.ToInt32(_ID));
                    itemSend.Active = true;
                    CommentDal.Update(itemSend);

                    _dele.BeginInvoke(itemSend.KH_Email
                            , string.Format("Milan Clinic & Spa - MilanSpa.vn: Tra loi  {0}", DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("{0}<hr/>{1}", _NoiDung
                            , itemSend.PID == 0 ? "" : string.Format(@"Quý khách vui lòng <a href=""http://milanspa.vn/lib/pages/TinTuc_Tin_ChiTiet.aspx?ID={1}"">xem bình luận</a>", domain, itemSend.PID))
                            , null, null);

                    _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("Milan Clinic & Spa - MilanSpa.vn: Tra loi  {0}", DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("{0}<hr/>{1}", _NoiDung
                            , itemSend.PID == 0 ? "" : string.Format(@"Quý khách vui lòng <a href=""http://milanspa.vn/lib/pages/TinTuc_Tin_ChiTiet.aspx?ID={1}"">xem bình luận</a>", domain, itemSend.PID))
                            , null, null);
                    itemSend.KH_Ten = "MilanSpa.vn";
                    itemSend.KH_Mobile = "";
                    itemSend.NoiDung = _NoiDung;
                    itemSend.Active = true;                      
                    CommentDal.Insert(itemSend);
                    break;
                    #endregion
                case "save":
                    #region chỉnh sửa
                    Comment itemSend1 = CommentDal.SelectById(Convert.ToInt32(_ID));
                    itemSend1.NoiDung = _NoiDung;
                    CommentDal.Update(itemSend1);
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        CommentDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "duyet":
                    #region Duyệt tin hàng loạt
                    Tin ItemDuyet = new Tin();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        CommentDal.ActiveById(_ID);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <a class=""mdl-head-btn mdl-head-del"" id=""dbtinmdl-delBtn"" href=""javascript:dbBlfn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbBlfn.duyet('true');"">Duyệt</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinmdlDuyetTin-addBtn"" href=""javascript:dbBlfn.rep('true');"">Sửa & Trả lời</a>
</div>
<table id=""dbBlMdl-List"" class=""mdl-list""></table>
<div id=""dbBlMdl-Pagerql""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "projectMgr.plugin.backend.tinTuc.binhLuan.JScript1.js")
                        , "{dbBlfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
