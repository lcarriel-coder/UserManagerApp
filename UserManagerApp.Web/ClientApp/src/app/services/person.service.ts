import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  private apiUrl = 'https://localhost:44357/api/personaUser/register';
  private apiUrlGetAll = 'https://localhost:44357/api/PersonaUser/GetAll';


  constructor(private http: HttpClient) {}

  createPerson(personData: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, personData);
  }

  getAllPersons(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrlGetAll);
  }

}
