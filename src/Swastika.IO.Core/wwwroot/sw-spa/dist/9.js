webpackJsonp([9],{

/***/ 38:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FetchDataComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__(10);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};


var FetchDataComponent = (function () {
    function FetchDataComponent(http, baseUrl) {
        var _this = this;
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(function (result) {
            _this.forecasts = result.json();
        }, function (error) { return console.error(error); });
    }
    FetchDataComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'fetchdata',
            template: __webpack_require__(81)
        }),
        __param(1, __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])('BASE_URL')),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"], String])
    ], FetchDataComponent);
    return FetchDataComponent;
}());



/***/ }),

/***/ 39:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FetchdataModule", function() { return FetchdataModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(9);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__fetchdata_component__ = __webpack_require__(38);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var FetchdataModule = (function () {
    function FetchdataModule() {
    }
    FetchdataModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild([{ path: '', component: __WEBPACK_IMPORTED_MODULE_2__fetchdata_component__["a" /* FetchDataComponent */] }])
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__fetchdata_component__["a" /* FetchDataComponent */]]
        })
    ], FetchdataModule);
    return FetchdataModule;
}());



/***/ }),

/***/ 81:
/***/ (function(module, exports) {

module.exports = "<div class=\"page-header page-header-small\">\n    <div class=\"page-header-image\" data-parallax=\"true\" style=\"background-image: url('../../../../themes/now-ui-kit-pro-v1.1.0/img/bg26.jpg');\">\n    </div>\n    <div class=\"content-center\">\n        <h1 class=\"title\">Weather forecast</h1>\n        <div class=\"text-center\">\n            <p>This component demonstrates fetching data from the server.</p>\n\n            <p *ngIf=\"!forecasts\"><em>Loading...</em></p>\n\n            <table class='table' *ngIf=\"forecasts\">\n                <thead>\n                    <tr>\n                        <th>Date</th>\n                        <th>Temp. (C)</th>\n                        <th>Temp. (F)</th>\n                        <th>Summary</th>\n                    </tr>\n                </thead>\n                <tbody>\n                    <tr *ngFor=\"let forecast of forecasts\">\n                        <td>{{ forecast.dateFormatted }}</td>\n                        <td>{{ forecast.temperatureC }}</td>\n                        <td>{{ forecast.temperatureF }}</td>\n                        <td>{{ forecast.summary }}</td>\n                    </tr>\n                </tbody>\n            </table>\n\n        </div>\n    </div>\n</div>\n";

/***/ })

});
//# sourceMappingURL=9.js.map