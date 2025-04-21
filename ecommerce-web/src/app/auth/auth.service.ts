import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { UserLoginModel } from './models/userLogin.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = new BehaviorSubject<boolean>(this.hasToken())
  isLoggedIn$ = this.loggedIn.asObservable();

  constructor(private client: HttpClient) {}

  login(user: UserLoginModel) {
    this.client.post("http://localhost:4999/api/v1/auth/login", {
      email: user.email,
      password: user.password,
    }).subscribe({
      next: (res) => {
        console.log(res)
        //this.loggedIn.next(true);
      }
    })
  }

  logout() {
    localStorage.removeItem('token')
    this.loggedIn.next(false)
  }

  hasToken(): boolean {
    if (typeof window === 'undefined') return false;

    const token = localStorage.getItem('token');
    return !!token && token !== 'undefined' && token.trim().length > 0;
  }
}
