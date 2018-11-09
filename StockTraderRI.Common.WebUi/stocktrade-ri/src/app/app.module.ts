import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';

import { StocktradeModule } from './stocktrade/stocktrade.module';
import { CoreModule } from './core/core.module';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), // TODO???
    AppRoutingModule, // because of route which i should use  in the app
    BrowserAnimationsModule, // TODO--> because of  ToastrModule module see website for more info
    HttpClientModule, // Tod use http strategy like httClient
    FormsModule,

    ToastrModule.forRoot(), // for Toast mechanic
    CoreModule,
    StocktradeModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
