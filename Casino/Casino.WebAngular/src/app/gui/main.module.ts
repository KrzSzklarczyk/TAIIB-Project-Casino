import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { GamesComponent } from './games/games.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
	declarations: [
		FooterComponent,
		HeaderComponent,
		GamesComponent,
	],
	imports: [
	],
	exports: [
	]
})
export class MainModule { }
