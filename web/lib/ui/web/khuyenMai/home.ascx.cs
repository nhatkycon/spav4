using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.core;
using linh.controls;
using System.Text;
using linh.common;
using docsoft.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using spa.entitites;
public partial class lib_ui_web_khuyenMai_home : BasedUi
{
    public string txt;
    public List<SpaKhuyenMai> List { get; set; }
    public string formatKhuyenMai(SpaKhuyenMai item)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(@"
<div class=""home-km-item"">
<div class=""km-dangky"">
<span class=""km-gia"">{10}</span>
<a href=""javascript:;"" class=""km-dangky-btn"">Đăng ký</a>
</div>

    <a href=""{0}/Spa-Khuyen-Mai/{1}/{2}.html"" class=""km-img-box"">
        <img src=""{0}/lib/up/i/{4}"" class=""km-img"" />
    </a>
    <a href=""{0}/Spa-Khuyen-Mai/{1}/{2}.html"" class=""km-ten"">{3}</a>
<span class=""spa-date"">
{5:dd/MM/yy}-{6:dd/MM/yy}
</span>
<a href=""{0}/Spa/{8}/{9}.html"" class=""km-spa-ten"">{7}</a>
</div>"
                , domain
                , Lib.Rutgon(Lib.Bodau(item.Ten), 50)
                , item.ID
                , item.Ten
                , Lib.imgSize(item._Spa.Anh, "150x115")
                , item.NgayBatDau
                , item.NgayKetThuc
                , item._Spa.Ten
                , Lib.Rutgon(Lib.Bodau(item._Spa.Ten), 50)
                , item._Spa.ID
                , item.GiaKhuyenMai == 0 ? string.Format("{0} %", item.TyLeKhuyenMai) : Lib.TienVietNam(item.GiaKhuyenMai));
        return sb.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
}