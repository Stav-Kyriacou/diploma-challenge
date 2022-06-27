import { Component, OnInit } from '@angular/core';
import { Customer, EditOrder, MainService, Order, Product } from 'src/app/services/main.service';

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

  //Create Order Variables
  createCustID: string = "";
  createProdID: string = "";
  createOrderDate: Date = new Date(2022, 6, 27);
  createShipDate: Date = new Date(2022, 6, 27);
  createQuantity: number = 1;
  createShipMode: string = this.shipMode[0];

  //Edit Order Variables
  currentOrder: EditOrder = new EditOrder();
  // editOrderID: number;
  // editCustID: string;
  // editProdID: string;
  editOrderDate: Date = new Date(2022, 6, 27);
  editShipDate: Date = new Date(2022, 6, 27);
  // editQuantity: number;
  // editShipMode: string = this.shipMode[0];


  constructor(private _mainService: MainService) {
    this.currentOrder.quantity = 1;
    this.currentOrder.shipMode = this.shipMode[0];
    this.currentOrder.orderDate = new Date(2022, 6, 27);
    this.currentOrder.shipDate = new Date(2022, 6, 27);
  }

  ngOnInit(): void {
    this.fetchData();

  }
  onChange(event: any) {

  }
  shippingChange(event: any) {
    console.log(event);
  }
  test() {
    console.log(this.currentOrder);

  }
  createOrder() {
    this._mainService.createOrder(this.createCustID, this.createProdID, this.createQuantity, this.createOrderDate, this.createShipDate, this.createShipMode).subscribe(null, null, () => {
      this.fetchData();
    });
  }
  editOrder() {
    this.currentOrder.orderDate = this.currentOrder.orderDate;
    this._mainService.editOrder(this.currentOrder).subscribe(null, null, ()=> {
      this.fetchData();
    });
  }
  fetchData() {
    this._mainService.getAllOrders().subscribe(data => this.orders = data, null, () => {
      this.currentOrder.orderID = this.orders[0].orderID;
    });
    this._mainService.getAllCustomers().subscribe(data => this.customers = data, null, () => {
      this.createCustID = this.customers[0].custID;
      this.currentOrder.custID = this.customers[0].custID;
    });
    this._mainService.getAllProducts().subscribe(data => this.products = data, null, () => {
      this.createProdID = this.products[0].prodID;
      this.currentOrder.prodID = this.products[0].prodID;
    });
  }
}
