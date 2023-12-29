import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SummaryReport, SalesdetailReport, SalescategorywiseReport, SalescustomerwiseReport, SalesitemwiseReport } from '../_models/Report';
import { Observable } from 'rxjs';
;

@Injectable({
  providedIn: 'root'
})

export class ReportService {

  constructor(private http: HttpClient) {
  }


  SalesSummaryRpt(brandID,fromDate,toDate) {
    return this.http.get<SummaryReport[]>(`api/report/summary/${brandID}/${fromDate}/${toDate}`);
  }

  SalesDetailRpt(brandID,locationID,fromDate,toDate) {
    return this.http.get<SalesdetailReport[]>(`api/report/salesdetail/${brandID}/${locationID}/${fromDate}/${toDate}`);
  }

  SalesItemwiseRpt(brandID,locationID,fromDate,toDate) {
    return this.http.get<SalesitemwiseReport[]>(`api/report/salesitemwise/${brandID}/${locationID}/${fromDate}/${toDate}`);
  }

  SalesCategorywiseRpt(brandID,locationID,fromDate,toDate) {
    return this.http.get<SalescategorywiseReport[]>(`api/report/salescategorywise/${brandID}/${locationID}/${fromDate}/${toDate}`);
  }

  SalesCustomerwiseRpt(brandID,locationID,customerID,fromDate,toDate) {
    return this.http.get<SalescustomerwiseReport[]>(`api/report/salescustomerwise/${brandID}/${locationID}/${customerID}/${fromDate}/${toDate}`);
  }

  SalesUserwiseRpt(brandID,locationID,fromDate,toDate) {
    return this.http.get<SalesdetailReport[]>(`api/report/salesuserwise/${brandID}/${locationID}/${fromDate}/${toDate}`);
  }
  
  loadLocations(brandId) {
    return this.http.get<Location[]>(`api/location/all/${brandId}`);
  }

}
