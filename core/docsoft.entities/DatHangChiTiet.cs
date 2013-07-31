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
    #region DatHangChiTiet
    #region BO
    public class DatHangChiTiet : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DH_ID { get; set; }
        public Int32 HH_ID { get; set; }
        public String HH_Ten { get; set; }
        public Int32 HH_SoLuong { get; set; }
        public Int32 HH_Gia { get; set; }
        public Int32 HH_Tong { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public DatHangChiTiet()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DatHangChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DatHangChiTietCollection : BaseEntityCollection<DatHangChiTiet>
    { }
    #endregion
    #region Dal
    public class DatHangChiTietDal
    {
        #region Methods

        public static void DeleteById(Int32 DHCT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DHCT_ID", DHCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Delete_DeleteById_hoangda", obj);
        }

        public static DatHangChiTiet Insert(DatHangChiTiet Inserted)
        {
            DatHangChiTiet Item = new DatHangChiTiet();
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("DHCT_DH_ID", Inserted.DH_ID);
            obj[1] = new SqlParameter("DHCT_HH_ID", Inserted.HH_ID);
            obj[2] = new SqlParameter("DHCT_HH_Ten", Inserted.HH_Ten);
            obj[3] = new SqlParameter("DHCT_HH_SoLuong", Inserted.HH_SoLuong);
            obj[4] = new SqlParameter("DHCT_HH_Gia", Inserted.HH_Gia);
            obj[5] = new SqlParameter("DHCT_HH_Tong", Inserted.HH_Tong);
            obj[6] = new SqlParameter("DHCT_NgayTao", Inserted.NgayTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHangChiTiet Update(DatHangChiTiet Updated)
        {
            DatHangChiTiet Item = new DatHangChiTiet();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("DHCT_ID", Updated.ID);
            obj[1] = new SqlParameter("DHCT_DH_ID", Updated.DH_ID);
            obj[2] = new SqlParameter("DHCT_HH_ID", Updated.HH_ID);
            obj[3] = new SqlParameter("DHCT_HH_Ten", Updated.HH_Ten);
            obj[4] = new SqlParameter("DHCT_HH_SoLuong", Updated.HH_SoLuong);
            obj[5] = new SqlParameter("DHCT_HH_Gia", Updated.HH_Gia);
            obj[6] = new SqlParameter("DHCT_HH_Tong", Updated.HH_Tong);
            obj[7] = new SqlParameter("DHCT_NgayTao", Updated.NgayTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHangChiTiet SelectById(Int32 DHCT_ID)
        {
            DatHangChiTiet Item = new DatHangChiTiet();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DHCT_ID", DHCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DatHangChiTietCollection SelectAll()
        {
            DatHangChiTietCollection List = new DatHangChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DatHangChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<DatHangChiTiet> pg = new Pager<DatHangChiTiet>("sp_tblDatHangChiTiet_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DatHangChiTiet getFromReader(IDataReader rd)
        {
            DatHangChiTiet Item = new DatHangChiTiet();
            if (rd.FieldExists("DHCT_ID"))
            {
                Item.ID = (Int32)(rd["DHCT_ID"]);
            }
            if (rd.FieldExists("DHCT_DH_ID"))
            {
                Item.DH_ID = (Int32)(rd["DHCT_DH_ID"]);
            }
            if (rd.FieldExists("DHCT_HH_ID"))
            {
                Item.HH_ID = (Int32)(rd["DHCT_HH_ID"]);
            }
            if (rd.FieldExists("DHCT_HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["DHCT_HH_Ten"]);
            }
            if (rd.FieldExists("DHCT_HH_SoLuong"))
            {
                Item.HH_SoLuong = (Int32)(rd["DHCT_HH_SoLuong"]);
            }
            if (rd.FieldExists("DHCT_HH_Gia"))
            {
                Item.HH_Gia = (Int32)(rd["DHCT_HH_Gia"]);
            }
            if (rd.FieldExists("DHCT_HH_Tong"))
            {
                Item.HH_Tong = (Int32)(rd["DHCT_HH_Tong"]);
            }
            if (rd.FieldExists("DHCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DHCT_NgayTao"]);
            }
            return Item;
        }

        #endregion

        #region Extend
        public static DatHangChiTietCollection SelectByDhId(string dh_id)
        {
            DatHangChiTietCollection List = new DatHangChiTietCollection();
            SqlParameter[] obj = new SqlParameter[] { 
            new SqlParameter("dh_id",dh_id)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDatHangChiTiet_Select_SelectByDhId_hoangda", obj))
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


