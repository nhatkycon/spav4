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

public partial class lib_ui_web_heThong_adv_bottom : BasedUi
{
    public string txtAdv;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {
            QuangCaoCollection QcList = QuangCaoDal.SelectByDanhMuc("VITRI_QC_FOOT", 1);
            if (QcList.Count > 0)
            {
                QuangCao Item = QcList[0];
                sb.AppendFormat(@"<a class=""home-adv-b-box"" href=""{2}"" target=""_blank""><img  src=""{0}/lib/up/i/{1}"" class=""home-adv-b-img""/></a>"
                    , domain, Lib.imgSize(Item.Anh, "full"), Item.Url);
            }
            txtAdv = sb.ToString();
        }
    }
}