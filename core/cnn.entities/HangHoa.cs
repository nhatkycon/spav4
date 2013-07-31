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
namespace cnn.entities
{
    #region HangHoa
    #region BO
    [Serializable()]
    public class HangHoa : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 DM_ID { get; set; }
        public Int32 GH_ID { get; set; }
        public Int32 XuatXu_ID { get; set; }
        public String Lang { get; set; }
        public Int32 LangBased_ID { get; set; }
        public Boolean LangBased { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public Double GNY { get; set; }
        public Double GiaNhap { get; set; }
        public Int32 DonVi_ID { get; set; }
        public Double SoLuong { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public String Anh { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public Boolean Home { get; set; }
        public Boolean Hot1 { get; set; }
        public Boolean Hot2 { get; set; }
        public Boolean Hot3 { get; set; }
        public Boolean Hot4 { get; set; }
        public Int16 P1 { get; set; }
        public DateTime NgayBD_DK_SPDT { get; set; }
        public DateTime NgayKT_DK_SPDT { get; set; }
        
        #endregion
        #region Contructor
        public HangHoa()
        { }
        public HangHoa(Int32? id, Int32? dm_id, Int32? gh_id, Int32? xuatxu_id, String lang, Int32? langbased_id, Boolean? langbased, String alias, String ten, String keywords, String description, String mota, String noidung, Double? gny, Double? gianhap, Int32? donvi_id, Double? soluong, Guid? rowid, DateTime? ngaytao, String nguoitao, DateTime? ngaycapnhat, String nguoicapnhat, String anh, Boolean? publish, Boolean? active, Boolean? home, Boolean? hot1, Boolean? hot2, Boolean? hot3, Boolean? hot4, Int16? p1, DateTime? ngaybd_dk_spdt, DateTime? ngaykt_dk_spdt, String tendanhmuc)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            if (gh_id != null)
            {
                GH_ID = gh_id.Value;
            }
            if (xuatxu_id != null)
            {
                XuatXu_ID = xuatxu_id.Value;
            }
            Lang = lang;
            if (langbased_id != null)
            {
                LangBased_ID = langbased_id.Value;
            }
            if (langbased != null)
            {
                LangBased = langbased.Value;
            }
            Alias = alias;
            Ten = ten;
            Keywords = keywords;
            Description = description;
            MoTa = mota;
            NoiDung = noidung;
            _DM_Ten = tendanhmuc;
            if (gny != null)
            {
                GNY = gny.Value;
            }
            if (gianhap != null)
            {
                GiaNhap = gianhap.Value;
            }
            if (donvi_id != null)
            {
                DonVi_ID = donvi_id.Value;
            }
            if (soluong != null)
            {
                SoLuong = soluong.Value;
            }
            if (rowid != null)
            {
                RowId = rowid.Value;
            }
            if (ngaybd_dk_spdt != null)
            {
                NgayBD_DK_SPDT = ngaybd_dk_spdt.Value;
            }

            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (ngaykt_dk_spdt != null)
            {
                NgayKT_DK_SPDT = ngaykt_dk_spdt.Value;
            }
            NguoiTao = nguoitao;
            if (ngaycapnhat != null)
            {
                NgayCapNhat = ngaycapnhat.Value;
            }
            NguoiCapNhat = nguoicapnhat;
            Anh = anh;
            if (publish != null)
            {
                Publish = publish.Value;
            }
            if (active != null)
            {
                Active = active.Value;
            }
            if (home != null)
            {
                Home = home.Value;
            }
            if (hot1 != null)
            {
                Hot1 = hot1.Value;
            }
            if (hot2 != null)
            {
                Hot2 = hot2.Value;
            }
            if (hot3 != null)
            {
                Hot3 = hot3.Value;
            }
            if (hot4 != null)
            {
                Hot4 = hot4.Value;
            }
            if (p1 != null)
            {
                P1 = p1.Value;
            }

        }
        #endregion
        #region Customs properties
        public string _DM_Ten { get; set; }
        public string _XuatXu_Ten { get; set; }
        public string _DonVi_Ten { get; set; }
        public string _GH_Ten { get; set; }
        #endregion
        #region Utilities
        public HangHoa(IDataReader rd)
        {
            if (rd.FieldExists("HH_ID"))
            {
                ID = (Int32)(rd["HH_ID"]);
            }
            if (rd.FieldExists("_DM_Ten"))
            {
                _DM_Ten = (String)(rd["_DM_Ten"]);
            }
            if (rd.FieldExists("_XuatXu_Ten"))
            {
                _XuatXu_Ten = (String)(rd["_XuatXu_Ten"]);
            }
            if (rd.FieldExists("_DonVi_Ten"))
            {
                _DonVi_Ten = (String)(rd["_DonVi_Ten"]);
            }
            if (rd.FieldExists("_GH_Ten"))
            {
                _GH_Ten = (String)(rd["_GH_Ten"]);
            }
            if (rd.FieldExists("HH_DM_ID"))
            {
                DM_ID = (Int32)(rd["HH_DM_ID"]);
            }
            if (rd.FieldExists("HH_GH_ID"))
            {
                GH_ID = (Int32)(rd["HH_GH_ID"]);
            }
            if (rd.FieldExists("HH_XuatXu_ID"))
            {
                XuatXu_ID = (Int32)(rd["HH_XuatXu_ID"]);
            }
            if (rd.FieldExists("HH_Lang"))
            {
                Lang = (String)(rd["HH_Lang"]);
            }
            if (rd.FieldExists("HH_LangBased_ID"))
            {
                LangBased_ID = (Int32)(rd["HH_LangBased_ID"]);
            }
            if (rd.FieldExists("HH_LangBased"))
            {
                LangBased = (Boolean)(rd["HH_LangBased"]);
            }
            if (rd.FieldExists("HH_Alias"))
            {
                Alias = (String)(rd["HH_Alias"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_Keywords"))
            {
                Keywords = (String)(rd["HH_Keywords"]);
            }
            if (rd.FieldExists("HH_Description"))
            {
                Description = (String)(rd["HH_Description"]);
            }
            if (rd.FieldExists("HH_MoTa"))
            {
                MoTa = (String)(rd["HH_MoTa"]);
            }
            if (rd.FieldExists("HH_NoiDung"))
            {
                NoiDung = (String)(rd["HH_NoiDung"]);
            }
            if (rd.FieldExists("HH_GNY"))
            {
                GNY = (Double)(rd["HH_GNY"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                GiaNhap = (Double)(rd["HH_GiaNhap"]);
            }
            if (rd.FieldExists("HH_DonVi_ID"))
            {
                DonVi_ID = (Int32)(rd["HH_DonVi_ID"]);
            }
            if (rd.FieldExists("HH_SoLuong"))
            {
                SoLuong = (Double)(rd["HH_SoLuong"]);
            }
            if (rd.FieldExists("HH_RowId"))
            {
                RowId = (Guid)(rd["HH_RowId"]);
            }
            if (rd.FieldExists("HH_NgayTao"))
            {
                NgayTao = (DateTime)(rd["HH_NgayTao"]);
            }
            if (rd.FieldExists("HH_NguoiTao"))
            {
                NguoiTao = (String)(rd["HH_NguoiTao"]);
            }
            if (rd.FieldExists("HH_NgayCapNhat"))
            {
                NgayCapNhat = (DateTime)(rd["HH_NgayCapNhat"]);
            }

            if (rd.FieldExists("HH_NgayBD_DK_SPDT"))
            {
                NgayBD_DK_SPDT = (DateTime)(rd["HH_NgayBD_DK_SPDT"]);
            }
            if (rd.FieldExists("HH_NgayKT_DK_SPDT"))
            {
                NgayKT_DK_SPDT = (DateTime)(rd["HH_NgayKT_DK_SPDT"]);
            }

            if (rd.FieldExists("HH_NguoiCapNhat"))
            {
                NguoiCapNhat = (String)(rd["HH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("HH_Anh"))
            {
                Anh = (String)(rd["HH_Anh"]);
            }
            if (rd.FieldExists("HH_Publish"))
            {
                Publish = (Boolean)(rd["HH_Publish"]);
            }
            if (rd.FieldExists("HH_Active"))
            {
                Active = (Boolean)(rd["HH_Active"]);
            }
            if (rd.FieldExists("HH_Home"))
            {
                Home = (Boolean)(rd["HH_Home"]);
            }
            if (rd.FieldExists("HH_Hot1"))
            {
                Hot1 = (Boolean)(rd["HH_Hot1"]);
            }
            if (rd.FieldExists("HH_Hot2"))
            {
                Hot2 = (Boolean)(rd["HH_Hot2"]);
            }
            if (rd.FieldExists("HH_Hot3"))
            {
                Hot3 = (Boolean)(rd["HH_Hot3"]);
            }
            if (rd.FieldExists("HH_Hot4"))
            {
                Hot4 = (Boolean)(rd["HH_Hot4"]);
            }
            if (rd.FieldExists("HH_P1"))
            {
                P1 = (Int16)(rd["HH_P1"]);
            }
        }
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return (new HangHoa(rd));
        }
        #endregion
    }
    #endregion
    #region Collection
    public class HangHoaCollection : BaseEntityCollection<HangHoa>
    { }
    #endregion
    #region Dal
    public class HangHoaDal
    {
        #region cacheKey
        private const string cacheItem = "Tin-{0}";
        private const string cacheList = "TinList-{0}";
        #endregion
        #region Methods
        public static void UpdateDKSPDacTrung(string ID, string dkspdt, DateTime timebd, DateTime timekt)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("ID", ID);
            if (!string.IsNullOrEmpty(dkspdt))
            {
                obj[1] = new SqlParameter("dkspdt", dkspdt);
            }
            else
            {
                obj[1] = new SqlParameter("dkspdt", DBNull.Value);
            }

            if (timebd != DateTime.MinValue)
            {
                obj[2] = new SqlParameter("timebd", timebd);
            }
            else
            {
                obj[2] = new SqlParameter("timebd", DBNull.Value);
            }
            if (timekt != DateTime.MinValue)
            {
                obj[3] = new SqlParameter("timekt", timekt);
            }
            else
            {
                obj[3] = new SqlParameter("timekt", DBNull.Value);
            }

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_DKSPDACTRUNG", obj);
        }
        public static void DeleteById(Int32 HH_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Delete_DeleteById_linhnx", obj);
            string _key = string.Format(cacheItem, HH_ID);
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                myCache.Remove(_key);
            }
            myCache.RemoveByPattern(cacheList);
        }
        public static HangHoa Insert(HangHoa Inserted)
        {
            HangHoa Item = new HangHoa();
            SqlParameter[] obj = new SqlParameter[31];
            obj[0] = new SqlParameter("HH_DM_ID", Inserted.DM_ID);
            obj[1] = new SqlParameter("HH_GH_ID", Inserted.GH_ID);
            obj[2] = new SqlParameter("HH_XuatXu_ID", Inserted.XuatXu_ID);
            obj[3] = new SqlParameter("HH_Lang", Inserted.Lang);
            obj[4] = new SqlParameter("HH_LangBased_ID", Inserted.LangBased_ID);
            obj[5] = new SqlParameter("HH_LangBased", Inserted.LangBased);
            obj[6] = new SqlParameter("HH_Alias", Inserted.Alias);
            obj[7] = new SqlParameter("HH_Ten", Inserted.Ten);
            obj[8] = new SqlParameter("HH_Ma", Inserted.Ma);
            obj[9] = new SqlParameter("HH_Keywords", Inserted.Keywords);
            obj[10] = new SqlParameter("HH_Description", Inserted.Description);
            obj[11] = new SqlParameter("HH_MoTa", Inserted.MoTa);
            obj[12] = new SqlParameter("HH_NoiDung", Inserted.NoiDung);
            obj[13] = new SqlParameter("HH_GNY", Inserted.GNY);
            obj[14] = new SqlParameter("HH_GiaNhap", Inserted.GiaNhap);
            obj[15] = new SqlParameter("HH_DonVi_ID", Inserted.DonVi_ID);
            obj[16] = new SqlParameter("HH_SoLuong", Inserted.SoLuong);
            obj[17] = new SqlParameter("HH_RowId", Inserted.RowId);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("HH_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[18] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[19] = new SqlParameter("HH_NguoiTao", Inserted.NguoiTao);
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[20] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[21] = new SqlParameter("HH_NguoiCapNhat", Inserted.NguoiCapNhat);
            obj[22] = new SqlParameter("HH_Anh", Inserted.Anh);
            obj[23] = new SqlParameter("HH_Publish", Inserted.Publish);
            obj[24] = new SqlParameter("HH_Active", Inserted.Active);
            obj[25] = new SqlParameter("HH_Home", Inserted.Home);
            obj[26] = new SqlParameter("HH_Hot1", Inserted.Hot1);
            obj[27] = new SqlParameter("HH_Hot2", Inserted.Hot2);
            obj[28] = new SqlParameter("HH_Hot3", Inserted.Hot3);
            obj[29] = new SqlParameter("HH_Hot4", Inserted.Hot4);
            obj[30] = new SqlParameter("HH_P1", Inserted.P1);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new HangHoa(rd);
                }
            }
            string _key = string.Format(cacheItem, Item.ID);
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                myCache.Remove(_key);
            }
            myCache.RemoveByPattern(cacheList);
            myCache.Max(_key, Item);
            return Item;
        }
        public static HangHoa Update(HangHoa Updated)
        {
            HangHoa Item = new HangHoa();
            SqlParameter[] obj = new SqlParameter[32];
            obj[0] = new SqlParameter("HH_ID", Updated.ID);
            obj[1] = new SqlParameter("HH_DM_ID", Updated.DM_ID);
            obj[2] = new SqlParameter("HH_GH_ID", Updated.GH_ID);
            obj[3] = new SqlParameter("HH_XuatXu_ID", Updated.XuatXu_ID);
            obj[4] = new SqlParameter("HH_Lang", Updated.Lang);
            obj[5] = new SqlParameter("HH_LangBased_ID", Updated.LangBased_ID);
            obj[6] = new SqlParameter("HH_LangBased", Updated.LangBased);
            obj[7] = new SqlParameter("HH_Alias", Updated.Alias);
            obj[8] = new SqlParameter("HH_Ten", Updated.Ten);
            obj[9] = new SqlParameter("HH_Ma", Updated.Ma);
            obj[10] = new SqlParameter("HH_Keywords", Updated.Keywords);
            obj[11] = new SqlParameter("HH_Description", Updated.Description);
            obj[12] = new SqlParameter("HH_MoTa", Updated.MoTa);
            obj[13] = new SqlParameter("HH_NoiDung", Updated.NoiDung);
            obj[14] = new SqlParameter("HH_GNY", Updated.GNY);
            obj[15] = new SqlParameter("HH_GiaNhap", Updated.GiaNhap);
            obj[16] = new SqlParameter("HH_DonVi_ID", Updated.DonVi_ID);
            obj[17] = new SqlParameter("HH_SoLuong", Updated.SoLuong);
            obj[18] = new SqlParameter("HH_RowId", Updated.RowId);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[19] = new SqlParameter("HH_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[19] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[20] = new SqlParameter("HH_NguoiTao", Updated.NguoiTao);
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("HH_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[21] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[22] = new SqlParameter("HH_NguoiCapNhat", Updated.NguoiCapNhat);
            obj[23] = new SqlParameter("HH_Anh", Updated.Anh);
            obj[24] = new SqlParameter("HH_Publish", Updated.Publish);
            obj[25] = new SqlParameter("HH_Active", Updated.Active);
            obj[26] = new SqlParameter("HH_Home", Updated.Home);
            obj[27] = new SqlParameter("HH_Hot1", Updated.Hot1);
            obj[28] = new SqlParameter("HH_Hot2", Updated.Hot2);
            obj[29] = new SqlParameter("HH_Hot3", Updated.Hot3);
            obj[30] = new SqlParameter("HH_Hot4", Updated.Hot4);
            obj[31] = new SqlParameter("HH_P1", Updated.P1);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new HangHoa(rd);
                }
            }
            string _key = string.Format(cacheItem, Item.ID);
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                myCache.Remove(_key);                
            }
            myCache.RemoveByPattern(cacheList);
            myCache.Max(_key, Item);
            return Item;
        }
        public static HangHoa SelectById(Int32 HH_ID)
        {
            HangHoa Item = new HangHoa();
            string _key = string.Format(cacheItem, HH_ID);
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                Item = (HangHoa)_obj;
                return Item;
            }
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new HangHoa(rd);
                }
            }
            myCache.Max(_key, Item);
            return Item;
        }
        public static HangHoa SelectByIdHoangDa(Int32 HH_ID)
        {
            HangHoa Item = new HangHoa();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = new HangHoa(rd);
                }
            }
            return Item;
        }


        public static HangHoaCollection SelectAll()
        {
            HangHoaCollection List = new HangHoaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new HangHoa(rd));
                }
            }
            return List;
        }
        public static Pager<HangHoa> pagerNormal(string url, bool rewrite, string sort)
        {
            string _key = string.Format(cacheList, string.Format("pagerNormal{1}{0}", sort, HttpContext.Current.Request["pages"]));
            Pager<HangHoa> pg = new Pager<HangHoa>();
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                pg = (Pager<HangHoa>)_obj;
                return pg;
            }
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            pg = new Pager<HangHoa>("tbl_sp_tblHangHoa_Pager_Normal_linhnx", "pages", 20, 10, rewrite, url, obj);
            myCache.Max(_key, pg);
            return pg;
        }
        #endregion        
        #region Extend
        public static HangHoaCollection getByLangBasedId(string LangBased_ID,string ID)
        {
            HangHoaCollection List = new HangHoaCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("LangBased_ID", LangBased_ID);
            obj[1] = new SqlParameter("ID", ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_getByLangBasedId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(new HangHoa(rd));
                }
            }
            return List;
        }
        public static Pager<HangHoa> pagerLangBased(string sort,int size)
        {
            string _key = string.Format(cacheList, string.Format("pagerLangBased{1}{0}{2}", sort, HttpContext.Current.Request["pages"], size));
            Pager<HangHoa> pg = new Pager<HangHoa>();
            object _obj = myCache.Get(_key);
            if (_obj != null)
            {
                pg = (Pager<HangHoa>)_obj;
                return pg;
            }
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Sort", sort);
            pg = new Pager<HangHoa>("tbl_sp_tblHangHoa_Pager_pagerLangBased_linhnx", "pages", size, 10, false, string.Empty, obj);
            myCache.Max(_key, pg);
            return pg;
        }
        public static HangHoaCollection SelectSanPhamMenuByDmId(SqlConnection con, string DM_ID, int Top)
        {
            HangHoaCollection List = new HangHoaCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectSanPhamMenuByDmId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(new HangHoa(rd));
                }
            }
            return List;
        }
        public static HangHoaCollection SelectAll(SqlConnection con)
        {
            HangHoaCollection List = new HangHoaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblHangHoa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(new HangHoa(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion
    #endregion
    
}


