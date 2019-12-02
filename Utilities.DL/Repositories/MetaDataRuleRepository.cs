using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilities.BL.Models;
using Utilities.DL.EventArguments;
using Utilities.DL.Properties;


namespace Utilities.DL.Repositories
{
    public class MetaDataRuleRepository : IRepository<MetaDataRule>
    {

        #region Fields

        //readonly List<MetaDataRule> _metaDataRules;
        public readonly ObservableCollection<MetaDataRule> metaDataRules;

        #endregion // Fields

        #region Constructor
        /// <summary>
        /// Create a new repository of meta data rules.
        /// </summary>
        public MetaDataRuleRepository()
        {
            metaDataRules = GetItems();
        }

        #endregion // Constructor
        
        #region Public Interface

        /// <summary>
        /// Raised when a metadatarule is placed into the repository.
        /// </summary>
        public event EventHandler<MetaDataRuleAddedEventArgs> MetaDataRuleAdded;

        public event EventHandler<MetaDataRuleUpdatedEventArgs> MetaDataRuleUpdated;

        public event EventHandler<MetaDataRuleDeletedEventArgs> MetaDataRuleDeleted;
        
        /// <summary>
        /// Saves/updates a MetaDataRule item to the database.
        /// If the MetaDataRule already exists in the repository
        /// it is updated and no exception is thrown.
        /// </summary>
        /// <param name="metaDataRule"></param>
        /// <returns></returns>
        public bool Save(MetaDataRule metaDataRule)
        {
            var success = false;

            if (metaDataRule == null)
                throw new ArgumentNullException("metaDataRule");

            if (metaDataRule.Validate())
            {
                if (!ContainsMetaDataRule(metaDataRule))
                {
                    metaDataRule.MetaDataRuleID = AddItem(metaDataRule);
                    success = metaDataRule.MetaDataRuleID > 0;

                    // If addition is successful update the internal metaDataRules shallow copy list
                    if (success && metaDataRules != null)
                        AddToMetaDataRulesList(metaDataRule);
                    
                    // If addition is successful fire the metaDataRuleAdded event for any subscribers.
                    if (success && MetaDataRuleAdded != null)
                        MetaDataRuleAdded(this, new MetaDataRuleAddedEventArgs(metaDataRule));
                }
                else
                {
                    success = UpdateItem(metaDataRule);   
                    
                    // If update is successful fire the metaDataRuleUpdated event.
                    if (success && MetaDataRuleUpdated != null)
                        MetaDataRuleUpdated(this, new MetaDataRuleUpdatedEventArgs(metaDataRule));
                }
            }
            return success;
        }

