<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Statics.master" AutoEventWireup="true" CodeFile="GioiThieu.aspx.cs" Inherits="lib_pages_GioiThieu" %>

<%@ Register src="../ui/web/heThong/GioiThieu.ascx" tagname="GioiThieu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head12" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <uc1:GioiThieu ID="GioiThieu1" runat="server" />
</asp:Content>

