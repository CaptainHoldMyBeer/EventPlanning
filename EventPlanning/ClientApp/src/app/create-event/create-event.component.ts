import { Component } from '@angular/core'
import { MatTableDataSource } from '@angular/material';

@Component({
    selector: 'create-event.component',
    templateUrl: './create-event.component.html'
})
export class CreateEventComponent {
    public user: any;
    displayedColumns = ['name', 'weight'];
    dataSource = new MatTableDataSource<Element>(ELEMENT_DATA);


    public getRecord(e: any) {
        alert(e);
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