import { Component, AfterViewInit } from '@angular/core';

@Component({
    selector: 'application',
    templateUrl: '/applications/indexview',
})
export class IndexComponent implements AfterViewInit{
    constructor() {
        NProgress.start();
    }

    ngAfterViewInit(): void {
        NProgress.done();
        $("#searchResult").dataTable({});
    }
}
