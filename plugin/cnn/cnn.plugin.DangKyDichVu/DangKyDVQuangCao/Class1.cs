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
[assembly: WebResource("cnn.plugin.DangKyDichVu.DangKyDVQuangCao.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.DangKyDichVu.DangKyDVQuangCao.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.DangKyDichVu.DangKyDVQuangCao
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
                    omail.Send(item.GiaTri, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com-Dịch vụ quảng cáo", "123$5678");
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
            DanhMuc Item;
            List<DanhMuc> List = new List<DanhMuc>();
            #region tham số
            string msg = Request["NoiDungLienHe"];
            string msgtitle = Request["msgtitle"];
            string MaDanhMuc = Request["MaDanhMuc"];
            string _LDM_Ma = Request["LDM_Ma"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);

            string _ID = Request["ID"];
            string _Ten = Request["Ten"];
            string _Anh = Request["Anh"];
            string _Url = Request["Url"];
            string _ThuTu = Request["ThuTu"];
            string _ViTri = Request["ViTri"];
            string _ViTri_Ten = Request["ViTri_Ten"];
            string _TrangQuangCao = Request["TrangQuangCao"];
            string _TrangQuangCao_Ten = Request["TrangQuangCao_Ten"];
            string _Active = Request["Active"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _NgayDangKy = Request["NgayDangKy"];
            string _TenDonVi = Request["TenDonVi"];
            string _DiaChiDonVi = Request["DiaChiDonVi"];
            string _NguoiLienHe = Request["NguoiLienHe"];
            string _Email = Request["Email"];
            string _DienThoai = Request["DienThoai"];
            string _SoTienThanhToan = Request["SoTienThanhToan"];
            QuangCao ItemQC;
            #endregion
            //autoCompleteLangBasedDanhMuc
            switch (subAct)
            {
                case "SaveDKDVQC":
                #region Save Đăng ký dịch vụ quảng cáo
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemQC = QuangCaoDal.SelectByIdHoangDA(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        ItemQC = new QuangCao();
                    }
                    ItemQC.Ten = _Ten;
                    ItemQC.Anh = _Anh;
                    ItemQC.Url = _Url;
                    //ItemQC.ThuTu = int.Parse(_ThuTu);
                    ItemQC.ViTri = int.Parse(_ViTri);
                    ItemQC.ViTri_Ten = _ViTri_Ten;
                    ItemQC.TrangQuangCao = int.Parse(_TrangQuangCao);
                    ItemQC.TrangQuangCao_Ten = _TrangQuangCao_Ten;
                    ItemQC.Active = Convert.ToBoolean(_Active);

                    ItemQC.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-vn"));
                    ItemQC.NgayCapNhat = DateTime.Now;

                    ItemQC.NgayDangKy = Convert.ToDateTime(_NgayDangKy, new CultureInfo("vi-vn"));

                    ItemQC.TenDonVi = _TenDonVi;
                    ItemQC.DiaChiDonVi = _DiaChiDonVi;
                    ItemQC.NguoiLienHe = _NguoiLienHe;
                    ItemQC.Email = _Email;
                    ItemQC.DienThoai = _DienThoai;
                    ItemQC.SoTienThanhToan = Double.Parse(_SoTienThanhToan);
                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemQC = QuangCaoDal.UpdateHoangDA(ItemQC);
                    }
                    else
                    {
                        ItemQC.NgayTao = DateTime.Now;
                        ItemQC.RowId = Guid.NewGuid();
                        ItemQC.NguoiTao = Security.Username;
                        ItemQC = QuangCaoDal.InsertHoangDA(ItemQC);
                    }
                    sb.Append("1");

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
                case "autoCompleteLangBasedByDanhMucId":
                    #region Lấy danh sách danh mục
                    DanhMuc ItemDanhMuc = new DanhMuc();
                    List<DanhMuc> ListDanhMuc = new List<DanhMuc>();
                    ListDanhMuc = DanhMucDal.SelectLangBasedByDanhMucId(_ID);
                    sb.Append(JavaScriptConvert.SerializeObject(ListDanhMuc));
                    break;
                    #endregion
                case "autoCompleteLangBased":
                    #region Lấy danh sách danh mục
                    Item = new DanhMuc();
                    List = getTree(DanhMucDal.SelectLangBasedFixHoangda(_ID, _LDM_Ma));
                    sb.Append(JavaScriptConvert.SerializeObject(List));
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
                case "get":
                    #region lấy dữ liệu gian hàng
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(GianHangDal.SelectByUserCoQuan(Security.Username)));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DangKyDVQuangCao.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    sb.Append(@"
                        <div id=""DangKyDVQuangCaoFn-Main""></div>        
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DangKyDVQuangCao.JScript1.js")
                        , "{DangKyDVQuangCaoFn.LoadForm();}");
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
