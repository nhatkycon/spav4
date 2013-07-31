<%@ Control Language="C#" AutoEventWireup="true" CodeFile="km_view.ascx.cs" Inherits="lib_ui_web_khuyenMai_km_view" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="km-item-view">
    <div class="km-dangky">
        <span class="km-gia-cu">
            <%=Lib.TienVietNam(Item.GiaThiTruong)%> 
        </span>
        <span class="km-gia-tyle">
            [-<%=Item.TyLeKhuyenMai %>%]
        </span>
        <span class="km-gia"><%=Item.GiaKhuyenMai == 0 ? string.Format("{0} %", Item.TyLeKhuyenMai) : Lib.TienVietNam(Item.GiaKhuyenMai) %></span>
        <a data-id="<%=Item.ID %>" data-type="0" href="javascript:;" class="km-dangky-btn ddv-btn">MUA</a>
    </div> 
    <h1 class="km-ten">
        <%=Item.Ten %>
    </h1>
    <span class="spa-date">
       Từ: <%=string.Format("{0:dd/MM/yy} - {1:dd/MM/yy}",Item.NgayBatDau, Item.NgayKetThuc) %>
    </span>    
    <div class="km-spa-mota">
        <%=Item.MoTa %>
    </div>
</div>

<div style="position: absolute;top:-10px; height: 10px; overflow: hidden;">
    <div itemscope itemtype="http://data-vocabulary.org/Product">  
      <span itemprop="name"><%=Item.Ten %></span>
      <img itemprop="image" src="/lib/up/i/<%=Lib.imgSize(Item._Spa.Anh,"150x115") %>" />
      <span itemprop="description"><%=Item.MoTa %>
      </span>
      Product #: <span itemprop="identifier" content="mpn:<%=Item.ID %>">
        <%=Item.ID %></span>
      <span itemprop="review" itemscope itemtype="http://data-vocabulary.org/Review-aggregate">
        <span itemprop="rating"><%=new Random().Next(2, 5)%></span> stars, based on <span itemprop="count"><%=Item.SoLuongMua %>
          </span> reviews
      </span>

      <span itemprop="offerDetails" itemscope itemtype="http://data-vocabulary.org/Offer">
        Regular price: <%=Lib.TienVietNam(Item.GiaThiTruong) %>
        <meta itemprop="currency" content="VND" />
        $<span itemprop="price"><%=Lib.TienVietNam(Item.GiaKhuyenMai)%></span>
        (Sale ends <time itemprop="priceValidUntil" datetime="<%=Item.NgayKetThuc.ToString("yyyy-MM-dd") %>">
          <%=Item.NgayKetThuc.ToString("yyyy-MM-dd") %>!</time>)
      </span>
    </div>
</div>