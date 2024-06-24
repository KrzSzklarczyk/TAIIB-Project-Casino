import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './gui/header/header.component';
import { FooterComponent } from './gui/footer/footer.component';
import { GamesComponent } from './gui/games/games.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  styleUrls: ['./app.component.css'],
  imports: [
    CommonModule,
    RouterModule,
    HeaderComponent,
    FooterComponent,
    GamesComponent,
  ],
})
export class AppComponent {
  title = 'casino-frontend';
  userName: string = 'Krzysztof';
  userCredits: number = 6000000;
}
