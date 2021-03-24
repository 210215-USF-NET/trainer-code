import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-get-heroes',
  templateUrl: './get-heroes.component.html',
  styleUrls: ['./get-heroes.component.css']
})
export class GetHeroesComponent implements OnInit {
  //This is where you put your properties
  // Create a property that contains all the heroes from the API
  heroes: hero[] = [];

  //Where you inject your deps
  //Inject the heroRest service to gain access to the data access methods of the service
  constructor(private heroService: HeroRESTService, private router: Router) { }

  //Lifecycle hook 
  // On initialization of this particular component what do you wanna do? 
  //In the get heroes component, we wanna get the heroes and initialize our heroes list
  ngOnInit(): void {
    this.heroService.GetAllHeroes().subscribe(
      (result) => {
        this.heroes = result;
      }
    );
  }

  GetHero(heroName: string) {
    //a way to pass data between components that have no parent child relationship 
    //ways to pass data between components with no parent child relationship:
    // 1. Via query parameters
    // 2. Via a service that both components subscribe to that holds the shared data
    this.router.navigate(['hero-details'], { queryParams: { hero: heroName } });
  }
}
