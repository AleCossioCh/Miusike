import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import { ArtistService } from 'src/app/services/artist.service';
import { NgForm } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-add-art',
  templateUrl: './add-art.component.html',
  styleUrls: ['./add-art.component.css']
})

export class AddArtComponent implements OnInit {
  constructor(public dialogbox: MatDialogRef<AddArtComponent>,
    private service:ArtistService, private snackBar: MatSnackBar){
      
  }
  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if(form != null)
      form.resetForm();

      this.service.formData = {
        id: 0,
        nombre: "",
        edad:0,
        imgPath: "pug.jpeg",
        biografia: ""
    }
  }

  onClose(){
    this.dialogbox.close();
    this.service.filter('Register click to update list');
  }

  onSubmit(form: NgForm){
    //ITS SHOWING ON CONSOLE
    console.log(form.value);
    //WITH THE BACKEND RUNNING USE THIS:
    this.service.addArtist(form.value).subscribe(res=>
      {
        this.resetForm(form);
        //the snack bar is to show a message that the artist was created succesfully
        this.snackBar.open(res.toString(), '', {
          duration:5000,
          verticalPosition:'top'
        });
      })
  }

}
