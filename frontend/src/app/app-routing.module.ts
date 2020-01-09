import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SeeAllArtComponent} from './artist/see-all-art/see-all-art.component'
import { ShowArtComponent} from './artist/show-art/show-art.component'
import {MainComponent} from './home/main/main.component'
import {TopComponent} from './ranking/top/top.component'
import {ContactoComponent} from './contacto/contacto/contacto.component'
import {TopVentaComponent} from './ranking/top-venta/top-venta.component'

const routes: Routes = [ 
  { path: 'artistas/:artistaId', component: SeeAllArtComponent},
  { path: 'artistas', component: ShowArtComponent},
  { path: '', component: MainComponent},
  { path: 'rankingVotos', component: TopComponent},
  { path: 'rankingVentas', component: TopVentaComponent},
  { path: 'contacto', component: ContactoComponent}
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
