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
using cnn.entities;
using System.Data.SqlClient;
using linh.core.dal;


public partial class lib_master_MasterPage : System.Web.UI.MasterPage
{
    public string mnu;
    public DanhMuc Item;
    public string pop;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = DAL.con())
        {
            if (Session["pop"] == null)
            {
                DanhMuc ItemDm = DanhMucDal.SelectByMa("SYSTEM-POP-UP", con);
                if (ItemDm.ID != 0 && ItemDm.KyHieu == "1")
                {
                    pop = "</script><div style=\"display:none;\"class=\"pop-pnl-2\">" + ItemDm.Description + "</div><script>var l =$('.pop-pnl-2').html(); jQuery.facebox(l);";
                }
                else
                {
                    //                    pop = @" jQuery(function(){
                    //var l =' <div class=""pop-pnl""><a href=""javascript:;"" class=""close-pop""></a> <div style=""float:left; width:260px; height:308px; margin-top:100px;margin-left:26px; background: url(Dotphao.gif); background-repeat:no-repeat; background-position: -90px -20px;""></div>      </div>';
                    //jQuery.facebox(l);
                    //jQuery('.close-pop').click(function(){jQuery(document).trigger('close.facebox');});
                    //});";
                }

                Session["pop"] = "oke";
            }
            if (Request["pop"] != null)
            {
                Session["pop"] = null;
            }
            var sb = new StringBuilder();
            #region sản phẩm
            //List<DanhMuc> ListDm = DanhMucDal.SelectLangBased("", "SP_NHOM");
            //foreach (DanhMuc item in ListDm)
            //{
            //    sb.AppendFormat(@"<a href=""san-pham.aspx?dm_id={0}"" title=""{1}"" class=""navi-top-subItem"">{1}</a>"
            //        ,item.ID,item.Ten);
            //}
            #endregion

            //List<SanPham> ListSanPhamMoi = SanPhamDal.SelectTop8SanPhamMoi(10);
            //foreach (SanPham item in ListSanPhamMoi)
            //{
            //    sb.AppendFormat(@"<a href=""san-pham.aspx?id={0}"" title=""{1}"" class=""navi-top-subItem"">{1}</a>"
            //        , item.ID, item.Ten);
            //}
            //mnu = sb.ToString();
            Item = DanhMucDal.SelectByMa("SYSTEM-FOOT");
        }
       

    }
    public string domain
    {
        get
        {
            return string.Format("http://{0}{1}", Request.Url.Host, Request.IsLocal ? string.Format(":{0}{1}", Request.Url.Port, Request.ApplicationPath) : "");
        }
    }
}
