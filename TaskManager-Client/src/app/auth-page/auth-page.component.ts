import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent implements OnInit {
  public state: string;
  public login: string;
  public password: string;
  public confpassword: string;
  public invalidpass: boolean;
  public invalidlogin: boolean;
  private httpClient: HttpClient;

  constructor(httpClient:HttpClient, private router: Router,
              private route: ActivatedRoute) { 
                this.httpClient = httpClient;
              }

  ngOnInit() {
    this.invalidpass = false;
    this.state = "0";
  }
  public onOk(){
     if(this.password!=this.confpassword){
        this.invalidpass = true;
        return;
     }
     const credentials: AuthModel = { login: this.login, password: this.password }
     this.httpClient.post("http://localhost:60359/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      let login = (<any>response).login;
      localStorage.setItem("login", login);
      this.invalidlogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidlogin = true;
    });
  }
  public goRegister(){
    this.state = "1";
  }
  public goLogin(){
    this.state = "0";
  }

  
}

export interface AuthModel {
  login:string,
  password:string
}