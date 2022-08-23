import { EventInfo } from "./event-information.interface";

export interface Event {
    Title: string;
    Id: number;
    Location: string;
    Date: Date;
    AdditionalInfo: Array<EventInfo>
}