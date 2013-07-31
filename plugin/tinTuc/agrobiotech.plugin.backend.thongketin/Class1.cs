using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using linh;
using linh.frm;
using linh.json;
using docsoft;
using docsoft.entities;
using linh.controls;
using linh.common;
using Microsoft.Reporting.WebForms;
[assembly: WebResource("agrobiotech.plugin.backend.thongketin.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("agrobiotech.plugin.backend.thongketin.htm.htm", "text/html", PerformSubstitution = true)]
namespace agrobiotech.plugin.backend.thongketin
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            #region biến
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _PID = Request["DMID"];
            string _PTen = Request["DMTen"];
            string _Ten = Request["Ten"];
            string _Mota = Request["Mota"];
            string _NoiDung = Request["NoiDung"];
            string _ThuTu = Request["ThuTu"];
            string _Anh = Request["Anh"];
            string _Hot = Request["Hot"];
            string _q = Request["q"];
            string _HetHan = Request["HetHan"];
            string _NgayHetHan = Request["NgayHetHan"];
            string _Status = Request["Status"];
            List<jgridRow> ListRow;
            string _NguoiTao = Request["Username"];
            string _tungay = Request["TuNgay"];
            string _denngay = Request["DenNgay"];
            int _acp = 1;
            #endregion
            if (!Security.IsAuthenticated())
            {
                Response.End();
            }
            switch (subAct)
            {
                case "get":
                    #region lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    
                    Pager<Tin> pager = TinDal.pagerNormalThongke("", false, jgrsidx + " " + jgrsord, _q, _PID, _NguoiTao,_tungay,_denngay ,_acp, "");

                    ListRow = new List<jgridRow>();
                    foreach (Tin item in pager.List)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString(), new string[] { 
                            item.ID.ToString()
                              ,item.NgayCapNhat.ToString("dd/MM/yyyy")
                            ,string.Format("<img src=\"../up/i/{0}\"/>",item.Anh)
                            ,item.Ten
                            ,item.MoTa
                            ,item.DM_ID.ToString()
                            ,item.DM_Ten
                            ,item.Views.ToString()
                            ,item.NguoiTao
                          
                            ,item.ThuTu.ToString()
                            ,item.Active.ToString()
                            ,item.Hot.ToString()
                            ,item.HetHan.ToString()
                        }));
                    }
                    jgrid grid = new jgrid(string.IsNullOrEmpty(jgrpage) ? "1" : jgrpage, pager.TotalPages.ToString(), pager.Total.ToString(), ListRow);
                   // jgrid grid = new jgrid("1", "1", pager.Total.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                    break;
                    #endregion
                case "reports":
                    #region bao cao
                    if (string.IsNullOrEmpty(jgRows)) jgRows = "20000";
                    jgRows = "200000";
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "TIN_NgayCapNhat";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "desc";
                    Pager<Tin> pagerGetReport = TinDal.pagerNormalThongke("", false, jgrsidx + " " + jgrsord, _q, _PID, _NguoiTao, _tungay, _denngay, _acp, "");
                    string tenBaoCao = Request["Ten"];
                    if (string.IsNullOrEmpty(tenBaoCao)) tenBaoCao = "Báo cáo";
                    RenderReport(pagerGetReport.List, Request["Loai"], tenBaoCao);
                    #endregion
                    break;
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div class=""mdl-head"">
<span class=""mdl-head-task-toolPnl"">
    <a class=""mdl-head-btn mdl-headTask-Loc"" href=""javascript:;"">
        <span class=""mdl-headTask-Loc-Title"">
            <span class=""ui-icon ui-icon-triangle-1-s""></span>        
            In báo cáo<span class=""mdl-headTask-Loc-Title-Display""></span>
        </span>
        <span class=""mdl-headTask-Loc-Box"">
            <span class=""mdl-headTask-Loc-Box-Pnl ui-widget-content ui-corner-bottom"">
                <span class=""mdl-headTask-Loc-Box-Content ui-corner-all"">
                    <span onclick=""thongketin.createReport('WORD');"">Xuất sang WORD</span>
                    <span onclick=""thongketin.createReport('EXCEL');"">Xuất sang EXCEL</span>                
                    <span onclick=""thongketin.createReport('PDF');"">Xuất sang PDF</span>
                </span>
            </span>
        </span>
    </a>
