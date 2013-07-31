using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_HoiDap_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var HD_ID = Request["HD_ID"];
        using (var con = DAL.con())
        {
            hoiDap_view1.Item = SpaHoiDapDal.SelectById(Convert.ToInt32(HD_ID));
            hoiDap_view1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "ADV-HOIDAP-VIEW", 10);
            hoiDap_view1.CauTraLoi = SpaHoiDapDal.CauTraLoi(con, HD_ID, 50);
            hoiDap_view1.LienQuan = SpaHoiDapDal.CauHoiLienQuan(con, HD_ID, 10);
        }
    }
}