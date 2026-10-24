import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { AuthResponse, LoginRequest, RegisterRequest } from './auth.models';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);
  
  // Update this if your .NET API runs on a different port (check Properties/launchSettings.json)
  private apiUrl = 'https://localhost:7196/api/auth'; 
  private tokenKey = 'lifetrack_token';

  private currentUserSubject = new BehaviorSubject<AuthResponse | null>(this.getUserFromStorage());
  public currentUser$ = this.currentUserSubject.asObservable();

  register(data: RegisterRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/register`, data).pipe(
      tap(response => this.setSession(response))
    );
  }

  login(data: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(`${this.apiUrl}/login`, data).pipe(
      tap(response => this.setSession(response))
    );
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem('lifetrack_user');
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  private setSession(authResult: AuthResponse) {
    localStorage.setItem(this.tokenKey, authResult.token);
    localStorage.setItem('lifetrack_user', JSON.stringify({ email: authResult.email, displayName: authResult.displayName }));
    this.currentUserSubject.next(authResult);
  }

  private getUserFromStorage(): AuthResponse | null {
    const token = localStorage.getItem(this.tokenKey);
    const userStr = localStorage.getItem('lifetrack_user');
    if (token && userStr) {
      const user = JSON.parse(userStr);
      return { token, email: user.email, displayName: user.displayName };
    }
    return null;
  }
}