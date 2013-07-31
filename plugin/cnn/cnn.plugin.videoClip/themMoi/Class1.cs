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
using cnn.entities;
using docsoft.entities;
using System.Xml;
using System.Globalization;
[assembly: WebResource("cnn.plugin.videoClip.themMoi.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.videoClip.themMoi.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.videoClip.themMoi
{
    public class Class1 : docPlugUI
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _id = Request["ID"];
            string _gh_id = Request["GH_ID"];
            string _chude_id = Request["ChuDe_ID"];
            string _chude_ten = Request["TenChuDe"];
            string _ten = Request["Ten"];
            string _thutu = Request["Thutu"];
            string _mota = Request["Mota"];
            string _anh = Request["UrlImage"];
            string _duyet = Request["Duyet"];
            string _clip = Request["Url"];
            string _cq_id = Request["CQ_ID"];
            string _active = Request["Active"];
            string _q = Request["q"];


            #endregion
            switch (subAct)
            {
                case "getVideo":
                    #region lấy danh sách
                    
                    string _NguoiTao = Security.Username;
                    if (string.IsNullOrEmpty(jgRows)) jgRows = "5";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "Thutu";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<VideoClip> PagerGet = VideoClipDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, Request["rows"], _gh_id, _chude_id, _active);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    foreach (VideoClip item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                             ,item.Thutu.ToString()
                            ,string.Format("<img class=\"adm-pro-icon\" src=\"../up/v/{0}\" />", string.IsNullOrEmpty(item.UrlImage) ? "no-image.png" :item.UrlImage)                            
                            ,item.Ten                                      
                            ,item.Mota 
                            ,item.SoLuotXem.ToString()
                            ,DanhMucDal.SelectById(item.ChuDe_ID).Ten.ToString()
                            ,item.Ngaytao.ToString("dd/MM/yy")
                            ,item.NguoiTao
                            ,item.Active.ToString()
                                                   
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion                 
                case "saveVideo":
                    #region lưu dữ liệu
                    VideoClip ItemSave = new VideoClip();
                    if (!string.IsNullOrEmpty(_id))
                    {
                        ItemSave = VideoClipDal.SelectById(Convert.ToInt32(_id));
                    }
                    
                    ItemSave.Ten = _ten;
                    ItemSave.ChuDe_ID = int.Parse(_chude_id);
                    ItemSave.Mota = string.IsNullOrEmpty(_mota) ? "" : _mota;
                    ItemSave.Active = Convert.ToBoolean(_duyet);
                    ItemSave.UrlImage = _anh;
                    ItemSave.Url = _clip;
                    ItemSave.Thutu = Convert.ToInt16(_thutu);
                    ItemSave.Loai = 1;
                    ItemSave.Keyword = "";
                    ItemSave.CateID = 0;

                    // ItemSave.PID = Convert.ToInt32(_PID);

                    if (!string.IsNullOrEmpty(_id))
                    {
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.Ngaytao = DateTime.Now;
                        ItemSave = VideoClipDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.SoLuotXem = 0;
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.Ngaytao = DateTime.Now;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = VideoClipDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "delVideo":
                    #region xóa
                    if (!string.IsNullOrEmpty(_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _id.Split(step);
                        for (int i = 0; i < arrID.Length; i++)
                        {
                            VideoClip o = new VideoClip();
                            o = VideoClipDal.SelectById(Convert.ToInt32(arrID[i]));
                            try
                            {
                                System.IO.File.Delete(Server.MapPath("~/up/v/" + o.UrlImage));
                                System.IO.File.Delete(Server.MapPath("~/up/v/" + o.Url));
                            }
                            catch { }
                            VideoClipDal.DeleteById(Convert.ToInt32(arrID[i]));
                        }
                    }
                    break;
                    #endregion
                case "duyetVideo":
                    #region Duyệt
                    if (!string.IsNullOrEmpty(_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _id.Split(step);
                        for (int i = 0; i < arrID.Length; i++)
                        {
                            VideoClip o = new VideoClip();
                            o = VideoClipDal.SelectById(Convert.ToInt32(arrID[i]));
                            o.Active = true;
                            VideoClipDal.Update(o);
                        }
                    }
                    break;
                    #endregion
                case "dungVideo":
                    #region Dừng
                    if (!string.IsNullOrEmpty(_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _id.Split(step);
                        for (int i = 0; i < arrID.Length; i++)
                        {
                            if (arrID[i] != "")
                            {
                                VideoClip o = new VideoClip();
                                o = VideoClipDal.SelectById(Convert.ToInt32(arrID[i]));
                                o.Active = false;
                                VideoClipDal.Update(o);
                            }
                        }
                    }
                    break;
                    #endregion
                case "editVideo":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_id))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(VideoClipDal.SelectById(Convert.ToInt32(_id))) + ")");
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.videoClip.themMoi.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head""> 
 <a class=""mdl-head-btn mdl-head-add"" id=""videoMdl-addBtn"" href=""javascript:videoClipfn.addVideo(); "">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""videoMdl-editBtn"" href=""javascript:videoClipfn.editVideo();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""videoMdl-delBtn"" href=""javascript:videoClipfn.delVideo();"">Xóa</a>
<a class=""mdl-head-btn mdl-head-active"" id=""videoMdl-actBtn"" href=""javascript:videoClipfn.duyetVideo();"">Duyệt</a>
<a class=""mdl-head-btn mdl-head-deactive"" id=""videoMdl-edactBtn"" href=""javascript:videoClipfn.dungVideo();"">Dừng</a>
</div>

<div id=""VideoClip-head"" class=""mdl-head mdl-headTask ui-accordion-header ui-helper-reset ui-state-default ui-widget ui-corner-all"">                                                                            
            <span>                                                         
                <input type=""text"" _value="""" class=""admtxt-da ui-corner-all mdl-head-filterChuDe"" /><button class=""admfilter-btn"" tabindex=""-1""></button>
            </span>                                    
            <span>                                               
                <input type=""text"" class=""admtxt-da ui-corner-all mdl-head-search-VideoClipmdl"" /><button class=""admSearch-btn"" tabindex=""-1""></button>                            
            </span>               
      </div>
</div>

<table id=""videoClipMdl-List"" class=""mdl-list""></table>
<div id=""videoClipmdl-Pager""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                       , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.videoClip.themMoi.JScript1.js")
                       , "{videoClipfn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }


    }
}
