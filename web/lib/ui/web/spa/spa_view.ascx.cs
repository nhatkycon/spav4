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

public partial class lib_ui_web_spa_spa_view : BasedUi
{
    public Spa Item { get; set; }
    public List<Spa> List { get; set; }
    public List<Comment> Comments { get; set; }
    public string txtPath { get; set; }
    public Dictionary<Int32, string> DanhMucs { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        rptAnh1.DataSource = Item._SpaAnh;
        rptAnh1.DataBind();
        DanhMucs = new Dictionary<Int32, string>();

        var listspa = (from p in Item._SpaDichVu
                       select new { p._DanhMuc.Ten, p.DM_ID }).Distinct().ToList();
        foreach (var item in listspa)
        {
            DanhMucs.Add(item.DM_ID, item.Ten);
        }

        this.Page.Header.Title = string.Format("{0} {1}", Item.Ten, Item.DiaChi);

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = Item.Ten + " " + Item.DiaChi;
        this.Page.Header.Controls.Add(meta);

     

    }
}