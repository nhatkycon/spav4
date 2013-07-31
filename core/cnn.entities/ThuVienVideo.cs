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
    #region ThuvienVideo
    #region BO
    public class ThuvienVideo : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String Keyword { get; set; }
        public String UrlImage { get; set; }
        public String Url { get; set; }
        public Int16 Thutu { get; set; }
        public Int16 Loai { get; set; }
        public DateTime Ngaytao { get; set; }
        public Boolean Active { get; set; }
        public Guid RowId { get; set; }
        public Int16 CateID { get; set; }
        public String NguoiTao { get; set; }
        #endregion
        #region Contructor
        public ThuvienVideo()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuvienVideoDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuvienVideoCollection : BaseEntityCollection<ThuvienVideo>
    { }
    #endregion
    #region Dal
    public class ThuvienVideoDal
    {
        #region Methods

        public static void DeleteById(Int32 TV_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Delete_DeleteById_hiennb", obj);
        }

        public static ThuvienVideo Insert(ThuvienVideo Inserted)
        {
            ThuvienVideo Item = new ThuvienVideo();
            SqlParameter[] obj = new SqlParameter[12];
            obj[0] = new SqlParameter("TV_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("TV_Mota", Inserted.Mota);
            obj[2] = new SqlParameter("TV_Keyword", Inserted.Keyword);
            obj[3] = new SqlParameter("TV_UrlImage", Inserted.UrlImage);
            obj[4] = new SqlParameter("TV_Url", Inserted.Url);
            obj[5] = new SqlParameter("TV_Thutu", Inserted.Thutu);
            obj[6] = new SqlParameter("TV_Loai", Inserted.Loai);
            obj[7] = new SqlParameter("TV_Ngaytao", Inserted.Ngaytao);
            obj[8] = new SqlParameter("TV_Active", Inserted.Active);
            obj[9] = new SqlParameter("TV_RowId", Inserted.RowId);
            obj[10] = new SqlParameter("TV_CateID", Inserted.CateID);
            obj[11] = new SqlParameter("TV_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuvienVideo Update(ThuvienVideo Updated)
        {
            ThuvienVideo Item = new ThuvienVideo();
            SqlParameter[] obj = new SqlParameter[13];
            obj[0] = new SqlParameter("TV_ID", Updated.ID);
            obj[1] = new SqlParameter("TV_Ten", Updated.Ten);
            obj[2] = new SqlParameter("TV_Mota", Updated.Mota);
            obj[3] = new SqlParameter("TV_Keyword", Updated.Keyword);
            obj[4] = new SqlParameter("TV_UrlImage", Updated.UrlImage);
            obj[5] = new SqlParameter("TV_Url", Updated.Url);
            obj[6] = new SqlParameter("TV_Thutu", Updated.Thutu);
            obj[7] = new SqlParameter("TV_Loai", Updated.Loai);
            obj[8] = new SqlParameter("TV_Ngaytao", Updated.Ngaytao);
            obj[9] = new SqlParameter("TV_Active", Updated.Active);
            obj[10] = new SqlParameter("TV_RowId", Updated.RowId);
            obj[11] = new SqlParameter("TV_CateID", Updated.CateID);
            obj[12] = new SqlParameter("TV_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuvienVideo SelectById(Int32 TV_ID)
        {
            ThuvienVideo Item = new ThuvienVideo();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TV_ID", TV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuvienVideoCollection SelectAll()
        {
            ThuvienVideoCollection List = new ThuvienVideoCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuvien_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }   
        public static Pager<ThuvienVideo> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize, string gh_id)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("gh_id", gh_id);
            Pager<ThuvienVideo> pg = new Pager<ThuvienVideo>("sp_tblThuvien_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuvienVideo getFromReader(IDataReader rd)
        {
            ThuvienVideo Item = new ThuvienVideo();
            if (rd.FieldExists("TV_ID"))
            {
                Item.ID = (Int32)(rd["TV_ID"]);
            }
            if (rd.FieldExists("TV_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["TV_GH_ID"]);
            }
            if (rd.FieldExists("TV_Ten"))
            {
                Item.Ten = (String)(rd["TV_Ten"]);
            }
            if (rd.FieldExists("TV_Mota"))
            {
                Item.Mota = (String)(rd["TV_Mota"]);
            }
            if (rd.FieldExists("TV_Keyword"))
            {
                Item.Keyword = (String)(rd["TV_Keyword"]);
            }
            if (rd.FieldExists("TV_UrlImage"))
            {
                Item.UrlImage = (String)(rd["TV_UrlImage"]);
            }
            if (rd.FieldExists("TV_Url"))
            {
                Item.Url = (String)(rd["TV_Url"]);
            }
            if (rd.FieldExists("TV_Thutu"))
            {
                Item.Thutu = (Int16)(rd["TV_Thutu"]);
            }
            if (rd.FieldExists("TV_Loai"))
            {
                Item.Loai = (Int16)(rd["TV_Loai"]);
            }
            if (rd.FieldExists("TV_Ngaytao"))
            {
                Item.Ngaytao = (DateTime)(rd["TV_Ngaytao"]);
            }
            if (rd.FieldExists("TV_Active"))
            {
                Item.Active = (Boolean)(rd["TV_Active"]);
            }
            if (rd.FieldExists("TV_RowId"))
            {
                Item.RowId = (Guid)(rd["TV_RowId"]);
            }
            if (rd.FieldExists("TV_CateID"))
            {
                Item.CateID = (Int16)(rd["TV_CateID"]);
            }
            if (rd.FieldExists("TV_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TV_NguoiTao"]);
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
