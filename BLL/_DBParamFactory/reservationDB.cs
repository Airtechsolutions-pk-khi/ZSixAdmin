using ZSixRestaurantAdmin._Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebAPICode.Helpers;

namespace BAL.Repositories
{

    public class reservationDB : baseDB
    {
        public static ReservationBLL repo;
        public static DataTable _dt;
        public static DataSet _ds;
        public reservationDB()
           : base()
        {
            repo = new ReservationBLL();
            _dt = new DataTable();
            _ds = new DataSet();
        }

        public List<ReservationBLL> GetAll(int brandID)
        {
            try
            {
                var lst = new List<ReservationBLL>();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@brandid", brandID);

                _dt = (new DBHelper().GetTableFromSP)("sp_GetReservation", p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<ReservationBLL>>().ToList();
                        //lst = _dt.DataTableToList<ReservationBLL>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetReservation(int id, int brandID)
        {
            try
            {
                var _obj = new OrdersBLL();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@ReservationID", id);
                //p[1] = new SqlParameter("@brandid", brandID);

                _ds = (new DBHelper().GetDatasetFromSP)("sp_GetReservationbyID_Admin", p);

                return _ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<DeliveryBLL> GetAllBrand()
        {
            try
            {
                var lst = new List<DeliveryBLL>();
                SqlParameter[] p = new SqlParameter[1];
                //p[0] = new SqlParameter("@brandid", brandID);

                _dt = (new DBHelper().GetTableFromSP)("sp_getAllBrand", p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        lst = _dt.DataTableToList<DeliveryBLL>();
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public BrandSettingsBLL GetItemSettings(int brandID)
        {
            try
            {
                var _obj = new BrandSettingsBLL();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@brandid", brandID);

                _dt = (new DBHelper().GetTableFromSP)("sp_GetBrandSettings_Admin", p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        _obj = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(_dt)).ToObject<List<BrandSettingsBLL>>().FirstOrDefault();
                        _obj.BrandID = brandID;
                    }
                }
                return _obj;
            }
            catch (Exception ex)
            {
                return new BrandSettingsBLL();
            }
        }
        public DeliveryBLL Get(int id)
        {
            try
            {
                var _obj = new DeliveryBLL();
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@id", id);
                //p[1] = new SqlParameter("@brandid", brandID);

                _dt = (new DBHelper().GetTableFromSP)("sp_GetDeliverybyID_Admin", p);
                if (_dt != null)
                {
                    if (_dt.Rows.Count > 0)
                    {
                        _obj = _dt.DataTableToList<DeliveryBLL>().FirstOrDefault();
                    }
                }
                return _obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       
        public int Insert(DeliveryBLL data)
        {
            try
            {
                int rtn = 0;
                SqlParameter[] p = new SqlParameter[4];

                p[0] = new SqlParameter("@Name", data.Name);                              
                p[1] = new SqlParameter("@Amount", data.Amount);
                p[2] = new SqlParameter("@StatusID", data.StatusID);
                p[3] = new SqlParameter("@DeliveryAreaID", data.DeliveryAreaID);               

                //rtn = (new DBHelper().ExecuteNonQueryReturn)("dbo.sp_insertDelivery_Admin", p);
                rtn = int.Parse(new DBHelper().GetTableFromSP("dbo.sp_insertDelivery_Admin", p).Rows[0]["DeliveryAreaID"].ToString());

                if (data.brands != "" && data.brands != null)
                {
                    SqlParameter[] p1 = new SqlParameter[2];
                    p1[0] = new SqlParameter("@DeliveryAreaID", rtn);
                    p1[1] = new SqlParameter("@BrandIDs", data.brands);
                    (new DBHelper().ExecuteNonQueryReturn)("sp_insertBrandDelivery_Admin", p1);
                }
                return rtn;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
       
        public int Update(ReservationBLL data)
        {
            try
            {
                int rtn = 0;
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@ReservationID", data.reservationID);               
                p[1] = new SqlParameter("@StatusID", 102);
                                
                rtn = (new DBHelper().ExecuteNonQueryReturn)("dbo.sp_updateReservation_Admin", p);
                
                
                return rtn;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Reject(ReservationBLL data)
        {
            try
            {
                int rtn = 0;
                SqlParameter[] p = new SqlParameter[2];

                p[0] = new SqlParameter("@ReservationID", data.reservationID);
                p[1] = new SqlParameter("@StatusID", 104);

                rtn = (new DBHelper().ExecuteNonQueryReturn)("dbo.sp_updateReservation_Admin", p);


                return rtn;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Delete(DeliveryBLL data)
        {
            try
            {
                int _obj = 0;
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@id", data.DeliveryAreaID);
                
                _obj = (new DBHelper().ExecuteNonQueryReturn)("sp_DeleteDelivery", p);

                return _obj;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
