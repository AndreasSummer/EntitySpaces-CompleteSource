
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : SQL
Date Generated       : 3/17/2012 4:39:36 AM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'CustomFieldsServer' table
	/// </summary>

	[Serializable]
	[DataContract]
	[KnownType(typeof(CustomFieldsServer))]	
	[XmlType("CustomFieldsServer")]
	[Table(Name="CustomFieldsServer")]
	public partial class CustomFieldsServer : esCustomFieldsServer
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new CustomFieldsServer();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 autoKey)
		{
			var obj = new CustomFieldsServer();
			obj.AutoKey = autoKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 autoKey, esSqlAccessType sqlAccessType)
		{
			var obj = new CustomFieldsServer();
			obj.AutoKey = autoKey;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		
					
		

		#region LINQtoSQL overrides (shame but we must do this)

			
		[Column(IsPrimaryKey = true, CanBeNull = false)]
		public override System.Int32? AutoKey
		{
			get { return base.AutoKey;  }
			set { base.AutoKey = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String FirstName
		{
			get { return base.FirstName;  }
			set { base.FirstName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.String LastName
		{
			get { return base.LastName;  }
			set { base.LastName = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? Age
		{
			get { return base.Age;  }
			set { base.Age = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateAdded
		{
			get { return base.DateAdded;  }
			set { base.DateAdded = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.DateTime? DateModified
		{
			get { return base.DateModified;  }
			set { base.DateModified = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String AddedBy
		{
			get { return base.AddedBy;  }
			set { base.AddedBy = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = true)]
		public override System.String ModifiedBy
		{
			get { return base.ModifiedBy;  }
			set { base.ModifiedBy = value; }
		}

			
		[Column(IsPrimaryKey = false, CanBeNull = false)]
		public override System.Int32? EsVersion
		{
			get { return base.EsVersion;  }
			set { base.EsVersion = value; }
		}


		#endregion
	
	}



	[Serializable]
	[CollectionDataContract]
	[XmlType("CustomFieldsServerCollection")]
	public partial class CustomFieldsServerCollection : esCustomFieldsServerCollection, IEnumerable<CustomFieldsServer>
	{
		public CustomFieldsServer FindByPrimaryKey(System.Int32 autoKey)
		{
			return this.SingleOrDefault(e => e.AutoKey == autoKey);
		}

		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(CustomFieldsServer))]
		public class CustomFieldsServerCollectionWCFPacket : esCollectionWCFPacket<CustomFieldsServerCollection>
		{
			public static implicit operator CustomFieldsServerCollection(CustomFieldsServerCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator CustomFieldsServerCollectionWCFPacket(CustomFieldsServerCollection collection)
			{
				return new CustomFieldsServerCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



	[Serializable]
	[DataContract(Name = "CustomFieldsServerQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class CustomFieldsServerQuery : esCustomFieldsServerQuery
	{
		public CustomFieldsServerQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "CustomFieldsServerQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(CustomFieldsServerQuery query)
		{
			return CustomFieldsServerQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator CustomFieldsServerQuery(string query)
		{
			return (CustomFieldsServerQuery)CustomFieldsServerQuery.SerializeHelper.FromXml(query, typeof(CustomFieldsServerQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esCustomFieldsServer : EntityBase
	{
		public esCustomFieldsServer()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 autoKey)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(autoKey);
			else
				return LoadByPrimaryKeyStoredProcedure(autoKey);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 autoKey)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(autoKey);
			else
				return LoadByPrimaryKeyStoredProcedure(autoKey);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 autoKey)
		{
			CustomFieldsServerQuery query = new CustomFieldsServerQuery();
			query.Where(query.AutoKey == autoKey);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 autoKey)
		{
			esParameters parms = new esParameters();
			parms.Add("AutoKey", autoKey);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to CustomFieldsServer.AutoKey
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? AutoKey
		{
			get
			{
				return base.GetSystemInt32(CustomFieldsServerMetadata.ColumnNames.AutoKey);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomFieldsServerMetadata.ColumnNames.AutoKey, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.AutoKey);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.FirstName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String FirstName
		{
			get
			{
				return base.GetSystemString(CustomFieldsServerMetadata.ColumnNames.FirstName);
			}
			
			set
			{
				if(base.SetSystemString(CustomFieldsServerMetadata.ColumnNames.FirstName, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.FirstName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.LastName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String LastName
		{
			get
			{
				return base.GetSystemString(CustomFieldsServerMetadata.ColumnNames.LastName);
			}
			
			set
			{
				if(base.SetSystemString(CustomFieldsServerMetadata.ColumnNames.LastName, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.LastName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.Age
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? Age
		{
			get
			{
				return base.GetSystemInt32(CustomFieldsServerMetadata.ColumnNames.Age);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomFieldsServerMetadata.ColumnNames.Age, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.Age);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.DateAdded
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateAdded
		{
			get
			{
				return base.GetSystemDateTime(CustomFieldsServerMetadata.ColumnNames.DateAdded);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomFieldsServerMetadata.ColumnNames.DateAdded, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.DateAdded);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.DateModified
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? DateModified
		{
			get
			{
				return base.GetSystemDateTime(CustomFieldsServerMetadata.ColumnNames.DateModified);
			}
			
			set
			{
				if(base.SetSystemDateTime(CustomFieldsServerMetadata.ColumnNames.DateModified, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.DateModified);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.AddedBy
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String AddedBy
		{
			get
			{
				return base.GetSystemString(CustomFieldsServerMetadata.ColumnNames.AddedBy);
			}
			
			set
			{
				if(base.SetSystemString(CustomFieldsServerMetadata.ColumnNames.AddedBy, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.AddedBy);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.ModifiedBy
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ModifiedBy
		{
			get
			{
				return base.GetSystemString(CustomFieldsServerMetadata.ColumnNames.ModifiedBy);
			}
			
			set
			{
				if(base.SetSystemString(CustomFieldsServerMetadata.ColumnNames.ModifiedBy, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.ModifiedBy);
				}
			}
		}		
		
		/// <summary>
		/// Maps to CustomFieldsServer.esVersion
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EsVersion
		{
			get
			{
				return base.GetSystemInt32(CustomFieldsServerMetadata.ColumnNames.EsVersion);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomFieldsServerMetadata.ColumnNames.EsVersion, value))
				{
					OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.EsVersion);
				}
			}
		}		
		
		#endregion	

		#region .str() Properties
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}
		
		public override void SetProperty(string name, object value)
		{
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "AutoKey": this.str().AutoKey = (string)value; break;							
						case "FirstName": this.str().FirstName = (string)value; break;							
						case "LastName": this.str().LastName = (string)value; break;							
						case "Age": this.str().Age = (string)value; break;							
						case "DateAdded": this.str().DateAdded = (string)value; break;							
						case "DateModified": this.str().DateModified = (string)value; break;							
						case "AddedBy": this.str().AddedBy = (string)value; break;							
						case "ModifiedBy": this.str().ModifiedBy = (string)value; break;							
						case "EsVersion": this.str().EsVersion = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "AutoKey":
						
							if (value == null || value is System.Int32)
								this.AutoKey = (System.Int32?)value;
								OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.AutoKey);
							break;
						
						case "Age":
						
							if (value == null || value is System.Int32)
								this.Age = (System.Int32?)value;
								OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.Age);
							break;
						
						case "DateAdded":
						
							if (value == null || value is System.DateTime)
								this.DateAdded = (System.DateTime?)value;
								OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.DateAdded);
							break;
						
						case "DateModified":
						
							if (value == null || value is System.DateTime)
								this.DateModified = (System.DateTime?)value;
								OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.DateModified);
							break;
						
						case "EsVersion":
						
							if (value == null || value is System.Int32)
								this.EsVersion = (System.Int32?)value;
								OnPropertyChanged(CustomFieldsServerMetadata.PropertyNames.EsVersion);
							break;
					

						default:
							break;
					}
				}
			}
            else if (this.ContainsColumn(name))
            {
                this.SetColumn(name, value);
            }
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}		

		public esStrings str()
		{
			if (esstrings == null)
			{
				esstrings = new esStrings(this);
			}
			return esstrings;
		}

		sealed public class esStrings
		{
			public esStrings(esCustomFieldsServer entity)
			{
				this.entity = entity;
			}
			
	
			public System.String AutoKey
			{
				get
				{
					System.Int32? data = entity.AutoKey;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AutoKey = null;
					else entity.AutoKey = Convert.ToInt32(value);
				}
			}
				
			public System.String FirstName
			{
				get
				{
					System.String data = entity.FirstName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FirstName = null;
					else entity.FirstName = Convert.ToString(value);
				}
			}
				
			public System.String LastName
			{
				get
				{
					System.String data = entity.LastName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.LastName = null;
					else entity.LastName = Convert.ToString(value);
				}
			}
				
			public System.String Age
			{
				get
				{
					System.Int32? data = entity.Age;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Age = null;
					else entity.Age = Convert.ToInt32(value);
				}
			}
				
			public System.String DateAdded
			{
				get
				{
					System.DateTime? data = entity.DateAdded;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateAdded = null;
					else entity.DateAdded = Convert.ToDateTime(value);
				}
			}
				
			public System.String DateModified
			{
				get
				{
					System.DateTime? data = entity.DateModified;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.DateModified = null;
					else entity.DateModified = Convert.ToDateTime(value);
				}
			}
				
			public System.String AddedBy
			{
				get
				{
					System.String data = entity.AddedBy;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.AddedBy = null;
					else entity.AddedBy = Convert.ToString(value);
				}
			}
				
			public System.String ModifiedBy
			{
				get
				{
					System.String data = entity.ModifiedBy;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ModifiedBy = null;
					else entity.ModifiedBy = Convert.ToString(value);
				}
			}
				
			public System.String EsVersion
			{
				get
				{
					System.Int32? data = entity.EsVersion;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.EsVersion = null;
					else entity.EsVersion = Convert.ToInt32(value);
				}
			}
			

			private esCustomFieldsServer entity;
		}
		
		[NonSerialized]
		private esStrings esstrings;		
		
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return CustomFieldsServerMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public CustomFieldsServerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomFieldsServerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomFieldsServerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(CustomFieldsServerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private CustomFieldsServerQuery query;		
	}



	[Serializable]
	abstract public partial class esCustomFieldsServerCollection : CollectionBase<CustomFieldsServer>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return CustomFieldsServerMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "CustomFieldsServerCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public CustomFieldsServerQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomFieldsServerQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(CustomFieldsServerQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomFieldsServerQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(CustomFieldsServerQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((CustomFieldsServerQuery)query);
		}

		#endregion
		
		private CustomFieldsServerQuery query;
	}



	[Serializable]
	abstract public partial class esCustomFieldsServerQuery : QueryBase
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomFieldsServerMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "AutoKey": return this.AutoKey;
				case "FirstName": return this.FirstName;
				case "LastName": return this.LastName;
				case "Age": return this.Age;
				case "DateAdded": return this.DateAdded;
				case "DateModified": return this.DateModified;
				case "AddedBy": return this.AddedBy;
				case "ModifiedBy": return this.ModifiedBy;
				case "EsVersion": return this.EsVersion;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem AutoKey
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.AutoKey, esSystemType.Int32); }
		} 
		
		public esQueryItem FirstName
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.FirstName, esSystemType.String); }
		} 
		
		public esQueryItem LastName
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.LastName, esSystemType.String); }
		} 
		
		public esQueryItem Age
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.Age, esSystemType.Int32); }
		} 
		
		public esQueryItem DateAdded
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.DateAdded, esSystemType.DateTime); }
		} 
		
		public esQueryItem DateModified
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.DateModified, esSystemType.DateTime); }
		} 
		
		public esQueryItem AddedBy
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.AddedBy, esSystemType.String); }
		} 
		
		public esQueryItem ModifiedBy
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.ModifiedBy, esSystemType.String); }
		} 
		
		public esQueryItem EsVersion
		{
			get { return new esQueryItem(this, CustomFieldsServerMetadata.ColumnNames.EsVersion, esSystemType.Int32); }
		} 
		
		#endregion
		
	}



	[Serializable]
	public partial class CustomFieldsServerMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomFieldsServerMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.AutoKey, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.AutoKey;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.FirstName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.FirstName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.LastName, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.LastName;
			c.CharacterMaxLength = 50;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.Age, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.Age;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((10))";
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.DateAdded, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.DateAdded;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.DateModified, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.DateModified;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.AddedBy, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.AddedBy;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.ModifiedBy, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.ModifiedBy;
			c.CharacterMaxLength = 50;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(CustomFieldsServerMetadata.ColumnNames.EsVersion, 8, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomFieldsServerMetadata.PropertyNames.EsVersion;
			c.NumericPrecision = 10;
			c.IsEntitySpacesConcurrency = true;
			m_columns.Add(c);
				
			m_columns.DateAdded = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateAdded.ColumnName = "DateAdded";
			m_columns.DateAdded.IsEnabled = true;
			m_columns.DateAdded.Type = DateType.ServerSide;

			m_columns.DateModified = new esColumnMetadataCollection.SpecialDate();
			m_columns.DateModified.ColumnName = "DateModified";
			m_columns.DateModified.IsEnabled = true;
			m_columns.DateModified.Type = DateType.ServerSide;

			m_columns.AddedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.AddedBy.ColumnName = "AddedBy";
			m_columns.AddedBy.IsEnabled = true;
			m_columns.AddedBy.UseEventHandler = false;

			m_columns.ModifiedBy = new esColumnMetadataCollection.AuditingInfo();
			m_columns.ModifiedBy.ColumnName = "ModifiedBy";
			m_columns.ModifiedBy.IsEnabled = true;
			m_columns.ModifiedBy.UseEventHandler = false;

		}
		#endregion	
	
		static public CustomFieldsServerMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return true; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string AutoKey = "AutoKey";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string DateAdded = "DateAdded";
			 public const string DateModified = "DateModified";
			 public const string AddedBy = "AddedBy";
			 public const string ModifiedBy = "ModifiedBy";
			 public const string EsVersion = "esVersion";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string AutoKey = "AutoKey";
			 public const string FirstName = "FirstName";
			 public const string LastName = "LastName";
			 public const string Age = "Age";
			 public const string DateAdded = "DateAdded";
			 public const string DateModified = "DateModified";
			 public const string AddedBy = "AddedBy";
			 public const string ModifiedBy = "ModifiedBy";
			 public const string EsVersion = "EsVersion";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(CustomFieldsServerMetadata))
			{
				if(CustomFieldsServerMetadata.mapDelegates == null)
				{
					CustomFieldsServerMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomFieldsServerMetadata.meta == null)
				{
					CustomFieldsServerMetadata.meta = new CustomFieldsServerMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();			


				meta["DateAdded.ServerSideText"] = "getutcdate()";

				meta["DateModified.ServerSideText"] = "getutcdate()";

				meta["AddedBy.ServerSideText"] = "dbo.GetCustomUser()";

				meta["ModifiedBy.ServerSideText"] = "dbo.GetCustomUser()";

				meta.AddTypeMap("AutoKey", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("FirstName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("LastName", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("Age", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("DateAdded", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("DateModified", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("AddedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("ModifiedBy", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("EsVersion", new esTypeMap("int", "System.Int32"));			
				meta.Catalog = "AggregateDb";
				meta.Schema = "dbo";
				
				meta.Source = "CustomFieldsServer";
				meta.Destination = "CustomFieldsServer";
				
				meta.spInsert = "proc_CustomFieldsServerInsert";				
				meta.spUpdate = "proc_CustomFieldsServerUpdate";		
				meta.spDelete = "proc_CustomFieldsServerDelete";
				meta.spLoadAll = "proc_CustomFieldsServerLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomFieldsServerLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomFieldsServerMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
