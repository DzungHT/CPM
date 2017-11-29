import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";

import { Application } from '../../../Models/application';

//import { ApplicationService } from '../service';

const URL_SEARCH = 'applications/searchProcess';

@Component({
    selector: 'search-application',
    templateUrl: '/applications/searchview',
})
export class SearchComponent implements OnInit, AfterViewInit {
    applications: Application[];
    application: Application;
    searchForm: FormGroup;
    dataTable: DataTables.Api;
    frmData: FormData;

    ngAfterViewInit(): void {
        NProgress.done();
    }
    ngOnInit(): void {
        let frmData = this.frmData;
        let dataTable = $("#searchResult").DataTable({
            order: [[2, "asc"]],
            ajax: {
                url: '/applications/searchProcess',
                type: 'POST',
                data: function (d) {
                    frmData.DataTable = d;
                    return frmData;
                }
            },
            columns: [
                {
                    searchable: false,
                    orderable: false,
                    data: null,
                    className: "text-center",
                    render: function (data, type, row, cell) {
                        var info = dataTable.page.info();
                        var stt = 1 + (info.page * info.length) + cell.row;
                        return stt;
                    }
                },
                {
                    searchable: false,
                    orderable: false,
                    data: null,
                    className: "text-center",
                    render: function (data, type, row, cell) {
                        return `<a href="javascript:;" class="text-success" style="margin-right: 7px">
                                    <i class="fa fa-edit fa-2x" title="Sửa"></i>
                                </a>
                                <a href="javascript:;" class="red">
                                    <i class="fa fa-remove fa-2x" title="Xóa"></i>
                                </a>`;
                    }
                },
                { data: 'Code', className: "text-center" },
                { data: 'Name'}
            ]
        });
        this.dataTable = dataTable;
    }
    constructor(private http: HttpClient) {
        NProgress.start();

        this.frmData = new FormData();
    }

    search(): void {
        this.dataTable.ajax.reload();
    }
}

class FormData {
    Code: string;
    Name: string;
    DataTable: any;
}
