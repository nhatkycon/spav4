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
using docsoft.entities;
namespace spa.entitites
{
    #region SpaDatDichVu
        #region BO
		public class SpaDatDichVu: BaseEntity
		{			
			#region Properties
			public  Int64 ID{get;set;}
			public  Int32 P_ID{get;set;}
			public  Int32 SPA_ID{get;set;}
			public  Int32 KH_ID{get;set;}
			public  Int32 Loai{get;set;}
			public  String GhiChu{get;set;}
			public  Boolean Active{get;set;}
			public  Boolean Confirmed{get;set;}
			public  Boolean ThanhToan{get;set;}
			public  DateTime NgayTao{get;set;}
			public  DateTime NgayHen{get;set;}
			public  Boolean SpaReaded{get;set;}
			public  Boolean SpaConfirmed{get;set;}
			public  DateTime NgaySpaDoc{get;set;}
			public  DateTime NgayThanhToan{get;set;}
            public  String KH_Ten{get;set;}
            public  String KH_Mobile{get;set;}
            public  String KH_DiaChi{get;set;}
			#endregion
			#region Contructor
			public SpaDatDichVu()
			{ }			
			public SpaDatDichVu (IDataReader rd)
            {             
                					if(rd.FieldExists("DDV_ID")){
					ID = (Int64)(rd["DDV_ID"]);
					}
					if(rd.FieldExists("DDV_P_ID")){
					P_ID = (Int32)(rd["DDV_P_ID"]);
					}
					if(rd.FieldExists("DDV_SPA_ID")){
					SPA_ID = (Int32)(rd["DDV_SPA_ID"]);
					}
					if(rd.FieldExists("DDV_KH_ID")){
					KH_ID = (Int32)(rd["DDV_KH_ID"]);
					}
					if(rd.FieldExists("DDV_Loai")){
					Loai = (Int32)(rd["DDV_Loai"]);
					}
					if(rd.FieldExists("DDV_GhiChu")){
					GhiChu = (String)(rd["DDV_GhiChu"]);
					}
					if(rd.FieldExists("DDV_Active")){
					Active = (Boolean)(rd["DDV_Active"]);
					}
					if(rd.FieldExists("DDV_Confirmed")){
					Confirmed = (Boolean)(rd["DDV_Confirmed"]);
					}
					if(rd.FieldExists("DDV_ThanhToan")){
					ThanhToan = (Boolean)(rd["DDV_ThanhToan"]);
					}
					if(rd.FieldExists("DDV_NgayTao")){
					NgayTao = (DateTime)(rd["DDV_NgayTao"]);
					}
					if(rd.FieldExists("DDV_NgayHen")){
					NgayHen = (DateTime)(rd["DDV_NgayHen"]);
					}
					if(rd.FieldExists("DDV_SpaReaded")){
					SpaReaded = (Boolean)(rd["DDV_SpaReaded"]);
					}
					if(rd.FieldExists("DDV_SpaConfirmed")){
					SpaConfirmed = (Boolean)(rd["DDV_SpaConfirmed"]);
					}
					if(rd.FieldExists("DDV_NgaySpaDoc")){
					NgaySpaDoc = (DateTime)(rd["DDV_NgaySpaDoc"]);
					}
					if(rd.FieldExists("DDV_NgayThanhToan")){
					NgayThanhToan = (DateTime)(rd["DDV_NgayThanhToan"]);
					}
                    if(rd.FieldExists("DDV_KH_Ten")){
					KH_Ten = (String)(rd["DDV_KH_Ten"]);
					}
                    if(rd.FieldExists("DDV_KH_DiaChi")){
					KH_DiaChi = (String)(rd["DDV_KH_DiaChi"]);
					}
                    if(rd.FieldExists("DDV_KH_Mobile")){
					KH_Mobile = (String)(rd["DDV_KH_Mobile"]);
					}

            }
			#endregion
			#region Customs properties
			public Member _KhachHang {get;set;}
            public Spa _Spa {get; set;}
            public SpaDichVu _SpaDichVu {get;set;}
            public SpaKhuyenMai _SpaKhuyenMai {get;set;}
			#endregion		
			public override BaseEntity getFromReader(IDataReader rd)
			{
				return new SpaDatDichVu(rd);
			}
			public string format(int Loai)
			{
				StringBuilder sb = new StringBuilder();
				switch (Loai)
				{
					case 0:
						#region 0 : 
						break;
						#endregion
					case 1:
						#region 1 : 
						break;
						#endregion
					case 2:
						#region 2 : 
						break;
						#endregion
					case 3:
						#region 3 : 
						break;
						#endregion
					default:
						#region mac dinh
						break;
						#endregion
				}
				return sb.ToString();
			}
		}
        #endregion
		#region Collection			
			public class SpaDatDichVuCollection : BaseEntityCollection<SpaDatDichVu>
			{}			
		#endregion
        #region Dal
            public class SpaDatDichVuDal
            {   
                #region Methods
                
