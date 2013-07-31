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
	#region yaf_AccessMask
        #region BO
		public class yaf_AccessMask: BaseEntity
		{			
			#region Properties
			public  Int32 AccessMaskID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  Int32 Flags{get;set;}
			#endregion
			#region Contructor
			public yaf_AccessMask()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_AccessMaskDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_AccessMaskCollection : BaseEntityCollection<yaf_AccessMask>
			{}			
		#endregion
        #region Dal
            public class yaf_AccessMaskDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 AccessMaskID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("AccessMaskID", AccessMaskID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_AccessMask_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_AccessMask Insert(yaf_AccessMask Inserted)
                {
                    yaf_AccessMask Item = new yaf_AccessMask();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("Flags", Inserted.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_AccessMask_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_AccessMask Update(yaf_AccessMask Updated)
                {
                    yaf_AccessMask Item = new yaf_AccessMask();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("AccessMaskID", Updated.AccessMaskID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("Flags", Updated.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_AccessMask_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_AccessMask SelectById(Int32 AccessMaskID)
                {
                    yaf_AccessMask Item = new yaf_AccessMask();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("AccessMaskID", AccessMaskID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_AccessMask_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_AccessMaskCollection SelectAll()
                {
                    yaf_AccessMaskCollection List = new yaf_AccessMaskCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_AccessMask_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_AccessMask> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_AccessMask> pg = new Pager<yaf_AccessMask>("sp_tblyaf_AccessMask_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_AccessMask getFromReader(IDataReader rd)
                {
                    yaf_AccessMask Item = new yaf_AccessMask();
                    					if(rd.FieldExists("AccessMaskID")){
					Item.AccessMaskID = (Int32)(rd["AccessMaskID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Active
        #region BO
		public class yaf_Active: BaseEntity
		{			
			#region Properties
			public  String SessionID{get;set;}
			public  Int32 BoardID{get;set;}
			public  Int32 UserID{get;set;}
			public  String IP{get;set;}
			public  DateTime Login{get;set;}
			public  DateTime LastActive{get;set;}
			public  String Location{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 TopicID{get;set;}
			public  String Browser{get;set;}
			public  String Platform{get;set;}
			#endregion
			#region Contructor
			public yaf_Active()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_Topic yaf_Topic{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_ActiveDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_ActiveCollection : BaseEntityCollection<yaf_Active>
			{}			
		#endregion
        #region Dal
            public class yaf_ActiveDal
            {   
                #region Methods
                
                public static void DeleteById(String SessionID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("SessionID", SessionID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Active_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Active Insert(yaf_Active Inserted)
                {
                    yaf_Active Item = new yaf_Active();
                    SqlParameter[] obj = new SqlParameter[10];
                    				obj[0] = new SqlParameter("UserID", Inserted.UserID);
				obj[1] = new SqlParameter("IP", Inserted.IP);
				obj[2] = new SqlParameter("Login", Inserted.Login);
				obj[3] = new SqlParameter("LastActive", Inserted.LastActive);
				obj[4] = new SqlParameter("Location", Inserted.Location);
				obj[5] = new SqlParameter("ForumID", Inserted.ForumID);
				obj[6] = new SqlParameter("TopicID", Inserted.TopicID);
				obj[7] = new SqlParameter("Browser", Inserted.Browser);
				obj[8] = new SqlParameter("Platform", Inserted.Platform);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Active_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Active Update(yaf_Active Updated)
                {
                    yaf_Active Item = new yaf_Active();
                    SqlParameter[] obj = new SqlParameter[11];
                    				obj[0] = new SqlParameter("SessionID", Updated.SessionID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("IP", Updated.IP);
				obj[4] = new SqlParameter("Login", Updated.Login);
				obj[5] = new SqlParameter("LastActive", Updated.LastActive);
				obj[6] = new SqlParameter("Location", Updated.Location);
				obj[7] = new SqlParameter("ForumID", Updated.ForumID);
				obj[8] = new SqlParameter("TopicID", Updated.TopicID);
				obj[9] = new SqlParameter("Browser", Updated.Browser);
				obj[10] = new SqlParameter("Platform", Updated.Platform);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Active_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Active SelectById(String SessionID)
                {
                    yaf_Active Item = new yaf_Active();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("SessionID", SessionID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Active_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ActiveCollection SelectAll()
                {
                    yaf_ActiveCollection List = new yaf_ActiveCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Active_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Active> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Active> pg = new Pager<yaf_Active>("sp_tblyaf_Active_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Active getFromReader(IDataReader rd)
                {
                    yaf_Active Item = new yaf_Active();
                    					if(rd.FieldExists("SessionID")){
					Item.SessionID = (String)(rd["SessionID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("IP")){
					Item.IP = (String)(rd["IP"]);
					}
					if(rd.FieldExists("Login")){
					Item.Login = (DateTime)(rd["Login"]);
					}
					if(rd.FieldExists("LastActive")){
					Item.LastActive = (DateTime)(rd["LastActive"]);
					}
					if(rd.FieldExists("Location")){
					Item.Location = (String)(rd["Location"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("TopicID")){
					Item.TopicID = (Int32)(rd["TopicID"]);
					}
					if(rd.FieldExists("Browser")){
					Item.Browser = (String)(rd["Browser"]);
					}
					if(rd.FieldExists("Platform")){
					Item.Platform = (String)(rd["Platform"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Attachment
        #region BO
		public class yaf_Attachment: BaseEntity
		{			
			#region Properties
			public  Int32 AttachmentID{get;set;}
			public  Int32 MessageID{get;set;}
			public  String FileName{get;set;}
			public  Int32 Bytes{get;set;}
			public  Int32 FileID{get;set;}
			public  String ContentType{get;set;}
			public  Int32 Downloads{get;set;}
			public  Byte[] FileData{get;set;}
			#endregion
			#region Contructor
			public yaf_Attachment()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_AttachmentDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_AttachmentCollection : BaseEntityCollection<yaf_Attachment>
			{}			
		#endregion
        #region Dal
            public class yaf_AttachmentDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 AttachmentID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("AttachmentID", AttachmentID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Attachment_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Attachment Insert(yaf_Attachment Inserted)
                {
                    yaf_Attachment Item = new yaf_Attachment();
                    SqlParameter[] obj = new SqlParameter[7];
                    				obj[0] = new SqlParameter("MessageID", Inserted.MessageID);
				obj[1] = new SqlParameter("FileName", Inserted.FileName);
				obj[2] = new SqlParameter("Bytes", Inserted.Bytes);
				obj[3] = new SqlParameter("FileID", Inserted.FileID);
				obj[4] = new SqlParameter("ContentType", Inserted.ContentType);
				obj[5] = new SqlParameter("Downloads", Inserted.Downloads);
				obj[6] = new SqlParameter("FileData", Inserted.FileData);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Attachment_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Attachment Update(yaf_Attachment Updated)
                {
                    yaf_Attachment Item = new yaf_Attachment();
                    SqlParameter[] obj = new SqlParameter[8];
                    				obj[0] = new SqlParameter("AttachmentID", Updated.AttachmentID);
				obj[1] = new SqlParameter("MessageID", Updated.MessageID);
				obj[2] = new SqlParameter("FileName", Updated.FileName);
				obj[3] = new SqlParameter("Bytes", Updated.Bytes);
				obj[4] = new SqlParameter("FileID", Updated.FileID);
				obj[5] = new SqlParameter("ContentType", Updated.ContentType);
				obj[6] = new SqlParameter("Downloads", Updated.Downloads);
				obj[7] = new SqlParameter("FileData", Updated.FileData);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Attachment_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Attachment SelectById(Int32 AttachmentID)
                {
                    yaf_Attachment Item = new yaf_Attachment();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("AttachmentID", AttachmentID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Attachment_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_AttachmentCollection SelectAll()
                {
                    yaf_AttachmentCollection List = new yaf_AttachmentCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Attachment_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Attachment> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Attachment> pg = new Pager<yaf_Attachment>("sp_tblyaf_Attachment_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Attachment getFromReader(IDataReader rd)
                {
                    yaf_Attachment Item = new yaf_Attachment();
                    					if(rd.FieldExists("AttachmentID")){
					Item.AttachmentID = (Int32)(rd["AttachmentID"]);
					}
					if(rd.FieldExists("MessageID")){
					Item.MessageID = (Int32)(rd["MessageID"]);
					}
					if(rd.FieldExists("FileName")){
					Item.FileName = (String)(rd["FileName"]);
					}
					if(rd.FieldExists("Bytes")){
					Item.Bytes = (Int32)(rd["Bytes"]);
					}
					if(rd.FieldExists("FileID")){
					Item.FileID = (Int32)(rd["FileID"]);
					}
					if(rd.FieldExists("ContentType")){
					Item.ContentType = (String)(rd["ContentType"]);
					}
					if(rd.FieldExists("Downloads")){
					Item.Downloads = (Int32)(rd["Downloads"]);
					}
					if(rd.FieldExists("FileData")){
					Item.FileData = (Byte[])(rd["FileData"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_BannedIP
        #region BO
		public class yaf_BannedIP: BaseEntity
		{			
			#region Properties
			public  Int32 ID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Mask{get;set;}
			public  DateTime Since{get;set;}
			#endregion
			#region Contructor
			public yaf_BannedIP()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_BannedIPDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_BannedIPCollection : BaseEntityCollection<yaf_BannedIP>
			{}			
		#endregion
        #region Dal
            public class yaf_BannedIPDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 ID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ID", ID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_BannedIP_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_BannedIP Insert(yaf_BannedIP Inserted)
                {
                    yaf_BannedIP Item = new yaf_BannedIP();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Mask", Inserted.Mask);
				obj[2] = new SqlParameter("Since", Inserted.Since);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_BannedIP_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_BannedIP Update(yaf_BannedIP Updated)
                {
                    yaf_BannedIP Item = new yaf_BannedIP();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("ID", Updated.ID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Mask", Updated.Mask);
				obj[3] = new SqlParameter("Since", Updated.Since);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_BannedIP_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_BannedIP SelectById(Int32 ID)
                {
                    yaf_BannedIP Item = new yaf_BannedIP();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ID", ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_BannedIP_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_BannedIPCollection SelectAll()
                {
                    yaf_BannedIPCollection List = new yaf_BannedIPCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_BannedIP_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_BannedIP> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_BannedIP> pg = new Pager<yaf_BannedIP>("sp_tblyaf_BannedIP_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_BannedIP getFromReader(IDataReader rd)
                {
                    yaf_BannedIP Item = new yaf_BannedIP();
                    					if(rd.FieldExists("ID")){
					Item.ID = (Int32)(rd["ID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Mask")){
					Item.Mask = (String)(rd["Mask"]);
					}
					if(rd.FieldExists("Since")){
					Item.Since = (DateTime)(rd["Since"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Board
        #region BO
		public class yaf_Board: BaseEntity
		{			
			#region Properties
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  Boolean AllowThreaded{get;set;}
			#endregion
			#region Contructor
			public yaf_Board()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_BoardDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_BoardCollection : BaseEntityCollection<yaf_Board>
			{}			
		#endregion
        #region Dal
            public class yaf_BoardDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 BoardID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("BoardID", BoardID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Board_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Board Insert(yaf_Board Inserted)
                {
                    yaf_Board Item = new yaf_Board();
                    SqlParameter[] obj = new SqlParameter[2];
                    				obj[0] = new SqlParameter("Name", Inserted.Name);
				obj[1] = new SqlParameter("AllowThreaded", Inserted.AllowThreaded);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Board_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Board Update(yaf_Board Updated)
                {
                    yaf_Board Item = new yaf_Board();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("BoardID", Updated.BoardID);
				obj[1] = new SqlParameter("Name", Updated.Name);
				obj[2] = new SqlParameter("AllowThreaded", Updated.AllowThreaded);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Board_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Board SelectById(Int32 BoardID)
                {
                    yaf_Board Item = new yaf_Board();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("BoardID", BoardID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Board_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_BoardCollection SelectAll()
                {
                    yaf_BoardCollection List = new yaf_BoardCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Board_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Board> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Board> pg = new Pager<yaf_Board>("sp_tblyaf_Board_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Board getFromReader(IDataReader rd)
                {
                    yaf_Board Item = new yaf_Board();
                    					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("AllowThreaded")){
					Item.AllowThreaded = (Boolean)(rd["AllowThreaded"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Category
        #region BO
		public class yaf_Category: BaseEntity
		{			
			#region Properties
			public  Int32 CategoryID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  Int16 SortOrder{get;set;}
			#endregion
			#region Contructor
			public yaf_Category()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_CategoryDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_CategoryCollection : BaseEntityCollection<yaf_Category>
			{}			
		#endregion
        #region Dal
            public class yaf_CategoryDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 CategoryID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CategoryID", CategoryID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Category_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Category Insert(yaf_Category Inserted)
                {
                    yaf_Category Item = new yaf_Category();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("SortOrder", Inserted.SortOrder);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Category_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Category Update(yaf_Category Updated)
                {
                    yaf_Category Item = new yaf_Category();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("CategoryID", Updated.CategoryID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("SortOrder", Updated.SortOrder);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Category_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Category SelectById(Int32 CategoryID)
                {
                    yaf_Category Item = new yaf_Category();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CategoryID", CategoryID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Category_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_CategoryCollection SelectAll()
                {
                    yaf_CategoryCollection List = new yaf_CategoryCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Category_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Category> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Category> pg = new Pager<yaf_Category>("sp_tblyaf_Category_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Category getFromReader(IDataReader rd)
                {
                    yaf_Category Item = new yaf_Category();
                    					if(rd.FieldExists("CategoryID")){
					Item.CategoryID = (Int32)(rd["CategoryID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("SortOrder")){
					Item.SortOrder = (Int16)(rd["SortOrder"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_CheckEmail
        #region BO
		public class yaf_CheckEmail: BaseEntity
		{			
			#region Properties
			public  Int32 CheckEmailID{get;set;}
			public  Int32 UserID{get;set;}
			public  String Email{get;set;}
			public  DateTime Created{get;set;}
			public  String Hash{get;set;}
			#endregion
			#region Contructor
			public yaf_CheckEmail()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_CheckEmailDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_CheckEmailCollection : BaseEntityCollection<yaf_CheckEmail>
			{}			
		#endregion
        #region Dal
            public class yaf_CheckEmailDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 CheckEmailID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CheckEmailID", CheckEmailID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_CheckEmail_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_CheckEmail Insert(yaf_CheckEmail Inserted)
                {
                    yaf_CheckEmail Item = new yaf_CheckEmail();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("UserID", Inserted.UserID);
				obj[1] = new SqlParameter("Email", Inserted.Email);
				obj[2] = new SqlParameter("Created", Inserted.Created);
				obj[3] = new SqlParameter("Hash", Inserted.Hash);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_CheckEmail_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_CheckEmail Update(yaf_CheckEmail Updated)
                {
                    yaf_CheckEmail Item = new yaf_CheckEmail();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("CheckEmailID", Updated.CheckEmailID);
				obj[1] = new SqlParameter("UserID", Updated.UserID);
				obj[2] = new SqlParameter("Email", Updated.Email);
				obj[3] = new SqlParameter("Created", Updated.Created);
				obj[4] = new SqlParameter("Hash", Updated.Hash);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_CheckEmail_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_CheckEmail SelectById(Int32 CheckEmailID)
                {
                    yaf_CheckEmail Item = new yaf_CheckEmail();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("CheckEmailID", CheckEmailID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_CheckEmail_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_CheckEmailCollection SelectAll()
                {
                    yaf_CheckEmailCollection List = new yaf_CheckEmailCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_CheckEmail_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_CheckEmail> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_CheckEmail> pg = new Pager<yaf_CheckEmail>("sp_tblyaf_CheckEmail_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_CheckEmail getFromReader(IDataReader rd)
                {
                    yaf_CheckEmail Item = new yaf_CheckEmail();
                    					if(rd.FieldExists("CheckEmailID")){
					Item.CheckEmailID = (Int32)(rd["CheckEmailID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("Email")){
					Item.Email = (String)(rd["Email"]);
					}
					if(rd.FieldExists("Created")){
					Item.Created = (DateTime)(rd["Created"]);
					}
					if(rd.FieldExists("Hash")){
					Item.Hash = (String)(rd["Hash"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Choice
        #region BO
		public class yaf_Choice: BaseEntity
		{			
			#region Properties
			public  Int32 ChoiceID{get;set;}
			public  Int32 PollID{get;set;}
			public  String Choice{get;set;}
			public  Int32 Votes{get;set;}
			#endregion
			#region Contructor
			public yaf_Choice()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Poll yaf_Poll{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_ChoiceDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_ChoiceCollection : BaseEntityCollection<yaf_Choice>
			{}			
		#endregion
        #region Dal
            public class yaf_ChoiceDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 ChoiceID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ChoiceID", ChoiceID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Choice_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Choice Insert(yaf_Choice Inserted)
                {
                    yaf_Choice Item = new yaf_Choice();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("PollID", Inserted.PollID);
				obj[1] = new SqlParameter("Choice", Inserted.Choice);
				obj[2] = new SqlParameter("Votes", Inserted.Votes);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Choice_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Choice Update(yaf_Choice Updated)
                {
                    yaf_Choice Item = new yaf_Choice();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("ChoiceID", Updated.ChoiceID);
				obj[1] = new SqlParameter("PollID", Updated.PollID);
				obj[2] = new SqlParameter("Choice", Updated.Choice);
				obj[3] = new SqlParameter("Votes", Updated.Votes);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Choice_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Choice SelectById(Int32 ChoiceID)
                {
                    yaf_Choice Item = new yaf_Choice();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ChoiceID", ChoiceID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Choice_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ChoiceCollection SelectAll()
                {
                    yaf_ChoiceCollection List = new yaf_ChoiceCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Choice_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Choice> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Choice> pg = new Pager<yaf_Choice>("sp_tblyaf_Choice_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Choice getFromReader(IDataReader rd)
                {
                    yaf_Choice Item = new yaf_Choice();
                    					if(rd.FieldExists("ChoiceID")){
					Item.ChoiceID = (Int32)(rd["ChoiceID"]);
					}
					if(rd.FieldExists("PollID")){
					Item.PollID = (Int32)(rd["PollID"]);
					}
					if(rd.FieldExists("Choice")){
					Item.Choice = (String)(rd["Choice"]);
					}
					if(rd.FieldExists("Votes")){
					Item.Votes = (Int32)(rd["Votes"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_EventLog
        #region BO
		public class yaf_EventLog: BaseEntity
		{			
			#region Properties
			public  Int32 EventLogID{get;set;}
			public  DateTime EventTime{get;set;}
			public  Int32 UserID{get;set;}
			public  String Source{get;set;}
			public  String Description{get;set;}
			public  Int32 TYPE{get;set;}
			#endregion
			#region Contructor
			public yaf_EventLog()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_EventLogDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_EventLogCollection : BaseEntityCollection<yaf_EventLog>
			{}			
		#endregion
        #region Dal
            public class yaf_EventLogDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 EventLogID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("EventLogID", EventLogID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_EventLog_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_EventLog Insert(yaf_EventLog Inserted)
                {
                    yaf_EventLog Item = new yaf_EventLog();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("EventTime", Inserted.EventTime);
				obj[1] = new SqlParameter("UserID", Inserted.UserID);
				obj[2] = new SqlParameter("Source", Inserted.Source);
				obj[3] = new SqlParameter("Description", Inserted.Description);
				obj[4] = new SqlParameter("TYPE", Inserted.TYPE);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_EventLog_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_EventLog Update(yaf_EventLog Updated)
                {
                    yaf_EventLog Item = new yaf_EventLog();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("EventLogID", Updated.EventLogID);
				obj[1] = new SqlParameter("EventTime", Updated.EventTime);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("Source", Updated.Source);
				obj[4] = new SqlParameter("Description", Updated.Description);
				obj[5] = new SqlParameter("TYPE", Updated.TYPE);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_EventLog_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_EventLog SelectById(Int32 EventLogID)
                {
                    yaf_EventLog Item = new yaf_EventLog();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("EventLogID", EventLogID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_EventLog_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_EventLogCollection SelectAll()
                {
                    yaf_EventLogCollection List = new yaf_EventLogCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_EventLog_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_EventLog> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_EventLog> pg = new Pager<yaf_EventLog>("sp_tblyaf_EventLog_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_EventLog getFromReader(IDataReader rd)
                {
                    yaf_EventLog Item = new yaf_EventLog();
                    					if(rd.FieldExists("EventLogID")){
					Item.EventLogID = (Int32)(rd["EventLogID"]);
					}
					if(rd.FieldExists("EventTime")){
					Item.EventTime = (DateTime)(rd["EventTime"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("Source")){
					Item.Source = (String)(rd["Source"]);
					}
					if(rd.FieldExists("Description")){
					Item.Description = (String)(rd["Description"]);
					}
					if(rd.FieldExists("TYPE")){
					Item.TYPE = (Int32)(rd["TYPE"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Forum
        #region BO
		public class yaf_Forum: BaseEntity
		{			
			#region Properties
			public  Int32 ForumID{get;set;}
			public  Int32 CategoryID{get;set;}
			public  Int32 ParentID{get;set;}
			public  String Name{get;set;}
			public  String Description{get;set;}
			public  Int16 SortOrder{get;set;}
			public  DateTime LastPosted{get;set;}
			public  Int32 LastTopicID{get;set;}
			public  Int32 LastMessageID{get;set;}
			public  Int32 LastUserID{get;set;}
			public  String LastUserName{get;set;}
			public  Int32 NumTopics{get;set;}
			public  Int32 NumPosts{get;set;}
			public  String RemoteURL{get;set;}
			public  Int32 Flags{get;set;}
			public  String ThemeURL{get;set;}
			#endregion
			#region Contructor
			public yaf_Forum()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Category yaf_Category{get;set;}
			//public yaf_Forum yaf_Forum{get;set;}
			public yaf_Topic yaf_Topic{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_ForumDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_ForumCollection : BaseEntityCollection<yaf_Forum>
			{}			
		#endregion
        #region Dal
            public class yaf_ForumDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 ForumID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ForumID", ForumID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Forum_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Forum Insert(yaf_Forum Inserted)
                {
                    yaf_Forum Item = new yaf_Forum();
                    SqlParameter[] obj = new SqlParameter[15];
                    				obj[0] = new SqlParameter("CategoryID", Inserted.CategoryID);
				obj[1] = new SqlParameter("ParentID", Inserted.ParentID);
				obj[2] = new SqlParameter("Name", Inserted.Name);
				obj[3] = new SqlParameter("Description", Inserted.Description);
				obj[4] = new SqlParameter("SortOrder", Inserted.SortOrder);
				obj[5] = new SqlParameter("LastPosted", Inserted.LastPosted);
				obj[6] = new SqlParameter("LastTopicID", Inserted.LastTopicID);
				obj[7] = new SqlParameter("LastMessageID", Inserted.LastMessageID);
				obj[8] = new SqlParameter("LastUserID", Inserted.LastUserID);
				obj[9] = new SqlParameter("LastUserName", Inserted.LastUserName);
				obj[10] = new SqlParameter("NumTopics", Inserted.NumTopics);
				obj[11] = new SqlParameter("NumPosts", Inserted.NumPosts);
				obj[12] = new SqlParameter("RemoteURL", Inserted.RemoteURL);
				obj[13] = new SqlParameter("Flags", Inserted.Flags);
				obj[14] = new SqlParameter("ThemeURL", Inserted.ThemeURL);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Forum_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Forum Update(yaf_Forum Updated)
                {
                    yaf_Forum Item = new yaf_Forum();
                    SqlParameter[] obj = new SqlParameter[16];
                    				obj[0] = new SqlParameter("ForumID", Updated.ForumID);
				obj[1] = new SqlParameter("CategoryID", Updated.CategoryID);
				obj[2] = new SqlParameter("ParentID", Updated.ParentID);
				obj[3] = new SqlParameter("Name", Updated.Name);
				obj[4] = new SqlParameter("Description", Updated.Description);
				obj[5] = new SqlParameter("SortOrder", Updated.SortOrder);
				obj[6] = new SqlParameter("LastPosted", Updated.LastPosted);
				obj[7] = new SqlParameter("LastTopicID", Updated.LastTopicID);
				obj[8] = new SqlParameter("LastMessageID", Updated.LastMessageID);
				obj[9] = new SqlParameter("LastUserID", Updated.LastUserID);
				obj[10] = new SqlParameter("LastUserName", Updated.LastUserName);
				obj[11] = new SqlParameter("NumTopics", Updated.NumTopics);
				obj[12] = new SqlParameter("NumPosts", Updated.NumPosts);
				obj[13] = new SqlParameter("RemoteURL", Updated.RemoteURL);
				obj[14] = new SqlParameter("Flags", Updated.Flags);
				obj[15] = new SqlParameter("ThemeURL", Updated.ThemeURL);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Forum_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Forum SelectById(Int32 ForumID)
                {
                    yaf_Forum Item = new yaf_Forum();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("ForumID", ForumID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Forum_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ForumCollection SelectAll()
                {
                    yaf_ForumCollection List = new yaf_ForumCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Forum_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Forum> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Forum> pg = new Pager<yaf_Forum>("sp_tblyaf_Forum_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Forum getFromReader(IDataReader rd)
                {
                    yaf_Forum Item = new yaf_Forum();
                    					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("CategoryID")){
					Item.CategoryID = (Int32)(rd["CategoryID"]);
					}
					if(rd.FieldExists("ParentID")){
					Item.ParentID = (Int32)(rd["ParentID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("Description")){
					Item.Description = (String)(rd["Description"]);
					}
					if(rd.FieldExists("SortOrder")){
					Item.SortOrder = (Int16)(rd["SortOrder"]);
					}
					if(rd.FieldExists("LastPosted")){
					Item.LastPosted = (DateTime)(rd["LastPosted"]);
					}
					if(rd.FieldExists("LastTopicID")){
					Item.LastTopicID = (Int32)(rd["LastTopicID"]);
					}
					if(rd.FieldExists("LastMessageID")){
					Item.LastMessageID = (Int32)(rd["LastMessageID"]);
					}
					if(rd.FieldExists("LastUserID")){
					Item.LastUserID = (Int32)(rd["LastUserID"]);
					}
					if(rd.FieldExists("LastUserName")){
					Item.LastUserName = (String)(rd["LastUserName"]);
					}
					if(rd.FieldExists("NumTopics")){
					Item.NumTopics = (Int32)(rd["NumTopics"]);
					}
					if(rd.FieldExists("NumPosts")){
					Item.NumPosts = (Int32)(rd["NumPosts"]);
					}
					if(rd.FieldExists("RemoteURL")){
					Item.RemoteURL = (String)(rd["RemoteURL"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
					if(rd.FieldExists("ThemeURL")){
					Item.ThemeURL = (String)(rd["ThemeURL"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_ForumAccess
        #region BO
		public class yaf_ForumAccess: BaseEntity
		{			
			#region Properties
			public  Int32 GroupID{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 AccessMaskID{get;set;}
			#endregion
			#region Contructor
			public yaf_ForumAccess()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_AccessMask yaf_AccessMask{get;set;}
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_Group yaf_Group{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_ForumAccessDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_ForumAccessCollection : BaseEntityCollection<yaf_ForumAccess>
			{}			
		#endregion
        #region Dal
            public class yaf_ForumAccessDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 GroupID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("GroupID", GroupID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_ForumAccess_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_ForumAccess Insert(yaf_ForumAccess Inserted)
                {
                    yaf_ForumAccess Item = new yaf_ForumAccess();
                    SqlParameter[] obj = new SqlParameter[2];
                    				obj[0] = new SqlParameter("AccessMaskID", Inserted.AccessMaskID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_ForumAccess_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ForumAccess Update(yaf_ForumAccess Updated)
                {
                    yaf_ForumAccess Item = new yaf_ForumAccess();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("GroupID", Updated.GroupID);
				obj[1] = new SqlParameter("ForumID", Updated.ForumID);
				obj[2] = new SqlParameter("AccessMaskID", Updated.AccessMaskID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_ForumAccess_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ForumAccess SelectById(Int32 GroupID)
                {
                    yaf_ForumAccess Item = new yaf_ForumAccess();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("GroupID", GroupID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_ForumAccess_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_ForumAccessCollection SelectAll()
                {
                    yaf_ForumAccessCollection List = new yaf_ForumAccessCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_ForumAccess_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_ForumAccess> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_ForumAccess> pg = new Pager<yaf_ForumAccess>("sp_tblyaf_ForumAccess_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_ForumAccess getFromReader(IDataReader rd)
                {
                    yaf_ForumAccess Item = new yaf_ForumAccess();
                    					if(rd.FieldExists("GroupID")){
					Item.GroupID = (Int32)(rd["GroupID"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("AccessMaskID")){
					Item.AccessMaskID = (Int32)(rd["AccessMaskID"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Group
        #region BO
		public class yaf_Group: BaseEntity
		{			
			#region Properties
			public  Int32 GroupID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  Int32 Flags{get;set;}
			#endregion
			#region Contructor
			public yaf_Group()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_GroupDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_GroupCollection : BaseEntityCollection<yaf_Group>
			{}			
		#endregion
        #region Dal
            public class yaf_GroupDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 GroupID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("GroupID", GroupID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Group_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Group Insert(yaf_Group Inserted)
                {
                    yaf_Group Item = new yaf_Group();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("Flags", Inserted.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Group_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Group Update(yaf_Group Updated)
                {
                    yaf_Group Item = new yaf_Group();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("GroupID", Updated.GroupID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("Flags", Updated.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Group_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Group SelectById(Int32 GroupID)
                {
                    yaf_Group Item = new yaf_Group();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("GroupID", GroupID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Group_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_GroupCollection SelectAll()
                {
                    yaf_GroupCollection List = new yaf_GroupCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Group_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Group> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Group> pg = new Pager<yaf_Group>("sp_tblyaf_Group_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Group getFromReader(IDataReader rd)
                {
                    yaf_Group Item = new yaf_Group();
                    					if(rd.FieldExists("GroupID")){
					Item.GroupID = (Int32)(rd["GroupID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Mail
        #region BO
		public class yaf_Mail: BaseEntity
		{			
			#region Properties
			public  Int32 MailID{get;set;}
			public  String FromUser{get;set;}
			public  String ToUser{get;set;}
			public  DateTime Created{get;set;}
			public  String Subject{get;set;}
			public  String Body{get;set;}
			#endregion
			#region Contructor
			public yaf_Mail()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_MailDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_MailCollection : BaseEntityCollection<yaf_Mail>
			{}			
		#endregion
        #region Dal
            public class yaf_MailDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 MailID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("MailID", MailID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Mail_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Mail Insert(yaf_Mail Inserted)
                {
                    yaf_Mail Item = new yaf_Mail();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("FromUser", Inserted.FromUser);
				obj[1] = new SqlParameter("ToUser", Inserted.ToUser);
				obj[2] = new SqlParameter("Created", Inserted.Created);
				obj[3] = new SqlParameter("Subject", Inserted.Subject);
				obj[4] = new SqlParameter("Body", Inserted.Body);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Mail_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Mail Update(yaf_Mail Updated)
                {
                    yaf_Mail Item = new yaf_Mail();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("MailID", Updated.MailID);
				obj[1] = new SqlParameter("FromUser", Updated.FromUser);
				obj[2] = new SqlParameter("ToUser", Updated.ToUser);
				obj[3] = new SqlParameter("Created", Updated.Created);
				obj[4] = new SqlParameter("Subject", Updated.Subject);
				obj[5] = new SqlParameter("Body", Updated.Body);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Mail_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Mail SelectById(Int32 MailID)
                {
                    yaf_Mail Item = new yaf_Mail();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("MailID", MailID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Mail_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_MailCollection SelectAll()
                {
                    yaf_MailCollection List = new yaf_MailCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Mail_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Mail> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Mail> pg = new Pager<yaf_Mail>("sp_tblyaf_Mail_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Mail getFromReader(IDataReader rd)
                {
                    yaf_Mail Item = new yaf_Mail();
                    					if(rd.FieldExists("MailID")){
					Item.MailID = (Int32)(rd["MailID"]);
					}
					if(rd.FieldExists("FromUser")){
					Item.FromUser = (String)(rd["FromUser"]);
					}
					if(rd.FieldExists("ToUser")){
					Item.ToUser = (String)(rd["ToUser"]);
					}
					if(rd.FieldExists("Created")){
					Item.Created = (DateTime)(rd["Created"]);
					}
					if(rd.FieldExists("Subject")){
					Item.Subject = (String)(rd["Subject"]);
					}
					if(rd.FieldExists("Body")){
					Item.Body = (String)(rd["Body"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Message
        #region BO
		public class yaf_Message: BaseEntity
		{			
			#region Properties
			public  Int32 MessageID{get;set;}
			public  Int32 TopicID{get;set;}
			public  Int32 ReplyTo{get;set;}
			public  Int32 Position{get;set;}
			public  Int32 Indent{get;set;}
			public  Int32 UserID{get;set;}
			public  String UserName{get;set;}
			public  DateTime Posted{get;set;}
			public  String Message{get;set;}
			public  String IP{get;set;}
			public  DateTime Edited{get;set;}
			public  Int32 Flags{get;set;}
			#endregion
			#region Contructor
			public yaf_Message()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_MessageDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_MessageCollection : BaseEntityCollection<yaf_Message>
			{}			
		#endregion
        #region Dal
            public class yaf_MessageDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 MessageID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("MessageID", MessageID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Message_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Message Insert(yaf_Message Inserted)
                {
                    yaf_Message Item = new yaf_Message();
                    SqlParameter[] obj = new SqlParameter[11];
                    				obj[0] = new SqlParameter("TopicID", Inserted.TopicID);
				obj[1] = new SqlParameter("ReplyTo", Inserted.ReplyTo);
				obj[2] = new SqlParameter("Position", Inserted.Position);
				obj[3] = new SqlParameter("Indent", Inserted.Indent);
				obj[4] = new SqlParameter("UserID", Inserted.UserID);
				obj[5] = new SqlParameter("UserName", Inserted.UserName);
				obj[6] = new SqlParameter("Posted", Inserted.Posted);
				obj[7] = new SqlParameter("Message", Inserted.Message);
				obj[8] = new SqlParameter("IP", Inserted.IP);
				obj[9] = new SqlParameter("Edited", Inserted.Edited);
				obj[10] = new SqlParameter("Flags", Inserted.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Message_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Message Update(yaf_Message Updated)
                {
                    yaf_Message Item = new yaf_Message();
                    SqlParameter[] obj = new SqlParameter[12];
                    				obj[0] = new SqlParameter("MessageID", Updated.MessageID);
				obj[1] = new SqlParameter("TopicID", Updated.TopicID);
				obj[2] = new SqlParameter("ReplyTo", Updated.ReplyTo);
				obj[3] = new SqlParameter("Position", Updated.Position);
				obj[4] = new SqlParameter("Indent", Updated.Indent);
				obj[5] = new SqlParameter("UserID", Updated.UserID);
				obj[6] = new SqlParameter("UserName", Updated.UserName);
				obj[7] = new SqlParameter("Posted", Updated.Posted);
				obj[8] = new SqlParameter("Message", Updated.Message);
				obj[9] = new SqlParameter("IP", Updated.IP);
				obj[10] = new SqlParameter("Edited", Updated.Edited);
				obj[11] = new SqlParameter("Flags", Updated.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Message_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Message SelectById(Int32 MessageID)
                {
                    yaf_Message Item = new yaf_Message();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("MessageID", MessageID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Message_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_MessageCollection SelectAll()
                {
                    yaf_MessageCollection List = new yaf_MessageCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Message_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Message> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Message> pg = new Pager<yaf_Message>("sp_tblyaf_Message_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Message getFromReader(IDataReader rd)
                {
                    yaf_Message Item = new yaf_Message();
                    					if(rd.FieldExists("MessageID")){
					Item.MessageID = (Int32)(rd["MessageID"]);
					}
					if(rd.FieldExists("TopicID")){
					Item.TopicID = (Int32)(rd["TopicID"]);
					}
					if(rd.FieldExists("ReplyTo")){
					Item.ReplyTo = (Int32)(rd["ReplyTo"]);
					}
					if(rd.FieldExists("Position")){
					Item.Position = (Int32)(rd["Position"]);
					}
					if(rd.FieldExists("Indent")){
					Item.Indent = (Int32)(rd["Indent"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("UserName")){
					Item.UserName = (String)(rd["UserName"]);
					}
					if(rd.FieldExists("Posted")){
					Item.Posted = (DateTime)(rd["Posted"]);
					}
					if(rd.FieldExists("Message")){
					Item.Message = (String)(rd["Message"]);
					}
					if(rd.FieldExists("IP")){
					Item.IP = (String)(rd["IP"]);
					}
					if(rd.FieldExists("Edited")){
					Item.Edited = (DateTime)(rd["Edited"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_NntpForum
        #region BO
		public class yaf_NntpForum: BaseEntity
		{			
			#region Properties
			public  Int32 NntpForumID{get;set;}
			public  Int32 NntpServerID{get;set;}
			public  String GroupName{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 LastMessageNo{get;set;}
			public  DateTime LastUpdate{get;set;}
			public  Boolean Active{get;set;}
			#endregion
			#region Contructor
			public yaf_NntpForum()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_NntpServer yaf_NntpServer{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_NntpForumDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_NntpForumCollection : BaseEntityCollection<yaf_NntpForum>
			{}			
		#endregion
        #region Dal
            public class yaf_NntpForumDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 NntpForumID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpForumID", NntpForumID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpForum_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_NntpForum Insert(yaf_NntpForum Inserted)
                {
                    yaf_NntpForum Item = new yaf_NntpForum();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("NntpServerID", Inserted.NntpServerID);
				obj[1] = new SqlParameter("GroupName", Inserted.GroupName);
				obj[2] = new SqlParameter("ForumID", Inserted.ForumID);
				obj[3] = new SqlParameter("LastMessageNo", Inserted.LastMessageNo);
				obj[4] = new SqlParameter("LastUpdate", Inserted.LastUpdate);
				obj[5] = new SqlParameter("Active", Inserted.Active);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpForum_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpForum Update(yaf_NntpForum Updated)
                {
                    yaf_NntpForum Item = new yaf_NntpForum();
                    SqlParameter[] obj = new SqlParameter[7];
                    				obj[0] = new SqlParameter("NntpForumID", Updated.NntpForumID);
				obj[1] = new SqlParameter("NntpServerID", Updated.NntpServerID);
				obj[2] = new SqlParameter("GroupName", Updated.GroupName);
				obj[3] = new SqlParameter("ForumID", Updated.ForumID);
				obj[4] = new SqlParameter("LastMessageNo", Updated.LastMessageNo);
				obj[5] = new SqlParameter("LastUpdate", Updated.LastUpdate);
				obj[6] = new SqlParameter("Active", Updated.Active);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpForum_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpForum SelectById(Int32 NntpForumID)
                {
                    yaf_NntpForum Item = new yaf_NntpForum();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpForumID", NntpForumID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpForum_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpForumCollection SelectAll()
                {
                    yaf_NntpForumCollection List = new yaf_NntpForumCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpForum_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_NntpForum> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_NntpForum> pg = new Pager<yaf_NntpForum>("sp_tblyaf_NntpForum_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_NntpForum getFromReader(IDataReader rd)
                {
                    yaf_NntpForum Item = new yaf_NntpForum();
                    					if(rd.FieldExists("NntpForumID")){
					Item.NntpForumID = (Int32)(rd["NntpForumID"]);
					}
					if(rd.FieldExists("NntpServerID")){
					Item.NntpServerID = (Int32)(rd["NntpServerID"]);
					}
					if(rd.FieldExists("GroupName")){
					Item.GroupName = (String)(rd["GroupName"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("LastMessageNo")){
					Item.LastMessageNo = (Int32)(rd["LastMessageNo"]);
					}
					if(rd.FieldExists("LastUpdate")){
					Item.LastUpdate = (DateTime)(rd["LastUpdate"]);
					}
					if(rd.FieldExists("Active")){
					Item.Active = (Boolean)(rd["Active"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_NntpServer
        #region BO
		public class yaf_NntpServer: BaseEntity
		{			
			#region Properties
			public  Int32 NntpServerID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  String Address{get;set;}
			public  Int32 Port{get;set;}
			public  String UserName{get;set;}
			public  String UserPass{get;set;}
			#endregion
			#region Contructor
			public yaf_NntpServer()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_NntpServerDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_NntpServerCollection : BaseEntityCollection<yaf_NntpServer>
			{}			
		#endregion
        #region Dal
            public class yaf_NntpServerDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 NntpServerID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpServerID", NntpServerID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpServer_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_NntpServer Insert(yaf_NntpServer Inserted)
                {
                    yaf_NntpServer Item = new yaf_NntpServer();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("Address", Inserted.Address);
				obj[3] = new SqlParameter("Port", Inserted.Port);
				obj[4] = new SqlParameter("UserName", Inserted.UserName);
				obj[5] = new SqlParameter("UserPass", Inserted.UserPass);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpServer_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpServer Update(yaf_NntpServer Updated)
                {
                    yaf_NntpServer Item = new yaf_NntpServer();
                    SqlParameter[] obj = new SqlParameter[7];
                    				obj[0] = new SqlParameter("NntpServerID", Updated.NntpServerID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("Address", Updated.Address);
				obj[4] = new SqlParameter("Port", Updated.Port);
				obj[5] = new SqlParameter("UserName", Updated.UserName);
				obj[6] = new SqlParameter("UserPass", Updated.UserPass);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpServer_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpServer SelectById(Int32 NntpServerID)
                {
                    yaf_NntpServer Item = new yaf_NntpServer();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpServerID", NntpServerID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpServer_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpServerCollection SelectAll()
                {
                    yaf_NntpServerCollection List = new yaf_NntpServerCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpServer_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_NntpServer> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_NntpServer> pg = new Pager<yaf_NntpServer>("sp_tblyaf_NntpServer_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_NntpServer getFromReader(IDataReader rd)
                {
                    yaf_NntpServer Item = new yaf_NntpServer();
                    					if(rd.FieldExists("NntpServerID")){
					Item.NntpServerID = (Int32)(rd["NntpServerID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("Address")){
					Item.Address = (String)(rd["Address"]);
					}
					if(rd.FieldExists("Port")){
					Item.Port = (Int32)(rd["Port"]);
					}
					if(rd.FieldExists("UserName")){
					Item.UserName = (String)(rd["UserName"]);
					}
					if(rd.FieldExists("UserPass")){
					Item.UserPass = (String)(rd["UserPass"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_NntpTopic
        #region BO
		public class yaf_NntpTopic: BaseEntity
		{			
			#region Properties
			public  Int32 NntpTopicID{get;set;}
			public  Int32 NntpForumID{get;set;}
			public  String Thread{get;set;}
			public  Int32 TopicID{get;set;}
			#endregion
			#region Contructor
			public yaf_NntpTopic()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_NntpForum yaf_NntpForum{get;set;}
			public yaf_Topic yaf_Topic{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_NntpTopicDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_NntpTopicCollection : BaseEntityCollection<yaf_NntpTopic>
			{}			
		#endregion
        #region Dal
            public class yaf_NntpTopicDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 NntpTopicID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpTopicID", NntpTopicID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpTopic_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_NntpTopic Insert(yaf_NntpTopic Inserted)
                {
                    yaf_NntpTopic Item = new yaf_NntpTopic();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("NntpForumID", Inserted.NntpForumID);
				obj[1] = new SqlParameter("Thread", Inserted.Thread);
				obj[2] = new SqlParameter("TopicID", Inserted.TopicID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpTopic_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpTopic Update(yaf_NntpTopic Updated)
                {
                    yaf_NntpTopic Item = new yaf_NntpTopic();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("NntpTopicID", Updated.NntpTopicID);
				obj[1] = new SqlParameter("NntpForumID", Updated.NntpForumID);
				obj[2] = new SqlParameter("Thread", Updated.Thread);
				obj[3] = new SqlParameter("TopicID", Updated.TopicID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpTopic_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpTopic SelectById(Int32 NntpTopicID)
                {
                    yaf_NntpTopic Item = new yaf_NntpTopic();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("NntpTopicID", NntpTopicID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpTopic_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_NntpTopicCollection SelectAll()
                {
                    yaf_NntpTopicCollection List = new yaf_NntpTopicCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_NntpTopic_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_NntpTopic> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_NntpTopic> pg = new Pager<yaf_NntpTopic>("sp_tblyaf_NntpTopic_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_NntpTopic getFromReader(IDataReader rd)
                {
                    yaf_NntpTopic Item = new yaf_NntpTopic();
                    					if(rd.FieldExists("NntpTopicID")){
					Item.NntpTopicID = (Int32)(rd["NntpTopicID"]);
					}
					if(rd.FieldExists("NntpForumID")){
					Item.NntpForumID = (Int32)(rd["NntpForumID"]);
					}
					if(rd.FieldExists("Thread")){
					Item.Thread = (String)(rd["Thread"]);
					}
					if(rd.FieldExists("TopicID")){
					Item.TopicID = (Int32)(rd["TopicID"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_PMessage
        #region BO
		public class yaf_PMessage: BaseEntity
		{			
			#region Properties
			public  Int32 PMessageID{get;set;}
			public  Int32 FromUserID{get;set;}
			public  DateTime Created{get;set;}
			public  String Subject{get;set;}
			public  String Body{get;set;}
			public  Int32 Flags{get;set;}
			#endregion
			#region Contructor
			public yaf_PMessage()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_PMessageDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_PMessageCollection : BaseEntityCollection<yaf_PMessage>
			{}			
		#endregion
        #region Dal
            public class yaf_PMessageDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 PMessageID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PMessageID", PMessageID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PMessage_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_PMessage Insert(yaf_PMessage Inserted)
                {
                    yaf_PMessage Item = new yaf_PMessage();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("FromUserID", Inserted.FromUserID);
				obj[1] = new SqlParameter("Created", Inserted.Created);
				obj[2] = new SqlParameter("Subject", Inserted.Subject);
				obj[3] = new SqlParameter("Body", Inserted.Body);
				obj[4] = new SqlParameter("Flags", Inserted.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PMessage_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PMessage Update(yaf_PMessage Updated)
                {
                    yaf_PMessage Item = new yaf_PMessage();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("PMessageID", Updated.PMessageID);
				obj[1] = new SqlParameter("FromUserID", Updated.FromUserID);
				obj[2] = new SqlParameter("Created", Updated.Created);
				obj[3] = new SqlParameter("Subject", Updated.Subject);
				obj[4] = new SqlParameter("Body", Updated.Body);
				obj[5] = new SqlParameter("Flags", Updated.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PMessage_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PMessage SelectById(Int32 PMessageID)
                {
                    yaf_PMessage Item = new yaf_PMessage();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PMessageID", PMessageID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PMessage_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PMessageCollection SelectAll()
                {
                    yaf_PMessageCollection List = new yaf_PMessageCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PMessage_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_PMessage> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_PMessage> pg = new Pager<yaf_PMessage>("sp_tblyaf_PMessage_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_PMessage getFromReader(IDataReader rd)
                {
                    yaf_PMessage Item = new yaf_PMessage();
                    					if(rd.FieldExists("PMessageID")){
					Item.PMessageID = (Int32)(rd["PMessageID"]);
					}
					if(rd.FieldExists("FromUserID")){
					Item.FromUserID = (Int32)(rd["FromUserID"]);
					}
					if(rd.FieldExists("Created")){
					Item.Created = (DateTime)(rd["Created"]);
					}
					if(rd.FieldExists("Subject")){
					Item.Subject = (String)(rd["Subject"]);
					}
					if(rd.FieldExists("Body")){
					Item.Body = (String)(rd["Body"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Poll
        #region BO
		public class yaf_Poll: BaseEntity
		{			
			#region Properties
			public  Int32 PollID{get;set;}
			public  String Question{get;set;}
			public  DateTime Closes{get;set;}
			#endregion
			#region Contructor
			public yaf_Poll()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_PollDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_PollCollection : BaseEntityCollection<yaf_Poll>
			{}			
		#endregion
        #region Dal
            public class yaf_PollDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 PollID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PollID", PollID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Poll_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Poll Insert(yaf_Poll Inserted)
                {
                    yaf_Poll Item = new yaf_Poll();
                    SqlParameter[] obj = new SqlParameter[2];
                    				obj[0] = new SqlParameter("Question", Inserted.Question);
				obj[1] = new SqlParameter("Closes", Inserted.Closes);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Poll_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Poll Update(yaf_Poll Updated)
                {
                    yaf_Poll Item = new yaf_Poll();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("PollID", Updated.PollID);
				obj[1] = new SqlParameter("Question", Updated.Question);
				obj[2] = new SqlParameter("Closes", Updated.Closes);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Poll_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Poll SelectById(Int32 PollID)
                {
                    yaf_Poll Item = new yaf_Poll();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PollID", PollID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Poll_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PollCollection SelectAll()
                {
                    yaf_PollCollection List = new yaf_PollCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Poll_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Poll> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Poll> pg = new Pager<yaf_Poll>("sp_tblyaf_Poll_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Poll getFromReader(IDataReader rd)
                {
                    yaf_Poll Item = new yaf_Poll();
                    					if(rd.FieldExists("PollID")){
					Item.PollID = (Int32)(rd["PollID"]);
					}
					if(rd.FieldExists("Question")){
					Item.Question = (String)(rd["Question"]);
					}
					if(rd.FieldExists("Closes")){
					Item.Closes = (DateTime)(rd["Closes"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_PollVote
        #region BO
		public class yaf_PollVote: BaseEntity
		{			
			#region Properties
			public  Int32 PollVoteID{get;set;}
			public  Int32 PollID{get;set;}
			public  Int32 UserID{get;set;}
			public  String RemoteIP{get;set;}
			#endregion
			#region Contructor
			public yaf_PollVote()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Poll yaf_Poll{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_PollVoteDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_PollVoteCollection : BaseEntityCollection<yaf_PollVote>
			{}			
		#endregion
        #region Dal
            public class yaf_PollVoteDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 PollVoteID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PollVoteID", PollVoteID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PollVote_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_PollVote Insert(yaf_PollVote Inserted)
                {
                    yaf_PollVote Item = new yaf_PollVote();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("PollID", Inserted.PollID);
				obj[1] = new SqlParameter("UserID", Inserted.UserID);
				obj[2] = new SqlParameter("RemoteIP", Inserted.RemoteIP);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PollVote_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PollVote Update(yaf_PollVote Updated)
                {
                    yaf_PollVote Item = new yaf_PollVote();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("PollVoteID", Updated.PollVoteID);
				obj[1] = new SqlParameter("PollID", Updated.PollID);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("RemoteIP", Updated.RemoteIP);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PollVote_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PollVote SelectById(Int32 PollVoteID)
                {
                    yaf_PollVote Item = new yaf_PollVote();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("PollVoteID", PollVoteID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PollVote_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_PollVoteCollection SelectAll()
                {
                    yaf_PollVoteCollection List = new yaf_PollVoteCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_PollVote_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_PollVote> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_PollVote> pg = new Pager<yaf_PollVote>("sp_tblyaf_PollVote_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_PollVote getFromReader(IDataReader rd)
                {
                    yaf_PollVote Item = new yaf_PollVote();
                    					if(rd.FieldExists("PollVoteID")){
					Item.PollVoteID = (Int32)(rd["PollVoteID"]);
					}
					if(rd.FieldExists("PollID")){
					Item.PollID = (Int32)(rd["PollID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("RemoteIP")){
					Item.RemoteIP = (String)(rd["RemoteIP"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Rank
        #region BO
		public class yaf_Rank: BaseEntity
		{			
			#region Properties
			public  Int32 RankID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  Int32 MinPosts{get;set;}
			public  String RankImage{get;set;}
			public  Int32 Flags{get;set;}
			#endregion
			#region Contructor
			public yaf_Rank()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_RankDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_RankCollection : BaseEntityCollection<yaf_Rank>
			{}			
		#endregion
        #region Dal
            public class yaf_RankDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 RankID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("RankID", RankID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Rank_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Rank Insert(yaf_Rank Inserted)
                {
                    yaf_Rank Item = new yaf_Rank();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("MinPosts", Inserted.MinPosts);
				obj[3] = new SqlParameter("RankImage", Inserted.RankImage);
				obj[4] = new SqlParameter("Flags", Inserted.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Rank_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Rank Update(yaf_Rank Updated)
                {
                    yaf_Rank Item = new yaf_Rank();
                    SqlParameter[] obj = new SqlParameter[6];
                    				obj[0] = new SqlParameter("RankID", Updated.RankID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("MinPosts", Updated.MinPosts);
				obj[4] = new SqlParameter("RankImage", Updated.RankImage);
				obj[5] = new SqlParameter("Flags", Updated.Flags);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Rank_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Rank SelectById(Int32 RankID)
                {
                    yaf_Rank Item = new yaf_Rank();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("RankID", RankID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Rank_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_RankCollection SelectAll()
                {
                    yaf_RankCollection List = new yaf_RankCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Rank_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Rank> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Rank> pg = new Pager<yaf_Rank>("sp_tblyaf_Rank_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Rank getFromReader(IDataReader rd)
                {
                    yaf_Rank Item = new yaf_Rank();
                    					if(rd.FieldExists("RankID")){
					Item.RankID = (Int32)(rd["RankID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("MinPosts")){
					Item.MinPosts = (Int32)(rd["MinPosts"]);
					}
					if(rd.FieldExists("RankImage")){
					Item.RankImage = (String)(rd["RankImage"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Registry
        #region BO
		public class yaf_Registry: BaseEntity
		{			
			#region Properties
			public  Int32 RegistryID{get;set;}
			public  String Name{get;set;}
			public  String VALUE{get;set;}
			public  Int32 BoardID{get;set;}
			#endregion
			#region Contructor
			public yaf_Registry()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_RegistryDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_RegistryCollection : BaseEntityCollection<yaf_Registry>
			{}			
		#endregion
        #region Dal
            public class yaf_RegistryDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 RegistryID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("RegistryID", RegistryID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Registry_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Registry Insert(yaf_Registry Inserted)
                {
                    yaf_Registry Item = new yaf_Registry();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("Name", Inserted.Name);
				obj[1] = new SqlParameter("VALUE", Inserted.VALUE);
				obj[2] = new SqlParameter("BoardID", Inserted.BoardID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Registry_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Registry Update(yaf_Registry Updated)
                {
                    yaf_Registry Item = new yaf_Registry();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("RegistryID", Updated.RegistryID);
				obj[1] = new SqlParameter("Name", Updated.Name);
				obj[2] = new SqlParameter("VALUE", Updated.VALUE);
				obj[3] = new SqlParameter("BoardID", Updated.BoardID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Registry_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Registry SelectById(Int32 RegistryID)
                {
                    yaf_Registry Item = new yaf_Registry();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("RegistryID", RegistryID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Registry_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_RegistryCollection SelectAll()
                {
                    yaf_RegistryCollection List = new yaf_RegistryCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Registry_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Registry> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Registry> pg = new Pager<yaf_Registry>("sp_tblyaf_Registry_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Registry getFromReader(IDataReader rd)
                {
                    yaf_Registry Item = new yaf_Registry();
                    					if(rd.FieldExists("RegistryID")){
					Item.RegistryID = (Int32)(rd["RegistryID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("VALUE")){
					Item.VALUE = (String)(rd["VALUE"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Replace_Words
        #region BO
		public class yaf_Replace_Words: BaseEntity
		{			
			#region Properties
			public  Int32 id{get;set;}
			public  String badword{get;set;}
			public  String goodword{get;set;}
			#endregion
			#region Contructor
			public yaf_Replace_Words()
			{ }
			#endregion
			#region Customs properties
			
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_Replace_WordsDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_Replace_WordsCollection : BaseEntityCollection<yaf_Replace_Words>
			{}			
		#endregion
        #region Dal
            public class yaf_Replace_WordsDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 id)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("id", id);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Replace_Words_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Replace_Words Insert(yaf_Replace_Words Inserted)
                {
                    yaf_Replace_Words Item = new yaf_Replace_Words();
                    SqlParameter[] obj = new SqlParameter[2];
                    				obj[0] = new SqlParameter("badword", Inserted.badword);
				obj[1] = new SqlParameter("goodword", Inserted.goodword);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Replace_Words_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Replace_Words Update(yaf_Replace_Words Updated)
                {
                    yaf_Replace_Words Item = new yaf_Replace_Words();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("id", Updated.id);
				obj[1] = new SqlParameter("badword", Updated.badword);
				obj[2] = new SqlParameter("goodword", Updated.goodword);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Replace_Words_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Replace_Words SelectById(Int32 id)
                {
                    yaf_Replace_Words Item = new yaf_Replace_Words();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("id", id);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Replace_Words_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Replace_WordsCollection SelectAll()
                {
                    yaf_Replace_WordsCollection List = new yaf_Replace_WordsCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Replace_Words_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Replace_Words> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Replace_Words> pg = new Pager<yaf_Replace_Words>("sp_tblyaf_Replace_Words_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Replace_Words getFromReader(IDataReader rd)
                {
                    yaf_Replace_Words Item = new yaf_Replace_Words();
                    					if(rd.FieldExists("id")){
					Item.id = (Int32)(rd["id"]);
					}
					if(rd.FieldExists("badword")){
					Item.badword = (String)(rd["badword"]);
					}
					if(rd.FieldExists("goodword")){
					Item.goodword = (String)(rd["goodword"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Smiley
        #region BO
		public class yaf_Smiley: BaseEntity
		{			
			#region Properties
			public  Int32 SmileyID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Code{get;set;}
			public  String Icon{get;set;}
			public  String Emoticon{get;set;}
			#endregion
			#region Contructor
			public yaf_Smiley()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_SmileyDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_SmileyCollection : BaseEntityCollection<yaf_Smiley>
			{}			
		#endregion
        #region Dal
            public class yaf_SmileyDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 SmileyID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("SmileyID", SmileyID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Smiley_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Smiley Insert(yaf_Smiley Inserted)
                {
                    yaf_Smiley Item = new yaf_Smiley();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Code", Inserted.Code);
				obj[2] = new SqlParameter("Icon", Inserted.Icon);
				obj[3] = new SqlParameter("Emoticon", Inserted.Emoticon);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Smiley_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Smiley Update(yaf_Smiley Updated)
                {
                    yaf_Smiley Item = new yaf_Smiley();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("SmileyID", Updated.SmileyID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Code", Updated.Code);
				obj[3] = new SqlParameter("Icon", Updated.Icon);
				obj[4] = new SqlParameter("Emoticon", Updated.Emoticon);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Smiley_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Smiley SelectById(Int32 SmileyID)
                {
                    yaf_Smiley Item = new yaf_Smiley();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("SmileyID", SmileyID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Smiley_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_SmileyCollection SelectAll()
                {
                    yaf_SmileyCollection List = new yaf_SmileyCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Smiley_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_Smiley> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Smiley> pg = new Pager<yaf_Smiley>("sp_tblyaf_Smiley_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Smiley getFromReader(IDataReader rd)
                {
                    yaf_Smiley Item = new yaf_Smiley();
                    					if(rd.FieldExists("SmileyID")){
					Item.SmileyID = (Int32)(rd["SmileyID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Code")){
					Item.Code = (String)(rd["Code"]);
					}
					if(rd.FieldExists("Icon")){
					Item.Icon = (String)(rd["Icon"]);
					}
					if(rd.FieldExists("Emoticon")){
					Item.Emoticon = (String)(rd["Emoticon"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_Topic
        #region BO
		public class yaf_Topic: BaseEntity
		{			
			#region Properties
			public  Int32 TopicID{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 UserID{get;set;}
			public  String UserName{get;set;}
			public  DateTime Posted{get;set;}
			public  String Topic{get;set;}
			public  Int32 Views{get;set;}
			public  Int16 Priority{get;set;}
			public  Int32 PollID{get;set;}
			public  Int32 TopicMovedID{get;set;}
			public  DateTime LastPosted{get;set;}
			public  Int32 LastMessageID{get;set;}
			public  Int32 LastUserID{get;set;}
			public  String LastUserName{get;set;}
			public  Int32 NumPosts{get;set;}
			public  Int32 Flags{get;set;}
			public  String keyword{get;set;}
			#endregion
			#region Contructor
			public yaf_Topic()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_Poll yaf_Poll{get;set;}
			//public yaf_Topic yaf_Topic {get;set;}
			public yaf_User yaf_User{get;set;}
			//public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_TopicDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_TopicCollection : BaseEntityCollection<yaf_Topic>
			{}			
		#endregion
        #region Dal
            public class yaf_TopicDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 TopicID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("TopicID", TopicID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_Topic Insert(yaf_Topic Inserted)
                {
                    yaf_Topic Item = new yaf_Topic();
                    SqlParameter[] obj = new SqlParameter[16];
                    				obj[0] = new SqlParameter("ForumID", Inserted.ForumID);
				obj[1] = new SqlParameter("UserID", Inserted.UserID);
				obj[2] = new SqlParameter("UserName", Inserted.UserName);
				obj[3] = new SqlParameter("Posted", Inserted.Posted);
				obj[4] = new SqlParameter("Topic", Inserted.Topic);
				obj[5] = new SqlParameter("Views", Inserted.Views);
				obj[6] = new SqlParameter("Priority", Inserted.Priority);
				obj[7] = new SqlParameter("PollID", Inserted.PollID);
				obj[8] = new SqlParameter("TopicMovedID", Inserted.TopicMovedID);
				obj[9] = new SqlParameter("LastPosted", Inserted.LastPosted);
				obj[10] = new SqlParameter("LastMessageID", Inserted.LastMessageID);
				obj[11] = new SqlParameter("LastUserID", Inserted.LastUserID);
				obj[12] = new SqlParameter("LastUserName", Inserted.LastUserName);
				obj[13] = new SqlParameter("NumPosts", Inserted.NumPosts);
				obj[14] = new SqlParameter("Flags", Inserted.Flags);
				obj[15] = new SqlParameter("keyword", Inserted.keyword);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Topic Update(yaf_Topic Updated)
                {
                    yaf_Topic Item = new yaf_Topic();
                    SqlParameter[] obj = new SqlParameter[17];
                    				obj[0] = new SqlParameter("TopicID", Updated.TopicID);
				obj[1] = new SqlParameter("ForumID", Updated.ForumID);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("UserName", Updated.UserName);
				obj[4] = new SqlParameter("Posted", Updated.Posted);
				obj[5] = new SqlParameter("Topic", Updated.Topic);
				obj[6] = new SqlParameter("Views", Updated.Views);
				obj[7] = new SqlParameter("Priority", Updated.Priority);
				obj[8] = new SqlParameter("PollID", Updated.PollID);
				obj[9] = new SqlParameter("TopicMovedID", Updated.TopicMovedID);
				obj[10] = new SqlParameter("LastPosted", Updated.LastPosted);
				obj[11] = new SqlParameter("LastMessageID", Updated.LastMessageID);
				obj[12] = new SqlParameter("LastUserID", Updated.LastUserID);
				obj[13] = new SqlParameter("LastUserName", Updated.LastUserName);
				obj[14] = new SqlParameter("NumPosts", Updated.NumPosts);
				obj[15] = new SqlParameter("Flags", Updated.Flags);
				obj[16] = new SqlParameter("keyword", Updated.keyword);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_Topic SelectById(Int32 TopicID)
                {
                    yaf_Topic Item = new yaf_Topic();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("TopicID", TopicID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_TopicCollection SelectAll()
                {
                    yaf_TopicCollection List = new yaf_TopicCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
                public static yaf_TopicCollection SelectTopicNew(int Top)
                {
                    yaf_TopicCollection List = new yaf_TopicCollection();
                    SqlParameter[] obj = new SqlParameter[1];

                    obj[0] = new SqlParameter("Top", Top);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_Topic_Select_SelectNewHome_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
               
				public static Pager<yaf_Topic> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_Topic> pg = new Pager<yaf_Topic>("sp_tblyaf_Topic_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_Topic getFromReader(IDataReader rd)
                {
                    yaf_Topic Item = new yaf_Topic();
                    					if(rd.FieldExists("TopicID")){
					Item.TopicID = (Int32)(rd["TopicID"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("UserName")){
					Item.UserName = (String)(rd["UserName"]);
					}
					if(rd.FieldExists("Posted")){
					Item.Posted = (DateTime)(rd["Posted"]);
					}
					if(rd.FieldExists("Topic")){
					Item.Topic = (String)(rd["Topic"]);
					}
					if(rd.FieldExists("Views")){
					Item.Views = (Int32)(rd["Views"]);
					}
					if(rd.FieldExists("Priority")){
					Item.Priority = (Int16)(rd["Priority"]);
					}
					if(rd.FieldExists("PollID")){
					Item.PollID = (Int32)(rd["PollID"]);
					}
					if(rd.FieldExists("TopicMovedID")){
					Item.TopicMovedID = (Int32)(rd["TopicMovedID"]);
					}
					if(rd.FieldExists("LastPosted")){
					Item.LastPosted = (DateTime)(rd["LastPosted"]);
					}
					if(rd.FieldExists("LastMessageID")){
					Item.LastMessageID = (Int32)(rd["LastMessageID"]);
					}
					if(rd.FieldExists("LastUserID")){
					Item.LastUserID = (Int32)(rd["LastUserID"]);
					}
					if(rd.FieldExists("LastUserName")){
					Item.LastUserName = (String)(rd["LastUserName"]);
					}
					if(rd.FieldExists("NumPosts")){
					Item.NumPosts = (Int32)(rd["NumPosts"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
					if(rd.FieldExists("keyword")){
					Item.keyword = (String)(rd["keyword"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_User
        #region BO
		public class yaf_User: BaseEntity
		{			
			#region Properties
			public  Int32 UserID{get;set;}
			public  Int32 BoardID{get;set;}
			public  String Name{get;set;}
			public  String Password{get;set;}
			public  String Email{get;set;}
			public  DateTime Joined{get;set;}
			public  DateTime LastVisit{get;set;}
			public  String IP{get;set;}
			public  Int32 NumPosts{get;set;}
			public  String Location{get;set;}
			public  String HomePage{get;set;}
			public  Int32 TimeZone{get;set;}
			public  String Avatar{get;set;}
			public  String Signature{get;set;}
			public  Byte[] AvatarImage{get;set;}
			public  Int32 RankID{get;set;}
			public  DateTime Suspended{get;set;}
			public  String LanguageFile{get;set;}
			public  String ThemeFile{get;set;}
			public  String MSN{get;set;}
			public  String YIM{get;set;}
			public  String AIM{get;set;}
			public  Int32 ICQ{get;set;}
			public  String RealName{get;set;}
			public  String Occupation{get;set;}
			public  String Interests{get;set;}
			public  Byte Gender{get;set;}
			public  String Weblog{get;set;}
			public  Boolean PMNotification{get;set;}
			public  Int32 Flags{get;set;}
			public  Int32 Points{get;set;}
			#endregion
			#region Contructor
			public yaf_User()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Board yaf_Board{get;set;}
			public yaf_Rank yaf_Rank{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_UserDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_UserCollection : BaseEntityCollection<yaf_User>
			{}			
		#endregion
        #region Dal
            public class yaf_UserDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 UserID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_User_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_User Insert(yaf_User Inserted)
                {
                    yaf_User Item = new yaf_User();
                    SqlParameter[] obj = new SqlParameter[30];
                    				obj[0] = new SqlParameter("BoardID", Inserted.BoardID);
				obj[1] = new SqlParameter("Name", Inserted.Name);
				obj[2] = new SqlParameter("Password", Inserted.Password);
				obj[3] = new SqlParameter("Email", Inserted.Email);
				obj[4] = new SqlParameter("Joined", Inserted.Joined);
				obj[5] = new SqlParameter("LastVisit", Inserted.LastVisit);
				obj[6] = new SqlParameter("IP", Inserted.IP);
				obj[7] = new SqlParameter("NumPosts", Inserted.NumPosts);
				obj[8] = new SqlParameter("Location", Inserted.Location);
				obj[9] = new SqlParameter("HomePage", Inserted.HomePage);
				obj[10] = new SqlParameter("TimeZone", Inserted.TimeZone);
				obj[11] = new SqlParameter("Avatar", Inserted.Avatar);
				obj[12] = new SqlParameter("Signature", Inserted.Signature);
				obj[13] = new SqlParameter("AvatarImage", Inserted.AvatarImage);
				obj[14] = new SqlParameter("RankID", Inserted.RankID);
				obj[15] = new SqlParameter("Suspended", Inserted.Suspended);
				obj[16] = new SqlParameter("LanguageFile", Inserted.LanguageFile);
				obj[17] = new SqlParameter("ThemeFile", Inserted.ThemeFile);
				obj[18] = new SqlParameter("MSN", Inserted.MSN);
				obj[19] = new SqlParameter("YIM", Inserted.YIM);
				obj[20] = new SqlParameter("AIM", Inserted.AIM);
				obj[21] = new SqlParameter("ICQ", Inserted.ICQ);
				obj[22] = new SqlParameter("RealName", Inserted.RealName);
				obj[23] = new SqlParameter("Occupation", Inserted.Occupation);
				obj[24] = new SqlParameter("Interests", Inserted.Interests);
				obj[25] = new SqlParameter("Gender", Inserted.Gender);
				obj[26] = new SqlParameter("Weblog", Inserted.Weblog);
				obj[27] = new SqlParameter("PMNotification", Inserted.PMNotification);
				obj[28] = new SqlParameter("Flags", Inserted.Flags);
				obj[29] = new SqlParameter("Points", Inserted.Points);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_User_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_User Update(yaf_User Updated)
                {
                    yaf_User Item = new yaf_User();
                    SqlParameter[] obj = new SqlParameter[31];
                    				obj[0] = new SqlParameter("UserID", Updated.UserID);
				obj[1] = new SqlParameter("BoardID", Updated.BoardID);
				obj[2] = new SqlParameter("Name", Updated.Name);
				obj[3] = new SqlParameter("Password", Updated.Password);
				obj[4] = new SqlParameter("Email", Updated.Email);
				obj[5] = new SqlParameter("Joined", Updated.Joined);
				obj[6] = new SqlParameter("LastVisit", Updated.LastVisit);
				obj[7] = new SqlParameter("IP", Updated.IP);
				obj[8] = new SqlParameter("NumPosts", Updated.NumPosts);
				obj[9] = new SqlParameter("Location", Updated.Location);
				obj[10] = new SqlParameter("HomePage", Updated.HomePage);
				obj[11] = new SqlParameter("TimeZone", Updated.TimeZone);
				obj[12] = new SqlParameter("Avatar", Updated.Avatar);
				obj[13] = new SqlParameter("Signature", Updated.Signature);
				obj[14] = new SqlParameter("AvatarImage", Updated.AvatarImage);
				obj[15] = new SqlParameter("RankID", Updated.RankID);
				obj[16] = new SqlParameter("Suspended", Updated.Suspended);
				obj[17] = new SqlParameter("LanguageFile", Updated.LanguageFile);
				obj[18] = new SqlParameter("ThemeFile", Updated.ThemeFile);
				obj[19] = new SqlParameter("MSN", Updated.MSN);
				obj[20] = new SqlParameter("YIM", Updated.YIM);
				obj[21] = new SqlParameter("AIM", Updated.AIM);
				obj[22] = new SqlParameter("ICQ", Updated.ICQ);
				obj[23] = new SqlParameter("RealName", Updated.RealName);
				obj[24] = new SqlParameter("Occupation", Updated.Occupation);
				obj[25] = new SqlParameter("Interests", Updated.Interests);
				obj[26] = new SqlParameter("Gender", Updated.Gender);
				obj[27] = new SqlParameter("Weblog", Updated.Weblog);
				obj[28] = new SqlParameter("PMNotification", Updated.PMNotification);
				obj[29] = new SqlParameter("Flags", Updated.Flags);
				obj[30] = new SqlParameter("Points", Updated.Points);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_User_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_User SelectById(Int32 UserID)
                {
                    yaf_User Item = new yaf_User();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_User_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserCollection SelectAll()
                {
                    yaf_UserCollection List = new yaf_UserCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_User_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_User> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_User> pg = new Pager<yaf_User>("sp_tblyaf_User_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_User getFromReader(IDataReader rd)
                {
                    yaf_User Item = new yaf_User();
                    					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("BoardID")){
					Item.BoardID = (Int32)(rd["BoardID"]);
					}
					if(rd.FieldExists("Name")){
					Item.Name = (String)(rd["Name"]);
					}
					if(rd.FieldExists("Password")){
					Item.Password = (String)(rd["Password"]);
					}
					if(rd.FieldExists("Email")){
					Item.Email = (String)(rd["Email"]);
					}
					if(rd.FieldExists("Joined")){
					Item.Joined = (DateTime)(rd["Joined"]);
					}
					if(rd.FieldExists("LastVisit")){
					Item.LastVisit = (DateTime)(rd["LastVisit"]);
					}
					if(rd.FieldExists("IP")){
					Item.IP = (String)(rd["IP"]);
					}
					if(rd.FieldExists("NumPosts")){
					Item.NumPosts = (Int32)(rd["NumPosts"]);
					}
					if(rd.FieldExists("Location")){
					Item.Location = (String)(rd["Location"]);
					}
					if(rd.FieldExists("HomePage")){
					Item.HomePage = (String)(rd["HomePage"]);
					}
					if(rd.FieldExists("TimeZone")){
					Item.TimeZone = (Int32)(rd["TimeZone"]);
					}
					if(rd.FieldExists("Avatar")){
					Item.Avatar = (String)(rd["Avatar"]);
					}
					if(rd.FieldExists("Signature")){
					Item.Signature = (String)(rd["Signature"]);
					}
					if(rd.FieldExists("AvatarImage")){
					Item.AvatarImage = (Byte[])(rd["AvatarImage"]);
					}
					if(rd.FieldExists("RankID")){
					Item.RankID = (Int32)(rd["RankID"]);
					}
					if(rd.FieldExists("Suspended")){
					Item.Suspended = (DateTime)(rd["Suspended"]);
					}
					if(rd.FieldExists("LanguageFile")){
					Item.LanguageFile = (String)(rd["LanguageFile"]);
					}
					if(rd.FieldExists("ThemeFile")){
					Item.ThemeFile = (String)(rd["ThemeFile"]);
					}
					if(rd.FieldExists("MSN")){
					Item.MSN = (String)(rd["MSN"]);
					}
					if(rd.FieldExists("YIM")){
					Item.YIM = (String)(rd["YIM"]);
					}
					if(rd.FieldExists("AIM")){
					Item.AIM = (String)(rd["AIM"]);
					}
					if(rd.FieldExists("ICQ")){
					Item.ICQ = (Int32)(rd["ICQ"]);
					}
					if(rd.FieldExists("RealName")){
					Item.RealName = (String)(rd["RealName"]);
					}
					if(rd.FieldExists("Occupation")){
					Item.Occupation = (String)(rd["Occupation"]);
					}
					if(rd.FieldExists("Interests")){
					Item.Interests = (String)(rd["Interests"]);
					}
					if(rd.FieldExists("Gender")){
					Item.Gender = (Byte)(rd["Gender"]);
					}
					if(rd.FieldExists("Weblog")){
					Item.Weblog = (String)(rd["Weblog"]);
					}
					if(rd.FieldExists("PMNotification")){
					Item.PMNotification = (Boolean)(rd["PMNotification"]);
					}
					if(rd.FieldExists("Flags")){
					Item.Flags = (Int32)(rd["Flags"]);
					}
					if(rd.FieldExists("Points")){
					Item.Points = (Int32)(rd["Points"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_UserForum
        #region BO
		public class yaf_UserForum: BaseEntity
		{			
			#region Properties
			public  Int32 UserID{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 AccessMaskID{get;set;}
			public  DateTime Invited{get;set;}
			public  Boolean Accepted{get;set;}
			#endregion
			#region Contructor
			public yaf_UserForum()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_AccessMask yaf_AccessMask{get;set;}
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_UserForumDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_UserForumCollection : BaseEntityCollection<yaf_UserForum>
			{}			
		#endregion
        #region Dal
            public class yaf_UserForumDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 UserID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserForum_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_UserForum Insert(yaf_UserForum Inserted)
                {
                    yaf_UserForum Item = new yaf_UserForum();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("AccessMaskID", Inserted.AccessMaskID);
				obj[1] = new SqlParameter("Invited", Inserted.Invited);
				obj[2] = new SqlParameter("Accepted", Inserted.Accepted);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserForum_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserForum Update(yaf_UserForum Updated)
                {
                    yaf_UserForum Item = new yaf_UserForum();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("UserID", Updated.UserID);
				obj[1] = new SqlParameter("ForumID", Updated.ForumID);
				obj[2] = new SqlParameter("AccessMaskID", Updated.AccessMaskID);
				obj[3] = new SqlParameter("Invited", Updated.Invited);
				obj[4] = new SqlParameter("Accepted", Updated.Accepted);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserForum_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserForum SelectById(Int32 UserID)
                {
                    yaf_UserForum Item = new yaf_UserForum();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserForum_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserForumCollection SelectAll()
                {
                    yaf_UserForumCollection List = new yaf_UserForumCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserForum_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_UserForum> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_UserForum> pg = new Pager<yaf_UserForum>("sp_tblyaf_UserForum_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_UserForum getFromReader(IDataReader rd)
                {
                    yaf_UserForum Item = new yaf_UserForum();
                    					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("AccessMaskID")){
					Item.AccessMaskID = (Int32)(rd["AccessMaskID"]);
					}
					if(rd.FieldExists("Invited")){
					Item.Invited = (DateTime)(rd["Invited"]);
					}
					if(rd.FieldExists("Accepted")){
					Item.Accepted = (Boolean)(rd["Accepted"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_UserGroup
        #region BO
		public class yaf_UserGroup: BaseEntity
		{			
			#region Properties
			public  Int32 UserID{get;set;}
			public  Int32 GroupID{get;set;}
			#endregion
			#region Contructor
			public yaf_UserGroup()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Group yaf_Group{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_UserGroupDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_UserGroupCollection : BaseEntityCollection<yaf_UserGroup>
			{}			
		#endregion
        #region Dal
            public class yaf_UserGroupDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 UserID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserGroup_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_UserGroup Insert(yaf_UserGroup Inserted)
                {
                    yaf_UserGroup Item = new yaf_UserGroup();
                    SqlParameter[] obj = new SqlParameter[1];
                    
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserGroup_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserGroup Update(yaf_UserGroup Updated)
                {
                    yaf_UserGroup Item = new yaf_UserGroup();
                    SqlParameter[] obj = new SqlParameter[2];
                    				obj[0] = new SqlParameter("UserID", Updated.UserID);
				obj[1] = new SqlParameter("GroupID", Updated.GroupID);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserGroup_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserGroup SelectById(Int32 UserID)
                {
                    yaf_UserGroup Item = new yaf_UserGroup();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserID", UserID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserGroup_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserGroupCollection SelectAll()
                {
                    yaf_UserGroupCollection List = new yaf_UserGroupCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserGroup_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_UserGroup> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_UserGroup> pg = new Pager<yaf_UserGroup>("sp_tblyaf_UserGroup_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_UserGroup getFromReader(IDataReader rd)
                {
                    yaf_UserGroup Item = new yaf_UserGroup();
                    					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("GroupID")){
					Item.GroupID = (Int32)(rd["GroupID"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_UserPMessage
        #region BO
		public class yaf_UserPMessage: BaseEntity
		{			
			#region Properties
			public  Int32 UserPMessageID{get;set;}
			public  Int32 UserID{get;set;}
			public  Int32 PMessageID{get;set;}
			public  Boolean IsRead{get;set;}
			#endregion
			#region Contructor
			public yaf_UserPMessage()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_UserPMessageDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_UserPMessageCollection : BaseEntityCollection<yaf_UserPMessage>
			{}			
		#endregion
        #region Dal
            public class yaf_UserPMessageDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 UserPMessageID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserPMessageID", UserPMessageID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserPMessage_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_UserPMessage Insert(yaf_UserPMessage Inserted)
                {
                    yaf_UserPMessage Item = new yaf_UserPMessage();
                    SqlParameter[] obj = new SqlParameter[3];
                    				obj[0] = new SqlParameter("UserID", Inserted.UserID);
				obj[1] = new SqlParameter("PMessageID", Inserted.PMessageID);
				obj[2] = new SqlParameter("IsRead", Inserted.IsRead);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserPMessage_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserPMessage Update(yaf_UserPMessage Updated)
                {
                    yaf_UserPMessage Item = new yaf_UserPMessage();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("UserPMessageID", Updated.UserPMessageID);
				obj[1] = new SqlParameter("UserID", Updated.UserID);
				obj[2] = new SqlParameter("PMessageID", Updated.PMessageID);
				obj[3] = new SqlParameter("IsRead", Updated.IsRead);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserPMessage_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserPMessage SelectById(Int32 UserPMessageID)
                {
                    yaf_UserPMessage Item = new yaf_UserPMessage();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("UserPMessageID", UserPMessageID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserPMessage_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_UserPMessageCollection SelectAll()
                {
                    yaf_UserPMessageCollection List = new yaf_UserPMessageCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_UserPMessage_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_UserPMessage> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_UserPMessage> pg = new Pager<yaf_UserPMessage>("sp_tblyaf_UserPMessage_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_UserPMessage getFromReader(IDataReader rd)
                {
                    yaf_UserPMessage Item = new yaf_UserPMessage();
                    					if(rd.FieldExists("UserPMessageID")){
					Item.UserPMessageID = (Int32)(rd["UserPMessageID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("PMessageID")){
					Item.PMessageID = (Int32)(rd["PMessageID"]);
					}
					if(rd.FieldExists("IsRead")){
					Item.IsRead = (Boolean)(rd["IsRead"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_WatchForum
        #region BO
		public class yaf_WatchForum: BaseEntity
		{			
			#region Properties
			public  Int32 WatchForumID{get;set;}
			public  Int32 ForumID{get;set;}
			public  Int32 UserID{get;set;}
			public  DateTime Created{get;set;}
			public  DateTime LastMail{get;set;}
			#endregion
			#region Contructor
			public yaf_WatchForum()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Forum yaf_Forum{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_WatchForumDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_WatchForumCollection : BaseEntityCollection<yaf_WatchForum>
			{}			
		#endregion
        #region Dal
            public class yaf_WatchForumDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 WatchForumID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WatchForumID", WatchForumID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchForum_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_WatchForum Insert(yaf_WatchForum Inserted)
                {
                    yaf_WatchForum Item = new yaf_WatchForum();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("ForumID", Inserted.ForumID);
				obj[1] = new SqlParameter("UserID", Inserted.UserID);
				obj[2] = new SqlParameter("Created", Inserted.Created);
				obj[3] = new SqlParameter("LastMail", Inserted.LastMail);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchForum_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchForum Update(yaf_WatchForum Updated)
                {
                    yaf_WatchForum Item = new yaf_WatchForum();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("WatchForumID", Updated.WatchForumID);
				obj[1] = new SqlParameter("ForumID", Updated.ForumID);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("Created", Updated.Created);
				obj[4] = new SqlParameter("LastMail", Updated.LastMail);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchForum_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchForum SelectById(Int32 WatchForumID)
                {
                    yaf_WatchForum Item = new yaf_WatchForum();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WatchForumID", WatchForumID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchForum_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchForumCollection SelectAll()
                {
                    yaf_WatchForumCollection List = new yaf_WatchForumCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchForum_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_WatchForum> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_WatchForum> pg = new Pager<yaf_WatchForum>("sp_tblyaf_WatchForum_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_WatchForum getFromReader(IDataReader rd)
                {
                    yaf_WatchForum Item = new yaf_WatchForum();
                    					if(rd.FieldExists("WatchForumID")){
					Item.WatchForumID = (Int32)(rd["WatchForumID"]);
					}
					if(rd.FieldExists("ForumID")){
					Item.ForumID = (Int32)(rd["ForumID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("Created")){
					Item.Created = (DateTime)(rd["Created"]);
					}
					if(rd.FieldExists("LastMail")){
					Item.LastMail = (DateTime)(rd["LastMail"]);
					}
                    return Item;                    
                }
                 #endregion
				
				#region Extend
				#endregion
            }
        #endregion
		       
        #endregion
	#region yaf_WatchTopic
        #region BO
		public class yaf_WatchTopic: BaseEntity
		{			
			#region Properties
			public  Int32 WatchTopicID{get;set;}
			public  Int32 TopicID{get;set;}
			public  Int32 UserID{get;set;}
			public  DateTime Created{get;set;}
			public  DateTime LastMail{get;set;}
			#endregion
			#region Contructor
			public yaf_WatchTopic()
			{ }
			#endregion
			#region Customs properties
			
			public yaf_Topic yaf_Topic{get;set;}
			public yaf_User yaf_User{get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return yaf_WatchTopicDal.getFromReader(rd);
			}
		}
        #endregion
		#region Collection			
			public class yaf_WatchTopicCollection : BaseEntityCollection<yaf_WatchTopic>
			{}			
		#endregion
        #region Dal
            public class yaf_WatchTopicDal
            {   
                #region Methods
                
                public static void DeleteById(Int32 WatchTopicID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WatchTopicID", WatchTopicID);
                    SqlHelper.ExecuteNonQuery(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchTopic_Delete_DeleteById_ductt", obj);
                }                
                
                public static yaf_WatchTopic Insert(yaf_WatchTopic Inserted)
                {
                    yaf_WatchTopic Item = new yaf_WatchTopic();
                    SqlParameter[] obj = new SqlParameter[4];
                    				obj[0] = new SqlParameter("TopicID", Inserted.TopicID);
				obj[1] = new SqlParameter("UserID", Inserted.UserID);
				obj[2] = new SqlParameter("Created", Inserted.Created);
				obj[3] = new SqlParameter("LastMail", Inserted.LastMail);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchTopic_Insert_InsertNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchTopic Update(yaf_WatchTopic Updated)
                {
                    yaf_WatchTopic Item = new yaf_WatchTopic();
                    SqlParameter[] obj = new SqlParameter[5];
                    				obj[0] = new SqlParameter("WatchTopicID", Updated.WatchTopicID);
				obj[1] = new SqlParameter("TopicID", Updated.TopicID);
				obj[2] = new SqlParameter("UserID", Updated.UserID);
				obj[3] = new SqlParameter("Created", Updated.Created);
				obj[4] = new SqlParameter("LastMail", Updated.LastMail);

                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchTopic_Update_UpdateNormal_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchTopic SelectById(Int32 WatchTopicID)
                {
                    yaf_WatchTopic Item = new yaf_WatchTopic();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("WatchTopicID", WatchTopicID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchTopic_Select_SelectById_ductt", obj))
                    {
                        while (rd.Read())
                        {
                            Item = getFromReader(rd);
                        }
                    }
                    return Item;
                }
                
                public static yaf_WatchTopicCollection SelectAll()
                {
                    yaf_WatchTopicCollection List = new yaf_WatchTopicCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.conforum(), CommandType.StoredProcedure, "sp_yaf_WatchTopic_Select_SelectAll_ductt"))
                    {
                        while (rd.Read())
                        {
                            List.Add(getFromReader(rd));
                        }
                    }
                    return List;
                }
				public static Pager<yaf_WatchTopic> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<yaf_WatchTopic> pg = new Pager<yaf_WatchTopic>("sp_tblyaf_WatchTopic_Pager_Normal_ductt", "page", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
				
                #region Utilities                
                public static yaf_WatchTopic getFromReader(IDataReader rd)
                {
                    yaf_WatchTopic Item = new yaf_WatchTopic();
                    					if(rd.FieldExists("WatchTopicID")){
					Item.WatchTopicID = (Int32)(rd["WatchTopicID"]);
					}
					if(rd.FieldExists("TopicID")){
					Item.TopicID = (Int32)(rd["TopicID"]);
					}
					if(rd.FieldExists("UserID")){
					Item.UserID = (Int32)(rd["UserID"]);
					}
					if(rd.FieldExists("Created")){
					Item.Created = (DateTime)(rd["Created"]);
					}
					if(rd.FieldExists("LastMail")){
					Item.LastMail = (DateTime)(rd["LastMail"]);
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

