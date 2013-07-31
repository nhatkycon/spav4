using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using linh.core.dal;
using linh.controls;

namespace cnn.entities
{
    #region ChungChi
    #region BO
    public class ChungChi : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 GH_ID { get; set; }
        public String Anh { get; set; }
        public String Ten { get; set; }
        public String So { get; set; }
        public String GioiHan { get; set; }
        public String DonViCap { get; set; }
        public DateTime NgayCap { get; set; }
        public Int32 F_ID { get; set; }
        public Int32 TT { get; set; }
        public Boolean Active { get; set; }
        #endregion
        #region Contructor
        public ChungChi()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ChungChiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ChungChiCollection : BaseEntityCollection<ChungChi>
    { }
    #endregion
    #region Dal
    public class ChungChiDal
    {
        #region Methods

        public static void DeleteById(Int32 CC_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CC_ID", CC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Delete_DeleteById_hiennb", obj);
        }

        public static ChungChi Insert(ChungChi Inserted)
        {
            ChungChi Item = new ChungChi();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("CC_GH_ID", Inserted.GH_ID);
            obj[1] = new SqlParameter("CC_Anh", Inserted.Anh);
            obj[2] = new SqlParameter("CC_Ten", Inserted.Ten);
            obj[3] = new SqlParameter("CC_So", Inserted.So);
            obj[4] = new SqlParameter("CC_GioiHan", Inserted.GioiHan);
            obj[5] = new SqlParameter("CC_DonViCap", Inserted.DonViCap);
            obj[6] = new SqlParameter("CC_NgayCap", Inserted.NgayCap);
            obj[7] = new SqlParameter("CC_F_ID", Inserted.F_ID);
            obj[8] = new SqlParameter("CC_TT", Inserted.TT);
            obj[9] = new SqlParameter("CC_Active", Inserted.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Insert_InsertNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChungChi Update(ChungChi Updated)
        {
            ChungChi Item = new ChungChi();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("CC_ID", Updated.ID);
            obj[1] = new SqlParameter("CC_GH_ID", Updated.GH_ID);
            obj[2] = new SqlParameter("CC_Anh", Updated.Anh);
            obj[3] = new SqlParameter("CC_Ten", Updated.Ten);
            obj[4] = new SqlParameter("CC_So", Updated.So);
            obj[5] = new SqlParameter("CC_GioiHan", Updated.GioiHan);
            obj[6] = new SqlParameter("CC_DonViCap", Updated.DonViCap);
            obj[7] = new SqlParameter("CC_NgayCap", Updated.NgayCap);
            obj[8] = new SqlParameter("CC_F_ID", Updated.F_ID);
            obj[9] = new SqlParameter("CC_TT", Updated.TT);
            obj[10] = new SqlParameter("CC_Active", Updated.Active);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Update_UpdateNormal_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChungChi SelectById(Int32 CC_ID)
        {
            ChungChi Item = new ChungChi();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CC_ID", CC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Select_SelectById_hiennb", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChungChiCollection SelectAll()
        {
            ChungChiCollection List = new ChungChiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Select_SelectAll_hiennb"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }  
        public static Pager<ChungChi> pagerNormal(string url, bool rewrite, string sort, string q, string pagesize, string gh_id)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Sort", sort);
            obj[1] = new SqlParameter("q", q);
            obj[2] = new SqlParameter("gh_id",gh_id);
            Pager<ChungChi> pg = new Pager<ChungChi>("sp_tblChungChi_Pager_Normal_hiennb", "Page", int.Parse(pagesize), 10, rewrite, url, obj);
            return pg;
        }
        public static void ActiveCC(string listID, string active )
        {

            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("CC_IDlist", listID);
            if (!string.IsNullOrEmpty(active))
            {
                obj[1] = new SqlParameter("Active", active);
            }
            else
            {
                obj[1] = new SqlParameter("Active", DBNull.Value);
            }            

            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Update_Active_hiennb", obj);
        }
        public static void DeleteByIdList(string listCC_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("listCC_ID", listCC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblChungChi_Delete_DeleteByIdList_hiennb", obj);
        }
        #endregion

        #region Utilities
        public static ChungChi getFromReader(IDataReader rd)
        {
            ChungChi Item = new ChungChi();
            if (rd.FieldExists("CC_ID"))
            {
                Item.ID = (Int32)(rd["CC_ID"]);
            }
            if (rd.FieldExists("CC_GH_ID"))
            {
                Item.GH_ID = (Int32)(rd["CC_GH_ID"]);
            }
            if (rd.FieldExists("CC_Anh"))
            {
                Item.Anh = (String)(rd["CC_Anh"]);
            }
            if (rd.FieldExists("CC_Ten"))
            {
                Item.Ten = (String)(rd["CC_Ten"]);
            }
            if (rd.FieldExists("CC_So"))
            {
                Item.So = (String)(rd["CC_So"]);
            }
            if (rd.FieldExists("CC_GioiHan"))
            {
                Item.GioiHan = (String)(rd["CC_GioiHan"]);
            }
            if (rd.FieldExists("CC_DonViCap"))
            {
                Item.DonViCap = (String)(rd["CC_DonViCap"]);
            }
            if (rd.FieldExists("CC_NgayCap"))
            {
                Item.NgayCap = (DateTime)(rd["CC_NgayCap"]);
            }
            if (rd.FieldExists("CC_F_ID"))
            {
                Item.F_ID = (Int32)(rd["CC_F_ID"]);
            }
            if (rd.FieldExists("CC_TT"))
            {
                Item.TT = (Int32)(rd["CC_TT"]);
            }
            if (rd.FieldExists("CC_Active"))
            {
                Item.Active = (Boolean)(rd["CC_Active"]);
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
