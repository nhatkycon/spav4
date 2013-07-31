using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_HoiDap_DanhMuc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        var DM_Alias = Request["DM_Alias"];
         using (var con = DAL.con())
         {
             ListMacDinh1.Pagers = SpaHoiDapDal.pagerByDichVu(null, null, "/Hoi-dap-Spa/" + DM_Alias + "/" + DM_ID + "/" + "/{0}/", DM_ID, 20);
             if(!string.IsNullOrEmpty(DM_ID))
             {
                 ListMacDinh1.Item = DanhMucDal.SelectById(con, Convert.ToInt32(DM_ID));
                 ListMacDinh1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "ADV-HOIDAP-DANHMUC", 10);
             }
             else
             {
                 ListMacDinh1.QuangCaos = QuangCaoDal.SelectByDanhMuc(con, "ADV-HOIDAP-MACDICH", 10);
                 
             }
         }
    }
}