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
using docsoft.entities;
namespace cnn.entities
{
    #region SanPham
    #region BO
    public class SanPham : BaseEntity
    {
        #region Properties
        public String Username { get; set; }
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 XuatXu_ID { get; set; }
        public String Lang { get; set; }
        public Int32 LangBased_ID { get; set; }
        public Boolean LangBased { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public Double GNY { get; set; }
        public Double GiaNhap { get; set; }
        public Int32 DonVi_ID { get; set; }
        public Double SoLuong { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String Anh { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public Boolean Home { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Boolean Hot4 { get; set; }
        public Int16 P1 { get; set; }
        public DateTime NgayBD_DK_SPDT { get; set; }
        public DateTime NgayKT_DK_SPDT { get; set; }
        public Boolean Draff { get; set; }

        public DateTime NgayBD_DK_SPMenu { get; set; }
        public DateTime NgayKT_DK_SPMenu { get; set; }
        #endregion
        #region Contructor
        public SanPham()
        { }
        #endregion
        #region Customs properties
        public List<Files> ListFiles { get; set; }
        public GianHang ItemGianHang { get; set; }
        public string _DM_Ten { get; set; }
        public string _XuatXu_Ten { get; set; }
        public string _DonVi_Ten { get; set; }
        public string _GH_Ten { get; set; }
        public string LoaiThanhVien { get; set; }
        public Boolean GH_DamBao { get; set; }
        public Boolean GH_Active { get; set; }
        public string GH_Ten { get; set; }
        public string GH_DiaChi { get; set; }
        public string GH_Email { get; set; }
       
        public string LH_YM { get; set; }
        public string LH_Ten { get; set; }
        public string LH_Email { get; set; }
        public string LH_Mobile { get; set; }
        public string LH_Phone { get; set; }

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SanPhamDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SanPhamCollection : BaseEntityCollection<SanPham>
    { }
    #endregion
    #region Dal
    public class SanPhamDal
    {
        #region Methods

        public static void DeleteById(Int32 HH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Delete_DeleteById_hoangda", obj);
        }
        public static void DangSPDungSP(string HH_ID, string DangSP, string DungAdm)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            if (!string.IsNullOrEmpty(DangSP))
            {
                obj[1] = new SqlParameter("HH_Publish", DangSP);
            }
            else
            {
                obj[1] = new SqlParameter("HH_Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DungAdm))
            {
                obj[2] = new SqlParameter("HH_Active", DungAdm);
            }
            else
            {
                obj[2] = new SqlParameter("HH_Active", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_DangSP_DungSP_ById_hoangda", obj);
        }

        public static SanPham InsertDraff(SanPham Inserted)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("HH_Lang", Inserted.Lang);
            obj[1] = new SqlParameter("HH_LangBased_ID", Inserted.LangBased_ID);
            obj[2] = new SqlParameter("HH_LangBased", Inserted.LangBased);
            obj[3] = new SqlParameter("HH_NgayTao", Inserted.NgayTao);
            obj[4] = new SqlParameter("HH_NguoiTao", Inserted.NguoiTao);
            obj[5] = new SqlParameter("HH_RowId", Inserted.RowId);
            obj[6] = new SqlParameter("HH_Draff", true);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static SanPham Insert(SanPham Inserted)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("HH_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("HH_GH_ID", Inserted.GH_ID);
            obj[2] = new SqlParameter("HH_XuatXu_ID", Inserted.XuatXu_ID);
            obj[3] = new SqlParameter("HH_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("HH_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("HH_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("HH_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("HH_Ten", Inserted.Ten);
            obj[8] = new SqlParameter("HH_Ma", Inserted.Ma);
            obj[9] = new SqlParameter("HH_Keywords", Inserted.Keywords);
            obj[10] = new SqlParameter("HH_Description", Inserted.Description);
            obj[11] = new SqlParameter("HH_MoTa", Inserted.MoTa);
            obj[12] = new SqlParameter("HH_NoiDung", Inserted.NoiDung);
            obj[13] = new SqlParameter("HH_GNY", Inserted.GNY);
            obj[14] = new SqlParameter("HH_GiaNhap", Inserted.GiaNhap);
            obj[15] = new SqlParameter("HH_DonVi_ID", Inserted.DonVi_ID);
            obj[16] = new SqlParameter("HH_SoLuong", Inserted.SoLuong);
            obj[17] = new SqlParameter("HH_RowId", Inserted.RowId);
            obj[18] = new SqlParameter("HH_NgayTao", Inserted.NgayTao);
            obj[19] = new SqlParameter("HH_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("HH_NgayCapNhat", Inserted.NgayCapNhat);
            obj[21] = new SqlParameter("HH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[22] = new SqlParameter("HH_Anh", Inserted.Anh);
            obj[23] = new SqlParameter("HH_Publish", Inserted.Publish);
            obj[24] = new SqlParameter("HH_Active", Inserted.Active);
            obj[25] = new SqlParameter("HH_Home", Inserted.Home);
            obj[26] = new SqlParameter("HH_Hot1", Inserted.Hot1);
            obj[27] = new SqlParameter("HH_Hot2", Inserted.Hot2);
            obj[28] = new SqlParameter("HH_Hot3", Inserted.Hot3);
            obj[29] = new SqlParameter("HH_Hot4", Inserted.Hot4);
            obj[30] = new SqlParameter("HH_P1", Inserted.P1);
            obj[31] = new SqlParameter("HH_NgayBD_DK_SPDT", DBNull.Value);
            obj[32] = new SqlParameter("HH_NgayKT_DK_SPDT", DBNull.Value);
            obj[33] = new SqlParameter("Username", Inserted.Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        /// <summary>
        /// ham nay phuc vu cho chuyen du lieu Duc cap nhat ngay 280711
        /// </summary>
        /// <param name="Inserted"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static SanPham Insert(SanPham Inserted, SqlConnection con)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("HH_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("HH_GH_ID", Inserted.GH_ID);
            obj[2] = new SqlParameter("HH_XuatXu_ID", Inserted.XuatXu_ID);
            obj[3] = new SqlParameter("HH_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("HH_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("HH_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("HH_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("HH_Ten", Inserted.Ten);
            obj[8] = new SqlParameter("HH_Ma", Inserted.Ma);
            obj[9] = new SqlParameter("HH_Keywords", Inserted.Keywords);
            obj[10] = new SqlParameter("HH_Description", Inserted.Description);
            obj[11] = new SqlParameter("HH_MoTa", Inserted.MoTa);
            obj[12] = new SqlParameter("HH_NoiDung", Inserted.NoiDung);
            obj[13] = new SqlParameter("HH_GNY", Inserted.GNY);
            obj[14] = new SqlParameter("HH_GiaNhap", Inserted.GiaNhap);
            obj[15] = new SqlParameter("HH_DonVi_ID", Inserted.DonVi_ID);
            obj[16] = new SqlParameter("HH_SoLuong", Inserted.SoLuong);
            obj[17] = new SqlParameter("HH_RowId", Inserted.RowId);
            obj[18] = new SqlParameter("HH_NgayTao", Inserted.NgayTao);
            obj[19] = new SqlParameter("HH_NguoiTao", Inserted.NguoiTao);
            obj[20] = new SqlParameter("HH_NgayCapNhat", Inserted.NgayCapNhat);
            obj[21] = new SqlParameter("HH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[22] = new SqlParameter("HH_Anh", Inserted.Anh);
            obj[23] = new SqlParameter("HH_Publish", Inserted.Publish);
            obj[24] = new SqlParameter("HH_Active", Inserted.Active);
            obj[25] = new SqlParameter("HH_Home", Inserted.Home);
            obj[26] = new SqlParameter("HH_Hot1", Inserted.Hot1);
            obj[27] = new SqlParameter("HH_Hot2", Inserted.Hot2);
            obj[28] = new SqlParameter("HH_Hot3", Inserted.Hot3);
            obj[29] = new SqlParameter("HH_Hot4", Inserted.Hot4);
            obj[30] = new SqlParameter("HH_P1", Inserted.P1);
            obj[31] = new SqlParameter("HH_NgayBD_DK_SPDT", Inserted.NgayBD_DK_SPDT);
            obj[32] = new SqlParameter("HH_NgayKT_DK_SPDT", DBNull.Value);
            obj[33] = new SqlParameter("Username", Inserted.Username);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SanPham Update(SanPham Updated)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[34];
            obj[0] = new SqlParameter("HH_ID", Updated.ID);
            obj[1] = new SqlParameter("HH_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("HH_GH_ID", Updated.GH_ID);
            obj[3] = new SqlParameter("HH_XuatXu_ID", Updated.XuatXu_ID);
            obj[4] = new SqlParameter("HH_Lang", Updated.Lang);
            obj[5] = new SqlParameter("HH_LangBased_ID", Updated.LangBased_ID);
            obj[6] = new SqlParameter("HH_LangBased", Updated.LangBased);
            obj[7] = new SqlParameter("HH_Alias", Updated.Alias);
            obj[8] = new SqlParameter("HH_Ten", Updated.Ten);
            obj[9] = new SqlParameter("HH_Ma", Updated.Ma);
            obj[10] = new SqlParameter("HH_Keywords", Updated.Keywords);
            obj[11] = new SqlParameter("HH_Description", Updated.Description);
            obj[12] = new SqlParameter("HH_MoTa", Updated.MoTa);
            obj[13] = new SqlParameter("HH_NoiDung", Updated.NoiDung);
            obj[14] = new SqlParameter("HH_GNY", Updated.GNY);
            obj[15] = new SqlParameter("HH_GiaNhap", Updated.GiaNhap);
            obj[16] = new SqlParameter("HH_DonVi_ID", Updated.DonVi_ID);
            obj[17] = new SqlParameter("HH_SoLuong", Updated.SoLuong);
            obj[18] = new SqlParameter("HH_RowId", Updated.RowId);
            obj[19] = new SqlParameter("HH_NgayTao", Updated.NgayTao);
            obj[20] = new SqlParameter("HH_NguoiTao", Updated.NguoiTao);
            obj[21] = new SqlParameter("HH_NgayCapNhat", Updated.NgayCapNhat);
            obj[22] = new SqlParameter("HH_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[23] = new SqlParameter("HH_Anh", Updated.Anh);
            obj[24] = new SqlParameter("HH_Publish", Updated.Publish);
            obj[25] = new SqlParameter("HH_Active", Updated.Active);
            obj[26] = new SqlParameter("HH_Home", Updated.Home);
            obj[27] = new SqlParameter("HH_Hot1", Updated.Hot1);
            obj[28] = new SqlParameter("HH_Hot2", Updated.Hot2);
            obj[29] = new SqlParameter("HH_Hot3", Updated.Hot3);
            obj[30] = new SqlParameter("HH_Hot4", Updated.Hot4);
            obj[31] = new SqlParameter("HH_P1", Updated.P1);
            obj[32] = new SqlParameter("HH_NgayBD_DK_SPDT", DBNull.Value);
            obj[33] = new SqlParameter("HH_NgayKT_DK_SPDT", DBNull.Value);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static SanPham UpdateDKDV(SanPham Updated, string hot1, string hot2, string hot3, string hot4)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("HH_ID", Updated.ID);
            if (!string.IsNullOrEmpty(hot1))
            {
                obj[1] = new SqlParameter("HH_Hot1", hot1);
            }
            else
            {
                obj[1] = new SqlParameter("HH_Hot1", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(hot2))
            {
                obj[2] = new SqlParameter("HH_Hot2", hot2);
            }
            else
            {
                obj[2] = new SqlParameter("HH_Hot2", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(hot3))
            {
                obj[3] = new SqlParameter("HH_Hot3", hot3);
            }
            else
            {
                obj[3] = new SqlParameter("HH_Hot3", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(hot4))
            {
                obj[4] = new SqlParameter("HH_Hot4", hot4);
            }
            else
            {
                obj[4] = new SqlParameter("HH_Hot4", DBNull.Value);
            }
            if (Updated.NgayBD_DK_SPDT != DateTime.MinValue)
            {
                obj[5] = new SqlParameter("HH_NgayBD_DK_SPDT", Updated.NgayBD_DK_SPDT);
            }
            else
            {
                obj[5] = new SqlParameter("HH_NgayBD_DK_SPDT", DBNull.Value);
            }
            if (Updated.NgayKT_DK_SPDT != DateTime.MinValue)
            {
                obj[6] = new SqlParameter("HH_NgayKT_DK_SPDT", Updated.NgayKT_DK_SPDT);
            }
            else
            {
                obj[6] = new SqlParameter("HH_NgayKT_DK_SPDT", DBNull.Value);
            }
            if (Updated.NgayBD_DK_SPMenu != DateTime.MinValue)
            {
                obj[7] = new SqlParameter("HH_NgayBD_DK_SPMenu", Updated.NgayBD_DK_SPMenu);
            }
            else
            {
                obj[7] = new SqlParameter("HH_NgayBD_DK_SPMenu", DBNull.Value);
            }
            if (Updated.NgayKT_DK_SPMenu != DateTime.MinValue)
            {
                obj[8] = new SqlParameter("HH_NgayKT_DK_SPMenu", Updated.NgayKT_DK_SPMenu);
            }
            else
            {
                obj[8] = new SqlParameter("HH_NgayKT_DK_SPMenu", DBNull.Value);
            }

            //obj[5] = new SqlParameter("HH_NgayBD_DK_SPDT", DBNull.Value);
            //obj[6] = new SqlParameter("HH_NgayKT_DK_SPDT", DBNull.Value);
            //obj[7] = new SqlParameter("HH_NgayBD_DK_SPMenu", DBNull.Value);
            //obj[8] = new SqlParameter("HH_NgayKT_DK_SPMenu", DBNull.Value);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_DKDV_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SanPham SelectById(Int32 HH_ID)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static SanPham SelectById(SqlConnection con, Int32 HH_ID)
        {
            SanPham Item = new SanPham();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static SanPhamCollection SelectByDM_ID(SqlConnection con, Int32 DM_ID, int Sobantin)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("HH_DM_ID", DM_ID);
            if (Sobantin == -1)
            {
                obj[1] = new SqlParameter("SobanTin", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("SobanTin", Sobantin);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectByDM_ID_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static SanPhamCollection SelectTreeParentByDmId(int DM_ID)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_DanhMuc_Select_Select_TreeParentByDmId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SanPhamCollection LoaiHinhDoanhNghiep_SelectByGH_ID(int GH_ID)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGianHang_LoaiHinhDoanhNghiep_SelectByGH_ID_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }



        public static SanPhamCollection SelectAll()
        {
            SanPhamCollection List = new SanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SanPhamCollection SelectTop8SanPhamDacTrung(SqlConnection con)
        {
            SanPhamCollection List = new SanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTop8SanPhamDacTrung_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SanPhamCollection SelectTop8SanPhamMoi(SqlConnection con)
        {
            SanPhamCollection List = new SanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTop8SanPhamMoi_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SanPhamCollection SelectTop8SanPhamMoi(SqlConnection con, int top)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTop8SanPhamMoi_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SanPhamCollection SelectTop8SanPhamMoi(int top)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectTop8SanPhamMoi_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SanPhamCollection SelectTopSanPhamMoiByGHID(SqlConnection con, int top, int GH_ID)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            if (top == -1)
            {
                obj[1] = new SqlParameter("Top", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("Top", top);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectSanPhamByGH_Id_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SanPhamCollection SelectTopSanPhamMoiByGHIDDMID(SqlConnection con, int top, int GH_ID, string _DM_ID)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            if (top == -1)
            {
                obj[1] = new SqlParameter("Top", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("Top", top);
            }
            obj[2] = new SqlParameter("DM_ID", _DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectSanPhamByGH_Id_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SanPhamCollection SelectTopSanPhamMoiByGHID(SqlConnection con, int top, int bottom, int GH_ID)
        {
            SanPhamCollection List = new SanPhamCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (GH_ID == -1)
            {
                obj[0] = new SqlParameter("GH_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("GH_ID", GH_ID);
            }

            obj[1] = new SqlParameter("Top", top);
            obj[2] = new SqlParameter("Bottom", bottom);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectSanPhamBetweenByGH_Id_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static SanPhamCollection SelectPhamMenu(SqlConnection con)
        {
            SanPhamCollection List = new SanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectSanPhamMenu_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static Pager<SanPham> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<SanPham> pg = new Pager<SanPham>("sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<SanPham> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<SanPham> pg = new Pager<SanPham>(con, "sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<SanPham> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string Active, string Username, string Publish, int Statuts, int DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[3] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[3] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[4] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[4] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Statuts.ToString()))
            {
                obj[5] = new SqlParameter("Statuts", Statuts);
            }
            else
            {
                obj[5] = new SqlParameter("Statuts", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID.ToString()))
            {
                obj[6] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[6] = new SqlParameter("DM_ID", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>(con, "sp_tblHangHoa_Pager_Normal_hoangda", "Pages", size, 5, rewrite, url, obj);
            return pg;
        }

        public static Pager<SanPham> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string Active, string Username, string Publish, int Statuts)
        {
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[3] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[3] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[4] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[4] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Statuts.ToString()))
            {
                obj[5] = new SqlParameter("Statuts", Statuts);
            }
            else
            {
                obj[5] = new SqlParameter("Statuts", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>(con, "sp_tblHangHoa_Pager_Normal_hoangda", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<SanPham> pagerNormal(string url, bool rewrite, string sort, string q, int size, string Active, string Username, string Publish, int Statuts, string DM_ID, string GH_ID)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[3] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[3] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[4] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[4] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Statuts.ToString()))
            {
                obj[5] = new SqlParameter("Statuts", Statuts);
            }
            else
            {
                obj[5] = new SqlParameter("Statuts", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[6] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[6] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(GH_ID))
            {
                obj[7] = new SqlParameter("GH_ID", GH_ID);
            }
            else
            {
                obj[7] = new SqlParameter("GH_ID", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>("sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<SanPham> pagerNormal(string url, bool rewrite, string sort, string q, int size, string Active, string Username, string Publish, int Statuts)
        {
            SqlParameter[] obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[3] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[3] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[4] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[4] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Statuts.ToString()))
            {
                obj[5] = new SqlParameter("Statuts", Statuts);
            }
            else
            {
                obj[5] = new SqlParameter("Statuts", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>("sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<SanPham> pagerNormal(string url, bool rewrite, string sort, string q, int size, string Publish, int Statuts)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Publish))
            {
                obj[2] = new SqlParameter("Publish", Publish);
            }
            else
            {
                obj[2] = new SqlParameter("Publish", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Statuts.ToString()))
            {
                obj[3] = new SqlParameter("Statuts", Statuts);
            }
            else
            {
                obj[3] = new SqlParameter("Statuts", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>("sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<SanPham> pagerNormal(string url, bool rewrite, string sort, string q, int size, string Active)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Active))
            {
                obj[2] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[2] = new SqlParameter("Active", DBNull.Value);
            }
            Pager<SanPham> pg = new Pager<SanPham>("sp_tblHangHoa_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SanPham getFromReader(IDataReader rd)
        {
            SanPham Item = new SanPham();
            if (rd.FieldExists("HH_ID"))
            {
                Item.ID = (Int32)(rd["HH_ID"]);
            }
            if (rd.FieldExists("HH_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["HH_DM_ID"]);
            }
            if (rd.FieldExists("DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["DM_ID"]);
            }

            if (rd.FieldExists("HH_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["HH_GH_ID"]);
            }
        
            if (rd.FieldExists("HH_XuatXu_ID"))
            {
                Item.XuatXu_ID = (Int32)(rd["HH_XuatXu_ID"]);
            }
            if (rd.FieldExists("HH_Lang"))
            {
                Item.Lang = (String)(rd["HH_Lang"]);
            }
            if (rd.FieldExists("HH_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["HH_LangBased_ID"]);
            }
            if (rd.FieldExists("HH_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["HH_LangBased"]);
            }
            if (rd.FieldExists("HH_Alias"))
            {
                Item.Alias = (String)(rd["HH_Alias"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_Keywords"))
            {
                Item.Keywords = (String)(rd["HH_Keywords"]);
            }
            if (rd.FieldExists("HH_Description"))
            {
                Item.Description = (String)(rd["HH_Description"]);
            }
            if (rd.FieldExists("HH_MoTa"))
            {
                Item.MoTa = (String)(rd["HH_MoTa"]);
            }
            if (rd.FieldExists("HH_NoiDung"))
            {
                Item.NoiDung = (String)(rd["HH_NoiDung"]);
            }
            if (rd.FieldExists("HH_GNY"))
            {
                Item.GNY = (Double)(rd["HH_GNY"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                Item.GiaNhap = (Double)(rd["HH_GiaNhap"]);
            }
            if (rd.FieldExists("HH_DonVi_ID"))
            {
                Item.DonVi_ID = (Int32)(rd["HH_DonVi_ID"]);
            }
            if (rd.FieldExists("HH_SoLuong"))
            {
                Item.SoLuong = (Double)(rd["HH_SoLuong"]);
            }
            if (rd.FieldExists("HH_RowId"))
            {
                Item.RowId = (Guid)(rd["HH_RowId"]);
            }
            if (rd.FieldExists("HH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HH_NgayTao"]);
            }
            if (rd.FieldExists("HH_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HH_NguoiTao"]);
            }
            if (rd.FieldExists("HH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["HH_NgayCapNhat"]);
            }
            if (rd.FieldExists("HH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["HH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("HH_Anh"))
            {
                Item.Anh = (String)(rd["HH_Anh"]);
            }
            if (rd.FieldExists("HH_Publish"))
            {
                Item.Publish = (Boolean)(rd["HH_Publish"]);
            }
            if (rd.FieldExists("HH_Active"))
            {
                Item.Active = (Boolean)(rd["HH_Active"]);
            }
            if (rd.FieldExists("HH_Home"))
            {
                Item.Home = (Boolean)(rd["HH_Home"]);
            }
            if (rd.FieldExists("HH_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["HH_Hot1"]);
            }
            if (rd.FieldExists("HH_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["HH_Hot2"]);
            }
            if (rd.FieldExists("HH_Hot3"))
            {
                Item.Hot3 = (Boolean)(rd["HH_Hot3"]);
            }
            if (rd.FieldExists("HH_Hot4"))
            {
                Item.Hot4 = (Boolean)(rd["HH_Hot4"]);
            }
            if (rd.FieldExists("HH_P1"))
            {
                Item.P1 = (Int16)(rd["HH_P1"]);
            }
            if (rd.FieldExists("HH_NgayBD_DK_SPDT"))
            {
                Item.NgayBD_DK_SPDT = (DateTime)(rd["HH_NgayBD_DK_SPDT"]);
            }
            if (rd.FieldExists("HH_NgayKT_DK_SPDT"))
            {
                Item.NgayKT_DK_SPDT = (DateTime)(rd["HH_NgayKT_DK_SPDT"]);
            }

            if (rd.FieldExists("HH_NgayBD_DK_SPMenu"))
            {
                Item.NgayBD_DK_SPMenu = (DateTime)(rd["HH_NgayBD_DK_SPMenu"]);
            }
            if (rd.FieldExists("HH_NgayKT_DK_SPMenu"))
            {
                Item.NgayKT_DK_SPMenu = (DateTime)(rd["HH_NgayKT_DK_SPMenu"]);
            }

            if (rd.FieldExists("_DM_Ten"))
            {
                Item._DM_Ten = (String)(rd["_DM_Ten"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item._DM_Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("_XuatXu_Ten"))
            {
                Item._XuatXu_Ten = (String)(rd["_XuatXu_Ten"]);
            }
            if (rd.FieldExists("_DonVi_Ten"))
            {
                Item._DonVi_Ten = (String)(rd["_DonVi_Ten"]);
            }
            if (rd.FieldExists("_GH_Ten"))
            {
                Item._GH_Ten = (String)(rd["_GH_Ten"]);
            }
            if (rd.FieldExists("GH_Ten"))
            {
                Item.GH_Ten = (String)(rd["GH_Ten"]);
            }
            if (rd.FieldExists("GH_DiaChi"))
            {
                Item.GH_DiaChi = (String)(rd["GH_DiaChi"]);
            }
            if (rd.FieldExists("HH_Draff"))
            {
                Item.Draff = (Boolean)(rd["HH_Draff"]);
            }

            if (rd.FieldExists("GH_Active"))
            {
                Item.GH_Active = (Boolean)(rd["GH_Active"]);
            }
            if (rd.FieldExists("GH_Email"))
            {
                Item.GH_Email = (String)(rd["GH_Email"]);
            }
            if (rd.FieldExists("GH_DamBao"))
            {
                Item.GH_DamBao = (Boolean)(rd["GH_DamBao"]);
            }
 
            if (rd.FieldExists("LoaiThanhVien"))
            {
                Item.LoaiThanhVien = (String)(rd["LoaiThanhVien"]);
            }

            if (rd.FieldExists("LH_Ym"))
            {
                Item.LH_YM = (String)(rd["LH_Ym"]);
            }
            if (rd.FieldExists("LH_Ten"))
            {
                Item.LH_Ten = (String)(rd["LH_Ten"]);
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
            return Item;
        }
        #endregion

        #region Extend

        public static void UpdateDKSPDacTrung(string ID, string dkspdt, DateTime timebd, DateTime timekt)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ID", ID);
            if (!string.IsNullOrEmpty(dkspdt))
            {
                obj[1] = new SqlParameter("dkspdt", dkspdt);
            }
            else
            {
                obj[1] = new SqlParameter("dkspdt", DBNull.Value);
            }

            if (timebd != DateTime.MinValue)
            {
                obj[2] = new SqlParameter("timebd", timebd);
            }
            else
            {
                obj[2] = new SqlParameter("timebd", DBNull.Value);
            }
            if (timekt != DateTime.MinValue)
            {
                obj[3] = new SqlParameter("timekt", timekt);
            }
            else
            {
                obj[3] = new SqlParameter("timekt", DBNull.Value);
            }
            obj[4] = new SqlParameter("HH_NgayCapNhat", DateTime.Now);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_DKSPDACTRUNG", obj);
        }
        public static void UpdateDKSPMenu(string ID, string dkspdt, DateTime timebd, DateTime timekt)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ID", ID);
            if (!string.IsNullOrEmpty(dkspdt))
            {
                obj[1] = new SqlParameter("dkspdt", dkspdt);
            }
            else
            {
                obj[1] = new SqlParameter("dkspdt", DBNull.Value);
            }

            if (timebd != DateTime.MinValue)
            {
                obj[2] = new SqlParameter("timebd", timebd);
            }
            else
            {
                obj[2] = new SqlParameter("timebd", DBNull.Value);
            }
            if (timekt != DateTime.MinValue)
            {
                obj[3] = new SqlParameter("timekt", timekt);
            }
            else
            {
                obj[3] = new SqlParameter("timekt", DBNull.Value);
            }
            obj[4] = new SqlParameter("HH_NgayCapNhat", DateTime.Now);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_DKSPMENU", obj);
        }

        #endregion
    }
    #endregion

    #endregion
}
