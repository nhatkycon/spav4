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
[assembly: WebResource("cnn.plugin.LienHeChung.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.LienHeChung.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.LienHeChung
{
    public class Class1 : docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);  
        void sendmailThongbao(string email, string tieude, string noidung)
        {
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com", "123$5678");
        }
    
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
                                &nbsp;LIÊN HỆ TỪ KHÁCH HÀNG CHONONGNGHIEP.COM
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
                                                     <strong><span style="" font-size: 15px"">{1}</span></strong></div>                                              
                                                <div style=""margin-bottom: 15px;"">- Địa chỉ:<strong> {2}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Email: <strong>{3}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Tên Người gửi: <strong>{4}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Email /Tài khoản Người gửi: <strong>{5}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Tiêu đề: <strong>{6}</strong></div>
                                                <div style=""margin-bottom: 15px;"">- Nội dung: <br><strong>{7}</strong></div>                                                                                 
                                               <div style=""margin-bottom: 15px;""><strong>
                                                    <br />
                                                     <div style=""margin-bottom: 15px;""><strong>
                                                        <em>Chúc Quý doanh nghiệp phát triển không ngừng!</em><br />                                                   
                                                    _____________________</em></strong></div>
                                                 <div style=""margin-bottom:20px; color:#0000FF; font-size: larger;""> Ban quản trị chonongnghiep.com</div>
                                                   <span style=""font-size: 12px;"">Để biết thêm chi tiết, xin liên hệ:<br />
                                                   </span></strong> <span style=""font-size: 12px;"">
                                                   <span style=""font-size: 12px; font-style: italic;"">{8}</span></div>
                                             </td>
                                             <td align=""left"" width=""200"" valign=""top"" style=""padding-left: 15px;"">
                                                <table cellspacing=""0"" cellpadding=""0"" width=""100%"" style=""height:100%"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""background-color: rgb(255, 248, 204); border: 1px solid rgb(255, 226, 34);
                                                                color: rgb(51, 51, 51); padding: 10px; font-size: 12px;"">
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
        protected override void Render(HtmlTextWriter writer) {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;            
            string msgtitle = Request["TieuDe"];
            string lienhe = "";
            string msgDN = Request["NoiDungLienHeDN"];
            string emailKhachHang = Request["EmailKH"];
            string tenKhachHang = Request["TenKH"];
            string ghid=Request["ID"]; 
            string email = Request["Email"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);            
            switch (subAct)
            {
                case "thongTinQT":
                    sb.Append("(" + JavaScriptConvert.SerializeObject(DanhMucDal.SelectByDM_Ma("LH_QT")) + ")");
                    break;
                case "lienHeDN":
                    foreach (DanhMuc lh in DanhMucDal.SelectByDM_Ma("LH_EMAIL"))
                    {
                        lienhe += lh.Ten.ToString() + ", Điện thoại: " + lh.KyHieu + ", Email: " + lh.GiaTri + "<br/>";
                    }

                    GianHang item = GianHangDal.SelectByGH_ID(ghid);                    
                        _dele.BeginInvoke(email
                            , string.Format("Thông báo từ chonongnghiep.com")
                            , string.Format(NoiDungLienHeDN
                                            , string.Format(item.LH_Ten)
                                            , item.Ten
                                            ,item.DiaChi
                                            , item.Email
                                            , tenKhachHang
                                            ,emailKhachHang
                                            ,msgtitle
                                            ,msgDN
                                            , lienhe.ToString()
                                            )
                            , null, null);                    
                    break;
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.LienHeChung.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.LienHeChung.JScript1.js")
                        , "{Lienhefn.LienHe();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
