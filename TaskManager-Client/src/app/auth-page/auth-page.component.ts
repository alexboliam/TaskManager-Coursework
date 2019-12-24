import { Component, OnInit } from '@angular/core';

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


  constructor() { }

  ngOnInit() {
    this.invalidpass = false;
    this.state = "0";
  }
  public onOk(){
     if(this.password!=this.confpassword){
        this.invalidpass = true;
        return;
     }
  }
  public goRegister(){
    this.state = "1";
  }
  public goLogin(){
    this.state = "0";
  }

  
}
