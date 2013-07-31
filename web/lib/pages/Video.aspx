<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Video.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="lib_pages_Video" %>

<%@ Register src="../ui/web/video/List.ascx" tagname="List" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc1:List ID="List1" runat="server" />
</asp:Content>

