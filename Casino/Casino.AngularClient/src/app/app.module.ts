import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from "@angular/material/form-field";
import { ReactiveFormsModule } from "@angular/forms";
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './gui/shared/footer/footer.component';
import { HeaderComponent } from './gui/shared/header/header.component';
import { GamesComponent } from './gui/main/games/games.component';
import { LoginComponent } from './gui/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { RegisterComponent } from './gui/register/register.component';
import { HelpsiteComponent } from './gui/helpsite/helpsite.component';
import { MainComponent } from './gui/main/main.component';
import { PromotionsComponent } from './gui/promotions/promotions.component';
import { SlotsyComponent } from './gui/slotsy/slotsy.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
export function tokenGetter() { 
  return localStorage.getItem("accessToken"); 
}

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    GamesComponent,
    LoginComponent,
    RegisterComponent,
    HelpsiteComponent,
    MainComponent,
    PromotionsComponent,
    SlotsyComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    FormsModule,
    MatCheckboxModule,
    MatDividerModule,
    MatIconModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:5080"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
