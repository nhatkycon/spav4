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
//[assembly: WebResource("cnn.plugin.raoVatMgr.JScript1.js", "text/javascript", PerformSubstitution = true)]
//[assembly: WebResource("cnn.plugin.raoVatMgr.htm.htm", "text/html")]

//namespace cnn.plugin.raoVatMgr
//{
//    public class Class1: docPlugUI
//    {
//        protected override void Render(HtmlTextWriter writer)
//        {
//            StringBuilder sb = new StringBuilder();
//            ClientScriptManager cs = this.Page.ClientScript;

//            #region tham số
//            string _ID = Request["ID"];
//            string _DM_ID = Request["DM_ID"];
//            string _TINH_ID = Request["TINH_ID"];
//            string _TINH_Ten= Request["TINH_Ten"];
//            string _NC_ID = Request["NC_ID"];
//            string _Lang = Request["Lang"];
//            string _Alias = Request["Alias"];
//            string _Ten = Request["Ten"];
//            string _MoTa = Request["MoTa"];
//            string _NoiDung = Request["NoiDung"];
//            string _NgayHetHan = Request["NgayHetHan"];
//            string _Anh1 = Request["Anh1"];
//            string _VIP_SUPER = Request["VIP_SUPER"];
//            string _VIP_SUPER_NgayHetHan = Request["VIP_SUPER_NgayHetHan"];
//            string _VIP_VIP = Request["VIP_VIP"];
//            string _VIP_VIP_NgayHetHan = Request["VIP_VIP_NgayHetHan"];
//            string _VIP_VIP_NgayHetHanDK = Request["VIP_VIP_NgayHetHanDK"];


//            string _VIP_NoiBat = Request["VIP_NoiBat"];
//            string _VIP_NoiBatDK = Request["VIP_NoiBatDK"];
//            string _VIP_NoiBat_NgayHetHan = Request["VIP_NoiBat_NgayHetHan"];
//            string _Active = Request["Active"];
//            string _Anonymous = Request["Anonymous"];
//            string _AnonymousPassword = Request["AnonymousPassword"];
//            string _q = Request["q"];
//            string _super = Request["_super"];
//            string _vip = Request["_vip"];
//            string _hot = Request["_hot"];
//            string _DM_Ma = Request["DM_Ma"];
//            string _user = Request["_user"];
//            string _hethan = Request["_hethan"];
//            string _Publish = Request["Publish"];
//            string _DKhot = Request["DKhot"];
//            string _DKsuper = Request["DKsuper"];
//            string _DKvip = Request["DKvip"];
            
//            List<jgridRow> ListRow;
//            RaoVat Item;
//            LienHe ItemLienHe;
//            #endregion
//            switch (subAct)
                    
//            {
//                case "get":
//                #region lấy dữ liệu cho lưới
//                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "RV_VIP_SUPER";
//                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
//                    Pager<RaoVat> pager = RaoVatDal.pagerNormallord("", false, jgrsidx + " " + jgrsord, _q, _super, _vip, _hot, _Active, Security.Username, _hethan, _DM_ID, _TINH_ID, _NC_ID, _Lang, _Publish, Convert.ToInt32(jgRows));
//                    ListRow = new List<jgridRow>();
//                    foreach (cnn.entities.RaoVat item in pager.List)
//                    {
//                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[]{
//                            item.ID.ToString()
//                            ,string.Format("<img src=\"../up/i/{0}?ref={1}\" height=\"50px\" width=\"50px\"   />",item.Anh1,Guid.NewGuid().ToString())
//                            ,item.Ten
//                            ,item._Nhucau_Ten
//                            ,item.NgayDang.ToString("dd/MM/yyyy")
//                            ,item.TenNguoiDang
//                            ,item.Publish.ToString()
//                            ,item.Active.ToString()
//                        }));
//                    }
//                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pager.TotalPages.ToString(), pager.Total.ToString(), ListRow);
//                    sb.Append(JavaScriptConvert.SerializeObject(grid));
//                    break;
//                #endregion
//                case "scpt":
//                    #region Nạp js
//                    sb.AppendFormat(@"{0}"
//                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.JScript1.js"));
//                    break;
//                    #endregion
//                default:
//                    #region
//                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    
//                        sb.Append(@"
//                        <div id=""RaoVatmdl-head"" class=""mdl-head"">
//                            <span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
//                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                <input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-Raovat"" />
//                            </span>
//                            <a class=""mdl-head-btn mdl-head-add"" id=""Raovatmdl-addBtn"" href=""javascript:raovatfn.add();"">Thêm</a>
//                            <a class=""mdl-head-btn mdl-head-edit"" id=""Raovatmdl-editBtn"" href=""javascript:raovatfn.edit();"">Sửa</a>
//                            <a class=""mdl-head-btn mdl-head-del"" id=""Raovatmdl-delBtn"" href=""javascript:raovatfn.del();"">Xóa</a>
//                        
//                            <a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"">
//                                <span class=""mdl-headTask-Loc-Title"">
//                                    <span class=""ui-icon ui-icon-triangle-1-s""></span>        
//                                        Duyệt tin 
//                                    <span class=""mdl-headTask-Loc-Title-Display""></span>
//                                </span>
//                                <span class=""mdl-headTask-Loc-Box"">
//                                    <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
//                                        <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
//                                            <span onclick=""javascript:raovatfn.duyet('true','');"">Dừng tin</span>
//                                            <span onclick=""javascript:raovatfn.duyet('false','');"">Bỏ dừng tin</span>
//                                        </span>
//                                    </span>
//                                </span>
//                            </a>
//                            <a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"">
//                                <span class=""mdl-headTask-Loc-Title"">
//                                    <span class=""ui-icon ui-icon-triangle-1-s""></span>        
//                                        Lọc tin 
//                                    <span class=""mdl-headTask-Loc-Title-Display""></span>
//                                </span>
//                                <span class=""mdl-headTask-Loc-Box"">
//                                    <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
//                                        <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
//                                            <span onclick=""javascript:raovatfn.filterfn(1,1,1,'true','','','');"">Đang đăng</span>
//                                            <span onclick=""javascript:raovatfn.filterfn(1,1,1,'false','','','');"">Quá hạn</span>
//                                            <span onclick=""javascript:raovatfn.filterfn(1,1,1,'','','','true');"">Tạm dừng</span>
//                                            <span onclick=""javascript:raovatfn.filterfn(2,1,1,'','','','');"">tin super</span>
//                                            <span onclick=""javascript:raovatfn.filterfn(1,2,1,'','','','');"">tin vip</span>
//                                            <span onclick=""javascript:raovatfn.filterfn(1,1,2,'','','','');"">tin nổi bật</span>
//                                        </span>
//                                    </span>
//                                </span>
//                            </a>
//                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterDMraovat""/>
//                            
//                            </span>
//                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterNCraovat""/>
//                            </span>
//                            <span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
//                                <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
//                                <input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterTINHraovat""/>
//                            </span>
//                        </div>
//                        <table id=""Raovatmdl-list"" class=""mdl-list""></table>
//                        <div id=""Raovatmdl-Page""></div>
//                        ");
//                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
//                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.raoVatMgr.JScript1.js")
//                        , "{raovatfn.loadgrid();}");
//                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
//                    break;
//                    #endregion
//            }
//            writer.Write(sb.ToString());
//            base.Render(writer);
//        } 
//    }
//}
