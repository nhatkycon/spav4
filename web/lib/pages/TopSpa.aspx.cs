using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core;

public partial class lib_pages_TopSpa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        spa_top1.Tops = DanhMucDal.SearchByLDM("SPA-TOP", "", "Vi-vn");
        spa_top1.QuangCaos = QuangCaoDal.SelectByDanhMuc("ADV-TOP-SPA-RIGHT", 10);
        spa_top1.QuangCaoTops = QuangCaoDal.SelectByDanhMuc("ADV-TOP-SPA-TOP", 10);
    }
}