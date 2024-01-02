import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { LocalStorageService } from 'src/app/_services/local-storage.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation, Customers } from 'src/app/_models/Reservation';
import { ToastService } from 'src/app/_services/toastservice';
import { Location } from 'src/app/_models/Location';
import { ReservationService } from 'src/app/_services/reservation.service';
@Component({
  selector: 'app-reservationdetails',
  templateUrl: './reservationdetails.component.html',
  providers: []
})

export class ReservationdetailsComponent implements OnInit {
  public reservations = new Reservation();
  public customers = new Customers();
  private selectedBrand;
  Locations: Location[] = [];
  selectedLocations = [];
  DeliveryBoys = [];
  deliveryboyfororder = 0;
  st;
  locationID = 0;
  data$: Observable<Reservation[]>;
  oldData: Reservation[];
  total$: Observable<number>;
  loading$: Observable<boolean>;
  locationSubscription: Subscription;
  constructor(public service: ReservationService,
    public ls: LocalStorageService,
    public ts: ToastService,
    public router: Router,
    private route: ActivatedRoute) {
    debugger
    this.selectedBrand = this.ls.getSelectedBrand().brandID;
  }

  ngOnInit() {
    this.setSelectedOrder();
    this.getData();
  }

  getData() {
    this.service.getAllData(this.selectedBrand);
    this.data$ = this.service.data$;
    this.total$ = this.service.total$;
    this.loading$ = this.service.loading$;
  }
  setSelectedOrder() {
    this.route.paramMap.subscribe(param => {
      const sid = +param.get('id');
      if (sid) {
        this.service.getById(sid, this.selectedBrand).subscribe(res => {
          //Set Forms
          debugger
          this.editForm(res);
        });
      }
    })
  }
  updateOrder(reservation, status) {
    debugger;
    reservation.statusID = status;
    //Update customer
    this.service.update(reservation).subscribe(data => {

      if (data != 0) {
        this.ts.showSuccess("Success", "Record updated successfully.")
        this.router.navigate(['/admin/reservation']);
      }
    }, error => {
      this.ts.showError("Error", "Failed to update record.")
    });
  }
  private editForm(obj) {
    debugger
    this.reservations = obj.reservation;
    this.customers = obj.customer;
    this.st = obj.reservation.statusID;

  }
  Update(obj) {
    debugger
    this.service.update(obj).subscribe((res: any) => {
      if (res != 0) {
        this.ts.showSuccess("Success", "Status Changed successfully.")
        this.getData();
        this.router.navigate(['/admin/reservation']);
      }
      else
        this.ts.showError("Error", "Failed to Change Status.")

    }, error => {
      this.ts.showError("Error", "Failed to Change Status.")
    });
  }
  Reject(obj) {
    this.service.reject(obj).subscribe((res: any) => {
      if (res != 0) {
        this.ts.showSuccess("Success", "Status Changed successfully.")
        this.getData();
        this.router.navigate(['/admin/reservation']);
      }
      else
        this.ts.showError("Error", "Failed to Change Status.")

    }, error => {
      this.ts.showError("Error", "Failed to Change Status.")
    });
  }
}
