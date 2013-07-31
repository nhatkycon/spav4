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

public partial class lib_pages_Spa_moi_khai_truong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(SqlConnection con = DAL.con())
        {
            spa_moi_list1.List = SpaDal.SelectKhaiTruong(con, 20);
            spa_moi_list1.QuangCaos = QuangCaoDal.SelectByDanhMuc("ADV-SPA-MOI-RIGHT", 10);
            spa_moi_list1.QuangCaosTop = QuangCaoDal.SelectByDanhMuc("ADV-SPA-MOI", 10);
        }
    }
}