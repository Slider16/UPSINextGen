using Core.Common.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilities.BL.Models;

namespace Utilities.DL.Repositories
{
    public class MetaSourceDataRepository :IRepository<MetaData>
    {
        public bool Save(MetaData item)
        {
            throw new NotImplementedException();
        }

        public int AddItem(MetaData item)
        {
            throw new NotImplementedException();
        }

        public MetaData GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MetaData> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MetaData> GetMetaSourceDataByTableAndField(string _tableName, string _fieldName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UPSINextGenConnection"].ToString());
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.GetMetaSourceDataByTableAndField", con))
            {
                try
                {
                    ObservableCollection<MetaData> metaSourceDataList = new ObservableCollection<MetaData>();

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.VarChar);
                    tablename.Value = _tableName;
                    
                    SqlParameter fieldname = new SqlParameter("@fieldname", SqlDbType.VarChar);
                    fieldname.Value = _fieldName;

                    cmd.Parameters.Add(tablename);
                    cmd.Parameters.Add(fieldname);

                    MetaData metaData;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        metaData = MetaData.CreateNewMetaData();
                        metaData.TableName = _tableName;
                        metaData.FieldName = _fieldName;
                        metaData.FieldValue = reader[_fieldName].ToString();

                        metaSourceDataList.Add(metaData);
                    }

                    con.Close();
                    return metaSourceDataList;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public bool UpdateItem(MetaData item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<MetaData> updatedItems)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(MetaData item)
        {
            throw new NotImplementedException();
        }

    }
}
