using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;
using docsoft.entities;
using System.Globalization;

namespace cnn.entities
{
    #region GianHang
    #region BO
     [Serializable()] 
    public class GianHang : BaseEntity
    {
        #region Properties
        #region GianHang
            public Int32 ID { get; set; }
            public String CQ_ID { get; set; }
            public Int32 TINH_ID { get; set; }
            public Int32 LDN_ID { get; set; }
            public Int32 LTV_ID { get; set; }
            public Int32 NhomDN_ID { get; set; }
            public Int32 MEM_ID { get; set; }
            public String TenLoaiThanhVien { get; set; }
            public String TenTinh { get; set; }
            public String Lang { get; set; }
            public Boolean LangBased { get; set; }
            public Int32 LangBasedId { get; set; }
            public String Ma { get; set; }
            public String Ten { get; set; }
            public Int32 NamThanhLap { get; set; }
            public String TomTat { get; set; }
            public String MoTa { get; set; }
            public String LienHe { get; set; }
            public String NguoiDaiDien { get; set; }
            public String ChinhSach { get; set; }
            public String Footer { get; set; }
            public String GioiThieu { get; set; }
            public String Anh { get; set; }
            public Boolean Flash { get; set; }
            public String FlashFile { get; set; }
            public Int16 FlashWidth { get; set; }
            public Int16 FlashHeight { get; set; }
            public String Slogan { get; set; }
            public String Banner { get; set; }
            public Int16 BannerType { get; set; }
            public Boolean DungGiaoDien { get; set; }
            public Int32 GD_ID { get; set; }
            public String DiaChi { get; set; }
            public String Website { get; set; }
            public String AnhWeb { get; set; }
            public Boolean webNoiBat { get; set; }
            public DateTime StartDate_WebNoiBat { get; set; }
            public DateTime EndDate_WebNoiBat { get; set; }
            public String DienThoai { get; set; }
            public String Fax { get; set; }
            public String Email { get; set; }
            public String ToaDo { get; set; }
            public Int32 Xem { get; set; }
            public Int32 BinhChon { get; set; }
            public Int32 Diem { get; set; }
            public String Hotline { get; set; }
            public String NguoiTao { get; set; }
            public DateTime NgayTao { get; set; }
            public DateTime NgayHetHan { get; set; }
            public DateTime NgayNangCap { get; set; }        
            public DateTime NgayCapNhat { get; set; }
            public Boolean KichHoat { get; set; }
            public DateTime NgayKichHoat { get; set; }
            public Boolean Active { get; set; }
            public DateTime ActiveDate { get; set; }
            public Boolean DamBao { get; set; }
            public DateTime NgayDamBao { get; set; }
            public Guid RowId { get; set; }
            public String Logo { get; set; }
        #endregion
         //list danh mục
         public List<DanhMuc> listSP { get; set; }

        //danhmuc, loai danh muc, Relation
         public String dm_Ma { get; set; }
        public Int32 dm_Id { get; set; }
        public String dm_Ten { get; set; }
        public Guid dm_RowId { get; set; }
        public String ldm_Ma { get; set; }
        public String nhom_SP { get; set; }
        public Int32 nhom_sp_id { get; set; }
        #region LienHe
            public String LH_ChucDanh { get; set; }
            public String LH_Anh { get; set; }
            public String LH_Ten { get; set; }
            public Boolean LH_GioiTinh { get; set; }
            public String LH_DiaChi { get; set; }
            public String LH_CongTy { get; set; }
            public String LH_Email { get; set; }
            public String LH_Mobile { get; set; }
            public String LH_Phone { get; set; }
            public String LH_Skype { get; set; }
            public String LH_Ym { get; set; }
            public String LH_Website { get; set; }
            public DateTime LH_NgayTao { get; set; }
            public DateTime LH_NgayCapNhat { get; set; }
            public String LH_NguoiTao { get; set; }
            public String LH_NguoiCapNhat { get; set; }
        #endregion

        #region hoangda
        public DateTime NgayDKTV_Vang { get; set; }
        public DateTime NgayKTTV_Vang { get; set; }
        public DateTime NgayDKTV_Bac { get; set; }
        public DateTime NgayKTTV_Bac { get; set; }
        public DateTime NgayDKTV_Dong { get; set; }
        public DateTime NgayKTTV_Dong { get; set; }
        public Boolean DKTV_Vang { get; set; }
        public Boolean DKTV_Bac { get; set; }
        public Boolean DKTV_Dong { get; set; }
        #endregion
        #endregion
        #region Contructor
        public GianHang()
        { }
        #endregion
        #region Customs properties

        #endregion
        
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GianHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
     [Serializable()]
    public class GianHangCollection : BaseEntityCollection<GianHang>
    { }
    #endregion
    #region Dal
    public class GianHangDal
    {
        #region Methods


