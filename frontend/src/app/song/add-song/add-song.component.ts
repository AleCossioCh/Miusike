import { Component, OnInit } from '@angular/core';
import {MatDialogRef} from '@angular/material';
import { SongService } from 'src/app/services/song.service';
import { NgForm } from '@angular/forms';
import {MatSnackBar} from '@angular/material';

@Component({
  selector: 'app-add-song',
  templateUrl: './add-song.component.html',
  styleUrls: ['./add-song.component.css']
})
export class AddSongComponent implements OnInit {


  constructor(public dialogbox: MatDialogRef<AddSongComponent>,
    private service:SongService, private snackBar: MatSnackBar)
  { }
  
  public listItems: Array<string> = [];

  ngOnInit() {
    this.resetForm();
    this.dropdownRefresh();
  }

  
  dropdownRefresh(){
    this.service.getDepDropDownValues().subscribe(data=>{
      console.log(data);
      data.forEach(element => {
        this.listItems.push(element["nombre"]);
      });
    });
  }

  resetForm(form?:NgForm){
    if(form != null)
      form.resetForm();

      this.service.formData = {
        id: 0,
        nombre: "",
        duracio:0,
        genero:"",
        artistaId:0, 
        votacion:0,
        ventas:0
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
    this.service.addSong(form.value, this.service.formData.artistaId ).subscribe(res=>
    {
      this.resetForm(form);
      //the snack bar is to show a message that the song was created succesfully
      this.snackBar.open(res.toString(), '', {
        duration:5000,
        verticalPosition:'top'
      });
    })
  }
}
