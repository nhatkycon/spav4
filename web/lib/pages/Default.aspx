<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_Default" %>

<%@ Register src="../ui/web/tin/home_slides.ascx" tagname="home_slides" tagprefix="uc1" %>
<%@ Register src="../ui/web/tin/home_tin.ascx" tagname="home_tin" tagprefix="uc3" %>
<%@ Register src="../ui/web/heThong/left_menu.ascx" tagname="left_menu" tagprefix="uc5" %>

<%@ Register src="../ui/web/spa/home_top.ascx" tagname="home_top" tagprefix="uc6" %>

<%@ Register src="../ui/web/spa/home_moi.ascx" tagname="home_moi" tagprefix="uc7" %>

<%@ Register src="../ui/web/khuyenMai/home.ascx" tagname="home" tagprefix="uc8" %>

<%@ Register src="../ui/web/hoiDap/home.ascx" tagname="home" tagprefix="uc9" %>
<%@ Register src="../ui/web/heThong/adv_home_right_bottom.ascx" tagname="adv_home_right_bottom" tagprefix="uc10" %>
<%@ Register src="../ui/web/advs/home_acList_1.ascx" tagname="home_acList_1" tagprefix="uc11" %>

<%@ Register src="../ui/web/advs/home_acList_2.ascx" tagname="home_acList_2" tagprefix="uc12" %>
<%@ Register src="../ui/web/advs/home_topLeft.ascx" tagname="home_topLeft" tagprefix="uc13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="home-mnu-left">
            <uc5:left_menu ID="left_menu1" runat="server" />
    </div>
    <div class="slides">
        <uc1:home_slides ID="home_slides" runat="server" />
    </div>
    <div class="home-action-pnl">
        <uc12:home_acList_2 ID="home_adv_ac1" runat="server" />
    </div>
    <div class="home-adv-top-left">
        <uc13:home_topLeft ID="home_topLeft1" runat="server" />
    </div>
    <div class="home-adv-top-center-pnl">
        <uc11:home_acList_1 ID="home_adv_ac2" runat="server" />          
    </div>
    <div class="home-adv-top-center-pnl">                
        <uc8:home ID="home1" runat="server" />
        <uc7:home_moi ID="home_moi1" runat="server" />
        <uc6:home_top ID="home_top1" runat="server" />
    </div>
    <div class="home-adv-top-center-pnl">
        <uc11:home_acList_1 ID="home_adv_ac3" runat="server" />          
    </div>
        <div class="home-adv-top-center-pnl">
        <div class="home-content-right-pnl">
            <uc9:home ID="home2" runat="server" />
            <uc10:adv_home_right_bottom ID="adv_home_right_bottom1" runat="server" />
        </div>
        <uc3:home_tin ID="home_tin1" runat="server" />
    </div>
</asp:Content>

