using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.common;
using linh.core;
using linh.core.dal;

public partial class lib_ui_web_dichVu_DichVuList : BasedUi
{
    public List<DanhMuc> List { get; set; }

    public string strDmHangHoa;
    int i = 0;
    int j = 0;
    public string txtPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
        sb.AppendFormat(@"<li>
        <a href=""{0}"" class=""tin-view-navi-menus-item home"">
        Trang chủ
        </a>
    </li>", domain);
        sb.Append(
            @"<li><a class=""tin-view-navi-menus-item"" href=""/Dich-vu-Spa/"">Dịch vụ Spa</a></li>");
        sb.AppendFormat(@"</ul>");

        using (SqlConnection con = DAL.con())
        {
            
            List = getTree(DanhMucDal.SelectLangBased(con, "", "DVU"));
            strDmHangHoa = getParent(List);
        }
        txtPath = sb.ToString();


        this.Page.Header.Title = string.Format("Dịch vụ Spa - Tạp chí spa");

        var meta = new HtmlMeta();
        meta.Name = "description";
        meta.Content = "Danh sách dịch vụ spa";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:description";
        meta.Content = "Danh sách dịch vụ spa";
        this.Page.Header.Controls.Add(meta);

        meta = new HtmlMeta();
        meta.Name = "og:title";
        meta.Content = string.Format("Dịch vụ Spa - Tạp chí spa");
        this.Page.Header.Controls.Add(meta);

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
            if (item.PID == 0)
            {
                sb.AppendFormat(@"<li class=""cate-home-li""><a href=""/{1}/{2}/{3}/"" class=""cate-item"">{4}</a>"
                    , domain, "Dich-vu-Spa", item.Alias, item.ID, item.Ten);
                sb.Append(getChild(_List, item));
                sb.Append("</li>");
                i++;
            }
        }
        sb.AppendFormat(@"<li class=""cate-home-li cate-home-li-more""><a href=""javascript:;"" class=""cate-item-more""></a></li>"
            , domain);
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
            foreach (DanhMuc item in myList)
            {
                sb.AppendFormat(@"<li class=""cate-home-li""><a href=""/{1}/{2}/{3}/"" class=""cate-item cate-item-sub"">{4}</a>"
                    , domain, "Dich-vu-Spa", item.Alias, item.ID, item.Ten);
                sb.Append(getChild(_List, item));
                sb.Append("</li>");
            }
        }
        return sb.ToString();
    }
}