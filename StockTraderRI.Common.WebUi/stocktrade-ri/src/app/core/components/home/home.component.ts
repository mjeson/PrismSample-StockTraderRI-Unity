import { Component, OnInit } from '@angular/core';
import { ValueService } from 'src/app/shared/services/value.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  values;
  constructor(private valueService: ValueService) { }

  ngOnInit() {
  }

  async learnMore() {
    await this.valueService.getValues().subscribe(I => this.values = I);

    await this.delay(5 * 1000);



  }
  async delay(ms: number) {
    await new Promise(resolve => setTimeout(() => resolve(), ms)).then(() => alert('fired'));
  }
}
