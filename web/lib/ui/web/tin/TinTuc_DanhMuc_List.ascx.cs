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
using System.Web.UI.HtmlControls;

public partial class lib_ui_web_tin_TinTuc_DanhMuc_List : BasedUi
{
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string _DM_ID=Request["DM_ID"];
        string DM_Alias = Request["DM_Alias"];
        string _Pages = Request["Pages"];
        using (SqlConnection con = DAL.con())
        {
            DanhMucCollection ListDm = DanhMucDal.SelectTreeParentByDmId(con, _DM_ID);
            sb.AppendFormat(@"<ul class=""tin-view-navi-menus"">");
            sb.AppendFormat(@"<li>
        <a href=""{0}"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>",domain);

            foreach (DanhMuc itemDm in ListDm)
            {
                if (itemDm.PID != 0)
                {
                    sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Tin-Tuc/{0}/{1}/"">{2}</a></li>"
                        , itemDm.Ma, itemDm.ID, itemDm.Ten);
                }
            }
            sb.AppendFormat(@"</ul>");

            DanhMuc ItemDm = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
            Pager<Tin> pg =
                TinDal.pagerByDanhMuc(string.Format("/Tin-Tuc/{0}/{1}", DM_Alias, _DM_ID) + "/{0}.htm", true,
                                      "TIN_NgayCapNhat Desc", _DM_ID, 10);
            int i = 0;
            if (pg.List.Count > 0)
            {
                foreach(Tin item in pg.List)
                {
                    i++;
                    if (i == 1 && string.IsNullOrEmpty(_Pages))
                    {
                        sb.Append(formatDanhMucItemBig(item));
                    }
                    else
                    {
                        sb.Append(formatDanhMucItemSmall(item));
                    }
                }
            }
            sb.Append(pg.Paging);
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = ItemDm.Description;
            this.Page.Header.Controls.Add(meta);
            this.Page.Header.Title = string.Format("{0}", ItemDm.Ten);
            
        }
        txt = sb.ToString();
    }
    public string formatDanhMucItemBig(Tin item)
    {
        return string.Format(@"
<div class=""tin-dm-itemBig"">
<a href=""{0}/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-anh"" />
</a>
<a href=""{0}/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-ten"">{3}</a>
<span class=""tin-item-moTa"">{4}</span>
</div>
"
                , domain
                , Lib.imgSize(item.Anh, "240x180")
                , item.ID
                , item.Ten
                , item.MoTa
                , Lib.Bodau(item.Ten)
                , item.DM_Ma
                , item.DM_ID);
    }
    public string formatDanhMucItemSmall(Tin item)
    {
        return string.Format(@"
<div class=""tin-dm-item"">
<a href=""{0}/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-img"" />
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
                , item.DM_ID);
    }
}