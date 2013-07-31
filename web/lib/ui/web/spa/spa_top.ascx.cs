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

public partial class lib_ui_web_spa_spa_top : BasedUi
{
    public List<DanhMuc> Tops { get; set; }
    public DanhMuc Item { get; set; }
    public List<SpaTop> Spas { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
    public List<QuangCao> QuangCaoTops { get; set; }
    public string txtPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
        sb.AppendFormat(@"<li>
        <a href=""/"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>");
        sb.Append(
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Top-Spa/"">Top Spa</a></li>");
        
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();

        this.Page.Header.Title = string.Format("Top spa ở Hà nội, Top spa ở Sài gòn");

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = "Top spa ở Hà nội, Top spa ở Sài gòn";
        this.Page.Header.Controls.Add(meta);
        if (Item!=null)
        {
            meta = new HtmlMeta();
            meta.Name = "og:image";
            meta.Content = domain + "/lib/up/i/" + Lib.imgSize(Item.Anh, "100x100");
            this.Page.Header.Controls.Add(meta);    
        }
        

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = string.Format("Top spa ở Hà nội, Top spa ở Sài gòn");
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("Top spa ở Hà nội, Top spa ở Sài gòn");
        this.Page.Header.Controls.Add(meta);
    }
}