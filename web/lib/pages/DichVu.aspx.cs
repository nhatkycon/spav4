using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_DichVu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        using (SqlConnection con = DAL.con())
        {
            DichVu_MacDinh1.Pagers = SpaDichVuDal.pagerByDichVu(con, null, null, null, null, 20, "/Dich-vu-Spa/" + "{0}/");
            //DichVu_MacDinh1.List = SpaDal.SelectKhaiTruong(20);
            DichVu_MacDinh1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "ADV-DVU-HOME-RIGHT", 10);
        }
       
    }
}