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
public partial class lib_ui_web_right_home : BasedUi
{
    public string txtAdv;
    public string txtVideo;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {
            VideoCollection List = VideoDal.SelectHome(1);
            if (List.Count > 0)
            {
                Video Item = List[0];
                sb.AppendFormat(@"<iframe width=""290"" height=""177"" src=""http://www.youtube.com/embed/{0}"" frameborder=""0"" allowfullscreen></iframe>"
                    ,Item.YID);
            }
            txtVideo = sb.ToString();
            sb = new StringBuilder();
            QuangCaoCollection QcList = QuangCaoDal.SelectByDanhMuc("VITRI_QC_KM", 1);
            if (QcList.Count > 0)
            {
                QuangCao Item = QcList[0];
                sb.AppendFormat(@"<a class=""home-adv-r-box"" href=""{2}"" target=""_blank""><img  src=""{0}/lib/up/i/{1}"" class=""home-adv-r-img""/></a>"
                    ,domain,Lib.imgSize(Item.Anh,"full"),Item.Url);
            }
            txtAdv = sb.ToString();
        }

    }
}