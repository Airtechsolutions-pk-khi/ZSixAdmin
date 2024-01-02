export class Reservation {
  reservationID: number;
  brandID: number;
  fullName: string;
  mobileNumber: string;  
  numberPerson: number;
  reservationDate: string;
  sittingArea: string;
  statusID: number;
}
export class Customers {
  customerID: number;
  fullName: string;
  email: string;
  mobile: string;
  password: string;
  image: string;
  locationID: number;
  brandID: number;
  statusID: number;
}
