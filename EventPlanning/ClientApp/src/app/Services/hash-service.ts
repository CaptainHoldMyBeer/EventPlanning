import { Injectable } from '@angular/core';
import { sha256, sha224 } from 'js-sha256';

@Injectable()
export class GlobalAppService {

    public getHash(password: string): string {
        return sha256(password);
    }
}