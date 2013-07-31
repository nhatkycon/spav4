<%@ Control Language="C#" AutoEventWireup="true" CodeFile="spa_top_list.ascx.cs" Inherits="lib_ui_web_spa_spa_top_list" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>

<div class="top-spa-view-list">
    <div class="top-spa-view-list-header">
        Top Spa
    </div>
    <div class="top-spa-view-list-body">
        <a href="javascript:;" class="top-spa-view-list-leftBtn"></a>
        <div class="top-spa-view-list-content">
            <div class="top-spa-view-list-content-rel">
                <% foreach (var item in Tops)
                    {%>
                    <div class="top-spa-view-list-item">
                        <a class="top-spa-view-img-list-item-box" href="/Top-Spa/<%=item.Alias %>/<%=item.ID.ToString() %>/">
                            <img class="top-spa-view-list-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh,"full") %>"/>
                        </a>
                        <a class="top-spa-view-list-item-ten" href="/Top-Spa/<%=item.Alias %>/<%=item.ID.ToString() %>/">
                            <%=item.Ten %>
                        </a>
                    </div>
                <%} %>
            </div>
        </div>
        <a href="javascript:;" class="top-spa-view-list-rightBtn"></a>        
    </div>        
</div>
<div class="top-view-left">
    <div class="top-spa-view">
        <div class="top-spa-view-header">
            <img class="top-spa-view-img-box" src="/lib/up/i/<%=Lib.imgSize(Item.Anh,"full") %>"/>
            <h1 class="top-spa-view-ten"><%=Item.Ten %></h1>
            <div class="top-spa-view-mota"><%=Item.Description %></div>
        </div>
        <div class="top-spa-view-listSpa">
        <% foreach (var item in Spas)
           {%>
            <div class="spa-list-top-spa-item">
                <div class="spa-list-top-spa-item-right">
                    <a href="/Spa/<%=item._Spa.Alias %>/<%=item.ID.ToString() %>.html" class="spa-list-top-spa-item-btn">
                        Đặt dịch vụ
                    </a>
                </div>
                <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="spa-list-top-spa-item-img-box">
                    <img src="/lib/up/i/<%=Lib.imgSize(item._Spa.Anh,"150x115") %>" class="spa-list-top-spa-item-img"/>
                </a>
                <div class="spa-list-top-spa-item-body">
                    <a class="spa-list-top-spa-item-ten" href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html"><%=item._Spa.Ten %></a>
                    <span class="spa-list-top-spa-item-diaChi">Địa chỉ: <%=item._Spa.DiaChi %></span>     
                    <div class="spa-list-top-spa-item-intro">
                        <%if(!string.IsNullOrEmpty(item.MoTa)) {%>
                        <div class="spa-list-top-spa-item-intro-mota">
                        <%=item.MoTa %>                        
                        </div>

                        <div class="spa-list-top-spa-item-intro-noiDung">
                        <%=item.NoiDung %>
                        </div>
                        <%} %>
                    </div>
                </div>
                <div class="spa-list-top-spa-item-footer">
                    <%if (item._Spa.Comments > 0)
                      { %>
                    <a class="spa-list-top-spa-item-comments" href="/Spa/<%=item._Spa.Alias %>/<%=item.ID.ToString() %>.html">Nhận xét của khách hàng (<%=item._Spa.Comments.ToString() %>)</a>
                    <%} %>
                    <div class="spa-list-item-star">
                        <div class="star-el" data-score="<%=item._Spa.Sao.ToString() %>"></div>
                    </div>
                </div>
            </div>
        <%} %>    
        </div>
    </div>
</div>

<div class="spa-list-adv spa-list-spa-view-adv">
    <% foreach (var item in QuangCaos)
       {%>
        <a target="_blank" class="spa-list-adv-item"href="<%=item.Url %>">
            <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>

<script>
    $('.top-spa-view-list-leftBtn').click(function () {
        var item = $(this);
        var pnl = item.parent().find('.top-spa-view-list-content');
        $(pnl).scrollTo('-=888px', 500);
    });
    $('.top-spa-view-list-rightBtn').click(function () {
        var item = $(this);
        var pnl = item.parent().find('.top-spa-view-list-content');
        $(pnl).scrollTo('+=888px', 500);
    });
</script>