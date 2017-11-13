import { Component, OnInit } from '@angular/core';

import { Application } from '../../../Models/application'
import { InputModel } from '../../../Models/inputModel'

@Component({
    selector: 'search-application',
    templateUrl: '/applications/searchview',
})
export class SearchComponent implements OnInit {
    ngOnInit(): void {
        $("#searchResult").DataTable({
            
        });
    }
    application: Application;
    codeInput: InputModel;
    constructor() {
        this.application = new Application();
        this.codeInput = new InputModel('Mã ứng dụng', this.application.Code, 'text', 'CodeSearch', 'Code');
    }
}
