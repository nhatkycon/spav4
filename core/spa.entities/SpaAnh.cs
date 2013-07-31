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
    #region SpaAnh
    #region BO
    public class SpaAnh : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 SPA_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String Anh { get; set; }
        public Int32 ThuTu { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public SpaAnh()
        { }
        #endregion
        #region Customs properties

        public string SPA_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaAnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaAnhCollection : BaseEntityCollection<SpaAnh>
    { }
    #endregion
    #region Dal
    public class SpaAnhDal
    {
        #region Methods

        public static void DeleteById(Guid SPAHA_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SPAHA_ID", SPAHA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaAnh_Delete_DeleteById_linhnx", obj);
        }

        public static SpaAnh Insert(SpaAnh item)
        {
            var Item = new SpaAnh();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("SPAHA_ID", item.ID);
            obj[1] = new SqlParameter("SPAHA_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("SPAHA_Ten", item.Ten);
            obj[3] = new SqlParameter("SPAHA_MoTa", item.MoTa);
            obj[4] = new SqlParameter("SPAHA_Anh", item.Anh);
            obj[5] = new SqlParameter("SPAHA_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("SPAHA_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("SPAHA_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("SPAHA_NguoiTao", item.NguoiTao);
            obj[8] = new SqlParameter("SPAHA_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaAnh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaAnh Update(SpaAnh item)
        {
            var Item = new SpaAnh();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("SPAHA_ID", item.ID);
            obj[1] = new SqlParameter("SPAHA_SPA_ID", item.SPA_ID);
            obj[2] = new SqlParameter("SPAHA_Ten", item.Ten);
            obj[3] = new SqlParameter("SPAHA_MoTa", item.MoTa);
            obj[4] = new SqlParameter("SPAHA_Anh", item.Anh);
            obj[5] = new SqlParameter("SPAHA_ThuTu", item.ThuTu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("SPAHA_NgayTao", item.NgayTao);
            }
            else
            {
                obj[6] = new SqlParameter("SPAHA_NgayTao", DBNull.Value);
            }
            obj[7] = new SqlParameter("SPAHA_NguoiTao", item.NguoiTao);
            obj[8] = new SqlParameter("SPAHA_Active", item.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaAnh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaAnh SelectById(Guid SPAHA_ID)
        {
            var Item = new SpaAnh();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SPAHA_ID", SPAHA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaAnh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaAnhCollection SelectAll()
        {
            var List = new SpaAnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaAnh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaAnh> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<SpaAnh>("sp_tblSpaAnh_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SpaAnh getFromReader(IDataReader rd)
        {
            var Item = new SpaAnh();
            if (rd.FieldExists("SPAHA_ID"))
            {
                Item.ID = (Guid)(rd["SPAHA_ID"]);
            }
            if (rd.FieldExists("SPAHA_SPA_ID"))
            {
                Item.SPA_ID = (Int32)(rd["SPAHA_SPA_ID"]);
            }
            if (rd.FieldExists("SPAHA_Ten"))
            {
                Item.Ten = (String)(rd["SPAHA_Ten"]);
            }
            if (rd.FieldExists("SPAHA_MoTa"))
            {
                Item.MoTa = (String)(rd["SPAHA_MoTa"]);
            }
            if (rd.FieldExists("SPAHA_Anh"))
            {
                Item.Anh = (String)(rd["SPAHA_Anh"]);
            }
            if (rd.FieldExists("SPAHA_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["SPAHA_ThuTu"]);
            }
            if (rd.FieldExists("SPAHA_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SPAHA_NgayTao"]);
            }
            if (rd.FieldExists("SPAHA_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["SPAHA_NguoiTao"]);
            }
            if (rd.FieldExists("SPAHA_Active"))
            {
                Item.Active = (Boolean)(rd["SPAHA_Active"]);
            }
            if (rd.FieldExists("SPA_Ten"))
            {
                Item.SPA_Ten = (String)(rd["SPA_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<SpaAnh> pagerBySpa(string url, bool rewrite, string sort, string SPA_ID, int size)
        {
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(SPA_ID))
            {
                obj[0] = new SqlParameter("SPA_ID", SPA_ID);
            }
            else
            {
                obj[0] = new SqlParameter("SPA_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[1] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[1] = new SqlParameter("Sort", DBNull.Value);
            }

            var pg = new Pager<SpaAnh>("sp_tblSpaAnh_PagerBySpa_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion

    #endregion
}
