/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : VistaDB4
Date Generated       : 3/17/2012 4:45:36 AM
===============================================================================
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
    public partial class ReferredEmployeeMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesVistaDB4()
		{
			// This is only executed once per the life of the application
			lock (typeof(ReferredEmployeeMetadata))
			{
				if(ReferredEmployeeMetadata.mapDelegates == null)
				{
					ReferredEmployeeMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ReferredEmployeeMetadata.meta == null)
				{
					ReferredEmployeeMetadata.meta = new ReferredEmployeeMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esVistaDB4);
				mapDelegates.Add("esVistaDB4", mapMethod);
				mapMethod("esVistaDB4");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esVistaDB4(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("EmployeeID", new esTypeMap("Int", "System.Int32"));
				meta.AddTypeMap("ReferredID", new esTypeMap("Int", "System.Int32"));				
				meta.Catalog = "ForeignKeyTest.vdb4";
				
				meta.Source = "ReferredEmployee";
				meta.Destination = "ReferredEmployee";
				
				meta.spInsert = "proc_ReferredEmployeeInsert";				
				meta.spUpdate = "proc_ReferredEmployeeUpdate";		
				meta.spDelete = "proc_ReferredEmployeeDelete";
				meta.spLoadAll = "proc_ReferredEmployeeLoadAll";
				meta.spLoadByPrimaryKey = "proc_ReferredEmployeeLoadByPrimaryKey";
				
				m_providerMetadataMaps["esVistaDB4"] = meta;
			}
			
			return m_providerMetadataMaps["esVistaDB4"];
		}
		
		static private int _esVistaDB4 = RegisterDelegateesVistaDB4();
    }
}
