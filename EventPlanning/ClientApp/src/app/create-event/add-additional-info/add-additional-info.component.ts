import { Component, Inject } from '@angular/core'
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { CreateEventComponent } from '../create-event.component';


@Component({
    selector: 'add-additional-info.component',
    templateUrl: './add-additional-info.component.html'
})
export class AddAdditionalInfoComponent {
    public user: any;

}