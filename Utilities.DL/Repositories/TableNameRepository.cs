using Core.Common.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using Utilities.BL.Models;

namespace Utilities.DL.Repositories
{
    public class TableNameRepository : IRepository<TableName>
    {
        public bool Save(TableName item)
        {
            throw new NotImplementedException();
        }

        public int AddItem(TableName item)
        {
            throw new NotImplementedException();
        }

        public TableName GetItem(int key)
        {
            throw new NotImplementedException();
        }

        // TODO: Straighten out connection strings here and everywhere.  You're actually using App.config, NOT String_DL.resx

        public ObservableCollection<TableName> GetItems(bool includeDeleted=false)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UPSINextGenConnection"].ToString());
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.GetTableNames", con))
            {
                var reader = cmd.ExecuteReader();

                ObservableCollection<TableName> tableNameList = new ObservableCollection<TableName>();

                TableName tableName;

                while (reader.Read())
                {
                    tableName = new TableName();
                    tableName.DisplayName = reader["DisplayName"].ToString();
                    tableName.OriginalName = reader["tablename"].ToString();
                    switch ( reader["IsActive"].ToString())
                    {
                        case "1":
                            tableName.EntityState = Core.Common.EntityStateOption.Active;
                            break;
                        case"0":
                            tableName.EntityState = Core.Common.EntityStateOption.Deleted;
                            break;
                    }

                    tableNameList.Add(tableName);
                }

                con.Close();
                return tableNameList;
            }
        }

        public bool UpdateItem(TableName item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItems(ObservableCollection<TableName> updatedItems)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(TableName item)
        {
            throw new NotImplementedException();
        }


    }
}
