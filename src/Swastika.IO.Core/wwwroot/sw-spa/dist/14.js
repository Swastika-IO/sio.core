webpackJsonp([14],{

/***/ 34:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return CounterComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var CounterComponent = (function () {
    function CounterComponent() {
        this.currentCount = 0;
    }
    CounterComponent.prototype.incrementCounter = function () {
        this.currentCount++;
    };
    CounterComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'counter',
            template: __webpack_require__(86)
        })
    ], CounterComponent);
    return CounterComponent;
}());



/***/ }),

/***/ 35:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CounterModule", function() { return CounterModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(9);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__counter_component__ = __webpack_require__(34);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var CounterModule = (function () {
    function CounterModule() {
    }
    CounterModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild([{ path: '', component: __WEBPACK_IMPORTED_MODULE_2__counter_component__["a" /* CounterComponent */] }])
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]],
            declarations: [__WEBPACK_IMPORTED_MODULE_2__counter_component__["a" /* CounterComponent */]]
        })
    ], CounterModule);
    return CounterModule;
}());



/***/ }),

/***/ 86:
/***/ (function(module, exports) {

module.exports = "<div class=\"page-header page-header-small\">\r\n    <div class=\"page-header-image\" data-parallax=\"true\" style=\"background-image: url('../../../../themes/now-ui-kit-pro-v1.1.0/img/bg26.jpg');\">\r\n    </div>\r\n    <div class=\"content-center\">\r\n        <h1 class=\"title\">Counter</h1>\r\n        <div class=\"text-center\">\r\n\r\n            <p>This is a simple example of an Angular component.</p>\r\n\r\n            <p>Current count: <strong>{{ currentCount }}</strong></p>\r\n\r\n            <button (click)=\"incrementCounter()\">Increment</button>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n";

/***/ })

});
//# sourceMappingURL=14.js.map