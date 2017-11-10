import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { IndexComponent } from './Components/index.component'
import { SearchComponent } from './Components/search.component'
import { InlineInputComponent } from '../../Components/inline-input.component'


const routes: Routes = [
    { path: 'applications', redirectTo: 'applications/search', pathMatch: 'full' },
    { path: 'applications/search', component: SearchComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class RoutingModule { }
