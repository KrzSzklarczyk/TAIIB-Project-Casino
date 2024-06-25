import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from "@angular/material/form-field";
import {ReactiveFormsModule} from "@angular/forms";
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './gui/footer/footer.component';
import { HeaderComponent } from './gui/header/header.component';
import { GamesComponent } from './gui/games/games.component';
import { LoginComponent } from './gui/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
export function tokenGetter() { 
  return localStorage.getItem("accessToken"); 
}

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    GamesComponent,
    LoginComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    FormsModule,
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
