<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hoiDap_view.ascx.cs" Inherits="lib_ui_web_hoiDap_hoiDap_view" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="home-dvu-left">
    <ul class="cate-home-ul">
        <li class="home-mnu-left-header">Khuyến mãi theo Dịch vụ</li>
    <%=strDmHangHoa%>
    </ul>    
</div>
<div class="dvu-list-body">
    <div class="hoiDap-view">
        <h1 class="hoiDap-view-ten">
            <%if(Item.DaTraLoi){ %>
                <span class="hoiDap-view-daTraLoi"></span>
            <%} %>
            <%=Item.Ten %>
            
        </h1>
        <div>
            <span class="hoiDap-view-ngayTao"><%=Item.NgayTao.ToString("dd-MM-yy") %></span>
            <span class="hoiDap-view-nguoiTao"><%=Item.NguoiTao %></span>    
        </div>
        <div class="hoiDap-view-noiDung"><%=Item.NoiDung %></div>
    </div>
    <div class="hoidap-list-header">
        <%if(CauTraLoi.Count > 0){ %>
        Có <%=CauTraLoi.Count.ToString() %> câu trả lời

        <%}
          else
          {%>
       Chưa có câu trả lời
  
          <%} %>
    </div>
    <div class="hoiDap-view-list">
        <%foreach (var item in CauTraLoi)
          { %>
            <div class="spa-hd-traLoi-item">
                <div class="spa-hd-ten"><%=item.Ten %></div>
                <span class="spa-hd-ngayTao"><%=item.NgayTao.ToString("dd-MM-yy") %></span><span class="spa-hd-nguoiTao"><%=item.NguoiTao %></span>
                <div class="spa-hd-noiDung"><%=item.NoiDung %></div>
            </div>
        <%} %>
    </div>    
</div>
<div class="dvu-list-adv">
    <a data-dv-id="<%=Item.DM_ID %>" class="spa-hd-hoiBtn datCauHoiDichVuBtn" href="javascript:;">Đặt câu hỏi</a>
    <p>&nbsp;</p>
    <div class="hd-view-adv">
        <% foreach (var item in QuangCaos)
           {%>
            <a target="_blank" class="hd-view-adv-item"href="<%=item.Url %>">
                <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
            </a>
        <%} %>
    </div>
    <div class="hoiDap-view-lienQuan-header">
        Hỏi đáp khác
    </div>
    <div class="hoiDap-view-lienQuan-list">
        <%foreach (var item in LienQuan)
          { %>
            <div class="spa-hd-lq-list-item">
                <a href="/Hoi-dap-Spa/<%=item._DanhMuc.Ma %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html" class="spa-hd-ten"><%=item.Ten %></a>
                <span class="spa-hd-nguoiTao"><%=item.NguoiTao %></span>
                <span class="spa-hd-ngayTao"><%=item.NgayTao.ToString("dd-MM-yy") %></span>
            </div>
        <%} %>
    </div>
</div>