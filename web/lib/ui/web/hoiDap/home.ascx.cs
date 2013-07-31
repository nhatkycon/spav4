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
using spa.entitites;
public partial class lib_ui_web_hoiDap_home : BasedUi
{
    public string headerTxt;
    public string contentTxt;
    public List<SpaHoiDap> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}