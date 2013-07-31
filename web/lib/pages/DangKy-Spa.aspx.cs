using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;
public partial class lib_pages_DangKy_Spa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var con = DAL.con())
        {
            DangKy1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "ADV-DANGKY", 10);
        }
    }
}