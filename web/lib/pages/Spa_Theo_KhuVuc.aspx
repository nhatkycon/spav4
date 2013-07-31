<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="Spa_Theo_KhuVuc.aspx.cs" Inherits="lib_pages_Spa_Theo_KhuVuc" %>
<%@ Register src="../ui/web/spa/Spa_khuVuc.ascx" tagname="Spa_khuVuc" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Spa_khuVuc ID="Spa_khuVuc1" runat="server" />
</asp:Content>

