<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home_tin.ascx.cs" Inherits="lib_ui_web_tin_home_tin" %>
<%@ Import Namespace="linh.common" %>
<div class="home-tin-panel">
    <div class="home-tin-big">
        <div class="home-tin-header">
            <a class="home-mdl-tin-header-title" href="/Tin-Tuc/Thong-bao-Tap-chi-spa/15740/">Tin mới</a> 
        </div>       
        <div class="home-tin-body">
            <%=txtTin %>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>
</div>
<div class="home-adv-insideTin-center-pnl">
    <% if (QuangCao1!=null){ %>
        <% var i = 1; %>
        <% foreach (var item in QuangCao1)
            {%>
                <a target="_blank" class="home-adv-insideTin-center-item<%= (i==QuangCao1.Count ? " home-adv-insideTin-center-itemLast" : "") %>"href="<%=item.Url %>">
                    <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
                </a>
            <% i++; %>
        <% } %>
    <%} %>
</div>
<div class="home-tin-panel">
    <div class="home-tin-big">
        <div class="home-tin-header">
            <a class="home-mdl-tin-header-title" href="/Tin-Tuc/Bi-quyet-lam-dep/15742/">Bí quyết làm đẹp</a> 
        </div>       
        <div class="home-tin-body">
            <%=txtDichVu%>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>
</div>
<div class="home-adv-insideTin-center-pnl">
    <% if (QuangCao1!=null){ %>
        <% var i = 1; %>
        <% foreach (var item in QuangCao2)
            {%>
                <a target="_blank" class="home-adv-insideTin-center-item<%= (i==QuangCao1.Count ? " home-adv-insideTin-center-itemLast" : "") %>"href="<%=item.Url %>">
                    <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
                </a>
            <% i++; %>
        <% } %>
    <%} %>
</div>
<div class="home-tin-panel">
    <div class="home-tin-big">
        <div class="home-tin-header">
            <a class="home-mdl-tin-header-title" href="/Tin-Tuc/Goc-spa-tai-nha/15743/">Góc spa tại nhà</a> 
        </div>       
        <div class="home-tin-body">
            <%=txtAlbumAnh%>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>
</div>
<div class="home-adv-insideTin-center-pnl">
    <% if (QuangCao1!=null){ %>
        <% var i = 1; %>
        <% foreach (var item in QuangCao3)
            {%>
                <a target="_blank" class="home-adv-insideTin-center-item<%= (i==QuangCao1.Count ? " home-adv-insideTin-center-itemLast" : "") %>"href="<%=item.Url %>">
                    <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
                </a>
            <% i++; %>
        <% } %>
    <%} %>
</div>
<div class="home-tin-panel">
    <div class="home-tin-big">
        <div class="home-tin-header">
            <a class="home-mdl-tin-header-title" href="/Tin-Tuc/Trai-nghiem-spa/15744/">Trải nghiệm Spa</a> 
        </div>       
        <div class="home-tin-body">
            <%=txtSanPham%>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>
</div>
<div class="home-adv-insideTin-center-pnl">
    <% if (QuangCao1!=null){ %>
        <% var i = 1; %>
        <% foreach (var item in QuangCao4)
            {%>
                <a target="_blank" class="home-adv-insideTin-center-item<%= (i==QuangCao1.Count ? " home-adv-insideTin-center-itemLast" : "") %>"href="<%=item.Url %>">
                    <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
                </a>
            <% i++; %>
        <% } %>
    <%} %>
</div>
<div class="home-tin-panel">
    <div class="home-tin-big">
        <div class="home-tin-header">
            <a class="home-mdl-tin-header-title" href="/Tin-Tuc/Spa-gioi-thieu/15741/">Spa giới thiệu</a> 
        </div>       
        <div class="home-tin-body">
            <%=txtCongNghe%>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>
</div>

<%--<div class="home-tin-panel">
    <div class="home-mdl-tin-header">
        <span class="home-mdl-tin-header-title">Tin tức</span>
    </div>
    <div class="home-mdl-tin-box"> 
        <div class="home-mdl-tin-content">
            <div class="home-tin-small">
                <div class="home-tin-header"><a href="/Tin-Tuc/Bi-quyet-lam-dep/15742/">Bí quyết làm đẹp</a>        
                </div>       
                <div class="home-tin-body">
                    <%=txtDichVu %>
                </div>
            </div>
            <div class="home-tin-small home-tin-small-last">
                <div class="home-tin-header"><a href="/Tin-Tuc/Goc-spa-tai-nha/15743/">Góc spa tại nhà</a> 
                </div>       
                <div class="home-tin-body">
                    <%=txtAlbumAnh %>
                </div>
            </div>
        </div>
        <div class="home-mdl-tin-content">
            <div class="home-tin-small">
                <div class="home-tin-header"><a href="/Tin-Tuc/Trai-nghiem-spa/15744/">Trải nghiệm Spa</a> 
                </div>       
                <div class="home-tin-body">
                    <%=txtSanPham %>
                </div>
            </div>
            <div class="home-tin-small home-tin-small-last">
                <div class="home-tin-header"><a href="/Tin-Tuc/Spa-gioi-thieu/15741/">Spa giới thiệu</a> 
                </div>       
                <div class="home-tin-body">
                    <%=txtCongNghe %>
                </div>
            </div>
        </div>
        <div class="home-mdl-tin-footer" _ref="0">
        </div>
    </div>                
</div>--%>