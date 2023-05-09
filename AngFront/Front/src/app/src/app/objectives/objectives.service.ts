import { Injectable } from "@angular/core";
import { ObjectiveView } from "../shared/objective-view.interface";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, catchError, tap, throwError } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ObjectiveService{
  
  getProducts(): ObjectiveView[] {
    return [
      {
        title: 'First title',
        description: 'First description',
        stars: 1
      },
      {
        title: 'Second title',
        description: 'Second description',
        stars: 2
      },
      {
        title: 'Third title',
        description: 'Third description',
        stars: 3
      }
    ]
  }
}