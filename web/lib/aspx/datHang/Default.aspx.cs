using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Text;
using linh.frm;
using linh.json;
using docsoft.entities;
using cnn.entities;
using docsoft;
using System.Web.UI;
using linh.controls;
using linh.common;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.core;

public partial class lib_aspx_datHang_Default : basePage
{
    public string strMon;
    public delegate void sendEmailDele(string email, string tieude, string noidung);
    void sendmailThongbao(string email, string tieude, string noidung)
    {
        omail.Send(email, email, tieude, noidung, "giaoban.pmtl@gmail.com", "mamvui.com", "123$5678");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string act = Request["act"];
        string _ID = Request["ID"];
        string _SoLuong = Request["SoLuong"];
        string _Ten = Request["Ten"];
        string _Gia = Request["Gia"];
        string _Img = Request["Img"];
        string _Email = Request["Email"];
        string _Mobile = Request["Mobile"];
        string _DiaChi = Request["DiaChi"];
        string _GhiChu = Request["GhiChu"];
        GioHang gh = new GioHang();
        HangHoa item = new HangHoa();
        sendEmailDele _dele = new sendEmailDele(sendmailThongbao);
        StringBuilder sb = new System.Text.StringBuilder();

        switch (act)
        {
            case "add":
            #region add
                item = HangHoaDal.SelectById(Convert.ToInt32(_ID));
                gh.add(item, _SoLuong);
                break;
            #endregion
            case "save":
                #region save
                
                DatHang itemDh = new DatHang();
                itemDh.GiaoHang = false;
                itemDh.GiaTri = gh.Total;
                itemDh.KH_DiaChi = _DiaChi;
                itemDh.KH_Email = _Email;
                itemDh.KH_ID = 0;
                itemDh.KH_Mobile = _Mobile;
                itemDh.KH_Ten = _Ten;
                itemDh.NgayTao = DateTime.Now;
                itemDh.PhiVanChuyen = gh.ShipCost;
                itemDh.Readed = false;
                itemDh.Tong = gh.Total + gh.ShipCost;
                itemDh.NgayGiao = DateTime.Now;
                itemDh = DatHangDal.Insert(itemDh);
                DatHangChiTiet itemDhCt = new DatHangChiTiet();
                StringBuilder sbDh = new System.Text.StringBuilder();
                sbDh.AppendFormat(@"Khách hàng: {0}<br/>Email: {1}<br/>Mobile: {2}<br/>Địa chỉ: {3}<br/>Ghi chú: {4}<br/>Ngày đặt hàng: {5}<br/><h3>Chi tiết</h3>"
                    ,_Ten,_Email,_Mobile,_DiaChi, _GhiChu,DateTime.Now);
                foreach (GioHangItem ghItem in gh.List.Values)
                {
                    itemDhCt = new DatHangChiTiet();
                    itemDhCt.DH_ID = itemDh.ID;
                    itemDhCt.HH_Gia = ghItem.Gia;
                    itemDhCt.HH_SoLuong = ghItem.SoLuong;
                    itemDhCt.HH_Ten = ghItem.Ten;
                    itemDhCt.HH_Tong = ghItem.Gia * ghItem.SoLuong;
                    itemDhCt.NgayTao = DateTime.Now;
                    DatHangChiTietDal.Insert(itemDhCt);
                    sbDh.AppendFormat("Món:{0} - {1}<br/>Số lượng: {2}<br/>Tổng: {3}<hr/>", ghItem.Ten, ghItem.Gia, ghItem.SoLuong, ghItem.Gia * ghItem.SoLuong);
                }
                sbDh.AppendFormat(@"Tổng:{0}<br/>Phí vận chuyển: {1}<br/>Tổng cộng: {2}"
                    , gh.Total, gh.ShipCost, gh.Total + gh.ShipCost);
                _dele.BeginInvoke("danhbaspa@gmail.com"
                            , string.Format("mamvui.com - Đặt hàng mới: {0}  {1} [{2}.000đ]", _Ten, DateTime.Now.ToString("hh:mm-dd/MM/yy"),gh.Total + gh.ShipCost)
                            , sbDh.ToString()
                            , null, null);
                gh.clear();
                break;
                #endregion
            case "UpSl":
                #region UpSl
                item = HangHoaDal.SelectById(Convert.ToInt32(_ID));
                gh.updateSl(item, _SoLuong);
                break;
                #endregion
            case "del":
                #region add
                gh.remove(Convert.ToInt32(_ID));
                break;
                #endregion
            case "clear":
                #region add
                gh.clear();
                break;
                #endregion
            case "get":
            #region get
                break;
            #endregion
            default:
                break;
        }
        //sb.Append(format_gioHang(gh));
        sb.AppendFormat("({0})", JavaScriptConvert.SerializeObject(gh));
        rendertext(sb);
        
    }
    string format_item(GioHangItem item)
    {
        return string.Format(@"<div class=""cart-item"">
                                <span class=""cart-item-gia"">{0}.000đ</span>
                                <img src=""../up/sanpham/{2}"" class=""cart-item-img"" />
                                <span class=""cart-item-ten"">{1}</span><br />
                                {3}
                                <a href=""javascript:;"" class=""cart-item-xoa"">xóa</a>
                            </div>", item.Gia, item.Ten, item.Img, buildSoLuong(item.SoLuong));
    }
    string format_gioHang(GioHang item) {
        StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<div class=""cart-top"">
        </div>
        <div class=""cart-body"">");
        foreach(GioHangItem gioHangItem in item.List.Values){
            sb.Append(format_item(gioHangItem));
        }
        if (item.ShipCost > 0) {
            sb.Append(@"<div class=""cart-ship"">
                <span class=""cart-ship-gia"">5.000đ</span>
                <span class=""cart-ship-label"">Phí vận chuyển</span><br />
                <span class=""cart-ship-info"">Dưới 80k, quý khách vui lòng phụ thêm 5k vận chuyển</span>
            </div>");
        }
        sb.AppendFormat(@"<div class=""cart-tong"">
                                Tổng cộng: <span class=""cart-tong-label"">{0}.000đ</span>
                            </div>", item.Total + item.ShipCost);
        sb.Append(@"<div class=""cart-info cart-info-active"">
            <table style=""width:100%;"" cellpadding=""4"" cellspacing=""2"">
                <tr>
                    <td valign=""top"" class=""td-header"">Tên:</td>
                    <td valign=""top"">
                        <input class=""input-small Ten"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Email:</td>
                    <td valign=""top"">
                        <input class=""input-small Email"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Mobile:</td>
                    <td valign=""top"">
                        <input class=""input-small Mobile"" />
                    </td>
                </tr>
                <tr>
                    <td valign=""top"" class=""td-header"">Địa chỉ:</td>
                    <td valign=""top"">
                        <input class=""input-small DiaChi"" />
                    </td>
                </tr>
                <tr>
                    <td colspan=""2"" valign=""top"">
                        <textarea class=""textarea-tiny GhiChu"" ></textarea>
                    </td>                                                                                
                </tr>
                <tr>
                    <td colspan=""2"" valign=""top"">
                        <a href=""javascript:;"" class=""cart-send"">Gửi Đặt hàng</a>
                    </td>
                </tr>
            </table>
        </div>");
        sb.Append("</div>");

        return sb.ToString();
    }
    string buildSoLuong(int SoLuong) {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<select class=""cart-item-soLuong"">");
        for (int i = 0; i < 10; i++) {
            sb.AppendFormat(@"<option value=""{0}""{1}>{0}</option>", i, i == SoLuong ? @" selected=""selected""" : "");
        }
        if(SoLuong>10){
            sb.AppendFormat(@"<option value=""{0}"" selected=""selected"">{0}</option>", SoLuong);
        }
        sb.Append(@"</select>");
        return sb.ToString();
    }
}
public class GioHang
{
    public int Total { get; set; }
    public int ShipCost { get; set; }
    public Dictionary<int,GioHangItem> List { get; set; }
    public GioHang() {
        if (HttpContext.Current.Session["cart"] == null) {
            List = new Dictionary<int, GioHangItem>();
            HttpContext.Current.Session["cart"] = List;
        }
        var list = HttpContext.Current.Session["cart"] as Dictionary<int, GioHangItem>;
        List = list;
        calculate();
    }
    public void calculate() {
        if (List == null) {
            List = new Dictionary<int, GioHangItem>();
            HttpContext.Current.Session["cart"] = List;
        }
        var list = HttpContext.Current.Session["cart"] as Dictionary<int, GioHangItem>;
        List = list;
        Total = 0;
        ShipCost = 0;
        foreach(GioHangItem item in List.Values){
            Total += item.Gia * item.SoLuong;
        }
        if (Total < 80) 
        { 
            ShipCost = 5; 
        }
    }
    public void add(HangHoa item)
    {
        GioHangItem gioHangItem = new GioHangItem();
        if (List[item.ID] != null)
        {
            gioHangItem = List[item.ID];
            gioHangItem.SoLuong += 1;
            List.Remove(item.ID);
            List.Add(item.ID, gioHangItem);
        }
        else {
            gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), 1);
            List.Add(item.ID, gioHangItem);
        }
        calculate();
        HttpContext.Current.Session["cart"] = List;
    }
    public void add(HangHoa item, string SoLuong)
    {
        GioHangItem gioHangItem = new GioHangItem();
        if (SoLuong == null) SoLuong = "1";
        if (List.ContainsKey(item.ID))
        {
            gioHangItem = List[item.ID];
            gioHangItem.SoLuong += Convert.ToInt32(SoLuong);
            List.Remove(item.ID);
            List.Add(item.ID, gioHangItem);
        }
        else
        {
            gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(SoLuong));
            List.Add(item.ID, gioHangItem);
        }
        calculate();
        HttpContext.Current.Session["cart"] = List;
    }
    public void updateSl(HangHoa item, string SoLuong)
    {
        GioHangItem gioHangItem = new GioHangItem();
        if (SoLuong == null) SoLuong = "1";
        if (List.ContainsKey(item.ID))
        {
            gioHangItem = List[item.ID];
            gioHangItem.SoLuong = Convert.ToInt32(SoLuong);
            List.Remove(item.ID);
            List.Add(item.ID, gioHangItem);
        }
        else
        {
            gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(SoLuong));
            List.Add(item.ID, gioHangItem);
        }
        calculate();
        HttpContext.Current.Session["cart"] = List;
    }
    public void add(string id,string ten,string anh,string gia, string soluong)
    {
        HangHoa item = new HangHoa();
        item.ID = Convert.ToInt32(id);
        item.Ten = ten;
        item.Anh = anh;
        item.GNY = Convert.ToDouble(gia);        
        GioHangItem gioHangItem = new GioHangItem();
        if (List.ContainsKey(item.ID))
        {
            gioHangItem = List[item.ID];
            gioHangItem.SoLuong += 1;
            List.Remove(item.ID);
            List.Add(item.ID, gioHangItem);
        }
        else
        {
            gioHangItem = new GioHangItem(item.Ten, item.Anh, Convert.ToInt32(item.GNY), Convert.ToInt32(soluong));
            List.Add(item.ID, gioHangItem);
        }
        calculate();
        HttpContext.Current.Session["cart"] = List;
    }
    public void remove(int item)
    {
        if (List.ContainsKey(item))
        {
            List.Remove(item);
            calculate();
        }
        HttpContext.Current.Session["cart"] = List;
    }
    public void clear()
    {
        List = new Dictionary<int, GioHangItem>();
        calculate();
        HttpContext.Current.Session["cart"] = List;
    }
    
}
public class GioHangItem : BaseEntity
{
    public string Ten { get; set; }
    public string Img { get; set; }
    public int Gia { get; set; }
    public int SoLuong { get; set; }
    public GioHangItem() { }
    public GioHangItem(string ten, string img, int gia, int soLuong)
    {
        Ten = ten;
        Img = img;
        Gia = gia;
        SoLuong = soLuong;
    }

    public override BaseEntity getFromReader(System.Data.IDataReader rd)
    {
        throw new NotImplementedException();
    }
}
public class GioHangList : BaseEntityCollection<GioHangItem>
{
}