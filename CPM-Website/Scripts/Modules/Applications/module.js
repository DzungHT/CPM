"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var angular_datatables_1 = require("angular-datatables");
var routing_module_1 = require("./routing.module");
var index_component_1 = require("./Components/index.component");
var search_component_1 = require("./Components/search.component");
var inline_input_component_1 = require("../../Components/inline-input.component");
var ApplicationModule = (function () {
    function ApplicationModule() {
    }
    return ApplicationModule;
}());
ApplicationModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            routing_module_1.RoutingModule,
            angular_datatables_1.DataTablesModule
        ],
        declarations: [
            index_component_1.IndexComponent,
            search_component_1.SearchComponent,
            inline_input_component_1.InlineInputComponent
        ],
        bootstrap: [index_component_1.IndexComponent]
    })
], ApplicationModule);
exports.ApplicationModule = ApplicationModule;
//# sourceMappingURL=module.js.map