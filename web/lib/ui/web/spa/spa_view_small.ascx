<%@ Control Language="C#" AutoEventWireup="true" CodeFile="spa_view_small.ascx.cs" Inherits="lib_ui_web_spa_spa_view_small" %>
<%@ Import Namespace="linh.common" %>
<div class="spa-view-header">
    <div class="spa-header-right-pnl">
        <%--<div class="fb-like" data-href="<% = Request.Url.AbsoluteUri %>" data-send="false" data-width="200" data-show-faces="true"></div>--%>
        <%if(Item.BaoDam){ %>
            <a href="/Tin-tuc/Danh-cho-quan-ly-spa/15745/Spa-dam-bao-la-gi/54.html" class="spa-baoDam"></a>
        <%} %>
        <a href="" class="loaiThanhVien loaiThanhVien-<%=Item.LoaiThanhVien %>"></a>
    </div>
    <div class="spa-header-left-pnl">
        <h3 class="spa-view-ten">
           <%=Item.Ten %> <div class="fb-like" data-href="http://tapchispa.com/Spa/<%=Item.Alias %>/<%=Item.ID %>.html" data-layout="button_count"  data-send="false" data-width="200" data-show-faces="false"></div>
        </h3>
        
        <p>
            <span class="spa-icon spa-icon-diaChi"></span>
            <%=Item.DiaChi %>
        </p>
        <p>
          <span class="spa-icon spa-icon-mobile"></span>  Điện thoại: <%=Item.Phone %> <%=Item.Mobile %>
        </p>
    </div>
