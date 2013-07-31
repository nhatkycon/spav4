using System;
using System.Collections.Generic;
using System.Linq;
using linh.core;
using System.Text;
using linh.common;
using docsoft.entities;
using spa.entitites;

public partial class lib_ui_web_spa_home_moi : BasedUi
{
    public string headerTxt;
    public string contentTxt;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<DanhMuc> listDm = DanhMucDal.SelectLangBased("", "QUAN").OrderBy(p => p.ThuTu).ToList();

        var listDm1 = from p in listDm
                      where p.GiaTri == "1"
                      orderby p.ThuTu
                      select p;
        listDm = listDm1.ToList();
        var sb = new StringBuilder();
        int i = 0;
        foreach (DanhMuc item in listDm)
        {
            sb.AppendFormat(@"<a _ref=""{0}"" href=""javascript:;"" class=""home-mdl-tin-header-item{2}"">{1}</a>"
                , item.ID, item.Ten, i == 0 ? " home-mdl-tin-header-item-active" : "");
            i++;
        }
        headerTxt = sb.ToString();
        sb = new StringBuilder();

        i = 0;
        var max = 0;
        foreach (DanhMuc item in listDm)
        {
            List<Spa> listSpa = SpaDal.pagerKhuVuc(string.Empty,false,null,16,item.ID.ToString()).List;
            if (listSpa.Count > 0)
            {
                var myGuid = Guid.NewGuid().ToString().Replace("-", "");
                sb.AppendFormat(@"
<div _ref=""{0}"" class=""home-mdl-tin-body{1}"">
                    <div class=""home-mdl-tin-body-container"">
                        <div _ref=""0"" class=""home-mdl-tin-content {2}"">                              
", item.ID, i == 0 ? " home-mdl-tin-body-active" : "", myGuid);

                sb.Append(@"<a href=""javascript:;"" class=""home-mdl-tin-content-leftBtn""></a>");

                sb.Append(@"<div class=""home-mdl-tin-content-box"">");
                sb.Append(@"<div class=""home-mdl-tin-content-box-rel"">");
                foreach (Spa itemSpa in listSpa)
                {
                    sb.AppendFormat(
                        @"
<div class=""home-spa-top-item"">
    <a href=""/Spa/{1}/{2}.html"" class=""spa-img-box"">
        <img src=""{0}/lib/up/i/{4}"" class=""spa-img"" />
    </a>
    <a href=""/Spa/{1}/{2}.html"" class=""spa-ten"">{3}</a></div>",
                        domain, itemSpa.Alias, itemSpa.ID, itemSpa.Ten, Lib.imgSize(itemSpa.Anh, "150x115"));
                }
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append(@"<a href=""javascript:;"" class=""home-mdl-tin-content-rightBtn""></a>");


                sb.AppendFormat(@"
                        </div>
                        <div _ref=""0"" class=""home-mdl-tin-footer"">
                            <a href=""/Spa/{1}/{2}/"" class=""home-mdl-tin-more"">Xem thêm</a>                            
                        </div>
                    </div>                    
                </div>", domain, item.KyHieu, item.ID);
            }
            i++;
        }
        contentTxt = sb.ToString();
    }
}