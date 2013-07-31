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
    #region SpaKhachHang
    #region BO
    public class SpaKhachHang : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ma { get; set; }
        public String Ho { get; set; }
        public String Ten { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
        public String DiaChi { get; set; }
        public Boolean Active { get; set; }
        public Boolean Readed { get; set; }
        #endregion
        #region Contructor
        public SpaKhachHang()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaKhachHangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaKhachHangCollection : BaseEntityCollection<SpaKhachHang>
    { }
    #endregion
    #region Dal
    public class SpaKhachHangDal
    {
        #region Methods

        public static void DeleteById(Int32 KH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhachHang_Delete_DeleteById_hoangda", obj);
        }

        public static SpaKhachHang Insert(SpaKhachHang Inserted)
        {
            SpaKhachHang Item = new SpaKhachHang();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("KH_Ma", Inserted.Ma);
            obj[1] = new SqlParameter("KH_Ho", Inserted.Ho);
            obj[2] = new SqlParameter("KH_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("KH_Email", Inserted.Email);
            obj[4] = new SqlParameter("KH_Mobile", Inserted.Mobile);
            obj[5] = new SqlParameter("KH_DiaChi", Inserted.DiaChi);
            obj[6] = new SqlParameter("KH_Active", Inserted.Active);
            obj[7] = new SqlParameter("KH_Readed", Inserted.Readed);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhachHang_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhachHang Update(SpaKhachHang Updated)
        {
            SpaKhachHang Item = new SpaKhachHang();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("KH_ID", Updated.ID);
            obj[1] = new SqlParameter("KH_Ma", Updated.Ma);
            obj[2] = new SqlParameter("KH_Ho", Updated.Ho);
            obj[3] = new SqlParameter("KH_Ten", Updated.Ten);
            obj[4] = new SqlParameter("KH_Email", Updated.Email);
            obj[5] = new SqlParameter("KH_Mobile", Updated.Mobile);
            obj[6] = new SqlParameter("KH_DiaChi", Updated.DiaChi);
            obj[7] = new SqlParameter("KH_Active", Updated.Active);
            obj[8] = new SqlParameter("KH_Readed", Updated.Readed);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhachHang_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhachHang SelectById(Int32 KH_ID)
        {
            SpaKhachHang Item = new SpaKhachHang();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("KH_ID", KH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhachHang_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaKhachHangCollection SelectAll()
        {
            SpaKhachHangCollection List = new SpaKhachHangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaKhachHang_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaKhachHang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<SpaKhachHang> pg = new Pager<SpaKhachHang>("sp_tblSpaKhachHang_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SpaKhachHang getFromReader(IDataReader rd)
        {
            SpaKhachHang Item = new SpaKhachHang();
            if (rd.FieldExists("KH_ID"))
            {
                Item.ID = (Int32)(rd["KH_ID"]);
            }
            if (rd.FieldExists("KH_Ma"))
            {
                Item.Ma = (String)(rd["KH_Ma"]);
            }
            if (rd.FieldExists("KH_Ho"))
            {
                Item.Ho = (String)(rd["KH_Ho"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.Ten = (String)(rd["KH_Ten"]);
            }
            if (rd.FieldExists("KH_Email"))
            {
                Item.Email = (String)(rd["KH_Email"]);
            }
            if (rd.FieldExists("KH_Mobile"))
            {
                Item.Mobile = (String)(rd["KH_Mobile"]);
            }
            if (rd.FieldExists("KH_DiaChi"))
            {
                Item.DiaChi = (String)(rd["KH_DiaChi"]);
            }
            if (rd.FieldExists("KH_Active"))
            {
                Item.Active = (Boolean)(rd["KH_Active"]);
            }
            if (rd.FieldExists("KH_Readed"))
            {
                Item.Readed = (Boolean)(rd["KH_Readed"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<SpaKhachHang> pagerByDichVu(string sort, string q, int size)
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
            Pager<SpaKhachHang> pg = new Pager<SpaKhachHang>("sp_tblSpaKhachHang_Pager_pagerByDichVu_hoangda", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
