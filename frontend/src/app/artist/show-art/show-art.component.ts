import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource, MatSort } from '@angular/material'
import { Artist } from 'src/models/artist-model';
import { ArtistService } from 'src/app/services/artist.service';

import {MatDialog, MatDialogConfig} from '@angular/material'
import {AddArtComponent} from 'src/app/artist/add-art/add-art.component'
import {MatSnackBar} from '@angular/material';
import {EditArtComponent} from 'src/app/artist/edit-art/edit-art.component'
@Component({
  selector: 'app-show-art',
  templateUrl: './show-art.component.html',
  styleUrls: ['./show-art.component.css']
})
export class ShowArtComponent implements OnInit {

  constructor(private service: ArtistService,
    private dialog:MatDialog, private snackBar:MatSnackBar) {
      //this is to refresh after the create an artist
      this.service.listen().subscribe((m:any)=>{
        console.log(m);
        this.refreshArtistList();
      });
     }

  listData : MatTableDataSource<any>;
  displayedColumns : string[] = ['Options', 'id', 'nombre']

  @ViewChild(MatSort, null) sort: MatSort

  ngOnInit() {
    this.refreshArtistList();
  }

  refreshArtistList(){
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

  this.service.getArtistList().subscribe(data => {
    this.listData = new MatTableDataSource(data);
    this.listData.sort = this.sort;
  });
}

  applyFilter(filtervalue: string){
    this.listData.filter = filtervalue.trim().toLocaleLowerCase();
  }

  onEdit(art: Artist){
    //ITS SHOWING ON CONSOLE that gets the Artist to edit
    console.log(art);
    this.service.formData = art;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus= true;
    dialogConfig.width = "70%";
    this.dialog.open(EditArtComponent, dialogConfig);
  }

  onDelete(id: number){
    //ITS SHOWING ON CONSOLE that gets the idArtist to delete
    console.log(id);
    //WITH THE BACKEND RUNNING USE THIS:
    if(confirm('Are you sure you want to delete?')){
      this.service.deleteArtist(id).subscribe(res=>{
        this.refreshArtistList();
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
    this.dialog.open(AddArtComponent, dialogConfig);
  }

}
