import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [HomeComponent, NavMenuComponent],
  imports: [
    CommonModule,
    NgbModule,
    SharedModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent, pathMatch: 'full' },

    ])
  ],

  exports: [NavMenuComponent]
})
export class CoreModule { }
