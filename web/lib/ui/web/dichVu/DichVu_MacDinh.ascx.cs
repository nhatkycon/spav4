using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.controls;
using spa.entitites;

public partial class lib_ui_web_dichVu_DichVu_MacDinh : System.Web.UI.UserControl
{
    public Pager<SpaDichVu> Pagers { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
    public List<Spa> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}