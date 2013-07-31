//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.UI;
//using System.Web;
//using linh;
//using linh.frm;
//using linh.json;
//using linh.common;
//using linh.controls;
//using docsoft;
//using cnn.entities;
//using docsoft.entities;
//using System.Xml;
//using System.Globalization;
//[assembly: WebResource("cnn.plugin.Video.JScript1.js", "text/javascript", PerformSubstitution = true)]
//[assembly: WebResource("cnn.plugin.Video.add.htm", "text/html", PerformSubstitution = true)]
//namespace cnn.plugin.Video
//{
//    public class Class1 : docPlugUI
//    {
//        protected override void Render(System.Web.UI.HtmlTextWriter writer)
//        {
//            StringBuilder sb = new StringBuilder();
//            ClientScriptManager cs = this.Page.ClientScript;
//            #region Tham số
//            string _id = Request["ID"];
//            string _gh_id = Request["GH_ID"];
//            string _chude_id = Request["ChuDe_ID"]; 
//            string _Ten = Request["Ten"];
//            string _Thutu = Request["Thutu"];
//            string _Mota = Request["Mota"];
//            string _Anh = Request["Anh"];
//            string _Duyet = Request["Duyet"];
//            string _Clip = Request["clip"];
//            string _CQ_ID = Request["CQ_ID"];
//            string _q= Request["q"];


//            #endregion
//            switch (subAct)
//            {
//                case "get":
//                    #region lấy danh sách
//                       string _NguoiTao = Security.Username;
//                    int _acp=1;
//                    if (string.IsNullOrEmpty(jgRows)) jgRows = "5";
//                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "Thutu";
//                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
//                    Pager<VideoClip> PagerGet = VideoClipDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, Request["rows"],_gh_id, _chude_id);
//                    List<jgridRow> ListRow = new List<jgridRow>();
//                    foreach (VideoClip item in PagerGet.List)
//                    {
//                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
//                            item.ID.ToString()
//                            ,string.Format("<img class=\"adm-pro-icon\" src=\"../up/v/{0}\" />", string.IsNullOrEmpty(item.UrlImage) ? "no-image.png" :item.UrlImage) 
//                            ,item.Ten  
//                             ,(item.Thutu.ToString())       
//                            ,item.Mota                           
//                            ,item.Active.ToString()
                                                   
//                        }));
//                    }
//                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
//                    sb.Append(JavaScriptConvert.SerializeObject(grid));
//                    break;
//                    #endregion
//                case "getpid":
//                    #region lấy danh sách cho autocomplete
//                    //List<Function> l = new List<Function>();
//                    //List<Function> ListGetPid = FunctionDal.SelectTree(Request["q"]);
//                    //for (int k = 0; k < ListGetPid.Count; k++)
//                    //{
//                    //    if (ListGetPid[k].Ma == "san-pham")
//                    //    {
//                    //        l = FunctionDal.SelectAllChildrentPID(ListGetPid[k].ID);
//                    //        if (l.Count == 0)
//                    //        {
//                    //            l.Insert(0, ListGetPid[k]);
//                    //        }
//                    //        break;
//                    //    }
//                    //}
//                    //sb.Append(JavaScriptConvert.SerializeObject(l));
//                    break;
//                    #endregion
//                case "save":
//                    #region lưu dữ liệu
//                    Thuvien ItemSave = new Thuvien();
//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        ItemSave = ThuvienDal.SelectById(Convert.ToInt32(_id));
//                    }

//                    ItemSave.Ngaytao = DateTime.Now;
//                    ItemSave.Ten = _Ten;

//                    ItemSave.Mota = string.IsNullOrEmpty(_Mota) ? "" : _Mota;
//                    ItemSave.Active = Convert.ToBoolean(_Duyet);
//                    ItemSave.UrlImage = _Anh;
//                    ItemSave.Url = _Clip;
//                    ItemSave.Thutu = Convert.ToInt16(_Thutu);
//                    ItemSave.Loai = 1;
//                    ItemSave.Keyword = "";
//                    ItemSave.CateID = 0;

