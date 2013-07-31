<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home_topLeft.ascx.cs" Inherits="lib_ui_web_advs_home_topLeft" %>
<%@ Import Namespace="linh.common" %>
<% if (QuangCaos!=null){ %>
    <% foreach (var item in QuangCaos)
        {%>
            <a target="_blank" class="home-adv-top-left-item" href="<%=item.Url %>">
                <img class="top-spa-adv-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
            </a>
    <% } %>
<%} %>