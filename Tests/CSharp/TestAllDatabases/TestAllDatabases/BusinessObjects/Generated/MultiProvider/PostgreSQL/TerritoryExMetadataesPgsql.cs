/*
===============================================================================
                    EntitySpaces Studio by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2012.1.0319.0
EntitySpaces Driver  : PostgreSQL
Date Generated       : 3/17/2012 4:45:08 AM
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
    public partial class TerritoryExMetadata : esMetadata, IMetadata
    {
		static private int RegisterDelegateesPgsql()
		{
			// This is only executed once per the life of the application
			lock (typeof(TerritoryExMetadata))
			{
				if(TerritoryExMetadata.mapDelegates == null)
				{
					TerritoryExMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (TerritoryExMetadata.meta == null)
				{
					TerritoryExMetadata.meta = new TerritoryExMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esPgsql);
				mapDelegates.Add("esPgsql", mapMethod);
				mapMethod("esPgsql");
			}
			return 0;	
		}		
		
		private esProviderSpecificMetadata esPgsql(string mapName)
		{
			if(!m_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();	
				

				meta.AddTypeMap("TerritoryID", new esTypeMap("int8", "System.Int64"));
				meta.AddTypeMap("Notes", new esTypeMap("varchar", "System.String"));				
				meta.Catalog = "ForeignKeyTest";
				meta.Schema = "public";
				meta.Source = "TerritoryEx";
				meta.Destination = "TerritoryEx";
				
				meta.spInsert = "proc_TerritoryExInsert";				
				meta.spUpdate = "proc_TerritoryExUpdate";		
				meta.spDelete = "proc_TerritoryExDelete";
				meta.spLoadAll = "proc_TerritoryExLoadAll";
				meta.spLoadByPrimaryKey = "proc_TerritoryExLoadByPrimaryKey";
				
				m_providerMetadataMaps["esPgsql"] = meta;
			}
			
			return m_providerMetadataMaps["esPgsql"];
		}
		
		static private int _esPgsql = RegisterDelegateesPgsql();
    }
}
