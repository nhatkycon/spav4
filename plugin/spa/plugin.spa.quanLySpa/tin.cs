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
using docbao.entitites;
using spa.entitites;
[assembly: WebResource("plugin.spa.quanLySpa.htm.htm", "text/html", PerformSubstitution = true)]
[assembly: WebResource("plugin.spa.quanLySpa.JScript1.js", "text/javascript", PerformSubstitution = true)]

namespace plugin.spa.quanLySpa
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            string _ID = Request["ID"];
            string _DM_ID = Request["DM_ID"];
            string _Ten = Request["Ten"];
            string _Phone = Request["Phone"];
            string _KV_ID = Request["KV_ID"];
            string _Sao = Request["Sao"];
            string _Alias = Request["Alias"];
            string _Diem = Request["Diem"];
            string _ToaDo = Request["ToaDo"];
            string _MoTa = Request["MoTa"];
            string _DiaChi = Request["DiaChi"];
            string _NoiDung = Request["NoiDung"];
            string _Publish = Request["Publish"];
            string _Moi = Request["Moi"];
            string _KhuyenMai = Request["KhuyenMai"];
            string _KhaiTruong = Request["KhaiTruong"];
            string _Anh = Request["Anh"];

            string _LoaiThanhVien = Request["LoaiThanhVien"];
            string _Website = Request["Website"];
            string _Email = Request["Email"];
            string _BaoDam = Request["BaoDam"];
            Spa Item;
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
                case "save":                    
                    #region lưu
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaDal.SelectById(Convert.ToInt32(_ID));
                    }
                    else
                    {
                        Item = new Spa();
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    Item.Alias = _Alias;
                    Item.Anh = _Anh;
                    Item.DiaChi = _DiaChi;
                    Item.Diem = Convert.ToInt32(_Diem);
                    Item.KhaiTruong = Convert.ToBoolean(_KhaiTruong);
                    Item.KhuyenMai = Convert.ToBoolean(_KhuyenMai);
                    Item.Website = _Website;
                    Item.Email = _Email;
                    Item.BaoDam = Convert.ToBoolean(_BaoDam);
                    if (!string.IsNullOrEmpty(_LoaiThanhVien))
                    {
                        Item.LoaiThanhVien = Convert.ToInt32(_LoaiThanhVien);
                    }

                    if (!string.IsNullOrEmpty(_KV_ID))
                    {
                        Item.KV_ID = Convert.ToInt32(_KV_ID);
                    }
                    if (!string.IsNullOrEmpty(_DM_ID))
                    {
                        Item.DM_ID = Convert.ToInt32(_DM_ID);
                    }
                    Item.Mobile = string.Empty;
                    Item.Moi = Convert.ToBoolean(_Moi);
                    Item.Mota = _MoTa;
                    Item.NgayCapNhat = DateTime.Now;
                    Item.NoiDung = _NoiDung;
                    Item.Phone = _Phone;
                    Item.Publish = Convert.ToBoolean(_Publish);
                    Item.Sao = Convert.ToByte(_Sao);
                    Item.SolanDanhGia = 0;
                    Item.Ten = _Ten;
                    Item.ToaDo = _ToaDo;
                    
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        Item = SpaDal.Update(Item);
                    }
                    else
                    {
                        Item.NgayTao = DateTime.Now;
                        Item.RowId = Guid.NewGuid();
                        Item = SpaDal.Insert(Item);
                    }
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
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.quanLySpa.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-quanLySpaMdl"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""quanLySpaMdl-addBtn"" href=""javascript:quanLySpaFn.add();"">Thêm</a>
    <a class=""mdl-head-btn mdl-head-edit"" id=""quanLySpaMdl-editBtn"" href=""javascript:quanLySpaFn.edit();"">Sửa</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""quanLySpaMdl-delBtn"" href=""javascript:quanLySpaFn.del();"">Xóa</a>
    <a class=""mdl-head-btn mdl-head-del""  href=""javascript:;"" onclick=""$('#quanLySpaMdl-List').trigger('reloadGrid');"">Nạp</a>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-spaFilterByKv""/>
    </span>
    <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-spaFilterByDm""/>
    </span>
</div>
<table id=""quanLySpaMdl-List"" class=""mdl-list""></table>
<div id=""quanLySpaMdl-Pager""></div>
");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "plugin.spa.quanLySpa.JScript1.js")
                        , "{quanLySpaFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}
