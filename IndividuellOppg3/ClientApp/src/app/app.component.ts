import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { SpmKlasse } from "./SpmKlasse";

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
  //styleUrls: ['./styles.css']
})
export class AppComponent {

  skjema: FormGroup;
  alleSporsmalene: Array<SpmKlasse>;
  laster: boolean;
  visListe: boolean;
  antallLikes: number;
  likt: number;
  ikkeLikt: number;
  Id1: number;
  Id2: number;


  likerButtonClick(etSpm: SpmKlasse) {
    etSpm.liker++;
    this.Id1 = etSpm.id;
    this.likt = etSpm.liker;
  }

  likerIkkeButtonClick(etSpm: SpmKlasse) {
    etSpm.likerIkke++;
    this.Id2 = etSpm.id;
    this.ikkeLikt = etSpm.likerIkke;
  }

  constructor(private _http: HttpClient, private fb: FormBuilder) {
    this.skjema = fb.group({});
    this.skjema = new FormGroup({
     innSpm: new FormControl()
    });
  }

  ngOnInit() {
    this.laster = true;
    this.hentAlleSpm();
    this.visListe = true;
  };

  hentAlleSpm() {
    this._http.get<SpmKlasse[]>("api/faq/HentAlle")
      .subscribe(sporsmalene => {
        this.alleSporsmalene = sporsmalene;
        this.laster = false;
      },
        error => console.log(error), () => console.log("hallaisen der! get-api/faq")
      );
  };


  vedSubmit() {
    this.lagreSpm();
    this.skjema.touched;
  }


  lagreSpm() {
    const lagretSpm = new SpmKlasse();

    lagretSpm.spm = this.skjema.value.innSpm;

    this._http.post("api/faq/LagreSpm", lagretSpm)
      .subscribe(retur => {
        console.log("Kommer hit 1");
        this.hentAlleSpm();
        this.visListe = true;
      }, error => console.log(error));
  };

  lagreLiker() {
    const lagretLiker = new SpmKlasse();

    lagretLiker.id = this.Id1;
    lagretLiker.liker = this.likt;

    this._http.put("api/faq/OppdaterLiker", lagretLiker)
      .subscribe(retur => {
        
        this.hentAlleSpm();
        this.visListe = true;
      }, error => console.log(error));
  };

  lagreLikerIkke() {
    const lagretLikerIkke = new SpmKlasse();

    lagretLikerIkke.id = this.Id2;
    lagretLikerIkke.likerIkke = this.ikkeLikt;

    this._http.put("api/faq/OppdaterLikerIkke", lagretLikerIkke)
      .subscribe(retur => {

        this.hentAlleSpm();
        this.visListe = true;
      }, error => console.log(error));
  };
}
