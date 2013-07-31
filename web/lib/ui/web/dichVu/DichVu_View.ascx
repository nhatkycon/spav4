﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DichVu_View.ascx.cs" Inherits="lib_ui_web_dichVu_DichVu_View" %>
<div itemscope itemtype="http://data-vocabulary.org/Product">
  <span itemprop="brand">ACME</span> <span itemprop="name">Executive
    Anvil</span>
  <img itemprop="image" src="anvil_executive.jpg" />

  <span itemprop="description">Sleeker than ACME's Classic Anvil, the 
    Executive Anvil is perfect for the business traveler
    looking for something to drop from a height.
  </span>
  Category: <span itemprop="category" content="Hardware > Tools > Anvils">Anvils</span>
  Product #: <span itemprop="identifier" content="mpn:925872">
    925872</span>
  <span itemprop="review" itemscope itemtype="http://data-vocabulary.org/Review-aggregate">
    <span itemprop="rating">4.4</span> stars, based on <span itemprop="count">89
      </span> reviews
  </span>

  <span itemprop="offerDetails" itemscope itemtype="http://data-vocabulary.org/Offer">
    Regular price: $179.99
    <meta itemprop="currency" content="USD" />
    $<span itemprop="price">119.99</span>
    (Sale ends <time itemprop="priceValidUntil" datetime="2020-11-05">
      5 November!</time>)
    Available from: <span itemprop="seller">Executive Objects</span>
    Condition: <span itemprop="condition" content="used">Previously owned, 
      in excellent condition</span>
    <span itemprop="availability" content="in_stock">In stock! Order now!</span>
  </span>
</div>