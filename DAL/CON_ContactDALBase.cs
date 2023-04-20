using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management_System.Areas.CON_Contact.Models;

namespace Hotel_Management_System.DAL
{
    public class CON_ContactDALBase : DALHelper
    {
        #region PR_CON_Contact_SelectAll

        public DataTable PR_CON_Contact_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CON_Contact_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_CON_Contact_Delete

        public bool? PR_CON_Contact_Delete(int? ContactID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CON_Contact_Delete");
                sqlDB.AddInParameter(dbCMD, "ContactID", SqlDbType.Int, ContactID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_CON_Contact_Insert
        public bool? PR_CON_Contact_Insert(CON_ContactModel modelCON_Contact)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CON_Contact_Insert");
                sqlDB.AddInParameter(dbCMD, "ContactName", SqlDbType.NVarChar, modelCON_Contact.ContactName);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCON_Contact.Email);
                sqlDB.AddInParameter(dbCMD, "Subject", SqlDbType.NVarChar, modelCON_Contact.Subject);
                sqlDB.AddInParameter(dbCMD, "Message", SqlDbType.NVarChar, modelCON_Contact.Message);
                sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

      
    }
}
