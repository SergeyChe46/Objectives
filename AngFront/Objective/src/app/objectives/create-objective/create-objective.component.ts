import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ObjectiveService } from '../objective-service.service';
import { Objective } from '../objective.interface';

@Component({
  selector: 'app-create-objective',
  templateUrl: './create-objective.component.html',
})
export class CreateObjectiveComponent {
  objectiveForm: FormGroup;
  constructor(private _objService: ObjectiveService){
    this.objectiveForm = new FormGroup({               
      'title': new FormControl('', [Validators.required, Validators.minLength(5)]),
      'description': new FormControl('', [Validators.required, Validators.minLength(5)]),
      'priority': new FormArray([
        new FormControl('Low'),
        new FormControl('Medium'),
        new FormControl('High'),
      ], Validators.required) 
  });
  }

  getPriorities(): FormArray{
    return this.objectiveForm.controls['priority'] as FormArray;
  }

  checkForm(): boolean{
    return this.objectiveForm.valid;
  }

  postObjective(newObjective: Objective) {
    this._objService.postObjective(newObjective)
      .subscribe(res => alert(res.description));
    console.log(newObjective);
  }
}
