using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using System.Data;
using System.Data.SqlClient;
using linh.core;

namespace cnn.entities
{
    #region Flash
    #region BO
    public class Flash : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }        
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String PathImage { get; set; }
        public String PathFlash { get; set; }
        public Int16 Thutu { get; set; }
        public String NguoiTao { get; set; }
        public DateTime Ngaytao { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public Flash()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return FlashDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class FlashCollection : BaseEntityCollection<Flash>
    { }
    #endregion
    #region Dal
    public class FlashDal
    {
        #region Methods

        public static void DeleteById(Int32 Flh_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Flh_ID", Flh_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Delete_DeleteById_hiennb", obj);
        }

        public static Flash Insert(Flash Inserted)
        {
            Flash Item = new Flash();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Flh_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("Flh_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("Flh_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("Flh_PathImage", Inserted.PathImage);
            obj[4] = new SqlParameter("Flh_PathFlash", Inserted.PathFlash);
            obj[5] = new SqlParameter("Flh_Thutu", Inserted.Thutu);
            obj[6] = new SqlParameter("Flh_NguoiTao", Inserted.NguoiTao);
            obj[7] = new SqlParameter("Flh_Ngaytao", Inserted.Ngaytao);
            obj[8] = new SqlParameter("Flh_Active", Inserted.Active);
            obj[9] = new SqlParameter("Flh_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Flash Update(Flash Updated)
        {
            Flash Item = new Flash();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("Flh_ID", Updated.ID);
            obj[1] = new SqlParameter("Flh_GH_ID", Updated.GH_ID);             
            obj[3] = new SqlParameter("Flh_Ten", Updated.Ten);
            obj[4] = new SqlParameter("Flh_Mota", Updated.Mota);
            obj[5] = new SqlParameter("Flh_PathImage", Updated.PathImage);
            obj[6] = new SqlParameter("Flh_PathFlash", Updated.PathFlash);             
            obj[7] = new SqlParameter("Flh_Thutu", Updated.Thutu);
            obj[8] = new SqlParameter("Flh_NguoiTao", Updated.NguoiTao);
            obj[9] = new SqlParameter("Flh_Ngaytao", Updated.Ngaytao);
            obj[10] = new SqlParameter("Flh_Active", Updated.Active);
            obj[11] = new SqlParameter("Flh_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Flash SelectById(Int32 Flh_ID)
        {
            Flash Item = new Flash();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Flh_ID", Flh_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static FlashCollection SelectAll()
        {
            FlashCollection List = new FlashCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
         
        public static Pager<Flash> pagerNormal(string url, bool rewrite, string sort, string q, string gh_id,string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("gh_id", gh_id);
            Pager<Flash> pg = new Pager<Flash>("sp_tblFlash_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }

        #endregion

        #region Utilities
        public static Flash getFromReader(IDataReader rd)
        {
            Flash Item = new Flash();
            if (rd.FieldExists("Flh_ID"))
            {
                Item.ID = (Int32)(rd["Flh_ID"]);
            }
            if (rd.FieldExists("Flh_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["Flh_GH_ID"]);
            }         
            if (rd.FieldExists("Flh_Ten"))
            {
                Item.Ten = (String)(rd["Flh_Ten"]);
            }
            if (rd.FieldExists("Flh_Mota"))
            {
                Item.Mota = (String)(rd["Flh_Mota"]);
            }
            if (rd.FieldExists("Flh_PathImage"))
            {
                Item.PathImage = (String)(rd["Flh_PathImage"]);
            }
            if (rd.FieldExists("Flh_PathFlash"))
            {
                Item.PathFlash = (String)(rd["Flh_PathFlash"]);
            }
            if (rd.FieldExists("Flh_Thutu"))
            {
                Item.Thutu = (Int16)(rd["Flh_Thutu"]);
            }
            if (rd.FieldExists("Flh_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["Flh_NguoiTao"]);
            }
            if (rd.FieldExists("Flh_Ngaytao"))
            {
                Item.Ngaytao = (DateTime)(rd["Flh_Ngaytao"]);
            }
            if (rd.FieldExists("Flh_Active"))
            {
                Item.Active = (Boolean)(rd["Flh_Active"]);
            }
            if (rd.FieldExists("Flh_RowId"))
            {
                Item.RowId = (Guid)(rd["Flh_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static FlashCollection SelectTopByGhId(string gh_id, int top)
        {
            FlashCollection List = new FlashCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("gh_id", gh_id);
            obj[1] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblFlash_Select_SelectTopByGhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static FlashCollection SelectTopByGhId(SqlConnection con, string gh_id, int top)
        {
            FlashCollection List = new FlashCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("gh_id", gh_id);
            obj[1] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblFlash_Select_SelectTopByGhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        /// <summary>
        /// duc them ham nay de chuyen du lieu(sua ngay 01/08/2011)
        /// </summary>
        /// <param name="Inserted"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Flash Insert(Flash Inserted,SqlConnection con)
        {
            Flash Item = new Flash();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Flh_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("Flh_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("Flh_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("Flh_PathImage", Inserted.PathImage);
            obj[4] = new SqlParameter("Flh_PathFlash", Inserted.PathFlash);
            obj[5] = new SqlParameter("Flh_Thutu", Inserted.Thutu);
            obj[6] = new SqlParameter("Flh_NguoiTao", Inserted.NguoiTao);
            obj[7] = new SqlParameter("Flh_Ngaytao", Inserted.Ngaytao);
            obj[8] = new SqlParameter("Flh_Active", Inserted.Active);
            obj[9] = new SqlParameter("Flh_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblFlash_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        #endregion
    }
    #endregion

    #endregion
}
