using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using linh.core;
using linh.controls;
using System.Text;
using linh.common;
using docsoft.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using spa.entitites;

public partial class lib_ui_web_dichVu_DichVu_DanhMuc : BasedUi
{
    public Pager<SpaDichVu> Pagers { get; set; }
    public DanhMuc Item { get; set; }
    public List<SpaHoiDap> HoiDaps { get; set; }
    public List<DanhMuc> KhuVucs { get; set; }
    public List<DanhMuc> DichVuCons { get; set; }
    public string txtPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        var sb = new StringBuilder();
        sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
        sb.AppendFormat(@"<li>
        <a href=""{0}"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>", domain);
        sb.Append(
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Dich-vu-Spa/"">Dịch vụ Spa</a></li>");

        var listDm = DanhMucDal.SelectTreeParentByDmId(linh.core.dal.DAL.con(), DM_ID);
        foreach (var itemDm in listDm)
        {
            sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Dich-vu-Spa/{0}/{1}/"">{2}</a></li>"
                   , itemDm.Alias, itemDm.ID, itemDm.Ten);
        }
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();


        this.Page.Header.Title = string.Format("Dịch vụ " +  Item.Ten + " - Tạp chí spa");

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = Item.GiaTri;
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "keywords";
        meta.Content = Item.KeyWords;
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = Item.GiaTri;
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("Dịch vụ " + Item.Ten + " - Tạp chí spa");
        this.Page.Header.Controls.Add(meta);
    }
}