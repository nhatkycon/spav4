<%@ Control Language="C#" AutoEventWireup="true" CodeFile="spa_moi_list.ascx.cs" Inherits="lib_ui_web_spa_spa_moi_list" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="spa-moi-khai-truong-left">
    <% foreach (var item in QuangCaosTop)
        {%>
        <a target="_blank" class="spa-moi-khai-truong-adv-item"href="<%=item.Url %>">
            <img class="spa-moi-khai-truong-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>  
    <div class="top-spa-view-listSpa">
    <% foreach (var item in List)
       {%>
          <div class="spa-list-top-spa-item">
            <div class="spa-list-top-spa-item-right">
                <a href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html" class="spa-list-top-spa-item-btn">
                    Đặt dịch vụ
                </a>
            </div>
            <a href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html" class="spa-list-top-spa-item-img-box">
                <img src="/lib/up/i/<%=Lib.imgSize(item.Anh,"150x115") %>" class="spa-list-top-spa-item-img"/>
            </a>
            <div class="spa-list-top-spa-item-body">
                <a class="spa-list-top-spa-item-ten" href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html"><%=item.Ten %></a>
            
                <span class="spa-list-top-spa-item-diaChi">Địa chỉ: <%=item.DiaChi %></span>                        
            </div>
            <div class="spa-list-top-spa-item-footer">
                <%if(item.Comments > 0){ %>
                <a class="spa-list-top-spa-item-comments" href="/Spa/<%=item.Alias %>/<%=item.ID.ToString() %>.html">Nhận xét của khách hàng (<%=item.Comments.ToString() %>)</a>
                <%} %>
                <div class="spa-list-item-star">
                    <div class="star-el" data-score="<%=item.Sao.ToString() %>"></div>
                </div>
            </div>
        </div>
       <%} %>
    </div>
</div>
<div class="spa-moi-khai-truong-right">
    <% foreach (var item in QuangCaos)
       {%>
        <a target="_blank" class="spa-list-adv-item"href="<%=item.Url %>">
            <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>
