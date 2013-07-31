<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="HoiDap_DanhMuc.aspx.cs" Inherits="lib_pages_HoiDap_DanhMuc" %>

<%@ Register src="../ui/web/hoiDap/ListMacDinh.ascx" tagname="ListMacDinh" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ListMacDinh ID="ListMacDinh1" runat="server" />
</asp:Content>

