import { Component, OnInit } from '@angular/core';
import { Customer, MainService, Order, Product } from 'src/app/services/main.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  shipMode: string[] = ["Second Class", "Standard Class", "First Class", "Overnight Express"];
  orders: Order[] = [];
  customers: Customer[] = [];
  products: Product[] = [];
  createCustID: string = "";
  createProdID: string = "";
  createOrderDate: Date = new Date(2022, 6, 27);
  createShipDate: Date = new Date(2022, 6, 27);
  createQuantity: number = 1;
  createShipMode: string = this.shipMode[0];


  constructor(private _mainService: MainService) { }

  ngOnInit(): void {
    this.fetchData();

  }
  onChange(event: any) {

  }
  shippingChange(event: any) {
    console.log(event);

  }
  test() {
    console.log(this.createCustID);
    console.log(this.createProdID);
    console.log(this.createOrderDate.toJSON());
    console.log(this.createShipDate.toJSON());
    console.log(this.createQuantity);
    console.log(this.createShipMode);
  }
  createOrder() {
    this._mainService.createOrder(this.createCustID, this.createProdID, this.createQuantity, this.createOrderDate, this.createShipDate, this.createShipMode).subscribe(null, null, () => {
      this.fetchData();
    });
  }
  fetchData() {
    this._mainService.getAllOrders().subscribe(data => this.orders = data);
    this._mainService.getAllCustomers().subscribe(data => this.customers = data, null, () => {
      this.createCustID = this.customers[0].custID;
    });
    this._mainService.getAllProducts().subscribe(data => this.products = data, null, () => {
      this.createProdID = this.products[0].prodID;
    });
  }
}
