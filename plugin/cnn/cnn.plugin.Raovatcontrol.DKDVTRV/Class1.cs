//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.UI;
//using System.Web;
//using linh;
//using linh.frm;
//using linh.json;
//using linh.common;
//using linh.controls;
//using docsoft;
//using cnn.entities;
//using docsoft.entities;
//using System.Xml;
//using System.Globalization;
//using System.IO;
//[assembly: WebResource("cnn.plugin.Raovatcontrol.DKDVTRV.JScript1.js", "text/javascript", PerformSubstitution = true)]
//[assembly: WebResource("cnn.plugin.Raovatcontrol.DKDVTRV.htm.htm", "text/html")]

//namespace cnn.plugin.Raovatcontrol.DKDVTRV
//{
//    public class Class1: docPlugUI
//    {
//        protected override void Render(HtmlTextWriter writer)
//        {
//            StringBuilder sb = new StringBuilder();
//            ClientScriptManager cs = this.Page.ClientScript;
//            #region Tham số
//            string _ID = Request["ID"];
//            string _NgayHetHan = Request["NgayHetHan"];
//            string _NgayCapNhat = Request["NgayCapNhat"];
//            string _q = Request["q"];
//            string _super = Request["_super"];
//            string _vip = Request["_vip"];
//            string _hot = Request["_hot"];
//            string _user = Request["_user"];
//            string _DM_ID = Request["DM_ID"];
//            string _TINH_ID = Request["TINH_ID"];
//            string _NC_ID = Request["NC_ID"];
//            string _VIP_SUPER_NgayHetHan = Request["VIP_SUPER_NgayHetHan"];
//            string _VIP_VIP_NgayHetHan = Request["VIP_VIP_NgayHetHan"];
//            string _VIP_NoiBat_NgayHetHan = Request["VIP_NoiBat_NgayHetHan"];
//            string _DKhot = Request["DKhot"];
//            string _DKsuper = Request["DKsuper"];
//            string _DKvip = Request["DKvip"];
//            #endregion

//            switch (subAct)
//            {
//                case "SaveDuyet":
//                    #region Cập nhật đăng ký dịch vụ
//                    if (!string.IsNullOrEmpty(_ID))
//                    {

//                        DateTime dksupertime;
//                        DateTime dkviptime;
//                        DateTime dkhottime;
//                        if (!string.IsNullOrEmpty(_VIP_NoiBat_NgayHetHan))
//                        {
//                            dkhottime = Convert.ToDateTime(_VIP_NoiBat_NgayHetHan, new CultureInfo("vi-vn"));
//                        }
//                        else
//                        {
//                            dkhottime = Convert.ToDateTime("1/1/1970", new CultureInfo("vi-vn"));
//                        }


//                        if (!string.IsNullOrEmpty(_VIP_SUPER_NgayHetHan))
//                        {
//                            dksupertime = Convert.ToDateTime(_VIP_SUPER_NgayHetHan, new CultureInfo("vi-vn"));
//                        }
//                        else
//                        {
//                            dksupertime = Convert.ToDateTime("1/1/1970", new CultureInfo("vi-vn"));
//                        }

//                        if (!string.IsNullOrEmpty(_VIP_VIP_NgayHetHan))
//                        {
//                            dkviptime = Convert.ToDateTime(_VIP_VIP_NgayHetHan, new CultureInfo("vi-vn"));

