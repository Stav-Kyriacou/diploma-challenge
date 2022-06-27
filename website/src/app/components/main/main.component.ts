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
  creatingOrder: boolean = false;
  createCustID: string = "";
  createProdID: string = "";
  createOrderDate: Date = new Date(2022, 6, 27);
  createShipDate: Date = new Date(2022, 6, 27);
  createQuantity: number = 1;
  createShipMode: string = this.shipMode[0];

  //Edit Order Variables
  editingOrder: boolean = false;
  currentOrder: EditOrder = new EditOrder();

  //Delete Order Variables
  deletingOrder: boolean = false;
  deleteOrderID: number;


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
    this.creatingOrder = true;
    this._mainService.createOrder(this.createCustID, this.createProdID, this.createQuantity, this.createOrderDate, this.createShipDate, this.createShipMode).subscribe(null, null, () => {
      this.fetchData();
      this.creatingOrder = false;
    });
  }
  editOrder() {
    this.editingOrder = true;
    this.currentOrder.orderDate = this.currentOrder.orderDate;
    this._mainService.updateOrder(this.currentOrder).subscribe(null, null, () => {
      this.fetchData();
      this.editingOrder = false;
    });
  }
  deleteOrder() {
    this.deletingOrder = true;
    this._mainService.deleteOrder(this.deleteOrderID).subscribe(null, null, () => {
      this.fetchData();
      this.deletingOrder = false;
    });
  }
  fetchData() {
    this._mainService.getAllOrders().subscribe(data => this.orders = data, null, () => {
      this.orders.reverse();
      this.currentOrder.orderID = this.orders[0].orderID;
      this.deleteOrderID = this.orders[0].orderID;
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
