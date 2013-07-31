using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using linh.frm;
namespace docsoft
{
    public class basePage: Page
    {
        public string act = HttpContext.Current.Request["act"];
        public string rqPlug = HttpContext.Current.Request["rqPlug"];
        public void rendertext(string txt)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(string txt,string content)
        {
            Response.ClearContent();
            Response.ContentType = content;
            Response.Write(txt);
            Response.End();
        }
        public void rendertext(StringBuilder sb)
        {
            Response.ClearContent();
            Response.ContentType = "text/html";
            Response.Write(sb.ToString());
            Response.End();
        }
        public void rendertext(StringBuilder sb, string content)
        {
            Response.ClearContent();
            Response.ContentType = content;
            Response.Write(sb.ToString());
            Response.End();
        }
        public string domain
        {
            get
            {
                return string.Format("http://{0}{1}", Request.Url.Host, Request.IsLocal ? string.Format(":{0}{1}", Request.Url.Port, Request.ApplicationPath) : "");
            }
        }
    }
    #region jgrid
    public class jgrid
    {
        public string page { get; set; }
        public string total { get; set; }
        public string records { get; set; }
        public List<jgridRow> rows { get; set; }
        public jgrid() { }
        public jgrid(string _page, string _total, string _records, List<jgridRow> _rows)
        {
            page = _page;
            total = _total;
            records = _records;
            rows = _rows;
        }
        public jgrid(string _page, string _total, string _records, List<jgridRow> _rows,List<jgridUserData> _userdata)
        {
            page = _page;
            total = _total;
            records = _records;
            rows = _rows;
            userdata = _userdata;
        }
        public List<jgridUserData> userdata { get; set; }
    }
    public class jgridUserData{
        public string column { get; set; }
        public string values { get; set; }
        public jgridUserData() { }
        public jgridUserData(string _col,string _values) {
            column = _col;
            values = _values;
        }
    }
    public class jgridRow
    {
        public jgridRow() { }
        public jgridRow(string _id, string[] _cell)
        {
            id = _id;
            cell = _cell;
        }
        public string id { get; set; }
        public string[] cell { get; set; }
    }
    #endregion   
    public class docPlugUI:PlugUI
    {
        public string subAct = HttpContext.Current.Request["subAct"];
        public string jgrpage = HttpContext.Current.Request["page"];
        public string jgrsord = HttpContext.Current.Request["sord"];
        public string jgrsidx = HttpContext.Current.Request["sidx"];
        public string fnId = HttpContext.Current.Request["fn_id"];
        public string jgRows = HttpContext.Current.Request["rows"];
    }
    public class autoCplItem
    {
        public string label { get; set; }
        public string value { get; set; }
        public string desc { get; set; }
        public autoCplItem() { }
        public autoCplItem(string _label, string _value)
        {
            label = _label;
            value = _value;
        }
        public autoCplItem(string _label, string _value, string _desc)
        {
            label = _label;
            value = _value;
            desc = _desc;
        }
    }
}
