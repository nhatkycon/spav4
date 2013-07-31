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

public partial class lib_ui_web_tin_home_slides : System.Web.UI.UserControl
{
    public List<Tin> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}