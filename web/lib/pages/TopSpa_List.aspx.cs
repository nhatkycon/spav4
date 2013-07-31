using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using spa.entitites;

public partial class lib_pages_TopSpa_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        spa_top_list1.Tops = DanhMucDal.SearchByLDM("SPA-TOP", "", "Vi-vn");
        spa_top_list1.QuangCaos = QuangCaoDal.SelectByDanhMuc("ADV-TOP-SPA-LIST-RIGHT", 10);
        spa_top_list1.QuangCaoTops = QuangCaoDal.SelectByDanhMuc("ADV-TOP-SPA-LIST-TOP", 10);
        spa_top_list1.Spas = SpaTopDal.SelectByLoai(DM_ID, 20);
        if(!string.IsNullOrEmpty(DM_ID))
        {
            spa_top_list1.Item = DanhMucDal.SelectById(Convert.ToInt32(DM_ID));            
        }
    }
}