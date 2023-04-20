using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Hotel_Management_System.Areas.HMS_RoomBooking.Models;

namespace Hotel_Management_System.DAL
{
    public class HMS_RoomBookingDALBase : DALHelper
    {
        #region PR_HMS_RoomBooking_SelectAll

        public DataTable PR_HMS_RoomBooking_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomBooking_SelectAll");
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

        #region PR_HMS_RoomBooking_Delete

        public bool? PR_HMS_RoomBooking_Delete(int? RoomBookingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomBooking_Delete");
                sqlDB.AddInParameter(dbCMD, "RoomBookingID", SqlDbType.Int, RoomBookingID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_HMS_RoomBooking_Insert
        public bool? PR_HMS_RoomBooking_Insert(HMS_RoomBookingModel modelHMS_RoomBooking)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomBooking_Insert");
                sqlDB.AddInParameter(dbCMD, "PrefixID", SqlDbType.Int, modelHMS_RoomBooking.PrefixID);
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.NVarChar, modelHMS_RoomBooking.FirstName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.NVarChar, modelHMS_RoomBooking.LastName);
                sqlDB.AddInParameter(dbCMD, "PhoneNumber", SqlDbType.NVarChar, modelHMS_RoomBooking.PhoneNumber);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelHMS_RoomBooking.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelHMS_RoomBooking.StateID);
                sqlDB.AddInParameter(dbCMD, "PinCode", SqlDbType.NVarChar, modelHMS_RoomBooking.PinCode);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelHMS_RoomBooking.Address);
                sqlDB.AddInParameter(dbCMD, "TotalPrice", SqlDbType.Decimal, modelHMS_RoomBooking.TotalPrice);
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

        #region PR_HMS_RoomBooking_SelectByPK
        public DataTable PR_HMS_RoomBooking_SelectByPK(int? RoomBookingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomBooking_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "RoomBookingID", SqlDbType.Int, RoomBookingID);

              

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

        #region PR_HMS_RoomBooking_Update
        public bool? PR_HMS_RoomBooking_Update(HMS_RoomBookingModel modelHMS_RoomBooking)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomBooking_Update");
                sqlDB.AddInParameter(dbCMD, "RoomBookingID", SqlDbType.Int, modelHMS_RoomBooking.RoomBookingID);
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.NVarChar, modelHMS_RoomBooking.FirstName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.NVarChar, modelHMS_RoomBooking.LastName);
                sqlDB.AddInParameter(dbCMD, "PhoneNumber", SqlDbType.NVarChar, modelHMS_RoomBooking.PhoneNumber);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelHMS_RoomBooking.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelHMS_RoomBooking.StateID);
                sqlDB.AddInParameter(dbCMD, "PinCode", SqlDbType.NVarChar, modelHMS_RoomBooking.PinCode);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelHMS_RoomBooking.Address);
                sqlDB.AddInParameter(dbCMD, "TotalPrice", SqlDbType.Decimal, modelHMS_RoomBooking.TotalPrice);
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
