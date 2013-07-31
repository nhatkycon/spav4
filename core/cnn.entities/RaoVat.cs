using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using linh.common;
using System.Web;

namespace cnn.entities
{
    #region RaoVat
    #region BO
    public class RaoVat : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 TINH_ID { get; set; }
        public Int32 NC_ID { get; set; }
        public String Gia { get; set; }
        public Int32 LangBased_ID { get; set; }
        public Boolean LangBased { get; set; }
        public String Lang { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayHetHan { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String TenNguoiDang { get; set; }
        public String Email { get; set; }
        public String DiaChi { get; set; }
        public String DienThoai { get; set; }
        public String YM { get; set; }
        public String Skype { get; set; }
        public String Anh1 { get; set; }
        public String Anh2 { get; set; }
        public String Anh3 { get; set; }
        public String Anh4 { get; set; }
        public String Anh5 { get; set; }
        public String Anh6 { get; set; }
        public String Anh7 { get; set; }
        public String Anh8 { get; set; }
        public Int32 Xem { get; set; }
        public Boolean VIP_SUPER { get; set; }
        public DateTime VIP_SUPER_NgayHetHan { get; set; }
        public DateTime VIP_SUPER_NgayBatDau { get; set; }
        public Boolean VIP_VIP { get; set; }
        public DateTime VIP_VIP_NgayHetHan { get; set; }
        public DateTime VIP_VIP_NgayBatDau { get; set; }
        public DateTime VIP_VIP_NgayHetHan_Active { get; set; }
        public DateTime VIP_VIP_NgayBatDau_Active { get; set; }
        public Boolean VIP_NoiBat { get; set; }
        public DateTime VIP_NoiBat_NgayHetHan { get; set; }
        public DateTime VIP_NoiBat_NgayBatDau { get; set; }
        public Boolean Active { get; set; }
        public Boolean Anonymous { get; set; }
        public String AnonymousPassword { get; set; }
        public Int32 GH_ID { get; set; }
        public Boolean Publish { get; set; }
        public Boolean DangKy_SUPER { get; set; }
        public Boolean DangKy_VIP { get; set; }
        public Boolean DangKy_NoiBat { get; set; }//8147
        public Boolean ChuyenBanGiong { get; set; }//8147
        #endregion
        #region Contructor
        public RaoVat()
        { }
        #endregion
        #region Customs properties
        public docsoft.entities.Member _Member { get; set; }
        public string _DM_Ten { get; set; }
        public string _Tinh_Ten { get; set; }
        public string _Nhucau_Ten { get; set; }
        public string _DM_Ma { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return RaoVatDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class RaoVatCollection : BaseEntityCollection<RaoVat>
    { }
    #endregion
    #region Dal
    public class RaoVatDal
    {
        #region Methods
        public static void UpdateDKDV(string RV_IDList, string dksuper, string dkvip, string dkhot, DateTime dksupertime, DateTime dkviptime, DateTime dkhottime,DateTime dkbdsuper, DateTime dkbdvip, DateTime dkbdhot)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("RV_IDlist", RV_IDList);
            if (!string.IsNullOrEmpty(dksuper))
            {
                obj[1] = new SqlParameter("RV_DangKy_SUPER", dksuper);
            }
            else
            {
                obj[1] = new SqlParameter("RV_DangKy_SUPER", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dkvip))
            {
                obj[2] = new SqlParameter("RV_DangKy_VIP", dkvip);
            }
            else
            {
                obj[2] = new SqlParameter("RV_DangKy_VIP", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dkhot))
            {
                obj[3] = new SqlParameter("RV_DangKy_NoiBat", dkhot);
            }
            else
            {
                obj[3] = new SqlParameter("RV_DangKy_NoiBat", DBNull.Value);
            }
            if (dksupertime != DateTime.MinValue)
            {
                obj[4] = new SqlParameter("RV_VIP_SUPER_NgayHetHan", dksupertime);
            }
            else
            {
                obj[4] = new SqlParameter("RV_VIP_SUPER_NgayHetHan", DBNull.Value);
            }
            if (dkviptime != DateTime.MinValue)
            {
                obj[5] = new SqlParameter("RV_VIP_VIP_NgayHetHan", dkviptime);
            }
            else
            {
                obj[5] = new SqlParameter("RV_VIP_VIP_NgayHetHan", DBNull.Value);
            }
            if (dkhottime != DateTime.MinValue)
            {
                obj[6] = new SqlParameter("RV_VIP_NoiBat_NgayHetHan", dkhottime);
            }
            else
            {
                obj[6] = new SqlParameter("RV_VIP_NoiBat_NgayHetHan", DBNull.Value);
            }
            //
            if (dkbdsuper != DateTime.MinValue)
            {
                obj[7] = new SqlParameter("RV_VIP_SUPER_NgayBatDau", dkbdsuper);
            }
            else
            {
                obj[7] = new SqlParameter("RV_VIP_SUPER_NgayBatDau", DBNull.Value);
            }
            //
            if (dkbdhot != DateTime.MinValue)
            {
                obj[8] = new SqlParameter("RV_VIP_NoiBat_NgayBatDau", dkbdhot);
            }
            else
            {
                obj[8] = new SqlParameter("RV_VIP_NoiBat_NgayBatDau", DBNull.Value);
            }
            //
            if (dkbdvip != DateTime.MinValue)
            {
                obj[9] = new SqlParameter("RV_VIP_VIP_NgayBatDau", dkbdvip);
            }
            else
            {
                obj[9] = new SqlParameter("RV_VIP_VIP_NgayBatDau", DBNull.Value);
            }
            

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_DKDVTIN", obj);

        }
        public static void UpdateDuyetRVTraPhi(string RV_IDList, string vip, DateTime NgayBD, DateTime NgayKT)
        {
            
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("RV_IDList", RV_IDList);
            if (!string.IsNullOrEmpty(vip))
            {
                obj[1] = new SqlParameter("RV_VIP_VIP", vip);
            }
            else
            {
                obj[1] = new SqlParameter("RV_VIP_VIP", DBNull.Value);
            }
            if (NgayKT != DateTime.MinValue)
            {
                obj[2] = new SqlParameter("RV_VIP_VIP_NgayHetHan", NgayKT);
            }
            else
            {
                obj[2] = new SqlParameter("RV_VIP_VIP_NgayHetHan", DBNull.Value);
            }
            if (NgayBD != DateTime.MinValue)
            {
                obj[3] = new SqlParameter("RV_VIP_VIP_NgayBatDau", NgayBD);
            }
            else
            {
                obj[3] = new SqlParameter("RV_VIP_VIP_NgayBatDau", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_DuyetDichVuRVTraPhi", obj);
        }
        public static void DangTinDungTin(string IDList, string Publish)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("IDList", IDList);
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[1] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[1] = new SqlParameter("Publish", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_DangTinDungTin", obj);
        }
        public static void HuyDichVu(string IDList, string cancelall, string cancelsuper, string cancelvip, string cancelhot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("IDList", IDList);
            if (!string.IsNullOrEmpty(cancelall))
            {
                obj[1] = new SqlParameter("cancelall", cancelall);
            }
            else
            {
                obj[1] = new SqlParameter("cancelall", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(cancelsuper))
            {
                obj[1] = new SqlParameter("cancelsuper", cancelsuper);
            }
            else
            {
                obj[1] = new SqlParameter("cancelsuper", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(cancelvip))
            {
                obj[1] = new SqlParameter("cancelvip", cancelvip);
            }
            else
            {
                obj[1] = new SqlParameter("cancelvip", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(cancelhot))
            {
                obj[1] = new SqlParameter("cancelhot", cancelhot);
            }
            else
            {
                obj[1] = new SqlParameter("cancelhot", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_ActiveList", obj);
        }
        public static void DuyetList(string IDList, string Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("IDList", IDList);
            if (!string.IsNullOrEmpty(Active))
            {
                obj[1] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[1] = new SqlParameter("Active", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_ActiveList", obj);
        }
        public static void DeleteById(Int32 RV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RV_ID", RV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Delete_DeleteById_hoangda", obj);
        }
        public static void DeleteByIdList(string RV_IDList)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RV_IDlist", RV_IDList);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Delete_DeleteByListId_hoangda", obj);
        }

        public static RaoVat Insert(RaoVat Inserted)
        {
            RaoVat Item = new RaoVat();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("RV_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("RV_TINH_ID", Inserted.TINH_ID);
            obj[2] = new SqlParameter("RV_NC_ID", Inserted.NC_ID);
            obj[3] = new SqlParameter("RV_Gia", Inserted.Gia);
            obj[4] = new SqlParameter("RV_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("RV_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("RV_Lang", Inserted.Lang);
            obj[7] = new SqlParameter("RV_Alias", Inserted.Alias);
            obj[8] = new SqlParameter("RV_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("RV_MoTa", Inserted.MoTa);
            obj[10] = new SqlParameter("RV_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("RV_NgayDang", Inserted.NgayDang);
            obj[12] = new SqlParameter("RV_NgayHetHan", Inserted.NgayHetHan);
            obj[13] = new SqlParameter("RV_NgayCapNhat", Inserted.NgayCapNhat);
            obj[14] = new SqlParameter("RV_TenNguoiDang", Inserted.TenNguoiDang);
            obj[15] = new SqlParameter("RV_Email", Inserted.Email);
            obj[16] = new SqlParameter("RV_DiaChi", Inserted.DiaChi);
            obj[17] = new SqlParameter("RV_DienThoai", Inserted.DienThoai);
            obj[18] = new SqlParameter("RV_YM", Inserted.YM);
            obj[19] = new SqlParameter("RV_Skype", Inserted.Skype);
            obj[20] = new SqlParameter("RV_Anh1", Inserted.Anh1);
            obj[21] = new SqlParameter("RV_Anh2", Inserted.Anh2);
            obj[22] = new SqlParameter("RV_Anh3", Inserted.Anh3);
            obj[23] = new SqlParameter("RV_Anh4", Inserted.Anh4);
            obj[24] = new SqlParameter("RV_Anh5", Inserted.Anh5);
            obj[25] = new SqlParameter("RV_Anh6", Inserted.Anh6);
            obj[26] = new SqlParameter("RV_Anh7", Inserted.Anh7);
            obj[27] = new SqlParameter("RV_Anh8", Inserted.Anh8);
            obj[28] = new SqlParameter("RV_Xem", Inserted.Xem);
            obj[29] = new SqlParameter("RV_Active", Inserted.Active);
            obj[30] = new SqlParameter("RV_Anonymous", Inserted.Anonymous);
            obj[31] = new SqlParameter("RV_AnonymousPassword", Inserted.AnonymousPassword);
            obj[32] = new SqlParameter("RV_GH_ID", Inserted.GH_ID);
            obj[33] = new SqlParameter("RV_Publish", Inserted.Publish);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static RaoVat Insert(RaoVat Inserted,SqlConnection con)
        {
            RaoVat Item = new RaoVat();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("RV_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("RV_TINH_ID", Inserted.TINH_ID);
            obj[2] = new SqlParameter("RV_NC_ID", Inserted.NC_ID);
            obj[3] = new SqlParameter("RV_Gia", Inserted.Gia);
            obj[4] = new SqlParameter("RV_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("RV_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("RV_Lang", Inserted.Lang);
            obj[7] = new SqlParameter("RV_Alias", Inserted.Alias);
            obj[8] = new SqlParameter("RV_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("RV_MoTa", Inserted.MoTa);
            obj[10] = new SqlParameter("RV_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("RV_NgayDang", Inserted.NgayDang);
            obj[12] = new SqlParameter("RV_NgayHetHan", Inserted.NgayHetHan);
            obj[13] = new SqlParameter("RV_NgayCapNhat", Inserted.NgayCapNhat);
            obj[14] = new SqlParameter("RV_TenNguoiDang", Inserted.TenNguoiDang);
            obj[15] = new SqlParameter("RV_Email", Inserted.Email);
            obj[16] = new SqlParameter("RV_DiaChi", Inserted.DiaChi);
            obj[17] = new SqlParameter("RV_DienThoai", Inserted.DienThoai);
            obj[18] = new SqlParameter("RV_YM", Inserted.YM);
            obj[19] = new SqlParameter("RV_Skype", Inserted.Skype);
            obj[20] = new SqlParameter("RV_Anh1", Inserted.Anh1);
            obj[21] = new SqlParameter("RV_Anh2", Inserted.Anh2);
            obj[22] = new SqlParameter("RV_Anh3", Inserted.Anh3);
            obj[23] = new SqlParameter("RV_Anh4", Inserted.Anh4);
            obj[24] = new SqlParameter("RV_Anh5", Inserted.Anh5);
            obj[25] = new SqlParameter("RV_Anh6", Inserted.Anh6);
            obj[26] = new SqlParameter("RV_Anh7", Inserted.Anh7);
            obj[27] = new SqlParameter("RV_Anh8", Inserted.Anh8);
            obj[28] = new SqlParameter("RV_Xem", Inserted.Xem);
            obj[29] = new SqlParameter("RV_Active", Inserted.Active);
            obj[30] = new SqlParameter("RV_Anonymous", Inserted.Anonymous);
            obj[31] = new SqlParameter("RV_AnonymousPassword", Inserted.AnonymousPassword);
            obj[32] = new SqlParameter("RV_GH_ID", Inserted.GH_ID);
            obj[33] = new SqlParameter("RV_Publish", Inserted.Publish);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblRaoVat_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RaoVat Update(RaoVat Updated)
        {
            RaoVat Item = new RaoVat();
            SqlParameter[] obj = new SqlParameter[35];
            obj[0] = new SqlParameter("RV_ID", Updated.ID);
            obj[1] = new SqlParameter("RV_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("RV_TINH_ID", Updated.TINH_ID);
            obj[3] = new SqlParameter("RV_NC_ID", Updated.NC_ID);
            obj[4] = new SqlParameter("RV_Gia", Updated.Gia);
            obj[5] = new SqlParameter("RV_LangBased_ID", Updated.LangBased_ID);
            obj[6] = new SqlParameter("RV_LangBased", Updated.LangBased);
            obj[7] = new SqlParameter("RV_Lang", Updated.Lang);
            obj[8] = new SqlParameter("RV_Alias", Updated.Alias);
            obj[9] = new SqlParameter("RV_Ten", Updated.Ten);
            obj[10] = new SqlParameter("RV_MoTa", Updated.MoTa);
            obj[11] = new SqlParameter("RV_NoiDung", Updated.NoiDung);
            if (Updated.NgayDang != DateTime.MinValue)
            {
                obj[12] = new SqlParameter("RV_NgayDang", Updated.NgayDang);
            }
            else
            {
                obj[12] = new SqlParameter("RV_NgayDang", DBNull.Value);
            }
            obj[14] = new SqlParameter("RV_NgayCapNhat", Updated.NgayCapNhat);
            obj[15] = new SqlParameter("RV_TenNguoiDang", Updated.TenNguoiDang);
            obj[16] = new SqlParameter("RV_Email", Updated.Email);
            obj[17] = new SqlParameter("RV_DiaChi", Updated.DiaChi);
            obj[18] = new SqlParameter("RV_DienThoai", Updated.DienThoai);
            obj[19] = new SqlParameter("RV_YM", Updated.YM);
            obj[20] = new SqlParameter("RV_Skype", Updated.Skype);
            obj[21] = new SqlParameter("RV_Anh1", Updated.Anh1);
            obj[22] = new SqlParameter("RV_Anh2", Updated.Anh2);
            obj[23] = new SqlParameter("RV_Anh3", Updated.Anh3);
            obj[24] = new SqlParameter("RV_Anh4", Updated.Anh4);
            obj[25] = new SqlParameter("RV_Anh5", Updated.Anh5);
            obj[26] = new SqlParameter("RV_Anh6", Updated.Anh6);
            obj[27] = new SqlParameter("RV_Anh7", Updated.Anh7);
            obj[28] = new SqlParameter("RV_Anh8", Updated.Anh8);
            obj[29] = new SqlParameter("RV_Xem", Updated.Xem);
            obj[30] = new SqlParameter("RV_Active", Updated.Active);
            obj[31] = new SqlParameter("RV_Anonymous", Updated.Anonymous);
            obj[32] = new SqlParameter("RV_AnonymousPassword", Updated.AnonymousPassword);
            obj[33] = new SqlParameter("RV_GH_ID", Updated.GH_ID);
            obj[34] = new SqlParameter("RV_Publish", Updated.Publish);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RaoVat SelectById(Int32 RV_ID)
        {
            RaoVat Item = new RaoVat();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("RV_ID", RV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static RaoVatCollection SelectAll()
        {
            RaoVatCollection List = new RaoVatCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRaoVat_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static RaoVatCollection SelectAll(SqlConnection con)
        {
            RaoVatCollection List = new RaoVatCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblRaoVat_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<RaoVat> pagerNormalDKDVTIN(string url, bool rewrite, string sort, string q, int size, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[2] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[2] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>("sp_tblRaoVat_Select_SelectAll_TinRVDKDV_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<RaoVat> pagerNormal(string url, bool rewrite, string sort, string q, int size, string DM_ID, string KV_ID, string NC_ID, string user, string Lang, string Publish, string Active, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user))
            {
                obj[5] = new SqlParameter("user", user);
            }
            else
            {
                obj[5] = new SqlParameter("user", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Lang))
            {
                obj[6] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[6] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[7] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[7] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[8] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[8] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[9] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[9] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>("sp_tblRaoVat_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<RaoVat> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string DM_ID, string KV_ID, string NC_ID, string user, string Lang, string Publish, string Active, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user))
            {
                obj[5] = new SqlParameter("user", user);
            }
            else
            {
                obj[5] = new SqlParameter("user", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Lang))
            {
                obj[6] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[6] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[7] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[7] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[8] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[8] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[9] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[9] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>(con,"sp_tblRaoVat_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        /// <summary>
        /// Hampv
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        public static RaoVatCollection pagerNormalTrangchuTop(SqlConnection cnn, string url, bool rewrite, string sort, string q, int size, string DM_ID, string KV_ID, string NC_ID, string Lang, string Publish, string Active, string trangthai)
        {
            RaoVatCollection List = new RaoVatCollection();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }
          
            if (!string.IsNullOrEmpty(Lang))
            {
                obj[5] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[5] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[6] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[6] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[7] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[7] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[8] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[8] = new SqlParameter("trangthai", DBNull.Value);
            }
            obj[9] = new SqlParameter("Top", size);
         


            using (IDataReader rd = SqlHelper.ExecuteReader(cnn, CommandType.StoredProcedure, "sp_tblRaoVat_Pager_Normal_trangchu_hoangdaTop", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
           
        }

        public static Pager<RaoVat> pagerNormalTrangchu(string url, bool rewrite, string sort, string q, int size, string DM_ID, string KV_ID, string NC_ID, string Lang, string Publish, string Active, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Lang))
            {
                obj[5] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[5] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[6] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[6] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[7] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[7] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[8] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[8] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>("sp_tblRaoVat_Pager_Normal_trangchu_hoangda", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<RaoVat> pagerNormalTrangchus(string url, bool rewrite, string sort, string q, int size, string DM_ID, string KV_ID, string NC_ID, string Lang, string Publish, string Active, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Lang))
            {
                obj[5] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[5] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[6] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[6] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[7] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[7] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[8] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[8] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>("sp_tblRaoVat_Pager_Normal_trangchu_hoangdas", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<RaoVat> pagerNormalTrangchurvlienquan(string url, bool rewrite, string sort, string q, int size, string _ID, string KV_ID, string NC_ID, string Lang, string Publish, string Active, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_ID))
            {
                obj[2] = new SqlParameter("RV_ID", _ID);
            }
            else
            {
                obj[2] = new SqlParameter("RV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KV_ID))
            {
                obj[3] = new SqlParameter("KV_ID", KV_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KV_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NC_ID))
            {
                obj[4] = new SqlParameter("NC_ID", NC_ID);
            }
            else
            {
                obj[4] = new SqlParameter("NC_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Lang))
            {
                obj[5] = new SqlParameter("Lang", Lang);
            }
            else
            {
                obj[5] = new SqlParameter("Lang", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[6] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[6] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[7] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[7] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[8] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[8] = new SqlParameter("trangthai", DBNull.Value);
            }
            Pager<RaoVat> pg = new Pager<RaoVat>("sp_tblRaoVat_Pager_Normal_trangchu_hoangdalienquan", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static RaoVat getFromReader(IDataReader rd)
        {
            RaoVat Item = new RaoVat();
            if (rd.FieldExists("_DM_Ma"))
            {
                Item._DM_Ma = (String)(rd["_DM_Ma"]);
            }
            if (rd.FieldExists("_Nhucau_Ten"))
            {
                Item._Nhucau_Ten = (String)(rd["_Nhucau_Ten"]);
            }
            if (rd.FieldExists("_DM_Ten"))
            {
                Item._DM_Ten = (String)(rd["_DM_Ten"]);
            }
            if (rd.FieldExists("_Nhucau_Ten"))
            {
                Item._Nhucau_Ten = (String)(rd["_Nhucau_Ten"]);
            }
            if (rd.FieldExists("_Tinh_Ten"))
            {
                Item._Tinh_Ten = (String)(rd["_Tinh_Ten"]);
            }
            if (rd.FieldExists("RV_ID"))
            {
                Item.ID = (Int32)(rd["RV_ID"]);
            }
            if (rd.FieldExists("RV_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["RV_DM_ID"]);
            }
            if (rd.FieldExists("RV_TINH_ID"))
            {
                Item.TINH_ID = (Int32)(rd["RV_TINH_ID"]);
            }
            if (rd.FieldExists("RV_NC_ID"))
            {
                Item.NC_ID = (Int32)(rd["RV_NC_ID"]);
            }
            if (rd.FieldExists("RV_Gia"))
            {
                Item.Gia = (String)(rd["RV_Gia"]);
            }
            if (rd.FieldExists("RV_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["RV_LangBased_ID"]);
            }
            if (rd.FieldExists("RV_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["RV_LangBased"]);
            }
            if (rd.FieldExists("RV_Lang"))
            {
                Item.Lang = (String)(rd["RV_Lang"]);
            }
            if (rd.FieldExists("RV_Alias"))
            {
                Item.Alias = (String)(rd["RV_Alias"]);
            }
            if (rd.FieldExists("RV_Ten"))
            {
                Item.Ten = (String)(rd["RV_Ten"]);
            }
            if (rd.FieldExists("RV_MoTa"))
            {
                Item.MoTa = (String)(rd["RV_MoTa"]);
            }
            if (rd.FieldExists("RV_NoiDung"))
            {
                Item.NoiDung = (String)(rd["RV_NoiDung"]);
            }
            if (rd.FieldExists("RV_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["RV_NgayDang"]);
            }
            if (rd.FieldExists("RV_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["RV_NgayHetHan"]);
            }
            if (rd.FieldExists("RV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["RV_NgayCapNhat"]);
            }
            if (rd.FieldExists("RV_TenNguoiDang"))
            {
                Item.TenNguoiDang = (String)(rd["RV_TenNguoiDang"]);
            }
            if (rd.FieldExists("RV_Email"))
            {
                Item.Email = (String)(rd["RV_Email"]);
            }
            if (rd.FieldExists("RV_DiaChi"))
            {
                Item.DiaChi = (String)(rd["RV_DiaChi"]);
            }
            if (rd.FieldExists("RV_DienThoai"))
            {
                Item.DienThoai = (String)(rd["RV_DienThoai"]);
            }
            if (rd.FieldExists("RV_YM"))
            {
                Item.YM = (String)(rd["RV_YM"]);
            }
            if (rd.FieldExists("RV_Skype"))
            {
                Item.Skype = (String)(rd["RV_Skype"]);
            }
            if (rd.FieldExists("RV_Anh1"))
            {
                Item.Anh1 = (String)(rd["RV_Anh1"]);
            }
            if (rd.FieldExists("RV_Anh2"))
            {
                Item.Anh2 = (String)(rd["RV_Anh2"]);
            }
            if (rd.FieldExists("RV_Anh3"))
            {
                Item.Anh3 = (String)(rd["RV_Anh3"]);
            }
            if (rd.FieldExists("RV_Anh4"))
            {
                Item.Anh4 = (String)(rd["RV_Anh4"]);
            }
            if (rd.FieldExists("RV_Anh5"))
            {
                Item.Anh5 = (String)(rd["RV_Anh5"]);
            }
            if (rd.FieldExists("RV_Anh6"))
            {
                Item.Anh6 = (String)(rd["RV_Anh6"]);
            }
            if (rd.FieldExists("RV_Anh7"))
            {
                Item.Anh7 = (String)(rd["RV_Anh7"]);
            }
            if (rd.FieldExists("RV_Anh8"))
            {
                Item.Anh8 = (String)(rd["RV_Anh8"]);
            }
            if (rd.FieldExists("RV_Xem"))
            {
                Item.Xem = (Int32)(rd["RV_Xem"]);
            }
            if (rd.FieldExists("RV_VIP_SUPER"))
            {
                Item.VIP_SUPER = (Boolean)(rd["RV_VIP_SUPER"]);
            }
            if (rd.FieldExists("RV_VIP_SUPER_NgayHetHan"))
            {
                Item.VIP_SUPER_NgayHetHan = (DateTime)(rd["RV_VIP_SUPER_NgayHetHan"]);
            }
            if (rd.FieldExists("RV_VIP_SUPER_NgayBatDau"))
            {
                Item.VIP_SUPER_NgayBatDau = (DateTime)(rd["RV_VIP_SUPER_NgayBatDau"]);
            }
            if (rd.FieldExists("RV_VIP_VIP"))
            {
                Item.VIP_VIP = (Boolean)(rd["RV_VIP_VIP"]);
            }
            if (rd.FieldExists("RV_VIP_VIP_NgayBatDau"))
            {
                Item.VIP_VIP_NgayBatDau = (DateTime)(rd["RV_VIP_VIP_NgayBatDau"]);
            }
            if (rd.FieldExists("RV_VIP_VIP_NgayHetHan"))
            {
                Item.VIP_VIP_NgayHetHan = (DateTime)(rd["RV_VIP_VIP_NgayHetHan"]);
            }
            if (rd.FieldExists("RV_VIP_VIP_NgayBatDau_Active"))
            {
                Item.VIP_VIP_NgayBatDau_Active = (DateTime)(rd["RV_VIP_VIP_NgayBatDau_Active"]);
            }
            if (rd.FieldExists("RV_VIP_VIP_NgayHetHan_Active"))
            {
                Item.VIP_VIP_NgayHetHan_Active = (DateTime)(rd["RV_VIP_VIP_NgayHetHan_Active"]);
            }
            if (rd.FieldExists("RV_VIP_NoiBat"))
            {
                Item.VIP_NoiBat = (Boolean)(rd["RV_VIP_NoiBat"]);
            }
            if (rd.FieldExists("RV_VIP_NoiBat_NgayHetHan"))
            {
                Item.VIP_NoiBat_NgayHetHan = (DateTime)(rd["RV_VIP_NoiBat_NgayHetHan"]);
            }
            if (rd.FieldExists("RV_VIP_NoiBat_NgayBatDau"))
            {
                Item.VIP_NoiBat_NgayBatDau = (DateTime)(rd["RV_VIP_NoiBat_NgayBatDau"]);
            }
            if (rd.FieldExists("RV_Active"))
            {
                Item.Active = (Boolean)(rd["RV_Active"]);
            }
            if (rd.FieldExists("RV_Anonymous"))
            {
                Item.Anonymous = (Boolean)(rd["RV_Anonymous"]);
            }
            if (rd.FieldExists("RV_AnonymousPassword"))
            {
                Item.AnonymousPassword = (String)(rd["RV_AnonymousPassword"]);
            }
            if (rd.FieldExists("RV_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["RV_GH_ID"]);
            }
            if (rd.FieldExists("RV_Publish"))
            {
                Item.Publish = (Boolean)(rd["RV_Publish"]);
            }//RV_ChuyenBanGiong
            if (rd.FieldExists("RV_ChuyenBanGiong"))
            {
                Item.ChuyenBanGiong = (Boolean)(rd["RV_ChuyenBanGiong"]);
            }
            if (rd.FieldExists("RV_DangKy_SUPER"))
            {
                Item.DangKy_SUPER = (Boolean)(Convert.ToBoolean(rd["RV_DangKy_SUPER"]));
            }
            if (rd.FieldExists("RV_DangKy_VIP"))
            {
                Item.DangKy_VIP = (Boolean)(Convert.ToBoolean(rd["RV_DangKy_VIP"]));
            }
            if (rd.FieldExists("RV_DangKy_NoiBat"))
            {
                Item.DangKy_NoiBat = (Boolean)(Convert.ToBoolean(rd["RV_DangKy_NoiBat"]));
            }
            if (rd.FieldExists("RV_NoiDung"))
            {
                Item.NoiDung = (String)(rd["RV_NoiDung"]);
            }
            if (rd.FieldExists("RV_MoTa"))
            {
                Item.MoTa = (String)(rd["RV_MoTa"]);
            }
            if (rd.FieldExists("TuNgay"))
            {
                Item.TuNgay = (DateTime)(rd["TuNgay"]);
            }
            if (rd.FieldExists("DenNgay"))
            {
                Item.DenNgay = (DateTime)(rd["DenNgay"]);
            }
            docsoft.entities.Member _mem = new docsoft.entities.Member();
            _mem = docsoft.entities.MemberDal.getFromReader(rd);
            Item._Member = _mem;
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}


