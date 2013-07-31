using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using spa.entitites;

public partial class lib_pages_Spa_view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var SPA_ID = Request["SPA_ID"];
        var Item = SpaDal.SelectById(Convert.ToInt16(SPA_ID));
        var pagerAnh = SpaAnhDal.pagerBySpa(string.Empty, false, "SPAHA_ThuTu asc", SPA_ID, 50);
        Item._SpaAnh = pagerAnh.List;
        var pagerDichVu = SpaDichVuDal.pagerByDichVu("DV_DM_ID asc", string.Empty, string.Empty, SPA_ID, 100);
        Item._SpaDichVu = pagerDichVu.List;
        var pagerKm = SpaKhuyenMaiDal.pagerSpa("KM_NgayTao desc", null, SPA_ID, 100);
        Item._SpaKhuyen = pagerKm.List;
        spa_view1.Item = Item;
        spa_view1.Comments = CommentDal.SelectActive(50, SPA_ID, "0");
        spa_view1.List = SpaDal.SelectLienQuan(SPA_ID, 20);

        var sb = new StringBuilder();
        sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
        sb.AppendFormat(@"<li>
        <a href=""/"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>");
        sb.Append(
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Spa/"">Spa</a></li>");

        var listDm = DanhMucDal.SelectTreeParentByDmId(linh.core.dal.DAL.con(), Item.KV_ID.ToString());
        foreach (var itemDm in listDm)
        {
            sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Spa/{0}/{1}/"">{2}</a></li>"
                   , itemDm.Ma, itemDm.ID, itemDm.Ten);
        }
        sb.AppendFormat(@"</ul>");
        spa_view1.txtPath = sb.ToString();

    }
}