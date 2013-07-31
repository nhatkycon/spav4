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

public partial class lib_ui_web_right_TinTuc_TinMoi : BasedUi
{
    public string txt;
    public DanhMuc Item;
    protected void Page_Load(object sender, EventArgs e)
    {

        StringBuilder sb = new StringBuilder();
        List<Tin> List = new List<Tin>();
        string _DM_ID = Request["DM_ID"];
        string _Pages = Request["Pages"];
        using (SqlConnection con = DAL.con())
        {
            Item = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
            List = TinDal.SelectByDanhMuc(con, "TIN-TIN", 5);
            int i = 0;
            foreach (Tin item in List)
            {
                i++;
                sb.Append(formatItem(item, i == List.Count-1));
            }
        }
        txt = sb.ToString();
    }
    public string formatItem(Tin item, bool last)
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