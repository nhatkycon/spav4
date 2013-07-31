using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using spa.entitites;

public partial class lib_pages_KhuyenMai : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MacDinh1.Pagers = SpaKhuyenMaiDal.pagerSpa("KM_NgayBatDau desc", null, null, 10,"/Spa-khuyen-mai/{0}/");
        MacDinh1.QuangCaoRight = QuangCaoDal.SelectByDanhMuc("ADV-KM-LIST-RIGHT", 10);
        MacDinh1.QuangCaoTop = QuangCaoDal.SelectByDanhMuc("ADV-KM-LIST-TOP", 10);
    }
}