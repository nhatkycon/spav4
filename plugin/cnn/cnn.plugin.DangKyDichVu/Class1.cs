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
[assembly: WebResource("cnn.plugin.DangKyDichVu.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.DangKyDichVu
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
                    omail.Send(item.GiaTri, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com-ĐĂNG KÝ DỊCH VỤ THÀNH VIÊN", "123$5678");
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
                                                                                               ĐĂNG KÝ DỊCH VỤ THÀNH VIÊN
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
</table>
                                                ";

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            #region tham số
            string msg = Request["NoiDungLienHe"];
            string msgtitle = Request["msgtitle"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);

            string MaDanhMuc = Request["MaDanhMuc"];

            string _NgayKTDKVANG = Request["NgayKTDKVANG"];
            string _NgayKTDKBAC = Request["NgayKTDKBAC"];
            string _NgayKTDKDONG = Request["NgayKTDKDONG"];

            string _NgayDKVANG = Request["NgayDKVANG"];
            string _NgayDKBAC = Request["NgayDKBAC"];
            string _NgayDKDONG = Request["NgayDKDONG"];

            string _DKVang = Request["DKVang"];
            string _DKBac = Request["DKBac"];
            string _DKDong = Request["DKDong"];
            string _ID = Request["ID"];


            #endregion

            
            switch (subAct)
            {
                case "DKDVTHANHVIEN":
                    #region Cập nhật đăng ký dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DateTime dkktVang;
                        DateTime dkktBac;
                        DateTime dkktDong;


                        DateTime dkbdVang;
                        DateTime dkbdBac;
                        DateTime dkbdDong;
                        #region VIP
                        if (!string.IsNullOrEmpty(_NgayDKVANG))
                        {
                            dkbdVang = Convert.ToDateTime(_NgayDKVANG, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkbdVang = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayKTDKVANG))
                        {
                            dkktVang = Convert.ToDateTime(_NgayKTDKVANG, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkktVang = DateTime.MinValue;
                        }
                        #endregion
                        #region SUPER
                        if (!string.IsNullOrEmpty(_NgayDKBAC))
                        {
                            dkbdBac = Convert.ToDateTime(_NgayDKBAC, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdBac = DateTime.MinValue;
                        }

                        if (!string.IsNullOrEmpty(_NgayKTDKBAC))
                        {
                            dkktBac = Convert.ToDateTime(_NgayKTDKBAC, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkktBac = DateTime.MinValue;
                        }

                        #endregion
                        #region HOT
                        if (!string.IsNullOrEmpty(_NgayDKDONG))
                        {
                            dkbdDong = Convert.ToDateTime(_NgayDKDONG, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdDong = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayKTDKDONG))
                        {
                            dkktDong = Convert.ToDateTime(_NgayKTDKDONG, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkktDong = DateTime.MinValue;
                        }
                        #endregion

                        GianHangDal.UpdateDKDVTHANHVIEN(_ID, _DKVang, _DKBac, _DKDong, dkbdVang, dkktVang, dkbdBac, dkktBac, dkbdDong, dkktDong);
                        sb.Append("1");
                    }
                    break;
                    #endregion



                case "LoadHoTroDKDV":
                    #region load hỗ trợ đăng ký dịch vụ
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectLangBased("", MaDanhMuc)));
                    break;
                    #endregion
                case "lienHe":
                    Member memberinfo = MemberDal.SelectByUser(Security.Username);
                    #region lienhe
                    _dele.BeginInvoke(""
                        , string.Format(msgtitle)
                        , string.Format(NoiDungLienHe, memberinfo.Username, memberinfo.Ten, memberinfo.DiaChi, memberinfo.Email, memberinfo.Mobile, msg)
                        , null, null);
                    break;
                    #endregion
                //case "lienHe":
                //    //Member memberinfo = MemberDal.SelectByUser(Security.Username);
                //    GianHang gianhangitem = GianHangDal.SelectByUserCoQuan(Security.Username);
                //    #region lienhe
                //    _dele.BeginInvoke(""
                //        , string.Format(msgtitle)
                //        , string.Format(NoiDungLienHe, gianhangitem.Ten, gianhangitem.DiaChi, gianhangitem.Email, gianhangitem.DienThoai, msg)
                //        , null, null);
                //    break;
                //    #endregion
                case "get":
                    #region lấy dữ liệu gian hàng
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GianHangDal.SelectByUserCoQuan(Security.Username)));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    //if (!string.IsNullOrEmpty(_ID))
                    //{
                    //    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(RaoVatDal.SelectById(Convert.ToInt32(_ID))));
                    //}
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    sb.Append(@"
                        <div id=""DangKyDichVuThanhVienFnMdl-DKDVFnMdl-dlgNew"">
<div style=""display:none"">
        <input disabled=""disabled"" class=""admtxt-raovat ID"" />
    </div>
    <center>
        <div class=""thanhToan-box"">
        <div class=""thanhToan-header"">
            <div class=""ThongTin-RaoVat"">
                <div class=""ThongTin-RaoVat-left"">
                    <img class=""adm-upload-preview-img-60"" alt="""" src=""""/>
                    <br />
                    <a class=""img-muaban""></a>
                </div>
                <div class=""ThongTin-RaoVat-right-box"">
                    <table>
                            <tr class=""adm-header-rv"">
                                <td style=""width:120px;"">
                                    Tên đơn vị:
                                </td>
                                <td>
                                    <a class=""MaDonVi"" style=""font-size:16px;font-family: Arial,Tahoma; color: #E97D13;""></a>
                                </td>
                            </tr>
                            <tr class=""adm-header-rv"">
                                <td style=""width:120px;"">
                                    Địa chỉ:
                                </td>
                                <td>
                                    <a class=""DiaChi""></a>
                                </td>
                            </tr>
                            <tr class=""adm-header-rv"">
                                <td style=""width:120px;"">
                                    Email:
                                </td>
                                <td>
                                    <a class=""Email""></a>
                                </td>
                            </tr>
                            <tr class=""adm-header-rv"">
                                <td style=""width:120px;"">
                                    Mã tin:
                                </td>
                                <td>
                                    <a class=""MaDangKy""></a>
                                </td>
                            </tr>
                        </table>
                </div>
            </div>
            <div class=""DanhsachDichVuDaDK"" style=""text-align:center;clear:both;float:right; margin-right:15px;""></div>
        </div>
        <div class=""thanhToan-body"">
            <div class=""thanhToan-menu"">
                <a _ref=""thanhToan-content-box-1"" href=""javascript:;"" class=""thanhToan-menu-item"" style=""margin-top:20px;"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Giới thiệu
                    </span>
                </a>
                <a _ref=""thanhToan-content-box-2"" href=""javascript:;"" class=""thanhToan-menu-item"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Thành viên Vàng
                    </span>
                </a>
                <a _ref=""thanhToan-content-box-3"" href=""javascript:;"" class=""thanhToan-menu-item"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Thành viên Bạc
                    </span>
                </a>
                <a _ref=""thanhToan-content-box-4"" href=""javascript:;"" class=""thanhToan-menu-item"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Thành viên Đồng
                    </span>
                </a>
                <a _ref=""thanhToan-content-box-5"" href=""javascript:;"" class=""thanhToan-menu-item"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Thanh toán
                    </span>
                </a>
                <a _ref=""thanhToan-content-box-6"" href=""javascript:;"" class=""thanhToan-menu-item"">
                    <span class=""thanhToan-menu-item-icon"">
                    </span>
                    <span class=""thanhToan-menu-item-ten"">
                    Liên hệ
                    </span>
                </a>
                <div class=""thanhToan-helpBox HoTro-DanhMuc"">
                </div>
            </div>
            <div class=""thanhToan-content"">
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-1"">
                    <div class=""thanhToan-content-box-ten"">
                        GIỚI THIỆU
                    </div>
                    <div class=""thanhToan-content-box-chiTiet GioiThieu-DanhMuc"">
                    </div>
                </div>
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-2"">
                    <div class=""thanhToan-content-box-ten"">
                        THÀNH VIÊN VÀNG
                    </div>
                    <div class=""thanhToan-content-box-moTa GioThieu-ThanhVien-Vang"">
                    </div>
                    <div class=""thanhToan-content-box-chiTiet"">
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   1. Phí dịch vụ: </span><span  class=""thanhToan-content-box-chiTiet-gia Gia-ThanhVien-Vang""></span> <span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ/Tuần</span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   2. Thời gian đăng ký: Từ ngày: </span><input   class=""admtxt-80 thanhToan-content-box-chiTiet-tuNgay NgayBD-DK-TV-Vang""/><button class=""admfilter-btn admfilter-btnDate""></button> đến ngày <input   class=""admtxt-80 thanhToan-content-box-chiTiet-denNgay NgayKT-DK-TV-Vang""/><button class=""admfilter-btn admfilter-btnDate""></button><span class=""SoNgay-DKTV-Vang"" style=""font-style:italic;""></span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   3. Tổng số tiền phải thanh toán:  </span> <span  class=""thanhToan-content-box-chiTiet-Tong TongTien-DKTV-Vang""></span><span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ</span>.
                        </p>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan"" style=""color:Red;"">Thanh toán</div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">1</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Thanh toán qua ATM: </span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-moTa"">(Nếu bạn có thẻ ATM)</span>
                        <a title=""Click để thanh toán Thanh toán qua ATM:"" href=""javascript:;"" class=""thanhToan-content-box-thanhToan-atmBtn"" style=""margin-left:10px;color:Red;"">Thanh toán</a>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">2</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Chuyển khoản qua Ngân hàng: </span>
                       
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-box ChuyenKhoan-DanhMuc"">
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"" style=""margin-right:20px;"">
                        <a class=""mdl-head-btn mdl-head-DKVang"" href=""javascript:"" onclick=""DangKyDichVuThanhVienFn.saveDKTVVANG();"" style=""float:right;"">Đăng ký</a>   
                    </div>
                </div>
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-3"">
                    <div class=""thanhToan-content-box-ten"">
                        THÀNH VIÊN BẠC
                    </div>
                    <div class=""thanhToan-content-box-moTa GioThieu-ThanhVien-Bac"">
                    </div>
                    <div class=""thanhToan-content-box-chiTiet"">
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   1. Phí dịch vụ: </span><span  class=""thanhToan-content-box-chiTiet-gia Gia-ThanhVien-Bac""></span> <span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ/Tuần</span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   2. Thời gian đăng ký: Từ ngày: </span><input   class=""admtxt-80 thanhToan-content-box-chiTiet-tuNgay NgayBD-DK-TV-Bac""/><button class=""admfilter-btn admfilter-btnDate""></button> đến ngày <input   class=""admtxt-80 thanhToan-content-box-chiTiet-denNgay NgayKT-DK-TV-Bac""/><button class=""admfilter-btn admfilter-btnDate""></button><span class=""SoNgay-DKTV-Bac"" style=""font-style:italic;""></span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   3. Tổng số tiền phải thanh toán:  </span> <span  class=""thanhToan-content-box-chiTiet-Tong TongTien-DKTV-Bac""></span><span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ</span>.
                        </p>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan"" style=""color:Red;"">Thanh toán</div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">1</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Thanh toán qua ATM: </span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-moTa"">(Nếu bạn có thẻ ATM)</span>
                        <a title=""Click để thanh toán Thanh toán qua ATM:"" href=""javascript:;"" class=""thanhToan-content-box-thanhToan-atmBtn"" style=""margin-left:10px;color:Red;"">Thanh toán</a>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">2</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Chuyển khoản qua Ngân hàng: </span>
                       
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-box ChuyenKhoan-DanhMuc"">
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"" style=""margin-right:20px;"">
                        <a class=""mdl-head-btn mdl-head-DKBac"" href=""javascript:"" onclick=""DangKyDichVuThanhVienFn.saveDKTVBAC();"" style=""float:right;"">Đăng ký</a>   
                    </div>
                </div>
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-4"">
                    <div class=""thanhToan-content-box-ten"">
                        THÀNH VIÊN ĐỒNG
                    </div>
                    <div class=""thanhToan-content-box-moTa GioThieu-ThanhVien-Dong"">
                    </div>
                    <div class=""thanhToan-content-box-chiTiet"">
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   1. Phí dịch vụ: </span><span  class=""thanhToan-content-box-chiTiet-gia Gia-ThanhVien-Dong""></span> <span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ/Tuần</span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   2. Thời gian đăng ký: Từ ngày: </span><input   class=""admtxt-80 thanhToan-content-box-chiTiet-tuNgay NgayBD-DK-TV-Dong""/><button class=""admfilter-btn admfilter-btnDate""></button> đến ngày <input   class=""admtxt-80 thanhToan-content-box-chiTiet-denNgay NgayKT-DK-TV-Dong""/><button class=""admfilter-btn admfilter-btnDate""></button><span class=""SoNgay-DKTV-Dong"" style=""font-style:italic;""></span>
                        </p>
                        <p>
                        <span  class=""thanhToan-content-box-chiTiet-tieuDe"">   3. Tổng số tiền phải thanh toán:  </span> <span  class=""thanhToan-content-box-chiTiet-Tong TongTien-DKTV-Dong""></span><span  class=""thanhToan-content-box-chiTiet-tienTe"">vnđ</span>.
                        </p>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan"" style=""color:Red;"">Thanh toán</div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">1</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Thanh toán qua ATM: </span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-moTa"">(Nếu bạn có thẻ ATM)</span>
                        <a title=""Click để thanh toán Thanh toán qua ATM:"" href=""javascript:;"" class=""thanhToan-content-box-thanhToan-atmBtn"" style=""margin-left:10px;color:Red;"">Thanh toán</a>
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"">
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-icon"">2</span>
                        <span class=""thanhToan-content-box-thanhToan-tieuDe-ten"">Chuyển khoản qua Ngân hàng: </span>
                       
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-box ChuyenKhoan-DanhMuc"">
                    </div>
                    <div class=""thanhToan-content-box-thanhToan-tieuDe"" style=""margin-right:20px;"">
                        <a class=""mdl-head-btn mdl-head-DKDong"" href=""javascript:"" onclick=""DangKyDichVuThanhVienFn.saveDKTVDONG();"" style=""float:right;"">Đăng ký</a>   
                    </div>
                </div>
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-5"">
                    <div class=""thanhToan-content-box-ten"">
                        THANH TOÁN
                    </div>
                    <div class=""thanhToan-content-box-chiTiet ThanhToan-DanhMuc"">
                    </div>
                </div>
                <div class=""thanhToan-content-box"" _ref=""thanhToan-content-box-6"">
                    <div class=""thanhToan-content-box-ten"">
                    LIÊN HỆ
                    </div>
                    
                    <table width=""100%;"" style=""margin-top:10px;"">
                        <tr>
                            <td style=""width:60px""></td>
                            <td colspan=""2"">
                                <div class=""thanhToan-content-box-chiTiet LienHe-DanhMuc"">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style=""width:60px""></td>
                            <td colspan=""2"">Gửi Email đến ban quản trị Chonongnghiep.com</td>
                        </tr>
                        <tr>
                            <td style=""width:60px"">
                                Tiêu đề:
                            </td>
                            <td valign=""top"">
                                <input type=""text"" class=""txtTieuDeLienHe"" style=""width: 525px;"" />
                            </td>
                        </tr>
                        <tr>
                            <td style=""width:60px;vertical-align:top;"">
                                Nội dung: 
                            </td>
                            <td valign=""top"">
                                <textarea class=""txtNoiDungLienHe"" style=""width: 525px; height: 125px;""></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td style=""width:60px""></td>
                            <td>
                                <a class=""mdl-head-btn mdl-head-lienHe"" href=""javascript:"" onclick=""DangKyDichVuThanhVienFn.sendLienHe();"">Liên hệ</a>
                            </td>
                        </tr> 
                    </table>
                    
                </div>
            </div>
        </div>
        <div>
            <span class=""admMsg""></span>
        </div>
    </div>
    </center>
</div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.JScript1.js")
                        , "{DangKyDichVuThanhVienFn.loadForm();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);

        }
    }
}
