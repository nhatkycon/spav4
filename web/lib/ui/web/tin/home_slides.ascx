<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home_slides.ascx.cs" Inherits="lib_ui_web_tin_home_slides" %>
<%@ Import Namespace="linh.common" %>
<div class="container">
    <img src="<%=ResolveUrl("~/lib/css/web/images-with-captions/img/new-ribbon.png") %>" width="112" height="112" alt="New Ribbon" class="slides-ribbon">
    <div class="home-tin-slides">
	    <div class="slides_container">		
		    <% foreach (var item in List)
               {%>
              <div class="slide">
                    <a href="/Tin-tuc/<%=item.DM_Ma %>/<%=item.DM_ID %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html" target="_blank">
                    <img class="slide-item-img" src="/lib/up/tintuc/<%=Lib.imgSize(item.Anh, "280x210") %>"></a>
                    <div class="caption">
                    <p><b><%=item.MoTa %></b><br/><%=item.Ten %></p>
                    </div>
                </div>
               <%} %>
	    </div>
	    <a href="#" class="prev"><img src="<%=ResolveUrl("~/lib/css/web/images-with-captions/img/arrow-prev.png")%>" width="24" height="43" alt="Arrow Prev"></a>
	    <a href="#" class="next"><img src="<%=ResolveUrl("~/lib/css/web/images-with-captions/img/arrow-next.png")%>" width="24" height="43" alt="Arrow Next"></a>
    </div>
</div>
<script>
    $(function () {
        $('.home-tin-slides').slides({
            preload: true,
            preloadImage: '<%=ResolveUrl("~/lib/css/web/images-with-captions/img/loading.gif")%>',
            play: 2500,
            pause: 2500,
            hoverPause: true,
            animationStart: function (current) {
                //$('.caption').animate({
                //    bottom: -35
                //}, 100);
            },
            animationComplete: function (current) {
                $('.caption').animate({
                    bottom: 0
                }, 200);
            },
            slidesLoaded: function () {
                //$('.caption').animate({
                //    bottom: 0
                //}, 200);
            }
        });
    });
</script>