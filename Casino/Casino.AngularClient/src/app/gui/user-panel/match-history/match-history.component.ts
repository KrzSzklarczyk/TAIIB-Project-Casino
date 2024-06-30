import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, of, forkJoin } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
import { BanditResponseDTO } from '../../../models/banditDTO';
import { GameResponseDTO } from '../../../models/gameDTO';
import { ResultResponseDTO } from '../../../models/ResultDTO';

@Component({
  selector: 'app-match-history',
  templateUrl: './match-history.component.html',
  styleUrls: ['./match-history.component.css']
})

export class MatchHistoryComponent implements OnInit {
  iconMap = ["banana", "seven", "cherry", "plum", "orange", "bell", "bar", "lemon", "melon"];
  displayedColumns: string[] = ['date', 'amount', 'position1', 'position2', 'position3', 'minbet', 'maxbet', 'betAmount'];
  cred: AuthenticatedResponse = { accessToken: '', refreshToken: '' };
  his: { date: string | Date, amount: number, position1: number, position2: number, position3: number, minbet: number, maxbet: number, betAmount: number }[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getResultData();
  }

  banditData: BanditResponseDTO = {
    description: '',
    position1: 0,
    position2: 0,
    position3: 0
  };

  gameData: GameResponseDTO = {
    resultId: 0,
    blackJackId: null,
    rouletteId: null,
    banditId: 0,
    description: '',
    startDate: new Date(),
    endDate: new Date(),
    maxBet: 0,
    minBet: 0,
    amount: 0
  };

  getBanditData(id: number): Observable<BanditResponseDTO> {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return of(this.banditData); // Return an observable of the default banditData
    } else {
      const url = `https://localhost:7063/Game/Bandit/${id}`;
      return this.http.get<BanditResponseDTO>(url, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      });
    }
  }

  getGameData(id: number): Observable<GameResponseDTO> {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return of(this.gameData); // Return an observable of the default gameData
    } else {
      const url = `https://localhost:7063/Game/Game/${id}`;
      return this.http.get<GameResponseDTO>(url, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      });
    }
  }

  getResultData(): void {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return;
    }

    this.http.post<ResultResponseDTO[]>('https://localhost:7063/Result/GetUserResult', this.cred, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    }).subscribe(results => {
      // Create an array of observables to handle fetching game and bandit data
      const dataObservables = results.map(result => {
        return this.getGameData(result.gameId).pipe(
          switchMap(gameData => {
            return this.getBanditData(gameData.banditId).pipe(
              map(banditData => ({
                amount: result.amount,
                betAmount: gameData.amount,
                date: result.dateTime,
                maxbet: gameData.maxBet,
                minbet: gameData.minBet,
                position1: banditData.position1,
                position2: banditData.position2,
                position3: banditData.position3,
              }))
            );
          })
        );
      });

      // Combine all observables and update the `his` array once all data is fetched
      forkJoin(dataObservables).subscribe(hisData => {
        this.his = hisData;
        console.log(this.his);
      });
    });
  }
}
