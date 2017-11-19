webpackJsonp([1],{

/***/ 37:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FrontModule", function() { return FrontModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__front_component__ = __webpack_require__(40);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



//import { HeaderComponent } from '../../components/modules/front/header/header.component';
//import { FeaturesComponent } from '../../components/modules/front/features/features.component';
var FrontModule = (function () {
    function FrontModule() {
    }
    FrontModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild([{ path: '', component: __WEBPACK_IMPORTED_MODULE_2__front_component__["a" /* FrontComponent */] }])
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_2__front_component__["a" /* FrontComponent */],
            ]
        })
    ], FrontModule);
    return FrontModule;
}());



/***/ }),

/***/ 40:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return FrontComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var FrontComponent = (function () {
    function FrontComponent() {
    }
    FrontComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'front',
            template: __webpack_require__(63)
        })
    ], FrontComponent);
    return FrontComponent;
}());



/***/ }),

/***/ 63:
/***/ (function(module, exports) {

module.exports = "ANGULAR HOME\r\n<br />\r\n<br />\r\n    <a [routerLink]=\"['/portal']\">Portal</a> | <a href=\"/?app=false\">MVC Site</a> | <a href=\"/ngx-admin?app=false\">ngx-admin</a>";

/***/ })

});
//# sourceMappingURL=1.js.map