                public static void DeleteById(Int64 DDV_ID)
                {
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("DDV_ID", DDV_ID);
                    SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Delete_DeleteById_linhnx", obj);
                }                
                public static SpaDatDichVu Insert(SpaDatDichVu Inserted)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[17];
                    						obj[0] = new SqlParameter("DDV_P_ID", Inserted.P_ID);
						obj[1] = new SqlParameter("DDV_SPA_ID", Inserted.SPA_ID);
						obj[2] = new SqlParameter("DDV_KH_ID", Inserted.KH_ID);
						obj[3] = new SqlParameter("DDV_Loai", Inserted.Loai);
						obj[4] = new SqlParameter("DDV_GhiChu", Inserted.GhiChu);
						obj[5] = new SqlParameter("DDV_Active", Inserted.Active);
						obj[6] = new SqlParameter("DDV_Confirmed", Inserted.Confirmed);
						obj[7] = new SqlParameter("DDV_ThanhToan", Inserted.ThanhToan);
					if(Inserted.NgayTao > DateTime.MinValue)
					{
				obj[8] = new SqlParameter("DDV_NgayTao", Inserted.NgayTao);
					}
					else{
						obj[8] = new SqlParameter("DDV_NgayTao", DBNull.Value);
					}
					if(Inserted.NgayHen > DateTime.MinValue)
					{
				obj[9] = new SqlParameter("DDV_NgayHen", Inserted.NgayHen);
					}
					else{
						obj[9] = new SqlParameter("DDV_NgayHen", DBNull.Value);
					}
						obj[10] = new SqlParameter("DDV_SpaReaded", Inserted.SpaReaded);
						obj[11] = new SqlParameter("DDV_SpaConfirmed", Inserted.SpaConfirmed);
					if(Inserted.NgaySpaDoc > DateTime.MinValue)
					{
				obj[12] = new SqlParameter("DDV_NgaySpaDoc", Inserted.NgaySpaDoc);
					}
					else{
						obj[12] = new SqlParameter("DDV_NgaySpaDoc", DBNull.Value);
					}
					if(Inserted.NgayThanhToan > DateTime.MinValue)
					{
				obj[13] = new SqlParameter("DDV_NgayThanhToan", Inserted.NgayThanhToan);
					}
					else{
						obj[13] = new SqlParameter("DDV_NgayThanhToan", DBNull.Value);
					}
                    obj[14] = new SqlParameter("DDV_KH_Ten", Inserted.KH_Ten);
                    obj[15] = new SqlParameter("DDV_KH_DiaChi", Inserted.KH_DiaChi);
                    obj[16] = new SqlParameter("DDV_KH_Mobile", Inserted.KH_Mobile);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
                public static SpaDatDichVu Insert(SpaDatDichVu Inserted, SqlConnection con)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[14];
                    						obj[0] = new SqlParameter("DDV_P_ID", Inserted.P_ID);
						obj[1] = new SqlParameter("DDV_SPA_ID", Inserted.SPA_ID);
						obj[2] = new SqlParameter("DDV_KH_ID", Inserted.KH_ID);
						obj[3] = new SqlParameter("DDV_Loai", Inserted.Loai);
						obj[4] = new SqlParameter("DDV_GhiChu", Inserted.GhiChu);
						obj[5] = new SqlParameter("DDV_Active", Inserted.Active);
						obj[6] = new SqlParameter("DDV_Confirmed", Inserted.Confirmed);
						obj[7] = new SqlParameter("DDV_ThanhToan", Inserted.ThanhToan);
					if(Inserted.NgayTao > DateTime.MinValue)
					{
				obj[8] = new SqlParameter("DDV_NgayTao", Inserted.NgayTao);
					}
					else{
						obj[8] = new SqlParameter("DDV_NgayTao", DBNull.Value);
					}
					if(Inserted.NgayHen > DateTime.MinValue)
					{
				obj[9] = new SqlParameter("DDV_NgayHen", Inserted.NgayHen);
					}
					else{
						obj[9] = new SqlParameter("DDV_NgayHen", DBNull.Value);
					}
						obj[10] = new SqlParameter("DDV_SpaReaded", Inserted.SpaReaded);
						obj[11] = new SqlParameter("DDV_SpaConfirmed", Inserted.SpaConfirmed);
					if(Inserted.NgaySpaDoc > DateTime.MinValue)
					{
				obj[12] = new SqlParameter("DDV_NgaySpaDoc", Inserted.NgaySpaDoc);
					}
					else{
						obj[12] = new SqlParameter("DDV_NgaySpaDoc", DBNull.Value);
					}
					if(Inserted.NgayThanhToan > DateTime.MinValue)
					{
				obj[13] = new SqlParameter("DDV_NgayThanhToan", Inserted.NgayThanhToan);
					}
					else{
						obj[13] = new SqlParameter("DDV_NgayThanhToan", DBNull.Value);
					}
                    obj[14] = new SqlParameter("DDV_KH_Ten", Inserted.KH_Ten);
                    obj[15] = new SqlParameter("DDV_KH_DiaChi", Inserted.KH_DiaChi);
                    obj[16] = new SqlParameter("DDV_KH_Mobile", Inserted.KH_Mobile);
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Insert_InsertNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
                public static SpaDatDichVu Update(SpaDatDichVu Updated)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[18];
                    				obj[0] = new SqlParameter("DDV_ID", Updated.ID);
				obj[1] = new SqlParameter("DDV_P_ID", Updated.P_ID);
				obj[2] = new SqlParameter("DDV_SPA_ID", Updated.SPA_ID);
				obj[3] = new SqlParameter("DDV_KH_ID", Updated.KH_ID);
				obj[4] = new SqlParameter("DDV_Loai", Updated.Loai);
				obj[5] = new SqlParameter("DDV_GhiChu", Updated.GhiChu);
				obj[6] = new SqlParameter("DDV_Active", Updated.Active);
				obj[7] = new SqlParameter("DDV_Confirmed", Updated.Confirmed);
				obj[8] = new SqlParameter("DDV_ThanhToan", Updated.ThanhToan);
					if(Updated.NgayTao > DateTime.MinValue)
					{
				obj[9] = new SqlParameter("DDV_NgayTao", Updated.NgayTao);
					}
					else{
						obj[9] = new SqlParameter("DDV_NgayTao", DBNull.Value);
					}
					if(Updated.NgayHen > DateTime.MinValue)
					{
				obj[10] = new SqlParameter("DDV_NgayHen", Updated.NgayHen);
					}
					else{
						obj[10] = new SqlParameter("DDV_NgayHen", DBNull.Value);
					}
				obj[11] = new SqlParameter("DDV_SpaReaded", Updated.SpaReaded);
				obj[12] = new SqlParameter("DDV_SpaConfirmed", Updated.SpaConfirmed);
					if(Updated.NgaySpaDoc > DateTime.MinValue)
					{
				obj[13] = new SqlParameter("DDV_NgaySpaDoc", Updated.NgaySpaDoc);
					}
					else{
						obj[13] = new SqlParameter("DDV_NgaySpaDoc", DBNull.Value);
					}
					if(Updated.NgayThanhToan > DateTime.MinValue)
					{
				obj[14] = new SqlParameter("DDV_NgayThanhToan", Updated.NgayThanhToan);
					}
					else{
						obj[14] = new SqlParameter("DDV_NgayThanhToan", DBNull.Value);
					}
                    obj[15] = new SqlParameter("DDV_KH_Ten", Updated.KH_Ten);
                    obj[16] = new SqlParameter("DDV_KH_DiaChi", Updated.KH_DiaChi);
                    obj[17] = new SqlParameter("DDV_KH_Mobile", Updated.KH_Mobile);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
                public static SpaDatDichVu Update(SpaDatDichVu Updated, SqlConnection con)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[18];
                    				obj[0] = new SqlParameter("DDV_ID", Updated.ID);
				obj[1] = new SqlParameter("DDV_P_ID", Updated.P_ID);
				obj[2] = new SqlParameter("DDV_SPA_ID", Updated.SPA_ID);
				obj[3] = new SqlParameter("DDV_KH_ID", Updated.KH_ID);
				obj[4] = new SqlParameter("DDV_Loai", Updated.Loai);
				obj[5] = new SqlParameter("DDV_GhiChu", Updated.GhiChu);
				obj[6] = new SqlParameter("DDV_Active", Updated.Active);
				obj[7] = new SqlParameter("DDV_Confirmed", Updated.Confirmed);
				obj[8] = new SqlParameter("DDV_ThanhToan", Updated.ThanhToan);
					if(Updated.NgayTao > DateTime.MinValue)
					{
				obj[9] = new SqlParameter("DDV_NgayTao", Updated.NgayTao);
					}
					else{
						obj[9] = new SqlParameter("DDV_NgayTao", DBNull.Value);
					}
					if(Updated.NgayHen > DateTime.MinValue)
					{
				obj[10] = new SqlParameter("DDV_NgayHen", Updated.NgayHen);
					}
					else{
						obj[10] = new SqlParameter("DDV_NgayHen", DBNull.Value);
					}
				obj[11] = new SqlParameter("DDV_SpaReaded", Updated.SpaReaded);
				obj[12] = new SqlParameter("DDV_SpaConfirmed", Updated.SpaConfirmed);
					if(Updated.NgaySpaDoc > DateTime.MinValue)
					{
				obj[13] = new SqlParameter("DDV_NgaySpaDoc", Updated.NgaySpaDoc);
					}
					else{
						obj[13] = new SqlParameter("DDV_NgaySpaDoc", DBNull.Value);
					}
					if(Updated.NgayThanhToan > DateTime.MinValue)
					{
				obj[14] = new SqlParameter("DDV_NgayThanhToan", Updated.NgayThanhToan);
					}
					else{
						obj[14] = new SqlParameter("DDV_NgayThanhToan", DBNull.Value);
					}
                     obj[15] = new SqlParameter("DDV_KH_Ten", Updated.KH_Ten);
                    obj[16] = new SqlParameter("DDV_KH_DiaChi", Updated.KH_DiaChi);
                    obj[17] = new SqlParameter("DDV_KH_Mobile", Updated.KH_Mobile);
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Update_UpdateNormal_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
                public static SpaDatDichVu SelectById(Int64 DDV_ID)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("DDV_ID", DDV_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Select_SelectById_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
				public static SpaDatDichVu SelectById(Int64 DDV_ID, SqlConnection con)
                {
                    SpaDatDichVu Item = new SpaDatDichVu();
                    SqlParameter[] obj = new SqlParameter[1];
                    obj[0] = new SqlParameter("DDV_ID", DDV_ID);
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Select_SelectById_linhnx", obj))
                    {
                        while (rd.Read())
                        {
                            Item = new SpaDatDichVu(rd);
                        }
                    }
                    return Item;
                }
                public static SpaDatDichVuCollection SelectAll()
                {
                    SpaDatDichVuCollection List = new SpaDatDichVuCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(new SpaDatDichVu(rd));
                        }
                    }
                    return List;
                }
				public static SpaDatDichVuCollection SelectAll(SqlConnection con)
                {
                    SpaDatDichVuCollection List = new SpaDatDichVuCollection();
                    using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaDatDichVu_Select_SelectAll_linhnx"))
                    {
                        while (rd.Read())
                        {
                            List.Add(new SpaDatDichVu(rd));
                        }
                    }
                    return List;
                }
				public static Pager<SpaDatDichVu> pagerNormal(string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<SpaDatDichVu> pg = new Pager<SpaDatDichVu>("sp_tblSpaDatDichVu_Pager_Normal_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
				public static Pager<SpaDatDichVu> pagerNormal(SqlConnection con, string url,bool rewrite,string sort)
				{
					SqlParameter[] obj = new SqlParameter[1];
            		obj[0] = new SqlParameter("Sort", sort);
					Pager<SpaDatDichVu> pg = new Pager<SpaDatDichVu>(con, "sp_tblSpaDatDichVu_Pager_Normal_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
                #endregion         
                #region Utilities                                
                 #endregion
				#region Extend
                public static Pager<SpaDatDichVu> pagerAll(SqlConnection con, string url, bool rewrite, string sort, string P_ID
                    , string SPA_ID, string KH_ID, string Loai, string Active, string Confirmed
                    , string ThanhToan, string SpaReaded, string SpaConfirmed, string NgayTao, string NgayHen)
				{
					SqlParameter[] obj = new SqlParameter[13];
                    if(string.IsNullOrEmpty(sort)){                        
            		    obj[0] = new SqlParameter("Sort", DBNull.Value);
                    }
                    else{
            		    obj[0] = new SqlParameter("Sort", sort);
                    }
                    if(string.IsNullOrEmpty(P_ID)){                        
            		    obj[1] = new SqlParameter("P_ID", DBNull.Value);
                    }
                    else{
            		    obj[1] = new SqlParameter("P_ID", P_ID);
                    }
                    if(string.IsNullOrEmpty(SPA_ID)){                        
            		    obj[2] = new SqlParameter("SPA_ID", DBNull.Value);
                    }
                    else{
            		    obj[2] = new SqlParameter("SPA_ID", SPA_ID);
                    }
                    if(string.IsNullOrEmpty(KH_ID)){                        
            		    obj[3] = new SqlParameter("KH_ID", DBNull.Value);
                    }
                    else{
            		    obj[3] = new SqlParameter("KH_ID", KH_ID);
                    }
                    if(string.IsNullOrEmpty(Loai)){                        
            		    obj[4] = new SqlParameter("Loai", DBNull.Value);
                    }
                    else{
            		    obj[4] = new SqlParameter("Loai", Loai);
                    }
                    if(string.IsNullOrEmpty(Active)){                        
            		    obj[5] = new SqlParameter("Active", DBNull.Value);
                    }
                    else{
            		    obj[5] = new SqlParameter("Active", Active);
                    }
                    if(string.IsNullOrEmpty(Confirmed)){                        
            		    obj[6] = new SqlParameter("Confirmed", DBNull.Value);
                    }
                    else{
            		    obj[6] = new SqlParameter("Confirmed", Confirmed);
                    }
                    if(string.IsNullOrEmpty(ThanhToan)){                        
            		    obj[7] = new SqlParameter("ThanhToan", DBNull.Value);
                    }
                    else{
            		    obj[7] = new SqlParameter("ThanhToan", ThanhToan);
                    }
                    if(string.IsNullOrEmpty(SpaReaded)){                        
            		    obj[8] = new SqlParameter("SpaReaded", DBNull.Value);
                    }
                    else{
            		    obj[8] = new SqlParameter("SpaReaded", SpaReaded);
                    }
                    if(string.IsNullOrEmpty(SpaConfirmed)){                        
            		    obj[9] = new SqlParameter("SpaConfirmed", DBNull.Value);
                    }
                    else{
            		    obj[9] = new SqlParameter("SpaConfirmed", SpaConfirmed);
                    }
                    if(string.IsNullOrEmpty(NgayTao)){                        
            		    obj[10] = new SqlParameter("NgayTao", DBNull.Value);
                    }
                    else{
            		    obj[10] = new SqlParameter("NgayTao", NgayTao);
                    }
                    if(string.IsNullOrEmpty(NgayHen)){                        
            		    obj[11] = new SqlParameter("NgayHen", DBNull.Value);
                    }
                    else{
            		    obj[11] = new SqlParameter("NgayHen", NgayHen);
                    }
					Pager<SpaDatDichVu> pg = new Pager<SpaDatDichVu>(con, "sp_tblSpaDatDichVu_Pager_All_linhnx", "q", 20, 10, rewrite, url,obj);
					return pg;
				}
				#endregion
            }
        #endregion
        #endregion
}
