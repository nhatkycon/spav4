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

public partial class lib_ui_web_heThong_home_dichVu : BasedUi
{
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        List<DanhMuc> ListDm = DanhMucDal.SelectLangBased("", "HOME-DVU");
        int i = 0;
        foreach (DanhMuc item in ListDm)
        {
            i++;
            sb.AppendFormat(@"<a title=""{3}"" class=""home-dvu-item{4}"" href=""{2}"">
<img class=""home-dvu-item-img"" src=""{0}/lib/up/i/{1}""></a>"
                , domain, Lib.imgSize(item.Anh, "170x150"), item.GiaTri, item.Ten, i == ListDm.Count ? " home-dvu-item-last" : "");
        }
        txt = sb.ToString();
    }
}