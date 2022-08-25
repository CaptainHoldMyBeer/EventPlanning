import { Component } from '@angular/core'
import { EventInfo } from '../Interfaces/event-information.interface'

@Component({
    selector: 'create-event.component',
    templateUrl: './create-event.component.html',
    styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent {
    public user: any;
    public data: Element[] = ELEMENT_DATA;
    public openDialogWindow: boolean = false;


    public openDialogWindowCommand() {
        this.openDialogWindow = true;
    }

    public closeDialogWindowCommand(e: boolean) {
        console.log("te");
        this.openDialogWindow = false;
    }

    public onAddNewInformation(newInfo: EventInfo) {
        let tmp = newInfo;
        alert(tmp);
    }
}
export interface Element {
    name: string;
    weight: string;
}

const ELEMENT_DATA: Element[] = [
    { name: 'Hydrogen', weight: "asdasdasd"},
    { name: 'Helium', weight: "asdasdasd", },
    { name: 'Lithium', weight: "asdasdasd",  },
    { name: 'Beryllium', weight: "asdasdasd", },
    { name: 'Boron', weight: "asdasdasd", },
    { name: 'Carbon', weight: "asdasdasd", },
    { name: 'Nitrogen', weight: "asdasdasd",  },
    { name: 'Oxygen', weight: "asdasdasd", },
    { name: 'Fluorine', weight: "asdasdasd",  },
    { name: 'Neon', weight: "asdasdasd",  },
    { name: 'Sodium', weight: "asdasdasd",  },
    { name: 'Magnesium', weight: "asdasdasd",  },
    { name: 'Aluminum', weight: "asdasdasd",  },
    { name: 'Silicon', weight: "asdasdasd", },
    { name: 'Phosphorus', weight: "asdasdasd",  },
    { name: 'Sulfur', weight: "asdasdasd",  },
    { name: 'Chlorine', weight: "asdasdasd",  },
    { name: 'Argon', weight: "asdasdasd",  },
    { name: 'Potassium', weight: "asdasdasd",  },
    { name: 'Calcium', weight: "asdasdasd",  },
];