</div>
<div class="spa-view-body">
    <div class="spa-view-tabs">
        <a href="javascript:;" class="spa-view-tabs-item spa-view-tabs-item-active">Giới thiệu</a>
        <a href="javascript:;" class="spa-view-tabs-item">Dịch vụ</a>
        <a href="javascript:;" class="spa-view-tabs-item">Khuyến mãi</a>
        <a href="javascript:;" class="spa-view-tabs-item">Nhận xét từ khách hàng (<%=Comments.Count.ToString() %>)</a>
        <a href="javascript:;" class="spa-view-tabs-item">Địa chỉ & Liên hệ</a>
    </div>
    <div class="spa-view-body-box">
        <div class="spa-view-body-item spa-view-body-item-active">
            <%if(Item._SpaAnh.Count > 0){ %>                    
            <div class="spa-view-slideshow">
                <div class="spa-view-slideshow-imgbox">
                    <img class="spa-view-slideshow-img" src="/lib/up/i/<%=Lib.imgSize(Item._SpaAnh[0].Anh,"full") %>"/>               
                    <div class="spa-view-slideshow-caption">
                        <%=Item._SpaAnh[0].Ten %>
                    </div>
                </div>
                <div class="spa-view-slideshow-thumnbails">
                    <a href="javascript:;" class="spa-view-slideshow-leftBtn">
                    </a>
                    <div class="spa-view-slideshow-thumnbails-box">
                        <div class="spa-view-slideshow-thumnbails-box-rel">
                            <asp:Repeater runat="server" ID="rptAnh1">
                                <ItemTemplate>
                                    <a href="javascript:;" class="spa-view-slideshow-thumnbails-item" >
                                        <img data-ten="<%#Eval("Ten") %>" data-full="/lib/up/i/<%# Lib.imgSize(Eval("Anh").ToString(),"full") %>" class="spa-view-slideshow-thumnbails-item-img" src="/lib/up/i/<%# Lib.imgSize(Eval("Anh").ToString(),"170x150") %>"/>                                                            
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <a href="javascript:;" class="spa-view-slideshow-rightBtn">
                    </a>
                </div>
            </div>
            <%} %>
            <div class="spa-view-noiDung">
                <%=Item.NoiDung %>                
            </div>
        </div>    
        <div class="spa-view-body-item">
            <h2>Danh sách dịch vụ của <%=Item.Ten %></h2>
            <% int Stt = 1; %>
            
                <div class="spa-view-dichVuList">
                    <ul class="DanhSachDichVuList">
                    <% foreach (var item in DanhMucs) {%>            
                      <% var listDv = from p in Item._SpaDichVu
                      where p.DM_ID == item.Key
                      select p;  %>      
                            <%if (listDv.Count() > 0){ %>
                            <li class="ds-item ds-header">
                                <ul>
                                    <li class="item-SoLuong"></li>
                                    <li class="item-Ten"><% = item.Value %></li>
                                    <li class="item-DonGia">Giá</li>
                                    <li class="item-DV_Ten">Thời gian</li>
                                </ul>
                            </li>
                            <% foreach (var spaDichVu in listDv)
                               {%>
                                <li class="ds-item">
                                    <ul>
                                        <li class="item-SoLuong"><%=Stt.ToString() %></li>
                                        <li class="item-Ten">
                                            <a href="javascript:;" class="dvu-list-item-ten">
                                                <%=spaDichVu.Ten %> <br/>
                                            </a>
                                            <div class="dvu-list-item-noiDung">
                                                <strong>
                                                    <i>
                                                        <%=spaDichVu.MoTa %>
                                                    </i>
                                                </strong>
                                                <%=spaDichVu.NoiDung %>
                                            </div>
                                        </li>
                                        <li class="item-DonGia">
                                            <%if(spaDichVu.Gia != 0){ %>
                                            <%=Lib.TienVietNam(spaDichVu.Gia) %>
                                            <%} %>
                                        </li>
                                        <li class="item-DV_Ten"><%=spaDichVu.DonVi %></li>
                                        <li class="item-DV_Ten">
                                            <a data-id="<%=spaDichVu.ID %>" data-type="1" href="javascript:;" class="dvu-book-btn ddv-btn">
                                                Đặt dịch vụ
                                                <span class="spa-icon spa-icon-book"></span>
                                            </a>
                                        </li>
                                    </ul>
                                </li>
                                <% Stt++; %>
                               <% } %>
                            <%} %>
                        <%} %>
                    </ul>
                </div>
               
            
            
        </div>    
        <div class="spa-view-body-item">
            <%if (Item._SpaKhuyen.Count > 0)
              { %>
            <% foreach (var item in Item._SpaKhuyen)
               {%>
                <div class="spa-view-km-item">
                    <%= string.Format(@"
<div class=""spa-view-km-item"">
<div class=""km-dangky"">
<span class=""km-gia"">{10}</span>
    <a  href=""javascript:;""  data-id=""{2}"" data-type=""0""  class=""km-dangky-btn ddv-btn"">Đăng ký</a>
</div>

    <a href=""{0}/Spa-Khuyen-Mai/{1}/{2}.html"" class=""km-img-box"">
        <img src=""{0}/lib/up/i/{4}"" class=""km-img"" />
    </a>
    <a href=""{0}/Spa-Khuyen-Mai/{1}/{2}.html"" class=""km-ten"">{3}</a>
<span class=""spa-date"">
{5:dd/MM/yy}-{6:dd/MM/yy}
</span>
<div class=""spa-mota"">
{7}
</div>
</div>"
                                       , string.Empty
                                       , Lib.Rutgon(Lib.Bodau(item.Ten), 50)
                                       , item.ID
                                       , item.Ten
                                       , Lib.imgSize(item._Spa.Anh, "150x115")
                                       , item.NgayBatDau
                                       , item.NgayKetThuc
                                       , item.MoTa
                                       , Lib.Rutgon(Lib.Bodau(item._Spa.Ten), 50)
                                       , item._Spa.ID
                                       ,
                                       item.GiaKhuyenMai == 0
                                           ? string.Format("{0} %", item.TyLeKhuyenMai)
                                           : Lib.TienVietNam(item.GiaKhuyenMai)) %>
                </div>
               <% } %>
            <% } else{ %>
            Chưa có khuyến mãi nào
            <%} %>
        </div>    
        <div class="spa-view-body-item">
            <div class="spa-view-ykien-header">
                <a href="javascript:;" class="spa-view-ykien-btn">Viết nhận xét</a>
                <span class="spa-view-ykien-title">Ý kiến nhận xét từ khách hàng</span><br/>
                <span class="spa-view-ykien-desc">Nhận xét của bạn giúp khách hàng khác có lựa chọn thông minh hơn</span>
            </div>   
            <div class="spa-view-ykien-posBox" style="display: none;">
                <div class="tin-view-bl-posBox">
                    <table cellpadding="2" cellspacing="2" width="100%">
                        <tr>
                            <td class="td-bl-header" valign="top">Bình chọn:</td>
                            <td valign="top">
                                <div id="star"></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-bl-header" valign="top">Tên:</td>
                            <td valign="top">
                                <input class="input-bl Ten" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-bl-header" valign="top">Email:</td>
                            <td valign="top">
                                <input class="input-bl Email" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-bl-header" valign="top">Mobile:</td>
                            <td valign="top">
                                <input class="input-bl Mobile" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-bl-header" valign="top">Nội dung:</td>
                            <td valign="top">
                                <textarea class="textarea-bl NoiDung" ></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2">                                    
                                <a _ID="<%=Item.ID %>" href="javascript:;" data-type="0" class="bl-btn">Gửi bình luận</a><br />
                                <span class="bl-msg"></span>
                            </td>
                        </tr>
                    </table>
                </div>
            </div> 
            <div class="spa-view-ykien-body">
                <% foreach (var item in Comments)
                   {%>
  <%= string.Format(@"<div class=""bl-item"">
            <div class=""bl-item-ten"">{0}</div>
            <div class=""bl-item-star"">
                <div class=""bl-star star-el"" data-score=""{3}""></div>
            </div>
            <div class=""bl-item-moTa"">{1}</div>
            <div class=""bl-item-moTa""><i>Ngày gửi: {2:hh:mm dd/MM/yyy}</i></div>
        </div>", item.KH_Ten, item.NoiDung, item.NgayTao, item.Star) %>
                   <%} %>
            </div>    
        </div>    
        <div class="spa-view-body-item">
            <h2>Bản đồ</h2>
            <div class="spa-view-map">
                <div id="map" style="height: 400px; width: 960px;"></div>
            </div>
            <h2>Địa chỉ</h2>
            <div class="spa-view-body-item-diaChi">
                Địa chỉ: <%=Item.DiaChi %><br/>
                Điện thoại: <%=Item.Phone %> <%=Item.Mobile %><br/>    
            </div>
        </div>    
    </div>
</div>
<h3 class="spa-view-lienQuanList-header">
    SPA LIÊN QUAN
</h3>
<div class="spa-view-lienQuanList">
        <a href="javascript:;" class="spa-view-slideshow-leftBtn">
        </a>
        <div class="spa-view-slideshow-thumnbails-box">
            <div class="spa-view-slideshow-thumnbails-box-rel">
                <% foreach (var spa in List)
                   {%>
  <%=string.Format(@"
<div class=""home-spa-lq-item"">
    <a href=""{0}/Spa/{1}/{2}.html"" class=""spa-img-box"">
        <img src=""{0}/lib/up/i/{4}"" class=""spa-img"" />
    </a>
    <a href=""{0}/Spa/{1}/{2}.html"" class=""spa-ten"">{3}</a></div>", string.Empty , spa.Alias, spa.ID, spa.Ten, Lib.imgSize(spa.Anh, "150x115")) %>
                   <%} %>
            </div>
        </div>
        <a href="javascript:;" class="spa-view-slideshow-rightBtn">
        </a>
    </div>
<script>
    
    var mapLoaded = false;
    $(function() {

        $('.spa-view-ykien-btn').click(function() {
            $('.spa-view-ykien-posBox').show();
        });

       
        $('.spa-view-tabs-item').each(function(i) {
            var item = $(this);
            item.click(function() {
                if (item.hasClass('spa-view-tabs-item-active'))
                    return false;
                $('.spa-view-tabs-item-active').removeClass('spa-view-tabs-item-active');
                item.addClass('spa-view-tabs-item-active');
                $('.spa-view-body-item').hide();
                $('.spa-view-body-item').eq(i).show();
                if(!mapLoaded) {
                    var map = new google.maps.Map(document.getElementById('map'), {
                        zoom: 16,
                        center: new google.maps.LatLng(<%=Item.ToaDo %>),
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                    });
                    var infoWindow = new google.maps.InfoWindow;
                    var onMarkerClick = function () {
                        var marker = this;
                        var latLng = marker.getPosition();
                        var l ='';
                        l += '<h3><%=Item.Ten %></h3>';
                        l += 'Địa chỉ:<%=Item.DiaChi.Replace(System.Environment.NewLine,"<br/>") %><br />';
                        l += 'Điện thoại:<%=Item.Phone %><br/>';
                        infoWindow.setContent(l);
                        infoWindow.open(map, marker);
                    };
                    google.maps.event.addListener(map, 'click', function () {
                        infoWindow.close();
                    });
                    var marker1 = new google.maps.Marker({
                        map: map,
                        position: new google.maps.LatLng(<%=Item.ToaDo %>)
                    });
                    google.maps.event.addListener(marker1, 'click', onMarkerClick);
                    google.maps.event.addListener(marker1, 'click', function () {
                    });

                }
            });
        });

        $('.spa-view-slideshow-thumnbails-item-img').each(function(i) {
            var item = $(this);
            item.click(function() {
                var full = item.attr('data-full');
                var ten = item.attr('data-ten');
                $('.spa-view-slideshow-caption').html(ten);
                $('.spa-view-slideshow-img').attr('src', full);
            });
        });
        

        $('.spa-view-slideshow-leftBtn').click(function () {
            var item = $(this);
            var pnl = item.parent().find('.spa-view-slideshow-thumnbails-box');
            $(pnl).scrollTo('-=900px', 500);
        });
        $('.spa-view-slideshow-rightBtn').click(function () {
            var item = $(this);
            var pnl = item.parent().find('.spa-view-slideshow-thumnbails-box');
            $(pnl).scrollTo('+=900px', 500);
        });
        
        $('.dvu-list-item-ten').each(function (i) {
            var item = $(this);
            item.click(function () {
                var pitem = item.next();
                if (pitem.hasClass('dvu-list-item-noiDung-show')) {
                    pitem.removeClass('dvu-list-item-noiDung-show');
                } else {
                    pitem.addClass('dvu-list-item-noiDung-show');
                }
            });
        });
    });
</script>
<script src="http://maps.google.com/maps/api/js?sensor=true" type="text/javascript"></script>