import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  readonly baseUrl: string = "https://localhost:5001";
  // readonly baseUrl: string = "https://101610510-challenge-api.azurewebsites.net";

    constructor(private _http: HttpClient) { }

}
