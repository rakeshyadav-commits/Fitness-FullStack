import { Routes } from '@angular/router';

import { LoginComponent }
from './components/login/login';

import { RegisterComponent }
from './components/register/register';

import { DashboardComponent }
from './layouts/dashboard/dashboard';

export const routes: Routes = [

  {
    path: '',
    component: LoginComponent
  },

  {
    path: 'register',
    component: RegisterComponent
  },

  {
    path: 'dashboard',
    component: DashboardComponent
  }

];