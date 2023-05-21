import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Performers } from 'src/app/objectives/performers.interface';
import { PerformersService } from '../performers.service';

@Component({
  selector: 'app-performer-card',
  templateUrl: './performer-card.component.html',
})

export class PerformerCardComponent implements OnInit {
  performer : Performers | undefined;
  
  constructor(
    private route: ActivatedRoute,
    private performerService: PerformersService
    ){}

  ngOnInit(): void {
    this.getPerformer();
  }

  getPerformer(){
    const performerEmail: string | null = this.route.snapshot.paramMap.get('email');
    if(performerEmail != null){
      this.performerService.getPerformer(performerEmail)
        .subscribe(data => this.performer = data);
    } else {
      this.performer = { 
        email: "Performer not found",
        name: "Performer not found",
        objectives: [],
        performerId: 0
      }
    }
  }
}
