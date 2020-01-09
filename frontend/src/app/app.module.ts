import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import {FormsModule} from '@angular/forms';
import {MatDialogModule} from '@angular/material'
import {MatSortModule} from '@angular/material'
import { HttpClientModule } from '@angular/common/http'
import { MatTableModule } from '@angular/material/table'; 
import { MatIconModule } from '@angular/material/icon'
import { MatButtonModule } from '@angular/material/button'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatInputModule} from '@angular/material/input';
import { EditSongComponent } from './song/edit-song/edit-song.component';
import { AddSongComponent } from './song/add-song/add-song.component';
import { ShowArtComponent } from './artist/show-art/show-art.component';
import { EditArtComponent } from './artist/edit-art/edit-art.component';
import { AddArtComponent } from './artist/add-art/add-art.component';
import { SongComponent } from './song/song.component'
import { ArtistComponent } from './artist/artist.component'
import {MatSnackBarModule} from '@angular/material/snack-bar'

import { SongService } from 'src/app/services/song.service';
import { ArtistService } from 'src/app/services/artist.service';
import { ShowSongComponent } from './song/show-song/show-song.component';
import { UploadComponent } from './upload/upload.component';
import { SeeAllArtComponent } from './artist/see-all-art/see-all-art.component';
import { MainComponent } from './home/main/main.component';
import { TopComponent } from './ranking/top/top.component';
import { ContactoComponent } from './contacto/contacto/contacto.component';
import { FooterComponent } from './home/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    EditSongComponent,
    AddSongComponent,
    ShowArtComponent,
    EditArtComponent,
    AddArtComponent, 
    SongComponent,
    ArtistComponent,
    ShowSongComponent,
    UploadComponent,
    SeeAllArtComponent,
    MainComponent,
    TopComponent,
    ContactoComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule, MatTableModule, MatIconModule, MatButtonModule,
    HttpClientModule,
    MatSortModule,
    MatDialogModule,
    MatSnackBarModule,
    FontAwesomeModule
  ],
  providers: [SongService, ArtistService],
  bootstrap: [AppComponent],
  entryComponents:[AddArtComponent, EditArtComponent, AddSongComponent, EditSongComponent]
})
export class AppModule { }
