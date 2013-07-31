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
[assembly: WebResource("cnn.plugin.tinNhan.daXoa.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.tinNhan.daXoa.htm.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.daXoa.htm1.htm", "text/html")]
[assembly: WebResource("cnn.plugin.tinNhan.daXoa.htm2.htm", "text/html")]
namespace cnn.plugin.tinNhan.daXoa
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _F_TinID = Request["F_TinID"];


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
            string _chuyentoi = Request["chuyentoi"];
            string _s = Request["s"];

            List<jgridRow> ListRow;
            #endregion
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TN_TinID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "DESC";

                    //Pager<tinnhan> pager = tinnhanDal.pagerNormal("", false, jgrsidx + " " + jgrsord, _q, _PID);
                    Pager<Tinnhan> pager = TinnhanDal.GetTindaxoa("", false, jgrsidx + " " + jgrsord,Security.Username,_s);
                    string Usergui;
                    string[] arUsergui;
                    ListRow = new List<jgridRow>();
                    foreach (Tinnhan item in pager.List)
                    {
                      
                        if (item.forward)
                            item.Tieude=string.Format(@"(FW){0}", item.Tieude);
                        if (!item.Doc)
                            item.Tieude = string.Format(@"<strong>{0}</strong>", item.Tieude);

                        arUsergui = item.Usergui.Split(new char[] { '(' });

                        Usergui = arUsergui[1].Remove(arUsergui[1].Length - 2);
                        if (Usergui == Security.Username)
                            item.Usergui = "Tôi.";

                        item.Tieude = string.Format(@"<a href=""javascript:tinnhandaxoaObj.selectRow('{0}')"" >{1}</a>", item.TinID, item.Tieude);
                        ListRow.Add(new jgridRow(item.TinID.ToString(), new string[] 
                        { 
                             item.Thutu.ToString()
                            , item.TinID.ToString()
                            ,(item.Co ? string.Format(@"<img style=""height:20px;width:20px;border-width:0px;"" src=""../css/ui/images/plugin-tinnhan-flag.bmp""/>" ) : "")
                            ,item.Usergui
                            ,(item.Quantrong ? string.Format(@"<img style=""height:20px;width:20px;border-width:0px;"" src=""../css/ui/images/plugin-tinnhan-quantrong.png""/>{0}" , item.Tieude) : item.Tieude)
                            // , item.Tieude
                          
                            ,string.Format(@"{0} {1}", item.Ngaygui.ToString("dd/MM/yyyy"),item.Ngaygui.ToShortTimeString())
                            //,item.Dagui.ToString()
                            //,item.File.ToString()
                            
                            ,(item.File ? @"<img style=""height:20px;width:20px;border-width:0px;"" src=""../css/ui/images/plugin-tinnhan-file.bmp""/>" : "")
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pager.TotalPages.ToString(), pager.Total.ToString(), ListRow);
                    // jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    //Security.Username
                    break;
                    #endregion
                case "insertTin":
                    #region lưu dữ liệu tạm
                    Tinnhan ItemInsert = new Tinnhan();
                    ItemInsert.RowID = Guid.NewGuid();


                    ItemInsert.Tieude = "";
                    ItemInsert.Noidung = "";
                    ItemInsert.Ngaygui = DateTime.Now;
                    ItemInsert.Usergui = Security.Username;

                    ItemInsert.File = false;


                    ItemInsert = TinnhanDal.InsertDraff(ItemInsert);
                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(ItemInsert));
                    break;
                    #endregion
                case "insertTinct":
                    #region lưu dữ liệu tạm


                    Tinnhan ItemInsertct = new Tinnhan();
                    ItemInsertct.RowID = Guid.NewGuid();


                    ItemInsertct.Tieude = "";
                    ItemInsertct.Noidung = "";
                    ItemInsertct.Ngaygui = DateTime.Now;
                    //ItemInsert.Trangthai =0;

                    ItemInsertct.File = false;

                    Tinnhan ItemOld = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    ItemInsertct.File = ItemOld.File;

                    ItemInsert = TinnhanDal.InsertDraff(ItemInsertct);
                    if (ItemOld.File)
                    {
                        foreach (Files itemf in ItemOld.Filelist)
                        {
                            itemf.PID = ItemInsertct.RowID;
                            FilesDal.Insert(itemf);
                        }
                    }
                    

                    sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(ItemInsert));
                    break;
                    #endregion
                case "getInfoct":
                    #region getInfoct chuyen tiep
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        Tinnhan Item=TinnhanDal.SelectById2(Convert.ToInt32(_TinID));
                        Item.Nguoigui = string.Format(@"<span _value=""{0}"" class=""adm-token-item-radi"">{1}<a href=""javascript:;"" class=""removeBtn"">x</a></span>", Item.NguoiguiObj.User, Item.NguoiguiObj.Ten);
                        
                        if (Item.Filelist.Count > 0)
                        {
                            if (Item.Filelist[0].ID != 0)
                            {
                                foreach (Files item in Item.Filelist)
                                {
                                    Item.FileListStr += string.Format(@"<span _value=""{0}"" class=""adm-token-item-radi""  onclick=""javascript:document.location.href='Default.aspx?act=download&ID={0}'"">{1}<a href=""javascript:;"" class=""removeBtn"">x</a></span>"
                                        , item.ID, item.Ten);
                                }
                            }
                        }


                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(Item));
                        //sb.Append("(" + JavaScriptConvert.SerializeObject(Item) + ")");
                    }
                    break;
                    #endregion
                case "getInfotl":
                    #region getInfotl tra loi
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        Tinnhan Item = TinnhanDal.SelectById2(Convert.ToInt32(_TinID));
                        Item.Nguoigui = string.Format(@"<span _value=""{0}"" class=""adm-token-item-radi"">{1}<a href=""javascript:;"" class=""removeBtn"">x</a></span>", Item.NguoiguiObj.User, Item.NguoiguiObj.Ten);

                        sb.Append("(" + JavaScriptConvert.SerializeObject(Item) + ")");
                    }
                    break;
                    #endregion
                case "getInfo":
                    #region chi tiết
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        Tinnhan Item = TinnhanDal.SelectById2(Convert.ToInt32(_TinID));
                        Item.Nguoigui = Item.NguoiguiObj.Ten + "(" + Item.NguoiguiObj.User + "),";
                        Item.sNgaygui = string.Format(@"{0} {1}", Item.Ngaygui.ToString("dd/MM/yyyy"), Item.Ngaygui.ToShortTimeString());

                        string listFile = @"<div class=""pp_group_titlebar"">";
                        if (Item.Filelist.Count > 0)
                        {
                            listFile += @"<b>" + Item.Filelist.Count.ToString() + @" tệp đính kèm</b>&nbsp;&mdash;&nbsp;";
                            //listFile += @"<a href="""" id="":1ay"">Tải xuống tất cả tệp đính kèm</a> ";
                            listFile += @"</div>";
                            listFile += @"<div class=""pp_media_bar hq"">";


                            if (Item.Filelist[0].ID != 0)
                            {
                                foreach (Files item in Item.Filelist)
                                {
                                    //Item.FileListStr += string.Format(@"<a href=""javascript:;"" class=""removeBtn"">x</a><a href=""Default.aspx?act=download&ID={0}"">{1}</a>"
                                    //    , item.ID, item.Ten);
                                    listFile += @" <table cellpadding=""0"" class=""hr cf"">";
                                    listFile += @"<tr>";
                                    listFile += @"   <td class=""hw"">";
                                    listFile += string.Format(@"<a href=""Default.aspx?act=download&ID={0}"">", item.ID);
                                    listFile += @"<img class=""hu"" alt="""" src=""../css/ui/images/plugin-tinnhan-file-doc.jpg"">";
                                    listFile += @"</a>";
                                    listFile += @"</td>";
                                    listFile += @"<td>";
                                    listFile += string.Format(@"<b>{0}</b><br>", item.Ten);
                                    listFile += string.Format(@" {0}K&nbsp;&nbsp; <span id="":1as"">", item.Size.ToString());
                                    listFile += string.Format(@" <a   href=""Default.aspx?act=download&ID={0}"">Tải xuống</a> </span>", item.ID);
                                    listFile += @" </td>";
                                    listFile += @" </tr>";
                                    listFile += @" </table>";
                                }
                            }
                        }
                        listFile += "</div>";
                        Item.FileListStr = listFile;
                        //danh sach nguoi nhan
                        if (Item.Nguoinhanlist.Count > 0)
                        {
                           
                            foreach (TinhanMember item in Item.Nguoinhanlist)
                            {
                                Item.Nguoinhan += item.Ten + "(" + item.User + "),";
                            }
                           
                        }
                        //danh sach Cc
                        //if (Item.UserCC == true)
                        //{
                            if (Item.Cclist.Count > 0)
                            {
                                if (Item.Cclist[0].ID != 0)
                                {
                                    foreach (TinhanMember item in Item.Cclist)
                                    {
                                        Item.Listcc += item.Ten + "(" + item.User + "),";
                                    }
                                }
                            }
                        //}
                        //danh sach Bc
                        //if (Item.UserBC == true)
                        //{
                            if (Item.Bclist.Count > 0)
                            {
                                if (Item.Bclist[0].ID != 0)
                                {
                                    foreach (TinhanMember item in Item.Bclist)
                                    {
                                        if (item.User == Security.Username)
                                        {
                                            Item.Listbc += item.Ten + "(" + item.User + "),";
                                            break;
                                        }
                                    }
                                }
                            }
                        //}
                        if (!Item.Doc)
                        {
                            TinhanMember imember = TinhanMemberDal.SelectByTinID(Item.TinID,Security.Username);
                            imember.Doc = true;
                            TinhanMemberDal.Update(imember);
                        }
                        sb.Append("(" + JavaScriptConvert.SerializeObject(Item) + ")");
                    }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(TinnhanDal.SelectById(Convert.ToInt32(_TinID))) + ")");
                    }
                    break;
                    #endregion
                case "delEmpty":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        TinnhanDal.DelEmpty(int.Parse(_TinID));
                    }
                    break;
                    #endregion
                case "del":
                    #region Xóa
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        _TinID = _TinID.Remove(_TinID.Length - 1, 1);
                        if (_TinID.StartsWith(","))
                            _TinID = _TinID.Remove(0, 1);
                        TinnhanDal.XoaBylistId(_TinID, Security.Username);
                    }
                    break;
                    #endregion
                case "datco":
                    #region datco
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        //TinnhanDal.DeletelistById(_TinID);
                        _TinID = _TinID.Remove(_TinID.Length-1, 1);
                        TinhanMemberDal.DatcoBylistId(_TinID,Security.Username);
                    }
                    break;
                    #endregion
                case "boco":
                #region boco
                    if (!string.IsNullOrEmpty(_TinID))
                    {
                        //TinnhanDal.DeletelistById(_TinID);
                        _TinID = _TinID.Remove(_TinID.Length-1, 1);
                        TinhanMemberDal.BocoBylistId(_TinID, Security.Username);
                    }
                break;
                #endregion
                case "chuyentoi":
                #region chuyentoi
                if (!string.IsNullOrEmpty(_TinID))
                {
                    _TinID = _TinID.Remove(_TinID.Length - 1, 1);
                    if (_TinID.StartsWith(","))
                        _TinID = _TinID.Remove(0, 1);
                    TinhanMemberDal.ChuyentoiBylistId(_TinID, Security.Username, _chuyentoi);
                }
                break;
                #endregion
                case "savetl":
                    #region lưu
                    Tinnhan ItemSavetl = new Tinnhan();

                    if (string.IsNullOrEmpty(_TinID))
                     {
                         ItemSavetl.RowID = Guid.NewGuid();
                         ItemSavetl.Ngaygui = DateTime.Now;
                         ItemSavetl = TinnhanDal.InsertDraff(ItemSavetl);
                         if (ItemSavetl.TinID == 0)
                             break;
                    }
                    ItemSavetl.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                    TinhanMemberDal.ClearTemp(ItemSavetl.TinID);

                    //xu ly nguoi gui
                    TinhanMember Itemguisavetl = new TinhanMember();
                    Itemguisavetl.TinID = ItemSavetl.TinID;
                    Itemguisavetl.User = Security.Username;
                    Itemguisavetl.Gui = true;
                    Itemguisavetl = TinhanMemberDal.Insert(Itemguisavetl);
                    
                    //xu ly danh sach nguoi nhan
                    string[] _listnguoinhan = _Nguoinhan.Split(new char[] { ',' });
                    for (int i = 0; i < _listnguoinhan.Length - 1; i++)
                    {
                        TinhanMember Itemnhantl = new TinhanMember();
                        Itemnhantl.TinID = ItemSavetl.TinID;
                        Itemnhantl.User = _listnguoinhan[i];
                        Itemnhantl.Nhan = true;
                        Itemnhantl = TinhanMemberDal.InsertNhan(Itemnhantl);
                    }
                    
                    //xu ly danh sach Cc
                    string[] _Cc = _UserCC.Split(new char[] { ',' });
                    for (int i = 0; i < _Cc.Length - 1; i++)
                    {
                        TinhanMember Itemcctl = new TinhanMember();
                        Itemcctl.TinID = ItemSavetl.TinID;
                        Itemcctl.User = _Cc[i];
                        Itemcctl.UserCC = true;
                        Itemcctl = TinhanMemberDal.InsertNhan(Itemcctl);
                    }

                    //xu ly danh sach Bc
                    string[] _Bc = _UserBC.Split(new char[] { ',' });
                    for (int i = 0; i < _Bc.Length - 1; i++)
                    {
                        TinhanMember Itembctl = new TinhanMember();
                        Itembctl.TinID = ItemSavetl.TinID;
                        Itembctl.User = _Bc[i];
                        Itembctl.UserBC = true;
                        Itembctl = TinhanMemberDal.InsertNhan(Itembctl);
                    }

                    ItemSavetl = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    ItemSavetl.Nguoigui = Security.Username;
                    ItemSavetl.Usergui = ItemSavetl.NguoiguiObj.Ten + "(" + Security.Username + "),";
                    ItemSavetl.Tieude = _Tieude;
                    ItemSavetl.Noidung = _Noidung;
                    ItemSavetl.Quantrong = Convert.ToBoolean(_Quantrong);

                    //xu ly danh sach File
                    //string[] _Filelist = _File.Split(new char[] { ',' });
                    if (_File.Length > 1)
                        ItemSavetl.File = true;
                    else
                        ItemSavetl.File = false;

                    //danh sach nguoi nhan
                    ItemSavetl.Nguoinhan = "";
                    ItemSavetl.Listnguoinhan = "";
                    if (ItemSavetl.Nguoinhanlist.Count > 0)
                    {

                        foreach (TinhanMember item in ItemSavetl.Nguoinhanlist)
                        {
                            ItemSavetl.Nguoinhan += item.Ten + "(" + item.User + "),";
                            ItemSavetl.Listnguoinhan += item.Ten + "(" + item.User + "),";
                        }

                    }
                    //danh sach Cc
                    ItemSavetl.Listcc = "";
                    if (ItemSavetl.Cclist.Count > 0)
                    {
                        if (ItemSavetl.Cclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSavetl.Cclist)
                            {
                                ItemSavetl.Listcc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }
                    //danh sach Bc
                    ItemSavetl.Listbc = "";
                    if (ItemSavetl.Bclist.Count > 0)
                    {
                        if (ItemSavetl.Bclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSavetl.Bclist)//cho nay phai chu y k can xet user co trung user dang nhap vi no la tin gui di (khac voi tin den)
                            {
                                ItemSavetl.Listbc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }

                    ItemSavetl = TinnhanDal.Update(ItemSavetl);

                    sb.Append("1");
                    break;
                    #endregion
                case "sendtl":
                    #region sendtl
                    Tinnhan ItemSendtl = new Tinnhan();

                    if (string.IsNullOrEmpty(_TinID))
                     {
                         ItemSendtl.RowID = Guid.NewGuid();
                         ItemSendtl.Ngaygui = DateTime.Now;
                         ItemSendtl = TinnhanDal.InsertDraff(ItemSendtl);
                         if (ItemSendtl.TinID == 0)
                             break;
                    }
                    ItemSendtl.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                    TinhanMemberDal.ClearTemp(ItemSendtl.TinID);

                    //xu ly nguoi gui
                    TinhanMember Itemguisendtl = new TinhanMember();
                    Itemguisendtl.TinID = ItemSendtl.TinID;
                    Itemguisendtl.User = Security.Username;
                    Itemguisendtl.Gui = true;
                    Itemguisendtl = TinhanMemberDal.Insert(Itemguisendtl);
                    
                    //xu ly danh sach nguoi nhan
                    string[] _listnguoinhantl = _Nguoinhan.Split(new char[] { ',' });
                    for (int i = 0; i < _listnguoinhantl.Length - 1; i++)
                    {
                        TinhanMember Itemnhantl = new TinhanMember();
                        Itemnhantl.TinID = ItemSendtl.TinID;
                        Itemnhantl.User = _listnguoinhantl[i];
                        Itemnhantl.Thuden = true;
                        Itemnhantl.Nhan = true;
                        Itemnhantl = TinhanMemberDal.InsertNhan(Itemnhantl);
                    }
                    
                    //xu ly danh sach Cc
                    string[] _Cctl = _UserCC.Split(new char[] { ',' });
                    for (int i = 0; i < _Cctl.Length - 1; i++)
                    {
                        TinhanMember Itemcctl = new TinhanMember();
                        Itemcctl.TinID = ItemSendtl.TinID;
                        Itemcctl.User = _Cctl[i];
                        Itemcctl.UserCC = true;
                        Itemcctl.Thuden = true;
                        Itemcctl = TinhanMemberDal.InsertNhan(Itemcctl);
                    }

                    //xu ly danh sach Bc
                    string[] _Bctl = _UserBC.Split(new char[] { ',' });
                    for (int i = 0; i < _Bctl.Length - 1; i++)
                    {
                        TinhanMember Itembctl = new TinhanMember();
                        Itembctl.TinID = ItemSendtl.TinID;
                        Itembctl.User = _Bctl[i];
                        Itembctl.UserBC = true;
                        Itembctl.Thuden = true;
                        Itembctl = TinhanMemberDal.InsertNhan(Itembctl);
                    }

                    ItemSendtl = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    ItemSendtl.Nguoigui = Security.Username;
                    ItemSendtl.Usergui = ItemSendtl.NguoiguiObj.Ten + "(" + Security.Username + "),";
                    ItemSendtl.Tieude = _Tieude;
                    ItemSendtl.Noidung = _Noidung;
                    ItemSendtl.Quantrong = Convert.ToBoolean(_Quantrong);
                    ItemSendtl.Dagui = true;
                    //xu ly danh sach File
                    //string[] _Filelist = _File.Split(new char[] { ',' });
                    if (_File.Length > 1)
                        ItemSendtl.File = true;
                    else
                        ItemSendtl.File = false;

                    //danh sach nguoi nhan
                    ItemSendtl.Nguoinhan = "";
                    ItemSendtl.Listnguoinhan = "";
                    if (ItemSendtl.Nguoinhanlist.Count > 0)
                    {

                        foreach (TinhanMember item in ItemSendtl.Nguoinhanlist)
                        {
                            ItemSendtl.Nguoinhan += item.Ten + "(" + item.User + "),";
                            ItemSendtl.Listnguoinhan += item.Ten + "(" + item.User + "),";
                        }

                    }
                    //danh sach Cc
                    ItemSendtl.Listcc = "";
                    if (ItemSendtl.Cclist.Count > 0)
                    {
                        if (ItemSendtl.Cclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSendtl.Cclist)
                            {
                                ItemSendtl.Listcc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }
                    //danh sach Bc
                    ItemSendtl.Listbc = "";
                    if (ItemSendtl.Bclist.Count > 0)
                    {
                        if (ItemSendtl.Bclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSendtl.Bclist)//cho nay phai chu y k can xet user co trung user dang nhap vi no la tin gui di (khac voi tin den)
                            {
                                ItemSendtl.Listbc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }

                    ItemSendtl = TinnhanDal.Update(ItemSendtl);
                    sb.Append("1");
                    break;
                    #endregion
                case "savect":  
                    #region lưu
                     Tinnhan ItemSavect = new Tinnhan();

                    if (string.IsNullOrEmpty(_TinID))
                     {
                         ItemSavect.RowID = Guid.NewGuid();
                         ItemSavect.Ngaygui = DateTime.Now;
                         ItemSavect = TinnhanDal.InsertDraff(ItemSavect);
                         if (ItemSavect.TinID == 0)
                             break;
                    }
                    ItemSavect.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                    TinhanMemberDal.ClearTemp(ItemSavect.TinID);

                    //xu ly nguoi gui
                    TinhanMember Itemguisavect = new TinhanMember();
                    Itemguisavect.TinID = ItemSavect.TinID;
                    Itemguisavect.User = Security.Username;
                    Itemguisavect.Gui = true;
                    Itemguisavect = TinhanMemberDal.Insert(Itemguisavect);
                    
                    //xu ly danh sach nguoi nhan
                    string[] _listnguoinhanct = _Nguoinhan.Split(new char[] { ',' });
                    for (int i = 0; i < _listnguoinhanct.Length - 1; i++)
                    {
                        TinhanMember Itemnhanct = new TinhanMember();
                        Itemnhanct.TinID = ItemSavect.TinID;
                        Itemnhanct.User = _listnguoinhanct[i];
                        Itemnhanct.Nhan = true;
                        Itemnhanct = TinhanMemberDal.InsertNhan(Itemnhanct);
                    }
                    
                    //xu ly danh sach Cc
                    string[] _Ccct = _UserCC.Split(new char[] { ',' });
                    for (int i = 0; i < _Ccct.Length - 1; i++)
                    {
                        TinhanMember Itemccct = new TinhanMember();
                        Itemccct.TinID = ItemSavect.TinID;
                        Itemccct.User = _Ccct[i];
                        Itemccct.UserCC = true;
                        Itemccct = TinhanMemberDal.InsertNhan(Itemccct);
                    }

                    //xu ly danh sach Bc
                    string[] _Bcct = _UserBC.Split(new char[] { ',' });
                    for (int i = 0; i < _Bcct.Length - 1; i++)
                    {
                        TinhanMember Itembcct = new TinhanMember();
                        Itembcct.TinID = ItemSavect.TinID;
                        Itembcct.User = _Bcct[i];
                        Itembcct.UserBC = true;
                        Itembcct = TinhanMemberDal.InsertNhan(Itembcct);
                    }

                    ItemSavect = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    ItemSavect.Nguoigui = Security.Username;
                    ItemSavect.Usergui = ItemSavect.NguoiguiObj.Ten + "(" + Security.Username + "),";
                    ItemSavect.Tieude = _Tieude;
                    ItemSavect.Noidung = _Noidung;
                    ItemSavect.Quantrong = Convert.ToBoolean(_Quantrong);
					ItemSavect.forward = true;
					
                    //xu ly danh sach File
                    if (_File.Length > 1)
                        ItemSavect.File = true;
                    else
                        ItemSavect.File = false;

                    //danh sach nguoi nhan
                    ItemSavect.Nguoinhan = "";
                    ItemSavect.Listnguoinhan = "";
                    if (ItemSavect.Nguoinhanlist.Count > 0)
                    {

                        foreach (TinhanMember item in ItemSavect.Nguoinhanlist)
                        {
                            ItemSavect.Nguoinhan += item.Ten + "(" + item.User + "),";
                            ItemSavect.Listnguoinhan += item.Ten + "(" + item.User + "),";
                        }

                    }
                    //danh sach Cc
                    ItemSavect.Listcc = "";
                    if (ItemSavect.Cclist.Count > 0)
                    {
                        if (ItemSavect.Cclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSavect.Cclist)
                            {
                                ItemSavect.Listcc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }
                    //danh sach Bc
                    ItemSavect.Listbc = "";
                    if (ItemSavect.Bclist.Count > 0)
                    {
                        if (ItemSavect.Bclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in ItemSavect.Bclist)
                            {
                                ItemSavect.Listbc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }

                    ItemSavect = TinnhanDal.Update(ItemSavect);

                    sb.Append("1");
                    break;
                    #endregion
                case "sendct":
                    #region send chuyen tiep
                     Tinnhan Itemsendct = new Tinnhan();

                    if (string.IsNullOrEmpty(_TinID))
                     {
                         Itemsendct.RowID = Guid.NewGuid();
                         Itemsendct.Ngaygui = DateTime.Now;
                         Itemsendct = TinnhanDal.InsertDraff(Itemsendct);
                         if (Itemsendct.TinID == 0)
                             break;
                    }
                    Itemsendct.TinID = Convert.ToInt32(_TinID);//chu y doan nay kha logic chu yeu la chi dung selectbyid 1 lan(o doan duoi)
                    TinhanMemberDal.ClearTemp(Itemsendct.TinID);

                    //xu ly nguoi gui
                    TinhanMember Itemguisendct = new TinhanMember();
                    Itemguisendct.TinID = Itemsendct.TinID;
                    Itemguisendct.User = Security.Username;
                    Itemguisendct.Gui = true;
                    Itemguisendct.Dagui = true;
                    Itemguisendct = TinhanMemberDal.Insert(Itemguisendct);

                    //xu ly danh sach nguoi nhan
                    string[] _nguoinhansendct = _Nguoinhan.Split(new char[] { ',' });
                    for (int i = 0; i < _nguoinhansendct.Length - 1; i++)
                    {
                        TinhanMember Itemnhanct = new TinhanMember();
                        Itemnhanct.TinID = Itemsendct.TinID;
                        Itemnhanct.User = _nguoinhansendct[i];
                        Itemnhanct.Thuden = true;
                        Itemnhanct.Nhan = true;
                        Itemnhanct = TinhanMemberDal.InsertNhan(Itemnhanct);
                    }

                    //xu ly danh sach Cc
                    string[] _Ccsendct = _UserCC.Split(new char[] { ',' });
                    for (int i = 0; i < _Ccsendct.Length - 1; i++)
                    {
                        TinhanMember Itemccct = new TinhanMember();
                        Itemccct.TinID = Itemsendct.TinID;
                        Itemccct.User = _Ccsendct[i];
                        Itemccct.UserCC = true;
                        Itemccct.Thuden = true;
                        Itemccct = TinhanMemberDal.InsertNhan(Itemccct);
                    }

                    //xu ly danh sach Bc
                    string[] _Bcsendct = _UserBC.Split(new char[] { ',' });
                    for (int i = 0; i < _Bcsendct.Length - 1; i++)
                    {
                        TinhanMember Itembcct = new TinhanMember();
                        Itembcct.TinID = Itemsendct.TinID;
                        Itembcct.User = _Bcsendct[i];
                        Itembcct.UserBC = true;
                        Itembcct.Thuden = true;
                        Itembcct = TinhanMemberDal.InsertNhan(Itembcct);
                    }


                    //cap nhat trang thai tin nhan

                    Itemsendct = TinnhanDal.SelectById(Convert.ToInt32(_TinID));
                    Itemsendct.Nguoigui = Security.Username;
                    Itemsendct.Usergui = Itemsendct.NguoiguiObj.Ten + "(" + Security.Username + "),";
                    Itemsendct.Tieude = _Tieude;
                    Itemsendct.Noidung = _Noidung;
                    Itemsendct.Quantrong = Convert.ToBoolean(_Quantrong);
                    Itemsendct.forward = true;
                    Itemsendct.Dagui = true;

                    //xu ly danh sach File
                    if (_File.Length > 1)
                        Itemsendct.File = true;
                    else
                        Itemsendct.File = false;

                    //danh sach nguoi nhan
                    Itemsendct.Nguoinhan = "";
                    Itemsendct.Listnguoinhan = "";
                    if (Itemsendct.Nguoinhanlist.Count > 0)
                    {

                        foreach (TinhanMember item in Itemsendct.Nguoinhanlist)
                        {
                            Itemsendct.Nguoinhan += item.Ten + "(" + item.User + "),";
                            Itemsendct.Listnguoinhan += item.Ten + "(" + item.User + "),";
                        }

                    }
                    //danh sach Cc
                    Itemsendct.Listcc = "";
                    if (Itemsendct.Cclist.Count > 0)
                    {
                        if (Itemsendct.Cclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in Itemsendct.Cclist)
                            {
                                Itemsendct.Listcc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }
                    //danh sach Bc
                    Itemsendct.Listbc = "";
                    if (Itemsendct.Bclist.Count > 0)
                    {
                        if (Itemsendct.Bclist[0].ID != 0)
                        {
                            foreach (TinhanMember item in Itemsendct.Bclist)
                            {
                                Itemsendct.Listbc += item.Ten + "(" + item.User + "),";
                            }
                        }
                    }

                    Itemsendct = TinnhanDal.Update(Itemsendct);
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
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.daXoa.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
    <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
        <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
        <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-tinnhandaxoa"" />
    </span>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinnhandaxoamdl-troveBtn"" href=""javascript:tinnhandaxoaObj.quaylai();"">Trở về</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinnhandaxoamdl-chuyentiepBtn"" href=""javascript:tinnhandaxoaObj.chuyentiep();"">Chuyển tiếp</a>
    <a class=""mdl-head-btn mdl-head-add"" id=""tinnhandaxoamdl-traloiBtn"" href=""javascript:tinnhandaxoaObj.traloi();"">Trả lời</a>

    <a class=""mdl-head-btn mdl-head-del"" id=""tinnhandaxoamdl-datcoBtn"" href=""javascript:tinnhandaxoaObj.datco();"">Đặt cờ</a>
    <a class=""mdl-head-btn mdl-head-del"" id=""tinnhandaxoamdl-bocoBtn"" href=""javascript:tinnhandaxoaObj.boco();"">Bỏ cờ</a>
    
    <a class=""mdl-head-btn mdl-head-del"" id=""tinnhandaxoamdl-delBtn"" href=""javascript:tinnhandaxoaObj.del();"">Xóa vĩnh viễn</a>

    <select id=""tinnhandaxoamdl-chuyentoiDop"" size=""1"" onChange=""tinnhandaxoaObj.chuyentoi(this)"">
        <option value=""nothing"" selected=""selected"">Di chuyển tới</option>
        <option value=""thuden"">Hòm thư đến</option>
        <option value=""thugui"">Hòm thư gửi</option>
        <option value=""daxoa"">Thư đã xóa</option>
        <option value=""spam"">Spam</option>
    </select>

  
</div>
<input style=""display:none""  id=""tinnhandaxoamdl-TinID"" />
<div id=""tinnhandaxoamdl-ListConten"">
    <div id=""tinnhandaxoa-List"">
        <table id=""tinnhandaxoamdl-List"" class=""mdl-list""></table>
    </div>
    <div id=""tinnhandaxoamdl-Pager""></div>
</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.daXoa.JScript1.js")
                        , "{tinnhandaxoaObj.setup();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
    }
}




