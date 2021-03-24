import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddHeroComponent } from './components/add-hero/add-hero.component';
import { GetHeroesComponent } from './components/get-heroes/get-heroes.component';
import { HeroDetailsComponent } from './components/hero-details/hero-details.component';
//This module gets scaffolded when you say to include routing in your angular app
//This property is where you define, which routes/routerLinks goes to certain components
// you need two things to define a route: path (endpoint) to go to, component that it is routing to
const routes: Routes = [
  {
    path: 'get-heroes',
    component: GetHeroesComponent
  },
  {
    path: 'add-hero',
    component: AddHeroComponent
  },
  {
    path: 'hero-details',
    component: HeroDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
