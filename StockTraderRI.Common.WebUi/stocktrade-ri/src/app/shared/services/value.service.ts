import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ValueService {

  constructor(private httpClient: HttpClient) { }

  getValues() {

    // TODO: call this /api/makes is endpoint --> head of the meth in controller
    const values = this.httpClient.get<any[]>('/api/values');
    return values;
  }

}
