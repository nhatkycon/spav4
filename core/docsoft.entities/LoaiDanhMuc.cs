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
    #region LoaiDanhMuc
    #region BO
    public class LoaiDanhMuc : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String KyHieu { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 ThuTu { get; set; }
        public String NguoiSua { get; set; }
        #endregion
        #region Contructor
        public LoaiDanhMuc()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return LoaiDanhMucDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class LoaiDanhMucCollection : BaseEntityCollection<LoaiDanhMuc>
    { }
    #endregion
    #region Dal
    public class LoaiDanhMucDal
    {
        #region Methods

        public static void DeleteById(Int32 LDM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Delete_DeleteById_linhnx", obj);
        }

        public static LoaiDanhMuc Insert(LoaiDanhMuc Inserted)
        {
            LoaiDanhMuc Item = new LoaiDanhMuc();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("LDM_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("LDM_Ma", Inserted.Ma);
            obj[2] = new SqlParameter("LDM_KyHieu", Inserted.KyHieu);
            obj[3] = new SqlParameter("LDM_RowId", Inserted.RowId);
            obj[4] = new SqlParameter("LDM_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("LDM_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("LDM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[7] = new SqlParameter("LDM_ThuTu", Inserted.ThuTu);
            obj[8] = new SqlParameter("LDM_NguoiSua", Inserted.NguoiSua);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMuc Update(LoaiDanhMuc Updated)
        {
            LoaiDanhMuc Item = new LoaiDanhMuc();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("LDM_ID", Updated.ID);
            obj[1] = new SqlParameter("LDM_Ten", Updated.Ten);
            obj[2] = new SqlParameter("LDM_Ma", Updated.Ma);
            obj[3] = new SqlParameter("LDM_KyHieu", Updated.KyHieu);
            obj[4] = new SqlParameter("LDM_RowId", Updated.RowId);
            obj[5] = new SqlParameter("LDM_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("LDM_NguoiTao", Updated.NguoiTao);
            obj[7] = new SqlParameter("LDM_NgayCapNhat", Updated.NgayCapNhat);
            obj[8] = new SqlParameter("LDM_ThuTu", Updated.ThuTu);
            obj[9] = new SqlParameter("LDM_NguoiSua", Updated.NguoiSua);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMuc SelectById(Int32 LDM_ID)
        {
            LoaiDanhMuc Item = new LoaiDanhMuc();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LDM_ID", LDM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static LoaiDanhMucCollection SelectAll()
        {
            LoaiDanhMucCollection List = new LoaiDanhMucCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static Pager<LoaiDanhMuc> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (string.IsNullOrEmpty(pagesize)) pagesize = "20";
            Pager<LoaiDanhMuc> pg = new Pager<LoaiDanhMuc>("sp_tblLoaiDanhMuc_Pager_Normal_linhnx", "page", Convert.ToInt32(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        public static LoaiDanhMucCollection SelectTree(string q)
        {
            LoaiDanhMucCollection List = new LoaiDanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("q", q);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectTree_hungpm", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion

        #region Utilities
        public static LoaiDanhMuc getFromReader(IDataReader rd)
        {
            LoaiDanhMuc Item = new LoaiDanhMuc();
            Item.ID = (Int32)(rd["LDM_ID"]);
            Item.Ten = (String)(rd["LDM_Ten"]);
            Item.Ma = (String)(rd["LDM_Ma"]);
            Item.KyHieu = (String)(rd["LDM_KyHieu"]);
            Item.RowId = (Guid)(rd["LDM_RowId"]);
            Item.NgayTao = (DateTime)(rd["LDM_NgayTao"]);
            Item.NguoiTao = (String)(rd["LDM_NguoiTao"]);
            Item.NgayCapNhat = (DateTime)(rd["LDM_NgayCapNhat"]);
            Item.ThuTu = (Int32)(rd["LDM_ThuTu"]);
            Item.NguoiSua = (String)(rd["LDM_NguoiSua"]);
            return Item;
        }
        #endregion
        #region extend
        public static LoaiDanhMucCollection SelectByKyHieu(string KyHieu)
        {
            LoaiDanhMucCollection List = new LoaiDanhMucCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KyHieu", KyHieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblLoaiDanhMuc_Select_SelectByKyHieu_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void UpdateDeletedById(Int32 DM_ID, Boolean DM_Deleted)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("DM_Deleted", DM_Deleted);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblDanhMuc_Update_UpdateDeletedById_linhnx", obj);
        }
        #endregion
    }
    #endregion

    #endregion
}


