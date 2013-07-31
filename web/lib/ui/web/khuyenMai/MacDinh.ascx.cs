using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;
using linh.core;
using spa.entitites;

public partial class lib_ui_web_khuyenMai_MacDinh : BasedUi
{
    public Pager<SpaKhuyenMai> Pagers { get; set; }
    public List<QuangCao> QuangCaoTop { get; set; }
    public List<QuangCao> QuangCaoRight { get; set; }
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
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Spa-khuyen-mai/"">Spa khuyến mãi</a></li>");
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();

        this.Page.Header.Title = string.Format("Spa khuyến mãi, Spa giảm giá, spa voucher - Tạp chí spa");

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = "Danh sách chương trình khuyến mãi, giảm giá của Spa";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = "Danh sách chương trình khuyến mãi, giảm giá của Spa";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("Spa khuyến mãi, Spa giảm giá, spa voucher - Tạp chí spa");
        this.Page.Header.Controls.Add(meta);
    }
}