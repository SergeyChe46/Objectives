import { Component, Input } from '@angular/core';
import { Performers } from '../performers.interface';

@Component({
  selector: 'app-performers-detail',
  templateUrl: './performers-detail.component.html'
})
export class PerformersDetailComponent {
  @Input() currentPerformer: Performers | undefined;  
}
