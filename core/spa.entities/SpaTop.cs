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
    #region SpaTop
    #region BO
    public class SpaTop : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 SPA_ID { get; set; }
        public Int32 ThuTu { get; set; }
        public Boolean Active { get; set; }
        public Boolean Readed { get; set; }
        public Int32 LOAI_ID { get; set; }
        #endregion
        #region Contructor
        public SpaTop()
        { }
        #endregion
        #region Customs properties
        public String DM_Ten { get; set; }
        public String SPA_Ten { get; set; }
        public String LOAI_Ten { get; set; }
        public Spa _Spa { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaTopDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaTopCollection : BaseEntityCollection<SpaTop>
    { }
    #endregion
    #region Dal
    public class SpaTopDal
    {
        #region Methods

        public static void DeleteById(Int32 TP_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TP_ID", TP_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Delete_DeleteById_hoangda", obj);
        }

        public static SpaTop Insert(SpaTop Inserted)
        {
            SpaTop Item = new SpaTop();
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("TP_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("TP_SPA_ID", Inserted.SPA_ID);
            obj[2] = new SqlParameter("TP_ThuTu", Inserted.ThuTu);
            obj[3] = new SqlParameter("TP_Active", Inserted.Active);
            obj[4] = new SqlParameter("TP_Readed", Inserted.Readed);
            obj[5] = new SqlParameter("TP_LOAI_ID", Inserted.LOAI_ID);
            obj[6] = new SqlParameter("TP_MoTa", Inserted.MoTa);
            obj[7] = new SqlParameter("TP_NoiDung", Inserted.NoiDung);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaTop Update(SpaTop Updated)
        {
            SpaTop Item = new SpaTop();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("TP_ID", Updated.ID);
            obj[1] = new SqlParameter("TP_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("TP_SPA_ID", Updated.SPA_ID);
            obj[3] = new SqlParameter("TP_ThuTu", Updated.ThuTu);
            obj[4] = new SqlParameter("TP_Active", Updated.Active);
            obj[5] = new SqlParameter("TP_Readed", Updated.Readed);
            obj[6] = new SqlParameter("TP_LOAI_ID", Updated.LOAI_ID);
            obj[7] = new SqlParameter("TP_MoTa", Updated.MoTa);
            obj[8] = new SqlParameter("TP_NoiDung", Updated.NoiDung);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaTop SelectById(Int32 TP_ID)
        {
            SpaTop Item = new SpaTop();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TP_ID", TP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SpaTopCollection SelectAll()
        {
            SpaTopCollection List = new SpaTopCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SpaTop> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            Pager<SpaTop> pg = new Pager<SpaTop>("sp_tblSpaTop_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        #endregion

        #region Utilities
        public static SpaTop getFromReader(IDataReader rd)
        {
            SpaTop Item = new SpaTop();
            if (rd.FieldExists("TP_ID"))
            {
                Item.ID = (Int32)(rd["TP_ID"]);
            }
            if (rd.FieldExists("TP_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["TP_DM_ID"]);
            }
            if (rd.FieldExists("TP_SPA_ID"))
            {
                Item.SPA_ID = (Int32)(rd["TP_SPA_ID"]);
            }
            if (rd.FieldExists("TP_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TP_ThuTu"]);
            }
            if (rd.FieldExists("TP_Active"))
            {
                Item.Active = (Boolean)(rd["TP_Active"]);
            }
            if (rd.FieldExists("TP_Readed"))
            {
                Item.Readed = (Boolean)(rd["TP_Readed"]);
            }
            if (rd.FieldExists("TP_LOAI_ID"))
            {
                Item.LOAI_ID = (Int32)(rd["TP_LOAI_ID"]);
            }
            if (rd.FieldExists("TP_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TP_DM_Ten"]);
            }
            if (rd.FieldExists("TP_SPA_Ten"))
            {
                Item.SPA_Ten = (String)(rd["TP_SPA_Ten"]);
            }
            if (rd.FieldExists("TP_LOAI_Ten"))
            {
                Item.LOAI_Ten = (String)(rd["TP_LOAI_Ten"]);
            }
            if (rd.FieldExists("TP_MoTa"))
            {
                Item.MoTa = (String)(rd["TP_MoTa"]);
            }
            if (rd.FieldExists("TP_NoiDung"))
            {
                Item.NoiDung = (String)(rd["TP_NoiDung"]);
            }
            Spa _spa = new Spa();
            _spa = SpaDal.getFromReader(rd);
            Item._Spa = _spa;
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<SpaTop> pagerDanhMuc(string sort, string q, string _dm_id, string _loai_id, int size)
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
            if (!string.IsNullOrEmpty(_loai_id))
            {
                obj[3] = new SqlParameter("loai_id", _loai_id);
            }
            else
            {
                obj[3] = new SqlParameter("loai_id", DBNull.Value);
            }
            Pager<SpaTop> pg = new Pager<SpaTop>("sp_tblSpaTop_Pager_pagerDanhMuc_hoangda", "pages", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static SpaTopCollection SelectByLoai(string dm_id, int top)
        {
            SpaTopCollection List = new SpaTopCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("dm_id", dm_id);
            obj[1] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaTop_Select_SelectByLoai_hoangda", obj))
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
