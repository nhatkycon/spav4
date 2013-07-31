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

        #region Relation_danhMuc_GianHang
        #region BO
        public class Relation_danhMuc_GianHang : BaseEntity
        {
            #region Properties
            public Int64 ID { get; set; }
            public Int32 DM_ID { get; set; }
            public Guid CID { get; set; }
            public Guid PID { get; set; }
            public Guid RowId { get; set; }
            public Int32 ThuTu { get; set; }
            #endregion
            #region Contructor
            public Relation_danhMuc_GianHang()
            { }
            #endregion
            #region Customs properties

            #endregion
            public override BaseEntity getFromReader(IDataReader rd)
            {
                return Relation_danhMuc_GianHangDal.getFromReader(rd);
            }
        }
        #endregion
        #region Collection
        public class Relation_danhMuc_GianHangCollection : BaseEntityCollection<Relation_danhMuc_GianHang>
        { }
        #endregion


        #region Dal
        public class Relation_danhMuc_GianHangDal
        {
            #region Methods

            public static void DeleteById(Int64 REL_ID)
            {
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("REL_ID", REL_ID);
                SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_danhMuc_GianHang_Delete_DeleteById_linhnx", obj);
            }


            public static Relation_danhMuc_GianHang InsertArrDMByGianHang(string arrdm_id, string gh_rowid, string ldm_ma)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                SqlParameter[] obj = new SqlParameter[3];
                obj[0] = new SqlParameter("arrdm_id", arrdm_id);
                obj[1] = new SqlParameter("gh_rowid", gh_rowid);
                obj[2] = new SqlParameter("ldm_ma", ldm_ma);
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_Insert_GHID_DMID_hiennb", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            public static Relation_danhMuc_GianHang InsertArrDMByGianHang(string arrdm_id, string gh_rowid, string ldm_ma,SqlConnection con)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                SqlParameter[] obj = new SqlParameter[3];
                obj[0] = new SqlParameter("arrdm_id", arrdm_id);
                obj[1] = new SqlParameter("gh_rowid", gh_rowid);
                obj[2] = new SqlParameter("ldm_ma", ldm_ma);
                using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblRelation_Insert_GHID_DMID_hiennb", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }
            public static Relation_danhMuc_GianHang Insert(Relation_danhMuc_GianHang Inserted)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                SqlParameter[] obj = new SqlParameter[5];
                obj[0] = new SqlParameter("REL_DM_ID", Inserted.DM_ID);
                obj[1] = new SqlParameter("REL_CID", Inserted.CID);
                obj[2] = new SqlParameter("REL_PID", Inserted.PID);
                obj[3] = new SqlParameter("REL_RowId", Inserted.RowId);
                obj[4] = new SqlParameter("REL_ThuTu", Inserted.ThuTu);

                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_danhMuc_GianHang_Insert_InsertNormal_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }

            public static Relation_danhMuc_GianHang Update(Relation_danhMuc_GianHang Updated)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                SqlParameter[] obj = new SqlParameter[6];
                obj[0] = new SqlParameter("REL_ID", Updated.ID);
                obj[1] = new SqlParameter("REL_DM_ID", Updated.DM_ID);
                obj[2] = new SqlParameter("REL_CID", Updated.CID);
                obj[3] = new SqlParameter("REL_PID", Updated.PID);
                obj[4] = new SqlParameter("REL_RowId", Updated.RowId);
                obj[5] = new SqlParameter("REL_ThuTu", Updated.ThuTu);

                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_danhMuc_GianHang_Update_UpdateNormal_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }

            public static Relation_danhMuc_GianHang SelectById(Int64 REL_ID)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("REL_ID", REL_ID);
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_danhMuc_GianHang_Select_SelectById_linhnx", obj))
                {
                    while (rd.Read())
                    {
                        Item = getFromReader(rd);
                    }
                }
                return Item;
            }

            public static Relation_danhMuc_GianHangCollection SelectAll()
            {
                Relation_danhMuc_GianHangCollection List = new Relation_danhMuc_GianHangCollection();
                using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblRelation_danhMuc_GianHang_Select_SelectAll_linhnx"))
                {
                    while (rd.Read())
                    {
                        List.Add(getFromReader(rd));
                    }
                }
                return List;
            }
            public static Pager<Relation_danhMuc_GianHang> pagerNormal(string url, bool rewrite, string sort)
            {
                SqlParameter[] obj = new SqlParameter[1];
                obj[0] = new SqlParameter("Sort", sort);
                Pager<Relation_danhMuc_GianHang> pg = new Pager<Relation_danhMuc_GianHang>("sp_tblRelation_danhMuc_GianHang_Pager_Normal_linhnx", "q", 20, 10, rewrite, url, obj);
                return pg;
            }
            #endregion

            #region Utilities
            public static Relation_danhMuc_GianHang getFromReader(IDataReader rd)
            {
                Relation_danhMuc_GianHang Item = new Relation_danhMuc_GianHang();
                if (rd.FieldExists("REL_ID"))
                {
                    Item.ID = (Int64)(rd["REL_ID"]);
                }
                if (rd.FieldExists("REL_DM_ID"))
                {
                    Item.DM_ID = (Int32)(rd["REL_DM_ID"]);
                }
                if (rd.FieldExists("REL_CID"))
                {
                    Item.CID = (Guid)(rd["REL_CID"]);
                }
                if (rd.FieldExists("REL_PID"))
                {
                    Item.PID = (Guid)(rd["REL_PID"]);
                }
                if (rd.FieldExists("REL_RowId"))
                {
                    Item.RowId = (Guid)(rd["REL_RowId"]);
                }
                if (rd.FieldExists("REL_ThuTu"))
                {
                    Item.ThuTu = (Int32)(rd["REL_ThuTu"]);
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
