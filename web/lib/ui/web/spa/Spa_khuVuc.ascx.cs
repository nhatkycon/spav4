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
using linh.controls;
using linh.core;
using spa.entitites;

public partial class lib_ui_web_spa_Spa_khuVuc : BasedUi
{
    public List<DanhMuc> KhuVucs { get; set; }
    public Pager<Spa> SpaPager { get; set; }
    public DanhMuc Item { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
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
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Spa/"">Spa</a></li>");
        if(!string.IsNullOrEmpty(DM_ID))
        {
            var listDm = DanhMucDal.SelectTreeParentByDmId(linh.core.dal.DAL.con(), DM_ID);
            foreach (var itemDm in listDm)
            {
                sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Spa/{0}/{1}/"">{2}</a></li>"
                       , itemDm.Ma, itemDm.ID, itemDm.Ten);
            }    
        }
        sb.AppendFormat(@"</ul>");
        txtPath = sb.ToString();

        this.Page.Header.Title = Item == null ? "Danh bạ Spa - TapChiSpa.com" : string.Format("Có {1} Spa ở {0}", Item.Ten, SpaPager.Total);

        var sbDescription = new StringBuilder();
        var sbKeywords = new StringBuilder();

        foreach (var item in KhuVucs)
        {
            sbDescription.AppendFormat(@"Danh sách Spa ở {0},", item.Ten);
            if (!string.IsNullOrEmpty(item.KeyWords))
            {
                sbKeywords.AppendFormat(@"{0},", item.KeyWords);
                
            }
        }

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = Item == null ? sbDescription.ToString() : Item.Description;
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "keywords";
        meta.Content = Item == null ? sbKeywords.ToString() : Item.KeyWords;
        this.Page.Header.Controls.Add(meta);

        if(Item!= null)
        {
            meta = new HtmlMeta();
            meta.Name = "og:image";
            meta.Content = domain + "/lib/up/i/" + Lib.imgSize(Item.Anh, "100x100");
            this.Page.Header.Controls.Add(meta);    
        }
        

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = Item == null ? sbDescription.ToString() : Item.Description;
        this.Page.Header.Controls.Add(meta);

        

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = Item == null ? "Danh bạ Spa - TapChiSpa.com" : string.Format("Có {1} Spa ở {0}", Item.Ten, SpaPager.Total);
        this.Page.Header.Controls.Add(meta);
    }
}