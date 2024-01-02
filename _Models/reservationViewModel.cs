using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZSixRestaurantAdmin._Models
{
    public class reservationViewModel
    {
    }

    public class ReservationBLL
    {
        public int reservationID { get; set; }
        
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public int? NumberPerson { get; set; }
        public DateTime? ReservationDate { get; set; }
        public string SittingArea { get; set; }
        public int StatusID { get; set; }
        public int? BrandID { get; set; }   
        public int? LocationID { get; set; }   
        public int CustomerID { get; set; }   
        public DateTime? LastUpdatedDate { get; set; }

    }

    public class RspReservationDetail
    {
        public CustomerBLL Customer { get; set; }
        public ReservationBLL Reservation { get; set; }
    }

}
