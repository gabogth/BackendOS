import { Injectable } from '@angular/core';
import { ICleanState } from '@app/core/interfaces/ICleanState';

@Injectable({
  providedIn: 'root',
})
export class StateService {
    private states: ICleanState[] = [];
    register(state: ICleanState) {
        this.states.push(state);
    }
    resetAll(): void {
        this.states.forEach(state => state.cleanState());
        this.states = [];
    }
}
