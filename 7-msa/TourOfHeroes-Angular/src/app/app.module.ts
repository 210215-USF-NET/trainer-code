import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetHeroesComponent } from './components/get-heroes/get-heroes.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AddHeroComponent } from './components/add-hero/add-hero.component';
import { FormsModule } from '@angular/forms';
import { HeroDetailsComponent } from './components/hero-details/hero-details.component';
import { EditHeroComponent } from './components/edit-hero/edit-hero.component';
import { environment } from 'src/environments/environment';

//this is the metadata of the module
@NgModule({
  declarations: [
    AppComponent,
    GetHeroesComponent,
    NavBarComponent,
    AddHeroComponent,
    HeroDetailsComponent,
    EditHeroComponent
  ],
  //This is where you declare external modules you'll be utilizing 
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
