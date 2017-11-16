import { Component } from '@angular/core';

@Component({
    selector: 'application',
    templateUrl: '/applications/indexview',
})
export class IndexComponent{
    constructor() {
        NProgress.start();
    }
}
