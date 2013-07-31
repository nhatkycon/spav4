<%@ Control Language="C#" AutoEventWireup="true" CodeFile="spa_top.ascx.cs" Inherits="lib_ui_web_spa_spa_top" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath%>
<div class="top-spa-adv">
    <% foreach (var item in QuangCaoTops)
        {%>
        <a target="_blank" class="top-spa-adv-item"href="<%=item.Url %>">
            <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>
<div class="top-spa-left">    
    <h1 class="top-spa-header">
        Top Spa
    </h1>
    <div class="top-spa-list">
    <% foreach (var item in Tops)
       {%>
    
        <div class="top-spa-item">
            <a class="top-spa-item-img-box" href="/Top-Spa/<%=item.Alias %>/<%=item.ID.ToString() %>/">
                <img class="top-spa-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh,"full") %>"/>
            </a>
            <a class="top-spa-item-ten" href="/Top-Spa/<%=item.Alias %>/<%=item.ID.ToString() %>/">
                <%=item.Ten %>
            </a>
        </div>
    
    <%} %>
    </div>
</div>
<div class="spa-list-adv">
    <% foreach (var item in QuangCaos)
       {%>
        <a target="_blank" class="spa-list-adv-item"href="<%=item.Url %>">
            <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>