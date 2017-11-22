import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Application } from '../../../Models/application'

import { ApplicationService } from '../service'

@Component({
    selector: 'search-application',
    templateUrl: '/applications/searchview',
})
export class SearchComponent implements OnInit, AfterViewInit {
    applications: Application[];
    application: Application;
    searchForm: FormGroup;

    ngAfterViewInit(): void {
        NProgress.done();
    }
    ngOnInit(): void {
        var customerTbl = $("#searchResult").DataTable({
            ajax: {
                url: '/applications/searchProcess',
                type: 'POST',
                data: function (d) {
                    //console.log(this);
                    return { Code: 'sdf', Name: '123', DataTable: d };
                }
            },
            columns: [
                {
                    searchable: false,
                    orderable: false,
                    data: null,
                    //targets: 0,
                    className: "text-center",
                    render: function (data, type, row, cell) {
                        var info = customerTbl.page.info();
                        var stt = 1 + (info.page * info.length) + cell.row;
                        return stt;
                    }
                },
                //{ data: 'ApplicationID' },
                {
                    data: 'Code',
                    className: "text-center"
                },
                { data: 'Name', name: 'Tên ứng dụng' }
            ]
        });
    }
    constructor() {
        NProgress.start();
        this.application = new Application();

        this.searchForm = new FormGroup({
            Code: new FormControl(),
            Name: new FormControl()
        });
    }

    search(): void {
        console.log(this.searchForm.value);
    }
}
