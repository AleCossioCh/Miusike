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
  SongUrl="http://localhost:5000/api/";
  constructor(private http: HttpClient) {

   }
   

   formData: Song;

  readonly APIurl = "http://localhost:3000/";
  getSongList(): Observable<Song[]> {
    //we need to put songs not artists (problems creating a new fake api)
    return this.http.get<Song[]>(this.APIurl + 'song');
  }

  

  deleteSong(id: number){
    return this.http.delete(this.APIurl+'/song/'+id);
  }

  

  //this method get all the drop drown all values for our artist

  getDepDropDownValues():Observable<any>{
    return this.http.get<Artist[]>("http://localhost:5000/api/"+'artista');
  }
  //listen and filter are used to refresh the songs after creating a new song
  private listeners = new Subject<any>();
  listen(): Observable<any>{
    return this.listeners.asObservable();
  }
  filter(filterBy: string){
    this.listeners.next(filterBy);
  }


  getSongs(ArtistId):Observable<Song[]> {
    return this.http.get<Song[]>(this.SongUrl + 'artista/' + ArtistId + '/canciones');
  }

  deleteOneSong(cancion: Song, ArtistId:number){
    return this.http.delete(this.SongUrl + 'artista/' + ArtistId + '/canciones/' + cancion.id);
  }
 
  addSong(song:Song, ArtistId:any):Observable<Song>{
    return this.http.post<Song>(this.SongUrl + 'artista/' + ArtistId + '/canciones', song);
  }

  updateSong(song:Song, ArtistId:any){
    return this.http.put(this.SongUrl + 'artista/' + ArtistId + '/canciones/' + song.id, song);
  }


  VoteSong(song: Song, ArtistId:number){
    return this.http.put(this.SongUrl + 'artista/' + ArtistId + '/canciones/' + song.id + '/voto' , song);
  }

  BuySong(song: Song, ArtistId:number){
    return this.http.put(this.SongUrl + 'artista/' + ArtistId + '/canciones/' + song.id + '/venta' , song);
  }

  getAllSongsByVote(votacion:number):Observable<Song[]>{
    return this.http.get<Song[]>(this.SongUrl + 'artista/allcanciones/' + votacion );
  }

  getAllSongsByBuy(venta:number):Observable<Song[]>{
    return this.http.get<Song[]>(this.SongUrl + 'artista/allcanciones/' + venta);
  }
  
 
 
}

