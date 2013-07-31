using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using cnn.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.core;

public partial class lib_aspx_comment_Default : basePage
{
    public delegate void sendEmailDele(string email, string tieude, string noidung);
    void sendmailThongbao(string email, string tieude, string noidung)
    {
        omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "TapChiSpa", "123$5678");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Request["act"];
        string _ID = Request["ID"];
        string _Ten = Request["Ten"];
        string _Email = Request["Email"];
        string _Mobile = Request["Mobile"];
        string _NoiDung = Request["NoiDung"];
        string _Kieu = Request["Kieu"];
        string _PID = Request["PID"];
        string _Star = Request["Star"];
        var item = new Comment();
        var _dele = new sendEmailDele(sendmailThongbao);
        var sb = new System.Text.StringBuilder();
        switch (act)
        {
            case "add":
                #region add
                item.KH_Email = _Email;
                item.KH_Mobile = _Mobile;
                item.KH_Ten = _Ten;
                item.NoiDung = _NoiDung;
                item.NgayTao = DateTime.Now;
                item.Readed = false;
                item.Active = false;
                if (string.IsNullOrEmpty(_PID))
                {
                    _PID = "0";
                }
                if (!string.IsNullOrEmpty(_Kieu))
                {
                    item.Kieu = Convert.ToInt32(_Kieu);
                }
                if (!string.IsNullOrEmpty(_Star))
                {
                    item.Star = Convert.ToInt32(_Star);
                }
                item.PID = Convert.ToInt32(_PID);
                item = CommentDal.Insert(item);
                _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("TapChiSpa - Bình luận mới: {0}  {1}", _Ten, DateTime.Now.ToString("hh:mm-dd/MM/yy"))
                            , string.Format("Tên: {0}<br/>Mobile: {1}<br/>Email: {2}<br/>Ý kiến<hr/> {3}"
                            , _Ten, _Mobile, _Email, _NoiDung)
                            , null, null);
                break;
                #endregion
            case "get":
                #region get
                foreach (Comment itemComment in CommentDal.SelectActive(20))
                {
                    sb.Append(format_comment(itemComment));
                }
                break;
                #endregion
            default:
                break;
        }
        rendertext(sb);
    }
    string format_comment(Comment item) {
        return string.Format(@"<div class=""bl-item"">
                                <div class=""bl-item-ten"">Qúy khách: {0}</div>
                                <div class=""bl-item-bl"">
                                {1}
                                </div>
                            </div>", item.KH_Ten, item.NoiDung);
    }
}