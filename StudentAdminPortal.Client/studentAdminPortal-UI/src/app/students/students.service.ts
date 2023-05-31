
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  private baseApiUrl = 'https://localhost:7189'

  constructor(private httpClient : HttpClient) { }

  getStudents() : Observable<any>{
    return this.httpClient.get<any>(this.baseApiUrl + '/students');
  }
}
