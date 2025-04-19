import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = new BehaviorSubject<boolean>(this.hasToken())
  isLoggedIn$ = this.loggedIn.asObservable();

  login() {
    this.loggedIn.next(true);
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
