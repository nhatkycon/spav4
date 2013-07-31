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
using docbao.entitites;
using System.Web.UI.HtmlControls;
public partial class lib_ui_web_video_List : BasedUi
{
    public string txt;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string _id = Request["ID"];
        Video Item = new Video();
        VideoCollection List = new VideoCollection();
        sb.AppendFormat(@"
<ul id=""tin-view-navi-menus"">
<li><a href=""{0}"" class=""tin-view-navi-menus-item home"">Trang chủ</a></li>
<li><a class=""tin-view-navi-menus-item"" href=""{0}/Video/"">Video</a></li>
</ul>
", domain);

        using (SqlConnection con = DAL.con())
        {
            if (!string.IsNullOrEmpty(_id))
            {
                #region Xem chi tiết Video

                Item = VideoDal.SelectById(Convert.ToInt32(_id));
                List = VideoDal.SelectByIdList(_id, 10);

                #endregion
            }
            else
            {
                #region Mặc định
                List = VideoDal.SelectHot(50);
                if (List.Count > 0)
                {
                    Item = List[0];
                }
                #endregion
            }
        }
        if (List.Count > 0)
        {
            sb.AppendFormat(@"<div class=""video-view-item"">
    <div class=""video-item-ten"">{0}
    </div>
    <div class=""video-item-pnl"">
        <iframe width=""660"" height=""477"" src=""http://www.youtube.com/embed/{2}"" frameborder=""0"" allowfullscreen></iframe>
    </div>
    <div class=""video-item-moTa"">{1}
    </div>
</div>", Item.Ten, Item.MoTa, Item.YID);
            if (List.Count > 1)
            {
                sb.Append(@"<div class=""video-lienQuan-header"">    
Video liên quan
</div>
<div class=""video-lienQuan-box"">");
                foreach (Video item in List)
                {
                    if (item.ID != Item.ID)
                    {
                        sb.AppendFormat(@"<div class=""video-lienQuan-item"">
        <a href=""{0}/Video/{4}/{1}.html"" class=""video-item-anhBox"">
            <img src=""{0}/lib/up/i/{2}"" class=""video-item-anh"" />
        </a>
        <a href=""{0}/Video/{4}/{1}.html"" class=""video-item-ten"">{3}
        </a>
    </div>", domain, item.ID, item.Anh, item.Ten, Lib.Bodau(item.Ten));
                    }
                }
                sb.Append(@"</div>");
            }

            HtmlMeta meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = Item.MoTa;
            this.Page.Header.Controls.Add(meta);
            this.Page.Header.Title = string.Format("{0}", Item.Ten);
        }

        txt = sb.ToString();
    }
    public string formatVideo(Video item)
    {
        return string.Format("");
    }
    public string formatVideoItem(Video item)
    {
        return string.Format("");
    }
}