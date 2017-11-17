import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { RoutingModule } from './routing.module'

import { IndexComponent } from './Components/index.component'
import { SearchComponent } from './Components/search.component'
import { InlineInputComponent } from '../../Components/inline-input.component'

//import { ApplicationService } from './service'


@NgModule({
    imports: [
        BrowserModule
        , FormsModule
        , RoutingModule
    ],
    declarations: [
        IndexComponent
        , SearchComponent
        , InlineInputComponent
    ],
    //providers: [ApplicationService],
    bootstrap: [IndexComponent]
})
export class ApplicationModule { }
