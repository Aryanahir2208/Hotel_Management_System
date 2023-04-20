using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management_System.Areas.HMS_RoomCategory.Models;

namespace Hotel_Management_System.DAL
{
    public class HMS_RoomCategoryDALBase : DALHelper
    {
        #region PR_HMS_RoomCategory_SelectAll

        public DataTable PR_HMS_RoomCategory_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_SelectAll");

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

        #region PR_HMS_RoomCategory_Delete

        public bool? PR_HMS_RoomCategory_Delete(int? RoomCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_Delete");
                sqlDB.AddInParameter(dbCMD, "RoomCategoryID", SqlDbType.Int, RoomCategoryID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_HMS_RoomCategory_Insert
        public bool? PR_HMS_RoomCategory_Insert(HMS_RoomCategoryModel modelHMS_RoomCategory)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_Insert");
                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, modelHMS_RoomCategory.CategoryName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelHMS_RoomCategory.Description);
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

        #region PR_HMS_RoomCategory_SelectByPK
        public DataTable PR_HMS_RoomCategory_SelectByPK(int? RoomCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "RoomCategoryID", SqlDbType.Int, RoomCategoryID);

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

        #region PR_HMS_RoomCategory_Update
        public bool? PR_HMS_RoomCategory_Update(HMS_RoomCategoryModel modelHMS_RoomCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_Update");
                sqlDB.AddInParameter(dbCMD, "RoomCategoryID", SqlDbType.Int, modelHMS_RoomCategory.RoomCategoryID);
                sqlDB.AddInParameter(dbCMD, "CategoryName", SqlDbType.NVarChar, modelHMS_RoomCategory.CategoryName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelHMS_RoomCategory.Description);
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
