import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../../auth/authenticated-response';
import { LoginModel } from '../../auth/login-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = true;
  credentials: LoginModel = { username: '', password: '' };
  constructor(private router: Router, private httpClient: HttpClient) { }


  login = (form: NgForm) => {
    if (form.valid) {
      this.httpClient.post<AuthenticatedResponse>('http://localhost:5292/Authentication/Authenticate', this.credentials,
        {
          headers: new HttpHeaders({ "Content-Type": "application/json" })
        })
        .subscribe({
          next: (response: AuthenticatedResponse) => {
            const token = response.token;
            localStorage.setItem('jwt', token);
            this.invalidLogin = false;
            this.router.navigate(['/'])
          },
          error: (err: HttpErrorResponse) => this.invalidLogin = true
        });
    }
  }



  ngOnInit(): void {
        
  }

}
