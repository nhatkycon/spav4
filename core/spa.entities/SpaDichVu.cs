using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using linh.core.dal;
using linh.controls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using linh.common;
using docsoft.entities;
namespace spa.entitites
{
    #region SpaDichVu
    #region BO
    public class SpaDichVu : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 SPA_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public Int32 Gia { get; set; }
        public Boolean KM { get; set; }
        public Int32 GiaKm { get; set; }
        public Boolean NgayBatDau { get; set; }
        public Boolean NgayKetThuc { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String DonVi { get; set; }
        public Boolean Hot { get; set; }
        #endregion
        #region Contructor
        public SpaDichVu()
        { }
        #endregion
        #region Customs properties
        public Spa _Spa { get; set; }
        public DanhMuc _DanhMuc { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaDichVuCollection : BaseEntityCollection<SpaDichVu>
    { }
    #endregion
    #region Dal
    public class SpaDichVuDal
    {
        #region Methods

        public static void DeleteById(Int32 DV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDichVu_Delete_DeleteById_hoangda", obj);
        }

        public static SpaDichVu Insert(SpaDichVu Inserted)
        {
            SpaDichVu Item = new SpaDichVu();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("DV_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("DV_SPA_ID", Inserted.SPA_ID);
            obj[2] = new SqlParameter("DV_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("DV_MoTa", Inserted.MoTa);
            obj[4] = new SqlParameter("DV_NoiDung", Inserted.NoiDung);
            obj[5] = new SqlParameter("DV_Gia", Inserted.Gia);
            obj[6] = new SqlParameter("DV_KM", Inserted.KM);
            obj[7] = new SqlParameter("DV_GiaKm", Inserted.GiaKm);
            obj[8] = new SqlParameter("DV_NgayBatDau", Inserted.NgayBatDau);
            obj[9] = new SqlParameter("DV_NgayKetThuc", Inserted.NgayKetThuc);
            obj[10] = new SqlParameter("DV_NgayTao", Inserted.NgayTao);
            obj[11] = new SqlParameter("DV_NgayCapNhat", Inserted.NgayCapNhat);
            obj[12] = new SqlParameter("DV_DonVi", Inserted.DonVi);
            obj[13] = new SqlParameter("DV_Hot", Inserted.Hot);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDichVu_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaDichVu Update(SpaDichVu Updated)
        {
            SpaDichVu Item = new SpaDichVu();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("DV_ID", Updated.ID);
            obj[1] = new SqlParameter("DV_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("DV_SPA_ID", Updated.SPA_ID);
            obj[3] = new SqlParameter("DV_Ten", Updated.Ten);
            obj[4] = new SqlParameter("DV_MoTa", Updated.MoTa);
            obj[5] = new SqlParameter("DV_NoiDung", Updated.NoiDung);
            obj[6] = new SqlParameter("DV_Gia", Updated.Gia);
            obj[7] = new SqlParameter("DV_KM", Updated.KM);
            obj[8] = new SqlParameter("DV_GiaKm", Updated.GiaKm);
            obj[9] = new SqlParameter("DV_NgayBatDau", Updated.NgayBatDau);
            obj[10] = new SqlParameter("DV_NgayKetThuc", Updated.NgayKetThuc);
            obj[11] = new SqlParameter("DV_NgayTao", Updated.NgayTao);
            obj[12] = new SqlParameter("DV_NgayCapNhat", Updated.NgayCapNhat);
            obj[13] = new SqlParameter("DV_DonVi", Updated.DonVi);
            obj[14] = new SqlParameter("DV_Hot", Updated.Hot);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDichVu_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaDichVu SelectById(Int32 DV_ID)
        {
            SpaDichVu Item = new SpaDichVu();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DV_ID", DV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDichVu_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaDichVuCollection SelectAll()
        {
            SpaDichVuCollection List = new SpaDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDichVu_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<SpaDichVu> pg = new Pager<SpaDichVu>("sp_tblSpaDichVu_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SpaDichVu getFromReader(IDataReader rd)
        {
            SpaDichVu Item = new SpaDichVu();
            if (rd.FieldExists("DV_ID"))
            {
                Item.ID = (Int32)(rd["DV_ID"]);
            }
            if (rd.FieldExists("DV_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["DV_DM_ID"]);
            }
            if (rd.FieldExists("DV_SPA_ID"))
            {
                Item.SPA_ID = (Int32)(rd["DV_SPA_ID"]);
            }
            if (rd.FieldExists("DV_Ten"))
            {
                Item.Ten = (String)(rd["DV_Ten"]);
            }
            if (rd.FieldExists("DV_MoTa"))
            {
                Item.MoTa = (String)(rd["DV_MoTa"]);
            }
            if (rd.FieldExists("DV_NoiDung"))
            {
                Item.NoiDung = (String)(rd["DV_NoiDung"]);
            }
            if (rd.FieldExists("DV_Gia"))
            {
                Item.Gia = (Int32)(rd["DV_Gia"]);
            }
            if (rd.FieldExists("DV_KM"))
            {
                Item.KM = (Boolean)(rd["DV_KM"]);
            }
            if (rd.FieldExists("DV_GiaKm"))
            {
                Item.GiaKm = (Int32)(rd["DV_GiaKm"]);
            }
            if (rd.FieldExists("DV_NgayBatDau"))
            {
                Item.NgayBatDau = (Boolean)(rd["DV_NgayBatDau"]);
            }
            if (rd.FieldExists("DV_NgayKetThuc"))
            {
                Item.NgayKetThuc = (Boolean)(rd["DV_NgayKetThuc"]);
            }
            if (rd.FieldExists("DV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DV_NgayTao"]);
            }
            if (rd.FieldExists("DV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["DV_NgayCapNhat"]);
            }
            if (rd.FieldExists("DV_DonVi"))
            {
                Item.DonVi = (String)(rd["DV_DonVi"]);
            }
            if (rd.FieldExists("DV_Hot"))
            {
                Item.Hot = (Boolean)(rd["DV_Hot"]);
            }
            Spa _spa = new Spa();
            _spa = SpaDal.getFromReader(rd);
            DanhMuc _danhMuc = new DanhMuc();
            _danhMuc = DanhMucDal.getFromReader(rd);
            Item._Spa = _spa;
            Item._DanhMuc = _danhMuc;
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<SpaDichVu> pagerByDichVu(string sort, string q, string _dm_id, string _spa_id, int size)
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
            if (!string.IsNullOrEmpty(_dm_id))
            {
                obj[2] = new SqlParameter("dm_id", _dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_spa_id))
            {
                obj[3] = new SqlParameter("spa_id", _spa_id);
            }
            else
            {
                obj[3] = new SqlParameter("spa_id", DBNull.Value);
            }
            Pager<SpaDichVu> pg = new Pager<SpaDichVu>("sp_tblSpaDichVu_Pager_pagerByDichVu_hoangda", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<SpaDichVu> pagerByDichVu(SqlConnection con, string sort, string q, string _dm_id, string _spa_id, int size, string cUrl)
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
            if (!string.IsNullOrEmpty(_dm_id))
            {
                obj[2] = new SqlParameter("dm_id", _dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_spa_id))
            {
                obj[3] = new SqlParameter("spa_id", _spa_id);
            }
            else
            {
                obj[3] = new SqlParameter("spa_id", DBNull.Value);
            }
            Pager<SpaDichVu> pg = new Pager<SpaDichVu>(con, "sp_tblSpaDichVu_Pager_pagerByDichVu_hoangda", "pages", size, 10, false, cUrl, obj);
            return pg;
        }
        public static Pager<SpaDichVu> pagerByDichVuKhuVuc(SqlConnection con, string sort, string q, string _dm_id, string _spa_id, string _kv_id, int size, string cUrl)
        {
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_dm_id))
            {
                obj[2] = new SqlParameter("dm_id", _dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_spa_id))
            {
                obj[3] = new SqlParameter("spa_id", _spa_id);
            }
            else
            {
                obj[3] = new SqlParameter("spa_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_kv_id))
            {
                obj[4] = new SqlParameter("kv_id", _kv_id);
            }
            else
            {
                obj[4] = new SqlParameter("kv_id", DBNull.Value);
            }
            var pg = new Pager<SpaDichVu>(con, "sp_tblSpaDichVu_Pager_pagerByDichVuKhuVuc_hoangda", "pages", size, 10, false, cUrl, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
