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
public partial class lib_ui_web_tin_home_tin : BasedUi
{
    public string txtTin;
    public string txtDichVu;
    public string txtAlbumAnh;
    public string txtCongNghe;
    public string txtSanPham;
    public List<QuangCao> QuangCao1 { get; set; }
    public List<QuangCao> QuangCao2 { get; set; }
    public List<QuangCao> QuangCao3 { get; set; }
    public List<QuangCao> QuangCao4 { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        var List = new List<Tin>();
        var Item = new Tin();
        using (var con = DAL.con())
        {
            #region tin
            List = TinDal.SelectByDanhMuc(con, "Thong-bao-Tap-chi-spa", 5);
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(builItemBig(Item));
                if (List.Count > 1)
                {
                    sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                    foreach (Tin item in List)
                    {
                        if (item.ID != Item.ID)
                        {
                            sb.Append(builItemLienQuan(item,"Tin-Tuc"));
                        }
                    }
                    sb.Append("</div>");
                }
            }
            txtTin = sb.ToString();
            sb = new StringBuilder();
            #endregion
            #region dich vu
            List = TinDal.SelectByDanhMuc(con, "Bi-quyet-lam-dep", 5);
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(builItemBig(Item));
                if (List.Count > 1)
                {
                    sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                    foreach (Tin item in List)
                    {
                        if (item.ID != Item.ID)
                        {
                            sb.Append(builItemLienQuan(item, "Bi-quyet-lam-dep"));
                        }
                    }
                    sb.Append("</div>");
                }
            }
            txtDichVu = sb.ToString();
            sb = new StringBuilder();
            #endregion
            #region San pham
            List = TinDal.SelectByDanhMuc(con, "Trai-nghiem-spa", 5);
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(builItemBig(Item));
                if (List.Count > 1)
                {
                    sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                    foreach (Tin item in List)
                    {
                        if (item.ID != Item.ID)
                        {
                            sb.Append(builItemLienQuan(item, "Trai-nghiem-spa"));
                        }
                    }
                    sb.Append("</div>");
                }
            }
            txtSanPham = sb.ToString();
            sb = new StringBuilder();
            #endregion
            #region Cong nghe
            List = TinDal.SelectByDanhMuc(con, "Spa-gioi-thieu", 5);
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(builItemBig(Item));
                if (List.Count > 1)
                {
                    sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                    foreach (Tin item in List)
                    {
                        if (item.ID != Item.ID)
                        {
                            sb.Append(builItemLienQuan(item, "Spa-gioi-thieu"));
                        }
                    }
                    sb.Append("</div>");
                }
            }
            txtCongNghe= sb.ToString();
            sb = new StringBuilder();
            #endregion
            #region Album
            List = TinDal.SelectByDanhMuc(con, "Goc-spa-tai-nha", 5);
            if (List.Count > 0)
            {
                Item = List[0];
                sb.Append(builItemBig(Item));
                if (List.Count > 1)
                {
                    sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                    foreach (Tin item in List)
                    {
                        if (item.ID != Item.ID)
                        {
                            sb.Append(builItemLienQuan(item, "Goc-spa-tai-nha"));
                        }
                    }
                    sb.Append("</div>");
                }
            }
            txtAlbumAnh = sb.ToString();
            sb = new StringBuilder();
            #endregion

            HtmlMeta meta = new HtmlMeta();
            meta.Name = "keywords";
            meta.Content = "cham soc da, lam trang da, giam beo, thẩm mỹ viện, tham my vien, chăm sóc toàn thân, cham soc toan than, massage toàn thân, massage toan than, chăm sóc chân tay, cham soc chan tay, Mua phieu spa giam gia";
            this.Page.Header.Controls.Add(meta);
            this.Page.Header.Title = "Tạp chí spa - Mua phiếu giảm giá từ 1.200 Spa và Salon";
        }
    }
    public string builLienQuanPnl(List<Tin> List, string _alias)
    {
        StringBuilder sb = new StringBuilder();
        Tin Item = new Tin();
        if (List.Count > 0)
        {
            Item = List[0];
            sb.Append(builItemSmall(Item, _alias));
            if (List.Count > 1)
            {
                sb.AppendFormat(@"<div class=""home-tin-item-lienQuan"">");
                foreach (Tin item in List)
                {
                    if (item.ID != Item.ID)
                    {
                        sb.Append(builItemLienQuan(item, _alias));
                    }
                }
                sb.Append("</div>");
            }
        }
        return sb.ToString();
    }
    public string builItemLienQuan(Tin item, string _alias)
    {
        return string.Format(@"<a href=""/Tin-tuc/{4}/{5}/{3}/{1}.html"" class=""home-tin-item-lienQuan-item"">{2}</a>"
                                , domain
                                , item.ID
                                , item.Ten
                                , Lib.Bodau(item.Ten)
                                , item.DM_Ma
                                ,item.DM_ID);
    }
    public string builItemSmall(Tin item, string _alias)
    {
        return string.Format(@"
<a href=""/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""home-tin-item-anhBox"">
    <img src=""/lib/up/tintuc/{1}"" class=""home-tin-item-anh"" />
</a>
<a href=""/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""home-tin-item-ten"">{3}</a>
<span class=""home-tin-item-moTa"">{4}</span>
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
    public string builItemBig(Tin Item)
    {
        return string.Format(@"
<a href=""/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""home-tin-item-anhBox"">
    <img src=""/lib/up/tintuc/{1}"" class=""home-tin-item-anh"" />
</a>
<a href=""/Tin-tuc/{6}/{7}/{5}/{2}.html"" class=""home-tin-item-ten"">{3}</a>
<span class=""home-tin-item-moTa"">{4}</span>"
                , domain
                , Lib.imgSize(Item.Anh, "240x180")
                , Item.ID
                , Item.Ten
                , Item.MoTa
                , Lib.Bodau(Item.Ten)
                , Item.DM_Ma
                , Item.DM_ID);
    }
    public string builPnlBig(List<Tin> list)
    {
        StringBuilder sb = new StringBuilder();
        return sb.ToString();
    }
}