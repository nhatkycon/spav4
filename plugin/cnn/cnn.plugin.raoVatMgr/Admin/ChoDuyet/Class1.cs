﻿using System;
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
[assembly: WebResource("cnn.plugin.raoVatMgr.Admin.ChoDuyet.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.raoVatMgr.Admin.ChoDuyet.htm.htm", "text/html")]
[assembly: WebResource("cnn.plugin.raoVatMgr.Admin.ChoDuyet.Dkdv.htm", "text/html")]
[assembly: WebResource("cnn.plugin.raoVatMgr.Admin.ChoDuyet.DuyetDKRVTP.htm", "text/html")]
namespace cnn.plugin.raoVatMgr.Admin.ChoDuyet
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
                    omail.Send(item.GiaTri, email, tieude, noidung, "giaoban.pmtl@gmail.com", "chonongnghiep.com-RaoVat", "123$5678");
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
                                CHỢ NÔNG NGHIỆP - LIÊN HỆ TỪ THÀNH VIÊN
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
                                                <div style=""margin-bottom: 15px;"">- Họ tên:<strong> {1}</strong></div>                                                   
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
                                                                                               --RAO VẶT--
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


            string _ID = Request["ID"];
            string _LangBased = Request["LangBased"];
            string _LangBased_ID = Request["LangBased_ID"];
            string _DM_ID = Request["dm"];
            string _TINH_ID = Request["dmkv"];
            string _TINH_Ten = Request["TINH_Ten"];
            string _NC_ID = Request["muaban"];
            string _Lang = Request["Lang"];
            string _Ten = Request["Ten"];
            string _NoiDung = Request["NoiDung"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _Anh1 = Request["Anh"];
            string _Gia = Request["Gia"];
            string _Active = Request["Active"];
            string _q = Request["q"];
            string _super = Request["_super"];
            string _vip = Request["_vip"];
            string _hot = Request["_hot"];
            string _user = Request["_user"];
            string _hethan = Request["_hethan"];
            string _Publish = Request["Publish"];
            string _DKhot = Request["DKhot"];
            string _DKsuper = Request["DKsuper"];
            string _DKvip = Request["DKvip"];
            string _trangthai = Request["trangthai"];
            string _NgayhethanSuper = Request["NgayHetHanSuper"];
            string _NgayhethanVip = Request["NgayHetHanVip"];
            string _NgayhethanHot = Request["NgayHetHanHot"];
            string _Mota = Request["Mota"];
            string _NgayDKSuper = Request["NgayDKSuper"];
            string _NgayDKVip = Request["NgayDKVip"];
            string _NgayDKHot = Request["NgayDKHot"];
            string MaDanhMuc = Request["MaDanhMuc"];
            RaoVat Item;
            List<RaoVat> List = new List<RaoVat>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion

            switch (subAct)
            {
                case "QuickSaveDichVu":
                    if (!string.IsNullOrEmpty(_ID)) {
                        if (Boolean.Parse(_vip))
                        {
                            RaoVat ItemRVQS = RaoVatDal.SelectById(int.Parse(_ID));
                            RaoVatDal.UpdateDuyetRVTraPhi(_ID, _vip, ItemRVQS.VIP_VIP_NgayBatDau, ItemRVQS.VIP_VIP_NgayHetHan);
                        }
                        else
                        {
                            RaoVatDal.UpdateDuyetRVTraPhi(_ID, _vip, DateTime.MinValue, DateTime.MinValue);
                        }
                    }
                    sb.Append("1");
                    break;
                case "DuyetDKDVRVTP":
                    #region Duyệt dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DateTime dkviptime;
                        DateTime dkbdviptime;
                        #region VIP
                        if (!string.IsNullOrEmpty(_NgayDKVip))
                        {
                            dkbdviptime = Convert.ToDateTime(_NgayDKVip, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkbdviptime = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayhethanVip))
                        {
                            dkviptime = Convert.ToDateTime(_NgayhethanVip, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkviptime = DateTime.MinValue;
                        }
                        #endregion
                        RaoVatDal.UpdateDuyetRVTraPhi(_ID, _vip, dkbdviptime, dkviptime);
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
                case "LoadThanhToanDanhMuc":
                    #region load hỗ trợ đăng ký dịch vụ
                    sb.Append(JavaScriptConvert.SerializeObject(DanhMucDal.SelectLangBased("", "THANHTOAN")));
                    break;
                    #endregion
                case "DKDV":
                    #region Cập nhật đăng ký dịch vụ
                    if (!string.IsNullOrEmpty(_ID))
                    {

                        DateTime dksupertime;
                        DateTime dkviptime;
                        DateTime dkhottime;
                        DateTime dkbdsupertime;
                        DateTime dkbdhottime;
                        DateTime dkbdviptime;
                        #region VIP
                        if (!string.IsNullOrEmpty(_NgayDKVip))
                        {
                            dkbdviptime = Convert.ToDateTime(_NgayDKVip, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkbdviptime = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayhethanVip))
                        {
                            dkviptime = Convert.ToDateTime(_NgayhethanVip, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkviptime = DateTime.MinValue;
                        }
                        #endregion
                        #region SUPER
                        if (!string.IsNullOrEmpty(_NgayDKSuper))
                        {
                            dkbdsupertime = Convert.ToDateTime(_NgayDKSuper, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdsupertime = DateTime.MinValue;
                        }

                        if (!string.IsNullOrEmpty(_NgayhethanSuper))
                        {
                            dksupertime = Convert.ToDateTime(_NgayhethanSuper, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dksupertime = DateTime.MinValue;
                        }

                        #endregion
                        #region HOT
                        if (!string.IsNullOrEmpty(_NgayDKHot))
                        {
                            dkbdhottime = Convert.ToDateTime(_NgayDKHot, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdhottime = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayhethanHot))
                        {
                            dkhottime = Convert.ToDateTime(_NgayhethanHot, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkhottime = DateTime.MinValue;
                        }
                        #endregion

                        RaoVatDal.UpdateDKDV(_ID, _DKsuper, _DKvip, _DKhot, dksupertime, dkviptime, dkhottime, dkbdsupertime, dkbdviptime, dkbdhottime);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "DangTinDungTin":
                    #region Đăng tin
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RaoVatDal.DangTinDungTin(_ID, _Publish);
                    }
                    break;
                    #endregion
                case "PheDuyet":
                    #region duyệt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RaoVatDal.DuyetList(_ID, _Active);
                    }
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        RaoVatDal.DeleteByIdList(_ID);
                    }
                    break;
                    #endregion
                case "get":
                    #region lấy dữ liệu cho grid

                    Pager<RaoVat> PagerGet = RaoVatDal.pagerNormalDKDVTIN("", false, jgrsidx + " " + jgrsord, _q, int.Parse(Request["rows"]), _trangthai);
                    int countrv = 0;
                    foreach (RaoVat item in PagerGet.List)
                    {
                        countrv++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,countrv.ToString()
                            ,string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh1,"50x50"))
                            ,item.Ten
                            ,item._DM_Ten
                            ,item._Nhucau_Ten
                            ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                            ,item.TuNgay.ToString("dd/MM/yyyy")
                            ,item.DenNgay.ToString("dd/MM/yyyy")
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage
                        , PagerGet.TotalPages.ToString()
                        , PagerGet.Total.ToString()
                        , ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(RaoVatDal.SelectById(Convert.ToInt32(_ID))));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = RaoVatDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new RaoVat();
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
                    if (!string.IsNullOrEmpty(_TINH_ID))
                    {
                        Item.TINH_ID = Convert.ToInt32(_TINH_ID);
                    }
                    if (!string.IsNullOrEmpty(_NC_ID))
                    {
                        Item.NC_ID = Convert.ToInt32(_NC_ID);
                    }
                    Item.Lang = _Lang;
                    Item.Ten = _Ten;
                    Item.Gia = _Gia;
                    Item.NoiDung = _NoiDung;
                    Item.MoTa = _Mota;
                    Item.Anh1 = _Anh1;
                    Item.NgayHetHan = Convert.ToDateTime(_NgayHetHan, new CultureInfo("vi-vn"));
                    Item.NgayCapNhat = DateTime.Now;
                    Item.Publish = Convert.ToBoolean(_Publish);
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = RaoVatDal.Update(Item);
                    }
                    else
                    {
                        Item.Active = true;
                        Item.NgayDang = DateTime.Now;
                        Item.TenNguoiDang = Security.Username;
                        Item = RaoVatDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.Admin.ChoDuyet.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                    <div id=""RaoVatAdminChoDuyetFnMdl-main"">   
                        <div id=""RaoVatAdminChoDuyetFnMdl-head"" class=""mdl-head"">
                            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-RaoVatAdminChoDuyet"" />
                            </span>
                            <a class=""mdl-head-btn mdl-head-edit"" id=""RaoVatAdminChoDuyetFnMdl-editBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.edit();"">Sửa</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""RaoVatAdminChoDuyetFnMdl-delBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.del();"" >Xóa</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""RaoVatAdminChoDuyetFnMdl-PheDuyetBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.DangTinDungTin('False');"" >Dừng</a>
                            <select class=""slt"" onchange=""RaoVatAdminChoDuyetFn.search();"" id=""RaoVatAdminChoDuyetFnMdl-changeLangSlt""></select>
                            <select class=""TrangThai"" onchange=""RaoVatAdminChoDuyetFn.search();"" id=""RaoVatAdminChoDuyetFnMdl-TrangThai""></select>
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterLoaiTinRaoVatAdminChoDuyet""/>
                            </span>    
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucRaoVatAdminChoDuyet""/>
                            </span>
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"" style=""display:none;"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterKhuVucRaoVatAdminChoDuyet""/>
                            </span>
                            <a class=""mdl-head-btn mdl-head-DKDV"" id=""RaoVatAdminChoDuyetFnMdl-DuyetDKDVBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.LoadFormDKDVTraPhi('#RaoVatAdminChoDuyetFnMdl-List');"" >Đăng ký tin dịch vụ</a>
                            <a class=""mdl-head-btn mdl-head-DKDV"" id=""RaoVatAdminChoDuyetFnMdl-DuyetDKDVBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.QuickSaveDichVu('True','#RaoVatAdminChoDuyetFnMdl-List');"" >Duyệt nhanh</a>
                            <a class=""mdl-head-btn mdl-head-DKDV"" id=""RaoVatAdminChoDuyetFnMdl-DuyetDKDVBtn"" href=""javascript:"" onclick=""RaoVatAdminChoDuyetFn.QuickSaveDichVu('False','#RaoVatAdminChoDuyetFnMdl-List');"" >Hủy</a>
                        </div>
                        <table id=""RaoVatAdminChoDuyetFnMdl-List"" class=""mdl-list""></table>
                        <div id=""RaoVatAdminChoDuyetFnMdl-Pager""></div>
                    </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.Admin.ChoDuyet.JScript1.js")
                        , "{RaoVatAdminChoDuyetFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion

            }
            writer.Write(sb.ToString());
            base.Render(writer);

        }
    }
}
