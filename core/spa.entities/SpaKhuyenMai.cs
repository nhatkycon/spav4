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
namespace spa.entitites
{
    #region SpaKhuyenMai
    #region BO
    public class SpaKhuyenMai : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 SPA_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Int32 GiaKhuyenMai { get; set; }
        public Int32 TyLeKhuyenMai { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Active { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Hot { get; set; }
        public Int32 GiaThiTruong { get; set; }
        public Int32 SoLuongMua { get; set; }
        public Int32 GiaThuVe { get; set; }
        #endregion
        #region Contructor
        public SpaKhuyenMai()
        { }
        #endregion
        #region Customs properties
        public Spa _Spa { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaKhuyenMaiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaKhuyenMaiCollection : BaseEntityCollection<SpaKhuyenMai>
    { }
    #endregion
    #region Dal
    public class SpaKhuyenMaiDal
    {
        #region Methods

        public static void DeleteById(Int32 KM_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KM_ID", KM_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Delete_DeleteById_hoangda", obj);
        }

        public static SpaKhuyenMai Insert(SpaKhuyenMai Inserted)
        {
            SpaKhuyenMai Item = new SpaKhuyenMai();
            SqlParameter[] obj = new SqlParameter[14];
            obj[0] = new SqlParameter("KM_SPA_ID", Inserted.SPA_ID);
            obj[1] = new SqlParameter("KM_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("KM_MoTa", Inserted.MoTa);
            if (Inserted.NgayBatDau != DateTime.MinValue)
            {
                obj[3] = new SqlParameter("KM_NgayBatDau", Inserted.NgayBatDau);
            }
            else
            {
                obj[3] = new SqlParameter("KM_NgayBatDau", DBNull.Value);
            }
            if (Inserted.NgayKetThuc != DateTime.MinValue)
            {
                obj[4] = new SqlParameter("KM_NgayKetThuc", Inserted.NgayKetThuc);
            }
            else
            {
                obj[4] = new SqlParameter("KM_NgayKetThuc", DBNull.Value);
            }
            obj[5] = new SqlParameter("KM_GiaKhuyenMai", Inserted.GiaKhuyenMai);
            obj[6] = new SqlParameter("KM_TyLeKhuyenMai", Inserted.TyLeKhuyenMai);
            obj[7] = new SqlParameter("KM_NgayCapNhat", Inserted.NgayCapNhat);
            obj[8] = new SqlParameter("KM_Active", Inserted.Active);
            obj[9] = new SqlParameter("KM_NgayTao", Inserted.NgayTao);
            obj[10] = new SqlParameter("KM_Hot", Inserted.Hot);
            obj[11] = new SqlParameter("KM_GiaThiTruong", Inserted.GiaThiTruong);
            obj[12] = new SqlParameter("KM_SoLuongMua", Inserted.SoLuongMua);
            obj[13] = new SqlParameter("KM_GiaThuVe", Inserted.GiaThuVe);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhuyenMai Update(SpaKhuyenMai Updated)
        {
            SpaKhuyenMai Item = new SpaKhuyenMai();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("KM_ID", Updated.ID);
            obj[1] = new SqlParameter("KM_SPA_ID", Updated.SPA_ID);
            obj[2] = new SqlParameter("KM_Ten", Updated.Ten);
            obj[3] = new SqlParameter("KM_MoTa", Updated.MoTa);
            if (Updated.NgayBatDau != DateTime.MinValue)
            {
                obj[4] = new SqlParameter("KM_NgayBatDau", Updated.NgayBatDau);
            }
            else
            {
                obj[4] = new SqlParameter("KM_NgayBatDau", DBNull.Value);
            }
            if (Updated.NgayKetThuc != DateTime.MinValue)
            {
                obj[5] = new SqlParameter("KM_NgayKetThuc", Updated.NgayKetThuc);
            }
            else
            {
                obj[5] = new SqlParameter("KM_NgayKetThuc", DBNull.Value);
            }
            obj[6] = new SqlParameter("KM_GiaKhuyenMai", Updated.GiaKhuyenMai);
            obj[7] = new SqlParameter("KM_TyLeKhuyenMai", Updated.TyLeKhuyenMai);
            obj[8] = new SqlParameter("KM_NgayCapNhat", Updated.NgayCapNhat);
            obj[9] = new SqlParameter("KM_Active", Updated.Active);
            obj[10] = new SqlParameter("KM_NgayTao", Updated.NgayTao);
            obj[14] = new SqlParameter("KM_Hot", Updated.Hot);
            obj[11] = new SqlParameter("KM_GiaThiTruong", Updated.GiaThiTruong);
            obj[12] = new SqlParameter("KM_SoLuongMua", Updated.SoLuongMua);
            obj[13] = new SqlParameter("KM_GiaThuVe", Updated.GiaThuVe);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhuyenMai SelectById(Int32 KM_ID)
        {
            SpaKhuyenMai Item = new SpaKhuyenMai();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KM_ID", KM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhuyenMaiCollection SelectAll()
        {
            SpaKhuyenMaiCollection List = new SpaKhuyenMaiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaKhuyenMai> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<SpaKhuyenMai> pg = new Pager<SpaKhuyenMai>("sp_tblSpaKhuyenMai_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SpaKhuyenMai getFromReader(IDataReader rd)
        {
            SpaKhuyenMai Item = new SpaKhuyenMai();
            if (rd.FieldExists("KM_ID"))
            {
                Item.ID = (Int32)(rd["KM_ID"]);
            }
            if (rd.FieldExists("KM_SPA_ID"))
            {
                Item.SPA_ID = (Int32)(rd["KM_SPA_ID"]);
            }
            if (rd.FieldExists("KM_Ten"))
            {
                Item.Ten = (String)(rd["KM_Ten"]);
            }
            if (rd.FieldExists("KM_MoTa"))
            {
                Item.MoTa = (String)(rd["KM_MoTa"]);
            }
            if (rd.FieldExists("KM_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["KM_NgayBatDau"]);
            }
            if (rd.FieldExists("KM_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["KM_NgayKetThuc"]);
            }
            if (rd.FieldExists("KM_GiaKhuyenMai"))
            {
                Item.GiaKhuyenMai = (Int32)(rd["KM_GiaKhuyenMai"]);
            }
            if (rd.FieldExists("KM_TyLeKhuyenMai"))
            {
                Item.TyLeKhuyenMai = (Int32)(rd["KM_TyLeKhuyenMai"]);
            }
            if (rd.FieldExists("KM_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["KM_NgayCapNhat"]);
            }
            if (rd.FieldExists("KM_Active"))
            {
                Item.Active = (Boolean)(rd["KM_Active"]);
            }
            if (rd.FieldExists("KM_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["KM_NgayTao"]);
            }
            if (rd.FieldExists("KM_Hot"))
            {
                Item.Hot = (Boolean)(rd["KM_Hot"]);
            }
            if (rd.FieldExists("KM_GiaThiTruong"))
            {
                Item.GiaThiTruong = (Int32)(rd["KM_GiaThiTruong"]);
            }
            if (rd.FieldExists("KM_SoLuongMua"))
            {
                Item.SoLuongMua = (Int32)(rd["KM_SoLuongMua"]);
            }
            if (rd.FieldExists("KM_GiaThuVe"))
            {
                Item.GiaThuVe = (Int32)(rd["KM_GiaThuVe"]);
            }
            Spa _spa = new Spa();
            _spa = SpaDal.getFromReader(rd);
            Item._Spa = _spa;
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<SpaKhuyenMai> pagerSpa(string sort, string q, string _spa_id, int size)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_spa_id))
            {
                obj[2] = new SqlParameter("spa_id", _spa_id);
            }
            else
            {
                obj[2] = new SqlParameter("spa_id", DBNull.Value);
            }
            var pg = new Pager<SpaKhuyenMai>("sp_tblSpaKhuyenMai_Pager_pagerSpa_hoangda", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static Pager<SpaKhuyenMai> pagerSpa(string sort, string q, string _spa_id, int size, string cUrl)
        {
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_spa_id))
            {
                obj[2] = new SqlParameter("spa_id", _spa_id);
            }
            else
            {
                obj[2] = new SqlParameter("spa_id", DBNull.Value);
            }
            var pg = new Pager<SpaKhuyenMai>("sp_tblSpaKhuyenMai_Pager_pagerSpa_hoangda", "page", size, 10, false, cUrl, obj);
            return pg;
        }
        public static SpaKhuyenMaiCollection SelectTop(int Top)
        {
            SpaKhuyenMaiCollection List = new SpaKhuyenMaiCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top", Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Select_SelectTop_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaKhuyenMaiCollection SelectTop(SqlConnection con, int Top)
        {
            SpaKhuyenMaiCollection List = new SpaKhuyenMaiCollection();
            SqlParameter[] obj = new SqlParameter[]{
                new SqlParameter("Top", Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaKhuyenMai_Select_SelectTop_hoangda", obj))
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
