import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
// import { GameService } from '../../services/game.service';
// import { GameDTO } from '../../models/game.model';
import { InfoDialogComponent } from './info/info.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css'],
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
  constructor(public dialog: MatDialog) {}

  openInfoDialog(gameType: string): void {
    let title = '';
    let content = '';

    if (gameType === 'game-slots') {
      title = 'Informacje o grze Jednoręki Bandyta';
      content = 'W grze Jednoręki Bandyta twoim celem będzie uzyskanie co najmniej 2 takich samych symboli obok siebie \n';
      content += '\n Minimalna wartość zakładu wynosi 25 \n';
      content += '\n Musisz obstawić aby zagrać \n';
      content += '\n Im więcej powtórzeń tego samego symbolu tym większa nagroda \n';
      content += '\n Rodzaje symboli mają wpływ na wielkość wygranej \n';
    }
    
    if (gameType === 'game-bandit') {
      title = 'Informacje o grze w Ruletka';
      content = 'W grze Ruletka twoim celem będzie poprawne obstawienie wyniku losowania \n';
      content += '\n Minimalna wartość zakładu wynosi 25 \n';
      content += '\n Postaw ilość jaką chcesz obstawić \n';
      content += '\n Musisz wybrać kolor i obstawić aby zagrać \n';
      content += '\n Możesz wybrać tylko jeden kolor \n';
      content += '\n Możesz obstawić dokładną liczbe aby wygrać jeszcze więcej \n';
    }

    const dialogRef = this.dialog.open(InfoDialogComponent, {
      maxWidth: '90vw',
      data: {
        title: title,
        content: content
      }
    });
  }

}
