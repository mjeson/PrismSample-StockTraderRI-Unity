import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  appUser: any;


  constructor(private auth: AuthService) {

    this.appUser = {
      name: 'Ghislain',
      isAdmin: true
    };
  }


  ngOnInit() { }

}