</span>
</div>
<div class=""mdl-head mdl-headTask ui-accordion-header ui-helper-reset ui-state-default ui-widget ui-corner-all"" id=""totrinhmdl-headTask"">




    <!-- hien combobox -->


<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"" style=""width:100%;"">
<input type=""text"" _value="""" class=""admtxt mdl-head-filterthanhvien""/><button class=""admfilter-btn""></button>
<input type=""text"" _value="""" class=""admtxt-medium mdl-head-tungay""/><button class=""admfilter-btn admfilter-btnDate""></button>
<input type=""text"" _value="""" class=""admtxt-medium mdl-head-denngay""/>
<button class=""admfilter-btn admfilter-btnDate""></button>

</span>
<!-- <a href=""javascript:;"" class=""mdl-head-clearSearch""></a>-->
 <span class=""mdl-head-task-searchPnl"" style=""display:none;"">

<input type=""text"" class=""admtxt-medium ui-corner-all mdl-head-search-thongketin"" /><button class=""admSearch-btn""></button> 
 <!--  hien text tim kiem -->
<input type=""text"" _value="""" class=""admtxt mdl-head-filterthongketinByCQID"" style=""display:none;""/><button class=""admfilter-btn"" style=""visibility:hidden""></button>
  </span>



</div>



<table id=""thongketinmdl-List"" class=""mdl-list"">
</table>
<div id=""thongketinmdl-Pager""></div><div id=""tongbaiviet"">" + ListFn.Count.ToString() + "</div>");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "agrobiotech.plugin.backend.thongketin.JScript1.js")
                        , "{thongketin.loadgrid();}","{thongketin.search();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        public void RenderReport(List<Tin> dt, string loai, string _ten)
        {

            LocalReport localReport = new LocalReport();

            localReport.ReportEmbeddedResource = "agrobiotech.plugin.backend.thongketin.Report1.rdlc";

            //A method that returns a collection for our report

            //Note: A report can have multiple data sources

            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            ReportParameter ten = new ReportParameter("Ten", _ten, false);
            localReport.SetParameters(ten);
            ReportDataSource reportDataSource = new ReportDataSource("dt", dt);
            localReport.DataSources.Add(reportDataSource);
            string reportType = string.IsNullOrEmpty(loai) ? "PDF" : loai;
            string mimeType;
            string encoding;
            string fileNameExtension;
            //The DeviceInfo settings should be changed based on the reportType

            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx

            string deviceInfo =

            "<DeviceInfo>" +

            "  <OutputFormat>PDF</OutputFormat>" +

            "  <PageWidth>8.5in</PageWidth>" +

            "  <PageHeight>11in</PageHeight>" +

            "  <MarginTop>0.5in</MarginTop>" +

            "  <MarginLeft>1in</MarginLeft>" +

            "  <MarginRight>1in</MarginRight>" +

            "  <MarginBottom>0.5in</MarginBottom>" +

            "</DeviceInfo>";

            Warning[] warnings;

            string[] streams;

            byte[] renderedBytes;

            //Render the report

            renderedBytes = localReport.Render(

                reportType,

                deviceInfo,

                out mimeType,

                out encoding,

                out fileNameExtension,

                out streams,

                out warnings);

            //Clear the response stream and write the bytes to the outputstream

            //Set content-disposition to "attachment" so that user is prompted to take an action

            //on the file (open or save)
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename=\"thongketin." + fileNameExtension + "\"");
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }
    }

}
