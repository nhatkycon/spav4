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
public partial class lib_ui_web_tin_DanhMuc_SubDanhMuc_List : BasedUi
{
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string _DM_ID = Request["DM_ID"];
        string _Pages = Request["Pages"];
        using (SqlConnection con = DAL.con())
        {

            DanhMucCollection ListDm = DanhMucDal.SelectTreeParentByDmId(con, _DM_ID);
            sb.AppendFormat(@"<ul class=""tin-view-navi-menus"">");
            sb.AppendFormat(@"<li>
        <a href=""{0}"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>", domain);

            foreach (DanhMuc itemDm in ListDm)
            {
                if (itemDm.PID != 0)
                {
                    sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""{3}/Tin-Tuc/{0}/{1}/"">{2}</a></li>"
                        , itemDm.Ma, itemDm.ID, itemDm.Ten, domain);
                }
            }
            sb.AppendFormat(@"</ul>");

            DanhMuc ItemDm = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
            DanhMucCollection DmList = DanhMucDal.SelectTreeChildByDmId(_DM_ID);
            
            int i = 0;

            var subDmList1 = from p in DmList
                             where p.PID.ToString() == _DM_ID
                             orderby p.ThuTu
                             select p;

            foreach (DanhMuc ItemDm1 in subDmList1)
            {
                if (ItemDm1.PID != 0)
                {
                    sb.AppendFormat(@"<div class=""dv-dm-pnl{1}""><div class=""dv-dm-pnl-header"">{0}</div>", ItemDm1.Ten
                        , (i % 2) != 0 ? "" : " dv-dm-pnl-last");
                    sb.Append(@"<div class=""dv-subdm-pnl"">");
                    var subDmList2 = from p in DmList
                                     where p.PID == ItemDm1.ID
                                     orderby p.ThuTu
                                     select p;
                    foreach (DanhMuc ItemDm2 in subDmList2)
                    {
                        sb.AppendFormat(@"<a class=""dv-subdm-pnl-item"" href=""{0}/Tin-Tuc/{2}/{1}/"">
<span class=""dv-subdm-pnl-item-imgBox{5}""><img class=""dv-subdm-pnl-item-img"" src=""{0}/lib/up/i/{4}""/></span>
<span class=""dv-subdm-pnl-item-ten"">{3}</span></a>"
                            , domain, ItemDm2.ID, ItemDm2.Ma, ItemDm2.Ten, ItemDm2.Anh, string.IsNullOrEmpty(ItemDm2.Anh) ? " dv-subdm-pnl-item-imgBox-hide" : "");
                    }
                    i++;                    
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
            }
            //sb.AppendFormat(@"<p></p><div class=""home-tin-big""><div class=""home-tin-header"">{0}</div></div>", ItemDm.Ten);
            //Pager<Tin> pg = TinDal.pagerByDanhMuc(domain + string.Format("/{0}/{1}", ItemDm.Alias, ItemDm.Ten) + "/{0}.htm", true, "TIN_NgayCapNhat Desc", _DM_ID);
            //if (pg.List.Count > 0)
            //{
            //    foreach (Tin item in pg.List)
            //    {
            //        i++;
            //        sb.Append(formatDanhMucItemSmall(item, i));
            //    }
            //}
            HtmlMeta meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = ItemDm.Description;
            this.Page.Header.Controls.Add(meta);
            this.Page.Header.Title = string.Format("{0}", ItemDm.Ten);
        }
        txt = sb.ToString();
    }
    public string formatDanhMucItemSmall(Tin item, int i)
    {
        return string.Format(@"
<div class=""sp-dm-item {8}"">
<a href=""{0}/Tin-Tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-imgBox"">
    <img src=""{0}/lib/up/tintuc/{1}"" class=""tin-item-anh"" />
</a>
<a href=""{0}/Tin-Tuc/{6}/{7}/{5}/{2}.html"" class=""tin-item-ten"">{3}</a>
<span class=""tin-item-moTa"">{4}</span>
</div>
"
                , domain
                , Lib.imgSize(item.Anh, "280x210")
                , item.ID
                , item.Ten
                , item.MoTa
                , Lib.Bodau(item.Ten)
                , item.DM_Ma
                , item.DM_ID
                , (i % 2) != 0 ? "" : " sp-dm-item-last");
    }
}