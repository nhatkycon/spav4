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
[assembly: WebResource("cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.DangKySanPhamDacTrung.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace cnn.plugin.DangKyDichVu.DKSanPhamDacTrung
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
            #region Tham số
            string msg = Request["NoiDungLienHe"];
            string msgtitle = Request["msgtitle"];
            sendEmailDele _dele = new sendEmailDele(sendmailThongbao);

            string MaDanhMuc = Request["MaDanhMuc"];

            string _NgayDKSPDT = Request["NgayDKSPDT"];
            string _NgayKTDKSPDT = Request["NgayKTDKSPDT"];

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
            HangHoa Item;
            List<HangHoa> List = new List<HangHoa>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion

            switch (subAct)
            {

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

                        HangHoaDal.UpdateDKSPDacTrung(_ID, _Hot1, dkspdt, ktdkspdt);
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
                case "get":
                    #region lấy dữ liệu cho grid
                    Pager<HangHoa> PagerGet = HangHoaDal.pagerLangBased("HH_" + jgrsidx + " " + jgrsord, Convert.ToInt32(jgRows));
                    foreach (HangHoa item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                              item.ID.ToString()
                            , item.LangBased.ToString()
                            , item.Lang
                            , string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh,"50x50"))
                            
                            , item.Ma
                            , item.Ten
                            , item._DM_Ten
                            , string.Format("{0:dd/MM/yy}",item.NgayCapNhat)
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , List.Count.ToString()
                        , List.Count.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        HangHoaDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(HangHoaDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = HangHoaDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new HangHoa();
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
                    Item.Description = _Description;
                    Item.Anh = _Anh;
                    Item.NoiDung = _NoiDung;
                    Item.Active = Convert.ToBoolean(_Active);
                    Item.Publish = Convert.ToBoolean(_Publish);
                    Item.Hot1 = Convert.ToBoolean(_Hot1);
                    Item.Hot2 = Convert.ToBoolean(_Hot2);
                    Item.Hot3 = Convert.ToBoolean(_Hot3);
                    Item.Hot4 = Convert.ToBoolean(_Hot4);
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NguoiCapNhat = Security.Username;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = HangHoaDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item.NguoiTao = Security.Username;
                        Item = HangHoaDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "autoCompleteLangBased":
                    #region Lấy danh sách danh mục
                    //Item = new hangHoa();
                    //Item.ID = 0;
                    //Item.Ten = "Chọn";
                    //List = getTree(HangHoaDal.SelectLangBased(_ID));
                    //List.Insert(0, Item);
                    //sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "getByLangBasedId":
                    #region getByLangBasedId: Lấy danh sách các ngôn ngữ khác theo ngôn ngữ gốc

                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-HangHoaDKSanPhamDacTrungFn"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""HangHoaDKSanPhamDacTrungFnMdl-addBtn"" href=""javascript:"" onclick=""HangHoaDKSanPhamDacTrungFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""HangHoaDKSanPhamDacTrungFnMdl-editBtn"" href=""javascript:"" onclick=""HangHoaDKSanPhamDacTrungFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""HangHoaDKSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""HangHoaDKSanPhamDacTrungFn.del();"" >Xóa</a>
    
    <a class=""mdl-head-btn mdl-head-del"" id=""HangHoaDKSanPhamDacTrungFnMdl-delBtn"" href=""javascript:"" onclick=""HangHoaDKSanPhamDacTrungFn.DangKySanPhamDacTrung();"" >Đăng ký Sản phẩm đặc trưng</a>
</div>
<table id=""HangHoaDKSanPhamDacTrungFnMdl-List"" class=""mdl-list""></table>
<div id=""HangHoaDKSanPhamDacTrungFnMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DangKyDichVu.DKSanPhamDacTrung.JScript1.js")
                        , "{HangHoaDKSanPhamDacTrungFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }

    }
}


//<select class=""slt"" onchange=""HangHoaDKSanPhamDacTrungFn.search();"" id=""HangHoaDKSanPhamDacTrungFnMdl-changeLangSlt""></select>
//    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucHangHoaDKSanPhamDacTrungFn""/>
//    </span>