<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="Spa_view.aspx.cs" Inherits="lib_pages_Spa_view" %>
<%@ Register src="../ui/web/spa/spa_view.ascx" tagname="spa_view" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:spa_view ID="spa_view1" runat="server" />
</asp:Content>

