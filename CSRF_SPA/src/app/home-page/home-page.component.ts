import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HttpServiceService } from '../Services/http-service.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private _httpServiceService: HttpServiceService ) { }

  ngOnInit(): void {
  }

getMethodAPI(){
  this._httpServiceService.get('api/Account','GetCustomers').subscribe(response => {
    console.log(response);
  })
}

postMethodAPI(){
  this._httpServiceService.post('values', 'api/Account','PostCustomer').subscribe(response => {
    console.log(response);
  })
}
}
