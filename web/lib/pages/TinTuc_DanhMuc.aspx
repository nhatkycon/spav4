<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/TinTuc.master" AutoEventWireup="true" CodeFile="TinTuc_DanhMuc.aspx.cs" Inherits="lib_pages_TinTuc_DanhMuc" %>

<%@ Register src="../ui/web/tin/TinTuc_DanhMuc_List.ascx" tagname="TinTuc_DanhMuc_List" tagprefix="uc1" %>

<%@ Register src="../ui/web/tin/TinTuc_DanhMuc_PlaceHolder.ascx" tagname="TinTuc_DanhMuc_PlaceHolder" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc2:TinTuc_DanhMuc_PlaceHolder ID="TinTuc_DanhMuc_PlaceHolder1" 
        runat="server" />
</asp:Content>

