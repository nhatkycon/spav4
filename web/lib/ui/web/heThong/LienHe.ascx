<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LienHe.ascx.cs" Inherits="lib_ui_web_heThong_LienHe" %>
<%=txt%>
<div class="tin-view-bl">
    <div class="tin-view-bl-header">
    Liên hệ   <span class="tin-view-bl-header-icon"></span>
    </div>
    <div class="tin-view-bl-body">
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
                    <a href="javascript:;" _ID="" class="bl-btn">Gửi liên hệ</a><br />
                    <span class="bl-msg"></span>
                </td>
            </tr>
        </table>
    </div>
</div>