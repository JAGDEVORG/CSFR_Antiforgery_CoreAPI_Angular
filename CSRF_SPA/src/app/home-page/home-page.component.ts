import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HttpServiceService } from '../Services/http-service.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  getResponse: string = "";
  postResponse: string = "";
  customerName: string = '';
  customerAddress: string = '';
  constructor(private _httpServiceService: HttpServiceService) { }

  ngOnInit(): void {
  }

  getMethodAPI() {
    this._httpServiceService.get('api/Account', 'GetCustomers').subscribe(response => {
      this.getResponse = response.content;
      console.log(response);
    })
  }

  postMethodAPI() {
    if (this.customerName != '') {
      this._httpServiceService.post(this.customerName, 'api/Account', 'PostCustomer').subscribe(response => {
        this.postResponse = response.content;
        this.customerName = '';
        console.log(response);
      })
    } else {
      this.postResponse = 'Please enter the customer name.'
    }
  }
}
