
/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0930.0
EntitySpaces Driver  : SQL
Date Generated       : 9/23/2012 6:16:29 PM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;



namespace BusinessObjects
{
	/// <summary>
	/// Encapsulates the 'Orders' table
	/// </summary>

    [DebuggerDisplay("Data = {Debug}")]
	[Serializable]
	[DataContract]
	[KnownType(typeof(Orders))]	
	[XmlType("Orders")]
	public partial class Orders : esOrders
	{	
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden | DebuggerBrowsableState.Never)]
		protected override esEntityDebuggerView[] Debug
		{
			get { return base.Debug; }
		}

		override public esEntity CreateInstance()
		{
			return new Orders();
		}
		
		#region Static Quick Access Methods
		static public void Delete(System.Int32 orderID)
		{
			var obj = new Orders();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save();
		}

	    static public void Delete(System.Int32 orderID, esSqlAccessType sqlAccessType)
		{
			var obj = new Orders();
			obj.OrderID = orderID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
			obj.Save(sqlAccessType);
		}
		#endregion

		#region Implicit Casts

		public static implicit operator OrdersProxyStub(Orders entity)
		{
			return new OrdersProxyStub(entity);
		}

		#endregion
		
					
		
	
	}



    [DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[CollectionDataContract]
	[XmlType("OrdersCollection")]
	public partial class OrdersCollection : esOrdersCollection, IEnumerable<Orders>
	{
		public Orders FindByPrimaryKey(System.Int32 orderID)
		{
			return this.SingleOrDefault(e => e.OrderID == orderID);
		}

		#region Implicit Casts
		
		public static implicit operator OrdersCollectionProxyStub(OrdersCollection coll)
		{
			return new OrdersCollectionProxyStub(coll);
		}
		
		#endregion
		
		
		#region WCF Service Class
		
		[DataContract]
		[KnownType(typeof(Orders))]
		public class OrdersCollectionWCFPacket : esCollectionWCFPacket<OrdersCollection>
		{
			public static implicit operator OrdersCollection(OrdersCollectionWCFPacket packet)
			{
				return packet.Collection;
			}

			public static implicit operator OrdersCollectionWCFPacket(OrdersCollection collection)
			{
				return new OrdersCollectionWCFPacket() { Collection = collection };
			}
		}
		
		#endregion
		
				
	}



    [DebuggerDisplay("Query = {Parse()}")]
	[Serializable]
	[DataContract(Name = "OrdersQuery", Namespace = "http://www.entityspaces.net")]	
	public partial class OrdersQuery : esOrdersQuery
	{
		public OrdersQuery(string joinAlias)
		{
			this.es.JoinAlias = joinAlias;
		}	

		override protected string GetQueryName()
		{
			return "OrdersQuery";
		}
		
					
	
		#region Explicit Casts
		
		public static explicit operator string(OrdersQuery query)
		{
			return OrdersQuery.SerializeHelper.ToXml(query);
		}

		public static explicit operator OrdersQuery(string query)
		{
			return (OrdersQuery)OrdersQuery.SerializeHelper.FromXml(query, typeof(OrdersQuery));
		}
		
		#endregion		
	}

	[DataContract]
	[Serializable]
	abstract public partial class esOrders : esEntity
	{
		public esOrders()
		{

		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 orderID)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 orderID)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(orderID);
			else
				return LoadByPrimaryKeyStoredProcedure(orderID);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 orderID)
		{
			OrdersQuery query = new OrdersQuery();
			query.Where(query.OrderID == orderID);
			return this.Load(query);
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 orderID)
		{
			esParameters parms = new esParameters();
			parms.Add("OrderID", orderID);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		#region Properties
		
		
		
		/// <summary>
		/// Maps to Orders.OrderID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? OrderID
		{
			get
			{
				return base.GetSystemInt32(OrdersMetadata.ColumnNames.OrderID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrdersMetadata.ColumnNames.OrderID, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.OrderID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.CustomerID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String CustomerID
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.CustomerID);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.CustomerID, value))
				{
					this._UpToCustomersByCustomerID = null;
					this.OnPropertyChanged("UpToCustomersByCustomerID");
					OnPropertyChanged(OrdersMetadata.PropertyNames.CustomerID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.EmployeeID
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? EmployeeID
		{
			get
			{
				return base.GetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID);
			}
			
			set
			{
				if(base.SetSystemInt32(OrdersMetadata.ColumnNames.EmployeeID, value))
				{
					this._UpToEmployeesByEmployeeID = null;
					this.OnPropertyChanged("UpToEmployeesByEmployeeID");
					OnPropertyChanged(OrdersMetadata.PropertyNames.EmployeeID);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.OrderDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? OrderDate
		{
			get
			{
				return base.GetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(OrdersMetadata.ColumnNames.OrderDate, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.OrderDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.RequiredDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? RequiredDate
		{
			get
			{
				return base.GetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(OrdersMetadata.ColumnNames.RequiredDate, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.RequiredDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShippedDate
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.DateTime? ShippedDate
		{
			get
			{
				return base.GetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate);
			}
			
			set
			{
				if(base.SetSystemDateTime(OrdersMetadata.ColumnNames.ShippedDate, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShippedDate);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipVia
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Int32? ShipVia
		{
			get
			{
				return base.GetSystemInt32(OrdersMetadata.ColumnNames.ShipVia);
			}
			
			set
			{
				if(base.SetSystemInt32(OrdersMetadata.ColumnNames.ShipVia, value))
				{
					this._UpToShippersByShipVia = null;
					this.OnPropertyChanged("UpToShippersByShipVia");
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipVia);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.Freight
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.Decimal? Freight
		{
			get
			{
				return base.GetSystemDecimal(OrdersMetadata.ColumnNames.Freight);
			}
			
			set
			{
				if(base.SetSystemDecimal(OrdersMetadata.ColumnNames.Freight, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.Freight);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipName
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipName
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipName);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipName, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipName);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipAddress
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipAddress
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipAddress);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipAddress, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipAddress);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipCity
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipCity
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipCity);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipCity, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCity);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipRegion
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipRegion
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipRegion);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipRegion, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipRegion);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipPostalCode
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipPostalCode
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipPostalCode, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipPostalCode);
				}
			}
		}		
		
		/// <summary>
		/// Maps to Orders.ShipCountry
		/// </summary>
		[DataMember(EmitDefaultValue=false)]
		virtual public System.String ShipCountry
		{
			get
			{
				return base.GetSystemString(OrdersMetadata.ColumnNames.ShipCountry);
			}
			
			set
			{
				if(base.SetSystemString(OrdersMetadata.ColumnNames.ShipCountry, value))
				{
					OnPropertyChanged(OrdersMetadata.PropertyNames.ShipCountry);
				}
			}
		}		
		
		[CLSCompliant(false)]
		internal protected Customers _UpToCustomersByCustomerID;
		[CLSCompliant(false)]
		internal protected Employees _UpToEmployeesByEmployeeID;
		[CLSCompliant(false)]
		internal protected Shippers _UpToShippersByShipVia;
		#endregion
		
		#region Housekeeping methods

		override protected IMetadata Meta
		{
			get
			{
				return OrdersMetadata.Meta();
			}
		}

		#endregion		
		
		#region Query Logic

		public OrdersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrdersQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrdersQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return this.Query.Load();
		}
		
		protected void InitQuery(OrdersQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntity)this).Connection;
			}			
		}

		#endregion
		
        [IgnoreDataMember]
		private OrdersQuery query;		
	}



	[Serializable]
	abstract public partial class esOrdersCollection : esEntityCollection<Orders>
	{
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return OrdersMetadata.Meta();
			}
		}

		protected override string GetCollectionName()
		{
			return "OrdersCollection";
		}

		#endregion		
		
		#region Query Logic

	#if (!WindowsCE)
		[BrowsableAttribute(false)]
	#endif
		public OrdersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new OrdersQuery();
					InitQuery(this.query);
				}

				return this.query;
			}
		}

		public bool Load(OrdersQuery query)
		{
			this.query = query;
			InitQuery(this.query);
			return Query.Load();
		}

		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new OrdersQuery();
				this.InitQuery(query);
			}
			return this.query;
		}

		protected void InitQuery(OrdersQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			
			if (!query.es2.HasConnection)
			{
				query.es2.Connection = ((IEntityCollection)this).Connection;
			}			
		}

		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery((OrdersQuery)query);
		}

		#endregion
		
		private OrdersQuery query;
	}



	[Serializable]
	abstract public partial class esOrdersQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return OrdersMetadata.Meta();
			}
		}	
		
		#region QueryItemFromName
		
        protected override esQueryItem QueryItemFromName(string name)
        {
            switch (name)
            {
				case "OrderID": return this.OrderID;
				case "CustomerID": return this.CustomerID;
				case "EmployeeID": return this.EmployeeID;
				case "OrderDate": return this.OrderDate;
				case "RequiredDate": return this.RequiredDate;
				case "ShippedDate": return this.ShippedDate;
				case "ShipVia": return this.ShipVia;
				case "Freight": return this.Freight;
				case "ShipName": return this.ShipName;
				case "ShipAddress": return this.ShipAddress;
				case "ShipCity": return this.ShipCity;
				case "ShipRegion": return this.ShipRegion;
				case "ShipPostalCode": return this.ShipPostalCode;
				case "ShipCountry": return this.ShipCountry;

                default: return null;
            }
        }		
		
		#endregion
		
		#region esQueryItems

		public esQueryItem OrderID
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.OrderID, esSystemType.Int32); }
		} 
		
		public esQueryItem CustomerID
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.CustomerID, esSystemType.String); }
		} 
		
		public esQueryItem EmployeeID
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.EmployeeID, esSystemType.Int32); }
		} 
		
		public esQueryItem OrderDate
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.OrderDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem RequiredDate
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.RequiredDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem ShippedDate
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShippedDate, esSystemType.DateTime); }
		} 
		
		public esQueryItem ShipVia
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipVia, esSystemType.Int32); }
		} 
		
		public esQueryItem Freight
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.Freight, esSystemType.Decimal); }
		} 
		
		public esQueryItem ShipName
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipName, esSystemType.String); }
		} 
		
		public esQueryItem ShipAddress
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipAddress, esSystemType.String); }
		} 
		
		public esQueryItem ShipCity
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipCity, esSystemType.String); }
		} 
		
		public esQueryItem ShipRegion
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipRegion, esSystemType.String); }
		} 
		
		public esQueryItem ShipPostalCode
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipPostalCode, esSystemType.String); }
		} 
		
		public esQueryItem ShipCountry
		{
			get { return new esQueryItem(this, OrdersMetadata.ColumnNames.ShipCountry, esSystemType.String); }
		} 
		
		#endregion
		
	}


	
	public partial class Orders : esOrders
	{

		#region UpToProductsCollection - Many To Many
		/// <summary>
		/// Many to Many
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>

		[XmlIgnore]
		public ProductsCollection UpToProductsCollection
		{
			get
			{
				if(this._UpToProductsCollection == null)
				{
					this._UpToProductsCollection = new ProductsCollection();
					this._UpToProductsCollection.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("UpToProductsCollection", this._UpToProductsCollection);
					if (!this.es.IsLazyLoadDisabled && this.OrderID != null)
					{
						ProductsQuery m = new ProductsQuery("m");
						OrderDetailsQuery j = new OrderDetailsQuery("j");
						m.Select(m);
						m.InnerJoin(j).On(m.ProductID == j.ProductID);
                        m.Where(j.OrderID == this.OrderID);

						this._UpToProductsCollection.Load(m);
					}
				}

				return this._UpToProductsCollection;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._UpToProductsCollection != null) 
				{ 
					this.RemovePostSave("UpToProductsCollection"); 
					this._UpToProductsCollection = null;
					this.OnPropertyChanged("UpToProductsCollection");
				} 
			}  			
		}

		/// <summary>
		/// Many to Many Associate
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		public void AssociateProductsCollection(Products entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.OrderID = this.OrderID;
			obj.ProductID = entity.ProductID;
		}

		/// <summary>
		/// Many to Many Dissociate
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>
		public void DissociateProductsCollection(Products entity)
		{
			if (this._OrderDetailsCollection == null)
			{
				this._OrderDetailsCollection = new OrderDetailsCollection();
				this._OrderDetailsCollection.es.Connection.Name = this.es.Connection.Name;
				this.SetPostSave("OrderDetailsCollection", this._OrderDetailsCollection);
			}

			OrderDetails obj = this._OrderDetailsCollection.AddNew();
			obj.OrderID = this.OrderID;
            obj.ProductID = entity.ProductID;
			obj.AcceptChanges();
			obj.MarkAsDeleted();
		}

		private ProductsCollection _UpToProductsCollection;
		private OrderDetailsCollection _OrderDetailsCollection;
		#endregion

		#region OrderDetailsCollectionByOrderID - Zero To Many
		
		static public esPrefetchMap Prefetch_OrderDetailsCollectionByOrderID
		{
			get
			{
				esPrefetchMap map = new esPrefetchMap();
				map.PrefetchDelegate = BusinessObjects.Orders.OrderDetailsCollectionByOrderID_Delegate;
				map.PropertyName = "OrderDetailsCollectionByOrderID";
				map.MyColumnName = "OrderID";
				map.ParentColumnName = "OrderID";
				map.IsMultiPartKey = false;
				return map;
			}
		}		
		
		static private void OrderDetailsCollectionByOrderID_Delegate(esPrefetchParameters data)
		{
			OrdersQuery parent = new OrdersQuery(data.NextAlias());

			OrderDetailsQuery me = data.You != null ? data.You as OrderDetailsQuery : new OrderDetailsQuery(data.NextAlias());

			if (data.Root == null)
			{
				data.Root = me;
			}
			
			data.Root.InnerJoin(parent).On(parent.OrderID == me.OrderID);

			data.You = parent;
		}			
		
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Order_Details_Orders
		/// </summary>

		[XmlIgnore]
		public OrderDetailsCollection OrderDetailsCollectionByOrderID
		{
			get
			{
				if(this._OrderDetailsCollectionByOrderID == null)
				{
					this._OrderDetailsCollectionByOrderID = new OrderDetailsCollection();
					this._OrderDetailsCollectionByOrderID.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("OrderDetailsCollectionByOrderID", this._OrderDetailsCollectionByOrderID);
				
					if (this.OrderID != null)
					{
						if (!this.es.IsLazyLoadDisabled)
						{
							this._OrderDetailsCollectionByOrderID.Query.Where(this._OrderDetailsCollectionByOrderID.Query.OrderID == this.OrderID);
							this._OrderDetailsCollectionByOrderID.Query.Load();
						}

						// Auto-hookup Foreign Keys
						this._OrderDetailsCollectionByOrderID.fks.Add(OrderDetailsMetadata.ColumnNames.OrderID, this.OrderID);
					}
				}

				return this._OrderDetailsCollectionByOrderID;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._OrderDetailsCollectionByOrderID != null) 
				{ 
					this.RemovePostSave("OrderDetailsCollectionByOrderID"); 
					this._OrderDetailsCollectionByOrderID = null;
					this.OnPropertyChanged("OrderDetailsCollectionByOrderID");
				} 
			} 			
		}
			
		
		private OrderDetailsCollection _OrderDetailsCollectionByOrderID;
		#endregion

				
		#region UpToCustomersByCustomerID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Customers
		/// </summary>

		[XmlIgnore]
					
		public Customers UpToCustomersByCustomerID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToCustomersByCustomerID == null && CustomerID != null)
				{
					this._UpToCustomersByCustomerID = new Customers();
					this._UpToCustomersByCustomerID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomersByCustomerID", this._UpToCustomersByCustomerID);
					this._UpToCustomersByCustomerID.Query.Where(this._UpToCustomersByCustomerID.Query.CustomerID == this.CustomerID);
					this._UpToCustomersByCustomerID.Query.Load();
				}	
				return this._UpToCustomersByCustomerID;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomersByCustomerID");
				
				bool changed = this._UpToCustomersByCustomerID != value;

				if(value == null)
				{
					this.CustomerID = null;
					this._UpToCustomersByCustomerID = null;
				}
				else
				{
					this.CustomerID = value.CustomerID;
					this._UpToCustomersByCustomerID = value;
					this.SetPreSave("UpToCustomersByCustomerID", this._UpToCustomersByCustomerID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToCustomersByCustomerID");
				}
			}
		}
		#endregion
		

				
		#region UpToEmployeesByEmployeeID - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Employees
		/// </summary>

		[XmlIgnore]
					
		public Employees UpToEmployeesByEmployeeID
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToEmployeesByEmployeeID == null && EmployeeID != null)
				{
					this._UpToEmployeesByEmployeeID = new Employees();
					this._UpToEmployeesByEmployeeID.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToEmployeesByEmployeeID", this._UpToEmployeesByEmployeeID);
					this._UpToEmployeesByEmployeeID.Query.Where(this._UpToEmployeesByEmployeeID.Query.EmployeeID == this.EmployeeID);
					this._UpToEmployeesByEmployeeID.Query.Load();
				}	
				return this._UpToEmployeesByEmployeeID;
			}
			
			set
			{
				this.RemovePreSave("UpToEmployeesByEmployeeID");
				
				bool changed = this._UpToEmployeesByEmployeeID != value;

				if(value == null)
				{
					this.EmployeeID = null;
					this._UpToEmployeesByEmployeeID = null;
				}
				else
				{
					this.EmployeeID = value.EmployeeID;
					this._UpToEmployeesByEmployeeID = value;
					this.SetPreSave("UpToEmployeesByEmployeeID", this._UpToEmployeesByEmployeeID);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToEmployeesByEmployeeID");
				}
			}
		}
		#endregion
		

				
		#region UpToShippersByShipVia - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Orders_Shippers
		/// </summary>

		[XmlIgnore]
					
		public Shippers UpToShippersByShipVia
		{
			get
			{
				if (this.es.IsLazyLoadDisabled) return null;
				
				if(this._UpToShippersByShipVia == null && ShipVia != null)
				{
					this._UpToShippersByShipVia = new Shippers();
					this._UpToShippersByShipVia.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToShippersByShipVia", this._UpToShippersByShipVia);
					this._UpToShippersByShipVia.Query.Where(this._UpToShippersByShipVia.Query.ShipperID == this.ShipVia);
					this._UpToShippersByShipVia.Query.Load();
				}	
				return this._UpToShippersByShipVia;
			}
			
			set
			{
				this.RemovePreSave("UpToShippersByShipVia");
				
				bool changed = this._UpToShippersByShipVia != value;

				if(value == null)
				{
					this.ShipVia = null;
					this._UpToShippersByShipVia = null;
				}
				else
				{
					this.ShipVia = value.ShipperID;
					this._UpToShippersByShipVia = value;
					this.SetPreSave("UpToShippersByShipVia", this._UpToShippersByShipVia);
				}
				
				if( changed )
				{
					this.OnPropertyChanged("UpToShippersByShipVia");
				}
			}
		}
		#endregion
		

		
		protected override esEntityCollectionBase CreateCollectionForPrefetch(string name)
		{
			esEntityCollectionBase coll = null;

			switch (name)
			{
				case "OrderDetailsCollectionByOrderID":
					coll = this.OrderDetailsCollectionByOrderID;
					break;	
			}

			return coll;
		}		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "OrderDetailsCollectionByOrderID", typeof(OrderDetailsCollection), new OrderDetails()));
		
			return props;
		}
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToEmployeesByEmployeeID != null)
			{
				this.EmployeeID = this._UpToEmployeesByEmployeeID.EmployeeID;
			}
			if(!this.es.IsDeleted && this._UpToShippersByShipVia != null)
			{
				this.ShipVia = this._UpToShippersByShipVia.ShipperID;
			}
		}
		
		/// <summary>
		/// Called by ApplyPostSaveKeys 
		/// </summary>
		/// <param name="coll">The collection to enumerate over</param>
		/// <param name="key">"The column name</param>
		/// <param name="value">The column value</param>
		private void Apply(esEntityCollectionBase coll, string key, object value)
		{
			foreach (esEntity obj in coll)
			{
				if (obj.es.IsAdded)
				{
					obj.SetProperty(key, value);
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._OrderDetailsCollection != null)
			{
				Apply(this._OrderDetailsCollection, "OrderID", this.OrderID);
			}
			if(this._OrderDetailsCollectionByOrderID != null)
			{
				Apply(this._OrderDetailsCollectionByOrderID, "OrderID", this.OrderID);
			}
		}
		
	}
	



	[DataContract(Namespace = "http://tempuri.org/", Name = "Orders")]
	[XmlType(TypeName="OrdersProxyStub")]	
	[Serializable]
	public partial class OrdersProxyStub
	{
		public OrdersProxyStub() 
		{
			theEntity = this.entity = new Orders();
		}

		public OrdersProxyStub(Orders obj)
		{
			theEntity = this.entity = obj;
		}

		public OrdersProxyStub(Orders obj, bool dirtyColumnsOnly)
		{
			theEntity = this.entity = obj;
			this.dirtyColumnsOnly = dirtyColumnsOnly;
		}
			
		#region Implicit Casts

		public static implicit operator Orders(OrdersProxyStub entity)
		{
			return entity.Entity;
		}

		#endregion	
		
		public Type GetEntityType()
		{
			return typeof(Orders);
		}

		[DataMember(Name="a0", Order=1, EmitDefaultValue=false)]
		public System.Int32? OrderID
		{
			get 
			{ 
				if (this.Entity.es.IsDeleted)
					return (System.Int32?)this.Entity.
						GetOriginalColumnValue(OrdersMetadata.ColumnNames.OrderID);
				else
					return this.Entity.OrderID;
			}
			set { this.Entity.OrderID = value; }
		}

		[DataMember(Name="a1", Order=2, EmitDefaultValue=false)]
		public System.String CustomerID
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.CustomerID))
					return this.Entity.CustomerID;
				else
					return null;
			}
			set { this.Entity.CustomerID = value; }
		}

		[DataMember(Name="a2", Order=3, EmitDefaultValue=false)]
		public System.Int32? EmployeeID
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.EmployeeID))
					return this.Entity.EmployeeID;
				else
					return null;
			}
			set { this.Entity.EmployeeID = value; }
		}

		[DataMember(Name="a3", Order=4, EmitDefaultValue=false)]
		public System.DateTime? OrderDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.OrderDate))
					return this.Entity.OrderDate;
				else
					return null;
			}
			set { this.Entity.OrderDate = value; }
		}

		[DataMember(Name="a4", Order=5, EmitDefaultValue=false)]
		public System.DateTime? RequiredDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.RequiredDate))
					return this.Entity.RequiredDate;
				else
					return null;
			}
			set { this.Entity.RequiredDate = value; }
		}

		[DataMember(Name="a5", Order=6, EmitDefaultValue=false)]
		public System.DateTime? ShippedDate
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShippedDate))
					return this.Entity.ShippedDate;
				else
					return null;
			}
			set { this.Entity.ShippedDate = value; }
		}

		[DataMember(Name="a6", Order=7, EmitDefaultValue=false)]
		public System.Int32? ShipVia
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipVia))
					return this.Entity.ShipVia;
				else
					return null;
			}
			set { this.Entity.ShipVia = value; }
		}

		[DataMember(Name="a7", Order=8, EmitDefaultValue=false)]
		public System.Decimal? Freight
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.Freight))
					return this.Entity.Freight;
				else
					return null;
			}
			set { this.Entity.Freight = value; }
		}

		[DataMember(Name="a8", Order=9, EmitDefaultValue=false)]
		public System.String ShipName
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipName))
					return this.Entity.ShipName;
				else
					return null;
			}
			set { this.Entity.ShipName = value; }
		}

		[DataMember(Name="a9", Order=10, EmitDefaultValue=false)]
		public System.String ShipAddress
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipAddress))
					return this.Entity.ShipAddress;
				else
					return null;
			}
			set { this.Entity.ShipAddress = value; }
		}

		[DataMember(Name="a10", Order=11, EmitDefaultValue=false)]
		public System.String ShipCity
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipCity))
					return this.Entity.ShipCity;
				else
					return null;
			}
			set { this.Entity.ShipCity = value; }
		}

		[DataMember(Name="a11", Order=12, EmitDefaultValue=false)]
		public System.String ShipRegion
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipRegion))
					return this.Entity.ShipRegion;
				else
					return null;
			}
			set { this.Entity.ShipRegion = value; }
		}

		[DataMember(Name="a12", Order=13, EmitDefaultValue=false)]
		public System.String ShipPostalCode
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipPostalCode))
					return this.Entity.ShipPostalCode;
				else
					return null;
			}
			set { this.Entity.ShipPostalCode = value; }
		}

		[DataMember(Name="a13", Order=14, EmitDefaultValue=false)]
		public System.String ShipCountry
		{
			get 
			{ 
				
				if (this.IncludeColumn(OrdersMetadata.ColumnNames.ShipCountry))
					return this.Entity.ShipCountry;
				else
					return null;
			}
			set { this.Entity.ShipCountry = value; }
		}


		[DataMember(Name="a10000", Order=10000)]
		public string esRowState
		{
			get { return TheRowState;  }
			set { TheRowState = value; }
		}
		
		[DataMember(Name="a10001", Order=10001, EmitDefaultValue=false)]
		private List<string> ModifiedColumns
		{
			get { return Entity.es.ModifiedColumns; }
			set 
			{ 
				Entity.es.ModifiedColumns.AddRange(value); 
			}
		}
		
		[DataMember(Name="a10002", Order=10002, EmitDefaultValue=false)]
		[XmlIgnore]		
		public Dictionary<string, object> esExtraColumns
		{
			get { return Entity.GetExtraColumns(); }
			set { Entity.SetExtraColumns(value);   }
		}
		
		[XmlArray("_x_ExtraColumns")]
		[XmlArrayItem("_x_ExtraColumns", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_ExtraColumns
		{
			get
			{
				Dictionary<string, object> extra = Entity.GetExtraColumns();

				// Make an array of DictionaryEntries to return   
				DictionaryEntry[] ret = new DictionaryEntry[extra.Count];
				int i = 0;
				DictionaryEntry de;

				// Iterate through the extra columns to load items into the array.   
				foreach (KeyValuePair<string, object> kv in extra)
				{
					de = new DictionaryEntry();
					de.Key = kv.Key;
					de.Value = kv.Value;
					ret[i] = de;
					i++;
				}
				return ret;
			}
			set
			{
				Dictionary<string, object> extra = new Dictionary<string, object>();
				for (int i = 0; i < value.Length; i++)
				{
					extra.Add((string)value[i].Key, (int)value[i].Value);
				}
				Entity.SetExtraColumns(extra);
			}
		}	

		[XmlIgnore]
		public Orders Entity
		{
			get
			{
				if (this.entity == null)
				{
					theEntity = this.entity = new Orders();
				}

				return this.entity;
			}

			set
			{
				this.entity = value;
			}
		}
		
		protected string TheRowState
		{
			get
			{
				return theEntity.es.RowState.ToString();
			}

			set
			{
				switch (value)
				{
					case "Unchanged":
						theEntity.AcceptChanges();
						break;

					case "Added":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Added;
						break;

					case "Modified":
						theEntity.AcceptChanges();
						theEntity.es.RowState = esDataRowState.Modified;
						break;

					case "Deleted":
						theEntity.AcceptChanges();
						theEntity.MarkAsDeleted();
						break;
				}
			}
		}		
		
		protected bool IncludeColumn(string columnName)
		{
			bool include = false;

			if (dirtyColumnsOnly)
			{
				if (theEntity.es.ModifiedColumns != null &&
					theEntity.es.ModifiedColumns.Contains(columnName))
				{
					include = true;
				}
			}
			else if (!theEntity.es.IsDeleted)
			{
				include = true;
			}

			return include;
		}		

		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		public Orders entity;
		
		[NonSerialized, XmlIgnore, CLSCompliant(false)]
		protected esEntity theEntity;

		[NonSerialized, XmlIgnore]
		protected bool dirtyColumnsOnly;		
	}



	[DataContract(Namespace = "http://tempuri.org/", Name = "OrdersCollection")]
	[XmlType(TypeName="OrdersCollectionProxyStub")]	
	[Serializable]
	public partial class OrdersCollectionProxyStub 
	{
		protected OrdersCollectionProxyStub() {}
		
		public OrdersCollectionProxyStub(esEntityCollection<Orders> coll)
			: this(coll, false, false)
		{
		
		}		
		
		public OrdersCollectionProxyStub(esEntityCollection<Orders> coll, bool dirtyRowsOnly)
			: this(coll, dirtyRowsOnly, false)
		{

		}	
		
		#region Implicit Casts

		public static implicit operator OrdersCollection(OrdersCollectionProxyStub proxyStubCollection)
		{
			return proxyStubCollection.GetCollection();
		}

		#endregion

		public Type GetEntityType()
		{
			return typeof(Orders);
		}
		
		public OrdersCollectionProxyStub(esEntityCollection<Orders> coll, bool dirtyRowsOnly, bool dirtyColumnsOnly)
		{		
			foreach (Orders entity in coll)
			{
				switch (entity.RowState)
				{
					case esDataRowState.Added:
					case esDataRowState.Modified:

						Collection.Add(new OrdersProxyStub(entity, dirtyColumnsOnly));
						break;

					case esDataRowState.Unchanged:

						if (!dirtyRowsOnly)
						{
							Collection.Add(new OrdersProxyStub(entity, dirtyColumnsOnly));
						}
						break;
				}
			}

			if (coll.es.DeletedEntities != null)
			{
				foreach (Orders entity in coll.es.DeletedEntities)
				{
					Collection.Add(new OrdersProxyStub(entity, dirtyColumnsOnly));
				}
			}
		}		

		[DataMember(Name = "Collection", EmitDefaultValue = false)]
		public List<OrdersProxyStub> Collection = new List<OrdersProxyStub>();

		public OrdersCollection GetCollection()
		{
			if (this._coll == null)
			{
				this._coll = new OrdersCollection();

				foreach (OrdersProxyStub proxy in this.Collection)
				{
					this._coll.AttachEntity(proxy.Entity);
				}
			}

			return this._coll;
		}

		[NonSerialized]
		[XmlIgnore]
		private OrdersCollection _coll;
	}



	[Serializable]
	public partial class OrdersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected OrdersMetadata()
		{
			m_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(OrdersMetadata.ColumnNames.OrderID, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrdersMetadata.PropertyNames.OrderID;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.CustomerID, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.CustomerID;
			c.CharacterMaxLength = 5;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.EmployeeID, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrdersMetadata.PropertyNames.EmployeeID;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.OrderDate, 3, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OrdersMetadata.PropertyNames.OrderDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.RequiredDate, 4, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OrdersMetadata.PropertyNames.RequiredDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShippedDate, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = OrdersMetadata.PropertyNames.ShippedDate;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipVia, 6, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipVia;
			c.NumericPrecision = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.Freight, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = OrdersMetadata.PropertyNames.Freight;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"(0)";
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipName, 8, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipName;
			c.CharacterMaxLength = 40;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipAddress, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipAddress;
			c.CharacterMaxLength = 60;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipCity, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipCity;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipRegion, 11, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipRegion;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipPostalCode, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipPostalCode;
			c.CharacterMaxLength = 10;
			c.IsNullable = true;
			m_columns.Add(c);
				
			c = new esColumnMetadata(OrdersMetadata.ColumnNames.ShipCountry, 13, typeof(System.String), esSystemType.String);
			c.PropertyName = OrdersMetadata.PropertyNames.ShipCountry;
			c.CharacterMaxLength = 15;
			c.IsNullable = true;
			m_columns.Add(c);
				
		}
		#endregion	
	
		static public OrdersMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base.m_dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base.m_columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string CustomerID = "CustomerID";
			 public const string EmployeeID = "EmployeeID";
			 public const string OrderDate = "OrderDate";
			 public const string RequiredDate = "RequiredDate";
			 public const string ShippedDate = "ShippedDate";
			 public const string ShipVia = "ShipVia";
			 public const string Freight = "Freight";
			 public const string ShipName = "ShipName";
			 public const string ShipAddress = "ShipAddress";
			 public const string ShipCity = "ShipCity";
			 public const string ShipRegion = "ShipRegion";
			 public const string ShipPostalCode = "ShipPostalCode";
			 public const string ShipCountry = "ShipCountry";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string OrderID = "OrderID";
			 public const string CustomerID = "CustomerID";
			 public const string EmployeeID = "EmployeeID";
			 public const string OrderDate = "OrderDate";
			 public const string RequiredDate = "RequiredDate";
			 public const string ShippedDate = "ShippedDate";
			 public const string ShipVia = "ShipVia";
			 public const string Freight = "Freight";
			 public const string ShipName = "ShipName";
			 public const string ShipAddress = "ShipAddress";
			 public const string ShipCity = "ShipCity";
			 public const string ShipRegion = "ShipRegion";
			 public const string ShipPostalCode = "ShipPostalCode";
			 public const string ShipCountry = "ShipCountry";
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
			lock (typeof(OrdersMetadata))
			{
				if(OrdersMetadata.mapDelegates == null)
				{
					OrdersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (OrdersMetadata.meta == null)
				{
					OrdersMetadata.meta = new OrdersMetadata();
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


				meta.AddTypeMap("OrderID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("CustomerID", new esTypeMap("nchar", "System.String"));
				meta.AddTypeMap("EmployeeID", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("OrderDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("RequiredDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ShippedDate", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("ShipVia", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Freight", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("ShipName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipAddress", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipCity", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipRegion", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipPostalCode", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("ShipCountry", new esTypeMap("nvarchar", "System.String"));			
				
				
				
				meta.Source = "Orders";
				meta.Destination = "Orders";
				
				meta.spInsert = "proc_OrdersInsert";				
				meta.spUpdate = "proc_OrdersUpdate";		
				meta.spDelete = "proc_OrdersDelete";
				meta.spLoadAll = "proc_OrdersLoadAll";
				meta.spLoadByPrimaryKey = "proc_OrdersLoadByPrimaryKey";
				
				this.m_providerMetadataMaps["esDefault"] = meta;
			}
			
			return this.m_providerMetadataMaps["esDefault"];
		}

		#endregion

		static private OrdersMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
