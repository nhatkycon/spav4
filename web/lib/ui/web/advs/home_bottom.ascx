<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home_bottom.ascx.cs" Inherits="lib_ui_web_advs_home_bottom" %>
<%@ Import Namespace="linh.common" %>
<% if (QuangCaos!=null){ %>
        <% var i = 1; %>
        <% foreach (var item in QuangCaos)
            {%>
            <a target="_blank" class="home-action-item<%= (i==QuangCaos.Count ? " home-action-itemLast" : "") %>"href="<%=item.Url %>">
                <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
            </a>
        <% i++; %>
        <% } %>
<%} %>