import {File} from '../Interfaces/file.interface'

export interface User {
    Id: string;
    Login: string;
    Email: string;
    Password: string;
    PinnedFile: File
}