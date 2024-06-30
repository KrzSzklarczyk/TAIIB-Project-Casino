import { Component, OnInit } from '@angular/core';

import { UserResponseDTO } from '../../../models/user.models';
import { AuthenticatedResponse } from '../../../models/authenticated-response';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { TransactionsResponseDTO } from '../../../models/TransactionDTO';
import { Observable, forkJoin, of, switchMap, map } from 'rxjs';
import { BanditResponseDTO } from '../../../models/banditDTO';
import { GameResponseDTO } from '../../../models/gameDTO';
import { ResultResponseDTO } from '../../../models/ResultDTO';

@Component({
  selector: 'app-admin-panel-user',
  templateUrl: './admin-panel-user.component.html',
  styleUrls: ['./admin-panel-user.component.css']
})
export class AdminPanelUserComponent implements OnInit {
  Users: UserResponseDTO[] = [];
  iconMap = ["banana", "seven", "cherry", "plum", "orange", "bell", "bar", "lemon", "melon"];
  cred: AuthenticatedResponse = { accessToken: '', refreshToken: '' };
  displayedColumns: string[] = ['userId', 'email', 'nickName', 'avatar', 'credits', 'userType', 'actions'];
  his: { date: string | Date, amount: number, position1: number, position2: number, position3: number, minbet: number, maxbet: number, betAmount: number }[] = [];
  transactionHistory: TransactionsResponseDTO[] = [];
  showMatchHistory: boolean = false;
  showTransactionHistory: boolean = false;
  selectedUserId: number | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.GetAllUsers();
  }

  GetAllUsers(): void {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    this.Users = [];
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return;
    }
    this.http.post<UserResponseDTO[]>("https://localhost:7063/Account/getAllUsers", this.cred, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    }).subscribe({
      next: (response: UserResponseDTO[]) => {
        this.Users = response;
      },
      error: (err: HttpErrorResponse) => { this.Users = []; }
    });
  }

  RemoveUser(id: number): void {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return;
    }
    const url = `https://localhost:7063/Account/RemoveUser/${id}`;
    this.http.post<boolean>(url, this.cred, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    }).subscribe({
      next: (response: boolean) => {
        if (response) {
          this.GetAllUsers();
        }
      },
      error: (err: HttpErrorResponse) => { }
    });
  }

  getBanditData(id: number): Observable<BanditResponseDTO> {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return of({
        description: '',
        position1: 0,
        position2: 0,
        position3: 0
      });
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
      return of({
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
      });
    } else {
      const url = `https://localhost:7063/Game/Game/${id}`;
      return this.http.get<GameResponseDTO>(url, {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      });
    }
  }

  GetHistory(id: number): void {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      this.his = [];
      return;
    }
    const url = `https://localhost:7063/Transaction/History/${id}`;
    this.http.post<TransactionsResponseDTO[]>(url, this.cred, {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    }).subscribe({
      next: (response: TransactionsResponseDTO[]) => {
        this.transactionHistory = response;
        this.showTransactionHistory = true;
        this.showMatchHistory = false;
        this.selectedUserId = id;
      },
      error: (err: HttpErrorResponse) => { this.transactionHistory = []; }
    });
  }

  getResultData(id: number): void {
    this.cred.accessToken = localStorage.getItem('accessToken') ?? '';
    this.cred.refreshToken = localStorage.getItem('refreshToken') ?? '';
    if (this.cred.accessToken === '' || this.cred.refreshToken === '') {
      return;
    }
    const url = `https://localhost:7063/Result/GetUserResult/${id}`;
    this.http.post<ResultResponseDTO[]>(url, this.cred, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    }).subscribe(results => {
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

      forkJoin(dataObservables).subscribe(hisData => {
        this.his = hisData;
        this.showMatchHistory = true;
        this.showTransactionHistory = false;
      });
    });
  }

  funcshowTransactionHistory(userId: number): void {
    this.GetHistory(userId);
  }

  getMatchHistory(userId: number): void {
    this.getResultData(userId);
    this.selectedUserId = userId;
  }

  goBack(): void {
    this.showMatchHistory = false;
    this.showTransactionHistory = false;
    this.selectedUserId = null;
  }
}
