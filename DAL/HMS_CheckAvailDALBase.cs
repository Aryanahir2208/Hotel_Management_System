using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management_System.Areas.HMS_CheckAvail.Models;

namespace Hotel_Management_System.DAL
{
    public class HMS_CheckAvailDALBase : DALHelper
    {
        #region PR_HMS_CheckAvail_SelectAll

        public DataTable PR_HMS_CheckAvail_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_CheckAvail_SelectAll");
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
        

        #region SelectCheckAvailID

        public DataTable SelectCheckAvailID(HMS_CheckAvailModel modelHMS_CheckAvail)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("HMS_CheckAvail_SelectAllTop1");

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


        #region PR_HMS_CheckAvail_SelectAllData

        public DataTable PR_HMS_CheckAvail_SelectAllData(int? CheckAvailID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("HMS_CheckAvail_SelectAllData");
                sqlDB.AddInParameter(dbCMD, "CheckAvailID", SqlDbType.Int, CheckAvailID);


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


        #region PR_HMS_CheckAvail_Delete

        public bool? PR_HMS_CheckAvail_Delete(int? CheckAvailID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_CheckAvail_Delete");
                sqlDB.AddInParameter(dbCMD, "CheckAvailID", SqlDbType.Int, CheckAvailID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region PR_HMS_CheckAvail_Insert
        public bool? PR_HMS_CheckAvail_Insert(HMS_CheckAvailModel modelHMS_CheckAvail, int? RoomCategoryID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_CheckAvail_Insert");
                sqlDB.AddInParameter(dbCMD, "CheckIn", SqlDbType.DateTime, modelHMS_CheckAvail.CheckIn);
                sqlDB.AddInParameter(dbCMD, "CheckOut", SqlDbType.DateTime, modelHMS_CheckAvail.CheckOut);
                sqlDB.AddInParameter(dbCMD, "TotalAdults", SqlDbType.Int, modelHMS_CheckAvail.TotalAdults);
                sqlDB.AddInParameter(dbCMD, "TotalChilds", SqlDbType.Int, modelHMS_CheckAvail.TotalChilds);
                sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
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


        #region PR_HMS_CheckAvail_SelectByPK
        public DataTable PR_HMS_CheckAvail_SelectByPK(int? CheckAvailID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_CheckAvail_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CheckAvailID", SqlDbType.Int, CheckAvailID);
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


        #region PR_HMS_CheckAvail_Update
        public bool? PR_HMS_CheckAvail_Update(HMS_CheckAvailModel modelHMS_CheckAvail)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_CheckAvail_Update");
                sqlDB.AddInParameter(dbCMD, "CheckAvailID", SqlDbType.Int, modelHMS_CheckAvail.CheckAvailID);
                sqlDB.AddInParameter(dbCMD, "CheckIn", SqlDbType.DateTime, modelHMS_CheckAvail.CheckIn);
                sqlDB.AddInParameter(dbCMD, "CheckOut", SqlDbType.DateTime, modelHMS_CheckAvail.CheckOut);
                sqlDB.AddInParameter(dbCMD, "TotalAdults", SqlDbType.Int, modelHMS_CheckAvail.TotalAdults);
                sqlDB.AddInParameter(dbCMD, "TotalChilds", SqlDbType.Int, modelHMS_CheckAvail.TotalChilds);
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, modelHMS_CheckAvail.RoomID);
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
