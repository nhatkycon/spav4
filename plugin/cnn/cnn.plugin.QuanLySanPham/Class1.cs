using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using cnn.entities;
using System.Globalization;
using System.IO;

[assembly: WebResource("cnn.plugin.QuanLySanPham.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.DangKySanPhamDacTrung.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.DangKySanPhamMenu.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.DuyetSPDT.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.QuanLySanPham.Publish.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.QuanLySanPham
{
    
    public class Class1 : docPlugUI
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
                    omail.Send(item.GiaTri, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com-ĐĂNG KÝ SẢN PHẨM ĐẶC TRƯNG", "123$5678");
                }
            }


        }
        #region Noi dung liên hệ
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
                                                                                               ĐĂNG KÝ SẢN PHẨM ĐẶC TRƯNG
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
        #endregion
        

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string msg = Request["NoiDungLienHe"];
            string msgtitle = Request["msgtitle"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);

            string MaDanhMuc = Request["MaDanhMuc"];
            string _NgayDKSPDT = Request["NgayDKSPDT"];
            string _NgayKTDKSPDT = Request["NgayKTDKSPDT"];
            string _NgayDKSPMN = Request["NgayDKSPMN"];
            string _NgayKTDKSPMN = Request["NgayKTDKSPMN"];

            string _F_ID = Request["F_ID"];
            string _PRowIdSP = Request["PRowIdSP"];

            string _ID = Request["ID"];
            string _LangBased = Request["LangBased"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _DM_ID = Request["DM_ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _Alias = Request["Alias"];
            string _Lang = Request["Lang"];
            string _XuatXu_ID = Request["XuatXu_ID"];
            string _DonVi_ID = Request["DonVi_ID"];
            string _SoLuong = Request["SoLuong"];
            string _GNY = Request["GNY"];
            string _GiaNhap = Request["GiaNhap"];
            string _KeyWords = Request["KeyWords"];
            string _Description = Request["Description"];
            string _MoTa = Request["MoTa"];
            string _Anh = Request["Anh"];
            string _NoiDung = Request["NoiDung"];
            string _Active = Request["Active"];
            string _Publish = Request["Publish"];
            string _Hot = Request["Hot"];
            string _Hot1 = Request["Hot1"];
            string _Hot2 = Request["Hot2"];
            string _Hot3 = Request["Hot3"];
            string _Hot4 = Request["Hot4"];
            string _q = Request["q"];
            string _dm = Request["dm"];
            string _ghid = Request["GH_ID"];
            SanPham Item;
            DiaChiBanGiong ItemDCBG;
            List<SanPham> List = new List<SanPham>();
            List<jgridRow> ListRow = new List<jgridRow>();

            //List<DanhMuc> ListDanhMucBG = new List<DanhMuc>();
            #endregion
            switch (subAct)
            {
                case"ChuyenThanhTinBanGiong":
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                    //string[] ArrID = _ID.Split(',');
                    string[] ArrID = _ID.Split(delimiterChars);
                    foreach (string ID in ArrID)
	                {
                        if (!string.IsNullOrEmpty(ID)) {
                            Item = SanPhamDal.SelectById(int.Parse(ID));
                            if (Item.Home == false)
                            {
                                Member Itemmem = MemberDal.SelectByUser(Item.NguoiTao);
                                DanhMuc ItemDM = DanhMucDal.SelectById(Item.DM_ID);
                                DanhMucCollection ListDMBG = DanhMucDal.SelectLangBased("", "BANGIONG");
                                if (!string.IsNullOrEmpty(ItemDM.KeyWords))
                                {
                                    foreach (DanhMuc itemDMBG in ListDMBG)
                                    {
                                        if (ItemDM.KeyWords == itemDMBG.Ma)
                                        {
                                            ItemDCBG = new DiaChiBanGiong();

                                            ItemDCBG.DM_ID = itemDMBG.ID;
                                            ItemDCBG.Ten = Item.Ten;
                                            if (!string.IsNullOrEmpty(_DonVi_ID))
                                            {
                                                ItemDCBG.DonViTinh = Item.DonVi_ID;
                                            }
                                            ItemDCBG.Anh = Item.Anh;
                                            ItemDCBG.NoiDung = Item.NoiDung;
                                            ItemDCBG.Mota = Item.MoTa;
                                            ItemDCBG.NgayTao = DateTime.Now;
                                            ItemDCBG.NoiDang = "Toàn Quốc";
                                            if (!string.IsNullOrEmpty(_GNY))
                                            {
                                                ItemDCBG.Gia = Item.GNY;
                                            }
                                            ItemDCBG.DiaChi = Itemmem.DiaChi;
                                            ItemDCBG.DienThoai = Itemmem.Mobile + " " + Itemmem.Phone;
                                            ItemDCBG.NguoiTao = Item.NguoiTao;
                                            ItemDCBG.RowId = Guid.NewGuid();
                                            ItemDCBG.PRowId = Item.RowId;
                                            ItemDCBG.Type = true;// tin bán giống lấy từ mục sản phẩm
                                            ItemDCBG.NguoiLienHe = Itemmem.Ten;
                                            ItemDCBG.Email = Itemmem.Email;
                                            ItemDCBG = DiaChiBanGiongDal.Insert(ItemDCBG);
                                            Item.Home = true;
                                            SanPhamDal.Update(Item);
                                            
                                        }
                                    }
                                }
                            }
                        }
	                }
                    sb.Append("1");
                    break;
                case "UserGianHangAutoComplete":
                    #region cungDonVi : Lấy thành viên cùng đơn vị
                    sb.Append(JavaScriptConvert.SerializeObject(MemberDal.SelectGianHangUsername()));
                    break;
                    #endregion
                case "SaveDKDV":
                    #region Cập nhật đăng ký dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        #region Đăng ký sản phẩm đặc trưng
                         Item= new SanPham();
                         Item.ID = int.Parse(_ID);
                         if (!string.IsNullOrEmpty(_NgayDKSPDT))
                         {
                             Item.NgayBD_DK_SPDT = Convert.ToDateTime(_NgayDKSPDT, new CultureInfo("vi-vn"));
                         }
                         else
                         {
                             Item.NgayBD_DK_SPDT = DateTime.MinValue;
                         }
                         if (!string.IsNullOrEmpty(_NgayKTDKSPDT))
                         {
                             Item.NgayKT_DK_SPDT = Convert.ToDateTime(_NgayKTDKSPDT, new CultureInfo("vi-vn"));
                         }
                         else
                         {
                             Item.NgayKT_DK_SPDT = DateTime.MinValue;
                         }
                         if (!string.IsNullOrEmpty(_NgayDKSPMN))
                         {
                             Item.NgayBD_DK_SPMenu = Convert.ToDateTime(_NgayDKSPMN, new CultureInfo("vi-vn"));
                         }
                         else
                         {
                             Item.NgayBD_DK_SPMenu = DateTime.MinValue;
                         }
                         if (!string.IsNullOrEmpty(_NgayKTDKSPMN))
                         {
                             Item.NgayKT_DK_SPMenu = Convert.ToDateTime(_NgayKTDKSPMN, new CultureInfo("vi-vn"));
                         }
                         else
                         {
                             Item.NgayKT_DK_SPMenu = DateTime.MinValue;
                         }
                        //if (!string.IsNullOrEmpty(_Hot1))
                        //{
                        //    Item.Hot1 = Convert.ToBoolean(_Hot1);
                        //}
                        ////if (!string.IsNullOrEmpty(_Hot2))
                        ////{
                        ////    Item.Hot2 = Convert.ToBoolean(_Hot2);
                        ////} 
                        //if (!string.IsNullOrEmpty(_Hot3))
                        //{
                        //    Item.Hot3 = Convert.ToBoolean(_Hot3);
                        //} 
                        ////if (!string.IsNullOrEmpty(_Hot4))
                        ////{
                        ////    Item.Hot4 = Convert.ToBoolean(_Hot4);
                        ////}
                        #endregion
                        SanPhamDal.UpdateDKDV(Item,_Hot1,_Hot2,_Hot3,_Hot4);
                        sb.Append("1");
                    }
                    break;
                    #endregion

                case "DKSPMenu":
                    #region Cập nhật đăng ký dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DateTime dkspdt;
                        DateTime ktdkspdt;

                        #region Đăng ký sản phẩm đặc trưng
                        if (!string.IsNullOrEmpty(_NgayDKSPDT))
                        {
                            dkspdt = Convert.ToDateTime(_NgayDKSPDT, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkspdt = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayKTDKSPDT))
                        {
                            ktdkspdt = Convert.ToDateTime(_NgayKTDKSPDT, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            ktdkspdt = DateTime.MinValue;
                        }
                        #endregion

                        SanPhamDal.UpdateDKSPMenu(_ID, _Hot2, dkspdt, ktdkspdt);
                        sb.Append("1");
                    }
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
                case "LoadHoTroDKDV":
                    #region load hỗ trợ đăng ký dịch vụ
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectLangBased("", MaDanhMuc)));
                    break;
                    #endregion
                case "SelectTreeParentByDmId":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SanPhamDal.SelectTreeParentByDmId(Convert.ToInt32(_DM_ID))));
                    }
                    break;
                    #endregion
                case "DKSPDT":
                    #region Cập nhật đăng ký dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DateTime dkspdt;
                        DateTime ktdkspdt;

                        #region Đăng ký sản phẩm đặc trưng
                        if (!string.IsNullOrEmpty(_NgayDKSPDT))
                        {
                            dkspdt = Convert.ToDateTime(_NgayDKSPDT, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkspdt = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayKTDKSPDT))
                        {
                            ktdkspdt = Convert.ToDateTime(_NgayKTDKSPDT, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            ktdkspdt = DateTime.MinValue;
                        }
                        #endregion

                        SanPhamDal.UpdateDKSPDacTrung(_ID, _Hot1, dkspdt, ktdkspdt);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "getDSSPAdm":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetAdm = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "True", "", "False", 0, _dm, _ghid);
                    int countAdm = 0;
                    foreach (SanPham item in PagerGetAdm.List)
                    {
                        countAdm++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countAdm.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Description
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.GH_Ten
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetAdm.TotalPages.ToString()
                        , PagerGetAdm.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "getDSSPDungAdm":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetDungAdm = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "False", "", "False", 0,_dm,_ghid);
                    int countDungAdm = 0;
                    foreach (SanPham item in PagerGetDungAdm.List)
                    {
                        countDungAdm++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countDungAdm.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Description
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.GH_Ten
                        }));
                    }
                    jgrid gridSPDungAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetDungAdm.TotalPages.ToString()
                        , PagerGetDungAdm.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDungAdm));
                    break;
                    #endregion
                case "get":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGet = SanPhamDal.pagerNormal("",false,"HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows),"",Security.Username,"False",0);
                    int count = 0;
                    foreach (SanPham item in PagerGet.List)
                    {
                        count++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,count.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Description
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                        }));
                    }
                    jgrid gridSPAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGet.TotalPages.ToString()
                        , PagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPAdm));
                    break;
                    #endregion
                case "getDanhSachSanPham":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetDanhSachSanPham = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows),"",Security.Username,"True",0);
                    int countDanhSachSanPham = 0;
                    foreach (SanPham item in PagerGetDanhSachSanPham.List)
                    {
                        countDanhSachSanPham++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countDanhSachSanPham.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Description
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                        }));
                    }
                    jgrid DanhSachSanPham = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetDanhSachSanPham.TotalPages.ToString()
                        , PagerGetDanhSachSanPham.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(DanhSachSanPham));
                    break;
                    #endregion
                case "getSPDT":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPDT = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows),"",Security.Username,"",1);
                    int countSPDT = 0;
                    foreach (SanPham item in PagerGetSPDT.List)
                    {
                        countSPDT++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPDT.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.Hot1 == true ?item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy") : "Không đăng ký"
                        }));
                    }
                    jgrid gridSPDT = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPDT.TotalPages.ToString()
                        , PagerGetSPDT.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDT));
                    break;
                    #endregion
                case "getSPDTDaDuyet":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPDTDaDuyet = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "", Security.Username, "", 3);
                    int countSPDTDaDuyet = 0;
                    foreach (SanPham item in PagerGetSPDTDaDuyet.List)
                    {
                        countSPDTDaDuyet++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPDTDaDuyet.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.Hot3 == true ?item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy") : "Không đăng ký"
                        }));
                    }
                    jgrid gridSPDTDaDuyet = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPDTDaDuyet.TotalPages.ToString()
                        , PagerGetSPDTDaDuyet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDTDaDuyet));
                    break;
                    #endregion
                case "getSPDTAdm":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPDTAdm = SanPhamDal.pagerNormal("", false, "HH_NgayCapNhat DESC", _q, Convert.ToInt32(jgRows), "", "", "", 1,_dm,_ghid);
                    int countSPDTAdm = 0;
                    foreach (SanPham item in PagerGetSPDTAdm.List)
                    {
                        countSPDTAdm++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPDTAdm.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yyyy}",item.NgayCapNhat)
                            ,item.Hot1 == true ?item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy") : "Không đăng ký"
                            ,item.GH_Ten
                        }));
                    }
                    jgrid gridSPDTAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPDTAdm.TotalPages.ToString()
                        , PagerGetSPDTAdm.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDTAdm));
                    break;
                    #endregion
                case "getSPMenuAdm":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPMenuAdm = SanPhamDal.pagerNormal("", false, "HH_NgayCapNhat DESC", _q, Convert.ToInt32(jgRows), "", "", "", 2, _dm, _ghid);
                    int countSPMenuAdm = 0;
                    foreach (SanPham item in PagerGetSPMenuAdm.List)
                    {
                        countSPMenuAdm++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPMenuAdm.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yyyy}",item.NgayCapNhat)
                            ,item.Hot2 == true ?item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy") : "Không đăng ký"
                            ,item.GH_Ten
                        }));
                    }
                    jgrid gridSPMenuAdm = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPMenuAdm.TotalPages.ToString()
                        , PagerGetSPMenuAdm.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPMenuAdm));
                    break;
                    #endregion
                case "getSPDTAdmDuyet":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPDTAdmDuyet = SanPhamDal.pagerNormal("", false, "HH_NgayCapNhat DESC", _q, Convert.ToInt32(jgRows), "", "", "", 3,_dm,_ghid);
                    int countSPDTAdmDuyet = 0;
                    foreach (SanPham item in PagerGetSPDTAdmDuyet.List)
                    {
                        countSPDTAdmDuyet++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPDTAdmDuyet.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yyyy}",item.NgayCapNhat)
                            ,item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy")
                            ,item.GH_Ten
                        }));
                    }
                    jgrid gridSPDTAdmDuyet = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPDTAdmDuyet.TotalPages.ToString()
                        , PagerGetSPDTAdmDuyet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDTAdmDuyet));
                    break;
                    #endregion
                case "getSPMenuAdmDuyet":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPMenuAdmDuyet = SanPhamDal.pagerNormal("", false, "HH_NgayCapNhat DESC", _q, Convert.ToInt32(jgRows), "", "", "", 4, _dm, _ghid);
                    int countSPMenuAdmDuyet = 0;
                    foreach (SanPham item in PagerGetSPMenuAdmDuyet.List)
                    {
                        countSPMenuAdmDuyet++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPMenuAdmDuyet.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yyyy}",item.NgayCapNhat)
                            ,item.NgayBD_DK_SPDT.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPDT.ToString("dd/MM/yyyy")
                            ,item.GH_Ten
                        }));
                    }
                    jgrid gridSPMenuAdmDuyet = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPMenuAdmDuyet.TotalPages.ToString()
                        , PagerGetSPMenuAdmDuyet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPMenuAdmDuyet));
                    break;
                    #endregion
                case "getMenu":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPMenu = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "", Security.Username, "", 2);
                    int countSPMenu = 0;
                    foreach (SanPham item in PagerGetSPMenu.List)
                    {
                        countSPMenu++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPMenu.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.Hot2 == true ?item.NgayBD_DK_SPMenu.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPMenu.ToString("dd/MM/yyyy") : "Không đăng ký"
                        }));
                    }
                    jgrid gridSPMenu = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPMenu.TotalPages.ToString()
                        , PagerGetSPMenu.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPMenu));
                    break;
                    #endregion
                case "getMenuUserDaDuyet":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPMenuDaDuyet = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "", Security.Username, "", 4);
                    int countSPMenuDaDuyet = 0;
                    foreach (SanPham item in PagerGetSPMenuDaDuyet.List)
                    {
                        countSPMenuDaDuyet++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPMenuDaDuyet.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                            ,item.Hot4 == true ?item.NgayBD_DK_SPMenu.ToString("dd/MM/yyyy")+"-"+ item.NgayKT_DK_SPMenu.ToString("dd/MM/yyyy") : "Không đăng ký"
                        }));
                    }
                    jgrid gridSPMenuDaDuyet = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPMenuDaDuyet.TotalPages.ToString()
                        , PagerGetSPMenuDaDuyet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPMenuDaDuyet));
                    break;
                    #endregion
                case "getSPDung":
                    #region lấy dữ liệu cho grid
                    Pager<SanPham> PagerGetSPDung = SanPhamDal.pagerNormal("", false, "HH_" + jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows), "", Security.Username, "True", 0);
                    int countSPDung = 0;
                    foreach (SanPham item in PagerGetSPDung.List)
                    {
                        countSPDung++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                             
                            item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            ,countSPDung.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/sanpham/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Description
                            , string.Format("{0:dd/MM/yy}",item.NgayTao)
                        }));
                    }
                    jgrid gridSPDung = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGetSPDung.TotalPages.ToString()
                        , PagerGetSPDung.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(gridSPDung));
                    break;
                    #endregion//DangTinDungTin
                case "DangTin":
                    #region DangTinDungTin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPhamDal.DangSPDungSP(_ID,"False",null);
                    }
                    break;
                    #endregion
                case "DungTin":
                    #region DangTinDungTin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPhamDal.DangSPDungSP(_ID,"True",null);
                    }
                    break;
                    #endregion
                case "DangTinAdm":
                    #region DangTinDungTin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPhamDal.DangSPDungSP(_ID, null, "True");
                    }
                    break;
                    #endregion
                case "DungTinAdm":
                    #region DangTinDungTin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPhamDal.DangSPDungSP(_ID, null, "False");
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPhamDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SanPhamDal.SelectById(Convert.ToInt32(_ID))));

                    }
                    break;
                    #endregion
                case "editDetail":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SanPham itemSP = SanPhamDal.SelectById(Convert.ToInt32(_ID));
                        itemSP.ListFiles = FilesDal.SelectByPRowId(itemSP.RowId);
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemSP));
                    }
                    break;
                    #endregion
                case "LoadAttachImg":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SanPhamDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SanPhamDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new SanPham();
                    }
                    Item.LangBased = Convert.ToBoolean(_LangBased);
                    if (!string.IsNullOrEmpty(_LangBased_ID))
                    {
                        Item.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    Item.Ten = _Ten;
                    Item.Ma = _Ma;
                    Item.Alias = _Alias;
                    Item.Lang = _Lang;
                    if (!string.IsNullOrEmpty(_XuatXu_ID))
                    {
                        Item.XuatXu_ID = Convert.ToInt32(_XuatXu_ID);
                    }
                    if (!string.IsNullOrEmpty(_DonVi_ID))
                    {
                        Item.DonVi_ID = Convert.ToInt32(_DonVi_ID);
                    }
                    if (!string.IsNullOrEmpty(_SoLuong))
                    {
                        Item.GiaNhap = Convert.ToDouble(_GiaNhap);
                    }
                    Item.Keywords = _KeyWords;
                    Item.Description = _MoTa;
                    Item.Anh = _Anh;
                    Item.NoiDung = _NoiDung;
                    if (!string.IsNullOrEmpty(_SoLuong))
                    {
                        Item.SoLuong = double.Parse(_SoLuong);
                    }
                    
                    if (!string.IsNullOrEmpty(_GNY))
                    {
                        Item.GNY = double.Parse(_GNY);
                    }

                    
                    Item.Hot1 = Convert.ToBoolean(_Hot1);
                    Item.Hot2 = Convert.ToBoolean(_Hot2);
                    Item.Hot3 = Convert.ToBoolean(_Hot3);
                    Item.Hot4 = Convert.ToBoolean(_Hot4);
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiCapNhat = Security.Username;
                    if (!string.IsNullOrEmpty(_PRowIdSP))
                    {
                        Item.RowId = new Guid(_PRowIdSP);
                    }
                    else
                    {
                        Item.RowId = Guid.NewGuid();
                    }
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SanPhamDal.Update(Item);
                    }
                    else
                    {
                        Item.Publish = false;
                        Item.Active = true;
                        Item.NgayTao = DateTime.Now;
                        Item.Username = Security.Username;
                        Item.NguoiTao = Security.Username;
                        Item = SanPhamDal.Insert(Item);
                    }

                    Member Itemmember = MemberDal.SelectByUser(Security.Username);

                    if (string.IsNullOrEmpty(_ID))
                    {
                        if (!string.IsNullOrEmpty(_DM_ID))
                        {
                            DanhMuc ItemDanhMucSP = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
                            DanhMucCollection ListDanhMucBanGiong = DanhMucDal.SelectLangBased("", "BANGIONG");
                            foreach (DanhMuc item in ListDanhMucBanGiong)
                            {
                                if (item.Ma == ItemDanhMucSP.KeyWords)
                                {
                                    ItemDCBG = new DiaChiBanGiong();

                                    ItemDCBG.DM_ID = item.ID;
                                    ItemDCBG.Ten = _Ten;
                                    if (!string.IsNullOrEmpty(_DonVi_ID))
                                    {
                                        ItemDCBG.DonViTinh = Convert.ToInt32(_DonVi_ID);
                                    }
                                    ItemDCBG.Anh = _Anh;
                                    ItemDCBG.NoiDung = _NoiDung;
                                    ItemDCBG.Mota = _MoTa;
                                    ItemDCBG.NgayTao = DateTime.Now;
                                    ItemDCBG.NoiDang = "Toàn Quốc";
                                    if (!string.IsNullOrEmpty(_GNY))
                                    {
                                        ItemDCBG.Gia = double.Parse(_GNY);
                                    }
                                    ItemDCBG.DiaChi = Itemmember.DiaChi;
                                    ItemDCBG.DienThoai = Itemmember.Mobile + " " + Itemmember.Phone;
                                    ItemDCBG.NguoiTao = Security.Username;
                                    ItemDCBG.RowId = Guid.NewGuid();
                                    ItemDCBG.PRowId = Item.RowId;
                                    ItemDCBG.Type = true;// tin bán giống lấy từ mục sản phẩm
                                    ItemDCBG.NgayTao = DateTime.Now;
                                    ItemDCBG.NguoiTao = Security.Username;
                                    ItemDCBG.NguoiLienHe = Itemmember.Ten;
                                    ItemDCBG.Email = Itemmember.Email;
                                    ItemDCBG = DiaChiBanGiongDal.Insert(ItemDCBG);
                                }
                            }
                        }
                        
                        
                    }
                    //List<DanhMuc> ListDMBG= DanhMucDal.SelectLangBased(_ID, "BANGIONG");
                    //Item.DM_ID = Convert.ToInt32(_DM_ID);
                    //DanhMuc ItemDMSP = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
                    //if (ItemDMSP.Ma)



                    sb.Append("1");
                    break;
                    #endregion
                case "InsertDraff":
                    #region lưu
                    Draff itemdraff = new Draff();
                    itemdraff.RowId = Guid.NewGuid();
                    itemdraff = DraffDal.Insert(itemdraff);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(itemdraff));
                    //Item = new SanPham();
                    //Item.LangBased = Convert.ToBoolean(_LangBased);
                    //if (!string.IsNullOrEmpty(_LangBased_ID))
                    //{
                    //    Item.LangBased_ID = Convert.ToInt32(_LangBased_ID);
                    //}
                    //Item.Lang = _Lang;
                    //Item.NgayTao = DateTime.Now;
                    //Item.RowId = Guid.NewGuid();
                    //Item.NguoiTao = Security.Username;
                    //Item = SanPhamDal.InsertDraff(Item);
                    //sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(Item));
                    //sb.Append("1");
                    break;
                    #endregion
                case "saveDoc":
                    #region Lưu tài liệu
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        item.PID = new Guid(_ID);
                        item = FilesDal.Update(item);
                        sb.AppendFormat("1");
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_ID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_ID));
                        string _files = Server.MapPath("~/lib/up/sanpham/") + item.ThuMuc + @"\";
                        string _file1 = _files + @"\" + item.Ten + item.MimeType ;
                        string _file2 = _files + @"\" + item.Ten + "400x400" + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_file1);
                            File.Delete(_file2);
                            Directory.Delete(_files);
                        }
                        FilesDal.DeleteById(item.ID); 
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.JScript1.js"));
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Publish.js"));
                    break;
                    #endregion
                case "scpt1":
                    #region Nạp js
                    //sb.AppendFormat(@"{0}"
                    //    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.JScript1.js"));
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <link href=""../js/fancybox/jquery.fancybox-1.3.4.css"" rel=""stylesheet"" type=""text/css"" />
                        <div id=""QuanLySanPhamFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-QuanLySanPhamFn"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-add"" id=""QuanLySanPhamFnMdl-addBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.add();"">Thêm</a>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""QuanLySanPhamFnMdl-editBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.edit();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""QuanLySanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.del();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""QuanLySanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.DangKySanPhamDacTrung();"" >Đăng ký SP đặc trưng</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""QuanLySanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.DangKySanPhamMenu();"" >Đăng ký SP Menu</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""QuanLySanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.DungTin();"" >Dừng SP</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""QuanLySanPhamFnMdl-delBtn"" href=""javascript:"" onclick=""QuanLySanPhamFn.LamMoi();"" >Refresh</a>
                            </div>
                            <table id=""QuanLySanPhamFnMdl-List"" class=""mdl-list""></table>
                            <div id=""QuanLySanPhamFnMdl-Pager""></div>
                            <div id=""QuanLySanPhamFnMdl-HangHoatempMdl-dlgNew""></div>
                            <div id=""QuanLySanPhamFnMdl-HangHoatempMdl-DangKySanPhamDacTrung-dlgNew""></div>
                            <div id=""QuanLySanPhamFnMdl-HangHoatempMdl-DangKySanPhamMenu-dlgNew""></div>
                        </div>
                    ");
                    
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.QuanLySanPham.JScript1.js")
                        , "{QuanLySanPhamFn.NapPublishFn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }

    }
}


