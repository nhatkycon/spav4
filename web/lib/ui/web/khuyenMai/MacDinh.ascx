<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MacDinh.ascx.cs" Inherits="lib_ui_web_khuyenMai_MacDinh" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="km-list-left">
    <div class="km-list-left-adv">
        <% foreach (var item in QuangCaoTop)
            {%>
            <a target="_blank" class="spa-moi-khai-truong-adv-item"href="<%=item.Url %>">
                <img class="spa-moi-khai-truong-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
            </a>
        <%} %>  
    </div>
    <div class="km-list-left-list">
        <% foreach (var item in Pagers.List)
           {%>
        <div class="list-km-item">
            <div class="km-dangky">
                <span class="km-gia"><%=item.GiaKhuyenMai == 0 ? string.Format("{0} %", item.TyLeKhuyenMai) : Lib.TienVietNam(item.GiaKhuyenMai) %></span>
                <a data-id="<%=item.ID %>" data-type="0" href="javascript:;" class="km-dangky-btn ddv-btn">Đăng ký</a>
            </div>
            <a href="/Spa-Khuyen-Mai/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html" class="km-img-box">
                <img src="/lib/up/i/<%=Lib.imgSize(item._Spa.Anh, "150x115") %>" class="km-img" />
            </a>
            <a href="/Spa-Khuyen-Mai/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html" class="km-ten"><%=item.Ten %></a>
            <span class="spa-date">
                <%=string.Format("{0:dd/MM/yy} - {1:dd/MM/yy}",item.NgayBatDau, item.NgayKetThuc) %>
            </span>
            <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID.ToString() %>.html" title="<%=item._Spa.Ten %>" class="km-spa-ten"><%=item._Spa.Ten %></a>
            <div class="km-spa-mota">
                <%=item.MoTa %>
            </div>
        </div>
           <%} %>
        <div class="km-list-left-pager">
            <%=Pagers.Paging %>
        </div>
    </div>    
</div>
<div class="km-list-right">
    <% foreach (var item in QuangCaoRight)
        {%>
        <a target="_blank" class="spa-list-adv-item"href="<%=item.Url %>">
            <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
        </a>
    <%} %>
</div>