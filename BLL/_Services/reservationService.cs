using BAL.Repositories;
using ZSixRestaurantAdmin._Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ZSixRestaurantAdmin.BLL._Services
{
    public class reservationService : baseService
    {
        reservationDB _service;
        public reservationService()
        {
            _service = new reservationDB();
        }

        public List<ReservationBLL> GetAll(int brandID)
        {
            try
            {
                return _service.GetAll(brandID);
            }
            catch (Exception ex)
            {
                return new List<ReservationBLL>();
            }
        }

        public RspReservationDetail GetReservation(int id, int brandID)
        {
            try
            {
                RspReservationDetail rsp = new RspReservationDetail();
                var customer = new CustomerBLL();
                var bll = new List<ReservationBLL>();
                var ds = _service.GetReservation(id, brandID);
                var _dsReservation = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0])).ToObject<List<ReservationBLL>>();
                var _dsCustomerData = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[1])).ToObject<List<CustomerBLL>>();

                foreach (var i in _dsReservation)
                {
                    bll.Add(new ReservationBLL
                    {
                        StatusID = i.StatusID,
                        LastUpdatedDate = i.LastUpdatedDate,
                        reservationID = i.reservationID,
                        CustomerID = i.CustomerID,
                        LocationID = i.LocationID,
                        ReservationDate = i.ReservationDate,
                        SittingArea = i.SittingArea,
                        NumberPerson = i.NumberPerson,
                    });
                    rsp.Reservation = bll.FirstOrDefault();
                    rsp.Customer = _dsCustomerData.Where(x => x.CustomerID == i.CustomerID).FirstOrDefault();
                }
                return rsp;
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
                return _service.GetAllBrand();
            }
            catch (Exception ex)
            {
                return new List<DeliveryBLL>();
            }
        }
        public BrandSettingsBLL GetItemSettings(int brandID)
        {
            return _service.GetItemSettings(brandID);
        }

        public DeliveryBLL Get(int id)
        {
            try
            {
                return _service.Get(id);
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
                //data.Image = UploadImage(data.Image, "Banner", _env);
                //data.LastUpdatedDate = _UTCDateTime_SA();
                var result = _service.Insert(data);

                return result;
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
                data.LastUpdatedDate = _UTCDateTime_SA();
                var result = _service.Update(data);
                //if (data.StatusID == 102)
                //{
                //    try
                //    {
                //        var ds = _service.GetToken(data.CustomerID);
                //        var getTokens = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0])).ToObject<List<PushTokenBLL>>();
                //        foreach (var item in getTokens)
                //        {
                //            var token = new PushNotificationBLL();
                //            token.Title = "Cote Rotie" + " | Reservation Update";
                //            token.Message = "Your Reservation Has Been confirmed";
                //            token.DeviceID = item.Token;
                //            _service.PushNotificationAndroid(token);
                //        }
                //    }
                //    catch (Exception)
                //    {
                //    }
                //}
                //else if (data.StatusID == 104)
                //{
                //    try
                //    {
                //        var ds = _service.GetToken(data.CustomerID);
                //        var getTokens = JArray.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0])).ToObject<List<PushTokenBLL>>();
                //        foreach (var item in getTokens)
                //        {
                //            var token = new PushNotificationBLL();
                //            token.Title = "Cote Rotie" + " | Reservation Update";
                //            token.Message = "Your Reservation Has Been Rejected";
                //            token.DeviceID = item.Token;
                //            _service.PushNotificationAndroid(token);
                //        }
                //    }
                //    catch (Exception)
                //    {
                //    }
                //}

                return result;
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
                data.LastUpdatedDate = _UTCDateTime_SA();
                var result = _service.Reject(data);

                return result;
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
                //data.LastUpdatedDate = _UTCDateTime_SA();
                var result = _service.Delete(data);

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
