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
    #region QuaTang
    #region BO
    public class QuaTang : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public String Ma { get; set; }
        public String Ten { get; set; }
        public String NoiDung { get; set; }
        public String MoTa { get; set; }
        public String Anh { get; set; }
        public Int32 SPA_ID { get; set; }
        public Int32 DV_ID { get; set; }
        public Boolean Active { get; set; }
        public Boolean Hot { get; set; }
        public Boolean TrangChu { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean HetHan { get; set; }
        #endregion
        #region Contructor
        public QuaTang()
        { }
        #endregion
        #region Customs properties

        public string SPA_Ten { get; set; }
        public string DV_Ten { get; set; }
        public int TongPhieu { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return QuaTangDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class QuaTangCollection : BaseEntityCollection<QuaTang>
    { }
    #endregion
    #region Dal
    public class QuaTangDal
    {
        #region Methods

        public static void DeleteById(Guid QT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("QT_ID", QT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblQuaTang_Delete_DeleteById_linhnx", obj);
        }

        public static QuaTang Insert(QuaTang item)
        {
            var Item = new QuaTang();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("QT_ID", item.ID);
            obj[1] = new SqlParameter("QT_Ma", item.Ma);
            obj[2] = new SqlParameter("QT_Ten", item.Ten);
            obj[3] = new SqlParameter("QT_NoiDung", item.NoiDung);
            obj[4] = new SqlParameter("QT_MoTa", item.MoTa);
            obj[5] = new SqlParameter("QT_Anh", item.Anh);
            obj[6] = new SqlParameter("QT_SPA_ID", item.SPA_ID);
            obj[7] = new SqlParameter("QT_DV_ID", item.DV_ID);
            obj[8] = new SqlParameter("QT_Active", item.Active);
            obj[9] = new SqlParameter("QT_Hot", item.Hot);
            obj[10] = new SqlParameter("QT_TrangChu", item.TrangChu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("QT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("QT_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("QT_HetHan", item.HetHan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuaTang_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuaTang Update(QuaTang item)
        {
            var Item = new QuaTang();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("QT_ID", item.ID);
            obj[1] = new SqlParameter("QT_Ma", item.Ma);
            obj[2] = new SqlParameter("QT_Ten", item.Ten);
            obj[3] = new SqlParameter("QT_NoiDung", item.NoiDung);
            obj[4] = new SqlParameter("QT_MoTa", item.MoTa);
            obj[5] = new SqlParameter("QT_Anh", item.Anh);
            obj[6] = new SqlParameter("QT_SPA_ID", item.SPA_ID);
            obj[7] = new SqlParameter("QT_DV_ID", item.DV_ID);
            obj[8] = new SqlParameter("QT_Active", item.Active);
            obj[9] = new SqlParameter("QT_Hot", item.Hot);
            obj[10] = new SqlParameter("QT_TrangChu", item.TrangChu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("QT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("QT_NgayTao", DBNull.Value);
            }
            obj[12] = new SqlParameter("QT_HetHan", item.HetHan);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuaTang_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuaTang SelectById(Guid QT_ID)
        {
            var Item = new QuaTang();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("QT_ID", QT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuaTang_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static QuaTangCollection SelectAll()
        {
            var List = new QuaTangCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblQuaTang_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<QuaTang> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<QuaTang>("sp_tblQuaTang_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static QuaTang getFromReader(IDataReader rd)
        {
            var Item = new QuaTang();
            if (rd.FieldExists("QT_ID"))
            {
                Item.ID = (Guid)(rd["QT_ID"]);
            }
            if (rd.FieldExists("QT_Ma"))
            {
                Item.Ma = (String)(rd["QT_Ma"]);
            }
            if (rd.FieldExists("QT_Ten"))
            {
                Item.Ten = (String)(rd["QT_Ten"]);
            }
            if (rd.FieldExists("QT_NoiDung"))
            {
                Item.NoiDung = (String)(rd["QT_NoiDung"]);
            }
            if (rd.FieldExists("QT_MoTa"))
            {
                Item.MoTa = (String)(rd["QT_MoTa"]);
            }
            if (rd.FieldExists("QT_Anh"))
            {
                Item.Anh = (String)(rd["QT_Anh"]);
            }
            if (rd.FieldExists("QT_SPA_ID"))
            {
                Item.SPA_ID = (Int32)(rd["QT_SPA_ID"]);
            }
            if (rd.FieldExists("QT_DV_ID"))
            {
                Item.DV_ID = (Int32)(rd["QT_DV_ID"]);
            }
            if (rd.FieldExists("QT_Active"))
            {
                Item.Active = (Boolean)(rd["QT_Active"]);
            }
            if (rd.FieldExists("QT_Hot"))
            {
                Item.Hot = (Boolean)(rd["QT_Hot"]);
            }
            if (rd.FieldExists("QT_TrangChu"))
            {
                Item.TrangChu = (Boolean)(rd["QT_TrangChu"]);
            }
            if (rd.FieldExists("QT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["QT_NgayTao"]);
            }
            if (rd.FieldExists("QT_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["QT_HetHan"]);
            }
            if (rd.FieldExists("QT_SPA_Ten"))
            {
                Item.SPA_Ten = (String)(rd["QT_SPA_Ten"]);
            }
            if (rd.FieldExists("QT_DV_Ten"))
            {
                Item.DV_Ten = (String)(rd["QT_DV_Ten"]);
            }
            if (rd.FieldExists("QT_TongPhieu"))
            {
                Item.TongPhieu = (Int32)(rd["QT_TongPhieu"]);
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
