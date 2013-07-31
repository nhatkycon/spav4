<%@ Control Language="C#" AutoEventWireup="true" CodeFile="footer.ascx.cs" Inherits="lib_ui_web_heThong_footer" %>
<div class="footer">
    <div class="footer-box">
        <div class="footer-body">
            <%=txt %>
        </div>            
    </div>
</div>
<div class="footer-tags">
    <div class="footer-box">
        <div class="footer-body">
             <% foreach (var item in DichVuCons)
                {%>
                <div class="tag ticket">
                    <span class="circle"></span>    
                    <a  title="<%= item.Ten %>" href="<%= domain %>/Dich-vu-Spa/<%= item.Alias %>/<%= item.ID.ToString() %>/" >
                        <%= item.Ten %>                            
                    </a>
                    </div>
            <%} %>  
        </div>            
    </div>
</div>
