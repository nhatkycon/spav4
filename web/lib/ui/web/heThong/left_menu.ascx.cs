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
using System.Globalization;
using cnn.entities;
using linh.core;
using linh.core.dal;
using System.Data.SqlClient;

public partial class lib_ui_web_heThong_left_menu : BasedUi
{
    public List<DanhMuc> List { get; set; }
    
    public string strDmHangHoa;
    int i = 0;
    int j = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = DAL.con())
        {
            List = getTree(DanhMucDal.SelectLangBased(con, "", "DVU"));
            strDmHangHoa = getParent(List);
        }
        
    }
    #region TreeProcess
    List<DanhMuc> getTree(List<DanhMuc> inputList)
    {
        List<DanhMuc> list = new List<DanhMuc>();
        var plist = from c in buildTree(inputList)
                    orderby c.Entity.ThuTu ascending
                    select c;
        foreach (HierarchyNode<DanhMuc> item in plist)
        {
            item.Entity.Level = item.Depth;
            list.Add(item.Entity);
            buildChild(item, list);
        }
        return list;
    }
    List<DanhMuc> getTreeTop(List<DanhMuc> inputList)
    {
        List<DanhMuc> list = new List<DanhMuc>();
        foreach (HierarchyNode<DanhMuc> item in buildTree(inputList))
        {
            item.Entity.Level = item.Depth;
            list.Add(item.Entity);
            break;
        }
        return list;
    }
    void buildChild(HierarchyNode<DanhMuc> item, List<DanhMuc> list)
    {
        var plist = from c in item.ChildNodes
                    orderby c.Entity.ThuTu ascending
                    select c;
        foreach (HierarchyNode<DanhMuc> _item in plist)
        {
            _item.Entity.Level = _item.Depth;
            list.Add(_item.Entity);
            buildChild(_item, list);
        }
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
    #endregion
    string getParent(List<DanhMuc> _List)
    {
        StringBuilder sb = new StringBuilder();
        foreach (DanhMuc item in _List)
        {
            if (item.PID == 0 && i < 8)
            {
                sb.AppendFormat(@"<li class=""cate-home-li""><a href=""/{1}/{2}/{3}/"" class=""cate-item"">{4}</a>"
                    , domain, "Dich-vu-Spa", item.Alias, item.ID, item.Ten);
                sb.Append(getChild(_List, item));
                sb.Append("</li>");
                i++;
            }
        }
        sb.AppendFormat(@"<li class=""cate-home-li cate-home-li-more""><a href=""/Dich-vu-Spa/"" class=""cate-item-more"">Xem thêm</a></li>"
            ,domain);
        return sb.ToString();
    }
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    string getChild(List<DanhMuc> _List, DanhMuc PID)
    {
        j = 0;
        sb1 = new StringBuilder();
        sb2 = new StringBuilder();
        string srv = Request["kind"];
        if (string.IsNullOrEmpty(srv)) srv = "San-pham";
        StringBuilder sb = new StringBuilder();
        var myList = from p
                     in _List
                     where p.PID == PID.ID
                     select p;        
        if (myList.Count() > 0)
        {
            sb.Append(@"<div class=""cate-flyOut"">");
            int max = 0;
            int total = myList.Count();
            if (total % 2 == 0)
            {
                max = total / 2;
            }
            else
            {
                max = Convert.ToInt32(Math.Floor(Convert.ToDecimal(myList.Count() / 2))) + 1;
            }            
            foreach (DanhMuc item in myList)
            {
                if (j < max)
                {
                    sb1.AppendFormat(@"<a href=""/Dich-vu-Spa/{1}/{2}/{3}/"" Class=""cate-flyOut-subCate-item"">{4}</a>", domain, PID.Alias, item.Alias, item.ID, item.Ten);
                }
                else
                {

                    sb2.AppendFormat(@"<a href=""/Dich-vu-Spa/{1}/{2}/{3}/"" Class=""cate-flyOut-subCate-item"">{4}</a>", domain, PID.Alias, item.Alias, item.ID, item.Ten);
                }
                j++;
            }
            if(!string.IsNullOrEmpty(sb1.ToString()))
            {
                sb.AppendFormat(@"<div class=""cate-flyOut-subCate-panel"">{0}</div>", sb1);
            }
            if (!string.IsNullOrEmpty(sb2.ToString()))
            {
                sb.AppendFormat(@"<div class=""cate-flyOut-subCate-panel"">{0}</div>", sb2);
            }
            sb.AppendFormat(@"<div class=""cate-flyOut-featured"">
                <div class=""cate-flyOut-featured-header"">
                    <div class=""cate-flyOut-featured-header-label"">
                    Dịch vụ
                    </div>
                    <div class=""cate-flyOut-featured-header-line"">
                    </div>
                </div>
                <div class=""cate-flyOut-featured-box"" _loaded=""0"" _DM_ID=""{0}"">        
                </div>
            </div>", PID.ID);
            sb.Append("</div>");
        }
        return sb.ToString();
    }
}