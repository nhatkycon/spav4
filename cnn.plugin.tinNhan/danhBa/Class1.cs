using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using linh;
using linh.frm;
using linh.json;
using linh.common;
using linh.controls;
using docsoft;
using docsoft.entities;
using System.Xml;
using System.IO;
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.htm.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.htm1.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.htm2.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.htm3.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.htm4.htm", "text/html")]
namespace cnn.plugin.tinNhan.danhBa
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _F_TinID = Request["F_TinID"];

            string _GID = Request["GID"];
            string _groupName = Request["groupName"];
            string _listUser = Request["listUser"];
            string _q = Request["q"];
            string _s = Request["s"];
            string _DB_ID = Request["DB_ID"];
            string _G_ID = Request["G_ID"];
            


            #endregion
            switch (subAct)
            {
                case "get2":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "DB_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    TinnhanDanhbaCollection List  = TinnhanDanhbaDal.SelectByUser(Security.Username, _GID, _s);
                    sb.Append(JavaScriptConvert.SerializeObject(List));

                    break;
                    #endregion
                case "getgroup2":
                    #region lấy danh sách nhom
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "G_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    Pager<TinnhanGroup> pagerG2 = TinnhanGroupDal.pagerSelectByUser("", false, jgrsidx + " " + jgrsord, Security.Username);


                    sb.Append(JavaScriptConvert.SerializeObject(pagerG2.List));
                    break;
                    #endregion
                case "savegroup":
                    #region lưu
                    TinnhanGroup ItemSave = new TinnhanGroup();
                    if (string.IsNullOrEmpty(_groupName))
                    {
                        sb.Append("0");
                        break;
                    }
                    if (!string.IsNullOrEmpty(_GID))
                    {
                        ItemSave = TinnhanGroupDal.SelectById(Convert.ToInt32(_GID));
                    }
                    ItemSave.Ten = _groupName;
                    ItemSave.Username = Security.Username;

                    if (!string.IsNullOrEmpty(_GID))
                        ItemSave = TinnhanGroupDal.Update(ItemSave);
                    else
                        ItemSave = TinnhanGroupDal.Insert(ItemSave);

                    sb.Append("1");
                    break;
                    #endregion
                case "editgroup":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_GID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(TinnhanGroupDal.SelectById(Convert.ToInt32(_GID))) + ")");
                    }
                    break;
                    #endregion
                case "delgroup":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_GID))
                    {
                        TinnhanGroupDal.XoaBylistId(_GID);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "listgroup":
                    #region listgroup
                    TinnhanGroupCollection listgetPid = TinnhanGroupDal.SelectAllByUser(_q, Security.Username);
                    sb.Append(JavaScriptConvert.SerializeObject(listgetPid));
                    break;
                #endregion
                case "savedanhba":
                    #region add

                    string[] arlistUser = _listUser.Split(new char[] { ',' });
                    for (int i = 0; i < arlistUser.Length - 1; i++)
                    {
                        TinnhanDanhba Itemnhantl = new TinnhanDanhba();
                        Itemnhantl.User = Security.Username;
                        Itemnhantl.Username = arlistUser[i];
                        Itemnhantl = TinnhanDanhbaDal.Insert(Itemnhantl);
                    }
                    sb.Append("1");
                    break;
                    #endregion

                case "deldanhba":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_DB_ID))
                    {
                        TinnhanDanhbaDal.XoaBylistId(_DB_ID);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "deldanhbaG":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_DB_ID))
                    {
                        TinnhanDanhbaDal.XoaByGroupId(_DB_ID);
                        sb.Append("1");
                    }
                    break;
                    #endregion
                case "chuyentoi":
                    #region chuyentoi
                    if (!string.IsNullOrEmpty(_DB_ID))
                    {
                        //TinnhanDal.DeletelistById(_TinID);
                        _DB_ID = _DB_ID.Remove(_DB_ID.Length - 1, 1);
                        _G_ID = _G_ID.Remove(_G_ID.Length - 1, 1);
                        string[] arG_ID = _G_ID.Split(new char[] { ',' });
                        foreach(string itemgroup in arG_ID)
                        {
                            TinnhanDanhbaDal.ChuyentoiBylistId(_DB_ID, itemgroup);
                        }
                    }
                    break;
                    #endregion
                
                case "getdetail":
                    #region lấy danh sách
                    _listUser = _listUser.Remove(_listUser.Length-1, 1);
                    _listUser = _listUser.Remove(0, 1);
                    Member user = MemberDal.SelectByUser(_listUser);
                    TinnhanGroupCollection argroup = TinnhanGroupDal.SelectByUserName(Security.Username, _listUser);
                    string argroups="";
                    foreach(TinnhanGroup item in argroup)
                    {
                        argroups += item.Ten + ",";
                    }


                    string data=@"<table style=""width: 500px"">";
                    data+=@"    <tr>";
                    data+=@"<td width=""120px"">";
                    data+=@"    User";
                    data+=@"</td>";
                    data+=@"<td>";
                    data += user.Username;
                    data+=@"</td>";
                    data+=@"</tr>";
                    data+=@"<tr>";
                    data+=@"<td width=""120px"">";
                    data+=@"    Tên";
                    data+=@"</td>";
                    data+=@"<td>";
                    data += user.Ten;
                    data+=@"</td>";
                    data+=@"</tr>";
                    data+=@" <tr>";
                    data+=@"    <td width=""120px"">";
                    data+=@"        EMail";
                    data+=@"    </td>";
                    data+=@"   <td>";
                    data += user.Email;
                    data+=@"    </td>";
                    data+=@" </tr>";
                    data+=@" <tr>";
                    data+=@"     <td width=""120px"">";
                    data+=@"         Danh sách";
                    data+=@"     </td>";
                    data+=@"     <td>";
                    data += argroups;
                    data+=@"    </td>";
                    data+=@"  </tr>";
                    data+=@"</table>";

                    
                    sb.Append(data);

                    break;
                    #endregion
                case "addexist":
                    #region addexist
                    string[] arlistUser2 = _listUser.Split(new char[] { ',' });
                    for (int i = 0; i < arlistUser2.Length - 1; i++)
                    {
                        TinnhanDanhba Itemnhantl = new TinnhanDanhba();
                        Itemnhantl.User = Security.Username;
                        Itemnhantl.Username = arlistUser2[i];
                        TinnhanDanhbaDal.Insert(Itemnhantl);
                    }

                    sb.Append("1");
                    break;
                    #endregion
              
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.danhBa.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"

