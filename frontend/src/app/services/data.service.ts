import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { Song } from 'src/models/song-model';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  
  listaCanciones: BehaviorSubject<Song[]> = new BehaviorSubject<Song[]>(null);
    userData = this.listaCanciones.asObservable();

  constructor() { }
  

  addData(dataObj) {
    const currentValue = this.listaCanciones.value;
    const updatedValue = [...currentValue, dataObj];
    this.listaCanciones.next(updatedValue);
}
}


