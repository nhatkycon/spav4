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
    #region HinhAnh
    #region BO
    public class HinhAnh : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String PathImage { get; set; }
        public String Link { get; set; }
        public String NguoiTao { get; set; }
        public DateTime Ngaytao { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        #endregion
        #region Contructor
        public HinhAnh()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return HinhAnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class HinhAnhCollection : BaseEntityCollection<HinhAnh>
    { }
    #endregion
    #region Dal
    public class HinhAnhDal
    {
        #region Methods

        public static void DeleteById(Int32 HA_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HA_ID", HA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHinhAnh_Delete_DeleteById_hiennb", obj);
        }

        public static HinhAnh Insert(HinhAnh Inserted)
        {
            HinhAnh Item = new HinhAnh();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("HA_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("HA_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("HA_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("HA_PathImage", Inserted.PathImage);
            obj[4] = new SqlParameter("HA_Link", Inserted.Link);
            obj[5] = new SqlParameter("HA_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("HA_Ngaytao", Inserted.Ngaytao);
            obj[7] = new SqlParameter("HA_Active", Inserted.Active);
            obj[8] = new SqlParameter("HA_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHinhAnh_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HinhAnh Update(HinhAnh Updated)
        {
            HinhAnh Item = new HinhAnh();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("HA_ID", Updated.ID);
            obj[1] = new SqlParameter("HA_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("HA_Ten", Updated.Ten);
            obj[3] = new SqlParameter("HA_Mota", Updated.Mota);
            obj[4] = new SqlParameter("HA_PathImage", Updated.PathImage);
            obj[5] = new SqlParameter("HA_Link", Updated.Link);
            obj[6] = new SqlParameter("HA_NguoiTao", Updated.NguoiTao);
            obj[7] = new SqlParameter("HA_Ngaytao", Updated.Ngaytao);
            obj[8] = new SqlParameter("HA_Active", Updated.Active);
            obj[9] = new SqlParameter("HA_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHinhAnh_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HinhAnh SelectById(Int32 HA_ID)
        {
            HinhAnh Item = new HinhAnh();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HA_ID", HA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHinhAnh_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HinhAnhCollection SelectAll()
        {
            HinhAnhCollection List = new HinhAnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHinhAnh_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }   
        public static Pager<HinhAnh> pagerNormal(string url, bool rewrite, string sort, string q, string gh_id, string pagesize)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("gh_id", gh_id);
            Pager<HinhAnh> pg = new Pager<HinhAnh>("sp_tblHinhAnh_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static HinhAnh getFromReader(IDataReader rd)
        {
            HinhAnh Item = new HinhAnh();
            if (rd.FieldExists("HA_ID"))
            {
                Item.ID = (Int32)(rd["HA_ID"]);
            }
            if (rd.FieldExists("HA_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["HA_GH_ID"]);
            }
            if (rd.FieldExists("HA_Ten"))
            {
                Item.Ten = (String)(rd["HA_Ten"]);
            }
            if (rd.FieldExists("HA_Mota"))
            {
                Item.Mota = (String)(rd["HA_Mota"]);
            }
            if (rd.FieldExists("HA_PathImage"))
            {
                Item.PathImage = (String)(rd["HA_PathImage"]);
            }
            if (rd.FieldExists("HA_Link"))
            {
                Item.Link = (String)(rd["HA_Link"]);
            }
            if (rd.FieldExists("HA_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["HA_NguoiTao"]);
            }
            if (rd.FieldExists("HA_Ngaytao"))
            {
                Item.Ngaytao = (DateTime)(rd["HA_Ngaytao"]);
            }
            if (rd.FieldExists("HA_Active"))
            {
                Item.Active = (Boolean)(rd["HA_Active"]);
            }
            if (rd.FieldExists("HA_RowId"))
            {
                Item.RowId = (Guid)(rd["HA_RowId"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static HinhAnh Insert(HinhAnh Inserted,SqlConnection con)
        {
            HinhAnh Item = new HinhAnh();
            SqlParameter[] obj = new SqlParameter[9];
            obj[0] = new SqlParameter("HA_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("HA_Ten", Inserted.Ten);
            obj[2] = new SqlParameter("HA_Mota", Inserted.Mota);
            obj[3] = new SqlParameter("HA_PathImage", Inserted.PathImage);
            obj[4] = new SqlParameter("HA_Link", Inserted.Link);
            obj[5] = new SqlParameter("HA_NguoiTao", Inserted.NguoiTao);
            obj[6] = new SqlParameter("HA_Ngaytao", Inserted.Ngaytao);
            obj[7] = new SqlParameter("HA_Active", Inserted.Active);
            obj[8] = new SqlParameter("HA_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblHinhAnh_Insert_InsertNormal_hiennb", obj))
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
