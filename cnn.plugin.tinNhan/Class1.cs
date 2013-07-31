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
[assembly: WebResource("cnn.plugin.tinNhan.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.tinNhan.htm.htm", "text/html")]
namespace cnn.plugin.tinNhan
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;

            string _F_TinID = Request["F_ID"];


            string _RowID = Request["RowID"];
            string _TinID = Request["ID"];
            string _PID = Request["PID"];
            string _Nguoinhan = Request["Nguoinhan"];
            string _UserCC = Request["UserCC"];
            string _UserBC = Request["UserBC"];
            
            string _Tieude = Request["Tieude"];
            string _Noidung = Request["Noidung"];
            string _Ngaygui = Request["Ngaygui"];
            string _Quantrong = Request["Quantrong"];
            string _File = Request["File"];
            string _Dagui = Request["Dagui"];
            string _forward = Request["forward"];




            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                #region lấy danh sách

                #endregion
                case "insertTin":
                    #region lưu dữ liệu tạm
                    Tinnhan ItemInsert = new Tinnhan();
                    ItemInsert.RowID = Guid.NewGuid();
                    

                    ItemInsert.Tieude="";
                    ItemInsert.Noidung="";
                    ItemInsert.Ngaygui=DateTime.Now;
                    ItemInsert.Usergui = Security.Username;
                   
                    ItemInsert.File = false;


                    ItemInsert = TinnhanDal.InsertDraff(ItemInsert);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(ItemInsert));
                    break;
                    #endregion
               
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        TinnhanDal.DeleteById(int.Parse(_TinID));
                    }
                    break;
                    #endregion
                case "save":
                    #region lưu
                    Tinnhan ItemSave = new Tinnhan();

                    if (string.IsNullOrEmpty(_TinID))
                     {
                        ItemSave.RowID = Guid.NewGuid();
                        ItemSave.Ngaygui = DateTime.Now;
                        ItemSave = TinnhanDal.InsertDraff(ItemSave);
                        _TinID = ItemSave.TinID.ToString();
                        if (string.IsNullOrEmpty(_TinID))
                            return;
                    }
                    ItemSave.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                    TinhanMemberDal.ClearTemp(ItemSave.TinID);

                    //xu ly nguoi gui
                    TinhanMember Itemguisave = new TinhanMember();
                    Itemguisave.TinID = ItemSave.TinID;
                    Itemguisave.User = Security.Username;
                    Itemguisave.Gui = true;
                    Itemguisave = TinhanMemberDal.Insert(Itemguisave);
                    
                    //xu ly danh sach nguoi nhan
                    string[] _listnguoinhan = _Nguoinhan.Split(new char[] { ',' });
                    for (int i = 0; i < _listnguoinhan.Length - 1; i++)
                    {
                        TinhanMember Itemnhan = new TinhanMember();
                        Itemnhan.TinID = ItemSave.TinID;
                        Itemnhan.User = _listnguoinhan[i];
                        Itemnhan.Nhan = true;
                        Itemnhan = TinhanMemberDal.InsertNhan(Itemnhan);
                    }
                    
                    //xu ly danh sach Cc
                    string[] _Cc = _UserCC.Split(new char[] { ',' });
                    for (int i = 0; i < _Cc.Length - 1; i++)
                    {
                        TinhanMember Itemcc = new TinhanMember();
                        Itemcc.TinID = ItemSave.TinID;
                        Itemcc.User = _Cc[i];
                        Itemcc.UserCC = true;
                        Itemcc = TinhanMemberDal.InsertNhan(Itemcc);
                    }

                    //xu ly danh sach Bc
                    string[] _Bc = _UserBC.Split(new char[] { ',' });
                    for (int i = 0; i < _Bc.Length - 1; i++)
                    {
                        TinhanMember Itembc = new TinhanMember();
                        Itembc.TinID = ItemSave.TinID;
                        Itembc.User = _Bc[i];
                        Itembc.UserBC = true;
                        Itembc = TinhanMemberDal.InsertNhan(Itembc);
                    }

                    ItemSave = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    ItemSave.Nguoigui = Security.Username;
                    ItemSave.Usergui = ItemSave.NguoiguiObj.Ten + "(" + Security.Username + "),";
                    ItemSave.Tieude = _Tieude;
                    ItemSave.Noidung = _Noidung;
                    ItemSave.Quantrong = Convert.ToBoolean(_Quantrong);

                    //xu ly danh sach File
                    //string[] _Filelist = _File.Split(new char[] { ',' });
                    if (_File.Length > 1)
                        ItemSave.File = true;
                    else
                        ItemSave.File = false;

                    //danh sach nguoi nhan
                    ItemSave.Nguoinhan = "";
                    ItemSave.Listnguoinhan = "";
                    if (ItemSave.Nguoinhanlist.Count > 0)
                    {

                        foreach (TinhanMember item in ItemSave.Nguoinhanlist)
                        {
                            ItemSave.Nguoinhan += item.Ten + "(" + item.User + "),";
                            ItemSave.Listnguoinhan += item.Ten + "(" + item.User + "),";
                        }

                    }
                    //danh sach Cc
                    ItemSave.Listcc = "";
                    if (ItemSave.Cclist.Count > 0)
                    {
                        if (ItemSave.Cclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSave.Cclist)
                            {
                                ItemSave.Listcc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }
                    //danh sach Bc
                    ItemSave.Listbc = "";
                    if (ItemSave.Bclist.Count > 0)
                    {
                        if (ItemSave.Bclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSave.Bclist)//cho nay phai chu y k can xet user co trung user dang nhap vi no la tin gui di (khac voi tin den)
                            {
                                ItemSave.Listbc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }

                    ItemSave = TinnhanDal.Update(ItemSave);

                    sb.Append("1");
                    break;
                    #endregion
                case "send":
                #region send
                Tinnhan Itemsend = new Tinnhan();


                if (string.IsNullOrEmpty(_TinID))
                    {
                        Itemsend.RowID = Guid.NewGuid();
                        Itemsend.Ngaygui = DateTime.Now;
                        Itemsend = TinnhanDal.InsertDraff(Itemsend);
                        if (Itemsend.TinID == 0)
                            break;
                }
                Itemsend.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                TinhanMemberDal.ClearTemp(Itemsend.TinID);

                //xu ly nguoi gui
                TinhanMember Itemguisend = new TinhanMember();
                Itemguisend.TinID = Itemsend.TinID;
                Itemguisend.User = Security.Username;
                Itemguisend.Gui = true;
                Itemguisend.Dagui = true;
                Itemguisend = TinhanMemberDal.Insert(Itemguisend);

                //xu ly danh sach nguoi nhan
                string[] _nguoinhansend = _Nguoinhan.Split(new char[] { ',' });
                for (int i = 0; i < _nguoinhansend.Length - 1; i++)
                {
                    TinhanMember Itemnhan = new TinhanMember();
                    Itemnhan.TinID = Itemsend.TinID;
                    Itemnhan.User = _nguoinhansend[i];
                    Itemnhan.Thuden = true;
                    Itemnhan.Nhan = true;
                    Itemnhan = TinhanMemberDal.InsertNhan(Itemnhan);
                }
                    
                //xu ly danh sach Cc
                string[] _Ccsend = _UserCC.Split(new char[] { ',' });
                for (int i = 0; i < _Ccsend.Length - 1; i++)
                {
                    TinhanMember Itemcc = new TinhanMember();
                    Itemcc.TinID = Itemsend.TinID;
                    Itemcc.User = _Ccsend[i];
                    Itemcc.UserCC = true;
                    Itemcc.Thuden = true;
                    Itemcc = TinhanMemberDal.InsertNhan(Itemcc);
                }

                //xu ly danh sach Bc
                string[] _Bcsend = _UserBC.Split(new char[] { ',' });
                for (int i = 0; i < _Bcsend.Length - 1; i++)
                {
                    TinhanMember Itembc = new TinhanMember();
                    Itembc.TinID = Itemsend.TinID;
                    Itembc.User = _Bcsend[i];
                    Itembc.UserBC = true;
                    Itembc.Thuden = true;
                    Itembc = TinhanMemberDal.InsertNhan(Itembc);
                }

                //cap nhat trang thai tin nhan
                Itemsend = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                Itemsend.Tieude = _Tieude;
                Itemsend.Noidung = _Noidung;
                Itemsend.Dagui = true;
                Itemsend.Ngaygui = DateTime.Now;
                Itemsend.Nguoigui = Security.Username;
                Itemsend.Usergui = Itemsend.NguoiguiObj.Ten + "(" + Security.Username + "),";
                Itemsend.Quantrong = Convert.ToBoolean(_Quantrong);

             

                //xu ly danh sach File
                if (_File.Length > 1)
                    Itemsend.File = true;
                else
                    Itemsend.File = false;

                //danh sach nguoi nhan
                Itemsend.Nguoinhan = "";
                Itemsend.Listnguoinhan = "";
                if (Itemsend.Nguoinhanlist.Count > 0)
                {

                    foreach (TinhanMember item in Itemsend.Nguoinhanlist)
                    {
                        Itemsend.Nguoinhan += item.Ten + "(" + item.User + "),";
                        Itemsend.Listnguoinhan += item.Ten + "(" + item.User + "),";
                    }

                }
                //danh sach Cc
                Itemsend.Listcc = "";
                if (Itemsend.Cclist.Count > 0)
                {
                    if (Itemsend.Cclist[0].ID != 0)
                    {
                        foreach (TinhanMember item in Itemsend.Cclist)
                        {
                            Itemsend.Listcc += item.Ten + "(" + item.User + "),";
                        }
                    }
                }
                //danh sach Bc
                Itemsend.Listbc = "";
                if (Itemsend.Bclist.Count > 0)
                {
                    if (Itemsend.Bclist[0].ID != 0)
                    {
                        foreach (TinhanMember item in Itemsend.Bclist)//cho nay phai chu y k can xet user co trung user dang nhap vi no la tin gui di (khac voi tin den)
                        {
                            Itemsend.Listbc += item.Ten + "(" + item.User + "),";
                        }
                    }
                }

                Itemsend = TinnhanDal.Update(Itemsend);
                   
                sb.Append("1");
                break;
                #endregion
                case "saveDoc":
                    #region Lưu tài liệu
                    if (!string.IsNullOrEmpty(_F_TinID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_TinID));
                        item.PID = new Guid(_RowID);
                        item = FilesDal.Update(item);
                        sb.AppendFormat("1");
                    }
                    break;
                    #endregion
                case "DeleteDoc":
                    #region Xóa tài liệu đính kèm
                    if (!string.IsNullOrEmpty(_F_TinID))
                    {
                        Files item = FilesDal.SelectById(Convert.ToInt32(_F_TinID));
                        string _files = Server.MapPath("~/up/d/") + item.ThuMuc;
                        string _file = _files + @"\" + item.Ten + item.MimeType;
                        if (Directory.Exists(_files))
                        {
                            File.Delete(_file);
                            Directory.Delete(_files);
                        }
                        FilesDal.DeleteById(item.ID);
                    }
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">

</div>
<div id=""Tinnhanmdl-dlgNew"">

<table>
    <tr>
        <td class=""adm-col-header"" valign=""top""><strong>Gửi tới:</strong> <input style=""display:none""  class=""admtxt ID"" /></td>
        <td valign=""top"" nowrap=""nowrap"">
 
            <div class=""adm-textarea-small-12 NguoinhanTo"" style=""float:left;"">
                <input class=""adm-token-input Nguoinhan"" />
            </div>
           <div style=""float: left; width: 120px;""> 
                <a class=""mdl-head-btn mdl-head-add"" id=""Tinnhanmdl-addnguoinhanBtn"" href=""javascript:tinNhanObj.addnguoinhan();"">+</a>
               
            </div>
        
</div></td>
        <td valign=""top""></td>
    </tr>
    <tr>
        <td class=""adm-col-header"" valign=""top"" ><strong>Cc:</strong></td>
        <td valign=""top"">
            <div class=""adm-textarea-small-12 CcTo"" style=""float:left;"">
                <input class=""adm-token-input Cc"" />
            </div>
            <div style=""float: left; width: 120px;""> 
                <a class=""mdl-head-btn mdl-head-add"" id=""Tinnhanmdl-addccBtn"" href=""javascript:tinNhanObj.addcc();"">+</a>
                 <a class=""mdl-head-btn mdl-head-add"" id=""Tinnhanmdl-bcBtn"" href=""javascript:tinNhanObj.thembc();"">Thêm Bc</a>
            </div>
        </td>
        <td valign=""top""></td>
    </tr>

    <tr id=""rowbc"" style=""display:none"">
        <td class=""adm-col-header"" valign=""top"" ><strong>Bc:</strong></td>
        <td valign=""top"">
            <div class=""adm-textarea-small-12 BcTo"" style=""float:left;"">
                <input class=""adm-token-input Bc"" />
            </div>
                <div style=""float: left; width: 120px;""> 
                <a class=""mdl-head-btn mdl-head-add"" id=""Tinnhanmdl-addbcBtn"" href=""javascript:tinNhanObj.addbc();"">+</a>
            </div>
        </td>
        <td valign=""top""></td>
    </tr>

    <tr>
        <td class=""adm-col-header"" valign=""top""><strong>Tiêu đề:</strong></td>
        <td valign=""top"">
            <input class=""adm-textarea-small-12 Tieude"" />
        </td>
        <td valign=""top""></td>
    </tr>
   
    <tr>
        <td class=""adm-col-header"" valign=""top""><strong> File kèm theo</strong></td > 
        <td class="""" valign=""top"" style=""float:left;"">
                 <div class=""adm-textarea-small-File"" style=""float:left;"">
                    <div class=""adm-upload-fileList""></div> 
                </div>
              <a href=""javascript:;""  class=""adm-uploadfile-btn File mdl-head-btn"" ref="""">Upload File</a>
        </td > 
        <td class=""adm-col-header"" valign=""top"" ><td/>
    </tr>
  
    <tr>
        <td class=""adm-col-header"" valign=""top"">&nbsp;<strong>Nội dung:</strong></td>
        <td class="""" valign=""top"" >
            <input type=""checkbox"" class=""Quantrong"" />Quang trọng
            <input type=""checkbox"" class=""Tinpopup"" />Thông báo Popup
            <input type=""checkbox"" class=""Tindidong"" />Thông báo tới di động
        </td>
        <td valign=""top""></td>
    </tr>

    <tr>
        <td valign=""top""></td>
        <td valign=""top"" >
            <textarea class=""Noidung""></textarea> 
          
        </td>
        <td valign=""top""></td>
    </tr>
     <tr>
            <td valign=""top"" colspan=2>
                <a class=""mdl-head-btn mdl-head-save"" id=""Tinnhanmdl-saveBtn"" href=""javascript:tinNhanObj.save();"">Lưu nháp</a>
                <a class=""mdl-head-btn mdl-head-del"" id=""Tinnhanmdl-delBtn"" href=""javascript:tinNhanObj.del();"">Xóa</a>
                <a class=""mdl-head-btn mdl-head-add"" id=""Tinnhanmdl-sendBtn"" href=""javascript:tinNhanObj.send();"">Gửi</a>
                <a class=""mdl-head-btn mdl-head-save"" id=""Tinnhanmdl-newBtn"" href=""javascript:tinNhanObj.themmoi();"" style=""display:none"">Thư mới</a>
                <span class=""admInfo""></span><br />
                <span class=""admMsg""></span>
              
            </td>
            <td valign=""top""></td>
        </tr>
    </table>
</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.JScript1.js")
                        , "{tinNhanObj.setup(); }");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




