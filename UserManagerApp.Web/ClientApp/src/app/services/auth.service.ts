import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:44357/api/account/login';
  private loggedIn = false;
  private userName: string | null = null;

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const loginDto = { username, password };
    return this.http.post<any>(this.apiUrl, loginDto).pipe(
      catchError((error) => {
        throw error;
      })
    );
  }

  setUserName(name: string) {
    this.userName = name;
    localStorage.setItem('userName', name);
  }

  getUserName() {

    return this.userName || localStorage.getItem('userName');
  }

  logout() {
    this.loggedIn = false;
    this.userName = null;
    localStorage.removeItem('userName');
  }

  isLoggedIn() {
    return this.loggedIn;
  }
}
