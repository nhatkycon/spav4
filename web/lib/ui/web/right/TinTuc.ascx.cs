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
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using docbao.entitites;

public partial class lib_ui_web_right_TinTuc : BasedUi
{
    public string txtAdv;
    public string txtVideo;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {
            sb = new StringBuilder();
            QuangCaoCollection QcList = QuangCaoDal.SelectByDanhMuc(con, "VITRI_QC_KM", 10);
            if (QcList.Count > 0)
            {
                foreach (var Item in QcList)
                {
                    sb.AppendFormat(@"<a class=""home-adv-r-box"" href=""{2}"" target=""_blank""><img  src=""{0}/lib/up/i/{1}"" class=""home-adv-r-img""/></a>"
                    , domain, Lib.imgSize(Item.Anh, "full"), Item.Url);
                }
                
            }
            txtAdv = sb.ToString();
        }

    }
}