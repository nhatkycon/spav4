<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="Spa_moi_khai_truong.aspx.cs" Inherits="lib_pages_Spa_moi_khai_truong" %>

<%@ Register src="../ui/web/spa/spa_moi_list.ascx" tagname="spa_moi_list" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:spa_moi_list ID="spa_moi_list1" runat="server" />
</asp:Content>

