<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DichVu_DanhMuc.ascx.cs" Inherits="lib_ui_web_dichVu_DichVu_DanhMuc" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="dvu-dm-pnl">
    <div class="dvu-dm-header">
        <div class="dvu-dm-hoiDap">
            <div class="dvu-dm-hoiDap-header">
                <a href="javascript:;" data-dv-id="<%=Item.ID %>" class="dvu-dm-hoiDap-header-more datCauHoiDichVuBtn">Đặt câp hỏi</a>
                <span class="dvu-dm-hoiDap-header-lbl">Hỏi đáp liên quan</span>
            </div>
            <ul class="dvu-dm-hoiDap-item">
                <%if (HoiDaps.Count > 0){ %>
                <% foreach (var item in HoiDaps)
                   {%>
                     <li>
                        <a class="dvu-dm-hoiDap-item-ten" href="/Hoi-dap-Spa/<%=item._DanhMuc.Ma %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html"><%=item.Ten %></a>
                    </li>   
                 <%  } %>
                            
                <%}else
                  { %>
                     <li>
                        <a class="dvu-dm-hoiDap-item-ten" href="javascript:;">Chưa có câu hỏi về dịch vụ này, bạn có thể là người đầu tiên hỏi</a>
                    </li> 
                 <% } %>
            </ul>
            <a href="/Hoi-dap-Spa/<%=Item.Alias %>/<%=Item.ID %>/" class="dvu-dm-hoiDap-more">Xem thêm</a>
        </div>
        <div class="dvu-dm-header-view">
            <a href="#" class="dvu-dm-header-views-img-box">
                <img src="/lib/up/i/<%=Lib.imgSize(Item.Anh,"170x150") %>" class="dvu-dm-header-views-img" />                
            </a>
            <a href="javascript:;" class="dvu-dm-header-views-ten">
            <%=Item.Ten %>
            </a>
            <%if(DichVuCons.Count > 1) {%>
            <div class="tags">
                <% foreach (var item in DichVuCons)
                   {%>
                    <%if(item.PID != 0)
                      {%>
                    <div class="ticket">
                        <span class="circle"></span>    
                        <a  title="<%= item.Ten %>" href="<%= domain %>/Dich-vu-Spa/<%= item.Alias %>/<%= item.ID.ToString() %>/" >
                            <%= item.Ten %>                            
                        </a>
                        </div>
                    <% } %>
                <%} %>                
            </div>
            <div class="dvu-dm-header-views-mota dvu-dm-header-views-mota-collaped">
                    <%=Item.Description %>                
                </div>  
            <%}else
              {%>                
                <div class="dvu-dm-header-views-mota dvu-dm-header-views-mota-collaped">
                    <%=Item.Description %>                
                </div>    
              <%} %>            
        </div>
    </div>
    <div class="dvu-dm-body"> 
        <div class="dvu-dm-body-l"> 
            <div class="dvu-dm-body-l-header">
                <span class="dvu-dm-body-l-header-title">
                Khu vực
                </span>
            </div>
            <div class="dvu-dm-body-l-body">
                <a href="javascript:;" data-kv="0" class="dvu-dm-body-l-dvu-item dvu-dm-body-l-dvu-item-select">Tất cả <span class="dvu-dm-body-l-dvu-item-count"><%=Pagers.Total %></span></a>
                <% foreach (var khuVuc in KhuVucs)
                   {%>
                    <a href="/Dich-vu-Spa/<%=Item.Alias %>-o-<%=Lib.Bodau(khuVuc.Ten) %>/<%=Item.ID %>/<%=khuVuc.ID %>.htm" data-kv="<%=khuVuc.ID.ToString() %>" class="dvu-dm-body-l-dvu-item level-<%=khuVuc.Level.ToString() %>"><%=khuVuc.Ten %></a>  
                   <%} %>
            </div>
        </div>     
        <div class="dvu-dm-body-r"> 
            <div class="dvu-dm-body-r-header">
                <a href="#" class="dvu-dm-body-r-header-title">
                Danh sách dịch vụ
                </a>
            </div>
            <div class="dvu-dm-body-r-body">
                <% foreach (var item in Pagers.List)
                           {%>                
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
                        <%if (!string.IsNullOrEmpty(item.MoTa)){ %>
                        <div class="dvu-item-mota">
                            <%=item.MoTa %>
                        </div>
                        <%} %>
                        <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-spa-ten"><%=item._Spa.Ten %> <span class="dvu-item-spa-baoDam" style="<%=item._Spa.Sao > 4 ? "" : "display: none;" %>">Spa bảo đảm</span></a>
                        <div class="dvu-item-star-box">
                            <div class="dvu-item-star star<%=item._Spa.Sao.ToString() %>"></div>
                        </div>
                        <span class="dvu-item-diaChi"><%=item._Spa.DiaChi %></span>
                        <span class="dvu-item-mobile"><%=item._Spa.Mobile %> <%=item._Spa.Phone %></span>
                        <%--<a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" class="dvu-item-link">Xem <% =ran.Next(1,20) %> ý kiến</a>--%>
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
</div>

<script>
    $(function() {
//        $('.dvu-dm-body-l-dvu-item').each(function () {
//            var item = $(this);
//            var kv = item.attr('data-kv');
//            var _ten = item.html();
//            if (item.hasClass('level-2')) {
//                item.html(_ten + ' (' + $('.dvu-dm-item[data-kv="' + kv + '"]').length + ')');
//            }
//            item.click(function () {
//                if (item.hasClass('dvu-dm-body-l-dvu-item-select'))
//                    return;
//                item.parent().find('.dvu-dm-body-l-dvu-item-select').removeClass('dvu-dm-body-l-dvu-item-select');
//                item.addClass('dvu-dm-body-l-dvu-item-select');
//                if(kv=='0') {
//                    $('.dvu-dm-item').show();
//                }
//                else {
//                    $('.dvu-dm-item').hide();
//                    $('.dvu-dm-item[data-kv="' + kv + '"]').show();
//                }
//            });
//        });
        $('.dvu-dm-header-views-mota').mouseenter(function() {
            var item = $(this);
            if (!item.hasClass('dvu-dm-header-views-mota-expaned')) {
                item.addClass('dvu-dm-header-views-mota-expaned');
            }
            item.removeClass('dvu-dm-header-views-mota-collaped');
            item.mouseleave(function() {
                item.removeClass('dvu-dm-header-views-mota-expaned');
                if (!item.hasClass('dvu-dm-header-views-mota-collaped')) {
                    item.addClass('dvu-dm-header-views-mota-collaped');
                }
            });
        });
        $('.dvu-dm-item').each(function (i) {
            var item = $(this);
            item.mouseenter(function() {
                if (!item.hasClass('dvu-dm-item-hover')) {
                    item.removeClass('dvu-dm-item-hover');
                    item.parent().find('.dvu-dm-item-hover').removeClass('dvu-dm-item-hover');
                    item.addClass('dvu-dm-item-hover');
                }
                
                item.mouseleave(function() {
                    item.removeClass('dvu-dm-item-hover');
                });
            });
        });
    });
</script>