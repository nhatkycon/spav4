using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using cnn.entities;
using System.Globalization;
[assembly: WebResource("cnn.plugin.giaoThuong.TestDanhMuc.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.giaoThuong.TestDanhMuc.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.giaoThuong.TestDanhMuc
{
    public class Class1 : docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            #region Tham số
            List<DanhMuc> List = new List<DanhMuc>();
            string _ID = Request["ID"];
            string _LDM_Ma = Request["LDM_Ma"];
            #endregion
            switch (subAct)
            {
                case "autoCompleteLangBased":
                    #region Lấy danh sách danh mục
                    List = getTree(DanhMucDal.SelectLangBased("", "SP_NHOM"));
                    sb.Append(JavaScriptConvert.SerializeObject(List));
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.TestDanhMuc.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
                        <a class=""mdl-head-btn mdl-head-add"" id=""GiaoThuongTestDanhMucFnMdl-addBtn"" href=""javascript:"" onclick=""GiaoThuongTestDanhMucFn.add();"">Thêm</a>
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.giaoThuong.TestDanhMuc.JScript1.js")
                    , "{GiaoThuongTestDanhMucFn.loadgrid();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        List<DanhMuc> getTree(List<DanhMuc> inputList)
        {
            List<DanhMuc> list = new List<DanhMuc>();
            foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
            {
                item.Entity.Level = item.Depth;
                list.Add(item.Entity);
                buildChild(item, list);
            }
            return list;
        }
        List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        {
            var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
            List<HierarchyNode<DanhMuc>> _list = new List<HierarchyNode<DanhMuc>>();
            foreach (HierarchyNode<DanhMuc> item in tree)
            {
                _list.Add(item);
            }
            return _list;
        }
        void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        {
            foreach (HierarchyNode<DanhMuc> _item in item.ChildNodes)
            {
                _item.Entity.Level = _item.Depth;
                list.Add(_item.Entity);
                buildChild(_item, list);
            }
        }
    }
}