//                    // ItemSave.PID = Convert.ToInt32(_PID);

//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        ItemSave = ThuvienDal.Update(ItemSave);
//                    }
//                    else
//                    {
//                        ItemSave.Ngaytao = DateTime.Now;
//                        ItemSave.RowId = Guid.NewGuid();
//                        ItemSave = ThuvienDal.Insert(ItemSave);
//                    }
//                    sb.Append("1");
//                    break;
//                    #endregion
//                case "del":
//                    #region xóa
//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        char[] step = { ',' };
//                        string[] arrID = _id.Split(step);
//                        for (int i = 0; i < arrID.Length; i++)
//                        {
//                            Thuvien o = new Thuvien();
//                            o = ThuvienDal.SelectById(Convert.ToInt32(arrID[i]));
//                            try
//                            {
//                                System.IO.File.Delete(Server.MapPath("~/up/v/" + o.UrlImage));
//                                System.IO.File.Delete(Server.MapPath("~/up/v/" + o.Url));
//                            }
//                            catch { }
//                            ThuvienDal.DeleteById(Convert.ToInt32(arrID[i]));
//                        }
//                    }
//                    break;
//                    #endregion
//                case "duyet":
//                    #region Duyệt
//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        char[] step = { ',' };
//                        string[] arrID = _id.Split(step);
//                        for (int i = 0; i < arrID.Length; i++)
//                        {
//                            Thuvien o = new Thuvien();
//                            o = ThuvienDal.SelectById(Convert.ToInt32(arrID[i]));
//                            o.Active = true;
//                            ThuvienDal.Update(o);
//                        }
//                    }
//                    break;
//                    #endregion
//                case "dung":
//                    #region Dừng
//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        char[] step = { ',' };
//                        string[] arrID = _id.Split(step);
//                        for (int i = 0; i < arrID.Length; i++)
//                        {
//                            Thuvien o = new Thuvien();
//                            o = ThuvienDal.SelectById(Convert.ToInt32(arrID[i]));
//                            o.Active = false;
//                            ThuvienDal.Update(o);
//                        }
//                    }
//                    break;
//                    #endregion
//                case "edit":
//                    #region chỉnh sửa
//                    if (!string.IsNullOrEmpty(_id))
//                    {
//                        sb.Append("(" + JavaScriptConvert.SerializeObject(ThuvienDal.SelectById(Convert.ToInt32(_id))) + ")");
//                    }
//                    break;
//                    #endregion
//                case "scpt":
//                    #region Nạp js
//                    sb.AppendFormat(@"{0}"
//                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Video.JScript1.js"));
//                    break;
//                    #endregion
//                default:
//                    #region nạp
//                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
//                    sb.Append(@"<div class=""mdl-head"">
//<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
//<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//    <input class=""admtxt-medium ui-corner-all SearchTxt"" />
//</span>
// <a class=""mdl-head-btn mdl-head-add"" id=""videoMdl-addBtn"" href=""javascript:video.add();"">Thêm</a>
//<a class=""mdl-head-btn mdl-head-edit"" id=""videoMdl-editBtn"" href=""javascript:video.edit();"">Sửa</a>
//<a class=""mdl-head-btn mdl-head-del"" id=""videoMdl-delBtn"" href=""javascript:video.del();"">Xóa</a>
//<a class=""mdl-head-btn mdl-head-active"" id=""videoMdl-actBtn"" href=""javascript:video.duyet();"">Duyệt</a>
//<a class=""mdl-head-btn mdl-head-deactive"" id=""videoMdl-edactBtn"" href=""javascript:video.dung();"">Dừng</a>
//
//
//<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filtervideoByCQID""/>
//</span>
//</div>
//
//<table id=""videomdl-List"" class=""mdl-list""></table>
//<div id=""videomdl-Pager""></div>");
//                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
//                       , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Video.JScript1.js")
//                       , "{video.loadgrid();}");
//                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
//                    break;
//                    #endregion
//            }
//            writer.Write(sb.ToString());
//            base.Render(writer);
//        }


//    }
//}
