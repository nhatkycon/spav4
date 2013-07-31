<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="TopSpa.aspx.cs" Inherits="lib_pages_TopSpa" %>

<%@ Register src="../ui/web/spa/spa_top.ascx" tagname="spa_top" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:spa_top ID="spa_top1" runat="server" />
</asp:Content>

