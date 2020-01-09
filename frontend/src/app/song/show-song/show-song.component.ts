import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource, MatSort } from '@angular/material'
import { Song } from 'src/models/song-model';
import { SongService } from 'src/app/services/song.service';

import {MatDialog, MatDialogConfig} from '@angular/material'
import {AddSongComponent} from 'src/app/song/add-song/add-song.component'
import {MatSnackBar} from '@angular/material';
import {EditSongComponent} from 'src/app/song/edit-song/edit-song.component'

@Component({
  selector: 'app-show-song',
  templateUrl: './show-song.component.html',
  styleUrls: ['./show-song.component.css']
})
export class ShowSongComponent implements OnInit {

  constructor(private service: SongService,
    private dialog:MatDialog, private snackBar:MatSnackBar) {
      //this is to refresh after creating a song
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.refreshSongList();
      });
     }

  listData : MatTableDataSource<any>;
  displayedColumns : string[] = ['Options', 'id', 'nombre', 'artistaId', 'duracio', 'genero']

  @ViewChild(MatSort, null) sort: MatSort

  ngOnInit() {
    this.refreshSongList();
  }

  applyFilter(filtervalue: string){
    this.listData.filter = filtervalue.trim().toLocaleLowerCase();
  }

  refreshSongList(){
    //This was used before implements the service to make tests
    /*var dummyData = [
      {
        ArtistId: 1,
        ArtistName: "Juanes"
      },
      {
        ArtistId: 2,
        ArtistName: "Shakira"
      },
      {
        ArtistId: 3,
        ArtistName: "Paquita"
      }
  ]
  this.listData = new MatTableDataSource(dummyData);
  */
    this.service.getSongList().subscribe(data => {
      this.listData = new MatTableDataSource(data);
      this.listData.sort = this.sort;
    });
  }

  onEdit(song: Song){
    //ITS SHOWING ON CONSOLE that gets the Artist to edit
    console.log(song);
    this.service.formData = song;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width = "70%";
    this.dialog.open(EditSongComponent, dialogConfig);
  }

  onDelete(id: number){
    //ITS SHOWING ON CONSOLE that gets the idArtist to delete
    console.log(id);
    //WITH THE BACKEND RUNNING USE THIS:
    if(confirm('Are you sure you want to delete?')){
      this.service.deleteSong(id).subscribe(res=>{
        this.refreshSongList();
        this.snackBar.open(res.toString(), '', {
          duration:5000,
          verticalPosition:'top'
        });
      });
    }
  }

  onAdd(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width = "70%";
    this.dialog.open(AddSongComponent, dialogConfig);
  }

}

  