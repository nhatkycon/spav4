<%@ Control Language="C#" AutoEventWireup="true" CodeFile="home.ascx.cs" Inherits="lib_ui_web_hoiDap_home" %>
<%@ Import Namespace="linh.common" %>
<div class="home-mdl-km">
    <div class="home-mdl-km-header">
        <span class="home-mdl-tin-header-title">Hỏi đáp</span>
    </div>
    <div class="home-mdl-km-box">
        <div class="sp-hd-home-header">
        <span class="spa-hd-icon"></span>
        <% var i = 0; %> 
        <% foreach (var item in List)
           {%>
                <%if(i==0)
                  {%>                
                    <div class="spa-hd-home-itemBig">
                        <a href="/Hoi-dap-Spa/<%=item._DanhMuc.Alias %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID %>.html" class="spa-hd-ten"><%=item.Ten %></a>
                        <span class="spa-hd-ngayTao"><%=item.NgayTao.ToString("dd-MM-yy") %></span>
                        <span class="spa-hd-nguoiTao"><%=item.NguoiTao %></span>
                    </div>
                <%} %>
            <% i++; %>
        <%} %>  
        <a href="javascript:;" class="spa-hd-hoiBtn datCauHoiChungBtn">Đặt câu hỏi</a>
        </div>

        <% i = 0; %>
        <div class="sp-hd-home-hox">
        <% foreach (var item in List)
           {%>
                <%if(i!=0)
                  {%>
                    <div class="spa-hd-home-item">
                        <a href="/Hoi-dap-Spa/<%=item._DanhMuc.Alias %>/<%=Lib.Bodau(item.Ten) %>/<%=item.ID %>.html" class="spa-hd-ten">
                            <%=item.Ten %>
                        </a>
                        <span class="spa-hd-ngayTao"><%=item.NgayTao.ToString("dd-MM-yy") %></span>
                        <span class="spa-hd-nguoiTao"><%=item.NguoiTao %></span>
                    </div>
                <%} %>
            <% i++; %>
        <% } %>    
        </div>                                   
    </div>
</div>