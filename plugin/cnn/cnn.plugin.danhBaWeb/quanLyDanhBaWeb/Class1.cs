using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh;
using linh.common;
using docsoft;
using cnn.entities;
using docsoft.entities;
using System.Web;
using System.Web.UI;
using linh.json;
using linh.controls;
using System.Globalization;
[assembly: WebResource("cnn.plugin.danhBaWeb.quanLyDanhBaWeb.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.danhBaWeb.htm.htm", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.danhBaWeb.quanLyDanhBaWeb
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region Tham so GianHang
            string _GH_ID = Request["ID"];
            string _CQ_ID = Request["CQ_ID"];
            string _TINH_ID = Request["TINH_ID"];
            string _NhomDN_ID = Request["NhomDN_ID"];
            string _LTV_ID = Request["LTV_ID"];
            string _LDN_ID = Request["LDN_ID"];
            string _MEM_ID = Request["MEM_ID"];
            string _Lang = Request["Lang"];
            string _LangBased = Request["LangBased"];
            string _LangBasedId = Request["LangBasedId"];
            string _Ma = Request["Ma"];
            string _Ten = Request["Ten"];
            string _TomTat = Request["TomTat"];
            string _MoTa = Request["MoTa"];
            string _LienHe = Request["LienHe"];
            String _NguoiDaiDien = Request["NguoiDaiDien"];
            string _ChinhSach = Request["ChinhSach"];
            string _Footer = Request["Footer"];
            string _GioiThieu = Request["GioiThieu"];
            string _Anh = Request["Anh"];
            string _Flash = Request["Flash"];
            string _FlashFile = Request["FlashFile"];
            string _FlashWidth = Request["FlashWidth"];
            string _FlashHeight = Request["FlashHeight"];
            string _Slogan = Request["Slogan"];
            string _Banner = Request["Banner"];
            string _BannerType = Request["BannerType"];
            string _DungGiaoDien = Request["DungGiaoDien"];
            string _GD_ID = Request["GD_ID"];
            string _DiaChi = Request["DiaChi"];
            string _website = Request["Website"];
            string _dienthoai = Request["DienthoaiDN"];
            string _Email = Request["Email"];
            string _NamThanhLap = Request["NamThanhLap"];
            string _ToaDo = Request["ToaDo"];
            string _Xem = Request["Xem"];
            string _BinhChon = Request["BinhChon"];
            string _Diem = Request["Diem"];
            string _Hotline = Request["Hotline"];
            string _NgayTao = Request["NgayTao"];
            string _NgayCapNhat = Request["NgayCapNhat"];
            string _KichHoat = Request["KichHoat"];
            string _NgayKichHoat = Request["NgayKichHoat"];
            string _DamBao = Request["DamBao"];
            string _NgayDamBao = Request["NgayDamBao"];
            string _rows_id = Request["Rows_ID"];
            string _q = Request["q"];
            string _startDateLTV = Request["GH_NgayBatDau"];
            string _endDateLTV = Request["GH_NgayKetThuc"];
            string ldm_ma = Request["LDM_Ma"];
            #endregion
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            switch (subAct)
            {

                case "get":
                    #region get du lieu
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    Pager<GianHang> PageGet = GianHangDal.pagerNormalView("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _TINH_ID, _LTV_ID, _NhomDN_ID,"", Request["rows"]);
                    List<jgridRow> ListRows = new List<jgridRow>();
                    int b = 0;
                    foreach (GianHang gh in PageGet.List)
                    {
                        b = b + 1;
                        ListRows.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    b.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                                              
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    gh.webNoiBat.ToString()                               
                                                                       
                                 }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1":jgrpage, PageGet.TotalPages.ToString(), PageGet.Total.ToString(), ListRows);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "Active":
                #region active web noi bat
                  if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.ActiveWebNoiBat(_GH_ID, "1");
                    }
                    break;                  
                #endregion
                case "HuyNoiBat":
                    #region active web noi bat
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.ActiveWebNoiBat(_GH_ID, "0");
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.danhBaWeb.quanLyDanhBaWeb.JScript1.js"));
                    break;
                    #endregion

                default:
                    #region Nap
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"

<div id=""danhBaWebMdl-Main-NewDlg"">

      <div id=""danhBaWebMdl-head"" class=""mdl-head mdl-headTask ui-accordion-header ui-helper-reset ui-state-default ui-widget ui-corner-all"">                                                                                                                     
                <a class=""mdl-head-btn mdl-head-noiBat"" id=""noibat"" href=""javascript:""  onclick=""danhBaWebFn.ActiveNoiBat();"">Active nổi bật</a>                    
                <a class=""mdl-head-btn mdl-head-khoa"" id=""khoa"" href=""javascript:""  onclick=""danhBaWebFn.HuyNoiBat();"">Hủy nổi bật</a>
                                                     
      </div>
       <table id=""danhBaWebMdl-List"" class=""mdl-list""></table>
       <div id=""danhBaWebMdl-Pager""></div>        

</div>                                                                      
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.danhBaWeb.quanLyDanhBaWeb.JScript1.js")
                        , "{danhBaWebFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}

 

 