        public int AddItem(MetaDataRule metaDataRule)
        {
            // SQL Stored procedure call to Save the new Meta data rule record.
            SqlConnection con = new SqlConnection(Strings_DL.ConnectionString_UPSINextGenStaging);
            con.Open();

            Int32 newId = 0;
            using (SqlCommand cmd = new SqlCommand("meta.insertMetaDataRule", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter tablename = new SqlParameter("@tablename", SqlDbType.VarChar);
                    SqlParameter fieldname = new SqlParameter("@fieldname", SqlDbType.VarChar);
                    SqlParameter oldvalue = new SqlParameter("@oldvalue", SqlDbType.VarChar);
                    SqlParameter newvalue = new SqlParameter("@newvalue", SqlDbType.VarChar);
                    SqlParameter isdeleted = new SqlParameter("@isdeleted", SqlDbType.Bit);

                    tablename.Value = metaDataRule.TableName;
                    fieldname.Value = metaDataRule.FieldName;
                    oldvalue.Value = metaDataRule.OldValue;
                    newvalue.Value = metaDataRule.NewValue;
                    isdeleted.Value = metaDataRule.IsDeleted;

                    cmd.Parameters.Add(tablename);
                    cmd.Parameters.Add(fieldname);
                    cmd.Parameters.Add(oldvalue);
                    cmd.Parameters.Add(newvalue);
                    cmd.Parameters.Add(isdeleted);
                    
                    newId = (Int32)cmd.ExecuteScalar();
                    con.Close();
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
            return (int)newId;
        }

        public bool UpdateItem(MetaDataRule metaDataRule)
        {
            SqlConnection con = new SqlConnection(Strings_DL.ConnectionString_UPSINextGenStaging);
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.updateMetaDataRule", con))
            {
                try
                {
                    int recordsUpdated = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter metadataruleid = new SqlParameter("@metadataruleid", SqlDbType.Int);
                    SqlParameter newvalue = new SqlParameter("@newvalue", SqlDbType.VarChar);
                    SqlParameter isdeleted = new SqlParameter("@isdeleted", SqlDbType.Bit);

                    metadataruleid.Value = metaDataRule.MetaDataRuleID;
                    newvalue.Value = metaDataRule.NewValue;
                    isdeleted.Value = metaDataRule.IsDeleted;

                    cmd.Parameters.Add(metadataruleid);
                    cmd.Parameters.Add(newvalue);
                    cmd.Parameters.Add(isdeleted);

                    recordsUpdated = cmd.ExecuteNonQuery();
                    con.Close();

                    return recordsUpdated > 0;
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

        public bool UpdateItems(ObservableCollection<MetaDataRule> updatedItems)
        {
            throw new NotImplementedException();
        }

        public MetaDataRule GetItem(int key)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<MetaDataRule> GetItems(bool includeDeleted=false)
        {
            string sprocToRun = "meta.GetMetaDataRules";
            if (includeDeleted)
                sprocToRun = "meta.GetAllMetaDataRules";

            SqlConnection con = new SqlConnection(Strings_DL.ConnectionString_UPSINextGenStaging);
            con.Open();

            using (SqlCommand cmd = new SqlCommand(sprocToRun, con))
            {
                ObservableCollection<MetaDataRule> metaDataRules = new ObservableCollection<MetaDataRule>();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MetaDataRule metaDataRule = MetaDataRule.CreateMetaDataRule(
                            reader.GetInt32(reader.GetOrdinal("MetaDataRuleID")),
                            reader["TableName"].ToString(),
                            reader["FieldName"].ToString(),
                            reader["OldValue"].ToString(),
                            reader["NewValue"].ToString(),
                            reader.GetBoolean(5)                                                  
                        );

                    metaDataRules.Add(metaDataRule);
                }

                con.Close();
                return metaDataRules;
            }
        }

        /// <summary>
        /// Returns a shallow-copied list of all metadatarules in the repository.
        /// Following DemoApp, may not need.  Use GetItems() instead for ObservableCollection.
        /// Not sure yet.
        /// </summary>
        /// <returns></returns>
        public List<MetaDataRule> GetMetaDataRulesList()
        {
            return new List<MetaDataRule>(metaDataRules);
        }
        
        public bool DeleteItem(MetaDataRule metaDataRule)
        {
            SqlConnection con = new SqlConnection(Strings_DL.ConnectionString_UPSINextGenStaging);
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.DeleteMetaDataRuleByID", con))
            {
                try
                {
                    int recordsDeleted = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter metaDataRuleID = new SqlParameter("@metaDataRuleID", SqlDbType.Int);
                    metaDataRuleID.Value = metaDataRule.MetaDataRuleID;

                    cmd.Parameters.Add(metaDataRuleID);

                    recordsDeleted = cmd.ExecuteNonQuery();
                    con.Close();

                    // If deletion is successful remove the metaDataRule from internal metadatarulelist.
                    if (recordsDeleted > 0)
                        metaDataRules.Remove(metaDataRule);

                    // If deletion is successful fire the metaDataRuleDeleted event for any subscribers.
                    if (recordsDeleted > 0 && MetaDataRuleDeleted != null)
                        MetaDataRuleDeleted(this, new MetaDataRuleDeletedEventArgs(metaDataRule));

                    return recordsDeleted > 0;
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
        
        /// <summary>
        /// Places the specified meta data rule into the repository.
        /// If the meta data rule is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        /// <param name="metaDataRule"></param>
        public void AddToMetaDataRulesList(MetaDataRule metaDataRule)
        {
            if (metaDataRule == null)
                throw new ArgumentNullException("metaDataRule");

            if (!metaDataRules.Contains(metaDataRule))
            {
                metaDataRules.Add(metaDataRule);
            }
        }
        
        public bool ContainsMetaDataRule(MetaDataRule metaDataRule)
        {
            if (metaDataRule == null)
                throw new ArgumentNullException("metaDataRule");

            return metaDataRules.Contains(metaDataRule);
        }
      
        #endregion // Public Interface

        #region Private Helpers

        private List<MetaDataRule> LoadMetaDataRules()
        {
            // Just testing here to follow demo app exactly.  May change to use the GetItems() method above 
            // after I prove what this is doing.  Jan 2, 2016

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UPSINextGenConnection"].ToString());
            con.Open();

            using (SqlCommand cmd = new SqlCommand("meta.GetMetaDataRules", con))
            {
                var reader = cmd.ExecuteReader();

                List<MetaDataRule> metaDataRuleList = new List<MetaDataRule>();

                //MetaDataRule metaDataRule = MetaDataRule.CreateNewMetaDataRule();

                while (reader.Read())
                {

                    MetaDataRule metaDataRule = MetaDataRule.CreateMetaDataRule(
                            reader.GetInt32(reader.GetOrdinal("MetaDataRuleID")),
                            reader["TableName"].ToString(),
                            reader["FieldName"].ToString(),
                            reader["OldValue"].ToString(),
                            reader["NewValue"].ToString(),
                            reader.GetBoolean(5)
                        );

                    metaDataRuleList.Add(metaDataRule);
                }
                con.Close();
                return metaDataRuleList;
            }

        }

        #endregion // Private Helpers
    }
}
