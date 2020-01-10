import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Artist } from 'src/models/artist-model'
import { Observable } from 'rxjs';

import {Subject} from 'rxjs'
@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  constructor(private http: HttpClient) {

   }
   
   formData: Artist;

  readonly APIurl = "http://localhost:58242/api";
  getArtistList(): Observable<Artist[]> {
    return this.http.get<Artist[]>(this.APIurl + '/artista');
  }

  addArtist(art:Artist){
    return this.http.post(this.APIurl+'/artista', art);
  }

  deleteArtist(id: number){
    return this.http.delete(this.APIurl+'/artista/'+id);
  }

  updateArtist(art:Artist){
    return this.http.put(this.APIurl+'/artista/'+art.id, art);
  }
  //listen and filter are used to refresh the autors after creating a new artist
  private listeners = new Subject<any>();
  listen(): Observable<any>{
    return this.listeners.asObservable();
  }
  filter(filterBy: string){
    this.listeners.next(filterBy);
  }
}
