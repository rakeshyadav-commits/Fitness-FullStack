import { Component } from '@angular/core';

import { Router } from '@angular/router';

import { NavbarComponent }
from '../../shared/navbar/navbar';

import { SidebarComponent }
from '../../shared/sidebar/sidebar';

@Component({
  selector: 'app-dashboard',

  standalone: true,

  imports: [
    NavbarComponent,
    SidebarComponent
  ],

  templateUrl: './dashboard.html',

  styleUrls: ['./dashboard.css']
})

export class DashboardComponent {

  constructor(private router: Router) { }

  ngOnInit() {

    const token = localStorage.getItem('token');

    if (!token) {

      alert('Please Login First');

      this.router.navigate(['/']);
    }
  }

  logout() {

    localStorage.removeItem('token');

    alert('Logout Successful');

    this.router.navigate(['/']);
  }
}