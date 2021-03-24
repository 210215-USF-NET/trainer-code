import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-hero-details',
  templateUrl: './hero-details.component.html',
  styleUrls: ['./hero-details.component.css']
})
export class HeroDetailsComponent implements OnInit {

  hero: hero;
  //the activated route allows me to unpack my route, i.e. get the route parameters
  constructor(private heroService: HeroRESTService, private route: ActivatedRoute) {
    this.hero =
    {
      heroName: '',
      hp: 0,
      elementType: 0,
      superPower:
      {
        name: '',
        description: '',
        damage: 0,
      }
    }
  }

  ngOnInit(): void {
    //i unpack my parameters, take the value of the hero parameter and send it to the 
    // gethero method of my service, that method returns an observable, so I say, after you
    // get a result, set the value of my hero, to the value of the result from the gethero method
    // of the service. 
    this.route.queryParams
      .subscribe(
        params => {
          this.heroService.GetHero(params.hero).subscribe(
            foundHero => {
              this.hero = foundHero;
            }
          )
        }
      );
  }

}