        public static void UpdateDKDVTHANHVIEN(string ID, string dkvang, string dkbac, string dkdong, DateTime dkbdvang, DateTime dkktvang, DateTime dkbdbac, DateTime dkktbac, DateTime dkbddong, DateTime dkktdong)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ID", ID);
            if (!string.IsNullOrEmpty(dkvang))
            {
                obj[1] = new SqlParameter("dkvang", dkvang);
            }
            else
            {
                obj[1] = new SqlParameter("dkvang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dkbac))
            {
                obj[2] = new SqlParameter("dkbac", dkbac);
            }
            else
            {
                obj[2] = new SqlParameter("dkbac", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dkdong))
            {
                obj[3] = new SqlParameter("dkdong", dkdong);
            }
            else
            {
                obj[3] = new SqlParameter("dkdong", DBNull.Value);
            }
            if (dkbdvang != DateTime.MinValue)
            {
                obj[4] = new SqlParameter("dkbdvang", dkbdvang);
            }
            else
            {
                obj[4] = new SqlParameter("dkbdvang", DBNull.Value);
            }
            if (dkktvang != DateTime.MinValue)
            {
                obj[5] = new SqlParameter("dkktvang", dkktvang);
            }
            else
            {
                obj[5] = new SqlParameter("dkktvang", DBNull.Value);
            }
            if (dkbdbac != DateTime.MinValue)
            {
                obj[6] = new SqlParameter("dkbdbac", dkbdbac);
            }
            else
            {
                obj[6] = new SqlParameter("dkbdbac", DBNull.Value);
            }
            //
            if (dkktbac != DateTime.MinValue)
            {
                obj[7] = new SqlParameter("dkktbac", dkktbac);
            }
            else
            {
                obj[7] = new SqlParameter("dkktbac", DBNull.Value);
            }
            //
            if (dkbddong != DateTime.MinValue)
            {
                obj[8] = new SqlParameter("dkbddong", dkbddong);
            }
            else
            {
                obj[8] = new SqlParameter("dkbddong", DBNull.Value);
            }
            //
            if (dkktdong != DateTime.MinValue)
            {
                obj[9] = new SqlParameter("dkktdong", dkktdong);
            }
            else
            {
                obj[9] = new SqlParameter("dkktdong", DBNull.Value);
            }


            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThanhVien_Update_DKDVTHANHVIEN", obj);

        }


        public static void DeleteById(Int32 GH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Delete_DeleteById_hiennb", obj);
        }

        public static void DeleteByIdList(string listGH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("listGH_ID", listGH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianhang_Delete_DeleteByIdList_linhnx", obj);
        }
        public static void ThanhVienVang(string listID, string kichhoat)
        {

            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("GH_IDlist", listID);
            if (!string.IsNullOrEmpty(kichhoat))
            {
                obj[1] = new SqlParameter("KichHoat", kichhoat);
            }
            else
            {
                obj[1] = new SqlParameter("KichHoat", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_KichHoat", obj);
        }
        public static void Xacnhan(string listID, string dambao, string active) {                
     
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("GH_IDlist", listID);
            if (!string.IsNullOrEmpty(dambao))
            {
                obj[1] = new SqlParameter("Dambao", dambao);
            }
            else
            {
                obj[1] = new SqlParameter("Dambao", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[2] = new SqlParameter("Active", active);
            }
            else
            {
                obj[2] = new SqlParameter("Active", DBNull.Value);
            }     
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_Xacnhan_hiennb", obj);
        }
        public static void DungGH(string listID, string active, string activeDate)
        {

            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("GH_IDlist", listID);
            if (!string.IsNullOrEmpty(active))
            {
                obj[1] = new SqlParameter("Active", active);
            }
            else
            {
                obj[1] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(activeDate))
            {
                obj[2] = new SqlParameter("ActiveDate", activeDate);
            }
            else
            {
                obj[2] = new SqlParameter("ActiveDate", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_Active_hiennb", obj);
        }

        public static GianHangCollection SelectByListId(string listID)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ListId", listID);            
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectByListId_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static GianHangCollection SelectByGhId(string gh_id)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", gh_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static GianHang SelectByGH_ID(string gh_id)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", gh_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item=getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHang SelectByGhId_NhomSP(string gh_id)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", gh_id);
         
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhIdLDM_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHang Insert(GianHang Inserted)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[45];
            obj[0] = new SqlParameter("GH_CQ_ID", Inserted.CQ_ID);
            obj[1] = new SqlParameter("GH_TINH_ID", Inserted.TINH_ID);
            obj[2] = new SqlParameter("GH_LDN_ID", Inserted.LDN_ID);
            obj[3] = new SqlParameter("GH_LTV_ID", Inserted.LTV_ID);            
            obj[4] = new SqlParameter("GH_Lang", Inserted.Lang);
            obj[5] = new SqlParameter("GH_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("GH_LangBasedId", Inserted.LangBasedId);
            obj[7] = new SqlParameter("GH_Ma", Inserted.Ma);
            obj[8] = new SqlParameter("GH_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("GH_TomTat", Inserted.TomTat);
            obj[10] = new SqlParameter("GH_MoTa", Inserted.MoTa);
            obj[11] = new SqlParameter("GH_LienHe", Inserted.LienHe);
            obj[12] = new SqlParameter("GH_ChinhSach", Inserted.ChinhSach);
            obj[13] = new SqlParameter("GH_Footer", Inserted.Footer);
            obj[14] = new SqlParameter("GH_GioiThieu", Inserted.GioiThieu);
            obj[15] = new SqlParameter("GH_Anh", Inserted.Anh);
            obj[16] = new SqlParameter("GH_Flash", Inserted.Flash);
            obj[17] = new SqlParameter("GH_FlashFile", Inserted.FlashFile);
            obj[18] = new SqlParameter("GH_FlashWidth", Inserted.FlashWidth);
            obj[19] = new SqlParameter("GH_FlashHeight", Inserted.FlashHeight);
            obj[20] = new SqlParameter("GH_Slogan", Inserted.Slogan);
            obj[21] = new SqlParameter("GH_Banner", Inserted.Banner);
            obj[22] = new SqlParameter("GH_BannerType", Inserted.BannerType);
            obj[23] = new SqlParameter("GH_DungGiaoDien", Inserted.DungGiaoDien);
            obj[24] = new SqlParameter("GH_GD_ID", Inserted.GD_ID);
            obj[25] = new SqlParameter("GH_DiaChi", Inserted.DiaChi);
            obj[26] = new SqlParameter("GH_Website", Inserted.Website);
            obj[27] = new SqlParameter("GH_DienThoai", Inserted.DienThoai);
            obj[28] = new SqlParameter("GH_Email", Inserted.Email);
            obj[29] = new SqlParameter("GH_ToaDo", Inserted.ToaDo);
            obj[30] = new SqlParameter("GH_Xem", Inserted.Xem);
            obj[31] = new SqlParameter("GH_BinhChon", Inserted.BinhChon);
            obj[32] = new SqlParameter("GH_Diem", Inserted.Diem);
            obj[33] = new SqlParameter("GH_Hotline", Inserted.Hotline);
            obj[34] = new SqlParameter("GH_NguoiTao", Inserted.NguoiTao);
            obj[35] = new SqlParameter("GH_NgayTao", Inserted.NgayTao);
            obj[36] = new SqlParameter("GH_NgayCapNhat", Inserted.NgayCapNhat);
            obj[37] = new SqlParameter("GH_KichHoat", Inserted.KichHoat);
            obj[38] = new SqlParameter("GH_NgayKichHoat", Inserted.NgayKichHoat);
            obj[39] = new SqlParameter("GH_Active", Inserted.Active);
            obj[40] = new SqlParameter("GH_ActiveDate", Inserted.ActiveDate);
            obj[41] = new SqlParameter("GH_DamBao", Inserted.DamBao);
            obj[42] = new SqlParameter("GH_NgayDamBao", Inserted.NgayDamBao);
            obj[43] = new SqlParameter("GH_RowId", Inserted.RowId);
            obj[44] = new SqlParameter("GH_NhomDN_ID", Inserted.LTV_ID);
            obj[45] = new SqlParameter("GH_MEM_ID", Inserted.MEM_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GianHang Update(GianHang Updated)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[65];
            obj[0] = new SqlParameter("GH_ID", Updated.ID);
            obj[1] = new SqlParameter("GH_CQ_ID", Updated.CQ_ID);
            obj[2] = new SqlParameter("GH_TINH_ID", Updated.TINH_ID);
            obj[3] = new SqlParameter("GH_LDN_ID", Updated.LDN_ID);
            obj[4] = new SqlParameter("GH_LTV_ID", Updated.LTV_ID);
            obj[5] = new SqlParameter("GH_NhomDN_ID", Updated.NhomDN_ID);
            obj[6] = new SqlParameter("GH_MEM_ID", Updated.MEM_ID);
            obj[7] = new SqlParameter("GH_Lang", Updated.Lang);
            obj[8] = new SqlParameter("GH_LangBased", Updated.LangBased);
            obj[9] = new SqlParameter("GH_LangBasedId", Updated.LangBasedId);
            obj[10] = new SqlParameter("GH_Ma", Updated.Ma);
            obj[11] = new SqlParameter("GH_Ten", Updated.Ten);
            obj[12] = new SqlParameter("GH_NamThanhLap", Updated.NamThanhLap);
            obj[13] = new SqlParameter("GH_TomTat", Updated.TomTat);
            obj[14] = new SqlParameter("GH_MoTa", Updated.MoTa);
            obj[15] = new SqlParameter("GH_LienHe", Updated.LienHe);
            obj[16] = new SqlParameter("GH_NguoiDaiDien", Updated.NguoiDaiDien);
            obj[17] = new SqlParameter("GH_ChinhSach", Updated.ChinhSach);
            obj[18] = new SqlParameter("GH_Footer", Updated.Footer);
            obj[19] = new SqlParameter("GH_GioiThieu", Updated.GioiThieu);
            obj[20] = new SqlParameter("GH_Anh", Updated.Anh);
            obj[21] = new SqlParameter("GH_Flash", Updated.Flash);
            obj[22] = new SqlParameter("GH_FlashFile", Updated.FlashFile);
            obj[23] = new SqlParameter("GH_FlashWidth", Updated.FlashWidth);
            obj[24] = new SqlParameter("GH_FlashHeight", Updated.FlashHeight);
            obj[25] = new SqlParameter("GH_Slogan", Updated.Slogan);
            obj[26] = new SqlParameter("GH_Banner", Updated.Banner);
            obj[27] = new SqlParameter("GH_BannerType", Updated.BannerType);
            obj[28] = new SqlParameter("GH_DungGiaoDien", Updated.DungGiaoDien);
            obj[29] = new SqlParameter("GH_GD_ID", Updated.GD_ID);
            obj[30] = new SqlParameter("GH_DiaChi", Updated.DiaChi);
            obj[31] = new SqlParameter("GH_Website", Updated.Website);
            obj[32] = new SqlParameter("GH_AnhWebsite", Updated.AnhWeb);
            obj[33] = new SqlParameter("GH_WebNoiBat", Updated.webNoiBat);
            if (Updated.StartDate_WebNoiBat !=DateTime.MinValue)
            {
                obj[34] = new SqlParameter("GH_StartDate_WebNoiBat", Updated.StartDate_WebNoiBat);
            }
            else
            {
                obj[34] = new SqlParameter("GH_StartDate_WebNoiBat", DBNull.Value);
            }
            if ( Updated.EndDate_WebNoiBat!=DateTime.MinValue)
            {
                obj[35] = new SqlParameter("GH_EndDate_WebNoiBat", Updated.EndDate_WebNoiBat);
            }
            else
            {
                obj[35] = new SqlParameter("GH_EndDate_WebNoiBat", DBNull.Value);
            }           
            obj[36] = new SqlParameter("GH_DienThoai", Updated.DienThoai);
            obj[37] = new SqlParameter("GH_Fax", Updated.Fax);
            obj[38] = new SqlParameter("GH_Email", Updated.Email);
            obj[39] = new SqlParameter("GH_ToaDo", Updated.ToaDo);
            obj[40] = new SqlParameter("GH_Xem", Updated.Xem);
            obj[41] = new SqlParameter("GH_BinhChon", Updated.BinhChon);
            obj[42] = new SqlParameter("GH_Diem", Updated.Diem);
            obj[43] = new SqlParameter("GH_Hotline", Updated.Hotline);
            obj[44] = new SqlParameter("GH_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayTao!=DateTime.MinValue)
            {
                obj[45] = new SqlParameter("GH_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[45] = new SqlParameter("GH_NgayTao", DBNull.Value);
            }
            if (Updated.NgayHetHan != DateTime.MinValue)
            {
                obj[46] = new SqlParameter("GH_NgayHetHan", Updated.NgayHetHan);
            }
            else
            {
                obj[46] = new SqlParameter("GH_NgayHetHan", DBNull.Value);
            }

            if (Updated.NgayNangCap != DateTime.MinValue )
            {
                obj[47] = new SqlParameter("GH_NgayNangCap", Updated.NgayNangCap);
            }
            else
            {
                obj[47] = new SqlParameter("GH_NgayNangCap", DBNull.Value);
            }
            if (Updated.NgayCapNhat != DateTime.MinValue)
            {
                obj[48] = new SqlParameter("GH_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[48] = new SqlParameter("GH_NgayCapNhat", DBNull.Value);
            }
                                   
            obj[49] = new SqlParameter("GH_KichHoat", Updated.KichHoat);
            if (Updated.NgayKichHoat != DateTime.MinValue )
            {
                obj[50] = new SqlParameter("GH_NgayKichHoat", Updated.NgayKichHoat);
            }
            else
            {
                obj[50] = new SqlParameter("GH_NgayKichHoat", DBNull.Value);
            }             
            obj[51] = new SqlParameter("GH_Active", Updated.Active);
            if (Updated.ActiveDate != DateTime.MinValue )
            {
                obj[52] = new SqlParameter("GH_ActiveDate", Updated.ActiveDate);
            }
            else
            {
                obj[52] = new SqlParameter("GH_ActiveDate", DBNull.Value);
            }            
           obj[53] = new SqlParameter("GH_DamBao", Updated.DamBao);
           if (Updated.NgayDamBao != DateTime.MinValue )
            {
                obj[54] = new SqlParameter("GH_NgayDamBao", Updated.NgayDamBao);
            }
            else
            {
                obj[54] = new SqlParameter("GH_NgayDamBao", DBNull.Value);
            }   
            
            obj[55] = new SqlParameter("GH_RowId", Updated.RowId);

            if (Updated.NgayDKTV_Vang != DateTime.MinValue )
            {
                obj[56] = new SqlParameter("GH_NgayDKTV_Vang", Updated.NgayDKTV_Vang);
            }
            else
            {
                obj[56] = new SqlParameter("GH_NgayDKTV_Vang", DBNull.Value);
            }
            if (Updated.NgayKTTV_Vang != DateTime.MinValue )
            {
                obj[57] = new SqlParameter("GH_NgayKTTV_Vang", Updated.NgayKTTV_Vang);
            }
            else
            {
                obj[57] = new SqlParameter("GH_NgayKTTV_Vang", DBNull.Value);
            }
            if (Updated.NgayDKTV_Bac != DateTime.MinValue)
            {
                obj[58] = new SqlParameter("GH_NgayDKTV_Bac", Updated.NgayDKTV_Bac);
            }
            else
            {
                obj[58] = new SqlParameter("GH_NgayDKTV_Bac", DBNull.Value);
            }
            if (Updated.NgayKTTV_Bac != DateTime.MinValue )
            {
                obj[59] = new SqlParameter("GH_NgayKTTV_Bac", Updated.NgayKTTV_Bac);
            }
            else
            {
                obj[59] = new SqlParameter("GH_NgayKTTV_Bac", DBNull.Value);
            }

            if (Updated.NgayDKTV_Dong != DateTime.MinValue )
            {
                obj[60] = new SqlParameter("GH_NgayDKTV_Dong", Updated.NgayDKTV_Dong);
            }
            else
            {
                obj[60] = new SqlParameter("GH_NgayDKTV_Dong", DBNull.Value);
            }
            if (Updated.NgayKTTV_Dong != DateTime.MinValue )
            {
                obj[61] = new SqlParameter("GH_NgayKTTV_Dong", Updated.NgayKTTV_Dong);
            }
            else
            {
                obj[61] = new SqlParameter("GH_NgayKTTV_Dong", DBNull.Value);
            }
           
                obj[62] = new SqlParameter("GH_DKTV_Vang", Updated.DKTV_Vang);
    
                obj[63] = new SqlParameter("GH_DKTV_Bac", Updated.DKTV_Bac);
       
                obj[63] = new SqlParameter("GH_DKTV_Bac", DBNull.Value);
         
         
                obj[63] = new SqlParameter("GH_DKTV_Dong", Updated.DKTV_Dong);
       
                obj[63] = new SqlParameter("GH_DKTV_Dong", DBNull.Value);
      
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GianHang Update(Int32 ltv_id, Int32 gh_id, String ngaydktvv, String ngaykttvv, String ngaydktvb, String ngaykttvb, String ngaydktvd, String ngaykttvd)
       {
           GianHang Item = new GianHang();
           SqlParameter[] obj = new SqlParameter[8];
           //obj[0] = new SqlParameter("GH_LTV_ID",ltv_id);

           //if (!string.IsNullOrEmpty(ngaydktvv))
           // {
           //     obj[1] = new SqlParameter("GH_NgayDKTV_Vang", Convert.ToDateTime(ngaydktvv, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[1] = new SqlParameter("GH_NgayDKTV_Vang", DBNull.Value);
           // }
           // if (!string.IsNullOrEmpty( ngaykttvv))
           // {
           //     obj[2] = new SqlParameter("GH_NgayKTTV_Vang", Convert.ToDateTime(ngaykttvv, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[2] = new SqlParameter("GH_NgayKTTV_Vang", DBNull.Value);
           // }
           // if (!string.IsNullOrEmpty(ngaydktvb))
           // {
           //     obj[3] = new SqlParameter("GH_NgayDKTV_Bac", Convert.ToDateTime(ngaydktvb, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[3] = new SqlParameter("GH_NgayDKTV_Bac", DBNull.Value);
           // }
           // if (!string.IsNullOrEmpty(ngaykttvb))
           // {
           //     obj[4] = new SqlParameter("GH_NgayKTTV_Bac", Convert.ToDateTime(ngaykttvb, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[4] = new SqlParameter("GH_NgayKTTV_Bac", DBNull.Value);
           // }

           // if (!string.IsNullOrEmpty(ngaydktvd))
           // {
           //     obj[5] = new SqlParameter("GH_NgayDKTV_Dong", Convert.ToDateTime(ngaydktvd, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[5] = new SqlParameter("GH_NgayDKTV_Dong", DBNull.Value);
           // }
           // if (!string.IsNullOrEmpty(ngaykttvd))
           // {
           //     obj[6] = new SqlParameter("GH_NgayKTTV_Dong", Convert.ToDateTime(ngaykttvd, new CultureInfo("vi-vn")));
           // }
           // else
           // {
           //     obj[6] = new SqlParameter("GH_NgayKTTV_Dong", DBNull.Value);
           // }

            obj[7] = new SqlParameter("GH_ID", gh_id);
           using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_LTV_hiennb", obj))
           {
               //while (rd.Read())
               //{
               //    //Item = getFromReader(rd);
               //}
           }
           return Item; 
       }

        /// <summary>
        /// Ham nay dung de copy du lieu. Duc them ngay 270711
        /// </summary>
        /// <param name="Updated"></param>
        /// <param name="con"></param>
        /// <returns></returns>
       public static GianHang Update2(GianHang Updated,SqlConnection con)
       {
           GianHang Item = new GianHang();
           SqlParameter[] obj = new SqlParameter[60];
           obj[0] = new SqlParameter("GH_ID", Updated.ID);
           obj[1] = new SqlParameter("GH_CQ_ID", Updated.CQ_ID);
           obj[2] = new SqlParameter("GH_TINH_ID", Updated.TINH_ID);
           obj[3] = new SqlParameter("GH_LDN_ID", Updated.LDN_ID);
           obj[4] = new SqlParameter("GH_LTV_ID", Updated.LTV_ID);
           obj[5] = new SqlParameter("GH_NhomDN_ID", Updated.NhomDN_ID);
           obj[6] = new SqlParameter("GH_MEM_ID", Updated.MEM_ID);
           obj[7] = new SqlParameter("GH_Lang", Updated.Lang);
           obj[8] = new SqlParameter("GH_LangBased", Updated.LangBased);
           obj[9] = new SqlParameter("GH_LangBasedId", Updated.LangBasedId);
           obj[10] = new SqlParameter("GH_Ma", Updated.Ma);
           obj[11] = new SqlParameter("GH_Ten", Updated.Ten);
           obj[12] = new SqlParameter("GH_TomTat", Updated.TomTat);
           obj[13] = new SqlParameter("GH_MoTa", Updated.MoTa);
           obj[14] = new SqlParameter("GH_LienHe", Updated.LienHe);
           obj[15] = new SqlParameter("GH_NguoiDaiDien", Updated.NguoiDaiDien);
           obj[16] = new SqlParameter("GH_ChinhSach", Updated.ChinhSach);
           obj[17] = new SqlParameter("GH_Footer", Updated.Footer);
           obj[18] = new SqlParameter("GH_GioiThieu", Updated.GioiThieu);
           obj[19] = new SqlParameter("GH_Anh", Updated.Anh);
           obj[20] = new SqlParameter("GH_Flash", Updated.Flash);
           obj[21] = new SqlParameter("GH_FlashFile", Updated.FlashFile);
           obj[22] = new SqlParameter("GH_FlashWidth", Updated.FlashWidth);
           obj[23] = new SqlParameter("GH_FlashHeight", Updated.FlashHeight);
           obj[24] = new SqlParameter("GH_Slogan", Updated.Slogan);
           obj[25] = new SqlParameter("GH_Banner", Updated.Banner);
           obj[26] = new SqlParameter("GH_BannerType", Updated.BannerType);
           obj[27] = new SqlParameter("GH_DungGiaoDien", Updated.DungGiaoDien);
           obj[28] = new SqlParameter("GH_GD_ID", Updated.GD_ID);
           obj[29] = new SqlParameter("GH_DiaChi", Updated.DiaChi);
           obj[30] = new SqlParameter("GH_Website", Updated.Website);
           obj[31] = new SqlParameter("GH_DienThoai", Updated.DienThoai);
           obj[32] = new SqlParameter("GH_Email", Updated.Email);
           obj[33] = new SqlParameter("GH_ToaDo", Updated.ToaDo);
           obj[34] = new SqlParameter("GH_Xem", Updated.Xem);
           obj[35] = new SqlParameter("GH_BinhChon", Updated.BinhChon);
           obj[36] = new SqlParameter("GH_Diem", Updated.Diem);
           obj[37] = new SqlParameter("GH_Hotline", Updated.Hotline);
           obj[38] = new SqlParameter("GH_NguoiTao", Updated.NguoiTao);
           obj[39] = new SqlParameter("GH_NgayTao", Updated.NgayTao);
           obj[40] = new SqlParameter("GH_NgayHetHan", DBNull.Value);
           obj[41] = new SqlParameter("GH_NgayNangCap", DBNull.Value);
           obj[42] = new SqlParameter("GH_NgayCapNhat", DBNull.Value);
           obj[43] = new SqlParameter("GH_KichHoat", Updated.KichHoat);
           obj[44] = new SqlParameter("GH_NgayKichHoat", DBNull.Value);
           obj[45] = new SqlParameter("GH_Active", Updated.Active);
           obj[46] = new SqlParameter("GH_ActiveDate", Updated.ActiveDate);
           obj[47] = new SqlParameter("GH_DamBao", Updated.DamBao);
           obj[48] = new SqlParameter("GH_NgayDamBao", DBNull.Value);
           obj[49] = new SqlParameter("GH_RowId", Updated.RowId);
           obj[50] = new SqlParameter("GH_NgayDKTV_Vang", DBNull.Value);
           obj[51] = new SqlParameter("GH_NgayKTTV_Vang", DBNull.Value);
           obj[52] = new SqlParameter("GH_NgayDKTV_Bac", DBNull.Value);
           obj[53] = new SqlParameter("GH_NgayKTTV_Bac", DBNull.Value);
           obj[54] = new SqlParameter("GH_NgayDKTV_Dong", DBNull.Value);
           obj[55] = new SqlParameter("GH_NgayKTTV_Dong", DBNull.Value);
           obj[56] = new SqlParameter("GH_DKTV_Vang", Updated.DKTV_Vang);
           obj[57] = new SqlParameter("GH_DKTV_Bac", Updated.DKTV_Bac);
           obj[58] = new SqlParameter("GH_DKTV_Dong", Updated.DKTV_Dong);
           obj[59] = new SqlParameter("GH_NamThanhLap", Updated.NamThanhLap);

           using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblGianHang_Update_UpdateNormal_hiennb", obj))
           {
               while (rd.Read())
               {
                   Item = getFromReader(rd);
               }
           }
           return Item;
       }

        public static GianHang SelectById(Int32 GH_ID)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHang SelectById(SqlConnection con, string GH_ID)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectById_Hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHangCollection SelectByGh_IdAndLdm_ma(Int32 GH_ID, String ldm_ma)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            obj[1] = new SqlParameter("ldm_ma", ldm_ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhId_LdmMa_hiennb", obj))
            {
                while (rd.Read())
                {
                   List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static GianHangCollection SelectDmIdByGhId(Int32 GH_ID)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);             
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhId_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static GianHangCollection SelectDmIdByGhUser(string user)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("UserName", user);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectDmIdByGhUser_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
      
        public static GianHang SelectByUserCoQuan(string Username)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectByUserCoQuan_Hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHang SelectByUserName(string Username)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectByUser_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHang SelectByUserName(string Username,SqlTransaction tran)
        {
            GianHang Item = new GianHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Username", Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectByUser_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static GianHangCollection SelectTree(string q)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectTree_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static GianHangCollection SelectAll()
        {
            GianHangCollection List = new GianHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GianHang> pagerNormal(string url, bool rewrite, string sort, string dambao, string active, string _q, string _nhomdn_id, string _tinh_id, string _ltv_id, string _ldn_id,string _ltv_ma, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(_q))
            {
                obj[1] = new SqlParameter("q", _q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dambao))
            {
                obj[2] = new SqlParameter("dambao", dambao);
            }
            else
            {
                obj[2] = new SqlParameter("dambao", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[7] = new SqlParameter("active", active);
            }
            else
            {
                obj[7] = new SqlParameter("active", DBNull.Value);
            }
                        
            if (!string.IsNullOrEmpty(_ldn_id))
            {
                obj[3] = new SqlParameter("LDN_ID", _ldn_id);
            }
            else
            {
                obj[3] = new SqlParameter("LDN_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ltv_id))
            {
                obj[4] = new SqlParameter("LTV_ID", _ltv_id);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhomdn_id))
            {
                obj[5] = new SqlParameter("NhomDN_ID", _nhomdn_id);
            }
            else
            {
                obj[5] = new SqlParameter("NhomDN_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[6] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[6] = new SqlParameter("TINH_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_ltv_ma))
            {
                obj[8] = new SqlParameter("LTV_Ma", _ltv_ma);
            }
            else
            {
                obj[8] = new SqlParameter("LTV_Ma", DBNull.Value);
            }
            Pager<GianHang> pg = new Pager<GianHang>("sp_tblGianHang_Pager_Normal_hiennb", "page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<GianHang> pagerNormal( SqlConnection con, string url, bool rewrite, string sort, string dambao, string active, string _q, string _nhomdn_id, string _tinh_id, string _ltv_id, string _ldn_id, string _ltv_ma, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(_q))
            {
                obj[1] = new SqlParameter("q", _q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[7] = new SqlParameter("active", active);
            }
            else
            {
                obj[7] = new SqlParameter("active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dambao))
            {
                obj[2] = new SqlParameter("dambao", dambao);
            }
            else
            {
                obj[2] = new SqlParameter("dambao", DBNull.Value);
            }          
            if (!string.IsNullOrEmpty(_ldn_id))
            {
                obj[3] = new SqlParameter("LDN_ID", _ldn_id);
            }
            else
            {
                obj[3] = new SqlParameter("LDN_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ltv_id))
            {
                obj[4] = new SqlParameter("LTV_ID", _ltv_id);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhomdn_id))
            {
                obj[5] = new SqlParameter("NhomDN_ID", _nhomdn_id);
            }
            else
            {
                obj[5] = new SqlParameter("NhomDN_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[6] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[6] = new SqlParameter("TINH_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[8] = new SqlParameter("LTV_Ma", _ltv_ma);
            }
            else
            {
                obj[8] = new SqlParameter("LTV_Ma", DBNull.Value);
            }
            Pager<GianHang> pg = new Pager<GianHang>(con, "sp_tblGianHang_Pager_Normal_hiennb", "pages", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static GianHangCollection GetGianHang(SqlConnection con, string url, bool rewrite, string sort, string dambao, string active, string _q, string _nhomdn_id, string _tinh_id,string _ltv_ma, string _ldn_id, string pagesize)
        {
            GianHangCollection List = new GianHangCollection();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", _q);
            obj[2] = new SqlParameter("dambao", dambao);
            obj[9] = new SqlParameter("active", active);
            if (!string.IsNullOrEmpty(_ldn_id))
            {
                obj[3] = new SqlParameter("LDN_ID", _ldn_id);
            }
            else
            {
                obj[3] = new SqlParameter("LDN_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ltv_ma))
            {
                obj[4] = new SqlParameter("LTV_Ma", _ltv_ma);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_Ma", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhomdn_id))
            {
                obj[5] = new SqlParameter("NhomDN_ID", _nhomdn_id);
            }
            else
            {
                obj[5] = new SqlParameter("NhomDN_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[6] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[6] = new SqlParameter("TINH_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                obj[7] = new SqlParameter("Pagesize", pagesize);
            }
            else
            {
                obj[7] = new SqlParameter("PageSize", DBNull.Value);
            }


            obj[8] = new SqlParameter("PageIndex", 1);


            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_LTV_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GianHang> pagerNormalView(SqlConnection con, string url, bool rewrite, string sort, string dambao, string active, string _q, string _tinh_id, string _ltv_id,string _nhom_sp,string ActiveWeb, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(_q))
            {
                obj[1] = new SqlParameter("q", _q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dambao))
            {
                obj[2] = new SqlParameter("dambao", dambao);
            }
            else
            {
                obj[2] = new SqlParameter("dambao", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[3] = new SqlParameter("active", active);
            }
            else
            {
                obj[3] = new SqlParameter("active", DBNull.Value);
            }       
            if (!string.IsNullOrEmpty(_ltv_id))
            {
                obj[4] = new SqlParameter("LTV_ID", _ltv_id);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_ID", DBNull.Value);
            }


            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[5] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[5] = new SqlParameter("TINH_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ActiveWeb))
            {
                obj[6] = new SqlParameter("ActiveWeb", ActiveWeb);
            }
            else
            {
                obj[6] = new SqlParameter("ActiveWeb", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhom_sp))
            {
                obj[7] = new SqlParameter("SP_NHOM", _nhom_sp);
            }
            else
            {
                obj[7] = new SqlParameter("SP_NHOM", DBNull.Value);
            }            
            Pager<GianHang> pg = new Pager<GianHang>(con, "sp_tblGianHang_Pager_Normal_Website_hiennb", "pages", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<GianHang> pagerNormalView(string url, bool rewrite, string sort, string dambao, string active, string _q, string _tinh_id, string _ltv_id, string _nhom_sp, string ActiveWeb, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(_q))
            {
                obj[1] = new SqlParameter("q", _q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dambao))
            {
                obj[2] = new SqlParameter("dambao", dambao);
            }
            else
            {
                obj[2] = new SqlParameter("dambao", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[3] = new SqlParameter("active", active);
            }
            else
            {
                obj[3] = new SqlParameter("active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ltv_id))
            {
                obj[4] = new SqlParameter("LTV_ID", _ltv_id);
            }
            else
            {
                obj[4] = new SqlParameter("LTV_ID", DBNull.Value);
            }


            if (!string.IsNullOrEmpty(_tinh_id))
            {
                obj[5] = new SqlParameter("TINH_ID", _tinh_id);
            }
            else
            {
                obj[5] = new SqlParameter("TINH_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(ActiveWeb))
            {
                obj[6] = new SqlParameter("ActiveWeb", ActiveWeb);
            }
            else
            {
                obj[6] = new SqlParameter("ActiveWeb", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_nhom_sp))
            {
                obj[7] = new SqlParameter("SP_NHOM", _nhom_sp);
            }
            else
            {
                obj[7] = new SqlParameter("SP_NHOM", DBNull.Value);
            }
            Pager<GianHang> pg = new Pager<GianHang>("sp_tblGianHang_Pager_Normal_Website_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        public static void ActiveWebNoiBat(string listID, string active)
        {

            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("IDlist", listID);
            if (!string.IsNullOrEmpty(active))
            {
                obj[1] = new SqlParameter("Active", active);
            }
            else
            {
                obj[1] = new SqlParameter("Active", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_Update_ActiveWeb_hiennb", obj);
        }
        #endregion

        #region Utilities
        public static GianHang getFromReader(IDataReader rd)
        {
            GianHang Item = new GianHang();

            if (rd.FieldExists("GH_ID"))
            {
                Item.ID = (Int32)(rd["GH_ID"]);
            }
            if (rd.FieldExists("GH_CQ_ID"))
            {
                Item.CQ_ID = (String)(rd["GH_CQ_ID"]);
            }
            if (rd.FieldExists("LoaiThanhVien_Ten"))
            {
                Item.TenLoaiThanhVien = (String)(rd["LoaiThanhVien_Ten"]);
            }
            if (rd.FieldExists("Tinh_Ten"))
            {
                Item.TenTinh = (String)(rd["Tinh_Ten"]);
            }
            if (rd.FieldExists("GH_TINH_ID"))
            {
                Item.TINH_ID = (Int32)(rd["GH_TINH_ID"]);
            }
            if (rd.FieldExists("GH_LDN_ID"))
            {
                Item.LDN_ID = (Int32)(rd["GH_LDN_ID"]);
            }
            if (rd.FieldExists("GH_LTV_ID"))
            {
                Item.LTV_ID = (Int32)(rd["GH_LTV_ID"]);
            }
            if (rd.FieldExists("GH_NhomDN_ID"))
            {
                Item.NhomDN_ID = (Int32)(rd["GH_NhomDN_ID"]);
            }
            if (rd.FieldExists("GH_MEM_ID"))
            {
                Item.MEM_ID = (Int32)(rd["GH_MEM_ID"]);
            }
            if (rd.FieldExists("GH_Lang"))
            {
                Item.Lang = (String)(rd["GH_Lang"]);
            }
            if (rd.FieldExists("GH_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["GH_LangBased"]);
            }
            if (rd.FieldExists("GH_LangBasedId"))
            {
                Item.LangBasedId = (Int32)(rd["GH_LangBasedId"]);
            }
            if (rd.FieldExists("GH_Ma"))
            {
                Item.Ma = (String)(rd["GH_Ma"]);
            }
            if (rd.FieldExists("GH_NamThanhLap"))
            {
                Item.NamThanhLap = (Int32)(rd["GH_NamThanhLap"]);
            }
            if (rd.FieldExists("GH_Ten"))
            {
                Item.Ten = (String)(rd["GH_Ten"]);
            }
            if (rd.FieldExists("GH_TomTat"))
            {
                Item.TomTat = (String)(rd["GH_TomTat"]);
            }
            if (rd.FieldExists("GH_MoTa"))
            {
                Item.MoTa = (String)(rd["GH_MoTa"]);
            }
            if (rd.FieldExists("GH_LienHe"))
            {
                Item.LienHe = (String)(rd["GH_LienHe"]);
            }
            if (rd.FieldExists("GH_NguoiDaiDien"))
            {
                Item.NguoiDaiDien = (String)(rd["GH_NguoiDaiDien"]);
            }
            if (rd.FieldExists("GH_ChinhSach"))
            {
                Item.ChinhSach = (String)(rd["GH_ChinhSach"]);
            }
            if (rd.FieldExists("GH_Footer"))
            {
                Item.Footer = (String)(rd["GH_Footer"]);
            }
            if (rd.FieldExists("GH_GioiThieu"))
            {
                Item.GioiThieu = (String)(rd["GH_GioiThieu"]);
            }
            if (rd.FieldExists("GH_Anh"))
            {
                Item.Anh = (String)(rd["GH_Anh"]);
            }
            if (rd.FieldExists("GH_Flash"))
            {
                Item.Flash = (Boolean)(rd["GH_Flash"]);
            }
            if (rd.FieldExists("GH_FlashFile"))
            {
                Item.FlashFile = (String)(rd["GH_FlashFile"]);
            }
            if (rd.FieldExists("GH_FlashWidth"))
            {
                Item.FlashWidth = (Int16)(rd["GH_FlashWidth"]);
            }
            if (rd.FieldExists("GH_FlashHeight"))
            {
                Item.FlashHeight = (Int16)(rd["GH_FlashHeight"]);
            }
            if (rd.FieldExists("GH_Slogan"))
            {
                Item.Slogan = (String)(rd["GH_Slogan"]);
            }
            if (rd.FieldExists("GH_Banner"))
            {
                Item.Banner = (String)(rd["GH_Banner"]);
            }
            if (rd.FieldExists("GH_BannerType"))
            {
                Item.BannerType = (Int16)(rd["GH_BannerType"]);
            }
            if (rd.FieldExists("GH_DungGiaoDien"))
            {
                Item.DungGiaoDien = (Boolean)(rd["GH_DungGiaoDien"]);
            }
            if (rd.FieldExists("GH_GD_ID"))
            {
                Item.GD_ID = (Int32)(rd["GH_GD_ID"]);
            }
            if (rd.FieldExists("GH_DiaChi"))
            {
                Item.DiaChi = (String)(rd["GH_DiaChi"]);
            }
            if (rd.FieldExists("GH_Website"))
            {
                Item.Website = (String)(rd["GH_Website"]);
            }
            if (rd.FieldExists("GH_StartDate_WebNoiBat"))
            {
                Item.StartDate_WebNoiBat = (DateTime)(rd["GH_StartDate_WebNoiBat"]);
            }
            if (rd.FieldExists("GH_EndDate_WebNoiBat"))
            {
                Item.EndDate_WebNoiBat = (DateTime)(rd["GH_EndDate_WebNoiBat"]);
            }
            if (rd.FieldExists("GH_AnhWebsite"))
            {
                Item.AnhWeb = (String)(rd["GH_AnhWebsite"]);
            }
            if (rd.FieldExists("GH_WebNoiBat"))
            {
                Item.webNoiBat = (Boolean)(rd["GH_WebNoiBat"]);
            }

            if (rd.FieldExists("GH_DienThoai"))
            {
                Item.DienThoai = (String)(rd["GH_DienThoai"]);
            }
            if (rd.FieldExists("GH_Fax"))
            {
                Item.Fax = (String)(rd["GH_Fax"]);
            }
            if (rd.FieldExists("GH_Email"))
            {
                Item.Email = (String)(rd["GH_Email"]);
            }
            if (rd.FieldExists("GH_ToaDo"))
            {
                Item.ToaDo = (String)(rd["GH_ToaDo"]);
            }
            if (rd.FieldExists("GH_Xem"))
            {
                Item.Xem = (Int32)(rd["GH_Xem"]);
            }
            if (rd.FieldExists("GH_BinhChon"))
            {
                Item.BinhChon = (Int32)(rd["GH_BinhChon"]);
            }
            if (rd.FieldExists("GH_Diem"))
            {
                Item.Diem = (Int32)(rd["GH_Diem"]);
            }
            if (rd.FieldExists("GH_Hotline"))
            {
                Item.Hotline = (String)(rd["GH_Hotline"]);
            }
            if (rd.FieldExists("GH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["GH_NguoiTao"]);
            }
            if (rd.FieldExists("GH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GH_NgayTao"]);
            }
            if (rd.FieldExists("GH_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["GH_NgayHetHan"]);
            }
            if (rd.FieldExists("GH_NgayNangCap"))
            {
                Item.NgayNangCap = (DateTime)(rd["GH_NgayNangCap"]);
            }      
            if (rd.FieldExists("GH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GH_NgayCapNhat"]);
            }
            if (rd.FieldExists("GH_KichHoat"))
            {
                Item.KichHoat = (Boolean)(rd["GH_KichHoat"]);
            }
            if (rd.FieldExists("GH_NgayKichHoat"))
            {
                Item.NgayKichHoat = (DateTime)(rd["GH_NgayKichHoat"]);
            }
            if (rd.FieldExists("GH_Active"))
            {
                Item.Active = (Boolean)(rd["GH_Active"]);
            }
            if (rd.FieldExists("GH_ActiveDate"))
            {
                Item.ActiveDate = (DateTime)(rd["GH_ActiveDate"]);
            }
            if (rd.FieldExists("GH_DamBao"))
            {
                Item.DamBao = (Boolean)(rd["GH_DamBao"]);
            }
            if (rd.FieldExists("GH_NgayDamBao"))
            {
                Item.NgayDamBao = (DateTime)(rd["GH_NgayDamBao"]);
            }
            if (rd.FieldExists("GH_RowId"))
            {
                Item.RowId = (Guid)(rd["GH_RowId"]);
            }
            if (rd.FieldExists("DM_ID"))
            {
                Item.dm_Id = (Int32)(rd["DM_ID"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.dm_Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                Item.dm_Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                Item.dm_RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("LDM_Ma"))
            {
                Item.ldm_Ma = (String)(rd["LDM_Ma"]);
            }

            if (rd.FieldExists("SP_NHOM"))
            {
                Item.nhom_SP = (String)(rd["SP_NHOM"]);
            }
            if (rd.FieldExists("SP_NHOM_ID"))
            {
                Item.nhom_sp_id = (Int32)(rd["SP_NHOM_ID"]);
            } 
 
            if (rd.FieldExists("GH_DKTV_Vang"))
            {
                Item.DKTV_Vang = (Boolean)(rd["GH_DKTV_Vang"]);
            }
            if (rd.FieldExists("GH_DKTV_Bac"))
            {
                Item.DKTV_Bac = (Boolean)(rd["GH_DKTV_Bac"]);
            }
            if (rd.FieldExists("GH_DKTV_Dong"))
            {
                Item.DKTV_Dong = (Boolean)(rd["GH_DKTV_Dong"]);
            }

            if (rd.FieldExists("GH_NgayDKTV_Vang"))
            {
                Item.NgayDKTV_Vang = (DateTime)(rd["GH_NgayDKTV_Vang"]);
            }
            if (rd.FieldExists("GH_NgayKTTV_Vang"))
            {
                Item.NgayKTTV_Vang = (DateTime)(rd["GH_NgayKTTV_Vang"]);
            }
            if (rd.FieldExists("GH_NgayDKTV_Bac"))
            {
                Item.NgayDKTV_Bac = (DateTime)(rd["GH_NgayDKTV_Bac"]);
            }
            if (rd.FieldExists("GH_NgayKTTV_Bac"))
            {
                Item.NgayKTTV_Bac = (DateTime)(rd["GH_NgayKTTV_Bac"]);
            }
            if (rd.FieldExists("GH_NgayDKTV_Dong"))
            {
                Item.NgayDKTV_Dong = (DateTime)(rd["GH_NgayDKTV_Dong"]);
            }
            if (rd.FieldExists("GH_NgayKTTV_Dong"))
            {
                Item.NgayKTTV_Dong = (DateTime)(rd["GH_NgayKTTV_Dong"]);
            }

            //lien He
            if (rd.FieldExists("LH_Ten"))
            {
                Item.LH_Ten = (String)(rd["LH_Ten"]);
            }
            if (rd.FieldExists("LH_ChucDanh"))
            {
                Item.LH_ChucDanh = (String)(rd["LH_ChucDanh"]);
            }
            if (rd.FieldExists("LH_Anh"))
            {
                Item.LH_Anh = (String)(rd["LH_Anh"]);
            }
            if (rd.FieldExists("LH_GioiTinh"))
            {
                Item.LH_GioiTinh = (Boolean)(rd["LH_GioiTinh"]);
            }
            if (rd.FieldExists("LH_DiaChi"))
            {
                Item.LH_DiaChi = (String)(rd["LH_DiaChi"]);
            }
            if (rd.FieldExists("LH_CongTy"))
            {
                Item.LH_CongTy = (String)(rd["LH_CongTy"]);
            }
            if (rd.FieldExists("LH_Email"))
            {
                Item.LH_Email = (String)(rd["LH_Email"]);
            }
            if (rd.FieldExists("LH_Mobile"))
            {
                Item.LH_Mobile = (String)(rd["LH_Mobile"]);
            }
            if (rd.FieldExists("LH_Phone"))
            {
                Item.LH_Phone = (String)(rd["LH_Phone"]);
            }
            if (rd.FieldExists("LH_Skype"))
            {
                Item.LH_Skype = (String)(rd["LH_Skype"]);
            }
            if (rd.FieldExists("LH_Ym"))
            {
                Item.LH_Ym = (String)(rd["LH_Ym"]);
            }
            if (rd.FieldExists("LH_Website"))
            {
                Item.LH_Website = (String)(rd["LH_Website"]);
            }
            if (rd.FieldExists("LH_NgayTao"))
            {
                Item.LH_NgayTao = (DateTime)(rd["LH_NgayTao"]);
            }
            if (rd.FieldExists("LH_NgayCapNhat"))
            {
                Item.LH_NgayCapNhat = (DateTime)(rd["LH_NgayCapNhat"]);
            }
            if (rd.FieldExists("LH_NguoiTao"))
            {
                Item.LH_NguoiTao = (String)(rd["LH_NguoiTao"]);
            }
            if (rd.FieldExists("LH_NguoiCapNhat"))
            {
                Item.LH_NguoiCapNhat = (String)(rd["LH_NguoiCapNhat"]);
            }

            return Item;
        }
        #endregion

        #region Extend
   
        #endregion
    }
    #endregion

    #endregion
}
