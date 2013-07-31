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
using System.IO;
[assembly: WebResource("cnn.plugin.thongTinDonVi.thongTinChung.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.thongTinDonVi.thongTinChung.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.thongTinDonVi.thongTinChung
{
    class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            DanhMucCollection DanhMucHotro = DanhMucDal.SelectLangBased("", "LIENHE");
            DanhMucCollection ListEmail = new DanhMucCollection();
            foreach (DanhMuc item in DanhMucHotro)
            {
                if (item.Ma == "LH_EMAIL")
                {
                    ListEmail.Add(item);
                }
            }

            if (ListEmail != null)
            {
                foreach (DanhMuc item in ListEmail)
                {
                    omail.Send(item.GiaTri, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com-ĐĂNG KÝ THÔNG TIN DOANH NGHIỆP", "123$5678");                    
                }
            } 
        }
        public const string NoiDungLienHe = @"
                <table cellspacing=""0"" cellpadding=""40"" border=""0"" width=""98%"">
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
                                CHỢ NÔNG NGHIỆP - LIÊN HỆ TỪ DOANH NGHIỆP
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
                                                    <strong><span style="" font-size: 15px"">Thông tin người liên hệ</span></strong>
                                                    <br/>
                                                </div>
                                                <div style=""margin-bottom: 15px;"">- Tên Doanh Nghiệp:<strong> {1}</strong></div>                                                   
                                                <div style=""margin-bottom: 15px;"">- Địa chỉ:<strong> {2}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Email: <strong>{3}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Điện thoại: <strong>{4}</strong></div>
                                             </td>
                                             <td style=""background-color: rgb(255, 248, 204); border: 1px solid rgb(255, 226, 34);color: rgb(51, 51, 51); padding: 10px; font-size: 12px;"">
                                                                <table  width=""100%"" cellspacing=""0"" cellpadding=""0"" align=""center"" style=""text-align: center;"">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <a target=""_blank"" href=""http://CHONONGNGHIEP.COM"" style=""font-size: 18px;text-decoration: none;"">Chợ nông nghiệp</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            
                                                                            <td style=""border: 1px solid rgb(59, 110, 34);"">
                                                                                <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style=""padding: 5px 15px; background-color: #FF9900; border-top: 1px solid #B2B2B2;"">
                                                                                               ĐĂNG KÝ THÔNG TIN DOANH NGHIỆP
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
                                        <tr>
                                            <td colspan=""2"">
                                                <div style=""margin-bottom: 15px;"">- Nội dung liên hệ: <br/><p>{5}</p></div>                                                                                 
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
    </tbody>
</table>";

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            #region tham số
            String socanbo = Request["SoCanBo"];   
            String quymonhamay = Request["QuyMoNhaMay"];
            String xuatkhau = Request["TyLeXuatKhau"];   
            String doanhthu = Request["DoanhThuHangNam"];            
            String solaodong = Request["SoLaoDong"];   
            String vonphapdinh = Request["VonPhapDinh"];
            String tinhid = Request["TenTinh"];   
            String namThanhLap = Request["NamThanhLap"];            
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
            String diachiDN = Request["DiaChiDN"];            
            String tenDN = Request["TenDN"];
            String dienthoaiDN = Request["DienThoaiDN"];
            String faxDN = Request["FaxDN"];
            String web = Request["Web"];
            String mota = Request["ChiTietCongTy"];   
            String logo = Request["AnhLogo"];
            String spdv= Request["SPDV"];
            String arrthitruong=Request["ThiTruong"];
            String arrchatluong = Request["ChatLuong"];
            String arrloaiDN = Request["LoaiDN"];
            ////    
            string msg = Request["NoiDungLienHe"];
            string msgtitle = Request["msgtitle"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
            string ldm_ma = Request["LDM_Ma"];
            #endregion


            switch (subAct)
            {
                case "lienHe":
                    Member memberinfo = MemberDal.SelectByUser(Security.Username);
                    #region lienhe
                    _dele.BeginInvoke(""
                        , string.Format(msgtitle)
                        , string.Format(NoiDungLienHe, memberinfo.Username, memberinfo.Ten, memberinfo.DiaChi, memberinfo.Email, memberinfo.Mobile, msg)
                        , null, null);
                    break;
                    #endregion
                case "LoadThongTin":
                #region load thong tin doanh nghiep( gian hang)
                    sb.Append("(" + JavaScriptConvert.SerializeObject(GianHangDal.SelectDmIdByGhUser(Security.Username)) + ")");
                    break;
                #endregion
                case "infoSave":
                    #region lưu dữ liệu thông tin doanh nghiệp                    
                    GianHang itemGH = new GianHang();
                    Relation itemRLT = new Relation();
                    LienHe itemLH = new LienHe();
                    Member itemMember = MemberDal.Select_InsertIntoLhByUser(Security.Username);
                    //update vào gian hàng
                    itemGH = GianHangDal.SelectByUserName(Security.Username);                    
                    //itemGH = GianHangDal.SelectByUserName("hiennguyen@yahoo.com");
                    itemGH.ID = itemGH.ID;
                    itemGH.Anh = logo;
                    itemGH.MoTa = mota;
                    if (itemGH.Website != "http://" || itemGH.Website!=null)
                    {
                        itemGH.Website = web;
                    }
                    itemGH.Ten = tenDN;
                    itemGH.DiaChi = diachiDN;
                    itemGH.NguoiDaiDien = nguoiDaiDien;
                    itemGH.TomTat = chinhanh;
                    itemGH.GioiThieu = diaChiNhaMay;
                    itemGH.Active = true;
                    itemGH.DamBao = false;
                    itemGH.DienThoai = dienthoaiDN;
                    itemGH.Fax = faxDN;
                    itemGH.NamThanhLap = int.Parse(namThanhLap);
                    itemGH.ActiveDate = DateTime.Now;
                    itemGH.NgayTao = DateTime.Now;
                    if (tinhid != null)
                    {
                        itemGH.TINH_ID = int.Parse(tinhid);
                    }
                    else
                    {
                        itemGH.TINH_ID = 0;
                    }
                    itemGH.LTV_ID = 11021;               
                    //itemGH.RowId = Guid.NewGuid();                                  
                    itemGH = GianHangDal.Update(itemGH);
                    //Save vào tblLienHe Người liên hệ
                    itemLH=LienHeDal.SelectByPId(itemMember.RowId.ToString());
                    if(gioiTinh=="Nam"){
                        itemLH.GioiTinh =true;
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
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrchatluong, itemGH.RowId.ToString(), "TV_ISO");
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrthitruong, itemGH.RowId.ToString(), "TV_TTRUONG");
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(arrloaiDN, itemGH.RowId.ToString(), "DN_LOAI");
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(vonphapdinh, itemGH.RowId.ToString(), "TV_VON");
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(spdv, itemGH.RowId.ToString(), "SP_NHOM");
                        Relation_danhMuc_GianHangDal.InsertArrDMByGianHang(tinhid, itemGH.RowId.ToString(), "KV_TINH");
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
                case "loadDM":
                    #region load hỗ trợ đăng ký doanh nghiệp
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectLangBasedByPID("", ldm_ma,"0")));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.thongTinDonVi.thongTinChung.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    sb.Append(@" <div id=""form-mdl""></div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.thongTinDonVi.thongTinChung.JScript1.js")
                        , "{thongTinDonViFn.loadForm();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);

        }
    }
}
