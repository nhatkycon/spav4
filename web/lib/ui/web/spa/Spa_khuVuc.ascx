<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Spa_khuVuc.ascx.cs" Inherits="lib_ui_web_spa_Spa_khuVuc" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath%>
<div class="spa-list-left">
    <% foreach (var khuVuc in KhuVucs)
        {%>
        <a href="/Spa/<%=khuVuc.KyHieu %>/<%=khuVuc.ID.ToString() %>/" data-kv="<%=khuVuc.ID.ToString() %>" 
            class="spa-list-kv-item level-<%=khuVuc.Level.ToString() %> <%=Request["DM_ID"] == khuVuc.ID.ToString() ? " spa-list-kv-item-select" : "" %>"><%=khuVuc.Ten %></a>  
        <%} %>
</div>
<div class="spa-list-right">
    <%if(Item != null){ %>
    <div class="spa-list-header">
        <h1>Spa ở <%=Item.Ten %></h1>
        <p class="spa-list-header-desc">
            Có <b><%=SpaPager.Total.ToString() %></b> spa ở <b><%=Item.Ten %></b>
        </p>
    </div>
    <%} %>

    <% foreach (var item in SpaPager.List)
       {%>
    <div class="spa-list-item">
        <div class="spa-list-item-right">
            <a href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html" class="spa-list-item-btn">
                Đặt dịch vụ
            </a>
        </div>
        <a href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html" class="spa-list-item-img-box">
            <img src="/lib/up/i/<%=Lib.imgSize(item.Anh,"150x115") %>" class="spa-list-item-img"/>
        </a>
        <div class="spa-list-item-body">
            <a class="spa-list-item-ten" href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html"><%=item.Ten %></a>
            
            <span class="spa-list-item-diaChi">Địa chỉ: <%=item.DiaChi %></span>                        
        </div>
        <div class="spa-list-item-footer">
            <%if(item.Comments > 0){ %>
            <a class="spa-list-item-comments" href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html">Nhận xét của khách hàng (<%=item.Comments.ToString() %>)</a>
            <%} %>            
            <div class="spa-list-item-star">
                <div class="star-el" data-score="<%=item.Sao.ToString() %>"></div>
            </div>
        </div>
    </div>
       <%} %>
    <div class="spa-list-paging">
        <%=SpaPager.Paging %>        
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