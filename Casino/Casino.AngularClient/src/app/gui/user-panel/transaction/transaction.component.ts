import { Component } from '@angular/core';
import { TransactionService } from '../../../services/transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrl: './transaction.component.css'
})
export class TransactionComponent {
  constructor(private transactionService:TransactionService){}
  credits: number=0;
  
addCredits() {
  if (this.credits !== null && this.credits > 0) 
this.transactionService.addCredits(this.credits);
}

}
