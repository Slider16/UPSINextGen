using Core.Common.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilities.BL.Models;

namespace Utilities.DL.Repositories
{
    public class MetaSourceFieldRepository : IRepository<MetaSourceField>
    {
        public bool Save(MetaSourceField item)
        {
            throw new NotImplementedException();
        }

        public int AddItem(MetaSourceField item)
        {
            throw new NotImplementedException();
        }

        public MetaSourceField GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MetaSourceField> GetItems(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MetaSourceField> GetMetaSourceFieldsByTableName(string _tableName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UPSINextGenConnection"].ToString());
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.GetMetaSourceFieldsByTableName", con))
            {
                try
                {

                    ObservableCollection<MetaSourceField> metaSourceFieldList = new ObservableCollection<MetaSourceField>();

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.VarChar);
                    tablename.Value = _tableName;
                    cmd.Parameters.Add(tablename);

                    MetaSourceField metaSourceField;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        metaSourceField = new MetaSourceField();
                        metaSourceField.MetaSourceFieldID = int.Parse(reader["MetaSourceFieldID"].ToString());
                        metaSourceField.FieldName = reader["FieldName"].ToString();
                        metaSourceField.VFPDataType = reader["vfpDataType"].ToString();
                        metaSourceField.IsDeleted = int.Parse(reader["isDeleted"].ToString());

                        metaSourceFieldList.Add(metaSourceField);
                    }

                    con.Close();
                    return metaSourceFieldList;
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        public bool UpdateItem(MetaSourceField item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<MetaSourceField> updatedItems)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(MetaSourceField item)
        {
            throw new NotImplementedException();
        }
    }
}
