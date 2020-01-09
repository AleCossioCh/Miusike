import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Song } from 'src/models/song-model';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.css']
})
export class TopComponent implements OnInit {
  listaCanciones: Song[]=[];
  headElements = ['Id', 'Nombre', 'Duracion', 'Genero', 'Votos', 'Compras'];
  
  constructor(private songService:SongService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.songService.getAllSongsByVote(1).subscribe(t => {
      this.listaCanciones = t;
    }); 
    
    
     
  }

 


}
