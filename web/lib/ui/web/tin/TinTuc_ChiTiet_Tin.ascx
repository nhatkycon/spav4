<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TinTuc_ChiTiet_Tin.ascx.cs" Inherits="lib_ui_web_tin_TinTuc_ChiTiet_Tin" %>
<%=txtPath%>
<div class="tin-view-item">
    <div class="tin-item-ten">
        <%=Item.Ten %>
    </div>
     <div class="tin-item-ngayTao">
        <%=Item.NgayTao.ToString("HH:mm:ss - dd/MM/yyyy") %>
    </div>
    <div class="tin-item-moTa">
        <%=Item.MoTa %>
    </div>
    <div class="tin-item-NoiDung">
        <%=Item.NoiDung %>
    </div>
    <div class="tin-item-tacGia">
        <%=Item.TacGia %>
    </div>
</div>
<div class="tin-view-bl">
    <div class="tin-view-bl-header">
    Bình luận   <span class="tin-view-bl-header-icon"></span>
    </div>
    <div class="tin-view-bl-body">
        <%=txtBl%>
    </div>
    <div class="tin-view-bl-posBox">
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td class="td-bl-header" valign="top">Tên:</td>
                <td valign="top">
                    <input class="input-bl Ten" />
                </td>
            </tr>
            <tr>
                <td class="td-bl-header" valign="top">Email:</td>
                <td valign="top">
                    <input class="input-bl Email" />
                </td>
            </tr>
            <tr>
                <td class="td-bl-header" valign="top">Mobile:</td>
                <td valign="top">
                    <input class="input-bl Mobile" />
                </td>
            </tr>
            <tr>
                <td class="td-bl-header" valign="top">Nội dung:</td>
                <td valign="top">
                    <textarea class="textarea-bl NoiDung" ></textarea>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">                                    
                    <a _ID="<%=Item.ID %>" href="javascript:;" data-type="1" class="bl-btn">Gửi bình luận</a><br />
                    <span class="bl-msg"></span>
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="tin-view-lienQuan">                    
    <div class="tin-view-lienQuan-header">
    Mới hơn
    </div>
    <div class="tin-view-lienQuan-body">
        <%=txtMoiHon%>
    </div>
</div>
<div class="tin-view-lienQuan tin-view-lienQuan-last">                    
    <div class="tin-view-lienQuan-header">
    Cũ hơn
    </div>
    <div class="tin-view-lienQuan-body">
        <%=txtCuHon%>
    </div>
</div>