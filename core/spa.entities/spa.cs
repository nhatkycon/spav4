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
    #region Spa
    #region BO
    public class Spa : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 KV_ID { get; set; }
        public Int32 DM_ID { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String Mota { get; set; }
        public String NoiDung { get; set; }
        public String Anh { get; set; }
        public String DiaChi { get; set; }
        public String Mobile { get; set; }
        public String Phone { get; set; }
        public String ToaDo { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Moi { get; set; }
        public Boolean KhuyenMai { get; set; }
        public Boolean KhaiTruong { get; set; }
        public Int32 Diem { get; set; }
        public Int32 SolanDanhGia { get; set; }
        public Byte Sao { get; set; }
        public Guid RowId { get; set; }
        public String Website { get; set; }
        public String Email { get; set; }
        public Int32 LoaiThanhVien { get; set; }
        public Boolean BaoDam { get; set; }
        #endregion
        #region Contructor
        public Spa()
        { }
        public Spa(Int32? id, Int32? kv_id, Int32? dm_id, String alias, String ten, String mota, String noidung, String anh, String diachi, String mobile, String phone, String toado, DateTime? ngaytao, DateTime? ngaycapnhat, Boolean? publish, Boolean? moi, Boolean? khuyenmai, Boolean? khaitruong, Int32? diem, Int32? solandanhgia, Byte? sao, Guid? rowid)
        {
            if (id != null)
            {
                ID = id.Value;
            }
            if (kv_id != null)
            {
                KV_ID = kv_id.Value;
            }
            if (dm_id != null)
            {
                DM_ID = dm_id.Value;
            }
            Alias = alias;
            Ten = ten;
            Mota = mota;
            NoiDung = noidung;
            Anh = anh;
            DiaChi = diachi;
            Mobile = mobile;
            Phone = phone;
            ToaDo = toado;
            if (ngaytao != null)
            {
                NgayTao = ngaytao.Value;
            }
            if (ngaycapnhat != null)
            {
                NgayCapNhat = ngaycapnhat.Value;
            }
            if (publish != null)
            {
                Publish = publish.Value;
            }
            if (moi != null)
            {
                Moi = moi.Value;
            }
            if (khuyenmai != null)
            {
                KhuyenMai = khuyenmai.Value;
            }
            if (khaitruong != null)
            {
                KhaiTruong = khaitruong.Value;
            }
            if (diem != null)
            {
                Diem = diem.Value;
            }
            if (solandanhgia != null)
            {
                SolanDanhGia = solandanhgia.Value;
            }
            if (sao != null)
            {
                Sao = sao.Value;
            }
            if (rowid != null)
            {
                RowId = rowid.Value;
            }

        }
        #endregion
        #region Customs properties
        public string KV_Ten { get; set; }
        public string DM_Ten { get; set; }
        public List<SpaAnh> _SpaAnh { get; set; }
        public List<SpaDichVu> _SpaDichVu { get; set; }
        public List<SpaKhuyenMai> _SpaKhuyen { get; set; }
        public Int32 Comments { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SpaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SpaCollection : BaseEntityCollection<Spa>
    { }
    #endregion
    #region Dal
    public class SpaDal
    {
        #region Methods

        public static void DeleteById(Int32 SPA_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SPA_ID", SPA_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Delete_DeleteById_linhnx", obj);
        }
        public static Spa Insert(Spa Inserted)
        {
            Spa Item = new Spa();
            SqlParameter[] obj = new SqlParameter[25];
            obj[0] = new SqlParameter("SPA_KV_ID", Inserted.KV_ID);
            obj[1] = new SqlParameter("SPA_DM_ID", Inserted.DM_ID);
            obj[2] = new SqlParameter("SPA_Alias", Inserted.Alias);
            obj[3] = new SqlParameter("SPA_Ten", Inserted.Ten);
            obj[4] = new SqlParameter("SPA_Mota", Inserted.Mota);
            obj[5] = new SqlParameter("SPA_NoiDung", Inserted.NoiDung);
            obj[6] = new SqlParameter("SPA_Anh", Inserted.Anh);
            obj[7] = new SqlParameter("SPA_DiaChi", Inserted.DiaChi);
            obj[8] = new SqlParameter("SPA_Mobile", Inserted.Mobile);
            obj[9] = new SqlParameter("SPA_Phone", Inserted.Phone);
            obj[10] = new SqlParameter("SPA_ToaDo", Inserted.ToaDo);
            if (Inserted.NgayTao > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("SPA_NgayTao", Inserted.NgayTao);
            }
            else
            {
                obj[11] = new SqlParameter("SPA_NgayTao", DBNull.Value);
            }
            if (Inserted.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SPA_NgayCapNhat", Inserted.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("SPA_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("SPA_Publish", Inserted.Publish);
            obj[14] = new SqlParameter("SPA_Moi", Inserted.Moi);
            obj[15] = new SqlParameter("SPA_KhuyenMai", Inserted.KhuyenMai);
            obj[16] = new SqlParameter("SPA_KhaiTruong", Inserted.KhaiTruong);
            obj[17] = new SqlParameter("SPA_Diem", Inserted.Diem);
            obj[18] = new SqlParameter("SPA_SolanDanhGia", Inserted.SolanDanhGia);
            obj[19] = new SqlParameter("SPA_Sao", Inserted.Sao);
            obj[20] = new SqlParameter("SPA_RowId", Inserted.RowId);
            obj[21] = new SqlParameter("SPA_Website", Inserted.Website);
            obj[22] = new SqlParameter("SPA_Email", Inserted.Email);
            obj[23] = new SqlParameter("SPA_LoaiThanhVien", Inserted.LoaiThanhVien);
            obj[24] = new SqlParameter("SPA_BaoDam", Inserted.BaoDam);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Spa Insert(Int32? id, Int32? kv_id, Int32? dm_id, String alias, String ten, String mota, String noidung, String anh, String diachi, String mobile, String phone, String toado, DateTime? ngaytao, DateTime? ngaycapnhat, Boolean? publish, Boolean? moi, Boolean? khuyenmai, Boolean? khaitruong, Int32? diem, Int32? solandanhgia, Byte? sao, Guid? rowid)
        {
            Spa Item = new Spa();
            SqlParameter[] obj = new SqlParameter[21];
            if (kv_id != null)
            {
                obj[0] = new SqlParameter("SPA_KV_ID", kv_id);
            }
            else
            {
                obj[0] = new SqlParameter("SPA_KV_ID", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[1] = new SqlParameter("SPA_DM_ID", dm_id);
            }
            else
            {
                obj[1] = new SqlParameter("SPA_DM_ID", DBNull.Value);
            }
            if (alias != null)
            {
                obj[2] = new SqlParameter("SPA_Alias", alias);
            }
            else
            {
                obj[2] = new SqlParameter("SPA_Alias", DBNull.Value);
            }
            if (ten != null)
            {
                obj[3] = new SqlParameter("SPA_Ten", ten);
            }
            else
            {
                obj[3] = new SqlParameter("SPA_Ten", DBNull.Value);
            }
            if (mota != null)
            {
                obj[4] = new SqlParameter("SPA_Mota", mota);
            }
            else
            {
                obj[4] = new SqlParameter("SPA_Mota", DBNull.Value);
            }
            if (noidung != null)
            {
                obj[5] = new SqlParameter("SPA_NoiDung", noidung);
            }
            else
            {
                obj[5] = new SqlParameter("SPA_NoiDung", DBNull.Value);
            }
            if (anh != null)
            {
                obj[6] = new SqlParameter("SPA_Anh", anh);
            }
            else
            {
                obj[6] = new SqlParameter("SPA_Anh", DBNull.Value);
            }
            if (diachi != null)
            {
                obj[7] = new SqlParameter("SPA_DiaChi", diachi);
            }
            else
            {
                obj[7] = new SqlParameter("SPA_DiaChi", DBNull.Value);
            }
            if (mobile != null)
            {
                obj[8] = new SqlParameter("SPA_Mobile", mobile);
            }
            else
            {
                obj[8] = new SqlParameter("SPA_Mobile", DBNull.Value);
            }
            if (phone != null)
            {
                obj[9] = new SqlParameter("SPA_Phone", phone);
            }
            else
            {
                obj[9] = new SqlParameter("SPA_Phone", DBNull.Value);
            }
            if (toado != null)
            {
                obj[10] = new SqlParameter("SPA_ToaDo", toado);
            }
            else
            {
                obj[10] = new SqlParameter("SPA_ToaDo", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[11] = new SqlParameter("SPA_NgayTao", ngaytao);
            }
            else
            {
                obj[11] = new SqlParameter("SPA_NgayTao", DBNull.Value);
            }
            if (ngaycapnhat != null)
            {
                obj[12] = new SqlParameter("SPA_NgayCapNhat", ngaycapnhat);
            }
            else
            {
                obj[12] = new SqlParameter("SPA_NgayCapNhat", DBNull.Value);
            }
            if (publish != null)
            {
                obj[13] = new SqlParameter("SPA_Publish", publish);
            }
            else
            {
                obj[13] = new SqlParameter("SPA_Publish", DBNull.Value);
            }
            if (moi != null)
            {
                obj[14] = new SqlParameter("SPA_Moi", moi);
            }
            else
            {
                obj[14] = new SqlParameter("SPA_Moi", DBNull.Value);
            }
            if (khuyenmai != null)
            {
                obj[15] = new SqlParameter("SPA_KhuyenMai", khuyenmai);
            }
            else
            {
                obj[15] = new SqlParameter("SPA_KhuyenMai", DBNull.Value);
            }
            if (khaitruong != null)
            {
                obj[16] = new SqlParameter("SPA_KhaiTruong", khaitruong);
            }
            else
            {
                obj[16] = new SqlParameter("SPA_KhaiTruong", DBNull.Value);
            }
            if (diem != null)
            {
                obj[17] = new SqlParameter("SPA_Diem", diem);
            }
            else
            {
                obj[17] = new SqlParameter("SPA_Diem", DBNull.Value);
            }
            if (solandanhgia != null)
            {
                obj[18] = new SqlParameter("SPA_SolanDanhGia", solandanhgia);
            }
            else
            {
                obj[18] = new SqlParameter("SPA_SolanDanhGia", DBNull.Value);
            }
            if (sao != null)
            {
                obj[19] = new SqlParameter("SPA_Sao", sao);
            }
            else
            {
                obj[19] = new SqlParameter("SPA_Sao", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[20] = new SqlParameter("SPA_RowId", rowid);
            }
            else
            {
                obj[20] = new SqlParameter("SPA_RowId", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Spa Update(Spa Updated)
        {
            Spa Item = new Spa();
            SqlParameter[] obj = new SqlParameter[26];
            obj[0] = new SqlParameter("SPA_ID", Updated.ID);
            obj[1] = new SqlParameter("SPA_KV_ID", Updated.KV_ID);
            obj[2] = new SqlParameter("SPA_DM_ID", Updated.DM_ID);
            obj[3] = new SqlParameter("SPA_Alias", Updated.Alias);
            obj[4] = new SqlParameter("SPA_Ten", Updated.Ten);
            obj[5] = new SqlParameter("SPA_Mota", Updated.Mota);
            obj[6] = new SqlParameter("SPA_NoiDung", Updated.NoiDung);
            obj[7] = new SqlParameter("SPA_Anh", Updated.Anh);
            obj[8] = new SqlParameter("SPA_DiaChi", Updated.DiaChi);
            obj[9] = new SqlParameter("SPA_Mobile", Updated.Mobile);
            obj[10] = new SqlParameter("SPA_Phone", Updated.Phone);
            obj[11] = new SqlParameter("SPA_ToaDo", Updated.ToaDo);
            if (Updated.NgayTao > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SPA_NgayTao", Updated.NgayTao);
            }
            else
            {
                obj[12] = new SqlParameter("SPA_NgayTao", DBNull.Value);
            }
            if (Updated.NgayCapNhat > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("SPA_NgayCapNhat", Updated.NgayCapNhat);
            }
            else
            {
                obj[13] = new SqlParameter("SPA_NgayCapNhat", DBNull.Value);
            }
            obj[14] = new SqlParameter("SPA_Publish", Updated.Publish);
            obj[15] = new SqlParameter("SPA_Moi", Updated.Moi);
            obj[16] = new SqlParameter("SPA_KhuyenMai", Updated.KhuyenMai);
            obj[17] = new SqlParameter("SPA_KhaiTruong", Updated.KhaiTruong);
            obj[18] = new SqlParameter("SPA_Diem", Updated.Diem);
            obj[19] = new SqlParameter("SPA_SolanDanhGia", Updated.SolanDanhGia);
            obj[20] = new SqlParameter("SPA_Sao", Updated.Sao);
            obj[25] = new SqlParameter("SPA_RowId", Updated.RowId);
            obj[21] = new SqlParameter("SPA_Website", Updated.Website);
            obj[22] = new SqlParameter("SPA_Email", Updated.Email);
            obj[23] = new SqlParameter("SPA_LoaiThanhVien", Updated.LoaiThanhVien);
            obj[24] = new SqlParameter("SPA_BaoDam", Updated.BaoDam);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Spa Update(Int32? id, Int32? kv_id, Int32? dm_id, String alias, String ten, String mota, String noidung, String anh, String diachi, String mobile, String phone, String toado, DateTime? ngaytao, DateTime? ngaycapnhat, Boolean? publish, Boolean? moi, Boolean? khuyenmai, Boolean? khaitruong, Int32? diem, Int32? solandanhgia, Byte? sao, Guid? rowid)
        {
            Spa Item = new Spa();
            SqlParameter[] obj = new SqlParameter[22];
            if (id != null)
            {
                obj[0] = new SqlParameter("SPA_ID", id);
            }
            else
            {
                obj[0] = new SqlParameter("SPA_ID", DBNull.Value);
            }
            if (kv_id != null)
            {
                obj[1] = new SqlParameter("SPA_KV_ID", kv_id);
            }
            else
            {
                obj[1] = new SqlParameter("SPA_KV_ID", DBNull.Value);
            }
            if (dm_id != null)
            {
                obj[2] = new SqlParameter("SPA_DM_ID", dm_id);
            }
            else
            {
                obj[2] = new SqlParameter("SPA_DM_ID", DBNull.Value);
            }
            if (alias != null)
            {
                obj[3] = new SqlParameter("SPA_Alias", alias);
            }
            else
            {
                obj[3] = new SqlParameter("SPA_Alias", DBNull.Value);
            }
            if (ten != null)
            {
                obj[4] = new SqlParameter("SPA_Ten", ten);
            }
            else
            {
                obj[4] = new SqlParameter("SPA_Ten", DBNull.Value);
            }
            if (mota != null)
            {
                obj[5] = new SqlParameter("SPA_Mota", mota);
            }
            else
            {
                obj[5] = new SqlParameter("SPA_Mota", DBNull.Value);
            }
            if (noidung != null)
            {
                obj[6] = new SqlParameter("SPA_NoiDung", noidung);
            }
            else
            {
                obj[6] = new SqlParameter("SPA_NoiDung", DBNull.Value);
            }
            if (anh != null)
            {
                obj[7] = new SqlParameter("SPA_Anh", anh);
            }
            else
            {
                obj[7] = new SqlParameter("SPA_Anh", DBNull.Value);
            }
            if (diachi != null)
            {
                obj[8] = new SqlParameter("SPA_DiaChi", diachi);
            }
            else
            {
                obj[8] = new SqlParameter("SPA_DiaChi", DBNull.Value);
            }
            if (mobile != null)
            {
                obj[9] = new SqlParameter("SPA_Mobile", mobile);
            }
            else
            {
                obj[9] = new SqlParameter("SPA_Mobile", DBNull.Value);
            }
            if (phone != null)
            {
                obj[10] = new SqlParameter("SPA_Phone", phone);
            }
            else
            {
                obj[10] = new SqlParameter("SPA_Phone", DBNull.Value);
            }
            if (toado != null)
            {
                obj[11] = new SqlParameter("SPA_ToaDo", toado);
            }
            else
            {
                obj[11] = new SqlParameter("SPA_ToaDo", DBNull.Value);
            }
            if (ngaytao != null)
            {
                obj[12] = new SqlParameter("SPA_NgayTao", ngaytao);
            }
            else
            {
                obj[12] = new SqlParameter("SPA_NgayTao", DBNull.Value);
            }
            if (ngaycapnhat != null)
            {
                obj[13] = new SqlParameter("SPA_NgayCapNhat", ngaycapnhat);
            }
            else
            {
                obj[13] = new SqlParameter("SPA_NgayCapNhat", DBNull.Value);
            }
            if (publish != null)
            {
                obj[14] = new SqlParameter("SPA_Publish", publish);
            }
            else
            {
                obj[14] = new SqlParameter("SPA_Publish", DBNull.Value);
            }
            if (moi != null)
            {
                obj[15] = new SqlParameter("SPA_Moi", moi);
            }
            else
            {
                obj[15] = new SqlParameter("SPA_Moi", DBNull.Value);
            }
            if (khuyenmai != null)
            {
                obj[16] = new SqlParameter("SPA_KhuyenMai", khuyenmai);
            }
            else
            {
                obj[16] = new SqlParameter("SPA_KhuyenMai", DBNull.Value);
            }
            if (khaitruong != null)
            {
                obj[17] = new SqlParameter("SPA_KhaiTruong", khaitruong);
            }
            else
            {
                obj[17] = new SqlParameter("SPA_KhaiTruong", DBNull.Value);
            }
            if (diem != null)
            {
                obj[18] = new SqlParameter("SPA_Diem", diem);
            }
            else
            {
                obj[18] = new SqlParameter("SPA_Diem", DBNull.Value);
            }
            if (solandanhgia != null)
            {
                obj[19] = new SqlParameter("SPA_SolanDanhGia", solandanhgia);
            }
            else
            {
                obj[19] = new SqlParameter("SPA_SolanDanhGia", DBNull.Value);
            }
            if (sao != null)
            {
                obj[20] = new SqlParameter("SPA_Sao", sao);
            }
            else
            {
                obj[20] = new SqlParameter("SPA_Sao", DBNull.Value);
            }
            if (rowid != null)
            {
                obj[21] = new SqlParameter("SPA_RowId", rowid);
            }
            else
            {
                obj[21] = new SqlParameter("SPA_RowId", DBNull.Value);
            }

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static Spa SelectById(Int32 SPA_ID)
        {
            Spa Item = new Spa();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SPA_ID", SPA_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static SpaCollection SelectAll()
        {
            SpaCollection List = new SpaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Spa> pagerNormal(string url, bool rewrite, string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[1];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            Pager<Spa> pg = new Pager<Spa>("tbl_sp_tblSpa_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Spa> pagerByQ(string q, string sort, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            if (string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            else
            {
                obj[1] = new SqlParameter("q", q);
            }
            Pager<Spa> pg = new Pager<Spa>("tbl_sp_tblSpa_Pager_pagerByQ_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion
        #region Utilities
        public static Spa getFromReader(IDataReader rd)
        {
            Spa Item = new Spa();
            if (rd.FieldExists("SPA_ID"))
            {
                Item.ID = (Int32)(rd["SPA_ID"]);
            }
            if (rd.FieldExists("SPA_KV_ID"))
            {
                Item.KV_ID = (Int32)(rd["SPA_KV_ID"]);
            }
            if (rd.FieldExists("SPA_DM_ID"))
            {
                Item.DM_ID = (Int32)(rd["SPA_DM_ID"]);
            }
            if (rd.FieldExists("SPA_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["SPA_DM_Ten"]);
            }
            if (rd.FieldExists("SPA_Alias"))
            {
                Item.Alias = (String)(rd["SPA_Alias"]);
            }
            if (rd.FieldExists("SPA_Ten"))
            {
                Item.Ten = (String)(rd["SPA_Ten"]);
            }
            if (rd.FieldExists("SPA_KV_Ten"))
            {
                Item.KV_Ten = (String)(rd["SPA_KV_Ten"]);
            }
            if (rd.FieldExists("SPA_Mota"))
            {
                Item.Mota = (String)(rd["SPA_Mota"]);
            }
            if (rd.FieldExists("SPA_NoiDung"))
            {
                Item.NoiDung = (String)(rd["SPA_NoiDung"]);
            }
            if (rd.FieldExists("SPA_Anh"))
            {
                Item.Anh = (String)(rd["SPA_Anh"]);
            }
            if (rd.FieldExists("SPA_DiaChi"))
            {
                Item.DiaChi = (String)(rd["SPA_DiaChi"]);
            }
            if (rd.FieldExists("SPA_Mobile"))
            {
                Item.Mobile = (String)(rd["SPA_Mobile"]);
            }
            if (rd.FieldExists("SPA_Phone"))
            {
                Item.Phone = (String)(rd["SPA_Phone"]);
            }
            if (rd.FieldExists("SPA_ToaDo"))
            {
                Item.ToaDo = (String)(rd["SPA_ToaDo"]);
            }
            if (rd.FieldExists("SPA_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SPA_NgayTao"]);
            }
            if (rd.FieldExists("SPA_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["SPA_NgayCapNhat"]);
            }
            if (rd.FieldExists("SPA_Publish"))
            {
                Item.Publish = (Boolean)(rd["SPA_Publish"]);
            }
            if (rd.FieldExists("SPA_Moi"))
            {
                Item.Moi = (Boolean)(rd["SPA_Moi"]);
            }
            if (rd.FieldExists("SPA_KhuyenMai"))
            {
                Item.KhuyenMai = (Boolean)(rd["SPA_KhuyenMai"]);
            }
            if (rd.FieldExists("SPA_KhaiTruong"))
            {
                Item.KhaiTruong = (Boolean)(rd["SPA_KhaiTruong"]);
            }
            if (rd.FieldExists("SPA_Diem"))
            {
                Item.Diem = (Int32)(rd["SPA_Diem"]);
            }
            if (rd.FieldExists("SPA_SolanDanhGia"))
            {
                Item.SolanDanhGia = (Int32)(rd["SPA_SolanDanhGia"]);
            }
            if (rd.FieldExists("SPA_Sao"))
            {
                Item.Sao = (Byte)(rd["SPA_Sao"]);
            }
            if (rd.FieldExists("SPA_RowId"))
            {
                Item.RowId = (Guid)(rd["SPA_RowId"]);
            }
            if (rd.FieldExists("SPA_Comments"))
            {
                Item.Comments = (Int32)(rd["SPA_Comments"]);
            }
            if (rd.FieldExists("SPA_Website"))
            {
                Item.Website = (String)(rd["SPA_Website"]);
            }
            if (rd.FieldExists("SPA_Email"))
            {
                Item.Email = (String)(rd["SPA_Email"]);
            }
            if (rd.FieldExists("SPA_LoaiThanhVien"))
            {
                Item.LoaiThanhVien = (Int32)(rd["SPA_LoaiThanhVien"]);
            }
            if (rd.FieldExists("SPA_BaoDam"))
            {
                Item.BaoDam = (Boolean)(rd["SPA_BaoDam"]);
            }
            return Item;
        }
        #endregion
        #region Extend
        #region formating
        public static string formatItem(string domain, Spa item)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""spa-item"">
    <span class=""spa-item-task"">
        <span class=""spa-item-task-bl"">{8}</span>
        <span class=""spa-item-task-view"">{9}</span>
    </span>
<img class=""spa-item-img"" src=""{0}/lib/up/{1}"">
<a class=""spa-item-ten"" href=""{0}/Danh-ba-spa/{2}/{3}.html"">{4}</a><br/>
<span class=""spa-item-desc"">{5}</span>
<span class=""spa-item-author"">Địa chỉ:{6} - </span><span class=""spa-item-author"">Điện thoại: {7}</span></div>
", domain, Lib.imgSize(item.Anh,"150x115"), item.Alias, item.ID, item.Ten, item.Mota, item.DiaChi, item.Phone, item.Diem, item.Sao);
            return sb.ToString();
        }
        public static string formatNoibat(string domain, Spa item)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""spa-item-noiBatHome"">
<img class=""spa-item-img"" src=""{0}/lib/up/{1}"">
<a class=""spa-item-ten"" href=""{0}/Danh-ba-spa/{2}/{3}.html"">{4}</a><br/>
<span class=""spa-item-desc"">{5}</span>
<span class=""spa-item-author"">Địa chỉ:{6} - </span><span class=""spa-item-author"">Điện thoại: {7}</span></div>
", domain, Lib.imgSize(item.Anh, "150x115"), item.Alias, item.ID, item.Ten, item.Mota, item.DiaChi, item.Phone, item.Diem, item.Sao);
            return sb.ToString();
        }
        public static string formatMoi(string domain, Spa item)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"
<div class=""spa-item-moi"">
<a class=""spa-item-ten"" href=""{0}/Danh-ba-spa/{2}/{3}.html"">{4}</a><br/>
<span class=""spa-item-author"">Địa chỉ:{6} - </span><span class=""spa-item-author"">Điện thoại: {7}</span></div>
", domain, Lib.imgSize(item.Anh, "150x115"), item.Alias, item.ID, item.Ten, item.Mota, item.DiaChi, item.Phone, item.Diem, item.Sao);
            return sb.ToString();
        }
        #endregion
        public static SpaCollection SelectLienQuan(string SPA_ID,int Top)
        {
            SpaCollection List = new SpaCollection();
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("SPA_ID", SPA_ID);
            obj[1] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectLienQuan_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaCollection SelectPublish(int Top)
        {
            SpaCollection List = new SpaCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectPublish_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaCollection SelectMoi(int Top)
        {
            return SelectMoi(DAL.con(), Top);
        }
        public static SpaCollection SelectMoi(SqlConnection con, int Top)
        {
            var list = new SpaCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectMoi_linhnx", obj))
            {
                while (rd.Read())
                {
                    list.Add(getFromReader(rd));
                }
            }
            return list;
        }
        public static SpaCollection SelectKhaiTruong(int Top)
        {
            SpaCollection List = new SpaCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectKhaiTruong_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaCollection SelectKhaiTruong(SqlConnection con, int Top)
        {
            SpaCollection List = new SpaCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectKhaiTruong_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SpaCollection SelectKhuyenMai(int Top)
        {
            SpaCollection List = new SpaCollection();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("Top", Top);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "tbl_sp_tblSpa_Select_SelectKhuyenMai_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Spa> pagerKhuVuc(string url, bool rewrite, string sort, int size, string KV_ID)
        {
            SqlParameter[] obj = new SqlParameter[2];
            if (string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            obj[1] = new SqlParameter("KV_ID", KV_ID);
            Pager<Spa> pg = new Pager<Spa>("tbl_sp_tblSpa_Pager_pagerKhuVuc_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion
    }
    #endregion
    #endregion
}
