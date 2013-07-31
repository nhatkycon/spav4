<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="DangKy-Spa.aspx.cs" Inherits="lib_pages_DangKy_Spa" %>
<%@OutputCache VaryByParam="*" Duration="86400" Location="ServerAndClient" %>

<%@ Register src="../ui/web/heThong/DangKy.ascx" tagname="DangKy" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:DangKy ID="DangKy1" runat="server" />
</asp:Content>

