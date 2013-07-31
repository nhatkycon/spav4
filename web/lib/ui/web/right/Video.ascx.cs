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
public partial class lib_ui_web_right_Video : BasedUi
{
    public string txtAdv;
    public string txtVideo;
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        List<docsoft.entities.Tin> ListTin = new List<docsoft.entities.Tin>();
        using (SqlConnection con = DAL.con())
        {
            VideoCollection List = VideoDal.SelectHome(1);
            if (List.Count > 0)
            {
                Video Item = List[0];
                sb.AppendFormat(@"<iframe width=""290"" height=""177"" src=""http://www.youtube.com/embed/{0}"" frameborder=""0"" allowfullscreen></iframe>"
                    , Item.YID);
            }
            txtVideo = sb.ToString();
            sb = new StringBuilder();
            QuangCaoCollection QcList = QuangCaoDal.SelectByDanhMuc("VITRI_QC_KM", 1);
            if (QcList.Count > 0)
            {
                QuangCao Item = QcList[0];
                sb.AppendFormat(@"<a class=""home-adv-r-box"" href=""{2}"" target=""_blank""><img  src=""{0}/lib/up/i/{1}"" class=""home-adv-r-img""/></a>"
                    , domain, Lib.imgSize(Item.Anh, "full"), Item.Url);
            }
            txtAdv = sb.ToString();

            ListTin = docsoft.entities.TinDal.SelectByDanhMuc(con, "TIN-TIN", 5);
            int i = 0;
            sb = new StringBuilder();
            foreach (docsoft.entities.Tin item in ListTin)
            {
                i++;
                sb.Append(formatItem(item, i == ListTin.Count - 1));
            }
            txt = sb.ToString();
        }

    }
    public string formatItem(docsoft.entities.Tin item, bool last)
    {
        return string.Format(@"
<div class=""dv-r-item{8}"">
<a href=""{0}/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-anh"" />
</a>
<a href=""{0}/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-ten"">{3}</a>
<span class=""tin-item-moTa"">{4}</span>
</div>
"
                , domain
                , Lib.imgSize(item.Anh, "120x90")
                , item.ID
                , item.Ten
                , item.MoTa
                , Lib.Bodau(item.Ten)
                , item.DM_Ma
                , item.DM_ID
                , last ? "" : " dv-r-item-last");
    }
}