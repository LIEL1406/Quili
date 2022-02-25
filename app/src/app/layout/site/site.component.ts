import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as feather from 'feather-icons';
import { CookieService } from 'ngx-cookie-service';
import { SavedRecipesService } from 'src/app/services/saved-recipes.service';

@Component({
  selector: 'app-site',
  templateUrl: './site.component.html',
  styleUrls: ['./site.component.css']
})
export class SiteComponent implements OnInit {

  public user: string;
  public numSaved: number; 

  constructor(
    private cookies: CookieService, 
    public router: Router,
    public saved: SavedRecipesService) { 
    this.user = this.cookies.get('Token');
    saved.GetSavedRecipes().subscribe(
      (res: any) => {
        if(res.Status)
          this.numSaved = (res.Data as []).length;
      })
  }

  ngOnInit(): void {
    feather.replace();
  }

  public logOut(){
    this.cookies.delete('Token');
    this.router.navigate(['/'])
  }
}
