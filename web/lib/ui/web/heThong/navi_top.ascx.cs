using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using linh.core;
using linh.controls;
using System.Text;
using linh.common;
using docsoft.entities;
using cnn.entities;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
public partial class lib_ui_web_heThong_navi_top : BasedUi
{
    public string txt;
    public string logo;
    public string ten;
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        using (SqlConnection con = DAL.con())
        {
            List<DanhMuc> ListDm = getTree(DanhMucDal.SelectLangBased(con,"", "MENU"));

            var List1 = from p in ListDm
                        where p.Level == 1
                        orderby p.ThuTu ascending
                        select p;
            int i = 0;
            int max = List1.ToList().Count;
            foreach (DanhMuc item in List1)
            {
                sb.AppendFormat(@"<li class=""menu-li""><a class=""navi-top-item"" href=""{0}"">{1}</a>"
                    , string.Format(item.GiaTri,domain), item.Ten);
                sb.Append(getSub(ListDm, item.ID));
                sb.Append("</li>");
                i++;
                if (i < max) {
                    sb.Append(@"<li class=""menu-li menu-li-space""></li>");
                }

            }

            DanhMuc ItemDm = DanhMucDal.SelectByMa("HETHONG-LOGO", con);
            if (ItemDm.ID != 0)
            {
                logo = string.Format("{0}", String.IsNullOrEmpty(ItemDm.Description) ? string.Format(@"<a href="""" class=""logo""></a>", domain) : ItemDm.Description);
            }
            if (Security.IsAuthenticated())
            {
                ten = MemberDal.SelectByUser(con, Security.Username).Ten;
            }
        }
        sb.Append(onlineMember());
        
        txt = sb.ToString();
    }

    public string onlineMember()
    {
        var total = 0;
        var ran = new Random();
        if (Application["count"]!= null)
        {
            total = Convert.ToInt32(Application["count"]);
            total = total + (ran.Next(-20, 20));
        }
        return string.Format(@"<li class=""menu-li menu-li-space""></li><li class=""menu-li""><a class=""navi-top-item"" href=""javascript:alert('{0} thành viên đang online');"">Đang online: <strong>{0}</strong></a>"
                    , Lib.TienVietNam(total));
    }

    public string getSub(List<DanhMuc> list, int pid)
    {
        StringBuilder sb = new StringBuilder();
        var List1 = from p in list
                    where p.PID==pid
                    orderby p.ThuTu ascending
                    select p;
        if (List1.ToList().Count > 0)
        {
            sb.Append(@"<div class=""menu-flyOut"">");
            foreach (DanhMuc item in List1)
            {
                sb.AppendFormat(@"<a class=""navi-top-subItem"" href=""{0}"">{1}</a>"
                    , string.Format(item.GiaTri, domain), item.Ten);
            }
            sb.Append("</div>");
        }
        return sb.ToString();
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