//                        }
//                        else
//                        {
//                            dkviptime = Convert.ToDateTime("1/1/1970", new CultureInfo("vi-vn"));
//                        }
//                        RaoVatDal.UpdateSaveDuyet(_ID, _DKsuper, _DKvip, _DKhot, dksupertime, dkviptime, dkhottime);
//                        sb.Append("1");
//                    }
//                    break;
//                    #endregion
//                case "edit":
//                #region chỉnh sửa
//                    if (!string.IsNullOrEmpty(_ID))
//                    {
//                        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(RaoVatDal.SelectById(Convert.ToInt32(_ID))));
//                    }
//                    break;
//                #endregion
//                case "get":
//                #region
//                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "RV_VIP_SUPER";
//                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
//                    bool isAdmin = MemberRoleDal.IsInRole(Security.Username, "Admin");
//                    List<RaoVat> Listrequest;
//                    if (isAdmin == true)
//                    {
//                        Listrequest = RaoVatDal.SelectRequestDKDV(_super, _vip, _hot, _q, "", jgrsidx + " " + jgrsord, _DM_ID, _TINH_ID, _NC_ID);
//                    }
//                    else
//                    {
//                        Listrequest = RaoVatDal.SelectRequestDKDV(_super, _vip, _hot, _q, Security.Username, jgrsidx + " " + jgrsord, _DM_ID, _TINH_ID, _NC_ID);
//                    }

                    
//                    List<jgridRow> ListRowRequestDKDV = new List<jgridRow>();
//                    foreach (RaoVat item in Listrequest)
//                    {
//                        ListRowRequestDKDV.Add(new jgridRow(item.ID.ToString(),
//                            new string[]
//                            {
//                                item.ID.ToString()
//                                ,string.Format("<img src=\"../up/i/{0}\" height=\"50px\" width=\"65px\"/>",item.Anh1)
//                                ,item.Ten
//                                ,item._Nhucau_Ten
//                                ,item.DangKy_SUPER.ToString()
//                                ,item.VIP_SUPER_NgayHetHan.ToString("dd/MM/yyyy") == "01/01/1970" ? "" : item.VIP_SUPER_NgayHetHan.ToString("dd/MM/yyyy")
//                                ,item.DangKy_VIP.ToString()
//                                ,item.VIP_VIP_NgayHetHan.ToString("dd/MM/yyyy") == "01/01/1970" ? "" : item.VIP_VIP_NgayHetHan.ToString("dd/MM/yyyy")
//                                ,item.DangKy_NoiBat.ToString()
//                                ,item.VIP_NoiBat_NgayHetHan.ToString("dd/MM/yyyy")== "01/01/1970" ? "" : item.VIP_NoiBat_NgayHetHan.ToString("dd/MM/yyyy")
//                                ,item.NgayCapNhat.ToString("dd/MM/yyyy")
//                                ,isAdmin ?  string.Format(@"<a _id=""{0}"" onclick=""dkdvtrvFn.admDuyet(this);"" class=""task-item-btn"" href=""javascript:;"">Duyệt</a>",item.ID) :(item.TenNguoiDang==Security.Username ? string.Format(@"<a _id=""{0}"" onclick=""dkdvtrvFn.View(this);"" class=""raovat-item-btn"" href=""javascript:;"">Xem</a>",item.ID) : "")
                                
//                            }));
//                    }
//                    jgrid grid1 = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, "1", Listrequest.Count.ToString(), ListRowRequestDKDV);
//                    sb.Append(JavaScriptConvert.SerializeObject(grid1));
//                    break;
//                #endregion
//                case "duyet":
//                #region duyệt mẩu tin
//                    if (!string.IsNullOrEmpty(_ID))
//                    {
//                        //RaoVatDal.DeleteById(Convert.ToInt32(_ID));
//                        RaoVatDal.DuyetListMautin(_ID);
                        
//                    }
//                    break;
//                #endregion
//                case "duyetchitiet":
//                #region duyệt chi tiết
//                    break;
//                #endregion
//                case "scpt":
//                #region Nạp js
//                    sb.AppendFormat(@"{0}"
//                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Raovatcontrol.DKDVTRV.JScript1.js"));
//                    break;
//                #endregion
//                default:
//                #region nap js
//                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);

//                    sb.Append(@"
//                            <div  id=""RaoVatSubmdl-head"" class=""mdl-head"">
//                                <a class=""mdl-head-btn mdl-head-edit"" id=""Raovatsbmdl-duyetBtn"" href=""javascript:dkdvtrvFn.duyet();"">Duyệt</a>
//                                <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
//                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                    <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-RaovatMdl-subDKFVMdl"" />
//                                </span>
//                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDMraovat""/>
//                                </span>
//                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterNCraovat""/>
//                                </span>
//                                <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                    <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                    <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterTINHraovat""/>
//                                </span>            
//                            </div>
//                            <table id=""RaovatFnMdl-subDKDVMdl-List"" class=""mdl-list""></table>
//                        
//                    ");
//                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
//                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.Raovatcontrol.DKDVTRV.JScript1.js")
//                        , "{dkdvtrvFn.loadgrid();}");
//                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
//                    break;
//                #endregion
//            }

//            writer.Write(sb.ToString());
//            base.Render(writer);
//        }
//    }
//}
