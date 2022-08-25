import { Component, Inject, Output, EventEmitter } from '@angular/core'
import { EventInfo } from '../../Interfaces/event-information.interface'

@Component({
    selector: 'add-additional-info',
    templateUrl: './add-additional-info.component.html'
})
export class AddAdditionalInfoComponent {
    public user: any;

    public Name: string = "";
    public Value: string = "";
    public Info: EventInfo;

    @Output() cancel: EventEmitter<boolean> = new EventEmitter();
    @Output() add: EventEmitter<EventInfo> = new EventEmitter();

    public onCancel() {
        console.log("close");
        this.cancel.emit(false);
    }

    public onAddData() {
        this.Info = {
            Key: this.Name,
            Value: this.Value
        };
        console.log("add");
        this.add.emit(this.Info);
    }
}