using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using spa.entitites;
using docsoft.entities;
using linh.core;
using linh.controls;
using System.Text;
using linh.common;
using spa.entitites;
public partial class lib_ui_web_heThong_DangKy : System.Web.UI.UserControl
{
    public List<QuangCao> QuangCaos { get; set; }
    public delegate void sendEmailDele(string email, string tieude, string noidung);
    void sendmail(string email, string tieude, string noidung)
    {
        omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "DanhBaSpa:Dang Ky", "123$5678");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Đăng ký Spa - Tạp chí spa";
    }
    protected void sendBtn_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sendEmailDele _dele = new sendEmailDele(sendmail);
        sb.AppendFormat(@"
<div class=""dvu-list-body"">
    <table width=""100%"">
        <tr>
            <td colspan=""2"">
                <h1 class=""dk-title"">
                    {0}
                </h1>
            </td>
        </tr>
        <tr>
            <td colspan=""2"">
                <span class=""dk-header-stt"">1</span>
                <span class=""dk-header-stepTitle"">Thông tin về Spa</span>
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Tên: 
            </td>
            <td  valign=""top"">
                {0}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Loại thành viên: 
            </td>
            <td  valign=""top"">
                {14}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Điện thoại: 
            </td>
            <td  valign=""top"">
                {1}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Địa chỉ: 
            </td>
            <td  valign=""top"">
                {2}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Website: 
            </td>
            <td  valign=""top"">
                {3}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Nick yahoo tư vấn: 
            </td>
            <td  valign=""top"">
                {4}
            </td>
        </tr>
        <tr>
            <td colspan=""2"">
                <span class=""dk-header-stt"">2</span>
                <span class=""dk-header-stepTitle"">Thông tin người liên hệ</span>
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Tên: 
            </td>
            <td  valign=""top"">
                {5}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Chức vụ: 
            </td>
            <td  valign=""top"">
                {6}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Điện thoại: 
            </td>
            <td  valign=""top"">
                {7}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                E-mail: 
            </td>
            <td  valign=""top"">
                {8}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Nick Yahoo: 
            </td>
            <td  valign=""top"">
                {9}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Nick Skype: 
            </td>
            <td  valign=""top"">
                {10}
            </td>
        </tr>
        <tr>
            <td colspan=""2"">
                <span class=""dk-header-stt"">3</span>
                <span class=""dk-header-stepTitle"">Thông tin thêm về Spa</span>
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Năm thành lập: 
            </td>
            <td  valign=""top"">
                {11}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Phần mềm quản lý: 
            </td>
            <td  valign=""top"">
                {12}
            </td>
        </tr>
        <tr>
            <td class=""dk-td-header"" valign=""top"">
                Ảnh Spa sẵn có: 
            </td>
            <td  valign=""top"">
                {13}
            </td>
        </tr>
    </table>
</div>
", spaTen.Text,spaDienThoai.Text, spaDiaChi.Text, spaWeb.Text,SpaYm.Text, Ten.Text
 , ChucVu.Text, Mobile.Text,Email.Text,Ym.Text,Skype.Text, SpaNam.Text,PhanMem.Checked ? "Đã dùng" : "Chưa"
 , AnhSpa.Checked? "Có" :"Chưa có", DropDownList1.SelectedValue);
        string tieuDe = string.Format(@"DanhBaSpa:Dang Ky - {0} - {1}", spaTen.Text, DateTime.Now.ToString("hh:mm dd/MM/yyyy"));
        _dele.BeginInvoke("linh_net@yahoo.com", tieuDe, sb.ToString(), null, null);
        Response.Redirect("../");
    }
}