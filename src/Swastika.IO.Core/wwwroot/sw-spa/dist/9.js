webpackJsonp([9],{

/***/ 53:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FetchDataComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__(9);
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
            template: __webpack_require__(95)
        }),
        __param(1, __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])('BASE_URL')),
        __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"], String])
    ], FetchDataComponent);
    return FetchDataComponent;
}());



/***/ }),

/***/ 54:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FetchdataModule", function() { return FetchdataModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__fetchdata_component__ = __webpack_require__(53);
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

/***/ 95:
/***/ (function(module, exports) {

module.exports = "<div class=\"page-header page-header-small\">\r\n    <div class=\"page-header-image\" data-parallax=\"true\" style=\"background-image: url('../../../../themes/now-ui-kit-pro-v1.1.0/img/bg26.jpg');\">\r\n    </div>\r\n    <div class=\"content-center\">\r\n        <h1 class=\"title\">Weather forecast</h1>\r\n        <div class=\"text-center\">\r\n            <p>This component demonstrates fetching data from the server.</p>\r\n\r\n            <p *ngIf=\"!forecasts\"><em>Loading...</em></p>\r\n\r\n            <table class='table' *ngIf=\"forecasts\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Date</th>\r\n                        <th>Temp. (C)</th>\r\n                        <th>Temp. (F)</th>\r\n                        <th>Summary</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr *ngFor=\"let forecast of forecasts\">\r\n                        <td>{{ forecast.dateFormatted }}</td>\r\n                        <td>{{ forecast.temperatureC }}</td>\r\n                        <td>{{ forecast.temperatureF }}</td>\r\n                        <td>{{ forecast.summary }}</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n";

/***/ })

});
//# sourceMappingURL=9.js.map