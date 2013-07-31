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
[assembly: WebResource("cnn.plugin.DiaChiBG.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.DiaChiBG.JScript1.js", "text/javascript", PerformSubstitution = true)]
namespace cnn.plugin.DiaChiBG
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _DM_ID = Request["DM_ID"];
            string _Ten = Request["Ten"];
            string _Ma = Request["Ma"];
            string _XuatXu_ID = Request["XuatXu_ID"];
            string _DonVi_ID = Request["DonVi_ID"];
            string _SoLuong = Request["SoLuong"];
            string _GNY = Request["GNY"];
            string _GiaNhap = Request["GiaNhap"];
            string _MoTa = Request["MoTa"];
            string _Anh = Request["Anh"];
            string _DiaChi = Request["DiaChi"];
            string _DienThoai = Request["DienThoai"];
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
            DiaChiBanGiong Item;
            DiaChiBanGiong ItemDCBG;
            List<SanPham> List = new List<SanPham>();
            List<jgridRow> ListRow = new List<jgridRow>();

            //List<DanhMuc> ListDanhMucBG = new List<DanhMuc>();
            #endregion
            switch (subAct)
            {
                case "SelectTreeParentByDmId":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(SanPhamDal.SelectTreeParentByDmId(Convert.ToInt32(_DM_ID))));
                    }
                    break;
                    #endregion
                case "get":
                    #region lấy dữ liệu cho grid
                    Pager<DiaChiBanGiong> PagerGet = DiaChiBanGiongDal.pagerNormal("", false,"DCBG_"+jgrsidx + " " + jgrsord, _q, Convert.ToInt32(jgRows),"",_dm);
                    foreach (DiaChiBanGiong item in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                            ,item.STT.ToString() 
                            , string.Format(@"<img style=""height:50px;width:50px;"" src=""../up/i/{0}"" />",item.Anh)
                            , item.Ten
                            , item._DM_Ten
                            , item.Mota
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
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        DiaChiBanGiongDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(DiaChiBanGiongDal.SelectById(Convert.ToInt32(_ID))));

                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DiaChiBanGiongDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new DiaChiBanGiong();
                    }

                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    Item.Ten = _Ten;
                    
                    if (!string.IsNullOrEmpty(_DonVi_ID))
                    {
                        Item.DonViTinh = Convert.ToInt32(_DonVi_ID);
                    }
                    Item.Anh = _Anh;
                    Item.NoiDung = _NoiDung;
                    Item.Mota = _MoTa;
                    Item.NgayTao = DateTime.Now;
                    Item.NoiDang = _XuatXu_ID;

                    if (!string.IsNullOrEmpty(_GNY))
                    {
                        Item.Gia = double.Parse(_GNY);
                    }
                    Item.DiaChi = _DiaChi;
                    Item.DienThoai = _DienThoai;
                    
                    Item.NguoiTao = Security.Username;
                    Item.RowId = Guid.NewGuid();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = DiaChiBanGiongDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.NguoiTao = Security.Username;
                        Item.NguoiLienHe = MemberDal.SelectByUser(Security.Username).Ten;
                        Item.Email = MemberDal.SelectByUser(Security.Username).Email;
                        Item = DiaChiBanGiongDal.Insert(Item);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DiaChiBG.JScript1.js"));
                    break;
                    #endregion
                case "scpt1":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DiaChiBG.Publish.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <div id=""DiaChiBanGiongFnMdl-Main"">
                            <div class=""mdl-head"">
                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-DiaChiBanGiongFn txtSearch"" />
                                </span>
                                <a class=""mdl-head-btn mdl-head-add"" id=""DiaChiBanGiongFnMdl-addBtn"" href=""javascript:"" onclick=""DiaChiBanGiongFn.addfn();"">Thêm</a>
                                <a class=""mdl-head-btn mdl-head-edit"" id=""DiaChiBanGiongFnMdl-editBtn"" href=""javascript:"" onclick=""DiaChiBanGiongFn.editfn();"">Sửa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DiaChiBanGiongFnMdl-delBtn"" href=""javascript:"" onclick=""DiaChiBanGiongFn.delfn();"" >Xóa</a>
                                <a class=""mdl-head-btn mdl-head-del"" id=""DiaChiBanGiongFnMdl-delBtn"" href=""javascript:"" onclick=""DiaChiBanGiongFn.LamMoiGrid('#DiaChiBanGiongFnMdl-List');"" >Refresh</a>
                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                                    <input type=""text"" _value="""" class=""mdl-head-filter FilterDMSP""/>
                                </span>
                            </div>
                            <table id=""DiaChiBanGiongFnMdl-List"" class=""mdl-list""></table>
                            <div id=""DiaChiBanGiongFnMdl-Pager""></div>
                            <div id=""DiaChiBanGiongFnMdl-HangHoatempMdl-dlgNew""></div>
                        </div>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.DiaChiBG.JScript1.js")
                        , "{DiaChiBanGiongFn.LoadGridfn();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }

    }
}
