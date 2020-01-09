import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import { SongService } from 'src/app/services/song.service';
import { NgForm } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-edit-song',
  templateUrl: './edit-song.component.html',
  styleUrls: ['./edit-song.component.css']
})
export class EditSongComponent implements OnInit {

  constructor(public dialogbox: MatDialogRef<EditSongComponent>,
    private service:SongService, private snackBar: MatSnackBar) { }

  public listItems: Array<number> = [];

  ngOnInit() {
    this.dropdownRefresh();
  }

  dropdownRefresh(){
    this.service.getDepDropDownValues().subscribe(data=>{
      console.log(data);
      data.forEach(element => {
        this.listItems.push(element["artistaId"]);
      });
    });
  }

  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click to update list');
  }

  onSubmit(form:NgForm){
    this.service.updateSong(form.value,  this.service.formData.artistaId).subscribe(res=>{
      this.snackBar.open(res.toString(), '',{
        duration:5000,
        verticalPosition:'top'
      })
    })
  }

}
