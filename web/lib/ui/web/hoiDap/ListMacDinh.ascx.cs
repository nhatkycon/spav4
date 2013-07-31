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
using linh.controls;
using linh.core;
using linh.core.dal;
using spa.entitites;

public partial class lib_ui_web_hoiDap_ListMacDinh : BasedUi
{
    public List<DanhMuc> List { get; set; }
    public Pager<SpaHoiDap> Pagers { get; set; }
    public DanhMuc Item { get; set; }
    public List<QuangCao> QuangCaos { get; set; }
    public string strDmHangHoa;
    int i = 0;
    int j = 0;
    public string txtPath;
    public string DM_ID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        DM_ID = Request["DM_ID"];
        var sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {
            sb.AppendFormat(@"<ul class=""tin-view-navi-menus spa-view-navi-menus"">");
            sb.AppendFormat(@"<li>
            <a href=""/"" class=""tin-view-navi-menus-item home"">
            Trang chủ
            </a>
        </li>", domain);
            sb.Append(
                @"<li><a class=""tin-view-navi-menus-item"" href=""/Hoi-dap-Spa/"">Hỏi đáp Spa</a></li>");
            var listDm = DanhMucDal.SelectTreeParentByDmId(con, DM_ID);
            foreach (var itemDm in listDm)
            {
                sb.AppendFormat(@"<li><a class=""tin-view-navi-menus-item"" href=""/Hoi-dap-Spa/{0}/{1}/"">{2}</a></li>"
                       , itemDm.Alias, itemDm.ID, itemDm.Ten);
            }
            sb.AppendFormat(@"</ul>");

            List = getTree(DanhMucDal.SelectLangBased(con, "", "DVU"));
            strDmHangHoa = getParent(List);

            if(!string.IsNullOrEmpty(DM_ID))
            {
                this.Page.Header.Title = string.Format(Item.Ten + " - Hỏi đáp Spa   Tạp chí spa");

                var meta = new HtmlMeta();
                meta.Name = "description";
                meta.Content = Item.GiaTri;
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "keywords";
                meta.Content = Item.KeyWords;
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "og:description";
                meta.Content = Item.GiaTri;
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "og:title";
                meta.Content = string.Format(Item.Ten + " - Hỏi đáp Spa  Tạp chí spa");
                this.Page.Header.Controls.Add(meta);
            }
            else
            {
                this.Page.Header.Title = string.Format("Hỏi đáp Spa   Tạp chí spa");

                var meta = new HtmlMeta();
                meta.Name = "description";
                meta.Content = "Hoi dap spa, hoi dap lam dep, hoi dap ve phau thuat tham my, hoi dap ve trang da, hoi dap ve chua sam da";
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "keywords";
                meta.Content = "Hoi dap spa, hoi dap lam dep, hoi dap ve phau thuat tham my, hoi dap ve trang da, hoi dap ve chua sam da";
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "og:description";
                meta.Content = "Hoi dap spa, hoi dap lam dep, hoi dap ve phau thuat tham my, hoi dap ve trang da, hoi dap ve chua sam da";
                this.Page.Header.Controls.Add(meta);

                meta = new HtmlMeta();
                meta.Name = "og:title";
                meta.Content = string.Format("Hỏi đáp Spa  Tạp chí spa");
                this.Page.Header.Controls.Add(meta);
            }
        }
        txtPath = sb.ToString();

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
                    , domain, "Hoi-dap-Spa", item.Alias, item.ID, item.Ten);
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
                    , domain, "Hoi-dap-Spa", item.Alias, item.ID, item.Ten);
                sb.Append(getChild(_List, item));
                sb.Append("</li>");
            }
        }
        return sb.ToString();
    }
}