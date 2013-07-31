using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.common;
using spa.entitites;

public partial class lib_pages_Spa_Theo_KhuVuc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        var DM_Alias = Request["DM_Alias"];
        if(!string.IsNullOrEmpty(DM_ID))
        {
            Spa_khuVuc1.Item = DanhMucDal.SelectById(Convert.ToInt32(DM_ID));            
        }
        
        Spa_khuVuc1.KhuVucs = getTree(DanhMucDal.SearchByLDM("QUAN", "", "Vi-vn"));
        if (string.IsNullOrEmpty(DM_ID))
        {
            Spa_khuVuc1.SpaPager = SpaDal.pagerKhuVuc("/Spa/{0}/", true, "SPA_NgayTao desc", 10, DM_ID);
            Spa_khuVuc1.QuangCaos = QuangCaoDal.SelectByDanhMuc("ADV-SPA-LIST-HOME-RIGHT", 10);

        }
        else
        {
            Spa_khuVuc1.SpaPager = SpaDal.pagerKhuVuc("/Spa/" + DM_Alias + "/" + DM_ID + "/{0}/", true, "SPA_NgayTao desc", 10, DM_ID);
            Spa_khuVuc1.QuangCaos = QuangCaoDal.SelectByDanhMuc("ADV-SPA-LIST-KV-RIGHT", 10);
            
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
}