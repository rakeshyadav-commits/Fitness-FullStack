import { Component } from '@angular/core';

import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
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