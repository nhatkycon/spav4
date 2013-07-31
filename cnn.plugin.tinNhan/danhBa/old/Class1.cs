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
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.old.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.old.htm.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.old.htm1.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.old.htm2.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.danhBa.old.htm3.htm", "text/html")]
namespace cnn.plugin.tinNhan.danhBa.old
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
            string _GD_ID = Request["GD_ID"];
            

            List<jgridRow> ListRow;
            List<jgridRow> ListRowG;
            List<jgridRow> ListRowGD;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "DB_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    Pager<TinnhanDanhba> pager = TinnhanDanhbaDal.pagerSelectByUser("", false, jgrsidx + " " + jgrsord, Security.Username, _GID,_s);

                    ListRow = new List<jgridRow>();
                    foreach (TinnhanDanhba item in pager.List)
                    {
                      
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] 
                        { 
                             item.Thutu.ToString()
                             ,item.ID.ToString()
                            ,item.Username
                          
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pager.TotalPages.ToString(), pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "get2":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "DB_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    TinnhanDanhbaCollection List  = TinnhanDanhbaDal.SelectByUser(Security.Username, _GID, _s);
                    sb.Append(JavaScriptConvert.SerializeObject(List));

                    break;
                    #endregion
                case "getgroup":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "G_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    Pager<TinnhanGroup> pagerG = TinnhanGroupDal.pagerSelectByUser("", false, jgrsidx + " " + jgrsord, Security.Username);

                    ListRowG = new List<jgridRow>();
                    foreach (TinnhanGroup item in pagerG.List)
                    {
                        ListRowG.Add(new jgridRow(item.ID.ToString(), new string[] 
                        { 
                             item.Thutu.ToString()
                             ,item.ID.ToString()
                            ,item.Ten
                        }));
                    }
                    jgrid gridG = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pagerG.TotalPages.ToString(), pagerG.Total.ToString(), ListRowG);
                    sb.Append(JavaScriptConvert.SerializeObject(gridG));
                    break;
                    #endregion
                case "getgroupdetail":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "GD_ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";
                    
                    if (string.IsNullOrEmpty(_GID))
                        _GID = "0"; 
                    Pager<TinnhanGroupDetail> pagerGD = TinnhanGroupDetailDal.pagerSelectByUser("", false, jgrsidx + " " + jgrsord, Convert.ToInt32(_GID));

                    ListRowGD = new List<jgridRow>();
                    foreach (TinnhanGroupDetail item in pagerGD.List)
                    {
                        ListRowGD.Add(new jgridRow(item.ID.ToString(), new string[] 
                        { 
                             item.Thutu.ToString()
                             ,item.ID.ToString()
                            ,item.Username
                        }));
                    }
                    jgrid gridGD = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pagerGD.TotalPages.ToString(), pagerGD.Total.ToString(), ListRowGD);
                    sb.Append(JavaScriptConvert.SerializeObject(gridGD));
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
                    }
                    break;
                    #endregion
                case "listgroup":
                #region danh sách chọn sẵn
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
                    }
                    break;
                    #endregion
                case "chuyentoi":
                    #region chuyentoi
                    if (!string.IsNullOrEmpty(_DB_ID))
                    {
                        //TinnhanDal.DeletelistById(_TinID);
                        _DB_ID = _DB_ID.Remove(_DB_ID.Length - 1, 1);
                        if (_DB_ID.StartsWith(","))
                            _DB_ID = _DB_ID.Remove(0, 1);
                        TinnhanDanhbaDal.ChuyentoiBylistId(_DB_ID, _G_ID);
                    }
                    break;
                    #endregion
                case "delgroupdetail":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_GD_ID))
                    {
                        TinnhanGroupDetailDal.XoaBylistId(_GD_ID);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.danhBa.old.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"

<div id=""danhbaoldmdl-ListConten"">
     <table style=""width:800px;"">
            <tr>
                <td   width=""50%"" style=""align:top;vertical-align:top;"">
                <fieldset style=""align:top;vertical-align:top;"">
                    <legend>Danh sách liên hệ</legend>
                    <div  class=""mdl-head"">
                        <a class=""mdl-head-btn mdl-head-add"" id=""danhbaoldmdl-add"" href=""javascript:danhbaObjold.danhbaadd();"">Thêm mới</a>
                        <a class=""mdl-head-btn mdl-head-del"" id=""danhbaoldmdl-delBtn"" href=""javascript:danhbaObjold.danhbadel();"">Xóa</a>
                        <input id=""listgroup"" class""mdl-head mdl-head-filter""/><button class=""admfilter-btn""></button>
                    </div>
                   <div id=""danhba-List"">
                        <table id=""danhbaoldmdl-List"" class=""mdl-list""></table>
                        <div id=""danhbaoldmdl-Pager""></div>
                    </div>
                   
                </fieldset>
                </td>
                <td width=""50%"" style=""align:top;vertical-align:top;"">
                   <fieldset  style=""align:top"">
                    <legend>Group</legend>
                   <a class=""mdl-head-btn mdl-head-add"" id=""danhbaoldmdl-groupadd"" href=""javascript:danhbaObjold.groupadd();"">Thêm mới</a>
                    <a class=""mdl-head-btn mdl-head-add"" id=""danhbaoldmdl-groupadd"" href=""javascript:danhbaObjold.groupedit();"">Sửa</a>
                   <a class=""mdl-head-btn mdl-head-del"" id=""danhbaoldmdl-groupdelBtn"" href=""javascript:danhbaObjold.groupdel();"">Xóa</a>
                    <div id=""danhbagroup-List"">
                        <table id=""danhbaoldgroupdl-List"" class=""mdl-list""></table>
                        <div id=""danhbaoldgroupdl-Pager""></div>
                    </div>
                    </hr>

                   <a class=""mdl-head-btn mdl-head-del"" id=""danhbaoldmdl-groupdetaildelBtn"" href=""javascript:danhbaObjold.groupdetaildel();"">Xóa</a>
                      <div id=""danhbagroupdetail-List"">
                        <table id=""danhbaoldgroupdetaildl-List"" class=""mdl-list""></table>
                        <div id=""danhbaoldgroupdetaildl-Pager""></div>
                      </div>
                    
                    </fieldset>
                </td>
            </tr>
           
        </table>

</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.danhBa.old.JScript1.js")
                        , "{danhbaObjold.setup();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




