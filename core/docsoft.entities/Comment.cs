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
namespace docsoft.entities
{
    

    #region Comment
    #region BO
    public class Comment : BaseEntity
    {
        #region Properties
        public Int32 ID { get; set; }
        public Int32 PID { get; set; }
        public String KH_Ten { get; set; }
        public String KH_Email { get; set; }
        public String KH_Mobile { get; set; }
        public String NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public Boolean Active { get; set; }
        public Boolean Readed { get; set; }
        public Int32 Kieu { get; set; }
        public Int32 Star { get; set; }
        #endregion
        #region Contructor
        public Comment()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return CommentDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class CommentCollection : BaseEntityCollection<Comment>
    { }
    #endregion
    #region Dal
    public class CommentDal
    {
        #region Methods

        public static void DeleteById(Int32 C_ID)
        {
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Delete_DeleteById_hoangda", obj);
        }

        public static Comment Insert(Comment Inserted)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter("C_PID", Inserted.PID);
            obj[1] = new SqlParameter("C_KH_Ten", Inserted.KH_Ten);
            obj[2] = new SqlParameter("C_KH_Email", Inserted.KH_Email);
            obj[3] = new SqlParameter("C_KH_Mobile", Inserted.KH_Mobile);
            obj[4] = new SqlParameter("C_NoiDung", Inserted.NoiDung);
            obj[5] = new SqlParameter("C_NgayTao", Inserted.NgayTao);
            obj[6] = new SqlParameter("C_Active", Inserted.Active);
            obj[7] = new SqlParameter("C_Readed", Inserted.Readed);
            obj[8] = new SqlParameter("C_Kieu", Inserted.Kieu);
            obj[9] = new SqlParameter("C_Star", Inserted.Star);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Insert_InsertNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Comment Update(Comment Updated)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[11];
            obj[0] = new SqlParameter("C_ID", Updated.ID);
            obj[1] = new SqlParameter("C_PID", Updated.PID);
            obj[2] = new SqlParameter("C_KH_Ten", Updated.KH_Ten);
            obj[3] = new SqlParameter("C_KH_Email", Updated.KH_Email);
            obj[4] = new SqlParameter("C_KH_Mobile", Updated.KH_Mobile);
            obj[5] = new SqlParameter("C_NoiDung", Updated.NoiDung);
            obj[6] = new SqlParameter("C_NgayTao", Updated.NgayTao);
            obj[7] = new SqlParameter("C_Active", Updated.Active);
            obj[8] = new SqlParameter("C_Readed", Updated.Readed);
            obj[9] = new SqlParameter("C_Star", Updated.Star);
            obj[10] = new SqlParameter("C_Kieu", Updated.Kieu);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Update_UpdateNormal_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static Comment SelectById(Int32 C_ID)
        {
            Comment Item = new Comment();
            SqlParameter[] obj = new SqlParameter[1];
            obj[0] = new SqlParameter("C_ID", C_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectById_hoangda", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        
        public static CommentCollection SelectAll()
        {
            CommentCollection List = new CommentCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectAll_hoangda"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<Comment> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            Pager<Comment> pg = new Pager<Comment>("sp_tblComment_Pager_Normal_hoangda", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<Comment> pagerNormal(string q)
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

            Pager<Comment> pg = new Pager<Comment>("sp_tblComment_Pager_Normal_hoangda", "pages", 20, 10, false, string.Empty, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static Comment getFromReader(IDataReader rd)
        {
            Comment Item = new Comment();
            if (rd.FieldExists("C_ID"))
            {
                Item.ID = (Int32)(rd["C_ID"]);
            }
            if (rd.FieldExists("C_PID"))
            {
                Item.PID = (Int32)(rd["C_PID"]);
            }
            if (rd.FieldExists("C_KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["C_KH_Ten"]);
            }
            if (rd.FieldExists("C_KH_Email"))
            {
                Item.KH_Email = (String)(rd["C_KH_Email"]);
            }
            if (rd.FieldExists("C_KH_Mobile"))
            {
                Item.KH_Mobile = (String)(rd["C_KH_Mobile"]);
            }
            if (rd.FieldExists("C_NoiDung"))
            {
                Item.NoiDung = (String)(rd["C_NoiDung"]);
            }
            if (rd.FieldExists("C_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["C_NgayTao"]);
            }
            if (rd.FieldExists("C_Active"))
            {
                Item.Active = (Boolean)(rd["C_Active"]);
            }
            if (rd.FieldExists("C_Readed"))
            {
                Item.Readed = (Boolean)(rd["C_Readed"]);
            }
            if (rd.FieldExists("C_Kieu"))
            {
                Item.Kieu = (Int32)(rd["C_Kieu"]);
            }
            if (rd.FieldExists("C_Star"))
            {
                Item.Star = (Int32)(rd["C_Star"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static CommentCollection SelectActive(int Top)
        {
            CommentCollection List = new CommentCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Top",Top)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectActive_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static CommentCollection SelectActive(int Top, string _ID)
        {
            CommentCollection List = new CommentCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Top",Top),
                new SqlParameter("ID",_ID)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectActive_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static CommentCollection SelectActive(int Top, string _ID, string _Kieu)
        {
            CommentCollection List = new CommentCollection();
            SqlParameter[] obj = new SqlParameter[] { 
                new SqlParameter("Top",Top),
                new SqlParameter("ID",_ID),
                new SqlParameter("Kieu",_Kieu)
            };
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Select_SelectActive_hoangda", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static void ActiveById(string _id)
        {
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("id", _id);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblComment_Update_ActiveById_hoangda", obj);
        }
        #endregion
    }
    #endregion

    #endregion
}


