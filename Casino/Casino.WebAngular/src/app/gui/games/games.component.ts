import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { GameService } from '../../services/game.service';
// import { GameDTO } from '../../models/game.model';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class GamesComponent { //implements OnInit 
  // games: GameDTO[] = [];

  // constructor(private gameService: GameService) {}

  // ngOnInit(): void {
  //   this.fetchGames();
  // }

  // fetchGames(): void {
  //   this.gameService.getGames().subscribe((games) => {
  //     this.games = games;
  //   });
  // }
}
