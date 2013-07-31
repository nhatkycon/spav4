using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.common;
using linh.core;
using spa.entitites;

public partial class lib_ui_web_spa_spa_top_list : BasedUi
{
    public List<DanhMuc> Tops { get; set; }
    public DanhMuc Item { get; set; }
    public List<SpaTop> Spas { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
    public List<QuangCao> QuangCaoTops { get; set; }
    public string txtPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        var sb = new StringBuilder();
        sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
        sb.AppendFormat(@"<li>
        <a href=""/"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>");
        sb.Append(
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Top-Spa/"">Top Spa</a></li>");
        if (!string.IsNullOrEmpty(DM_ID))
        {
            var listDm = DanhMucDal.SelectTreeParentByDmId(linh.core.dal.DAL.con(), DM_ID);
            foreach (var itemDm in listDm)
            {
                sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Top-Spa/{0}/{1}/"">{2}</a></li>"
                       , itemDm.Ma, itemDm.ID, itemDm.Ten);
            }
        }
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();

        this.Page.Header.Title = string.Format("{0}",Item.Ten);

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = Item.Description;

        meta = new HtmlMeta();
        meta.Name = "keywords";
        meta.Content = Item.KeyWords;

        this.Page.Header.Controls.Add(meta);
        if (Item != null)
        {
            meta = new HtmlMeta();
            meta.Name = "og:image";
            meta.Content = domain + "/lib/up/i/" + Lib.imgSize(Item.Anh, "100x100");
            this.Page.Header.Controls.Add(meta);
        }


        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = Item.Description;
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("{0}", Item.Ten);
        this.Page.Header.Controls.Add(meta);
    }
}