<div id=""danhbamdl-ListConten"">
     <table style=""width:100%; border-width:0px;"">
             <tr style=""background-color: #E0E0E0;border-width:0px;"">
                <td   width=""220px"" style=""align:top;vertical-align:top; float: left; border-width:0px;"" colspan=""1"">
                   <a class=""mdl-head-btn mdl-head-add"" id=""danhbamdl-groupadd"" href=""javascript:danhbaObj.groupadd();"">Thêm nhóm</a>
                   <a class=""mdl-head-btn mdl-head-add"" id=""danhbamdl-add"" href=""javascript:danhbaObj.danhbaadd();"">Thêm địa chỉ</a>
                     
                 </td>
                 <td width=""300px"" style=""align:left !important;vertical-align:top;border-width:0px;"">
                    <div style=""align:left !important;vertical-align:top;border-width:0px;"">
                        <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
                        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
                            <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-listdanhba"" />
                        </span>
                    </div>
                   
                </td>
                <td width=""550px"" style=""align:top;vertical-align:top;border-width:0px;"">
              
                     
                 </td>
            </tr>
        
            <tr border-width:0px;>
                <td   width=""220px"" style=""align:top;vertical-align:top; background-color: #F5F5F5; border-width:0px;"">
                  
                   
                    <div id=""danhbagroup-List"">
                        <table id=""danhbagroupdl-List"" class=""mdl-list""></table>
                        <div id=""danhbagroupdl-Pager""></div>
                    </div>
                   <a class=""mdl-head-btn mdl-head-add"" id=""danhbamdl-groupadd"" href=""javascript:danhbaObj.groupedit();"">Sửa</a>
                   <a class=""mdl-head-btn mdl-head-del"" id=""danhbamdl-groupdelBtn"" href=""javascript:danhbaObj.groupdel();"">Xóa</a>
                </td>
               <td width=""300px"" style=""align:top;vertical-align:top; background-color: #FAFAFA; border-width:0px;"">
                     <div id=""danhba-List"" class=""modal-pane-bd2"">
                        
                        <table id=""danhbamdl-List"" class=""mdl-list""></table>
                        <div id=""danhbamdl-Pager""></div>
                    </div>
                    <div id=""chonnhom"" style=""display:none"">
                    </div>
                </td>
               
                <td width=""550px"" style=""align:top;vertical-align:top; border-width:0px;"">
                  <div  class=""mdl-head danhbadetail"" style=""display:none"">
                        <div style="""">
                            <a class=""mdl-head-btn mdl-head-del"" id=""danhbamdl-chuyenBtn"" href=""javascript:danhbaObj.chuyentoi();"">Cho vào nhóm</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""danhbamdl-xoakhoigroupBtn"" href=""javascript:danhbaObj.danhbadelG();"" style=""display:none"">Xóa khỏi nhóm</a>
                            <a class=""mdl-head-btn mdl-head-del"" id=""danhbamdl-delBtn"" href=""javascript:danhbaObj.danhbadel();"">Xóa</a>
                        
                        </div>
                        <br>
                        <h2 class=""legend""><span class=""label"">Chi tiết</span></h2>
                        <div  class=""listdanhbadetail"" >
                        
                    
                         </div>
                  </div>
                     
                 </td>
            </tr>
           
        </table>
<input type=""text"" class=""checkcount"" style=""display:none""/>
</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.danhBa.JScript1.js")
                        , "{danhbaObj.setup();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




