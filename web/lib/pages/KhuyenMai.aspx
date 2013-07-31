<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="KhuyenMai.aspx.cs" Inherits="lib_pages_KhuyenMai" %>

<%@ Register src="../ui/web/dichVu/DichVu_KhuyenMai.ascx" tagname="DichVu_KhuyenMai" tagprefix="uc1" %>

<%@ Register src="../ui/web/khuyenMai/MacDinh.ascx" tagname="MacDinh" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc2:MacDinh ID="MacDinh1" runat="server" />
</asp:Content>

