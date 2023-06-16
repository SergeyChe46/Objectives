import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Objective } from '../objective.interface';
import { ObjectiveService } from '../objective.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-create-objective',
  templateUrl: './create-objective.component.html',
})
export class CreateObjectiveComponent implements OnInit {
  customers: any;
  constructor(private http: HttpClient, private service: ObjectiveService) {
    this.objectiveForm = new FormGroup({               
      title: new FormControl('', [Validators.required, Validators.minLength(5)]),
      description: new FormControl('', [Validators.required, Validators.minLength(5)]),
      priority: new FormControl(null)
    });
    // Устанавливает выбранный из дропдауна приоритет. 
    this.objectiveForm.controls['priority'].setValue(this.selectedPrior, {onlySelf: true});
  }

  ngOnInit(): void {
    this.http.get('http://localhost:5292/objectives/create')
    .subscribe({
      next: (result: any) => this.customers = result,
      error: (err: HttpErrorResponse) => console.log(err)
    })
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
    this.service.post(newObjective)
      .subscribe(
        () => this.objectiveWasAddedChange.emit()
      );
    this.objectiveForm.reset();
  }

  @Output() objectiveWasAddedChange = new EventEmitter();
}
