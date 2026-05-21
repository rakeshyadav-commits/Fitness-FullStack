import { Component } from '@angular/core';

import { FormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';

import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    RouterLink
  ],
  templateUrl: './register.html',
  styleUrl: './register.css'
})

export class RegisterComponent {

  registerData = {
    userId: 0,
    fullName: '',
    email: '',
    password: ''
  };

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  register() {

    this.authService
      .register(this.registerData)
      .subscribe({

        next: (response) => {

          console.log(response);

          alert('Registration Successful');

          this.router.navigate(['/']);
        },

        error: (error) => {

          console.log(error);

          alert('Registration Failed');
        }
      });
  }
}