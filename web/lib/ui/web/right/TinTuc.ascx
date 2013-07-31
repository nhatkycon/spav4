<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TinTuc.ascx.cs" Inherits="lib_ui_web_right_TinTuc" %>
<%@ Register src="TinTuc_PlaceHolder.ascx" tagname="TinTuc_PlaceHolder" tagprefix="uc1" %>
<div class="home-adv-r">
    <%=txtAdv %>
</div>
<div class="home-video">
    <uc1:TinTuc_PlaceHolder ID="TinTuc_PlaceHolder1" runat="server" />
</div>