import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Song } from 'src/models/song-model'
import { Observable } from 'rxjs';
import {Artist} from 'src/models/artist-model'

import {Subject} from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private http: HttpClient) {

   }
   

   formData: Song;

  readonly APIurl = "http://localhost:3000/";
  getSongList(): Observable<Song[]> {
    //we need to put songs not artists (problems creating a new fake api)
    return this.http.get<Song[]>(this.APIurl + 'song');
  }

  addSong(song:Song){
    return this.http.post(this.APIurl+'/song', song);
  }

  deleteSong(id: number){
    return this.http.delete(this.APIurl+'/song/'+id);
  }

  updateSong(song:Song){
    return this.http.put(this.APIurl+'/song/' + song.id, song);
  }

  //this method get all the drop drown all values for our artist

  getDepDropDownValues():Observable<any>{
    return this.http.get<Artist[]>("http://localhost:58242/api/"+'artista');
  }
  //listen and filter are used to refresh the songs after creating a new song
  private listeners = new Subject<any>();
  listen(): Observable<any>{
    return this.listeners.asObservable();
  }
  filter(filterBy: string){
    this.listeners.next(filterBy);
  }
}
