<%@ Control Language="C#" AutoEventWireup="true" CodeFile="navi_top.ascx.cs" Inherits="lib_ui_web_heThong_navi_top" %>
<%@ Import Namespace="docsoft" %>
<div class="logo-pnl">
<%=logo %>
</div>
<div class="search-pnl-box search-pnl-focus">
    <div class="search-pnl">
        <div class="search-pnl-item">
            <span class="search-item-label">Dịch vụ</span>
            <input class="search-item-txt search-item-txt-DVU" />
        </div>
        <div class="search-pnl-item">
            <span class="search-item-label">Địa điểm</span>
            <input class="search-item-txt search-item-txt-QUAN" />
        </div>
        <a href="javascript:;" class="search-btn">Tìm</a>
    </div>
    
</div>
<div class="top-right">
    <%if(Security.IsAuthenticated()){ %>
        <a href="/lib/pages/CaNhan.aspx" class="topBar-navigation-item icon-dvu"><span class="icon"></span><span class="icon-ten"><%=ten %></span></a>
        <%--<a href="/mem/<%=Security.Username %>/" class="topBar-navigation-item icon-khang item-icon-vietBai"><span class="icon"></span><span class="icon-ten">Cá nhân</span></a>--%>
        <a href="javascript:;" class="topBar-navigation-item icon-khang item-icon-thoat"><span class="icon"></span><span class="icon-ten">Thoát</span></a>
    <%}else{ %>
        <a href="javascript:;" class="topBar-navigation-item icon-dvu item-icon-dangNhap"><span class="icon"></span><span class="icon-ten">Đăng ký/ Đăng nhập</span></a>
    <%} %>
</div>
<div class="navi-top">
    <ul>
        <%=txt %>
    </ul>
</div>
