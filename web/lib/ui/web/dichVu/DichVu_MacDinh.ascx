<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DichVu_MacDinh.ascx.cs" Inherits="lib_ui_web_dichVu_DichVu_MacDinh" %>
<%@ Import Namespace="linh.common" %>
<div class="dvu-list-body">
    <div class="dvu-list-box">
        <div class="dvu-dm-body-r-header">
            <a href="#" class="dvu-dm-body-r-header-title">
            Danh sách dịch vụ
            </a>
        </div>
        <div class="dvu-dm-body-r-body">
        <% foreach (var item in Pagers.List){%>                
            <div data-kv="<%=item._Spa.KV_ID.ToString() %>" class="dvu-dm-item<%=item.KM ? " dvu-dm-item-km" : "" %>">
                <div class="dvu-item-rPnl">
                     <%if (item.Gia!=0)
                        { %>
                    <span class="dvu-item-gia"><%= Lib.TienVietNam(item.KM ? item.GiaKm : (item.Gia)) %></span>
                    <% } %>
                    <a href="javascript:;"  data-id="<%=item.ID %>" data-type="1" class="dvu-item-datBtn ddv-btn">Đặt dịch vụ</a>
                    <a href="ymsgr:sendim?danhbaspa" class="dvu-item-hoiBtn">Hỏi nhân viên</a>
                </div>
                <div href="#" class="dvu-item-img-box">
                    <%--<span class="dvu-item-img-hoverBox">
                        <span class="dvu-item-acceptGift"></span>
                    </span>--%>
                    <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-spa-ten">
                        <img src="/lib/up/i/<%=Lib.imgSize(item._Spa.Anh,"150x115") %>" class="dvu-item-img" />                              
                    </a>
                    <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html#map" class="dvu-item-link dvu-item-link-map">Xem bản đồ</a>
                </div>
                <div class="dvu-item-main">
                    <a href="/Dich-vu-Spa/<%= Lib.Bodau(item.Ten) %>/<%= item.ID.ToString() %>.html" title="<%=item.Ten %>" class="dvu-item-ten"><%=item.Ten %></a>
                    <%if(!string.IsNullOrEmpty(item.MoTa))
                      { %>
                    <div class="dvu-item-mota">
                        <%= item.MoTa %>
                    </div>
                    <% } %>
                    <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-spa-ten"><%=item._Spa.Ten %> <span class="dvu-item-spa-baoDam" style="<%=item._Spa.Sao > 4 ? "" : "display: none;" %>">Spa bảo đảm</span></a>
                    <div class="dvu-item-star-box">
                        <div class="dvu-item-star star<%=item._Spa.Sao.ToString() %>"></div>
                    </div>
                    <span class="dvu-item-diaChi"><%=item._Spa.DiaChi %></span>
                    <span class="dvu-item-mobile"><%=item._Spa.Mobile %> <%=item._Spa.Phone %></span>
                    <%--<a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-link">Xem <%=ran.Next(1,20) %>  ý kiến</a>--%>
                    <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-link">Xem thông tin về Spa</a>
                </div>
            </div>                                
        <%} %> 
            <div class="dvu-dm-body-r-body-paging">
                    <%=Pagers.Paging %>
            </div>
        </div>

    </div>
</div>
<div class="dvu-list-adv">
    <% foreach (var item in QuangCaos)
       {%>
        <a target="_blank" class="dvu-list-adv-item"href="<%=item.Url %>">
            <img class="dvu-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>
<script>
    $('.dvu-dm-item').each(function (i) {
        var item = $(this);
        item.mouseenter(function () {
            if (!item.hasClass('dvu-dm-item-hover')) {
                item.removeClass('dvu-dm-item-hover');
                item.parent().find('.dvu-dm-item-hover').removeClass('dvu-dm-item-hover');
                item.addClass('dvu-dm-item-hover');
            }

            item.mouseleave(function () {
                item.removeClass('dvu-dm-item-hover');
            });
        });
    });
</script>