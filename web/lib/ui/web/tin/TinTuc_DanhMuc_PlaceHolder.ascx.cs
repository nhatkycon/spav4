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


public partial class lib_ui_web_tin_TinTuc_DanhMuc_PlaceHolder : BasedUi
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        string _DM_ID = Request["DM_ID"];
        string _Pages = Request["Pages"];
        using (SqlConnection con = DAL.con())
        {
            DanhMuc ItemDm = DanhMucDal.SelectById(Convert.ToInt32(_DM_ID));
            UserControl uc = (UserControl)this.Page.LoadControl(ItemDm.KyHieu);
            this.Controls.Add(uc);
        }
       
    }
}