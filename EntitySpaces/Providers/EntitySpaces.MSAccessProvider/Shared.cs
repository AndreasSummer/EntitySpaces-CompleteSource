/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

using EntitySpaces.DynamicQuery;
using EntitySpaces.Interfaces;

namespace EntitySpaces.MSAccessProvider
{
    class Shared
    {
        static public OleDbCommand BuildDynamicInsertCommand(esDataRequest request, esEntitySavePacket packet)
        {
            string sql = String.Empty;
            string defaults = String.Empty;
            string into = String.Empty;
            string values = String.Empty;
            string comma = String.Empty;
            string defaultComma = String.Empty;
            string where = String.Empty;
            string whereComma = String.Empty;
 
            PropertyCollection props = new PropertyCollection();
            OleDbParameter p = null;

            Dictionary<string, OleDbParameter> types = Cache.GetParameters(request);

            OleDbCommand cmd = new OleDbCommand();
            if (request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            esColumnMetadataCollection cols = request.Columns;
            foreach (esColumnMetadata col in cols)
            {
                bool isModified = packet.ModifiedColumns == null ? false : packet.ModifiedColumns.Contains(col.Name);

                if (isModified && (!col.IsAutoIncrement && !col.IsConcurrency && !col.IsEntitySpacesConcurrency))
                {
                    p = cmd.Parameters.Add(CloneParameter(types[col.Name]));

                    into += comma + Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose;
                    values += comma + p.ParameterName;
                    comma = ", ";
                }
                else if (col.IsAutoIncrement)
                {
                    props["AutoInc"] = col.Name;
                    props["Source"] = request.ProviderMetadata.Source;
                }
                else if (col.IsConcurrency)
                {
                    props["Timestamp"] = col.Name;
                    props["Source"] = request.ProviderMetadata.Source;
                }
                else if (col.IsEntitySpacesConcurrency)
                {
                    props["EntitySpacesConcurrency"] = col.Name;

                    into += comma + Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose;
                    values += comma + "1";
                    comma = ", ";

                    p = CloneParameter(types[col.Name]);
                    p.Value = 1;
                    cmd.Parameters.Add(p);
                }
                else if (col.IsComputed)
                {
                    // Do nothing but leave this here
                }
                else if (cols.IsSpecialColumn(col))
                {
                    // Do nothing but leave this here
                }
                else if (col.HasDefault)
                {
                    defaults += defaultComma + Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose;
                    defaultComma = ",";
                }

                if (col.IsInPrimaryKey)
                {
                    where += whereComma + col.Name;
                    whereComma = ",";
                }
            }

            #region Special Columns
            if (cols.DateAdded != null && cols.DateAdded.IsServerSide)
            {
                into += comma + Delimiters.ColumnOpen + cols.DateAdded.ColumnName + Delimiters.ColumnClose;
                values += comma + request.ProviderMetadata["DateAdded.ServerSideText"];
                comma = ", ";

                defaults += defaultComma + Delimiters.ColumnOpen + cols.DateAdded.ColumnName + Delimiters.ColumnClose;
                defaultComma = ",";
            }

            if (cols.DateModified != null && cols.DateModified.IsServerSide)
            {
                into += comma + Delimiters.ColumnOpen + cols.DateModified.ColumnName + Delimiters.ColumnClose;
                values += comma + request.ProviderMetadata["DateModified.ServerSideText"];
                comma = ", ";

                defaults += defaultComma + Delimiters.ColumnOpen + cols.DateModified.ColumnName + Delimiters.ColumnClose;
                defaultComma = ",";
            }

            if (cols.AddedBy != null && cols.AddedBy.IsServerSide)
            {
                into += comma + Delimiters.ColumnOpen + cols.AddedBy.ColumnName + Delimiters.ColumnClose;
                values += comma + request.ProviderMetadata["AddedBy.ServerSideText"];
                comma = ", ";

                defaults += defaultComma + Delimiters.ColumnOpen + cols.AddedBy.ColumnName + Delimiters.ColumnClose;
                defaultComma = ",";
            }

            if (cols.ModifiedBy != null && cols.ModifiedBy.IsServerSide)
            {
                into += comma + Delimiters.ColumnOpen + cols.ModifiedBy.ColumnName + Delimiters.ColumnClose;
                values += comma + request.ProviderMetadata["ModifiedBy.ServerSideText"];
                comma = ", ";

                defaults += defaultComma + Delimiters.ColumnOpen + cols.ModifiedBy.ColumnName + Delimiters.ColumnClose;
                defaultComma = ",";
            }
            #endregion

            if (defaults.Length > 0)
            {
                comma = String.Empty;
                props["Defaults"] = defaults;
                props["Where"] = where;
            }

            sql += "INSERT INTO " + CreateFullName(request);

            if (into.Length != 0)
            {
                sql += "(" + into + ") VALUES (" + values + ")";
            }
            else
            {
                sql += "DEFAULT VALUES";
            }

            request.Properties = props;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        static public OleDbCommand BuildDynamicUpdateCommand(esDataRequest request, esEntitySavePacket packet)
        {
            string where = String.Empty;
            string scomma = String.Empty;
            string wcomma = String.Empty;
            string defaults = String.Empty;
            string defaultsWhere = String.Empty;
            string defaultsComma = String.Empty;
            string defaultsWhereComma = String.Empty;
            List<OleDbParameter> whereParams = new List<OleDbParameter>();

            string sql = "UPDATE " + CreateFullName(request) + " SET ";

            PropertyCollection props = new PropertyCollection();
            OleDbParameter p = null;

            Dictionary<string, OleDbParameter> types = Cache.GetParameters(request);

            OleDbCommand cmd = new OleDbCommand();
            if (request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            esColumnMetadataCollection cols = request.Columns;
            foreach (esColumnMetadata col in cols)
            {
                bool isModified = packet.ModifiedColumns == null ? false : packet.ModifiedColumns.Contains(col.Name);

                if (isModified && (!col.IsAutoIncrement && !col.IsConcurrency && !col.IsEntitySpacesConcurrency))
                {
                    p = cmd.Parameters.Add(CloneParameter(types[col.Name]));

                    sql += scomma;
                    sql += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + p.ParameterName;
                    scomma = ", ";
                }
                else if (col.IsAutoIncrement)
                {
                    // Nothing to do but leave this here
                }
                else if (col.IsConcurrency)
                {
                    p = CloneParameter(types[col.Name]);
                    p.SourceVersion = DataRowVersion.Original;
                    whereParams.Add(p);
                    //cmd.Parameters.Add(p);

                    where += wcomma;
                    where += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + p.ParameterName;
                    wcomma = " AND ";
                }
                else if (col.IsEntitySpacesConcurrency)
                {
                    props["EntitySpacesConcurrency"] = col.Name;

                    p = CloneParameter(types[col.Name]);
                    p.SourceVersion = DataRowVersion.Original;
                    whereParams.Add(p);
                    //cmd.Parameters.Add(p);

                    sql += scomma;
                    sql += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " + 1";
                    scomma = ", ";

                    where += wcomma;
                    where += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + p.ParameterName;
                    wcomma = " AND ";
                }
                else if (col.IsComputed)
                {
                    // Do nothing but leave this here
                }
                else if (cols.IsSpecialColumn(col))
                {
                    // Do nothing but leave this here
                }
                else if (col.HasDefault)
                {
                    // defaults += defaultsComma + Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose;
                    // defaultsComma = ",";
                }

                if (col.IsInPrimaryKey)
                {
                    p = CloneParameter(types[col.Name]);
                    p.SourceVersion = DataRowVersion.Original;
                    whereParams.Add(p);
                    //cmd.Parameters.Add(p);

                    where += wcomma;
                    where += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + p.ParameterName;
                    wcomma = " AND ";

                    defaultsWhere += defaultsWhereComma + col.Name;
                    defaultsWhereComma = ",";
                }
            }

            #region Special Columns
            if (cols.DateModified != null && cols.DateModified.IsServerSide)
            {
                sql += scomma;
                sql += Delimiters.ColumnOpen + cols.DateModified.ColumnName + Delimiters.ColumnClose + " = " + request.ProviderMetadata["DateModified.ServerSideText"];
                scomma = ", ";

                defaults += defaultsComma + Delimiters.ColumnOpen + cols.DateModified.ColumnName + Delimiters.ColumnClose;
                defaultsComma = ",";
            }

            if (cols.ModifiedBy != null && cols.ModifiedBy.IsServerSide)
            {
                sql += scomma;
                sql += Delimiters.ColumnOpen + cols.ModifiedBy.ColumnName + Delimiters.ColumnClose + " = " + request.ProviderMetadata["ModifiedBy.ServerSideText"];
                scomma = ", ";

                defaults += defaultsComma + Delimiters.ColumnOpen + cols.ModifiedBy.ColumnName + Delimiters.ColumnClose;
                defaultsComma = ",";
            }
            #endregion

            if (defaults.Length > 0)
            {
                props["Defaults"] = defaults;
                props["Where"] = defaultsWhere;
            }

            if (whereParams.Count > 0)
            {
                foreach (OleDbParameter parm in whereParams)
                {
                    cmd.Parameters.Add(parm);
                }
            }

            sql += " WHERE (" + where + ")";

            request.Properties = props;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        static public OleDbCommand BuildDynamicDeleteCommand(esDataRequest request, List<string> modifiedColumns)
        {
            Dictionary<string, OleDbParameter> types = Cache.GetParameters(request);

            OleDbCommand cmd = new OleDbCommand();
            if (request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            string sql = "DELETE FROM " + CreateFullName(request) + " ";

            string comma = String.Empty;
            comma = String.Empty;
            sql += " WHERE ";
            foreach (esColumnMetadata col in request.Columns)
            {
                if (col.IsInPrimaryKey || col.IsEntitySpacesConcurrency)
                {
                    OleDbParameter p = types[col.Name];
                    cmd.Parameters.Add(CloneParameter(p));

                    sql += comma;
                    sql += Delimiters.ColumnOpen + col.Name + Delimiters.ColumnClose + " = " + p.ParameterName;
                    comma = " AND ";
                }
            }

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }

        static public OleDbCommand BuildStoredProcInsertCommand(esDataRequest request)
        {
            OleDbCommand cmd = new OleDbCommand();
            if(request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Delimiters.StoredProcNameOpen + request.ProviderMetadata.spInsert + Delimiters.StoredProcNameClose;

            PopulateStoredProcParameters(cmd, request);

            return cmd;
        }

        static public OleDbCommand BuildStoredProcUpdateCommand(esDataRequest request)
        {
            OleDbCommand cmd = new OleDbCommand();
            if(request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Delimiters.StoredProcNameOpen + request.ProviderMetadata.spUpdate + Delimiters.StoredProcNameClose;

            PopulateStoredProcParameters(cmd, request);

            foreach (esColumnMetadata col in request.Columns)
            {
                if (col.IsComputed)
                {
                    OleDbParameter p = cmd.Parameters[Delimiters.Param + col.PropertyName];
                    p.Direction = ParameterDirection.InputOutput;
                }
            }

            return cmd;
        }

        static public OleDbCommand BuildStoredProcDeleteCommand(esDataRequest request)
        {
            OleDbCommand cmd = new OleDbCommand();
            if(request.CommandTimeout != null) cmd.CommandTimeout = request.CommandTimeout.Value;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Delimiters.StoredProcNameOpen + request.ProviderMetadata.spDelete + Delimiters.StoredProcNameClose;

            Dictionary<string, OleDbParameter> types = Cache.GetParameters(request);

            OleDbParameter p;

            foreach (esColumnMetadata col in request.Columns)
            {
                if (col.IsInPrimaryKey)
                {
                    p = types[col.Name];
                    p = CloneParameter(p);
                    p.SourceVersion = DataRowVersion.Current;
                    cmd.Parameters.Add(p);
                }
            }

            return cmd;
        }

        static public void PopulateStoredProcParameters(OleDbCommand cmd, esDataRequest request)
        {
            Dictionary<string, OleDbParameter> types = Cache.GetParameters(request);

            OleDbParameter p;

            foreach (esColumnMetadata col in request.Columns)
            {
                p = types[col.Name];
                p = CloneParameter(p);
                p.SourceVersion = DataRowVersion.Current;

                if (p.OleDbType == OleDbType.DBTimeStamp)
                {
                    p.Direction = ParameterDirection.InputOutput;
                }
                cmd.Parameters.Add(p);
            }
        }

        static private OleDbParameter CloneParameter(OleDbParameter p)
        {
            ICloneable param = p as ICloneable;
            return param.Clone() as OleDbParameter;
        }

        static public string CreateFullName(esDynamicQuerySerializable query)
        {
            IDynamicQuerySerializableInternal iQuery = query as IDynamicQuerySerializableInternal;
            esProviderSpecificMetadata providerMetadata = iQuery.ProviderMetadata as esProviderSpecificMetadata;

            string name = String.Empty;

            name += Delimiters.TableOpen;
            if (query.es.QuerySource != null)
                name += query.es.QuerySource;
            else
                name += providerMetadata.Destination;
            name += Delimiters.TableClose;

            return name;
        }

        static public string CreateFullName(esDataRequest request)
        {
            string name = String.Empty;

            name += Delimiters.TableOpen;
            if(request.DynamicQuery != null && request.DynamicQuery.es.QuerySource != null)
                name += request.DynamicQuery.es.QuerySource;
            else
                name += request.ProviderMetadata.Destination;
            name += Delimiters.TableClose;

            return name;
        }

        static public string CreateFullName(esProviderSpecificMetadata providerMetadata)
        {
            return Delimiters.TableOpen + providerMetadata.Destination + Delimiters.TableClose;
        }

        static public esConcurrencyException CheckForConcurrencyException(OleDbException ex)
        {
            esConcurrencyException ce = null;

            if (ex.Errors != null)
            {
                foreach (OleDbError err in ex.Errors)
                {
                    if (err.NativeError == 532)
                    {
                        ce = new esConcurrencyException(err.Message, ex);
                        ce.Source = err.Source;
                        break;
                    }
                }
            }

            return ce;
        }

    }
}
