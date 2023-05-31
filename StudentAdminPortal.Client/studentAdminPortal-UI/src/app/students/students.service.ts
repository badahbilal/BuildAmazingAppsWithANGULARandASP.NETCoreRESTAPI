
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../Models/api-models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  private baseApiUrl = 'https://localhost:7189/api'

  constructor(private httpClient : HttpClient) { }

  getStudents() : Observable<Student[]>{
    return this.httpClient.get<Student[]>(this.baseApiUrl + '/students');
  }
}
