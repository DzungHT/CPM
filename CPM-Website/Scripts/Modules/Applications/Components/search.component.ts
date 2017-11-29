import { Component, OnInit, AfterViewInit } from '@angular/core';

import { Application } from '../../../Models/application'
import { InputModel } from '../../../Models/inputModel'

import { ApplicationService } from '../service'

@Component({
    selector: 'search-application',
    templateUrl: '/applications/searchview',
})
export class SearchComponent implements OnInit, AfterViewInit {
    applications: Application[];

    ngAfterViewInit(): void {
        NProgress.done();
    }
    ngOnInit(): void {
        var customerTbl = $("#searchResult").DataTable({
            ajax: {
                url: '/applications/searchProcess',
                type: 'POST'
            },
            columns: [
                {
                    searchable: false,
                    orderable: false,
                    data: null,
                    //targets: 0,
                    className: "alignCenter",
                    render: function (data, type, row, cell) {
                        var info = customerTbl.page.info();
                        var stt = 1 + (info.page * info.length) + cell.row;
                        return stt;
                    }
                },
                //{ data: 'ApplicationID' },
                { data: 'Code' },
                { data: 'Name', name: 'Tên ứng dụng' }
            ]
        });
    }
    application: Application;
    codeInput: InputModel;
    constructor() {
        NProgress.start();
        this.application = new Application();
        this.codeInput = new InputModel('Mã ứng dụng', this.application.Code, 'text', 'CodeSearch', 'Code');
    }
}
