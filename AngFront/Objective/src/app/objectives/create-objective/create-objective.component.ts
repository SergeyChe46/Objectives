import { Component } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ObjectiveService } from '../objective-service.service';
import { Objective } from '../objective.interface';

@Component({
  selector: 'app-create-objective',
  templateUrl: './create-objective.component.html',
})
export class CreateObjectiveComponent {
  constructor(private _objService: ObjectiveService){
    this.objectiveForm = new FormGroup({               
      title: new FormControl('', [Validators.required, Validators.minLength(5)]),
      description: new FormControl('', [Validators.required, Validators.minLength(5)]),
      priority: new FormControl(null)
    });
    // Устанавливает выбранный из дропдауна приоритет. 
    this.objectiveForm.controls['priority'].setValue(this.selectedPrior, {onlySelf: true});
  }
  // Форма создания задач.
  objectiveForm: FormGroup;
  // Доступные варианты приоритета задач.
  priorities: string[] = ['Low', 'Medium', 'High'];
  // Выбранный приоритет задачи.
  selectedPrior: string = this.priorities[0];  
/**
 * Проверяет длину заголовка и описания.
 * @returns Корректность введённых данных.
 */
  checkForm(): boolean{
    return this.objectiveForm.valid;
  }

/**
 * Создаёт новую задачу.
 * @param newObjective Значения задачи из формы.
 */
  postObjective(newObjective: Objective): void {
    this._objService.postObjective(newObjective)
      .subscribe(res => alert(res.description));
    console.log(newObjective);
  }
}
