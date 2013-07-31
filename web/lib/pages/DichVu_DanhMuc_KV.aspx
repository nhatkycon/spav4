<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/DichVu.master" AutoEventWireup="true" CodeFile="DichVu_DanhMuc_KV.aspx.cs" Inherits="lib_pages_DichVu_DanhMuc_KV" %>

<%@ Register src="../ui/web/dichVu/DichVu_DanhMuc_KhuVuc.ascx" tagname="DichVu_DanhMuc_KhuVuc" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc1:DichVu_DanhMuc_KhuVuc ID="DichVu_DanhMuc_KhuVuc1" runat="server" />
</asp:Content>

