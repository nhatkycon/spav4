﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.common;
using linh.core.dal;
using spa.entitites;

public partial class lib_pages_DichVu_DanhMuc_KV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var DM_ID = Request["DM_ID"];
        var KV_ID = Request["KV_ID"];
        var DM_Alias = Request["DM_Alias"];

        using (SqlConnection con = DAL.con())
        {
            DichVu_DanhMuc_KhuVuc1.Visible = !string.IsNullOrEmpty(DM_ID);
            DichVu_DanhMuc_KhuVuc1.Item = DanhMucDal.SelectById(Convert.ToInt32(DM_ID), con);
            var pagerHoiDaps = SpaHoiDapDal.pagerByDichVu(null, null, DM_ID, 5);
            DichVu_DanhMuc_KhuVuc1.HoiDaps = pagerHoiDaps.List;
            var pagerDichVu = SpaDichVuDal.pagerByDichVuKhuVuc(con, null, null, DM_ID, null, KV_ID, 40, "/Dich-vu-Spa/" + DM_Alias + "/" + DM_ID + "/" + KV_ID + "/{0}.htm");
            DichVu_DanhMuc_KhuVuc1.Pagers = pagerDichVu;
            DichVu_DanhMuc_KhuVuc1.KhuVucs = getTree(DanhMucDal.SearchByLDM(con, "QUAN", "", "Vi-vn"));
            DichVu_DanhMuc_KhuVuc1.DichVuCons = DanhMucDal.SelectTreeChildByDmId(DM_ID);
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