import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './gui/login/login.component';
import { HelpsiteComponent } from './gui/helpsite/helpsite.component';
import { RegisterComponent } from './gui/register/register.component';
import { PromotionsComponent } from './gui/promotions/promotions.component';
import { MainComponent } from './gui/main/main.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'helpsite', component: HelpsiteComponent },
  { path: 'promotions', component: PromotionsComponent },
  { path: '', component: MainComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
