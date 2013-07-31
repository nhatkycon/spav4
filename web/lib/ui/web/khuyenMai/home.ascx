<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home.ascx.cs" Inherits="lib_ui_web_khuyenMai_home" %>
<%@ Import Namespace="linh.common" %>
<div class="home-mdl-km">
    <div class="home-mdl-km-header">
        <span class="home-mdl-tin-header-title">Khuyến mãi</span>
    </div>
    <div class="home-mdl-km-box"> 
        <% foreach (var item in List)
           {%>
            <div class="home-km-item">
                <div class="km-dangky">
                    <span class="km-gia"><%=item.GiaKhuyenMai == 0 ? string.Format("{0} %",item.TyLeKhuyenMai) : Lib.TienVietNam(item.GiaKhuyenMai) %></span>
                    <a data-id="<%=item.ID %>" data-type="0"  href="/Spa-Khuyen-Mai/<%=Lib.Bodau(item.Ten) %>/<%=item.ID %>.html" class="km-dangky-btn">Xem</a>
                </div>
                <a href="/Spa-Khuyen-Mai/<%=Lib.Bodau(item.Ten) %>/<%=item.ID %>.html" title="<%=item.Ten %>" class="km-ten"><%=item.Ten %></a>
                <span class="spa-date">
                <%=item.NgayBatDau.ToString("dd/MM/yy") %> - <%=item.NgayKetThuc.ToString("dd/MM/yy") %>
                </span>
                <a href="/Spa/<%=item._Spa.Alias %>/<%=item._Spa.ID %>.html" class="km-spa-ten"><%=item._Spa.Ten %></a>
            </div>
        <%} %>
    <%=txt %>
    </div>
</div>