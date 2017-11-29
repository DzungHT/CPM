"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
//import { ApplicationService } from '../service';
var URL_SEARCH = 'applications/searchProcess';
var SearchComponent = (function () {
    function SearchComponent(http) {
        this.http = http;
        NProgress.start();
        this.frmData = new FormData();
    }
    SearchComponent.prototype.ngAfterViewInit = function () {
        NProgress.done();
    };
    SearchComponent.prototype.ngOnInit = function () {
        var frmData = this.frmData;
        var dataTable = $("#searchResult").DataTable({
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
                        return "<a href=\"javascript:;\" class=\"text-success\" style=\"margin-right: 7px\">\n                                    <i class=\"fa fa-edit fa-2x\" title=\"S\u1EEDa\"></i>\n                                </a>\n                                <a href=\"javascript:;\" class=\"red\">\n                                    <i class=\"fa fa-remove fa-2x\" title=\"X\u00F3a\"></i>\n                                </a>";
                    }
                },
                { data: 'Code', className: "text-center" },
                { data: 'Name' }
            ]
        });
        this.dataTable = dataTable;
    };
    SearchComponent.prototype.search = function () {
        this.dataTable.ajax.reload();
    };
    return SearchComponent;
}());
SearchComponent = __decorate([
    core_1.Component({
        selector: 'search-application',
        templateUrl: '/applications/searchview',
    }),
    __metadata("design:paramtypes", [http_1.HttpClient])
], SearchComponent);
exports.SearchComponent = SearchComponent;
var FormData = (function () {
    function FormData() {
    }
    return FormData;
}());
//# sourceMappingURL=search.component.js.map