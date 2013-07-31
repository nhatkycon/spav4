using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using spa.entitites;
using linh.common;
using System.Reflection;
[assembly: WebResource("plugin.spa.datDichVuMgr.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.datDichVuMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.datDichVuMgr
{
    public class Class1:docPlugUI
    {
        public delegate void sendEmailDele(string email, string tieude, string noidung);
        void sendmail(string email, string tieude, string noidung)
        {
            //omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "DanhBaSpa:DatHang", "123$5678");
            omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "TapChiSpa:DatHang", "123$5678");
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string NgayHen_Ngay = Request["NgayHen_Ngay"];
            string NgayHen_Gio = Request["NgayHen_Gio"];
            string MEM_Ten = Request["MEM_Ten"];
            string MEM_DiaChi = Request["MEM_DiaChi"];
            string MEM_Mobile = Request["MEM_Mobile"];
            string GhiChu = Request["GhiChu"];
            string DV_ID = Request["DV_ID"];
            string Loai = Request["Loai"];
            SpaDatDichVu Item;
            List<jgridRow> ListRow = new List<jgridRow>();
            Pager<Spa> PagerGet;
            #endregion
            
            switch (subAct)
            {
                case "get":
                    #region lấy dữ liệu cho grid
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "SPA_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";

                    PagerGet = SpaDal.pagerByQ(Request["q"], jgrsidx + " " + jgrsord, 10);
                    foreach (Spa dm in PagerGet.List)
                    {
                        ListRow.Add(new jgridRow(dm.ID.ToString(), new string[] { 
                             string.Format("{0}",dm.ID)
                            , string.Format("<img style=\"width: 50px;\"  src=\"../up/i/{0}\" />", linh.common.Lib.imgSize(dm.Anh,"150x115"))
                            , dm.KV_Ten
                            , dm.Ten
                            , dm.DiaChi
                            , dm.Phone
                            , dm.NgayTao.ToString("hh:mm - dd/MM/yyyy")
                            , dm.Moi.ToString()
                            , dm.KhaiTruong.ToString()
                            , dm.KhuyenMai.ToString()
                            , dm.Publish.ToString()
                            , dm.Sao.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, PagerGet.TotalPages.ToString(), PagerGet.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "del":
                    #region xóa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        SpaDal.DeleteById(Convert.ToInt32(_ID));
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(SpaDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "getGio":
                    #region Nạp Gio
                    var listGio = new List<string>();
                    for (int i = 8; i < 19; i++)
                    {
                        for (int j = 0; j < 60; j += 20)
                        {
                            listGio.Add(string.Format("{0}:{1}", i.ToString().Length == 1 ? string.Format("0{0}", i) : i.ToString(), j.ToString().Length == 1 ? string.Format("0{0}", j) : j.ToString()));
                        }
                    }
                    sb.Append(JavaScriptConvert.SerializeObject(listGio));
                    break;
                    #endregion
                case "saveDangky":
                    #region lưu
                    if(Security.IsAuthenticated())
                    {
                        Item=new SpaDatDichVu
                                 {
                                     Active = false,
                                     Confirmed = false,
                                     GhiChu = GhiChu,
                                     KH_DiaChi = MEM_DiaChi,
                                     KH_Mobile = MEM_Mobile,
                                     KH_Ten = MEM_Ten,
                                     Loai = Convert.ToInt32(Loai),
                                     NgayHen =
                                         Convert.ToDateTime(string.Format("{0} {1}", NgayHen_Ngay, NgayHen_Gio),
                                                            new CultureInfo("vi-Vn")),
                                     NgayTao = DateTime.Now,
                                     P_ID = Convert.ToInt32(DV_ID),
                                     SPA_ID = SpaDichVuDal.SelectById(Convert.ToInt32(DV_ID)).SPA_ID,
                                     SpaConfirmed = false,
                                     SpaReaded = false,
                                     ThanhToan = false
                                 };
                        Item = SpaDatDichVuDal.Insert(Item);
                        var _dele = new sendEmailDele(sendmail);
                        sb.AppendFormat("");
                        string tieuDe = string.Format(@"DanhBaSpa:DatHang - {0} - {1}", MEM_Ten, DateTime.Now.ToString("hh:mm dd/MM/yyyy"));
                        _dele.BeginInvoke("linh_net@yahoo.com", tieuDe, sb.ToString(), null, null);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "save":                    
                    #region lưu
                    //if (!string.IsNullOrEmpty(_ID))
                    //{
                    //    Item = SpaDal.SelectById(Convert.ToInt32(_ID));
                    //}
                    //else
                    //{
                    //    Item = new Spa();
                    //}
                    //if (!string.IsNullOrEmpty(_DM_ID))
                    //{
                    //    Item.DM_ID = Convert.ToInt32(_DM_ID);
                    //}
                    //Item.Alias = _Alias;
                    //Item.Anh = _Anh;
                    //Item.DiaChi = _DiaChi;
                    //Item.Diem = Convert.ToInt32(_Diem);
                    //Item.KhaiTruong = Convert.ToBoolean(_KhaiTruong);
                    //Item.KhuyenMai = Convert.ToBoolean(_KhuyenMai);
                    //if (!string.IsNullOrEmpty(_KV_ID))
                    //{
                    //    Item.KV_ID = Convert.ToInt32(_KV_ID);
                    //}
                    //Item.Mobile = string.Empty;
                    //Item.Moi = Convert.ToBoolean(_Moi);
                    //Item.Mota = _MoTa;
                    //Item.NgayCapNhat = DateTime.Now;
                    //Item.NoiDung = _NoiDung;
                    //Item.Phone = _Phone;
                    //Item.Publish = Convert.ToBoolean(_Publish);
                    //Item.Sao = Convert.ToByte(_Sao);
                    //Item.SolanDanhGia = 0;
                    //Item.Ten = _Ten;
                    //Item.ToaDo = _ToaDo;
                    
                    //if (!string.IsNullOrEmpty(_ID))
                    //{
                    //    Item = SpaDal.Update(Item);
                    //}
                    //else
                    //{
                    //    Item.NgayTao = DateTime.Now;
                    //    Item.RowId = Guid.NewGuid();
                    //    Item = SpaDal.Insert(Item);
                    //}
                    sb.Append("1");
                    break;
                    #endregion
                case "autoComplete":
                    #region lưu
                    PagerGet = SpaDal.pagerByQ(Request["q"], string.Empty, 20);
                    sb.Append(JavaScriptConvert.SerializeObject(PagerGet.List));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.datDichVuMgr.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

                    sb.Append(Lib.GetResource(Assembly.GetExecutingAssembly(), "mdl.htm"));
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.datDichVuMgr.JScript1.js")
                        , "{datDichVuFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
