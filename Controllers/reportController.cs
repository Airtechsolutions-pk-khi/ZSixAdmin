﻿
using System;
using System.Collections.Generic;
using ZSixRestaurantAdmin._Models;
using ZSixRestaurantAdmin.BLL._Services;
using Microsoft.AspNetCore.Mvc;

namespace ZSixRestaurantAdmin.Controllers
{
    [Route("api/[controller]")]

    public class reportController : ControllerBase
    {
        reportService _service;
        public reportController()
        {
            _service = new reportService();
        }

        [HttpGet("summary/{brandid}/{fromDate}/{toDate}")]
        public List<salesSummarytBLL> GetSummaryRpt(int brandid, string fromDate, string toDate)
        {
            return _service.GetSalesSummaryRpt(brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }

        [HttpGet("salesdetail/{brandid}/{locationid}/{fromDate}/{toDate}")]
        public List<SalesDetailBLL> GetSalesDetail(int brandid, string locationid, string fromDate, string toDate)
        {
            return _service.GetSalesDetailRpt(locationid,brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }

        [HttpGet("salesitemwise/{brandid}/{locationid}/{fromDate}/{toDate}")]
        public List<SalesItemwiseBLL> GetSalesItemwise(int brandid, string locationid, string fromDate, string toDate)
        {
            return _service.GetSalesItemwiseRpt(locationid, brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }

        [HttpGet("salescategorywise/{brandid}/{locationid}/{fromDate}/{toDate}")]
        public List<SalesCategorywiseBLL> GetSalesCategorywise(int brandid, string locationid, string fromDate, string toDate)
        {
            return _service.GetSalesCategorywiseRpt(locationid, brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }

        [HttpGet("salesuserwise/{brandid}/{locationid}/{fromDate}/{toDate}")]
        public List<SalesUserwiseBLL> GetSalesuserwise(int brandid, string locationid, string fromDate, string toDate)
        {
            return _service.GetSalesUserwiseRpt(locationid, brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }

        [HttpGet("salescustomerwise/{brandid}/{locationid}/{customerid}/{fromDate}/{toDate}")]
        public List<SalesCustomerwiseBLL> GetSalesCustomerwise(int brandid, string locationid, int customerid, string fromDate, string toDate)
        {
            return _service.GetSalesCustomerwiseRpt(locationid, brandid, customerid,Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }
        [HttpGet("reservationdetail/{brandid}/{locationid}/{fromDate}/{toDate}")]
        public List<ReservationDetailBLL> GetReservationDetailBLLs(int brandid, string locationid, string fromDate, string toDate)
        {
            return _service.GetReservationDetailRpt(brandid, locationid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }
        [HttpGet("deliveryboydetail/{brandid}/{fromDate}/{toDate}")]
        public List<DeliveryBoyDetailBLL> GetDeliveryBoyDetailRpt(int brandid, string fromDate, string toDate)
        {
            return _service.GetDeliveryBoyDetailRpt(brandid, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }
        [HttpGet("orderreportbytype/{brandId}/{orderType}/{locationId}/{fromDate}/{toDate}")]
        public List<OrdersBLL> OrderReportByType(int brandId, int orderType, int locationId, string fromDate, string toDate)
        {
            return _service.OrderReportByType(brandId, orderType, locationId, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
        }
    }
}
