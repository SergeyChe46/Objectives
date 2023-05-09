import { Component, EventEmitter, Input, OnChanges, Output } from "@angular/core";

@Component({
    selector: 'obj-star',
    templateUrl: 'stars.component.html'
})
export class StarsComponent implements OnChanges{
    @Input() rating: number = 4
    cropWidth: number = 75

    @Output() ratingClicked: EventEmitter<string> = new EventEmitter<string>();

    ngOnChanges(): void{
        this.cropWidth = this.rating * 75 / 5;
    }

    onClick(): void{
        this.ratingClicked.emit(this.rating.toString());
    }
}