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
using System.Data;
[assembly: WebResource("cnn.plugin.doanhNghiep.thanhVienBiKhoa.doanhNghiepTVBK.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.thanhVienMienPhi.doanhNghiepTVMP.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.thanhVienDong.doanhNghiepTVD.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.thanhVienBac.doanhNghiepTVB.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.thanhVienVang.doanhNghiepTVV.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.chuaDuyet.doanhNghiepChuaDuyet.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.daDuyet.doanhNghiepDaDuyet.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.Mainform.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.nangCapTV.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.ChungChi.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.Video.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.Flash.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.HinhAnh.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.doanhNghiep.doanhNghiep.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.doanhNghiep
{
    public class doanhNghiep : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com", "123$5678");
        }

        #region inviMailBody
        public const string inviMailBody = @"<table cellspacing=""0"" cellpadding=""40"" border=""0"" width=""98%"">
    <tbody>
        <tr>
            <td bgcolor=""#C0D6E1"" width=""100%"" style=""font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;"">
                <table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""720"">
                    <tbody>
                        <tr>
                            <td style=""background: none repeat scroll 0% 0% #459C06; color: #FFF;
                                font-weight: bold; font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;
                                padding: 8px 8px; vertical-align: middle; font-size: 16px; letter-spacing: -0.03em;
                                text-align: left;"">
                                THÔNG BÁO TỪ CHONONGNGHIEP.COM
                            </td>
                        </tr>
                        <tr>
                            <td valign=""top"" style=""background-color: rgb(255, 255, 255); border-bottom: 1px solid rgb(59, 89, 152);
                                border-left: 1px solid rgb(204, 204, 204); border-right: 1px solid rgb(204, 204, 204);
                                font-family: 'lucida grande',tahoma,verdana,arial,sans-serif; padding: 15px;"">
                                <table width=""100%"">
                                    <tbody>
                                        <tr>
                                            <td align=""left"" width=""470px"" valign=""top"" style=""font-size: 12px;"">
                                                <div >
                                                    <strong><em>Kính gửi: </em><span style="" font-size: 15px"">{0}</span></strong></div>                                               
                                                <div style=""margin-bottom: 15px;"">- Địa chỉ:<strong> {1}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Email: <strong>{2}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Ban quản trị chonongnghiep.com xin thông báo, Quý doanh nghiệp đã <strong><font color=""FF0000"">{3}</font></strong> từ ngày <strong>{4}</strong></div>                                                                                 
                                               <div style=""margin-bottom: 15px;""><strong>
                                                    <br />
                                                    <em>Trân trọng cám ơn Quý doanh nghiệp đã tham gia và ủng hộ chonongnghiep.com</em><div style=""margin-bottom: 15px;""><strong>
                                                        <em>Chúc Quý doanh nghiệp phát triển không ngừng!</em><br />                                                   
                                                    _____________________</em></strong></div>
                                                 <div style=""margin-bottom:20px; color:#0000FF; font-size: larger;""> Ban quản trị chonongnghiep.com</div>
                                                   <span style=""font-size: 12px;"">Để biết thêm chi tiết, xin liên hệ:<br />
                                                   </span></strong> <span style=""font-size: 12px;"">
                                                   <span style=""font-size: 12px; font-style: italic;"">{5}</span></div>
                                             </td>
                                             <td align=""left"" width=""200"" valign=""top"" style=""padding-left: 15px;"">
                                                <table cellspacing=""0"" cellpadding=""0"" width=""100%"" style=""height:100%"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""background-color: rgb(255, 248, 204); border: 1px solid rgb(255, 226, 34);
                                                                color: rgb(51, 51, 51); padding: 10px; font-size: 12px;"">
                                                                <div style=""margin-bottom: 15px;"">
                                                                    <br />
                                                                    Phần LOGO........................:</div>
                                                                <table  width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style=""border: 1px solid rgb(59, 110, 34);"">
                                                                                <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style=""padding: 5px 15px; background-color: #FF9900; border-top: 1px solid #B2B2B2;"">
                                                                                               Img Logo ................
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style=""color: rgb(153, 153, 153); padding: 10px; font-size: 11px; font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;"">
                                <font color=""999999"">
                                    CHONONGNGHIEP.COM <br />
                                    BẢN QUYỀN THUỘC TRUNG TÂM CÔNG NGHỆ PHẦN MỀM THUỶ LỢI - VIỆN KHOA HỌC THUỶ LỢI 
                                    VIỆT NAM<br />
                                    Địa chỉ: 269 Chùa Bộc - Đống Đa - Hà Nội - Tel: 84.4.35634913 - Fax: 84.4.35626602<br />
                                    Website: http://phanmemthuyloi.vn - Email: phanmemthuyloi@gmail.com
                                    <br />Nick hỗ trợ trực tuyến:
                                    <a target=""_blank"" href=""ymsgr:sendIM?pvqha9"">
                                        <img src=""http://opi.yahoo.com/online?u=pvqha9&m=g&t=0"" style=""border:0;"" />  Phạm Văn Quý
                                    </a>
                                      &nbsp;|&nbsp;
                                    <a target=""_blank"" href=""ymsgr:sendIM?linh_net"">
                                        <img src=""http://opi.yahoo.com/online?u=linh_net&m=g&t=0"" style=""border:0;"" /> Nguyễn Xuân Linh
                                    </a>
                                </font>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";
        #endregion
        #region NoiDungLienHeDN
        public const string NoiDungLienHeDN = @"<table cellspacing=""0"" cellpadding=""40"" border=""0"" width=""98%"">
    <tbody>
        <tr>
            <td bgcolor=""#C0D6E1"" width=""100%"" style=""font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;"">
                <table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""720"">
                    <tbody>
                        <tr>
                            <td style=""background: none repeat scroll 0% 0% #459C06; color: #FFF;
                                font-weight: bold; font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;
                                padding: 8px 8px; vertical-align: middle; font-size: 16px; letter-spacing: -0.03em;
                                text-align: left;"">
                                &nbsp;THÔNG BÁO TỪ CHONONGNGHIEP.COM
                            </td>
                        </tr>
                        <tr>
                            <td valign=""top"" style=""background-color: rgb(255, 255, 255); border-bottom: 1px solid rgb(59, 89, 152);
                                border-left: 1px solid rgb(204, 204, 204); border-right: 1px solid rgb(204, 204, 204);
                                font-family: 'lucida grande',tahoma,verdana,arial,sans-serif; padding: 15px;"">
                                <table width=""100%"">
                                    <tbody>
                                        <tr>
                                            <td align=""left"" width=""470px"" valign=""top"" style=""font-size: 12px;"">
                                                <div >
                                                    <strong><em>Kính gửi: </em><span style="" font-size: 15px"">{0}</span></strong></div>                                               
                                                <div style=""margin-bottom: 15px;"">- Địa chỉ:<strong> {1}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Email: <strong>{2}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Nội dung thông báo: <br><strong>{3}</strong></div>                                                                                 
                                               <div style=""margin-bottom: 15px;""><strong>
                                                    <br />
                                                    <em>Trân trọng cám ơn Quý doanh nghiệp đã tham gia và ủng hộ chonongnghiep.com</em><div style=""margin-bottom: 15px;""><strong>
                                                        <em>Chúc Quý doanh nghiệp phát triển không ngừng!</em><br />                                                   
                                                    _____________________</em></strong></div>
                                                 <div style=""margin-bottom:20px; color:#0000FF; font-size: larger;""> Ban quản trị chonongnghiep.com</div>
                                                   <span style=""font-size: 12px;"">Để biết thêm chi tiết, xin liên hệ:<br />
                                                   </span></strong> <span style=""font-size: 12px;"">
                                                   <span style=""font-size: 12px; font-style: italic;"">{4}</span></div>
                                             </td>
                                             <td align=""left"" width=""200"" valign=""top"" style=""padding-left: 15px;"">
                                                <table cellspacing=""0"" cellpadding=""0"" width=""100%"" style=""height:100%"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""background-color: rgb(255, 248, 204); border: 1px solid rgb(255, 226, 34);
                                                                color: rgb(51, 51, 51); padding: 10px; font-size: 12px;"">
                                                                <div style=""margin-bottom: 15px;"">
                                                                    <br />
                                                                    <center><b>BAN QUẢN TRỊ</b> </center></div>
                                                                <table  width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style=""border: 1px solid rgb(59, 110, 34);"">
                                                                                <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style=""padding: 5px 15px; background-color: #FF9900; border-top: 1px solid #FCFCFC;"">
                                                                                               CHONONGNGHIEP.COM                                                                                                 
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style=""color: rgb(153, 153, 153); padding: 10px; font-size: 11px; font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;"">
                                <font color=""999999"">
                                    CHONONGNGHIEP.COM <br />
                                    BẢN QUYỀN THUỘC TRUNG TÂM CÔNG NGHỆ PHẦN MỀM THUỶ LỢI - VIỆN KHOA HỌC THUỶ LỢI 
                                    VIỆT NAM<br />
                                    Địa chỉ: 269 Chùa Bộc - Đống Đa - Hà Nội - Tel: 84.4.35634913 - Fax: 84.4.35626602<br />
                                    Website: http://phanmemthuyloi.vn - Email: phanmemthuyloi@gmail.com
                                    <br />Nick hỗ trợ trực tuyến:
                                    <a target=""_blank"" href=""ymsgr:sendIM?pvqha9"">
                                        <img src=""http://opi.yahoo.com/online?u=pvqha9&m=g&t=0"" style=""border:0;"" />  Phạm Văn Quý
                                    </a>
                                      &nbsp;|&nbsp;
                                    <a target=""_blank"" href=""ymsgr:sendIM?linh_net"">
                                        <img src=""http://opi.yahoo.com/online?u=linh_net&m=g&t=0"" style=""border:0;"" /> Nguyễn Xuân Linh
                                    </a>
                                </font>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>";
        #endregion
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            String socanbo = Request["SoCanBo"];
            String quymonhamay = Request["QuyMoNhaMay"];
            String xuatkhau = Request["TyLeXuatKhau"];
            String doanhthu = Request["DoanhThuHangNam"];
            String solaodong = Request["SoLaoDong"];
            String vonphapdinh = Request["VonPhapDinh"];
            String spdv = Request["SPDV"];
            String arrthitruong = Request["ThiTruong"];
            String arrchatluong = Request["ChatLuong"];
            String arrloaiDN = Request["LoaiDN"];

            String imgLH = Request["ImageLienHe"];
            String diaChiLH = Request["DiaChiNguoiLienHe"];
            String yahoo = Request["Yahoo"];
            String chucDanh = Request["ChucDanh"];
            String diDong = Request["DiDong"];
            String dienThoai = Request["DienThoai"];
            String emailLienHe = Request["EmailLienHe"];
            String gioiTinh = Request["GioiTinh"];
            String tenLienHe = Request["TenNguoiLienHe"];
            String diaChiNhaMay = Request["DiaChiNhaMay"];
            String chinhanh = Request["ChiNhanhDN"];
            String nguoiDaiDien = Request["NguoiDaiDien"];


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
            #region Tham so ChungChi
            string _cc_id = Request["CC_ID"];
            string _cc_gh_id = Request["CC_GH_ID"];
            string _cc_thutu = Request["CC_TT"];
            string _cc_anh = Request["CC_Anh"];
            string _cc_ten = Request["CC_Ten"];
            string _cc_so = Request["CC_So"];
            string _cc_gioihan = Request["CC_GioiHan"];
            string _cc_donvicap = Request["CC_DonViCap"];
            string _cc_ngaycap = Request["CC_NgayCap"];
            string _cc_active = Request["CC_Active"];
            #endregion
            #region Tham so ThuVien
            string _tv_id = Request["TV_ID"];
            string _tv_gh_id = Request["TV_GH_ID"];
            string _tv_ten = Request["TV_Ten"];
            string _tv_mota = Request["TV_Mota"];
            string _tv_keyword = Request["TV_Keyword"];
            string _tv_UrlImage = Request["TV_UrlImage"];
            string _tv_Url = Request["TV_Url"];
            string _tv_thutu = Request["TV_Thutu"];
            string _tv_loai = Request["TV_Loai"];
            string _tv_ngaytao = Request["TV_Ngaytao"];
            string _tv_active = Request["TV_Active"];
            string _tv_nguoitao = Request["TV_NguoiTao"];
            string _rows = Request["rows"];
            #endregion
            #region Tham so Flash
            string _flh_id = Request["Flh_ID"];
            string _flh_gh_id = Request["Flh_GH_ID"];
            string _flh_vitri = Request["Flh_Vitri"];
            string _flh_ten = Request["Flh_Ten"];
            string _flh_mota = Request["Flh_Mota"];
            string _flh_pathimg = Request["Flh_UrlImage"];
            string _flh_pathflash = Request["Flh_Url"];
            string _flh_link = Request["Flh_Link"];
            string _flh_thutu = Request["Flh_Thutu"];
            string _flh_nguoitao = Request["Flh_NguoiTao"];
            string _flh_ngaytao = Request["Flh_NgayTao"];
            string _flh_active = Request["Flh_Active"];
            #endregion
            #region Tham so Hình Ảnh doanh nghiệp
            string _ha_id = Request["HA_ID"];
            string _ha_gh_id = Request["HA_GH_ID"];
            string _ha_vitri = Request["HA_Vitri"];
            string _ha_ten = Request["HA_Ten"];
            string _ha_mota = Request["HA_Mota"];
            string _ha_pathimg = Request["HA_UrlImage"];
            string _ha_link = Request["HA_Link"];
            string _ha_nguoitao = Request["HA_NguoiTao"];
            string _ha_ngaytao = Request["HA_NgayTao"];
            string _ha_active = Request["HA_Active"];
            #endregion

            string lienhe = "";
            string msgDN = Request["NoiDungLienHeDN"];
            string Repass = Request["RePass"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
            #endregion

            switch (subAct)
            {

                case "getChuaDuyet":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    Pager<GianHang> PageGet = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "0", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "", Request["rows"]);
                    List<jgridRow> ListRow = new List<jgridRow>();
                    int a = 0;
                    foreach (GianHang gh in PageGet.List)
                    {
                        a = a + 1;
                        ListRow.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    a.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                     
                                    //string.Format(DanhMucDal.SelectById(gh.LTV_ID)==null? "":DanhMucDal.SelectById(gh.LTV_ID).Ma),                                                                      
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGet.TotalPages.ToString(), PageGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getDuyet":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    Pager<GianHang> PageGetDuyet = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "", Request["rows"]);
                    List<jgridRow> ListRowDuyet = new List<jgridRow>();
                    int b = 0;
                    foreach (GianHang gh in PageGetDuyet.List)
                    {
                        b = b + 1;
                        ListRowDuyet.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    b.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridDuyet = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetDuyet.TotalPages.ToString(), PageGetDuyet.Total.ToString(), ListRowDuyet);
                    sb.Append(JavaScriptConvert.SerializeObject(gridDuyet));
                    break;
                    #endregion
                case "getTVV":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<GianHang> PageGetTVV = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "TV_VANG", Request["rows"]);
                    List<jgridRow> ListRowTVV = new List<jgridRow>();
                    int c = 0;
                    foreach (GianHang gh in PageGetTVV.List)
                    {
                        c = c + 1;
                        ListRowTVV.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    c.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridTVV = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetTVV.TotalPages.ToString(), PageGetTVV.Total.ToString(), ListRowTVV);
                    sb.Append(JavaScriptConvert.SerializeObject(gridTVV));
                    break;
                    #endregion
                case "getTVB":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<GianHang> PageGetTVB = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "TV_BAC", Request["rows"]);
                    List<jgridRow> ListRowTVB = new List<jgridRow>();
                    int d = 0;
                    foreach (GianHang gh in PageGetTVB.List)
                    {
                        d = d + 1;
                        ListRowTVB.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    d.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridTVB = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetTVB.TotalPages.ToString(), PageGetTVB.Total.ToString(), ListRowTVB);
                    sb.Append(JavaScriptConvert.SerializeObject(gridTVB));
                    break;
                    #endregion
                case "getTVD":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<GianHang> PageGetTVD = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "TV_DONG", Request["rows"]);
                    List<jgridRow> ListRowTVD = new List<jgridRow>();
                    int e = 0;
                    foreach (GianHang gh in PageGetTVD.List)
                    {
                        e = e + 1;
                        ListRowTVD.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    e.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridTVD = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetTVD.TotalPages.ToString(), PageGetTVD.Total.ToString(), ListRowTVD);
                    sb.Append(JavaScriptConvert.SerializeObject(gridTVD));
                    break;
                    #endregion

                case "getTVMP":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<GianHang> PageGetTVMP = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, "1", "1", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "TV_FREE", Request["rows"]);
                    List<jgridRow> ListRowTVMP = new List<jgridRow>();
                    int f = 0;
                    foreach (GianHang gh in PageGetTVMP.List)
                    {
                        f = f + 1;
                        ListRowTVMP.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    f.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridTVMP = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetTVMP.TotalPages.ToString(), PageGetTVMP.Total.ToString(), ListRowTVMP);
                    sb.Append(JavaScriptConvert.SerializeObject(gridTVMP));
                    break;
                    #endregion
                case "getTVBK":
                    #region Get du lieu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "NgayTao";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    Pager<GianHang> PageGetTVK = GianHangDal.pagerNormal("", false, "GH_" + jgrsidx + " " + jgrsord, null, "0", _q, _NhomDN_ID, _TINH_ID, _LTV_ID, _LDN_ID, "TV_FREE", Request["rows"]);
                    List<jgridRow> ListRowTVK = new List<jgridRow>();
                    int g = 0;
                    foreach (GianHang gh in PageGetTVK.List)
                    {
                        g = g + 1;
                        ListRowTVK.Add(new jgridRow(gh.ID.ToString(),
                             new string[] { 
                                    gh.ID.ToString(),
                                    g.ToString(),                                     
                                    string.Format(gh.Ten==null?"":gh.Ten),                                     
                                    string.Format(gh.DiaChi==null? "":gh.DiaChi), 
                                    string.Format(gh.TenTinh==null?"":gh.TenTinh),                                     
                                    gh.NgayTao.ToString("dd/MM/yyyy"),                                      
                                    gh.NguoiTao,     
                                    string.Format(gh.Website==null?"":gh.Website), 
                                    string.Format(gh.LH_Ten==null?"":gh.LH_Ten),                                     
                                    string.Format(gh.LH_Mobile==null?"":gh.LH_Mobile),                                                                          
                                    string.Format(gh.NguoiDaiDien==null?"":gh.NguoiDaiDien),
                                    string.Format(MemberDal.SelectAllByUserName(gh.NguoiTao).Email==null?"":MemberDal.SelectAllByUserName(gh.NguoiTao).Email),
                                    string.Format(gh.DienThoai==null?"":gh.DienThoai)
                                                                       
                                 }));
                    }
                    jgrid gridTVK = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PageGetTVK.TotalPages.ToString(), PageGetTVK.Total.ToString(), ListRowTVK);
                    sb.Append(JavaScriptConvert.SerializeObject(gridTVK));
                    break;
                    #endregion
                case "NangCapThanhVien":
                    #region
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(GianHangDal.SelectByGh_IdAndLdm_ma(Convert.ToInt32(_GH_ID), "TV_LOAI")) + ")");
                    }
                    break;
                    #endregion
                case "boxacnhan":
                    #region
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.Xacnhan(_GH_ID, "0", "1");
                    }
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thống báo từ chonongnghiep.com")
                            , string.Format(inviMailBody
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , string.Format("bỏ xác nhận")
                                            , DateTime.Now
                                            , lienhe.ToString()
                                            )
                            , null, null);
                    }
                    break;
                    #endregion

                case "saveNangCapLTV":
                    #region lưu dữ liệu thông tin doanh nghiệp
                    GianHang ghItem = new GianHang();
                    Relation rltItem = new Relation();
                    //update vào gian hàng 
                    string LTV_Ma = DanhMucDal.SelectById(int.Parse(_LTV_ID)).Ma;
                    ghItem = GianHangDal.SelectById(int.Parse(_GH_ID));
                    if (LTV_Ma == "TV_VANG")
                    {
                        ghItem.NgayDKTV_Vang = Convert.ToDateTime(_startDateLTV,new CultureInfo("vi-vn"));
                        ghItem.NgayKTTV_Vang = Convert.ToDateTime(_endDateLTV, new CultureInfo("vi-vn"));
                    }
                    if (LTV_Ma == "TV_BAC")
                    {
                        ghItem.NgayDKTV_Bac = Convert.ToDateTime(_startDateLTV, new CultureInfo("vi-vn"));
                        ghItem.NgayKTTV_Bac = Convert.ToDateTime(_endDateLTV, new CultureInfo("vi-vn"));
                    }
                    if (LTV_Ma == "TV_DONG")
                    {
                        ghItem.NgayDKTV_Dong = Convert.ToDateTime(_startDateLTV, new CultureInfo("vi-vn"));
                        ghItem.NgayKTTV_Dong = Convert.ToDateTime(_endDateLTV, new CultureInfo("vi-vn"));
                    }

                    ghItem.LTV_ID = int.Parse(_LTV_ID);
                    ghItem = GianHangDal.Update(ghItem);

                    //combox, check box Insert vào tblRelation                    
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(_LTV_ID, ghItem.RowId.ToString(), "TV_LOAI");                                    

                    break;
                    #endregion
                case "editGianHang":
                    #region Edit doanh nghiệp
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(GianHangDal.SelectDmIdByGhId(Convert.ToInt32(_GH_ID))) + ")");
                    }
                    break;
                    #endregion
                case "LoadThongTinDN":
                    #region load thong tin doanh nghiep( gian hang)
                    sb.Append("(" + JavaScriptConvert.SerializeObject(GianHangDal.SelectDmIdByGhId(int.Parse(_GH_ID))) + ")");
                    break;
                    #endregion

                case "loadDM":
                    #region load hỗ trợ đăng ký doanh nghiệp
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectLangBasedByPID("", ldm_ma, "0")));
                    break;
                    #endregion
                case "infoBusinessSave":
                    #region lưu dữ liệu thông tin doanh nghiệp
                    GianHang itemGH = new GianHang();
                    Relation itemRLT = new Relation();
                    LienHe itemLH = new LienHe();
                    //update vào gian hàng                     
                    itemGH = GianHangDal.SelectById(int.Parse(_GH_ID));
                    itemGH.ID = itemGH.ID;
                    itemGH.Anh = _Anh;
                    itemGH.MoTa = _MoTa;
                    if (_website != "http://" || _website != null)
                    {
                        itemGH.Website = _website;
                    }
                    itemGH.Ten = _Ten;
                    itemGH.DiaChi = _DiaChi;
                    itemGH.NguoiDaiDien = _NguoiDaiDien;
                    itemGH.TomTat = _TomTat;
                    itemGH.GioiThieu = _GioiThieu;
                    itemGH.Active = true;
                    itemGH.DamBao = false;
                    itemGH.DienThoai = _dienthoai;
                    itemGH.NamThanhLap = int.Parse(_NamThanhLap);
                    itemGH.ActiveDate = DateTime.Now;
                    itemGH.NgayTao = DateTime.Now;
                    itemGH.TINH_ID = int.Parse(_TINH_ID);
                    itemGH.LTV_ID = 11021;
                    itemGH = GianHangDal.Update(itemGH);
                    //Save vào tblLienHe Người liên hệ                    
                    itemLH = LienHeDal.SelectByGhId(int.Parse(_GH_ID));
                    if (gioiTinh == "Nam")
                    {
                        itemLH.GioiTinh = true;
                    }
                    else
                    {
                        itemLH.GioiTinh = false;
                    }
                    itemLH.Ten = tenLienHe;
                    itemLH.Email = emailLienHe;
                    itemLH.Phone = dienThoai;
                    itemLH.Mobile = diDong;
                    itemLH.ChucDanh = chucDanh;
                    itemLH.Ym = yahoo;
                    itemLH.DiaChi = diaChiLH;
                    itemLH.Anh = imgLH;
                    itemLH.NgayCapNhat = DateTime.Now;
                    itemLH.NguoiCapNhat = Security.Username;
                    itemLH.Active = true;
                    itemLH = LienHeDal.Update(itemLH);

                    //itemLH = LienHeDal.Insert(itemLH);
                    //combox, check box Insert vào tblRelation  

                    //Relation_danhMuc_GianHangDal.InsertArrDMByGianHang("11019", itemGH.RowId.ToString(), "TV_LOAI");                                    
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrchatluong, itemGH.RowId.ToString(), "TV_ISO");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrthitruong, itemGH.RowId.ToString(), "TV_TTRUONG");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrloaiDN, itemGH.RowId.ToString(), "DN_LOAI");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(vonphapdinh, itemGH.RowId.ToString(), "TV_VON");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(spdv, itemGH.RowId.ToString(), "SP_NHOM");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(_TINH_ID, itemGH.RowId.ToString(), "KV_TINH");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(solaodong, itemGH.RowId.ToString(), "TV_LD");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(socanbo, itemGH.RowId.ToString(), "TV_R&D");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(doanhthu, itemGH.RowId.ToString(), "TV_DTHU");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(xuatkhau, itemGH.RowId.ToString(), "TV_XK");
                    Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(quymonhamay, itemGH.RowId.ToString(), "TV_QUYMONM");
                    break;
                    #endregion
                case "EmailMember":
                    sb.Append(JavaScriptConvert.SerializeObject(MemberDal.SelectByUser(Security.Username)));
                    break;
                case "getPid":
                    #region get Setautocomplete gian hang
                    GianHang _GHItem = new GianHang();
                    _GHItem.ID = 0;
                    _GHItem.Ten = "Chọn";
                    GianHangCollection ListGetPid = new GianHangCollection();
                    ListGetPid = GianHangDal.SelectTree(_q);
                    ListGetPid.Insert(0, _GHItem);
                    sb.Append(JavaScriptConvert.SerializeObject(ListGetPid));
                    break;
                    #endregion
                case "lienHeDN":
                    #region lienheDN
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thông báo từ chonongnghiep.com")
                            , string.Format(NoiDungLienHeDN
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , msgDN
                                            , lienhe.ToString()
                                            )
                            , null, null);
                    }
                    break;
                    #endregion
                case "xacnhan":
                    #region
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.Xacnhan(_GH_ID, "1", "1");
                    }
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thống báo từ chonongnghiep.com")
                            , string.Format(inviMailBody
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , string.Format("được xác nhận")
                                            , DateTime.Now
                                            , lienhe.ToString()
                                            )
                            , null, null);
                    }
                    break;
                    #endregion              
                case "Active": 
                    #region
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.DungGH(_GH_ID, "0", DateTime.Now.ToString());
                    }
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += "  - " + lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thống báo từ chonongnghiep.com")
                            , string.Format(inviMailBody
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , string.Format("bị khóa")
                                            , DateTime.Now
                                            , lienhe.ToString()
                                           )
                            , null, null);
                    }

                    break;
                    #endregion
                case "ActiveTVBK": 
                    #region
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.DungGH(_GH_ID, "1", DateTime.Now.ToString());
                    }
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += "  - " + lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thống báo từ chonongnghiep.com")
                            , string.Format(inviMailBody
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , string.Format("được kích hoạt")
                                            , DateTime.Now
                                            , lienhe.ToString()
                                           )
                            , null, null);
                    }

                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_GH_ID))
                    {
                        GianHangDal.DeleteByIdList(_GH_ID);
                    }
                    foreach (LienHe lh in LienHeDal.SelectByActive(true))
                    {
                        lienhe += lh.Ten.ToString() + ", Điện thoại: " + lh.Mobile + ", Email: " + lh.Email + "<br/>";
                    }
                    foreach (GianHang item in GianHangDal.SelectByListId(_GH_ID))
                    {
                        _dele.BeginInvoke(item.Email
                            , string.Format("Thống báo từ chonongnghiep.com")
                            , string.Format(inviMailBody
                                            , item.Ten
                                            , item.DiaChi
                                            , item.Email
                                            , string.Format("bị xóa")
                                            , DateTime.Now
                                            , lienhe.ToString()
                                            )
                            , null, null);
                    }
                    break;
                    #endregion
                case "getChungChi":
                    #region get chung chi
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "CC_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    Pager<ChungChi> PagerGetCC = ChungChiDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, Request["rows"], _cc_gh_id);
                    List<jgridRow> ListRowCC = new List<jgridRow>();
                    foreach (ChungChi cc in PagerGetCC.List)
                    {
                        ListRowCC.Add(new jgridRow(cc.ID.ToString(),
                            new string[] { 
                                cc.ID.ToString(),
                                cc.TT.ToString(),
                                string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(cc.Anh,"50x50")),
                                cc.Ten.ToString(),
                                cc.So,
                                cc.GioiHan,
                                cc.DonViCap,
                                cc.NgayCap.ToString("dd/MM/yyyy"),
                                cc.Active.ToString()                                                              
                                 }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGetCC.TotalPages.ToString(), PagerGetCC.Total.ToString(), ListRowCC);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "editChungChi":
                    #region Edit chứng chỉ
                    if (!string.IsNullOrEmpty(_cc_id))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(ChungChiDal.SelectById(Convert.ToInt32(_cc_id))) + ")");
                    }
                    break;
                    #endregion
                case "delChungChi":
                    #region xóa
                    if (!string.IsNullOrEmpty(_cc_id))
                    {
                        ChungChiDal.DeleteByIdList(_cc_id);
                    }
                    break;
                    #endregion
                case "ActiveChungChi":
                    #region active Chứng chỉ
                    if (!string.IsNullOrEmpty(_cc_id))
                    {
                        ChungChiDal.ActiveCC(_cc_id, "1");
                    }
                    break;
                    #endregion
                case "saveChungChi":
                    #region luu chung chi
                    ChungChi ItemSave = new ChungChi();

                    if (string.IsNullOrEmpty(_cc_ten))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_cc_id))
                    {
                        ItemSave = ChungChiDal.SelectById(Convert.ToInt32(_cc_id));
                    }
                    ItemSave.TT = int.Parse(_cc_thutu);
                    ItemSave.GH_ID = int.Parse(_cc_gh_id);
                    ItemSave.Ten = _cc_ten;
                    ItemSave.So = _cc_so;
                    ItemSave.NgayCap = Convert.ToDateTime(_cc_ngaycap, new CultureInfo("vi-vn"));
                    ItemSave.GioiHan = _cc_gioihan;
                    ItemSave.DonViCap = _cc_donvicap;
                    ItemSave.Anh = _cc_anh;
                    ItemSave.Active = Convert.ToBoolean(_cc_active);

                    if (!string.IsNullOrEmpty(_cc_id))
                    {
                        ItemSave = ChungChiDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave = ChungChiDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getVideo":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgRows)) jgRows = "10";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TV_Thutu";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<Thuvien> PagerGet = ThuvienDal.pagerNormal("", false, jgrsidx + " " + jgrsord
                       , int.Parse(_rows)
                       , Request["q"]
                       , _CQ_ID
                       , 0
                       , _tv_nguoitao
                       , _tv_gh_id);
                    List<jgridRow> ListRowVideo = new List<jgridRow>();
                    foreach (Thuvien item in PagerGet.List)
                    {
                        ListRowVideo.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,(item.Thutu.ToString())
                            ,string.Format("<img class=\"adm-pro-icon\" src=\"../up/v/{0}\" />", string.IsNullOrEmpty(item.UrlImage) ? "no-image.png" :item.UrlImage) 
                            ,item.Ten                                      
                            ,item.Mota  
                            ,item.Ngaytao.ToString("dd/MM/yy")
                            ,item.NguoiTao
                            ,item.Active.ToString()
                                                   
                        }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRowVideo);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "saveVideo":
                    #region lưu dữ liệu
                    Thuvien ItemSaveVideo = new Thuvien();
                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        ItemSaveVideo = ThuvienDal.SelectById(Convert.ToInt32(_tv_id));
                    }

                    ItemSaveVideo.Ngaytao = DateTime.Now;
                    ItemSaveVideo.Ten = _tv_ten;
                    ItemSaveVideo.GH_ID = int.Parse(_tv_gh_id);
                    ItemSaveVideo.Mota = string.IsNullOrEmpty(_tv_mota) ? "" : _tv_mota;
                    ItemSaveVideo.Active = Convert.ToBoolean(_tv_active);
                    ItemSaveVideo.UrlImage = _tv_UrlImage;
                    ItemSaveVideo.Url = _tv_Url;
                    ItemSaveVideo.Thutu = Convert.ToInt16(_tv_thutu);
                    ItemSaveVideo.Loai = 1;
                    ItemSaveVideo.Keyword = "";
                    ItemSaveVideo.CateID = 0;
                    ItemSaveVideo.NguoiTao = Security.Username;

                    // ItemSave.PID = Convert.ToInt32(_PID);

                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        ItemSaveVideo = ThuvienDal.Update(ItemSaveVideo);
                    }
                    else
                    {
                        ItemSaveVideo.RowId = Guid.NewGuid();
                        ItemSaveVideo = ThuvienDal.Insert(ItemSaveVideo);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "delVideo":
                    #region xóa
                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _tv_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                Thuvien o = new Thuvien();
                                o = ThuvienDal.SelectById(Convert.ToInt32(arrID[j]));
                                try
                                {
                                    System.IO.File.Delete(Server.MapPath("~/up/v/" + o.UrlImage));
                                    System.IO.File.Delete(Server.MapPath("~/up/v/" + o.Url));
                                }
                                catch { }
                                ThuvienDal.DeleteById(Convert.ToInt32(arrID[j]));
                            }
                        }
                    }
                    break;
                    #endregion
                case "duyetVideo":
                    #region Duyệt
                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _tv_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                Thuvien o = new Thuvien();
                                o = ThuvienDal.SelectById(Convert.ToInt32(arrID[j]));
                                o.Active = true;
                                ThuvienDal.Update(o);
                            }
                        }
                    }
                    break;
                    #endregion
                case "dungVideo":
                    #region Dừng
                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _tv_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                Thuvien o = new Thuvien();
                                o = ThuvienDal.SelectById(Convert.ToInt32(arrID[j]));
                                o.Active = false;
                                ThuvienDal.Update(o);
                            }
                        }
                    }
                    break;
                    #endregion
                case "editVideo":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_tv_id))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(ThuvienDal.SelectById(Convert.ToInt32(_tv_id))) + ")");
                    }
                    break;
                    #endregion
                case "getFlash":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgRows)) jgRows = "5";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "Flh_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<Flash> PagerGetFlash = FlashDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _flh_gh_id, Request["rows"]);
                    List<jgridRow> ListRowFlash = new List<jgridRow>();
                    foreach (Flash item in PagerGetFlash.List)
                    {
                        if (item.PathImage != "")
                        {
                            ListRowFlash.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,(item.Thutu.ToString())
                            ,string.Format("<img class=\"adm-pro-icon\" src=\"../up/i/{0}\" />", string.IsNullOrEmpty(item.PathImage) ? "no-image.png" :item.PathImage)                              
                            ,item.Ten                                                                 
                            ,item.Ngaytao.ToString("dd/MM/yyyy")
                            ,item.NguoiTao
                            ,item.Active.ToString()                                                   
                            }));
                        }
                        else
                        {
                            ListRowFlash.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,(item.Thutu.ToString())
                            ,string.Format("<embed class=\"adm-pro-icon\" src=\"../up/v/{0}\" />", string.IsNullOrEmpty(item.PathFlash) ? "no-image.png" :item.PathFlash)                              
                            ,item.Ten                                                                 
                            ,item.Ngaytao.ToString("dd/MM/yyyy")
                            ,item.NguoiTao
                            ,item.Active.ToString()                                                   
                            }));
                        }
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGetFlash.TotalPages.ToString(), PagerGetFlash.Total.ToString(), ListRowFlash);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "saveFlash":
                    #region lưu dữ liệu
                    Flash ItemSaveFlash = new Flash();
                    if (!string.IsNullOrEmpty(_flh_id))
                    {
                        ItemSaveFlash = FlashDal.SelectById(Convert.ToInt32(_flh_id));
                    }

                    ItemSaveFlash.Ngaytao = DateTime.Now;
                    ItemSaveFlash.Ten = _flh_ten;
                    ItemSaveFlash.GH_ID = int.Parse(_flh_gh_id);
                    ItemSaveFlash.Mota = string.IsNullOrEmpty(_flh_mota) ? "" : _flh_mota;
                    ItemSaveFlash.Active = Convert.ToBoolean(_flh_active);
                    if (_flh_pathimg !=null) {
                        ItemSaveFlash.PathImage = _flh_pathimg;
                        ItemSaveFlash.PathFlash = "";
                    }
                    if (_flh_pathflash !=null)
                    {
                        ItemSaveFlash.PathImage = "";
                        ItemSaveFlash.PathFlash = _flh_pathflash;
                    }
                    ItemSaveFlash.Thutu = Convert.ToInt16(_flh_thutu);
                    ItemSaveFlash.NguoiTao = Security.Username;

                    // ItemSave.PID = Convert.ToInt32(_PID);

                    if (!string.IsNullOrEmpty(_flh_id))
                    {
                        ItemSaveFlash = FlashDal.Update(ItemSaveFlash);
                    }
                    else
                    {
                        ItemSaveFlash.RowId = Guid.NewGuid();
                        ItemSaveFlash = FlashDal.Insert(ItemSaveFlash);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "delFlash":
                    #region xóa
                    FlashDal.DeleteById(Convert.ToInt32(_flh_id));
                    break;
                    #endregion
                case "duyetFlash":
                    #region Duyệt

                    Flash duyetflash = new Flash();
                    duyetflash = FlashDal.SelectById(Convert.ToInt32(_flh_id));
                    duyetflash.Active = true;
                    FlashDal.Update(duyetflash);
                    break;
                    #endregion
                case "dungFlash":
                    #region Dừng

                    Flash dungflash = new Flash();
                    dungflash = FlashDal.SelectById(Convert.ToInt32(_flh_id));
                    dungflash.Active = false;
                    FlashDal.Update(dungflash);
                    break;
                    #endregion
                case "editFlash":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_flh_id))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(FlashDal.SelectById(Convert.ToInt32(_flh_id))) + ")");
                    }
                    break;
                    #endregion
                case "getHinhAnh":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgRows)) jgRows = "5";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "HA_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    Pager<HinhAnh> PagerGetHA = HinhAnhDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _ha_gh_id, Request["rows"]);
                    List<jgridRow> ListRowHA = new List<jgridRow>();
                    foreach (HinhAnh item in PagerGetHA.List)
                    {
                        ListRowHA.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()                            
                            ,string.Format("<img class=\"adm-pro-icon\" src=\"../up/i/{0}\" />", string.IsNullOrEmpty(item.PathImage) ? "no-image.png" :item.PathImage)                              
                            ,item.Ten  
                            ,item.Link                                   
                            ,item.Ngaytao.ToString("dd/MM/yyyy")
                            ,item.NguoiTao
                            ,item.Active.ToString()
                                                   
                        }));
                    }
                    grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGetHA.TotalPages.ToString(), PagerGetHA.Total.ToString(), ListRowHA);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "saveHinhAnh":
                    #region lưu dữ liệu
                    HinhAnh ItemSaveAnh = new HinhAnh();
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        ItemSaveAnh = HinhAnhDal.SelectById(Convert.ToInt32(_ha_id));
                    }
                    ItemSaveAnh.Ngaytao = DateTime.Now;
                    ItemSaveAnh.Ten = _ha_ten;
                    ItemSaveAnh.GH_ID = int.Parse(_ha_gh_id);
                    ItemSaveAnh.Mota = string.IsNullOrEmpty(_ha_mota) ? "" : _ha_mota;
                    ItemSaveAnh.Active = Convert.ToBoolean(_ha_active);
                    ItemSaveAnh.PathImage = _ha_pathimg;
                    ItemSaveAnh.Link = _ha_link;
                    ItemSaveAnh.NguoiTao = Security.Username;
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        ItemSaveAnh = HinhAnhDal.Update(ItemSaveAnh);
                    }
                    else
                    {
                        ItemSaveAnh.RowId = Guid.NewGuid();
                        ItemSaveAnh = HinhAnhDal.Insert(ItemSaveAnh);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "editHinhAnh":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(HinhAnhDal.SelectById(Convert.ToInt32(_ha_id))) + ")");
                    }
                    break;
                    #endregion
                case "delHinhAnh":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _ha_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                HinhAnh o = new HinhAnh();
                                o = HinhAnhDal.SelectById(Convert.ToInt32(arrID[j]));
                                try
                                {
                                    System.IO.File.Delete(Server.MapPath("~/up/i/" + o.PathImage));
                                }
                                catch { }
                                HinhAnhDal.DeleteById(Convert.ToInt32(arrID[j]));
                            }
                        }
                    }
                    break;
                    #endregion
                case "duyetHinhAnh":
                    #region Duyệt
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _ha_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                HinhAnh o = new HinhAnh();
                                o = HinhAnhDal.SelectById(Convert.ToInt32(arrID[j]));
                                o.Active = true;
                                HinhAnhDal.Update(o);
                            }
                        }
                    }
                    break;
                    #endregion
                case "dungHinhAnh":
                    #region Dừng
                    if (!string.IsNullOrEmpty(_ha_id))
                    {
                        char[] step = { ',' };
                        string[] arrID = _ha_id.Split(step);
                        for (int j = 0; j < arrID.Length; j++)
                        {
                            if (arrID[j] != "")
                            {
                                HinhAnh o = new HinhAnh();
                                o = HinhAnhDal.SelectById(Convert.ToInt32(arrID[j]));
                                o.Active = false;
                                HinhAnhDal.Update(o);
                            }
                        }
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(doanhNghiep), "cnn.plugin.doanhNghiep.doanhNghiep.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Publish.js"));
                    break;
                    #endregion
          
                default:
                    #region Nap
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId); //Kiem tra quyen

                    sb.Append(@"<div id =""DoanhNghiepChuaDuyet-Main-NewDlg"">
                    </div>                     
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(doanhNghiep), "cnn.plugin.doanhNghiep.doanhNghiep.js")
                        , "{doanhNghiepFn.loadForm();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
