import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { hero } from 'src/app/models/hero';
import { HeroRESTService } from 'src/app/services/hero-rest.service';

@Component({
  selector: 'app-add-hero',
  templateUrl: './add-hero.component.html',
  styleUrls: ['./add-hero.component.css']
})
export class AddHeroComponent implements OnInit {
  hero2Add: hero;
  constructor(private heroService: HeroRESTService, private router: Router) {
    this.hero2Add =
    {
      heroName: '',
      hp: 0,
      elementType: 0,
      superPower:
      {
        name: '',
        description: '',
        damage: 0,
        id: 0,
        heroid: 0
      },
      id: 0
    }
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.heroService.AddHero(this.hero2Add).subscribe(
      (hero) => {
        alert(`${hero.heroName} was added!`);
        this.router.navigate(['get-heroes']);
      }
    );
  }
}
