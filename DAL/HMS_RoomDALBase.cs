
using System.Data;
using System.Data.Common;
using Hotel_Management_System.Areas.HMS_Room.Models;
using Hotel_Management_System.Areas.HMS_RoomCategory.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace Hotel_Management_System.DAL
{
    public class HMS_RoomDALBase : DALHelper
    {
        #region PR_HMS_Rooms_SelectAll

        public DataTable PR_HMS_Rooms_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_Rooms_SelectAll");
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

        #region PR_HMS_Rooms_Delete

        public bool? PR_HMS_Rooms_Delete(int? RoomID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_Rooms_Delete");
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, RoomID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_HMS_Rooms_Insert
        public bool? PR_HMS_Rooms_Insert(HMS_RoomModel modelHMS_Room)
        {

            try
            { 
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_Rooms_Insert");
                sqlDB.AddInParameter(dbCMD, "RoomLocation", SqlDbType.Int, modelHMS_Room.RoomLocation);
                sqlDB.AddInParameter(dbCMD, "RoomCost", SqlDbType.NVarChar, modelHMS_Room.RoomCost);
                sqlDB.AddInParameter(dbCMD, "BedSize", SqlDbType.NVarChar, modelHMS_Room.BedSize);
                sqlDB.AddInParameter(dbCMD, "RoomPhoto", SqlDbType.NVarChar, modelHMS_Room.RoomPhoto);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelHMS_Room.Description);
                sqlDB.AddInParameter(dbCMD, "RoomCategoryID", SqlDbType.Int, modelHMS_Room.RoomCategoryID);
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

        #region PR_HMS_Rooms_SelectByPK
        public DataTable PR_HMS_Rooms_SelectByPK(int? RoomID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_Rooms_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, RoomID);

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

        #region PR_HMS_Rooms_Update
        public bool? PR_HMS_Rooms_Update(HMS_RoomModel modelHMS_Room)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_Rooms_Update");
                sqlDB.AddInParameter(dbCMD, "RoomID", SqlDbType.Int, modelHMS_Room.RoomID);
                sqlDB.AddInParameter(dbCMD, "RoomLocation", SqlDbType.NVarChar, modelHMS_Room.RoomLocation);
                sqlDB.AddInParameter(dbCMD, "RoomCost", SqlDbType.NVarChar, modelHMS_Room.RoomCost);
                sqlDB.AddInParameter(dbCMD, "BedSize", SqlDbType.NVarChar, modelHMS_Room.BedSize);
                sqlDB.AddInParameter(dbCMD, "RoomPhoto", SqlDbType.NVarChar, modelHMS_Room.RoomPhoto);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelHMS_Room.Description);
                sqlDB.AddInParameter(dbCMD, "RoomCategoryID", SqlDbType.NVarChar, modelHMS_Room.RoomCategoryID);
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

        #region PR_HMS_RoomCategory_SelectComboBox
        public DataTable PR_HMS_RoomCategory_SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HMS_RoomCategory_SelectComboBox");
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


    }
}
