using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;

namespace docsoft.entities
{
    #region PhieuQuaTang
    #region BO
    public class PhieuQuaTang : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public Guid QT_ID { get; set; }
        public String Username { get; set; }
        public DateTime NgayNhan { get; set; }
        public Boolean DaDung { get; set; }
        public Boolean NgayDung { get; set; }
        public Boolean Active { get; set; }
        public DateTime NgayTao { get; set; }
        #endregion
        #region Contructor
        public PhieuQuaTang()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuQuaTangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuQuaTangCollection : BaseEntityCollection<PhieuQuaTang>
    { }
    #endregion
    #region Dal
    public class PhieuQuaTangDal
    {
        #region Methods

        public static void DeleteById(Guid PQT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PQT_ID", PQT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblPhieuQuaTang_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuQuaTang Insert(PhieuQuaTang item)
        {
            var Item = new PhieuQuaTang();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("PQT_ID", item.ID);
            obj[1] = new SqlParameter("PQT_Ma", item.Ma);
            obj[2] = new SqlParameter("PQT_QT_ID", item.QT_ID);
            obj[3] = new SqlParameter("PQT_Username", item.Username);
            if (item.NgayNhan > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PQT_NgayNhan", item.NgayNhan);
            }
            else
            {
                obj[4] = new SqlParameter("PQT_NgayNhan", DBNull.Value);
            }
            obj[5] = new SqlParameter("PQT_DaDung", item.DaDung);
            obj[6] = new SqlParameter("PQT_NgayDung", item.NgayDung);
            obj[7] = new SqlParameter("PQT_Active", item.Active);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PQT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("PQT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhieuQuaTang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuQuaTang Update(PhieuQuaTang item)
        {
            var Item = new PhieuQuaTang();
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("PQT_ID", item.ID);
            obj[1] = new SqlParameter("PQT_Ma", item.Ma);
            obj[2] = new SqlParameter("PQT_QT_ID", item.QT_ID);
            obj[3] = new SqlParameter("PQT_Username", item.Username);
            if (item.NgayNhan > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PQT_NgayNhan", item.NgayNhan);
            }
            else
            {
                obj[4] = new SqlParameter("PQT_NgayNhan", DBNull.Value);
            }
            obj[5] = new SqlParameter("PQT_DaDung", item.DaDung);
            obj[6] = new SqlParameter("PQT_NgayDung", item.NgayDung);
            obj[7] = new SqlParameter("PQT_Active", item.Active);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PQT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("PQT_NgayTao", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhieuQuaTang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuQuaTang SelectById(Guid PQT_ID)
        {
            var Item = new PhieuQuaTang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PQT_ID", PQT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhieuQuaTang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuQuaTangCollection SelectAll()
        {
            var List = new PhieuQuaTangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblPhieuQuaTang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuQuaTang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<PhieuQuaTang>("sp_tblPhieuQuaTang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuQuaTang getFromReader(IDataReader rd)
        {
            var Item = new PhieuQuaTang();
            if (rd.FieldExists("PQT_ID"))
            {
                Item.ID = (Guid)(rd["PQT_ID"]);
            }
            if (rd.FieldExists("PQT_Ma"))
            {
                Item.Ma = (String)(rd["PQT_Ma"]);
            }
            if (rd.FieldExists("PQT_QT_ID"))
            {
                Item.QT_ID = (Guid)(rd["PQT_QT_ID"]);
            }
            if (rd.FieldExists("PQT_Username"))
            {
                Item.Username = (String)(rd["PQT_Username"]);
            }
            if (rd.FieldExists("PQT_NgayNhan"))
            {
                Item.NgayNhan = (DateTime)(rd["PQT_NgayNhan"]);
            }
            if (rd.FieldExists("PQT_DaDung"))
            {
                Item.DaDung = (Boolean)(rd["PQT_DaDung"]);
            }
            if (rd.FieldExists("PQT_NgayDung"))
            {
                Item.NgayDung = (Boolean)(rd["PQT_NgayDung"]);
            }
            if (rd.FieldExists("PQT_Active"))
            {
                Item.Active = (Boolean)(rd["PQT_Active"]);
            }
            if (rd.FieldExists("PQT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PQT_NgayTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion
}
