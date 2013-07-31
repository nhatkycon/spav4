<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="HoiDap_View.aspx.cs" Inherits="lib_pages_HoiDap_View" %>

<%@ Register src="../ui/web/hoiDap/hoiDap_view.ascx" tagname="hoiDap_view" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:hoiDap_view ID="hoiDap_view1" runat="server" />
</asp:Content>

