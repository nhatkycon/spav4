<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/TinTuc.master" AutoEventWireup="true" CodeFile="TinTuc_Tin_ChiTiet.aspx.cs" Inherits="lib_pages_TinTuc_Tin_ChiTiet" %>

<%@ Register src="../ui/web/tin/TinTuc_ChiTiet_Tin.ascx" tagname="TinTuc_ChiTiet_Tin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc1:TinTuc_ChiTiet_Tin ID="TinTuc_ChiTiet_Tin1" runat="server" />
</asp:Content>

