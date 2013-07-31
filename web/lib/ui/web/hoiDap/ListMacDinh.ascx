<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListMacDinh.ascx.cs" Inherits="lib_ui_web_hoiDap_ListMacDinh" %>
<%@ Import Namespace="linh.common" %>
<%=txtPath %>
<div class="home-dvu-left">
    <ul class="cate-home-ul">
        <li class="home-mnu-left-header">Hỏi đáp theo Dịch vụ</li>
    <%=strDmHangHoa%>
    </ul>    
</div>
<div class="dvu-list-body">
    <%foreach(var item in Pagers.List){ %>
        <div class="spa-hd-list-item">
            <a href="/Hoi-dap-Spa/<%=item._DanhMuc.Ma %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID.ToString() %>.html" class="spa-hd-ten"><%=item.Ten %></a>
            <span class="spa-hd-ngayTao"><%=item.NgayTao.ToString("dd-MM-yy") %></span><span class="spa-hd-nguoiTao"><%=item.NguoiTao %></span>
        </div>
    <%} %>
    <div class="dvu-list-pager">
        <%=Pagers.Paging %>        
    </div>
</div>
<div class="dvu-list-adv">
    <a data-dv-id="<%=DM_ID %>" class="spa-hd-hoiBtn <%=string.IsNullOrEmpty(DM_ID) ? "datCauHoiChungBtn" : "datCauHoiDichVuBtn" %>" href="javascript:;">Đặt câu hỏi</a>
    <p>&nbsp;</p>
    <div class="hd-view-adv">
        <% foreach (var item in QuangCaos)
           {%>
            <a target="_blank" class="hd-view-adv-item"href="<%=item.Url %>">
                <img class="spa-list-adv-item-img" src="/lib/up/i/<%=Lib.imgSize(item.Anh, "full") %>"/>      
            </a>
        <%} %>
    </div>
</div>