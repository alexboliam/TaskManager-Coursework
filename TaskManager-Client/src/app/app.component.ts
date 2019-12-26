import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  
  title = 'Task Manager';
  
  public isAuthorized: boolean;

  constructor(httpClient: HttpClient,
              private router: Router,
              private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.isAuthorized = false;
    let check = localStorage.getItem('login');
    if(check != null)
    {
      this.isAuthorized = true;
    }
  }
}
