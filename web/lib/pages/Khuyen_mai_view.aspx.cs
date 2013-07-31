using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using spa.entitites;

public partial class lib_pages_Khuyen_mai_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var KM_ID = Request["KM_ID"];
        km_view1.Visible = !string.IsNullOrEmpty(KM_ID);
        var km = SpaKhuyenMaiDal.SelectById(Convert.ToInt32(KM_ID));
        km_view1.Item = km;
        km_view1.QuangCaoRight = QuangCaoDal.SelectByDanhMuc("ADV-KM-VIEW-RIGHT", 10);
        km_view1.QuangCaoTop = QuangCaoDal.SelectByDanhMuc("ADV-KM-VIEW-TOP", 10);

        spa_view1.Visible = !string.IsNullOrEmpty(KM_ID);
        var Item = km._Spa;
        var pagerAnh = SpaAnhDal.pagerBySpa(string.Empty, false, "SPAHA_ThuTu asc", km.SPA_ID.ToString(), 50);
        Item._SpaAnh = pagerAnh.List;
        var pagerDichVu = SpaDichVuDal.pagerByDichVu("DV_DM_ID asc", string.Empty, string.Empty, km.SPA_ID.ToString(), 100);
        Item._SpaDichVu = pagerDichVu.List;
        var pagerKm = SpaKhuyenMaiDal.pagerSpa("KM_NgayTao desc", null, km.SPA_ID.ToString(), 100);
        Item._SpaKhuyen = pagerKm.List;
        spa_view1.Item = Item;
        spa_view1.Comments = CommentDal.SelectActive(50, km.SPA_ID.ToString(), "0");
        spa_view1.List = SpaDal.SelectLienQuan(km.SPA_ID.ToString(), 20);

    }
}