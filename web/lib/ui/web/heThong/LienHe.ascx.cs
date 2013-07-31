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
using cnn.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;

public partial class lib_ui_web_heThong_LienHe : BasedUi
{
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {

            sb.AppendFormat(@"
<ul id=""tin-view-navi-menus"">
<li><a href=""{0}"" class=""tin-view-navi-menus-item home"">Trang chủ</a></li>
<li><a class=""tin-view-navi-menus-item"" href=""{0}/Lien-he.html"">Liên hệ</a></li>
</ul>
", domain);
            DanhMuc ItemDm = DanhMucDal.SelectByMa("SYSTEM-LIENHE", con);
            if (ItemDm.ID != 0)
            {
                sb.AppendFormat("{0}", String.IsNullOrEmpty(ItemDm.Description) ? string.Format(@"SYSTEM-LIENHE is missing", domain) : ItemDm.Description);
            }
        }
        txt = sb.ToString();
    }
}