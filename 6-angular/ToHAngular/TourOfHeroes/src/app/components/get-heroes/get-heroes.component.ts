import { Component, OnInit } from '@angular/core';
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
  constructor(private heroService: HeroRESTService) { }

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

}
