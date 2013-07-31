using System;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con  = DAL.con())
        {
            home_slides.List = TinDal.SelectByDanhMuc(con, "slides", 20);
            home_adv_ac1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-AC1", 3);
            home_topLeft1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-TOPLEFT", 1);
            home_adv_ac2.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-AC2", 3);
            home_adv_ac3.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-AC3", 3);
            home1.List = SpaKhuyenMaiDal.SelectTop(con, 4);
            home2.List = SpaHoiDapDal.SelectHome(con, 5);

            home_tin1.QuangCao1 = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-TIN1", 3);
            home_tin1.QuangCao2 = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-TIN2", 3);
            home_tin1.QuangCao3 = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-TIN3", 3);
            home_tin1.QuangCao4 = QuangCaoDal.SelectByDanhMuc(con, "HOME-ADV-TIN4", 3);
        }
    }
}