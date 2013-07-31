<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="TopSpa_List.aspx.cs" Inherits="lib_pages_TopSpa_List" %>

<%@ Register src="../ui/web/spa/spa_top_list.ascx" tagname="spa_top_list" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:spa_top_list ID="spa_top_list1" runat="server" />
</asp:Content>

