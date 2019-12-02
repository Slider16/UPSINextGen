using Core.Common.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilities.BL.Models;

namespace Utilities.DL.Repositories
{
    public class DynamicGridRecordRepository : IRepository<DynamicGridRecord>
    {
        public bool Save(DynamicGridRecord item)
        {
            throw new NotImplementedException();
        }

        public int AddItem(DynamicGridRecord item)
        {
            throw new NotImplementedException();
        }

        public DynamicGridRecord GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<DynamicGridRecord> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<DynamicGridRecord> GetFieldValueOwnerRecords(string _tableName, string _fieldName, string _fieldValue)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UPSINextGenConnection"].ToString());
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.GetFieldValueOwner", con))
            {
                try
                {
                    ObservableCollection<DynamicGridRecord> dynamicGridRecordList = new ObservableCollection<DynamicGridRecord>();

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.VarChar);
                    tablename.Value = _tableName;

                    SqlParameter fieldname = new SqlParameter("@fieldname", SqlDbType.VarChar);
                    fieldname.Value = _fieldName;

                    SqlParameter fieldvalue = new SqlParameter("@fieldvalue", SqlDbType.VarChar);
                    fieldvalue.Value = _fieldValue;

                    cmd.Parameters.Add(tablename);
                    cmd.Parameters.Add(fieldname);
                    cmd.Parameters.Add(fieldvalue);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DynamicGridRecord record = new DynamicGridRecord();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            DynamicGridProperty property = new DynamicGridProperty(reader.GetName(i), reader.GetValue(i));

                            record.Properties.Add(property);
                        }

                        dynamicGridRecordList.Add(record);
                    }

                    con.Close();
                    return dynamicGridRecordList;
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        
        public bool UpdateItem(DynamicGridRecord item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<DynamicGridRecord> updatedItems)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(DynamicGridRecord item)
        {
            throw new NotImplementedException();
        }

  
    }
}
