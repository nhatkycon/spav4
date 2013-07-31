<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DangKy.ascx.cs" Inherits="lib_ui_web_heThong_DangKy" %>
<%@ Import Namespace="linh.common" %>
<style>

</style>
<div class="dvu-list-body">
    <table width="100%" cellpadding="4" cellspacing="4">
        <tr>
            <td colspan="2">
                <h1 class="dk-title">
                    Đăng ký spa của bạn
                </h1>
                <div class="dk-subTitle">
                    Bạn có biết hơn <b>63%</b> khách hàng của bạn đến từ internet.<br />
                    Với hơn 1,200 spa trong hệ thống - Tạp chí Spa là website được đông đảo khách hàng có nhu cầu Spa lựa chọn.<br />
                    Họ tìm thấy ở Tạp chí Spa sự so sánh giữa các spa, sự tư vấn từ chính những người dùng - giúp họ lựa chọn một Spa phù hợp nhất.<br />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span class="dk-header-stt">1</span>
                <span class="dk-header-stepTitle">Thông tin về Spa</span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Tên: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="spaTen" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="spaTen" ErrorMessage="*" ID="validateSpaTen" ValidationGroup="submit" runat="server" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Loại thành viên:
                </td>
            <td  valign="top">
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="Vàng">Vàng: 1.200.000 đ/ Năm</asp:ListItem>
                    <asp:ListItem Value="Bạc">Bạc: 800.000đ/ năm</asp:ListItem>
                    <asp:ListItem Value="Đồng">Đồng: 500.000 đ/ năm</asp:ListItem>
                    <asp:ListItem Value="Miễn phí"></asp:ListItem>
                </asp:DropDownList><br/>
                <span class="dk-msg">
                    Spa của bạn muốn trở thành <b>loại thành viên</b> nào trong hệ thống
                </span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Điện thoại: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="spaDienThoai" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="spaDienThoai" ErrorMessage="*" ID="validateSpaDienThoai" ValidationGroup="submit" runat="server" Display="Dynamic" /><br />
                <span class="dk-msg">
                    Ghi cả cố định, di động và hotline (ví dụ: 042670620 0946709969, hotline: 093456899)
                </span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Địa chỉ: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="spaDiaChi" runat="server" CssClass="dk-spa-textarea" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ControlToValidate="spaDiaChi" ErrorMessage="*" ID="validateSpaDiaChi" ValidationGroup="submit" runat="server" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Website: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="spaWeb" runat="server" CssClass="dk-spa-input" /><br />
                <span class="dk-msg">
                    Để trống nếu chưa có website
                </span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Nick yahoo tư vấn: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="SpaYm" runat="server" CssClass="dk-spa-textarea" TextMode="MultiLine" />
                <asp:RequiredFieldValidator ControlToValidate="SpaYm" ErrorMessage="*" ID="RequiredFieldValidator6" ValidationGroup="submit" runat="server" Display="Dynamic" />
                <span class="dk-msg">
                    Đây là nick yahoo bạn dùng để tư vấn cho khách hàng, Nếu chưa có để trống và chúng tôi sẽ giúp bạn tạo lấy 1 cái.
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span class="dk-header-stt">2</span>
                <span class="dk-header-stepTitle">Thông tin người liên hệ</span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Tên: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="Ten" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="Ten" ErrorMessage="*" ID="RequiredFieldValidator1" ValidationGroup="submit" runat="server" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Chức vụ: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="ChucVu" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="ChucVu" ErrorMessage="*" ID="RequiredFieldValidator4" ValidationGroup="submit" runat="server" Display="Dynamic" /><br />                
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Điện thoại: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="Mobile" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="Mobile" ErrorMessage="*" ID="RequiredFieldValidator2" ValidationGroup="submit" runat="server" Display="Dynamic" /><br />                
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                E-mail: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="Email" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="Email" ErrorMessage="*" ID="RequiredFieldValidator3" ValidationGroup="submit" runat="server" Display="Dynamic" /><br />                
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Nick Yahoo: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="Ym" runat="server" CssClass="dk-spa-input" />
                <asp:RequiredFieldValidator ControlToValidate="Ym" ErrorMessage="*" ID="RequiredFieldValidator5" ValidationGroup="submit" runat="server" Display="Dynamic" /><br />                
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Nick Skype: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="Skype" runat="server" CssClass="dk-spa-input" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span class="dk-header-stt">3</span>
                <span class="dk-header-stepTitle">Thông tin thêm về Spa</span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Năm thành lập: 
            </td>
            <td  valign="top">
                <asp:TextBox ID="SpaNam" runat="server" CssClass="dk-spa-input" />
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Phần mềm quản lý: 
            </td>
            <td  valign="top">
                <asp:CheckBox ID="PhanMem" runat="server" CssClass="dk-spa-input" /><asp:Label AssociatedControlID="PhanMem" runat="server" ID="PhanMemLbl" Text="Đã sử dụng phần mềm"></asp:Label>
                <span class="dk-msg">
                    Nếu bên bạn chưa dùng phần mềm quản lý, vui lòng không tíc vào ô trên
                </span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
                Ảnh Spa sẵn có: 
            </td>
            <td  valign="top">
                <asp:CheckBox ID="AnhSpa" runat="server" CssClass="dk-spa-input" /><asp:Label AssociatedControlID="AnhSpa" runat="server" ID="Label1" Text="Có sẵn"></asp:Label>
                <span class="dk-msg">
                    Chúng tôi sẽ cần album ảnh thật đẹp về Spa của bạn để đưa lên website, nếu Spa bạn đã có sẵn ảnh xin vui lòng tíc vào ô trên. Nếu chưa có, chúng tôi sẽ giúp bạn có một bộ ảnh ưng ý nhất về Spa của mình.
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span class="dk-header-stt">4</span>
                <span class="dk-header-stepTitle">Sau khi điền các thông tin đầy đủ, bạn vui lòng click vào nút bên dưới để gửi cho chúng tôi</span>
            </td>
        </tr>
        <tr>
            <td class="dk-td-header" valign="top">
            </td>
            <td>
                <asp:Button ID="sendBtn" ValidationGroup="submit"  runat="server" Text="Gửi thông tin" OnClick="sendBtn_Click" />
            </td>
        </tr>
    </table>

</div>
<div class="dvu-list-adv">
    <% foreach (var item in QuangCaos)
       {%>
        <a target="_blank" class="dvu-list-adv-item"href="<%=item.Url %>">
            <img class="dvu-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>