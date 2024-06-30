import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-roulette',
  templateUrl: './roulette.component.html',
  styleUrls: ['./roulette.component.css']
})
export class RouletteComponent implements OnInit {
  
  perfecthalf: number = ((1 / 37) * 360) / 2;
  currentLength: number = this.perfecthalf;
  spininterval: number = 0;

  constructor(private renderer: Renderer2, private el: ElementRef) {}

  ngOnInit(): void {
    this.renderer.setStyle(this.el.nativeElement.querySelector('.wheel img'), 'transform', `rotate(${this.perfecthalf}deg)`);

    // Trigger initial spin on component load
    this.spin();
  }

  spin(): void {
    this.renderer.setStyle(this.el.nativeElement.querySelector('.wheel img'), 'filter', 'blur(0px)');

    this.spininterval = this.getRandomInt(0, 37) * (360 / 37) + this.getRandomInt(3, 4) * 360;
    this.currentLength += this.spininterval;

    const numofsecs = this.spininterval;

    console.log(this.currentLength);
    this.renderer.setStyle(this.el.nativeElement.querySelector('.wheel img'), 'transform', `rotate(${this.currentLength}deg)`);

    setTimeout(() => {
      this.renderer.setStyle(this.el.nativeElement.querySelector('.wheel img'), 'filter', 'blur(0px)');
    }, numofsecs);
  }

  getRandomInt(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }
}
