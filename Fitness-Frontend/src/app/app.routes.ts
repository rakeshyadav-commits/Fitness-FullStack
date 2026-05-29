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
  },

  {
    path: 'bmi',
    loadComponent: () =>
      import('./pages/bmi/bmi')
      .then(m => m.Bmi)
  },

  {
    path: 'calories',
    loadComponent: () =>
      import('./pages/calories/calories')
      .then(m => m.Calories)
  },

 {
  path: 'profile',
  loadComponent: () =>
    import('./pages/profile/profile')
    .then(m => m.Profile)
}
];