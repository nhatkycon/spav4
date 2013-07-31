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
using System.Web;
using linh.common;

namespace docsoft.entities
{
    #region Tin
    #region BO
    public class Tin : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String Lang { get; set; }
        public Boolean LangBased { get; set; }
        public Int32 LangBased_ID { get; set; }
        public String Alias { get; set; }
        public String KeyWords { get; set; }
        public String Description { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public String TacGia { get; set; }
        public String Anh { get; set; }
        public Int32 ThuTu { get; set; }
        public String Nguon { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Int32 Views { get; set; }
        public Boolean Hot { get; set; }
        public Boolean Active { get; set; }
        public Boolean Publish { get; set; }
        public Boolean HetHan { get; set; }
        public Boolean Moi { get; set; }
        public Guid RowId { get; set; }
        public String DM_Ma { get; set; }
        #endregion
        #region Contructor
        public Tin()
        { }
        #endregion
        #region Customs properties
        public String multiID { get; set; }
        public List<Files> Filelist { get; set; }
        public string FileListStr { get; set; }
        public string DM_Ten { get; set; }
        public Int32 _ID { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return TinDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class TinCollection : BaseEntityCollection<Tin>
    { }
    #endregion
    #region Dal
    public class TinDal
    {
        #region Methods

        public static void DeleteById(Int64 TIN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Delete_DeleteById_linhnx", obj);
        }

        public static Tin Insert(Tin Inserted)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[28];
            obj[0] = new SqlParameter("TIN_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("TIN_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("TIN_Lang", Inserted.Lang);
            obj[3] = new SqlParameter("TIN_LangBased", Inserted.LangBased);
            obj[4] = new SqlParameter("TIN_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("TIN_Alias", Inserted.Alias);
            obj[6] = new SqlParameter("TIN_Ten", Inserted.Ten);
            obj[7] = new SqlParameter("TIN_MoTa", Inserted.MoTa);
            obj[8] = new SqlParameter("TIN_NoiDung", Inserted.NoiDung);
            obj[9] = new SqlParameter("TIN_TacGia", Inserted.TacGia);
            obj[10] = new SqlParameter("TIN_Anh", Inserted.Anh);
            obj[11] = new SqlParameter("TIN_ThuTu", Inserted.ThuTu);
            obj[12] = new SqlParameter("TIN_Nguon", Inserted.Nguon);
            obj[13] = new SqlParameter("TIN_NgayTao", Inserted.NgayTao);
            obj[14] = new SqlParameter("TIN_NguoiTao", Inserted.NguoiTao);
            obj[15] = new SqlParameter("TIN_NgayCapNhat", Inserted.NgayCapNhat);
            obj[16] = new SqlParameter("TIN_NguoiCapNhat", Inserted.NguoiCapNhat);
            string htl = string.Format("{0:dd/MM/yy}", Inserted.NgayDang);
            if (htl != "01/01/01")
            {
                obj[17] = new SqlParameter("TIN_NgayDang", Inserted.NgayDang);
            }
            else
            {
                obj[17] = new SqlParameter("TIN_NgayDang", DBNull.Value);
            }
            obj[18] = new SqlParameter("TIN_NgayHetHan", Inserted.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Inserted.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[18] = new SqlParameter("TIN_NgayHetHan", Inserted.NgayHetHan);
            }
            else
            {
                obj[18] = new SqlParameter("TIN_NgayHetHan", DBNull.Value);
            }
            //obj[17] = new SqlParameter("TIN_NgayDang", Inserted.NgayDang);
            //obj[18] = new SqlParameter("TIN_NgayHetHan", Inserted.NgayHetHan);
            obj[19] = new SqlParameter("TIN_Views", Inserted.Views);
            obj[20] = new SqlParameter("TIN_Hot", Inserted.Hot);
            obj[21] = new SqlParameter("TIN_Active", Inserted.Active);
            obj[22] = new SqlParameter("TIN_Publish", Inserted.Publish);
            obj[23] = new SqlParameter("TIN_HetHan", Inserted.HetHan);
            obj[24] = new SqlParameter("TIN_Moi", Inserted.Moi);
            obj[25] = new SqlParameter("TIN_RowId", Inserted.RowId);
            obj[26] = new SqlParameter("TIN_KeyWords", Inserted.KeyWords);
            obj[27] = new SqlParameter("TIN_Description", Inserted.Description);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Tin Update(Tin Updated)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[29];
            obj[0] = new SqlParameter("TIN_ID", Updated.ID);
            obj[1] = new SqlParameter("TIN_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("TIN_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("TIN_Lang", Updated.Lang);
            obj[4] = new SqlParameter("TIN_LangBased", Updated.LangBased);
            obj[5] = new SqlParameter("TIN_LangBased_ID", Updated.LangBased_ID);
            obj[6] = new SqlParameter("TIN_Alias", Updated.Alias);
            obj[7] = new SqlParameter("TIN_Ten", Updated.Ten);
            obj[8] = new SqlParameter("TIN_MoTa", Updated.MoTa);
            obj[9] = new SqlParameter("TIN_NoiDung", Updated.NoiDung);
            obj[10] = new SqlParameter("TIN_TacGia", Updated.TacGia);
            obj[11] = new SqlParameter("TIN_Anh", Updated.Anh);
            obj[12] = new SqlParameter("TIN_ThuTu", Updated.ThuTu);
            obj[13] = new SqlParameter("TIN_Nguon", Updated.Nguon);
            obj[14] = new SqlParameter("TIN_NgayTao", Updated.NgayTao);
            obj[15] = new SqlParameter("TIN_NguoiTao", Updated.NguoiTao);
           // obj[16] = new SqlParameter("TIN_NgayCapNhat", Updated.NgayCapNhat);
            string capnhat = string.Format("{0:dd/MM/yy}", Updated.NgayCapNhat);
            if (capnhat != "01/01/01")
            {
                obj[16] = new SqlParameter("TIN_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[16] = new SqlParameter("TIN_NgayCapNhat", DBNull.Value);
            }
            obj[17] = new SqlParameter("TIN_NguoiCapNhat", Updated.NguoiCapNhat);


            string htl = string.Format("{0:dd/MM/yy}", Updated.NgayDang);
            if (htl != "01/01/01")
            {
                obj[18] = new SqlParameter("TIN_NgayDang", Updated.NgayDang);
            }
            else
            {
                obj[18] = new SqlParameter("TIN_NgayDang", DBNull.Value);
            }
           // obj[16] = new SqlParameter("TIN_NgayHetHan", Updated.NgayHetHan);
            string htl1 = string.Format("{0:dd/MM/yy}", Updated.NgayHetHan);
            if (htl1 != "01/01/01")
            {
                obj[19] = new SqlParameter("TIN_NgayHetHan", Updated.NgayHetHan);
            }
            else
            {
                obj[19] = new SqlParameter("TIN_NgayHetHan", DBNull.Value);
            }

            //obj[18] = new SqlParameter("TIN_NgayDang", Updated.NgayDang);
            //obj[19] = new SqlParameter("TIN_NgayHetHan", Updated.NgayHetHan);
            obj[20] = new SqlParameter("TIN_Views", Updated.Views);
            obj[21] = new SqlParameter("TIN_Hot", Updated.Hot);
            obj[22] = new SqlParameter("TIN_Active", Updated.Active);
            obj[23] = new SqlParameter("TIN_Publish", Updated.Publish);
            obj[24] = new SqlParameter("TIN_HetHan", Updated.HetHan);
            obj[25] = new SqlParameter("TIN_Moi", Updated.Moi);
            obj[26] = new SqlParameter("TIN_RowId", Updated.RowId);
            obj[27] = new SqlParameter("TIN_KeyWords", Updated.KeyWords);
            obj[28] = new SqlParameter("TIN_Description", Updated.Description);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static Tin SelectById(Int64 TIN_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static TinCollection SelectAll()
        {
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> pagerNormal(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp,string _Code,string Lang)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            obj[6] = new SqlParameter("Lang", Lang);
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_All", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        /// <summary>
        /// hampv
        /// </summary>
        /// <param name="url"></param>
        /// <param name="rewrite"></param>
        /// <param name="sort"></param>
        /// <param name="q"></param>
        /// <param name="dm"></param>
        /// <param name="nguoitao"></param>
        /// <param name="acp"></param>
        /// <param name="_Code"></param>
        /// <param name="Lang"></param>
        /// <returns></returns>
        public static Pager<Tin> pagerNormalView(SqlConnection cnn, string url, bool rewrite, string sort,  string dm, string _Code, string Lang, int size)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
          
            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }
           
            obj[2] = new SqlParameter("DM_Ma", _Code);
            obj[3] = new SqlParameter("Lang", Lang);
          
            Pager<Tin> pg = new Pager<Tin>(cnn, "sp_tblTin_Pager_Normal_linhnx_AllView", "Pages", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerNormalTin(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            obj[6] = new SqlParameter("Lang", Lang);
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx", "page", 10, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerDuyet(string url, bool rewrite, string sort, string q, string dm, string nguoitao, int acp, string _Code, string Lang)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            obj[6] = new SqlParameter("Lang", Lang);
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_duyet", "page", 10, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<Tin> pagerNormalThongke(string url, bool rewrite, string sort, string q, string dm, string nguoitao, string _tungay, string _denngay, int acp, string _Code)
        {
            SqlParameter[] obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            if (!string.IsNullOrEmpty(dm))
            {
                obj[2] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[2] = new SqlParameter("dm_id", DBNull.Value);
            }
            obj[3] = new SqlParameter("acp", acp);
            obj[4] = new SqlParameter("NguoiTao", nguoitao);
            obj[5] = new SqlParameter("DM_Ma", _Code);
            if (!string.IsNullOrEmpty(_tungay))
            {
                obj[6] = new SqlParameter("TuNgay", _tungay);
            }
            else
            {
                obj[6] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(_denngay))
            {
                obj[7] = new SqlParameter("DenNgay", _denngay);
            }
            else
            {
                obj[7] = new SqlParameter("DenNgay", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_Normal_linhnx_KT", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Tin getFromReader(IDataReader rd)
        {
            Tin Item = new Tin();
            if (rd.FieldExists("TIN_ID"))
            {
                Item.ID = (Int32)(rd["TIN_ID"]);
            }
            if (rd.FieldExists("_TIN_ID"))
            {
                Item._ID = (Int32)(rd["_TIN_ID"]);
            }
            if (rd.FieldExists("TIN_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["TIN_GH_ID"]);
            }
            if (rd.FieldExists("TIN_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["TIN_DM_ID"]);
            }
            if (rd.FieldExists("TIN_Lang"))
            {
                Item.Lang = (String)(rd["TIN_Lang"]);
            }
            if (rd.FieldExists("TIN_LangBased"))
            {
                Item.LangBased = (Boolean)(rd["TIN_LangBased"]);
            }
            if (rd.FieldExists("TIN_LangBased_ID"))
            {
                Item.LangBased_ID = (Int32)(rd["TIN_LangBased_ID"]);
            }
            if (rd.FieldExists("TIN_Alias"))
            {
                Item.Alias = (String)(rd["TIN_Alias"]);
            }
            if (rd.FieldExists("TIN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TIN_DM_Ten"]);
            }
            if (rd.FieldExists("TIN_Ten"))
            {
                Item.Ten = (String)(rd["TIN_Ten"]);
            }
            if (rd.FieldExists("TIN_MoTa"))
            {
                Item.MoTa = (String)(rd["TIN_MoTa"]);
            }
            if (rd.FieldExists("TIN_NoiDung"))
            {
                Item.NoiDung = (String)(rd["TIN_NoiDung"]);
            }
            if (rd.FieldExists("TIN_KeyWords"))
            {
                Item.KeyWords = (String)(rd["TIN_KeyWords"]);
            }
            if (rd.FieldExists("TIN_Description"))
            {
                Item.Description = (String)(rd["TIN_Description"]);
            }
            if (rd.FieldExists("TIN_TacGia"))
            {
                Item.TacGia = (String)(rd["TIN_TacGia"]);
            }
            if (rd.FieldExists("TIN_Anh"))
            {
                Item.Anh = (String)(rd["TIN_Anh"]);
            }
            if (rd.FieldExists("TIN_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["TIN_ThuTu"]);
            }
            if (rd.FieldExists("TIN_Nguon"))
            {
                Item.Nguon = (String)(rd["TIN_Nguon"]);
            }
            if (rd.FieldExists("TIN_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TIN_NgayTao"]);
            }
            if (rd.FieldExists("TIN_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["TIN_NguoiTao"]);
            }
            if (rd.FieldExists("TIN_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TIN_NgayCapNhat"]);
            }
            if (rd.FieldExists("TIN_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["TIN_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TIN_NgayDang"))
            {
                Item.NgayDang = (DateTime)(rd["TIN_NgayDang"]);
            }
            if (rd.FieldExists("TIN_NgayHetHan"))
            {
                Item.NgayHetHan = (DateTime)(rd["TIN_NgayHetHan"]);
            }
            if (rd.FieldExists("TIN_Views"))
            {
                Item.Views = (Int32)(rd["TIN_Views"]);
            }
            if (rd.FieldExists("TIN_Hot"))
            {
                Item.Hot = (Boolean)(rd["TIN_Hot"]);
            }
            if (rd.FieldExists("TIN_Active"))
            {
                Item.Active = (Boolean)(rd["TIN_Active"]);
            }
            if (rd.FieldExists("TIN_Publish"))
            {
                Item.Publish = (Boolean)(rd["TIN_Publish"]);
            }
            if (rd.FieldExists("TIN_HetHan"))
            {
                Item.HetHan = (Boolean)(rd["TIN_HetHan"]);
            }
            if (rd.FieldExists("TIN_Moi"))
            {
                Item.Moi = (Boolean)(rd["TIN_Moi"]);
            }
            if (rd.FieldExists("TIN_RowId"))
            {
                Item.RowId = (Guid)(rd["TIN_RowId"]);
            }
            if (rd.FieldExists("TIN_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["TIN_DM_Ten"]);
            }
            if (rd.FieldExists("TIN_DM_Ma"))
            {
                Item.DM_Ma = (String)(rd["TIN_DM_Ma"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static void DeleteMultiById(String TIN_ID, string DM_Ma)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_ID);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Delete_DeleteMultiById_hungpm", obj);
        }
        public static void UpdateHotMulti(Tin TIN_Hot)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Hot.multiID);
            obj[1] = new SqlParameter("TIN_Hot", TIN_Hot.Hot);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateHotMultiById_hungpm", obj);
        }
        public static void UpdateMulti(Tin TIN_Active)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("TIN_ID", TIN_Active.multiID);
            obj[1] = new SqlParameter("TIN_Active", TIN_Active.Active);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateMultiById_hungpm", obj);
        }
        public static void UpdateHetHanMulti(Tin TinHetHan)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("TIN_ID", TinHetHan.multiID);
            obj[1] = new SqlParameter("TIN_HetHan", TinHetHan.HetHan);
            obj[2] = new SqlParameter("TIN_NgayHetHan", TinHetHan.NgayHetHan);
            string htl = string.Format("{0:dd/MM/yy}", TinHetHan.NgayHetHan);
            if (htl != "01/01/01")
            {
                obj[2] = new SqlParameter("TIN_NgayHetHan", TinHetHan.NgayHetHan);
            }
            else
            {
                obj[2] = new SqlParameter("TIN_NgayHetHan", DBNull.Value);
            }
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Update_UpdateHetHanMultiById_hungpm", obj);
        }      
        public static TinCollection SelectTopTen()
        {
            TinCollection List = new TinCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTopTen_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTop(int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTop_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectDanhSachHome(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectDanhSachHome_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopThongBao(int top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("top", top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tblRss_sp_tblRssTin_Select_SelectTopThongBao_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection byDanhMuc(int top,string dm_id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection byLoaiDanhMuc(int top, string dm_id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("dm_id", dm_id);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssTin_Select_byLoaiDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static string formatSlides(Tin item)
        {
            HttpContext c = HttpContext.Current;
            string domain = string.Format("http://{0}{1}", c.Request.Url.Host, c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : "");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""slide"">
    <a href=""{0}/{2}/{5}.html"" target=""_blank"">
    <img class=""slide-item-img"" src=""{0}/lib/up/tintuc/{1}""></a>
    <div class=""caption"">
    <p><b>{3}</b><br/>{4}</p>
    </div>
</div>", domain
                , Lib.imgSize(item.Anh, "280x210")
                , item.Alias
                , item.Ten
                , item.MoTa
                , item.ID);
            return sb.ToString();
        }
        public static TinCollection GetTinbyMaDanhMuc(int top, string DM_Ma)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("top", top);
            obj[1] = new SqlParameter("DM_Ma", DM_Ma);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRssTin_Select_byDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMuc(string DM_Ma,int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMuc(SqlConnection con, string DM_Ma, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_Ma", DM_Ma);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMuc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMuc(string DM_ID, int Top, DateTime NgayCapNhat)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            obj[2] = new SqlParameter("NgayCapNhat", NgayCapNhat);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMucID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDanhMucNew(string DM_ID, int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDanhMucNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectByDiemBaoNew( int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
          
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByDiemBaoNewID_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection SelectTopHot(int Top)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectTopHot_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Tin> pagerByDanhMuc(string url, bool rewrite, string sort, string dm)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_pagerByDanhMuc_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Tin> pagerByDanhMuc(string url, bool rewrite, string sort, string dm, int Top)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(dm))
            {
                obj[1] = new SqlParameter("dm_id", dm);
            }
            else
            {
                obj[1] = new SqlParameter("dm_id", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_pagerByDanhMuc_linhnx", "page", Top, 10, rewrite, url, obj);
            return pg;
        }
        public static TinCollection lienQuan(int Top, string Id, int dmId)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            obj[2] = new SqlParameter("DM_ID", dmId);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_lienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection lienQuanCuHon(SqlConnection con, int Top, string Id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_lienQuanCuHon_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static TinCollection lienQuanMoiHon(SqlConnection con, int Top, string Id)
        {
            TinCollection List = new TinCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Id", Id);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblTin_Select_lienQuanMoiHon_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Tin SelectByIdView(Int32 VBD_ID)
        {
            Tin Item = new Tin();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TIN_ID", VBD_ID);
            List<Files> filelist = new List<Files>();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblTin_Select_SelectByIdView_linhnx", obj))
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
        public static Pager<Tin> pagerBySearch(string url, bool rewrite, string sort, string q)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            Pager<Tin> pg = new Pager<Tin>("sp_tblTin_Pager_pagerBySearch_linhnx", "page", 20, 10, rewrite, url, obj);
            return pg;
        }


        #endregion
    }
    #endregion
    #endregion
}
