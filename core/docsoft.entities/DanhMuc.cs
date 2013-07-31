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
namespace docsoft.entities
{

    #region DanhMuc
    #region BO
    public class DanhMuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 PID { get; set; }
        public Int32 LDM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String KyHieu { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiSua { get; set; }
        public Int32 ThuTu { get; set; }
        public String GiaTri { get; set; }
        public String KeyWords { get; set; }
        public String Description { get; set; }
        public Guid RowId { get; set; }
        public Boolean Deleted { get; set; }
        public String Anh { get; set; }
        public Int32 TotalRv { get; set; }
        public Int32 TotalHh { get; set; }
        public Int32 TotalGt { get; set; }
        public Int32 TotalDn { get; set; }
        #endregion
        #region Contructor
        public DanhMuc()
        { }
        #endregion
        #region Customs properties
        public List<DanhMuc> ListDanhMuc { get; set; }
        public LoaiDanhMuc loaiDanhMuc { get; set; }
        public Int32 Level { get; set; }
        public string LDM_Ten { get; set; }
        public string PID_Ten { get; set; }
        public Int32 _ID { get; set; }
        #region Hoangda
        //public Int32 DM_ID { get; set; }
        //public string DM_Ten { get; set; }
        #endregion
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DanhMucCollection : BaseEntityCollection<DanhMuc>
    { }
    #endregion
    #region Dal
    public class DanhMucDal
    {
        #region Methods
        public static void DeleteById(Int32 DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Delete_DeleteById_linhnx", obj);
        }




        public static DanhMuc Insert(DanhMuc Inserted)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[25];
            obj[0] = new SqlParameter("DM_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("DM_PID", Inserted.PID);
            obj[2] = new SqlParameter("DM_LDM_ID", Inserted.LDM_ID);
            obj[3] = new SqlParameter("DM_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("DM_LangBased", Inserted.LangBased);
            obj[5] = new SqlParameter("DM_LangBased_ID", Inserted.LangBased_ID);
            obj[6] = new SqlParameter("DM_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("DM_KyHieu", Inserted.KyHieu);
            obj[8] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("DM_Ma", Inserted.Ma);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("DM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("DM_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("DM_NguoiSua", Inserted.NguoiSua);
            obj[14] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[15] = new SqlParameter("DM_GiaTri", Inserted.GiaTri);
            obj[16] = new SqlParameter("DM_KeyWords", Inserted.KeyWords);
            obj[17] = new SqlParameter("DM_Description", Inserted.Description);
            obj[18] = new SqlParameter("DM_RowId", Inserted.RowId);
            obj[19] = new SqlParameter("DM_Deleted", Inserted.Deleted);
            obj[20] = new SqlParameter("DM_Anh", Inserted.Anh);
            obj[21] = new SqlParameter("DM_TotalRv", Inserted.TotalRv);
            obj[22] = new SqlParameter("DM_TotalHh", Inserted.TotalHh);
            obj[23] = new SqlParameter("DM_TotalGt", Inserted.TotalGt);
            obj[24] = new SqlParameter("DM_TotalDn", Inserted.TotalDn);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMuc Insert(DanhMuc Inserted, SqlTransaction tran)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[25];
            obj[0] = new SqlParameter("DM_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("DM_PID", Inserted.PID);
            obj[2] = new SqlParameter("DM_LDM_ID", Inserted.LDM_ID);
            obj[3] = new SqlParameter("DM_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("DM_LangBased", Inserted.LangBased);
            obj[5] = new SqlParameter("DM_LangBased_ID", Inserted.LangBased_ID);
            obj[6] = new SqlParameter("DM_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("DM_KyHieu", Inserted.KyHieu);
            obj[8] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("DM_Ma", Inserted.Ma);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("DM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("DM_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("DM_NguoiSua", Inserted.NguoiSua);
            obj[14] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[15] = new SqlParameter("DM_GiaTri", Inserted.GiaTri);
            obj[16] = new SqlParameter("DM_KeyWords", Inserted.KeyWords);
            obj[17] = new SqlParameter("DM_Description", Inserted.Description);
            obj[18] = new SqlParameter("DM_RowId", Inserted.RowId);
            obj[19] = new SqlParameter("DM_Deleted", Inserted.Deleted);
            obj[20] = new SqlParameter("DM_Anh", Inserted.Anh);
            obj[21] = new SqlParameter("DM_TotalRv", Inserted.TotalRv);
            obj[22] = new SqlParameter("DM_TotalHh", Inserted.TotalHh);
            obj[23] = new SqlParameter("DM_TotalGt", Inserted.TotalGt);
            obj[24] = new SqlParameter("DM_TotalDn", Inserted.TotalDn);

            using (IDataReader rd = SqlHelper.ExecuteReader(tran, CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Insert_InsertNormal_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Insert(DanhMuc Inserted, SqlConnection con)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[25];
            obj[0] = new SqlParameter("DM_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("DM_PID", Inserted.PID);
            obj[2] = new SqlParameter("DM_LDM_ID", Inserted.LDM_ID);
            obj[3] = new SqlParameter("DM_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("DM_LangBased", Inserted.LangBased);
            obj[5] = new SqlParameter("DM_LangBased_ID", Inserted.LangBased_ID);
            obj[6] = new SqlParameter("DM_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("DM_KyHieu", Inserted.KyHieu);
            obj[8] = new SqlParameter("DM_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("DM_Ma", Inserted.Ma);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("DM_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("DM_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("DM_NguoiSua", Inserted.NguoiSua);
            obj[14] = new SqlParameter("DM_ThuTu", Inserted.ThuTu);
            obj[15] = new SqlParameter("DM_GiaTri", Inserted.GiaTri);
            obj[16] = new SqlParameter("DM_KeyWords", Inserted.KeyWords);
            obj[17] = new SqlParameter("DM_Description", Inserted.Description);
            obj[18] = new SqlParameter("DM_RowId", Inserted.RowId);
            obj[19] = new SqlParameter("DM_Deleted", Inserted.Deleted);
            obj[20] = new SqlParameter("DM_Anh", Inserted.Anh);
            obj[21] = new SqlParameter("DM_TotalRv", Inserted.TotalRv);
            obj[22] = new SqlParameter("DM_TotalHh", Inserted.TotalHh);
            obj[23] = new SqlParameter("DM_TotalGt", Inserted.TotalGt);
            obj[24] = new SqlParameter("DM_TotalDn", Inserted.TotalDn);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Insert_InsertNormal_ductt2", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Update(DanhMuc Updated)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("DM_ID", Updated.ID);
            obj[1] = new SqlParameter("DM_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("DM_PID", Updated.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", Updated.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", Updated.Lang);
            obj[5] = new SqlParameter("DM_LangBased", Updated.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", Updated.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", Updated.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", Updated.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", Updated.Ten);
            obj[10] = new SqlParameter("DM_Ma", Updated.Ma);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("DM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("DM_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("DM_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("DM_NguoiSua", Updated.NguoiSua);
            obj[15] = new SqlParameter("DM_ThuTu", Updated.ThuTu);
            obj[16] = new SqlParameter("DM_GiaTri", Updated.GiaTri);
            obj[17] = new SqlParameter("DM_KeyWords", Updated.KeyWords);
            obj[18] = new SqlParameter("DM_Description", Updated.Description);
            obj[19] = new SqlParameter("DM_RowId", Updated.RowId);
            obj[20] = new SqlParameter("DM_Deleted", Updated.Deleted);
            obj[21] = new SqlParameter("DM_Anh", Updated.Anh);
            obj[22] = new SqlParameter("DM_TotalRv", Updated.TotalRv);
            obj[23] = new SqlParameter("DM_TotalHh", Updated.TotalHh);
            obj[24] = new SqlParameter("DM_TotalGt", Updated.TotalGt);
            obj[25] = new SqlParameter("DM_TotalDn", Updated.TotalDn);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc Update(DanhMuc Updated, SqlConnection con)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("DM_ID", Updated.ID);
            obj[1] = new SqlParameter("DM_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("DM_PID", Updated.PID);
            obj[3] = new SqlParameter("DM_LDM_ID", Updated.LDM_ID);
            obj[4] = new SqlParameter("DM_Lang", Updated.Lang);
            obj[5] = new SqlParameter("DM_LangBased", Updated.LangBased);
            obj[6] = new SqlParameter("DM_LangBased_ID", Updated.LangBased_ID);
            obj[7] = new SqlParameter("DM_Alias", Updated.Alias);
            obj[8] = new SqlParameter("DM_KyHieu", Updated.KyHieu);
            obj[9] = new SqlParameter("DM_Ten", Updated.Ten);
            obj[10] = new SqlParameter("DM_Ma", Updated.Ma);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("DM_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("DM_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("DM_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("DM_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("DM_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("DM_NguoiSua", Updated.NguoiSua);
            obj[15] = new SqlParameter("DM_ThuTu", Updated.ThuTu);
            obj[16] = new SqlParameter("DM_GiaTri", Updated.GiaTri);
            obj[17] = new SqlParameter("DM_KeyWords", Updated.KeyWords);
            obj[18] = new SqlParameter("DM_Description", Updated.Description);
            obj[19] = new SqlParameter("DM_RowId", Updated.RowId);
            obj[20] = new SqlParameter("DM_Deleted", Updated.Deleted);
            obj[21] = new SqlParameter("DM_Anh", Updated.Anh);
            obj[22] = new SqlParameter("DM_TotalRv", Updated.TotalRv);
            obj[23] = new SqlParameter("DM_TotalHh", Updated.TotalHh);
            obj[24] = new SqlParameter("DM_TotalGt", Updated.TotalGt);
            obj[25] = new SqlParameter("DM_TotalDn", Updated.TotalDn);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMuc SelectById(Int32 DM_ID)
        {
            try
            {
                DanhMuc Item = new DanhMuc();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("DM_ID", DM_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            catch (Exception excp)
            {
                return null;
            }
        }
        public static DanhMuc SelectById(Int32 DM_ID,SqlConnection con)
        {
            try
            {
                DanhMuc Item = new DanhMuc();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("DM_ID", DM_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            catch (Exception excp)
            {
                return null;
            }
        }

        public static DanhMuc SelectById(SqlConnection con, Int32 DM_ID)
        {
            try
            {
                DanhMuc Item = new DanhMuc();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("DM_ID", DM_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            catch (Exception excp)
            {
                return null;
            }
        }
        public static DanhMuc SelectToltalProduct_By_GhId(SqlConnection con, Int32 GH_ID)
        {
            try
            {
                DanhMuc Item = new DanhMuc();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("GH_ID", GH_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectToltalProduct_By_GhId_hoangda", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            catch (Exception excp)
            {
                return null;
            }
        }
        public static DanhMuc SelectToltalProduct_ByDmId(SqlConnection con, Int32 DM_ID)
        {
            try
            {
                DanhMuc Item = new DanhMuc();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("DM_ID", DM_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectToltalProduct_ByDmId_hoangda", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            catch (Exception excp)
            {
                return null;
            }
        }








        public static DanhMucCollection SelectAll()
        {
            DanhMucCollection List = new DanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DanhMuc> pagerNormal(string url, bool rewrite, string sort)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            Pager<DanhMuc> pg = new Pager<DanhMuc>("tbl_sp_tblDanhMuc_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static DanhMuc getFromReader(IDataReader rd)
        {
            DanhMuc Item = new DanhMuc();
            if (rd.FieldExists("DM_ID"))
            {
                Item.ID = (Int32)(rd["DM_ID"]);
            }
            if (rd.FieldExists("_DM_ID"))
            {
                Item._ID = (Int32)(rd["_DM_ID"]);
            }
            if (rd.FieldExists("DM_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["DM_GH_ID"]);
            }
            if (rd.FieldExists("DM_PID"))
            {
                Item.PID = (Int32)(rd["DM_PID"]);
            }
            if (rd.FieldExists("DM_LDM_ID"))
            {
                Item.LDM_ID = (Int32)(rd["DM_LDM_ID"]);
            }
            else
            {
                Item.LDM_ID = 0;
            }
            if (rd.FieldExists("DM_Lang"))
            {
                Item.Lang = (String)(rd["DM_Lang"]);
            }
            if (rd.FieldExists("DM_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["DM_LangBased"]);
            }
            if (rd.FieldExists("DM_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["DM_LangBased_ID"]);
            }
            if (rd.FieldExists("DM_Alias"))
            {
                Item.Alias = (String)(rd["DM_Alias"]);
            }
            if (rd.FieldExists("DM_KyHieu"))
            {
                Item.KyHieu = (String)(rd["DM_KyHieu"]);
            }
            if (rd.FieldExists("DM_Deleted"))
            {
                Item.Deleted = (Boolean)(rd["DM_Deleted"]);
            }
            // Item.Active = (Boolean)(rd["FN_Active"]);
            if (rd.FieldExists("DM_Ten"))
            {
                Item.Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("DM_Ma"))
            {
                Item.Ma = (String)(rd["DM_Ma"]);
            }
            if (rd.FieldExists("DM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            }
            if (rd.FieldExists("DM_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            }
            if (rd.FieldExists("DM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            }
            if (rd.FieldExists("DM_NguoiSua"))
            {
                Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            }
            if (rd.FieldExists("DM_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            }
            if (rd.FieldExists("DM_GiaTri"))
            {
                Item.GiaTri = (String)(rd["DM_GiaTri"]);
            }
            if (rd.FieldExists("DM_KeyWords"))
            {
                Item.KeyWords = (String)(rd["DM_KeyWords"]);
            }
            if (rd.FieldExists("DM_Description"))
            {
                Item.Description = (String)(rd["DM_Description"]);
            }
            if (rd.FieldExists("DM_RowId"))
            {
                Item.RowId = (Guid)(rd["DM_RowId"]);
            }
            if (rd.FieldExists("DM_Anh"))
            {
                Item.Anh = (String)(rd["DM_Anh"]);
            }
            if (rd.FieldExists("DM_TotalRv"))
            {
                Item.TotalRv = (Int32)(rd["DM_TotalRv"]);
            }
            if (rd.FieldExists("DM_TotalHh"))
            {
                Item.TotalHh = (Int32)(rd["DM_TotalHh"]);
            }
            if (rd.FieldExists("DM_TotalGt"))
            {
                Item.TotalGt = (Int32)(rd["DM_TotalGt"]);
            }
            if (rd.FieldExists("DM_TotalDn"))
            {
                Item.TotalDn = (Int32)(rd["DM_TotalDn"]);
            }
            if (rd.FieldExists("PID_Ten"))
            {
                Item.PID_Ten = (String)(rd["PID_Ten"]);
            }
            if (rd.FieldExists("DM_LDM_Ten"))
            {
                Item.LDM_Ten = (String)(rd["DM_LDM_Ten"]);
            }
            else
            {
                Item.LDM_Ten = "";
            }
            return Item;
        }
        #endregion
        #region Extend
        public static DanhMucCollection SelectAllDanhMucByTin(string TIN_ID, string LDM_ma, string Lang)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_Ma", LDM_ma);
            obj[2] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhmuc_Select_SelectAllDanhMucByTin_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection TreeChildByDmId(SqlConnection con, Int32 DM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectSubDanhMucByDmId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMuc TreeParentByDmId(SqlConnection con, string DM_ID)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_fnTreeParentByDmId_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DanhMuc SelectByLangBasedIdLang(string DM_ID, string Lang)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Select_SelectByLangBasedIdLang_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc getFromReaderSearch(IDataReader rd)
        {
            DanhMuc Item = new DanhMuc();
            Item.ID = (Int32)(rd["DM_ID"]);
            Item.LDM_ID = (Int32)(rd["DM_LDM_ID"]);
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.KyHieu = (String)(rd["DM_KyHieu"]);
            Item.Ma = (String)(rd["DM_Ma"]);
            Item.RowId = (Guid)(rd["DM_RowId"]);
            Item.NgayTao = (DateTime)(rd["DM_NgayTao"]);
            Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            Item.NgayCapNhat = (DateTime)(rd["DM_NgayCapNhat"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            return Item;
        }
        public static DanhMuc getFromReaderNoiGuiListDmGiaTri(IDataReader rd)
        {
            DanhMuc Item = new DanhMuc();
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            return Item;
        }
        public static DanhMuc getFromReaderNoiGuiDm(IDataReader rd)
        {
            DanhMuc Item = new DanhMuc();
            Item.ID = (Int32)(rd["DM_ID"]);
            Item.Ten = (String)(rd["DM_Ten"]);
            Item.KyHieu = (String)(rd["DM_KyHieu"]);
            Item.Ma = (String)(rd["DM_Ma"]);
            Item.RowId = (Guid)(rd["DM_RowId"]);
            Item.NguoiTao = (String)(rd["DM_NguoiTao"]);
            Item.GiaTri = (String)(rd["DM_GiaTri"]);
            Item.ThuTu = (Int32)(rd["DM_ThuTu"]);
            Item.NguoiSua = (String)(rd["DM_NguoiSua"]);
            return Item;
        }
        public static DanhMuc QuickSave(string Ten, string KyHieu, string LDM_Ma)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Ten", Ten);
            obj[1] = new SqlParameter("KyHieu", KyHieu);
            obj[2] = new SqlParameter("LDM_Ma", LDM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Insert_QuickSave_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMuc SelectByMa(string DM_Ma)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_hungpm", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        /// <summary>
        /// ham nay duc dung de chuyen du lieu 
        /// </summary>
        /// <param name="DM_Ma"></param>
        /// <returns></returns>
        public static DanhMuc SelectByMa(string DM_Ma, SqlConnection con)
        {
            DanhMuc Item = new DanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByMa_ductt", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static DanhMucCollection SelectByKyHieu(string KyHieu)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KyHieu", KyHieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByKyHieu_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByLoaiDanhMucKyHieu(string KyHieu)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KyHieu", KyHieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLoaiDanhMucKyHieu_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection byPid(string PID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_byPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByDM_PID(int DM_PID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_PID", DM_PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByDM_PID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByDM_Ma(string DM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByDM_Ma_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByLdmId(int LDM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLdmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SearchByLDM(string LDM_ID, string q, string Lang)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SearchByLDM_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SearchByLDM(SqlConnection con, string LDM_ID, string q, string Lang)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SearchByLDM_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SearchByLDM_DM_PID(SqlConnection con,string LDM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SearchByLDM_DM_PID_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static DanhMucCollection SearchNguoiThao(string Top, string q)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SearchNguoiThao_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection ByLdmAndPID(string LDM_ID, string PID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_ByLdmAndPID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderSearch(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection NoiGuiListDmGiaTri(string LDM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_NoiGuiListDmGiaTri_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderNoiGuiListDmGiaTri(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection NoiGuiListDm(string LDM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_NoiGuiListDm_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection NoiGuiListDmbyPid(string LDM_ID, string PID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            obj[1] = new SqlParameter("PID", PID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_NoiGuiListDmbyPid_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReaderNoiGuiDm(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SearchNodeSettingByNode(string NODE_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("NODE_ID", NODE_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SearchNodeSettingByNode_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static DanhMucCollection SelectByDmLang(string LDM_ID, string Lang)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("Lang", Lang);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByDmLang_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static DanhMucCollection SelectByDmLangActive(string LDM_ID, string Lang, int _Active)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("Lang", Lang);
            obj[2] = new SqlParameter("Active", _Active);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByDmLangActive_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByDmLangActive(SqlConnection con, string LDM_ID, string Lang, int _Active)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(LDM_ID))
            {
                obj[0] = new SqlParameter("LDM_ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            }
            obj[1] = new SqlParameter("Lang", Lang);
            obj[2] = new SqlParameter("Active", _Active);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByDmLangActive_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBasedDMCHA(SqlConnection con,string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedDMCHA_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBasedDMCHA(string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedDMCHA_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static DanhMucCollection SelectPidByMa(string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            obj[2] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectPidByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBased(string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            obj[2] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBased_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBased(SqlConnection con, string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            obj[2] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBased_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static DanhMucCollection SelectLangBasedByMa(string ID, string DM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(DM_Ma))
            {
                obj[1] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            }
            obj[2] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBasedByKTNNMa(string ID, string DM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(DM_Ma))
            {
                obj[1] = new SqlParameter("DM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            }
            obj[2] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBased_KTNN_ByMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection selectByLdmMa(string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[0] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectByLdmMa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection selectDmByLdmMaInGianHang(SqlConnection con, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[0] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectDmByLdmMaInGianHang_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectByGh_IdAndLdm_ma(Int32 GH_ID, String ldm_ma)
        {
            DanhMucCollection List = new DanhMucCollection();
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
        public static DanhMucCollection SelectLangBasedByPID(string ID, string LDM_Ma, string DM_PID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[4];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[2] = new SqlParameter("DM_PID", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("DM_PID", DM_PID);
            }
            obj[3] = new SqlParameter("Lang", "Vi-vn");
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedByPID_hiennb", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectLangBasedByDanhMucId(string ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedByDanhMucId_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        /// <summary>
        /// Hampv
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LDM_Ma"></param>
        /// <returns></returns>
        public static DanhMucCollection SelectLangBasedByMaDanhMuc(string ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("Ma", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Ma", ID);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBasedByMaDanhMuc_Hampv", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }



        public static DanhMucCollection SelectLangBasedFixHoangda(string ID, string LDM_Ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            if (string.IsNullOrEmpty(LDM_Ma))
            {
                obj[1] = new SqlParameter("LDM_Ma", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("LDM_Ma", LDM_Ma);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectLangBased_Fix_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectListDanhMucID(string ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(ID))
            {
                obj[0] = new SqlParameter("ID", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("ID", ID);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectListDanhMuc_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DanhMuc> pagerByLdmId(string sort, string q, string _DM_LDM_ID, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[3];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(_DM_LDM_ID))
            {
                obj[2] = new SqlParameter("ldm", DBNull.Value);
            }
            else
            {
                obj[2] = new SqlParameter("ldm", _DM_LDM_ID);
            }
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<DanhMuc> pg = new Pager<DanhMuc>("sp_tblDanhMuc_Pager_ByLdmId_linhnx", "page", Convert.ToInt32(pagesize), 10, false, string.Empty, obj);
            return pg;
        }
        public static void UpdateDeletedById(Int32 DM_ID, Boolean DM_Deleted)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("DM_Deleted", DM_Deleted);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Update_UpdateDeletedById_linhnx", obj);
        }
        //Select_fnTreeChildByDmId
        public static DanhMucCollection Select_fnTreeChildByDmId(SqlConnection con,int DM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_fnTreeChildByDmId_Hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectAllDanhmucByGetTin(string TIN_ID, string LDM_ma)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("LDM_Ma", LDM_ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhmuc_Select_SelectAllFunctionByTin_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectDanhMucByGhId(SqlConnection con, string GH_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GH_ID", GH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_SelectDanhMucByGhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectTreeChildByDmId(string DM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDanhMuc_Select_fnTreeChildByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DanhMucCollection SelectTreeParentByDmId(SqlConnection con, string DM_ID)
        {
            DanhMucCollection List = new DanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDanhMuc_Select_fnTreeParentByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}


