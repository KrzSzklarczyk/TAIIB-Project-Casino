import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SlotsyService } from './slotsy.service';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './slotsy.component.html',
  styleUrl: './slotsy.component.css'
})
export class SlotsyComponent implements OnInit {
  debugText: string = 'Click "Start Rolling" to begin';
  rolling: boolean = false;
  betAmount: number = 0;

  constructor(private slotMachineService: SlotsyService) {}

  ngOnInit(): void {}

  startRolling(): void {
    if(this.betAmount >= 25){
      if (!this.rolling) {
        this.rolling = true;
        this.debugText = 'Rolling...';

      const reelsList = document.querySelectorAll<HTMLElement>('.slots > .reel');
     Promise
      .all(Array.from(reelsList).map((reel, i) => this.slotMachineService.roll(reel, i)))
      .then((deltas) => {
        deltas.forEach((delta, i) => this.slotMachineService.indexes[i] = (this.slotMachineService.indexes[i] + delta) % this.slotMachineService.num_icons);
        this.debugText = this.slotMachineService.indexes.map((i) => this.slotMachineService.iconMap[i]).join(' - ');
      
       console.log(this.debugText);
      
        if (this.slotMachineService.indexes[0] == this.slotMachineService.indexes[1] && this.slotMachineService.indexes[1] == this.slotMachineService.indexes[2]) {
          const slotsEl = document.querySelector(".slots") as HTMLElement;
          slotsEl.classList.add("win");
          setTimeout(() => slotsEl.classList.remove("win"), 2000);
        }
        this.rolling = false;
      });
    }
  }
}
}