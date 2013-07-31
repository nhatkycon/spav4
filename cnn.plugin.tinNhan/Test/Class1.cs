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
[assembly: WebResource("cnn.plugin.tinNhan.Test.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("cnn.plugin.tinNhan.Test.htm.htm", "text/html", PerformSubstitution = true)]
namespace cnn.plugin.tinNhan.Test
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

                case "test":
                    #region đếm số task của từng thành viên
                        sb.Append("1");
                    break;
                    #endregion
                case "scpt":
                    #region Nạp js
                    sb.AppendFormat(@"{0}"
                        , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.Test.JScript1.js"));
                    break;
                    #endregion
                default:
                    #region Nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"
<div id=""tinNhanTestMdl-dlgNew"">
    <table>
        <tr>
            <td>
                Danh mục sản phẩm
            </td>
            <td>
                <div>
                    <div class=""DanhMucBox"">
                        <div>
                            <div class=""danhMucSelection-List"">
                            </div>
                            <button class=""admfilter-btn danhMucSelection-Btn"">
                            </button>
                        </div>
                    </div>
                    <div class=""DanhMucBox_show"">
                        <div id=""productCategoryListContainer"">
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        </table>
</div>

                   
                    ");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                    , cs.GetWebResourceUrl(typeof(Class1), "cnn.plugin.tinNhan.Test.JScript1.js")
                    , "{tinnhanTestObj.setup();}");
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));
                    break;
                    #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        //List<DanhMuc> getTree(List<DanhMuc> inputList)
        //{
        //    List<DanhMuc> list = new List<DanhMuc>();
        //    foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
        //    {
        //        item.Entity.Level = item.Depth;
        //        list.Add(item.Entity);
        //        buildChild(item, list);
        //    }
        //    return list;
        //}
        //List<HierarchyNode<DanhMuc>> buildTree(List<DanhMuc> listInput)
        //{
        //    var tree = listInput.OrderByDescending(e => e.ID).ToList().AsHierarchy(e => e.ID, e => e.PID);
        //    List<HierarchyNode<DanhMuc>> _list = new List<HierarchyNode<DanhMuc>>();
        //    foreach (HierarchyNode<DanhMuc> item in tree)
        //    {
        //        _list.Add(item);
        //    }
        //    return _list;
        //}
        //void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
        //{
        //    foreach (HierarchyNode<DanhMuc> _item in item.ChildNodes)
        //    {
        //        _item.Entity.Level = _item.Depth;
        //        list.Add(_item.Entity);
        //        buildChild(_item, list);
        //    }
        //}
    }
}
