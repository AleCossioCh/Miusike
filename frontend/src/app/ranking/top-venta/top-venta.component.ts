import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Song } from 'src/models/song-model';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-top-venta',
  templateUrl: './top-venta.component.html',
  styleUrls: ['./top-venta.component.css']
})
export class TopVentaComponent implements OnInit {
listaCanciones: Song[]=[];
  headElements = ['Id', 'Nombre', 'Duracion', 'Genero', 'Votos', 'Compras'];
  constructor(private songService:SongService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.songService.getAllSongsByBuy(2).subscribe(t => {
      this.listaCanciones = t;
    }); 
  }

}

  