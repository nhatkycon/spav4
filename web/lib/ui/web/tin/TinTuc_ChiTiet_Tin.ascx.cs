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

public partial class lib_ui_web_tin_TinTuc_ChiTiet_Tin : BasedUi
{
    public string txt;
    public string txtCuHon;
    public string txtMoiHon;
    public string txtPath;
    public string txtBl;
    public Tin Item;

    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        DanhMuc ItemDm = new DanhMuc();
        string _id = Request["ID"];
        using (SqlConnection con = DAL.con())
        {


            Item = TinDal.SelectById(Convert.ToInt64(_id));
            ItemDm = DanhMucDal.SelectById(Item.ID);
            int i = 0;
            List<Tin> ListMoiHon = TinDal.lienQuanMoiHon(con, 10, _id);
            if (ListMoiHon.Count > 0)
            {
                foreach (Tin item in ListMoiHon)
                {
                    i++;
                    sb.Append(formatItem(item, i == (ListMoiHon.Count - 1)));
                }
            }
            else
            {
                
            }
            txtMoiHon = sb.ToString();
            sb = new StringBuilder();
            i = 0;
            List<Tin> ListCuHon = TinDal.lienQuanCuHon(con, 10, _id);
            if (ListCuHon.Count > 0)
            {
                foreach (Tin item in ListCuHon)
                {
                    i++;
                    sb.Append(formatItem(item, i == (ListCuHon.Count - 1)));
                }
            }
            else
            {

            }
            txtCuHon = sb.ToString();
            sb = new StringBuilder();


            DanhMucCollection ListDm = DanhMucDal.SelectTreeParentByDmId(con, Item.DM_ID.ToString());
            sb.AppendFormat(@"<ul class=""tin-view-navi-menus"">");
            sb.AppendFormat(@"<li>
        <a href=""/"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>");

            foreach (DanhMuc itemDm in ListDm)
            {
                if (itemDm.PID != 0)
                {
                    sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Tin-Tuc/{0}/{1}/"">{2}</a></li>"
                        , itemDm.Ma, itemDm.ID, itemDm.Ten);
                }
            }
            sb.AppendFormat(@"</ul>");
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = Item.MoTa;
            this.Page.Header.Controls.Add(meta);
            this.Page.Header.Title = string.Format("{0}", Item.Ten);

            txtPath = sb.ToString();

            sb = new StringBuilder();
            CommentCollection ListCm = CommentDal.SelectActive(10, _id);
            foreach (Comment item in ListCm)
            {
                sb.Append(formatCom(item));
            }
            txtBl = sb.ToString();

        }
        txt = sb.ToString();
    }
    public string formatItem(Tin item, bool last)
    {
        return string.Format(@"
<div class=""tin-view-lienQuan-item{8}"">
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
                , item.DM_ID
                , last ? "" : " tin-view-lienQuan-item-last");
    }
    public string formatCom(Comment item) {
        return string.Format(@"<div class=""bl-item"">
            <div class=""bl-item-ten"">{0}</div>
            <div class=""bl-item-moTa"">{1}</div>
        </div>", item.KH_Ten, item.NoiDung);
    }
}