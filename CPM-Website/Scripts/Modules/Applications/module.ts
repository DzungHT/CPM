import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { RoutingModule } from './routing.module'

import { IndexComponent } from './Components/index.component'
import { SearchComponent } from './Components/search.component'

//import { ApplicationService } from './service'


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        RoutingModule,
        HttpClientModule
    ],
    declarations: [
        IndexComponent
        , SearchComponent
    ],
    //providers: [ApplicationService],
    bootstrap: [IndexComponent]
})
export class ApplicationModule { }
