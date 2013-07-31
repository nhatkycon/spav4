<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/DichVu.master" AutoEventWireup="true" CodeFile="DichVu_DanhMuc.aspx.cs" Inherits="lib_pages_DichVu_DanhMuc" %>
<%@ Register src="../ui/web/dichVu/DichVu_DanhMuc.ascx" tagname="DichVu_DanhMuc" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc1:DichVu_DanhMuc ID="DichVu_DanhMuc1" runat="server" />
</asp:Content>

