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
    #region DatHang
    #region BO
    public class DatHang : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String KH_Ten { get; set; }
        public String KH_Email { get; set; }
        public String KH_Mobile { get; set; }
        public String KH_DiaChi { get; set; }
        public Int32 KH_ID { get; set; }
        public Int32 GiaTri { get; set; }
        public Int32 PhiVanChuyen { get; set; }
        public Int32 Tong { get; set; }
        public Boolean GiaoHang { get; set; }
        public DateTime NgayGiao { get; set; }
        public Boolean Readed { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public DatHang()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DatHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DatHangCollection : BaseEntityCollection<DatHang>
    { }
    #endregion
    #region Dal
    public class DatHangDal
    {
        #region Methods

        public static void DeleteById(Int32 DH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DH_ID", DH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Delete_DeleteById_hoangda", obj);
        }

        public static DatHang Insert(DatHang Inserted)
        {
            DatHang Item = new DatHang();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("DH_KH_Ten", Inserted.KH_Ten);
            obj[1] = new SqlParameter("DH_KH_Email", Inserted.KH_Email);
            obj[2] = new SqlParameter("DH_KH_Mobile", Inserted.KH_Mobile);
            obj[3] = new SqlParameter("DH_KH_DiaChi", Inserted.KH_DiaChi);
            obj[4] = new SqlParameter("DH_KH_ID", Inserted.KH_ID);
            obj[5] = new SqlParameter("DH_GiaTri", Inserted.GiaTri);
            obj[6] = new SqlParameter("DH_PhiVanChuyen", Inserted.PhiVanChuyen);
            obj[7] = new SqlParameter("DH_Tong", Inserted.Tong);
            obj[8] = new SqlParameter("DH_GiaoHang", Inserted.GiaoHang);
            obj[9] = new SqlParameter("DH_NgayGiao", Inserted.NgayGiao);
            obj[10] = new SqlParameter("DH_Readed", Inserted.Readed);
            obj[11] = new SqlParameter("DH_NgayTao", Inserted.NgayTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHang Update(DatHang Updated)
        {
            DatHang Item = new DatHang();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("DH_ID", Updated.ID);
            obj[1] = new SqlParameter("DH_KH_Ten", Updated.KH_Ten);
            obj[2] = new SqlParameter("DH_KH_Email", Updated.KH_Email);
            obj[3] = new SqlParameter("DH_KH_Mobile", Updated.KH_Mobile);
            obj[4] = new SqlParameter("DH_KH_DiaChi", Updated.KH_DiaChi);
            obj[5] = new SqlParameter("DH_KH_ID", Updated.KH_ID);
            obj[6] = new SqlParameter("DH_GiaTri", Updated.GiaTri);
            obj[7] = new SqlParameter("DH_PhiVanChuyen", Updated.PhiVanChuyen);
            obj[8] = new SqlParameter("DH_Tong", Updated.Tong);
            obj[9] = new SqlParameter("DH_GiaoHang", Updated.GiaoHang);
            obj[10] = new SqlParameter("DH_NgayGiao", Updated.NgayGiao);
            obj[11] = new SqlParameter("DH_Readed", Updated.Readed);
            obj[12] = new SqlParameter("DH_NgayTao", Updated.NgayTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHang SelectById(Int32 DH_ID)
        {
            DatHang Item = new DatHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DH_ID", DH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHangCollection SelectAll()
        {
            DatHangCollection List = new DatHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DatHang> pagerNormalChuaGiao(string url, bool rewrite, string sort, string q, int size)
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

            Pager<DatHang> pg = new Pager<DatHang>("sp_tblDatHang_Pager_pagerNormalChuaGiao_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<DatHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<DatHang> pg = new Pager<DatHang>("sp_tblDatHang_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DatHang getFromReader(IDataReader rd)
        {
            DatHang Item = new DatHang();
            if (rd.FieldExists("DH_ID"))
            {
                Item.ID = (Int32)(rd["DH_ID"]);
            }
            if (rd.FieldExists("DH_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["DH_KH_Ten"]);
            }
            if (rd.FieldExists("DH_KH_Email"))
            {
                Item.KH_Email = (String)(rd["DH_KH_Email"]);
            }
            if (rd.FieldExists("DH_KH_Mobile"))
            {
                Item.KH_Mobile = (String)(rd["DH_KH_Mobile"]);
            }
            if (rd.FieldExists("DH_KH_DiaChi"))
            {
                Item.KH_DiaChi = (String)(rd["DH_KH_DiaChi"]);
            }
            if (rd.FieldExists("DH_KH_ID"))
            {
                Item.KH_ID = (Int32)(rd["DH_KH_ID"]);
            }
            if (rd.FieldExists("DH_GiaTri"))
            {
                Item.GiaTri = (Int32)(rd["DH_GiaTri"]);
            }
            if (rd.FieldExists("DH_PhiVanChuyen"))
            {
                Item.PhiVanChuyen = (Int32)(rd["DH_PhiVanChuyen"]);
            }
            if (rd.FieldExists("DH_Tong"))
            {
                Item.Tong = (Int32)(rd["DH_Tong"]);
            }
            if (rd.FieldExists("DH_GiaoHang"))
            {
                Item.GiaoHang = (Boolean)(rd["DH_GiaoHang"]);
            }
            if (rd.FieldExists("DH_NgayGiao"))
            {
                Item.NgayGiao = (DateTime)(rd["DH_NgayGiao"]);
            }
            if (rd.FieldExists("DH_Readed"))
            {
                Item.Readed = (Boolean)(rd["DH_Readed"]);
            }
            if (rd.FieldExists("DH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DH_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void GiaoById(Int32 DH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("ID", DH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHang_Update_GiaoById_hoangda", obj);
        }
        #endregion
    }
    #endregion

    #endregion
}


