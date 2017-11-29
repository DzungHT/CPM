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
var application_1 = require("../../../Models/application");
var inputModel_1 = require("../../../Models/inputModel");
var SearchComponent = (function () {
    function SearchComponent() {
        NProgress.start();
        this.application = new application_1.Application();
        this.codeInput = new inputModel_1.InputModel('Mã ứng dụng', this.application.Code, 'text', 'CodeSearch', 'Code');
    }
    SearchComponent.prototype.ngAfterViewInit = function () {
        NProgress.done();
    };
    SearchComponent.prototype.ngOnInit = function () {
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
    };
    return SearchComponent;
}());
SearchComponent = __decorate([
    core_1.Component({
        selector: 'search-application',
        templateUrl: '/applications/searchview',
    }),
    __metadata("design:paramtypes", [])
], SearchComponent);
exports.SearchComponent = SearchComponent;
//# sourceMappingURL=search.component.js.map