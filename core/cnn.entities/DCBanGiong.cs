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
    #region DiaChiBanGiong
    #region BO
    public class DiaChiBanGiong : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public String Ten { get; set; }
        public String Anh { get; set; }
        public String NoiDung { get; set; }
        public String Mota { get; set; }
        public DateTime NgayTao { get; set; }
        public String NoiDang { get; set; }
        public String DiaChi { get; set; }
        public String DienThoai { get; set; }
        public String Mobie { get; set; }
        public Int32 DM_ID { get; set; }
        public Guid RowId { get; set; }
        public Guid PRowId { get; set; }
        public Guid CRowId { get; set; }
        public String NguoiTao { get; set; }
        public String NguoiLienHe { get; set; }
        public Boolean Type { get; set; }
        public String Email { get; set; }
        public Int32 DonViTinh { get; set; }
        public Double Gia { get; set; }
        public Int64 STT { get; set; }
        #endregion
        #region Contructor
        public DiaChiBanGiong()
        { }
        #endregion
        #region Customs properties
        public String _DM_Ten { get; set; }
        public String _DM_DonVi { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DiaChiBanGiongDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DiaChiBanGiongCollection : BaseEntityCollection<DiaChiBanGiong>
    { }
    #endregion
    #region Dal
    public class DiaChiBanGiongDal
    {
        #region Methods

        public static void DeleteById(Int32 DCBG_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DCBG_ID", DCBG_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Delete_DeleteById_hoangda", obj);
        }

        public static DiaChiBanGiong Insert(DiaChiBanGiong Inserted)
        {
            DiaChiBanGiong Item = new DiaChiBanGiong();
            SqlParameter[] obj = new SqlParameter[19];
            obj[0] = new SqlParameter("DCBG_Ten", Inserted.Ten);
            obj[1] = new SqlParameter("DCBG_Anh", Inserted.Anh);
            obj[2] = new SqlParameter("DCBG_NoiDung", Inserted.NoiDung);
            obj[3] = new SqlParameter("DCBG_Mota", Inserted.Mota);
            obj[4] = new SqlParameter("DCBG_NgayTao", Inserted.NgayTao);
            obj[5] = new SqlParameter("DCBG_NoiDang", Inserted.NoiDang);
            obj[6] = new SqlParameter("DCBG_DiaChi", Inserted.DiaChi);
            obj[7] = new SqlParameter("DCBG_DienThoai", Inserted.DienThoai);
            obj[8] = new SqlParameter("DCBG_Mobie", Inserted.Mobie);
            obj[9] = new SqlParameter("DCBG_DM_ID", Inserted.DM_ID);
            obj[10] = new SqlParameter("DCBG_RowId", Inserted.RowId);
            obj[11] = new SqlParameter("DCBG_PRowId", Inserted.PRowId);
            obj[12] = new SqlParameter("DCBG_CRowId", Inserted.CRowId);
            obj[13] = new SqlParameter("DCBG_NguoiTao", Inserted.NguoiTao);
            obj[14] = new SqlParameter("DCBG_NguoiLienHe", Inserted.NguoiLienHe);
            obj[15] = new SqlParameter("DCBG_Type", Inserted.Type);
            obj[16] = new SqlParameter("DCBG_Email", Inserted.Email);
            obj[17] = new SqlParameter("DCBG_DonViTinh", Inserted.DonViTinh);
            obj[18] = new SqlParameter("DCBG_Gia", Inserted.Gia);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DiaChiBanGiong Update(DiaChiBanGiong Updated)
        {
            DiaChiBanGiong Item = new DiaChiBanGiong();
            SqlParameter[] obj = new SqlParameter[20];
            obj[0] = new SqlParameter("DCBG_ID", Updated.ID);
            obj[1] = new SqlParameter("DCBG_Ten", Updated.Ten);
            obj[2] = new SqlParameter("DCBG_Anh", Updated.Anh);
            obj[3] = new SqlParameter("DCBG_NoiDung", Updated.NoiDung);
            obj[4] = new SqlParameter("DCBG_Mota", Updated.Mota);
            obj[5] = new SqlParameter("DCBG_NgayTao", Updated.NgayTao);
            obj[6] = new SqlParameter("DCBG_NoiDang", Updated.NoiDang);
            obj[7] = new SqlParameter("DCBG_DiaChi", Updated.DiaChi);
            obj[8] = new SqlParameter("DCBG_DienThoai", Updated.DienThoai);
            obj[9] = new SqlParameter("DCBG_Mobie", Updated.Mobie);
            obj[10] = new SqlParameter("DCBG_DM_ID", Updated.DM_ID);
            obj[11] = new SqlParameter("DCBG_RowId", Updated.RowId);
            obj[12] = new SqlParameter("DCBG_PRowId", Updated.PRowId);
            obj[13] = new SqlParameter("DCBG_CRowId", Updated.CRowId);
            obj[14] = new SqlParameter("DCBG_NguoiTao", Updated.NguoiTao);
            obj[15] = new SqlParameter("DCBG_NguoiLienHe", Updated.NguoiLienHe);
            obj[16] = new SqlParameter("DCBG_Type", Updated.Type);
            obj[17] = new SqlParameter("DCBG_Email", Updated.Email);
            obj[18] = new SqlParameter("DCBG_DonViTinh", Updated.DonViTinh);
            obj[19] = new SqlParameter("DCBG_Gia", Updated.Gia);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DiaChiBanGiong SelectById(Int32 DCBG_ID)
        {
            DiaChiBanGiong Item = new DiaChiBanGiong();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DCBG_ID", DCBG_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DiaChiBanGiongCollection SelectAll()
        {
            DiaChiBanGiongCollection List = new DiaChiBanGiongCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DiaChiBanGiong> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", DBNull.Value);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            Pager<DiaChiBanGiong> pg = new Pager<DiaChiBanGiong>("sp_tblDiaChiBanGiong_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<DiaChiBanGiong> pagerNormal(string url, bool rewrite, string sort, string q, int size,string Username, string DM_ID)
        {
            SqlParameter[] obj = new SqlParameter[4];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Username))
            {
                obj[2] = new SqlParameter("Username", Username);
            }
            else
            {
                obj[2] = new SqlParameter("Username", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[3] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[3] = new SqlParameter("DM_ID", DBNull.Value);
            }
            Pager<DiaChiBanGiong> pg = new Pager<DiaChiBanGiong>("sp_tblDiaChiBanGiong_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DiaChiBanGiong getFromReader(IDataReader rd)
        {
            DiaChiBanGiong Item = new DiaChiBanGiong();
            if (rd.FieldExists("DCBG_ID"))
            {
                Item.ID = (Int32)(rd["DCBG_ID"]);
            }
            if (rd.FieldExists("DCBG_Ten"))
            {
                Item.Ten = (String)(rd["DCBG_Ten"]);
            }
            if (rd.FieldExists("DCBG_Anh"))
            {
                Item.Anh = (String)(rd["DCBG_Anh"]);
            }
            if (rd.FieldExists("DCBG_NoiDung"))
            {
                Item.NoiDung = (String)(rd["DCBG_NoiDung"]);
            }
            if (rd.FieldExists("DCBG_Mota"))
            {
                Item.Mota = (String)(rd["DCBG_Mota"]);
            }
            if (rd.FieldExists("DCBG_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DCBG_NgayTao"]);
            }
            if (rd.FieldExists("DCBG_NoiDang"))
            {
                Item.NoiDang = (String)(rd["DCBG_NoiDang"]);
            }
            if (rd.FieldExists("DCBG_DiaChi"))
            {
                Item.DiaChi = (String)(rd["DCBG_DiaChi"]);
            }
            if (rd.FieldExists("DCBG_DienThoai"))
            {
                Item.DienThoai = (String)(rd["DCBG_DienThoai"]);
            }
            if (rd.FieldExists("DCBG_Mobie"))
            {
                Item.Mobie = (String)(rd["DCBG_Mobie"]);
            }
            if (rd.FieldExists("DCBG_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["DCBG_DM_ID"]);
            }
            if (rd.FieldExists("DCBG_RowId"))
            {
                Item.RowId = (Guid)(rd["DCBG_RowId"]);
            }
            if (rd.FieldExists("DCBG_PRowId"))
            {
                Item.PRowId = (Guid)(rd["DCBG_PRowId"]);
            }
            if (rd.FieldExists("DCBG_CRowId"))
            {
                Item.CRowId = (Guid)(rd["DCBG_CRowId"]);
            }
            if (rd.FieldExists("DCBG_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["DCBG_NguoiTao"]);
            }
            if (rd.FieldExists("DCBG_NguoiLienHe"))
            {
                Item.NguoiLienHe = (String)(rd["DCBG_NguoiLienHe"]);
            }
            if (rd.FieldExists("DCBG_Type"))
            {
                Item.Type = (Boolean)(rd["DCBG_Type"]);
            }
            if (rd.FieldExists("DCBG_Email"))
            {
                Item.Email = (String)(rd["DCBG_Email"]);
            }
            if (rd.FieldExists("DCBG_DonViTinh"))
            {
                Item.DonViTinh = (Int32)(rd["DCBG_DonViTinh"]);
            }
            if (rd.FieldExists("DCBG_Gia"))
            {
                Item.Gia = (Double)(rd["DCBG_Gia"]);
            }
            if (rd.FieldExists("_DM_Ten"))
            {
                Item._DM_Ten = (String)(rd["_DM_Ten"]);
            }
            if (rd.FieldExists("_DM_DonVi"))
            {
                Item._DM_DonVi = (String)(rd["_DM_DonVi"]);
            }
            if (rd.FieldExists("STT"))
            {
                Item.STT = Convert.ToInt64(rd["STT"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DiaChiBanGiongCollection SelectTopDCBG(SqlConnection con, Int32 Top)
        {
            DiaChiBanGiongCollection List = new DiaChiBanGiongCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Select_SelectTop_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DiaChiBanGiongCollection SelectbeetwenDCBG(SqlConnection con, Int32 Top, Int32 Bottom, int DM_ID)
        {
            DiaChiBanGiongCollection List = new DiaChiBanGiongCollection();
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("Bottom", Bottom);
            obj[2] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblDiaChiBanGiong_Select_Selectbeetween_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static DiaChiBanGiongCollection SelectTreeParentByDmId(int DM_ID)
        {
            DiaChiBanGiongCollection List = new DiaChiBanGiongCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DM_ID", DM_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_DanhMuc_Select_Select_TreeParentByDmId_hoangda", obj))
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
