<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="Khuyen_mai_view.aspx.cs" Inherits="lib_pages_Khuyen_mai_view" %>
<%@ Register src="../ui/web/khuyenMai/km_view.ascx" tagname="km_view" tagprefix="uc1" %>


<%@ Register src="../ui/web/spa/spa_view_small.ascx" tagname="spa_view_small" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:km_view ID="km_view1" runat="server" />
    <uc3:spa_view_small ID="spa_view1" runat="server" />
    <%--<uc2:spa_view ID="spa_view1" runat="server" />--%>
</asp:Content>

