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
    #region VideoClip
    #region BO
    public class VideoClip : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 ChuDe_ID { get; set; }
        public String Ten { get; set; }
        public Int32 SoLuotXem { get; set; }
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
        public VideoClip()
        { }
        #endregion
        #region Customs properties
        public string TenChuDe { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return VideoClipDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class VideoClipCollection : BaseEntityCollection<VideoClip>
    { }
    #endregion
    #region Dal
    public class VideoClipDal
    {
        #region Methods

        public static void DeleteById(Int32 VC_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VC_ID", VC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblVideoClip_Delete_DeleteById_hiennb", obj);
        }

        public static VideoClip Insert(VideoClip Inserted)
        {
            VideoClip Item = new VideoClip();
            SqlParameter[] obj = new SqlParameter[15];
            obj[0] = new SqlParameter("VC_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("VC_ChuDe_ID", Inserted.ChuDe_ID);
            obj[2] = new SqlParameter("VC_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("VC_SoLuotXem", Inserted.SoLuotXem);
            obj[4] = new SqlParameter("VC_Mota", Inserted.Mota);
            obj[5] = new SqlParameter("VC_Keyword", Inserted.Keyword);
            obj[6] = new SqlParameter("VC_UrlImage", Inserted.UrlImage);
            obj[7] = new SqlParameter("VC_Url", Inserted.Url);
            obj[8] = new SqlParameter("VC_Thutu", Inserted.Thutu);
            obj[9] = new SqlParameter("VC_Loai", Inserted.Loai);
            obj[10] = new SqlParameter("VC_Ngaytao", Inserted.Ngaytao);
            obj[11] = new SqlParameter("VC_Active", Inserted.Active);
            obj[12] = new SqlParameter("VC_RowId", Inserted.RowId);
            obj[13] = new SqlParameter("VC_CateID", Inserted.CateID);
            obj[14] = new SqlParameter("VC_NguoiTao", Inserted.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVideoClip_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VideoClip Update(VideoClip Updated)
        {
            VideoClip Item = new VideoClip();
            SqlParameter[] obj = new SqlParameter[16];
            obj[0] = new SqlParameter("VC_ID", Updated.ID);
            obj[1] = new SqlParameter("VC_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("VC_ChuDe_ID", Updated.ChuDe_ID);
            obj[3] = new SqlParameter("VC_Ten", Updated.Ten);
            obj[4] = new SqlParameter("VC_SoLuotXem", Updated.SoLuotXem);
            obj[5] = new SqlParameter("VC_Mota", Updated.Mota);
            obj[6] = new SqlParameter("VC_Keyword", Updated.Keyword);
            obj[7] = new SqlParameter("VC_UrlImage", Updated.UrlImage);
            obj[8] = new SqlParameter("VC_Url", Updated.Url);
            obj[9] = new SqlParameter("VC_Thutu", Updated.Thutu);
            obj[10] = new SqlParameter("VC_Loai", Updated.Loai);
            obj[11] = new SqlParameter("VC_Ngaytao", Updated.Ngaytao);
            obj[12] = new SqlParameter("VC_Active", Updated.Active);
            obj[13] = new SqlParameter("VC_RowId", Updated.RowId);
            obj[14] = new SqlParameter("VC_CateID", Updated.CateID);
            obj[15] = new SqlParameter("VC_NguoiTao", Updated.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVideoClip_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VideoClip SelectById(Int32 VC_ID)
        {
            VideoClip Item = new VideoClip();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("VC_ID", VC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVideoClip_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static VideoClipCollection SelectAll()
        {
            VideoClipCollection List = new VideoClipCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblVideoClip_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }    

        public static Pager<VideoClip> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize, string gh_id, string chude_id, string active)
        {
            SqlParameter[] obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("gh_id", gh_id);
            obj[3] = new SqlParameter("chude_id", chude_id);
            obj[4] = new SqlParameter("active", active);
            Pager<VideoClip> pg = new Pager<VideoClip>("sp_tblVideoClip_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        #endregion
       

        #region Utilities
        public static VideoClip getFromReader(IDataReader rd)
        {
            VideoClip Item = new VideoClip();
            if (rd.FieldExists("VC_ID"))
            {
                Item.ID = (Int32)(rd["VC_ID"]);
            }
            if (rd.FieldExists("VC_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["VC_GH_ID"]);
            }
            if (rd.FieldExists("VC_ChuDe_ID"))
            {
                Item.ChuDe_ID = (Int32)(rd["VC_ChuDe_ID"]);
            }
            if (rd.FieldExists("VC_Ten"))
            {
                Item.Ten = (String)(rd["VC_Ten"]);
            }
            if (rd.FieldExists("VC_SoLuotXem"))
            {
                Item.SoLuotXem = (Int32)(rd["VC_SoLuotXem"]);
            }
            if (rd.FieldExists("VC_Mota"))
            {
                Item.Mota = (String)(rd["VC_Mota"]);
            }
            if (rd.FieldExists("VC_Keyword"))
            {
                Item.Keyword = (String)(rd["VC_Keyword"]);
            }
            if (rd.FieldExists("VC_UrlImage"))
            {
                Item.UrlImage = (String)(rd["VC_UrlImage"]);
            }
            if (rd.FieldExists("VC_Url"))
            {
                Item.Url = (String)(rd["VC_Url"]);
            }
            if (rd.FieldExists("VC_Thutu"))
            {
                Item.Thutu = (Int16)(rd["VC_Thutu"]);
            }
            if (rd.FieldExists("VC_Loai"))
            {
                Item.Loai = (Int16)(rd["VC_Loai"]);
            }
            if (rd.FieldExists("VC_Ngaytao"))
            {
                Item.Ngaytao = (DateTime)(rd["VC_Ngaytao"]);
            }
            if (rd.FieldExists("VC_Active"))
            {
                Item.Active = (Boolean)(rd["VC_Active"]);
            }
            if (rd.FieldExists("VC_RowId"))
            {
                Item.RowId = (Guid)(rd["VC_RowId"]);
            }
            if (rd.FieldExists("VC_CateID"))
            {
                Item.CateID = (Int16)(rd["VC_CateID"]);
            }
            if (rd.FieldExists("VC_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["VC_NguoiTao"]);
            }
            if (rd.FieldExists("DM_Ten"))
            {
                Item.TenChuDe = (String)(rd["DM_Ten"]);
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
