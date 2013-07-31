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
using linh.common;
using System.Web;
using docsoft.entities;
namespace cnn.entities
{
    #region GiaoThuong
    #region BO
    public class GiaoThuong : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 KV_ID { get; set; }
        public Boolean Mua { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public String XuatXu { get; set; }
        public String Anh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int64 Views { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Boolean Hot4 { get; set; }
        public Guid RowId { get; set; }

        #endregion
        #region Contructor
        public GiaoThuong()
        { }
        #endregion
        #region Customs properties
        public String _DM_Ten { get; set; }
        public String _GiaoThuongh_Ten { get; set; }
        public Int32 COUNTLANG { get; set; }
        public Int32 _MEM_ID { get; set; }
        public String _MEM_Username { get; set; }
        public Int32 _CQ_ID { get; set; }
        public string _CQ_Ten { get; set; }
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GiaoThuongDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GiaoThuongCollection : BaseEntityCollection<GiaoThuong>
    { }
    #endregion
    #region Dal
    public class GiaoThuongDal
    {
        #region Methods
        public static GiaoThuong SelectByIdView(Int32 VBD_ID)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GiaoThuong_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                    Files item = new Files();
                    if (rd.FieldExists("F_Ten"))
                    {
                        item.Ten = (String)(rd["F_Ten"]);
                    }

                    if (rd.FieldExists("F_ID"))
                    {
                        item.ID = (Int32)(rd["F_ID"]);
                    }
                    if (rd.FieldExists("F_NguoiTao"))
                    {
                        item.NguoiTao = (String)(rd["F_NguoiTao"]);
                    }
                    if (rd.FieldExists("F_Size"))
                    {
                        item.Size = (Int32)(rd["F_Size"]);
                    }
                    if (rd.FieldExists("F_MimeType"))
                    {
                        item.MimeType = (String)(rd["F_MimeType"]);
                    }
                    if (rd.FieldExists("F_Download"))
                    {
                        item.Download = (Int32)(rd["F_Download"]);
                    }
                    filelist.Add(item);
                }
            }
            Item.Filelist = filelist;
            return Item;
        }
        public static void DuyetList(string IDList, string Active, string dungfn)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("IDList", IDList);
            if (!string.IsNullOrEmpty(Active))
            {
                obj[1] = new SqlParameter("Active", Active);
            }
            else
            {
                obj[1] = new SqlParameter("Active", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dungfn))
            {
                obj[2] = new SqlParameter("dungfn", dungfn);
            }
            else
            {
                obj[2] = new SqlParameter("dungfn", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Update_ActiveList", obj);
        }

        public static void DeleteById(Int32 GT_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GT_ID", GT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Delete_DeleteById_linhnx", obj);
        }
        public static void DeleteByIdList(string GT_IDList)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GT_IDList", GT_IDList);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Delete_DeleteByIdList_linhnx", obj);
        }

        public static void DKDVVIP(string GT_IDList)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("IDList", GT_IDList);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_DKDVVIP_hoangda", obj);
        }

        public static GiaoThuong Insert(GiaoThuong Inserted)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("GT_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("GT_GH_ID", Inserted.GH_ID);
            obj[2] = new SqlParameter("GT_KV_ID", Inserted.KV_ID);
            obj[3] = new SqlParameter("GT_Mua", Inserted.Mua);
            obj[4] = new SqlParameter("GT_Lang", Inserted.Lang);
            obj[5] = new SqlParameter("GT_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("GT_LangBased_ID", Inserted.LangBased_ID);
            obj[7] = new SqlParameter("GT_Alias", Inserted.Alias);
            obj[8] = new SqlParameter("GT_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("GT_MoTa", Inserted.MoTa);
            obj[10] = new SqlParameter("GT_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("GT_XuatXu", Inserted.XuatXu);
            obj[12] = new SqlParameter("GT_Anh", Inserted.Anh);
            obj[13] = new SqlParameter("GT_NgayHetHan", Inserted.NgayHetHan);
            obj[14] = new SqlParameter("GT_NguoiTao", Inserted.NguoiTao);
            obj[15] = new SqlParameter("GT_NgayTao", Inserted.NgayTao);
            obj[16] = new SqlParameter("GT_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[17] = new SqlParameter("GT_NgayCapNhat", Inserted.NgayCapNhat);
            obj[18] = new SqlParameter("GT_Views", Inserted.Views);
            obj[19] = new SqlParameter("GT_Active", Inserted.Active);
            obj[20] = new SqlParameter("GT_Publish", Inserted.Publish);
            obj[21] = new SqlParameter("GT_Hot1", Inserted.Hot1);
            obj[22] = new SqlParameter("GT_Hot2", Inserted.Hot2);
            obj[23] = new SqlParameter("GT_Hot3", Inserted.Hot3);
            obj[24] = new SqlParameter("GT_Hot4", Inserted.Hot4);
            obj[25] = new SqlParameter("GT_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaoThuong Insert(GiaoThuong Inserted,SqlConnection con)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("GT_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("GT_GH_ID", Inserted.GH_ID);
            obj[2] = new SqlParameter("GT_KV_ID", Inserted.KV_ID);
            obj[3] = new SqlParameter("GT_Mua", Inserted.Mua);
            obj[4] = new SqlParameter("GT_Lang", Inserted.Lang);
            obj[5] = new SqlParameter("GT_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("GT_LangBased_ID", Inserted.LangBased_ID);
            obj[7] = new SqlParameter("GT_Alias", Inserted.Alias);
            obj[8] = new SqlParameter("GT_Ten", Inserted.Ten);
            obj[9] = new SqlParameter("GT_MoTa", Inserted.MoTa);
            obj[10] = new SqlParameter("GT_NoiDung", Inserted.NoiDung);
            obj[11] = new SqlParameter("GT_XuatXu", Inserted.XuatXu);
            obj[12] = new SqlParameter("GT_Anh", Inserted.Anh);
            obj[13] = new SqlParameter("GT_NgayHetHan", Inserted.NgayHetHan);
            obj[14] = new SqlParameter("GT_NguoiTao", Inserted.NguoiTao);
            obj[15] = new SqlParameter("GT_NgayTao", Inserted.NgayTao);
            obj[16] = new SqlParameter("GT_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[17] = new SqlParameter("GT_NgayCapNhat", Inserted.NgayCapNhat);
            obj[18] = new SqlParameter("GT_Views", Inserted.Views);
            obj[19] = new SqlParameter("GT_Active", Inserted.Active);
            obj[20] = new SqlParameter("GT_Publish", Inserted.Publish);
            obj[21] = new SqlParameter("GT_Hot1", Inserted.Hot1);
            obj[22] = new SqlParameter("GT_Hot2", Inserted.Hot2);
            obj[23] = new SqlParameter("GT_Hot3", Inserted.Hot3);
            obj[24] = new SqlParameter("GT_Hot4", Inserted.Hot4);
            obj[25] = new SqlParameter("GT_RowId", Inserted.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblGiaoThuong_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static GiaoThuong Update(GiaoThuong Updated)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[22];
            obj[0] = new SqlParameter("GT_ID", Updated.ID);
            obj[1] = new SqlParameter("GT_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("GT_GH_ID", Updated.GH_ID);
            obj[3] = new SqlParameter("GT_KV_ID", Updated.KV_ID);
            obj[4] = new SqlParameter("GT_Mua", Updated.Mua);
            obj[5] = new SqlParameter("GT_Lang", Updated.Lang);
            obj[6] = new SqlParameter("GT_LangBased", Updated.LangBased);
            obj[7] = new SqlParameter("GT_LangBased_ID", Updated.LangBased_ID);
            obj[8] = new SqlParameter("GT_Alias", Updated.Alias);
            obj[9] = new SqlParameter("GT_Ten", Updated.Ten);
            obj[10] = new SqlParameter("GT_MoTa", Updated.MoTa);
            obj[11] = new SqlParameter("GT_NoiDung", Updated.NoiDung);
            obj[12] = new SqlParameter("GT_XuatXu", Updated.XuatXu);
            obj[13] = new SqlParameter("GT_Anh", Updated.Anh);
            obj[14] = new SqlParameter("GT_NgayHetHan", Updated.NgayHetHan);
            obj[15] = new SqlParameter("GT_NguoiTao", Updated.NguoiTao);
            obj[16] = new SqlParameter("GT_NgayTao", Updated.NgayTao);
            obj[17] = new SqlParameter("GT_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[18] = new SqlParameter("GT_NgayCapNhat", Updated.NgayCapNhat);
            obj[19] = new SqlParameter("GT_Views", Updated.Views);
            //obj[20] = new SqlParameter("GT_Active", Updated.Active);
            obj[20] = new SqlParameter("GT_Publish", Updated.Publish);
            //obj[22] = new SqlParameter("GT_Hot1", Updated.Hot1);
            //obj[23] = new SqlParameter("GT_Hot2", Updated.Hot2);
            //obj[24] = new SqlParameter("GT_Hot3", Updated.Hot3);
            //obj[25] = new SqlParameter("GT_Hot4", Updated.Hot4);
            obj[21] = new SqlParameter("GT_RowId", Updated.RowId);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaoThuong SelectById(Int32 GT_ID)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GT_ID", GT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaoThuong SelectByUser(string user)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("user", user);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblGiaoThuong_Select_getByUser_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GiaoThuong SelectCountLang(int GT_ID, string Lang)
        {
            GiaoThuong Item = new GiaoThuong();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("GT_ID", GT_ID);
            obj[1] = new SqlParameter("Lang", Lang);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblGiaoThuong_Select_Lang_getById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static GiaoThuongCollection SelectgetByLangBasedId(int LangBased_ID)
        {
            GiaoThuongCollection List = new GiaoThuongCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("LangBased_ID", LangBased_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblGiaoThuong_Select_getByLangBasedId_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static GiaoThuongCollection SelectAll()
        {
            GiaoThuongCollection List = new GiaoThuongCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblGiaoThuong_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GiaoThuong> pagerNormal(string url, bool rewrite, string sort, string q, string dm, string user, string active, string publish, string Lang, int size, string dmkv, string muaban, string trangthai)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q",DBNull.Value);
            }
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(user))
            {
                obj[3] = new SqlParameter("user", user);
            }
            else
            {
                obj[3] = new SqlParameter("user", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(active))
            {
                obj[4] = new SqlParameter("active", active);
            }
            else
            {
                obj[4] = new SqlParameter("active", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(publish))
            {
                obj[5] = new SqlParameter("publish", publish);
            }
            else
            {
                obj[5] = new SqlParameter("publish", DBNull.Value);
            }
            
            obj[6] = new SqlParameter("Lang", Lang);
            if (!string.IsNullOrEmpty(dmkv))
            {
                obj[7] = new SqlParameter("dmkv", dmkv);
            }
            else
            {
                obj[7] = new SqlParameter("dmkv", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(muaban))
            {
                obj[8] = new SqlParameter("muaban", muaban);
            }
            else
            {
                obj[8] = new SqlParameter("muaban", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(trangthai))
            {
                obj[9] = new SqlParameter("trangthai", trangthai);
            }
            else
            {
                obj[9] = new SqlParameter("trangthai", DBNull.Value);
            }

            Pager<GiaoThuong> pg = new Pager<GiaoThuong>("sp_tblGiaoThuong_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static GiaoThuong getFromReader(IDataReader rd)
        {
            GiaoThuong Item = new GiaoThuong();
            if (rd.FieldExists("GT_ID"))
            {
                Item.ID = (Int32)(rd["GT_ID"]);
            }
            if (rd.FieldExists("GT_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["GT_DM_ID"]);
            }
            if (rd.FieldExists("GT_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["GT_GH_ID"]);
            }
            if (rd.FieldExists("GT_KV_ID"))
            {
                Item.KV_ID = (Int32)(rd["GT_KV_ID"]);
            }
            if (rd.FieldExists("GT_Mua"))
            {
                Item.Mua = (Boolean)(rd["GT_Mua"]);
            }
            if (rd.FieldExists("GT_Lang"))
            {
                Item.Lang = (String)(rd["GT_Lang"]);
            }
            if (rd.FieldExists("GT_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["GT_LangBased"]);
            }
            if (rd.FieldExists("GT_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["GT_LangBased_ID"]);
            }
            if (rd.FieldExists("GT_Alias"))
            {
                Item.Alias = (String)(rd["GT_Alias"]);
            }
            if (rd.FieldExists("GT_Ten"))
            {
                Item.Ten = (String)(rd["GT_Ten"]);
            }
            if (rd.FieldExists("GT_MoTa"))
            {
                Item.MoTa = (String)(rd["GT_MoTa"]);
            }
            if (rd.FieldExists("GT_NoiDung"))
            {
                Item.NoiDung = (String)(rd["GT_NoiDung"]);
            }
            if (rd.FieldExists("GT_XuatXu"))
            {
                Item.XuatXu = (String)(rd["GT_XuatXu"]);
            }
            if (rd.FieldExists("GT_Anh"))
            {
                Item.Anh = (String)(rd["GT_Anh"]);
            }
            if (rd.FieldExists("GT_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["GT_NgayHetHan"]);
            }
            if (rd.FieldExists("GT_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["GT_NguoiTao"]);
            }
            if (rd.FieldExists("GT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GT_NgayTao"]);
            }
            if (rd.FieldExists("GT_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["GT_NguoiCapNhat"]);
            }
            if (rd.FieldExists("GT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GT_NgayCapNhat"]);
            }
            if (rd.FieldExists("GT_Views"))
            {
                Item.Views = (Int64)(rd["GT_Views"]);
            }
            if (rd.FieldExists("GT_Active"))
            {
                Item.Active = (Boolean)(rd["GT_Active"]);
            }
            if (rd.FieldExists("GT_Publish"))
            {
                Item.Publish = (Boolean)(rd["GT_Publish"]);
            }
            if (rd.FieldExists("GT_Hot1"))
            {
                Item.Hot1 = (Boolean)(rd["GT_Hot1"]);
            }
            if (rd.FieldExists("GT_Hot2"))
            {
                Item.Hot2 = (Boolean)(rd["GT_Hot2"]);
            }
            if (rd.FieldExists("GT_Hot3"))
            {
                Item.Hot3 = (Boolean)(rd["GT_Hot3"]);
            }
            if (rd.FieldExists("GT_Hot4"))
            {
                Item.Hot4 = (Boolean)(rd["GT_Hot4"]);
            }
            if (rd.FieldExists("GT_RowId"))
            {
                Item.RowId = (Guid)(rd["GT_RowId"]);
            }
            if (rd.FieldExists("_GiaoThuongh_Ten"))
            {
                Item._GiaoThuongh_Ten = (String)(rd["_GiaoThuongh_Ten"]);
            }
            if (rd.FieldExists("_DM_Ten"))
            {
                Item._DM_Ten = (String)(rd["_DM_Ten"]);
            }
            if (rd.FieldExists("COUNTLANG"))
            {
                Item.COUNTLANG = (Int32)(rd["COUNTLANG"]);
            }
            if (rd.FieldExists("MEM_ID"))
            {
                Item._MEM_ID = (Int32)(rd["MEM_ID"]);
            }
            if (rd.FieldExists("CQ_ID"))
            {
                Item._CQ_ID = (Int32)(rd["CQ_ID"]);
            }
            if (rd.FieldExists("MEM_Username"))
            {
                Item._MEM_Username = (String)(rd["MEM_Username"]);
            }
            if (rd.FieldExists("CQ_Ten"))
            {
                Item._CQ_Ten = (String)(rd["CQ_Ten"]);
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
