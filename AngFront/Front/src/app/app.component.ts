import { Component } from "@angular/core";

@Component({
  selector: 'pm-root',
  templateUrl: 'app.component.html'
})
export class AppComponent{
  pageTitle: string = 'Acme - Product'
  secondLine: string = 'Second - Line'
  temp: string | null

  changeLine(): void{
    this.temp = this.pageTitle
    this.pageTitle = this.secondLine
    this.secondLine = this.temp
  }
}