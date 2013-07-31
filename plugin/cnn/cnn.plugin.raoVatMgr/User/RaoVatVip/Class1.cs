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
[assembly: WebResource("cnn.plugin.raoVatMgr.User.RaoVatVip.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.raoVatMgr.User.RaoVatVip.htm.htm", "text/html")]
[assembly: WebResource("cnn.plugin.raoVatMgr.User.RaoVatVip.Dkdv.htm", "text/html")]
namespace cnn.plugin.raoVatMgr.User.RaoVatVip
{
    class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            #region tham số
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
            string _calcelall = Request["_calcelall"];
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
            RaoVat Item;
            List<RaoVat> List = new List<RaoVat>();
            List<jgridRow> ListRow = new List<jgridRow>();
            #endregion

            switch (subAct)
            {
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

                        if (!string.IsNullOrEmpty(_NgayhethanVip))
                        {
                            dkhottime = Convert.ToDateTime(_NgayhethanVip, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dkhottime = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayhethanSuper))
                        {
                            dksupertime = Convert.ToDateTime(_NgayhethanSuper, new CultureInfo("vi-vn"));
                        }
                        else
                        {
                            dksupertime = DateTime.MinValue;
                        }
                        if (!string.IsNullOrEmpty(_NgayhethanHot))
                        {
                            dkviptime = Convert.ToDateTime(_NgayhethanHot, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkviptime = DateTime.MinValue;
                        }

                        if (!string.IsNullOrEmpty(_NgayDKHot))
                        {
                            dkbdhottime = Convert.ToDateTime(_NgayDKHot, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdhottime = DateTime.MinValue;
                        }

                        if (!string.IsNullOrEmpty(_NgayDKSuper))
                        {
                            dkbdsupertime = Convert.ToDateTime(_NgayDKSuper, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdsupertime = DateTime.MinValue;
                        }

                        if (!string.IsNullOrEmpty(_NgayDKVip))
                        {
                            dkbdviptime = Convert.ToDateTime(_NgayDKVip, new CultureInfo("vi-vn"));

                        }
                        else
                        {
                            dkbdviptime = DateTime.MinValue;
                        }

                        RaoVatDal.UpdateDKDV(_ID, _DKsuper, _DKvip, _DKhot, dksupertime, dkviptime, dkhottime, dkbdsupertime, dkbdviptime, dkbdhottime);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "HuyDichVu":
                    #region duyệt
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        //RaoVatDal.DuyetList(_ID, _calcelall,_super,_vip,_hot);
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

                    Pager<RaoVat> PagerGet = RaoVatDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, Convert.ToInt32(Request["rows"]), _DM_ID, "", _NC_ID, Security.Username, _Lang, _Publish, _Active, "3");
                    int countrv = 0;
                    foreach (RaoVat item in PagerGet.List)
                    {
                        countrv++;
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
                            item.ID.ToString()
                            ,countrv.ToString()
                            ,"RV-"+ item.ID.ToString()
                            ,string.Format(@"<img src=""../up/i/{0}"" />",Lib.imgSize(item.Anh1,"50x50"))
                            ,item.Ten
                            ,item._DM_Ten
                            ,item._Nhucau_Ten
                            ,item.NgayDang.ToString("dd/MM/yyyy")
                            ,item.DangKy_SUPER == true ? item.VIP_SUPER_NgayBatDau.ToString("dd/MM/yyyy")+"-"+item.VIP_SUPER_NgayHetHan.ToString("dd/MM/yyyy") : "Không đăng ký"
                            ,item.DangKy_VIP == true ? item.VIP_VIP_NgayBatDau.ToString("dd/MM/yyyy")+"-"+ item.VIP_VIP_NgayHetHan.ToString("dd/MM/yyyy"): "Không đăng ký"
                            ,item.DangKy_NoiBat == true ?item.VIP_NoiBat_NgayBatDau.ToString("dd/MM/yyyy")+"-"+ item.VIP_NoiBat_NgayHetHan.ToString("dd/MM/yyyy") : "Không đăng ký"
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.User.RaoVatVip.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    sb.Append(@"
                    <div id=""UserRaoVatVipFnMdl-main"">   
                        <div id=""UserRaoVatVipFnMdl-head"" class=""mdl-head"">
                            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-UserRaoVatVip"" />
                            </span>
                            
                            <a class=""mdl-head-btn mdl-head-edit"" id=""UserRaoVatVipFnMdl-editBtn"" href=""javascript:"" onclick=""UserRaoVatVipFn.edit();"">Sửa</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""UserRaoVatVipFnMdl-delBtn"" href=""javascript:"" onclick=""UserRaoVatVipFn.del();"" >Xóa</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""UserRaoVatVipFnMdl-DKDVBtn"" href=""javascript:"" onclick=""UserRaoVatVipFn.DKDV();"" >Sửa Đăng ký dịch vụ trả phí</a>
                            <select class=""slt"" onchange=""UserRaoVatVipFn.search();"" id=""UserRaoVatVipFnMdl-changeLangSlt""></select>
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterLoaiTinUserRaoVatVip""/>
                            </span>    
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDanhMucUserRaoVatVip""/>
                            </span>
                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"" style=""display:none;"">
                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterKhuVucUserRaoVatVip""/>
                            </span>
                        </div>
                        <table id=""UserRaoVatVipFnMdl-List"" class=""mdl-list""></table>
                        <div id=""UserRaoVatVipFnMdl-Pager""></div>
                    </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.User.RaoVatVip.JScript1.js")
                        , "{UserRaoVatVipFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion

            }
            writer.Write(sb.ToString());
            base.Render(writer);

        }
    }
}
