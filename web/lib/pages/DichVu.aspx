<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="DichVu.aspx.cs" Inherits="lib_pages_DichVu" %>

<%@ Register src="../ui/web/dichVu/DichVuList.ascx" tagname="DichVuList" tagprefix="uc1" %>

<%@ Register src="../ui/web/dichVu/DichVu_MacDinh.ascx" tagname="DichVu_MacDinh" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:DichVuList ID="DichVuList1" runat="server" />
    <uc2:DichVu_MacDinh ID="DichVu_MacDinh1" runat="server" />
</asp:Content>

