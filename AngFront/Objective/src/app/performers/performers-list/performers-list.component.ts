import { Component, OnInit } from '@angular/core';
import { Performers } from '../performers.interface';
import { PerformersService } from '../performers.service';

@Component({
  selector: 'app-performers-list',
  templateUrl: './performers-list.component.html',
})
export class PerformersListComponent implements OnInit {
  performers: Performers[] = [];
  thisPerformer: Performers | undefined;

  constructor(private performerService: PerformersService){}
  ngOnInit(): void {
    this.getPerformers();
  }

  getPerformers(){
    this.performerService.getPerformers()
      .subscribe(data => this.performers = data);
  }

  sendSelectedPerformer(selectedPerf: Performers): void {
    this.thisPerformer = selectedPerf;
  }
}
