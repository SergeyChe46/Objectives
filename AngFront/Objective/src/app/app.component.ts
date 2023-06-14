import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'Objective';

  isUserAuthenticated = (): boolean => {
    return false
  }

  logOut = () => {
    localStorage.removeItem("jwt");
  }
}
