import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { RoutingModule } from './routing.module'

import { IndexComponent } from './Components/index.component'
import { SearchComponent } from './Components/search.component'
import { InlineInputComponent } from '../../Components/inline-input.component'


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
    bootstrap: [IndexComponent]
})
export class ApplicationModule { }
