webpackJsonp([16],{

/***/ 133:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PortalSomethingComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var PortalSomethingComponent = (function () {
    function PortalSomethingComponent() {
    }
    PortalSomethingComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'sw-portal-something',
            //styles: [require('./something.component.scss')],
            template: __webpack_require__(141),
        })
    ], PortalSomethingComponent);
    return PortalSomethingComponent;
}());



/***/ }),

/***/ 134:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PortalSomethingModule", function() { return PortalSomethingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(8);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__something_component__ = __webpack_require__(133);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var PortalSomethingModule = (function () {
    function PortalSomethingModule() {
    }
    PortalSomethingModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild([
                    {
                        path: '',
                        component: __WEBPACK_IMPORTED_MODULE_2__something_component__["a" /* PortalSomethingComponent */],
                        children: [
                            {
                                path: '',
                                redirectTo: 'list-something',
                                pathMatch: 'full'
                            },
                            {
                                path: 'create-something',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(15).then((function (require) { resolve(__webpack_require__(128)['PortalCreateSomethingModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            },
                            {
                                path: 'list-something',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(4).then((function (require) { resolve(__webpack_require__(132)['PortalListSomethingModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            },
                            {
                                path: 'list-draft-something',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(8).then((function (require) { resolve(__webpack_require__(130)['PortalListDraftSomethingModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            }
                        ]
                    },
                ])
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_2__something_component__["a" /* PortalSomethingComponent */]
            ]
        })
    ], PortalSomethingModule);
    return PortalSomethingModule;
}());



/***/ }),

/***/ 141:
/***/ (function(module, exports) {

module.exports = "<router-outlet></router-outlet>";

/***/ })

});
//# sourceMappingURL=16.js.map