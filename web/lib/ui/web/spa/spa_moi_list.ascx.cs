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
using spa.entitites;

public partial class lib_ui_web_spa_spa_moi_list : System.Web.UI.UserControl
{
    public List<Spa> List { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
    public List<QuangCao> QuangCaosTop { get; set; }
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
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Spa-moi-khai-truong/"">Spa mới khai trương</a></li>");
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();

        this.Page.Header.Title = string.Format("Spa mới khai trương - Tạp chí spa");

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = "Danh sách những Spa mới khai trương";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = "Danh sách những Spa mới khai trương";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("Spa mới khai trương - Tạp chí spa");
        this.Page.Header.Controls.Add(meta);
    }
}