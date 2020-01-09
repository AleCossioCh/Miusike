import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import { ArtistService } from 'src/app/services/artist.service';
import { NgForm } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-edit-art',
  templateUrl: './edit-art.component.html',
  styleUrls: ['./edit-art.component.css']
})
export class EditArtComponent implements OnInit {

  constructor(public dialogbox: MatDialogRef<EditArtComponent>,
    private service:ArtistService, private snackBar: MatSnackBar)
  { }

  ngOnInit() {
  }

  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click to update list');
  }

  onSubmit(form:NgForm){
    this.service.updateArtist(form.value).subscribe(res=>{
      this.snackBar.open(res.toString(), '',{
        duration:5000,
        verticalPosition:'top'
      })
    })
  }
  
}
