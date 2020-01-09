import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Song } from 'src/models/song-model';
import { SongService } from 'src/app/services/song.service';
import { Artist } from 'src/models/artist-model';
import { ArtistService } from 'src/app/services/artist.service';
import {AddSongComponent} from 'src/app/song/add-song/add-song.component'
import {EditSongComponent} from 'src/app/song/edit-song/edit-song.component'


import {MatDialog, MatDialogConfig} from '@angular/material'
@Component({
  selector: 'app-see-all-art',
  templateUrl: './see-all-art.component.html',
  styleUrls: ['./see-all-art.component.css']
})
export class SeeAllArtComponent implements OnInit {
  canciones:Song[];
  artista:Artist;
  
  constructor(private songService:SongService,private route: ActivatedRoute, private dialog:MatDialog, private artistService: ArtistService) { }

  ngOnInit() {
    const ArtistId = this.route.snapshot.paramMap.get("artistaId");
    this.songService.getSongs(ArtistId).subscribe(t => {
      this.canciones = t;
    }); 
    
    this.artistService.getArtist(ArtistId).subscribe(t => {
      this.artista = t;
    }); 
      
  }


  onDelete(cancion:Song) {
    // Remove From UI
    this.canciones = this.canciones.filter(t => t.id !== cancion.id);
    // Remove from server
    this.songService.deleteOneSong(cancion, this.artista.id).subscribe();
  }

  
  onAddSong(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width = "70%";
    this.dialog.open(AddSongComponent, dialogConfig);
    
  }

  onEdit(song: Song){
 
    console.log(song);
    this.songService.formData = song;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width = "70%";
    this.dialog.open(EditSongComponent, dialogConfig);
  }


  onVote(cancion:Song) {
   
    this.songService.VoteSong(cancion, this.artista.id).subscribe();
  }

  onBuy(cancion:Song) {
   
    this.songService.BuySong(cancion, this.artista.id).subscribe();
  }
}
