webpackJsonp([0],{

/***/ 102:
/***/ (function(module, exports) {

module.exports = "<!-- Header -->\r\n<sw-header></sw-header>\r\n\r\n<!-- Page Content Holder -->\r\n<div class=\"container-fluid wrapper\">\r\n    <div class=\"row flex-xl-nowrap\">\r\n        <!-- Sidebar Holder -->\r\n        <sw-sidebar></sw-sidebar>\r\n\r\n        <!-- Content Holder -->\r\n        <main class=\"py-md-3 px-md-4 sw-content\" role=\"main\">\r\n            <router-outlet></router-outlet>\r\n        </main>\r\n    </div>\r\n</div>\r\n\r\n";

/***/ }),

/***/ 109:
/***/ (function(module, exports, __webpack_require__) {


        var result = __webpack_require__(69);

        if (typeof result === "string") {
            module.exports = result;
        } else {
            module.exports = result.toString();
        }
    

/***/ }),

/***/ 110:
/***/ (function(module, exports, __webpack_require__) {


        var result = __webpack_require__(70);

        if (typeof result === "string") {
            module.exports = result;
        } else {
            module.exports = result.toString();
        }
    

/***/ }),

/***/ 118:
/***/ (function(module, exports, __webpack_require__) {


        var result = __webpack_require__(78);

        if (typeof result === "string") {
            module.exports = result;
        } else {
            module.exports = result.toString();
        }
    

/***/ }),

/***/ 119:
/***/ (function(module, exports) {

module.exports = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjwhLS0gR2VuZXJhdG9yOiBBZG9iZSBJbGx1c3RyYXRvciAyMS4wLjAsIFNWRyBFeHBvcnQgUGx1Zy1JbiAuIFNWRyBWZXJzaW9uOiA2LjAwIEJ1aWxkIDApICAtLT4NCjxzdmcgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgeD0iMHB4IiB5PSIwcHgiDQoJIHZpZXdCb3g9IjAgMCAxMjMgMTIzIiBzdHlsZT0iZW5hYmxlLWJhY2tncm91bmQ6bmV3IDAgMCAxMjMgMTIzOyIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+DQo8c3R5bGUgdHlwZT0idGV4dC9jc3MiPg0KCS5zdDB7ZmlsbDojRkZGRkZGO3N0cm9rZTojRkZGRkZGO30NCjwvc3R5bGU+DQo8cGF0aCBjbGFzcz0ic3QwIiBkPSJNNjEuNSw2MS41QzQ0LjksNTguNSwzNCw0Mi42LDM3LDI2UzU1LjktMS41LDcyLjUsMS41QzgwLjgsMyw4Ni4zLDExLDg0LjgsMTkuM1M3NS4zLDMzLDY3LDMxLjUNCglzLTE2LjIsNC0xNy44LDEyLjNTNTMuMiw2MCw2MS41LDYxLjVMNjEuNSw2MS41QzY0LjUsNDQuOSw4MC40LDM0LDk3LDM3czI3LjUsMTguOSwyNC41LDM1LjVjLTEuNSw4LjMtOS41LDEzLjgtMTcuOCwxMi4zDQoJUzkwLDc1LjMsOTEuNSw2N3MtNC0xNi4yLTEyLjMtMTcuOFM2Myw1My4yLDYxLjUsNjEuNUM3OC4xLDY0LjUsODksODAuNCw4Niw5N3MtMTguOSwyNy41LTM1LjUsMjQuNWMtOC4zLTEuNS0xMy44LTkuNS0xMi4yLTE3LjgNCglTNDcuNyw5MCw1Niw5MS41YzguMywxLjUsMTYuMi00LDE3LjgtMTIuM1M2OS44LDYzLDYxLjUsNjEuNUM1OC41LDc4LjEsNDIuNiw4OSwyNiw4NlMtMS41LDY3LjEsMS41LDUwLjVDMyw0Mi4yLDExLDM2LjcsMTkuMywzOC4zDQoJUzMzLDQ3LjcsMzEuNSw1NnM0LDE2LjIsMTIuMywxNy44UzYwLDY5LjgsNjEuNSw2MS41Ii8+DQo8L3N2Zz4NCg=="

/***/ }),

/***/ 22:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PortalModule", function() { return PortalModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__(9);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__portal_component__ = __webpack_require__(62);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__components_header_header_component__ = __webpack_require__(42);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__components_sidebar_sidebar_component__ = __webpack_require__(43);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





var PortalModule = (function () {
    function PortalModule() {
    }
    PortalModule = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"].forChild([
                    {
                        path: '',
                        component: __WEBPACK_IMPORTED_MODULE_2__portal_component__["a" /* PortalComponent */],
                        children: [
                            //{
                            //    path: '',
                            //    redirectTo: 'dashboard',
                            //    pathMatch: 'full'
                            //},
                            {
                                path: '',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(4).then((function (require) { resolve(__webpack_require__(61)['PortalDashboardModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            },
                            {
                                path: 'article',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(11).then((function (require) { resolve(__webpack_require__(53)['PortalArticleModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            },
                            {
                                path: 'blank',
                                loadChildren: function () { return new Promise(function (resolve) { __webpack_require__.e/* require.ensure */(12).then((function (require) { resolve(__webpack_require__(51)['PortalSomethingModule']); }).bind(null, __webpack_require__)).catch(__webpack_require__.oe); }); },
                            }
                        ]
                    },
                ])
            ],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["RouterModule"]],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_2__portal_component__["a" /* PortalComponent */],
                __WEBPACK_IMPORTED_MODULE_3__components_header_header_component__["a" /* HeaderComponent */],
                __WEBPACK_IMPORTED_MODULE_4__components_sidebar_sidebar_component__["a" /* SidebarComponent */],
            ]
        })
    ], PortalModule);
    return PortalModule;
}());



/***/ }),

/***/ 42:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return HeaderComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var HeaderComponent = (function () {
    function HeaderComponent() {
    }
    HeaderComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'sw-header',
            template: __webpack_require__(91),
            styles: [__webpack_require__(109)]
        })
    ], HeaderComponent);
    return HeaderComponent;
}());



/***/ }),

/***/ 43:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SidebarComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var SidebarComponent = (function () {
    function SidebarComponent() {
    }
    SidebarComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'sw-sidebar',
            template: __webpack_require__(92),
            styles: [__webpack_require__(110)]
        })
    ], SidebarComponent);
    return SidebarComponent;
}());



/***/ }),

/***/ 62:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return PortalComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(1);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var PortalComponent = (function () {
    function PortalComponent() {
    }
    PortalComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'portal',
            styles: [
                //require('./themes/swastika-io-admin/css/portal.css'),
                //require('./themes/swastika-io-admin/font/css/open-iconic-bootstrap.css'),
                __webpack_require__(118)
            ],
            template: __webpack_require__(102),
            encapsulation: __WEBPACK_IMPORTED_MODULE_0__angular_core__["ViewEncapsulation"].None
        })
    ], PortalComponent);
    return PortalComponent;
}());



/***/ }),

/***/ 69:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(8)(undefined);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/***/ }),

/***/ 70:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(8)(undefined);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/***/ }),

/***/ 78:
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(8)(undefined);
// imports


// module
exports.push([module.i, "body {\n  margin: 0; }\n\n.sw-content {\n  width: 100%; }\n", ""]);

// exports


/***/ }),

/***/ 91:
/***/ (function(module, exports, __webpack_require__) {

module.exports = "\r\n<header class=\"navbar navbar-expand navbar-dark flex-column flex-md-row sw-navbar\">\r\n\r\n    <a class=\"navbar-brand mr-0 mr-md-2\" href=\"/\" aria-label=\"Swastika I/O\">\r\n        <img src=\"" + __webpack_require__(119) + "\" alt=\"Swastika I/O\" width=\"35px\">\r\n    </a>\r\n\r\n    <button type=\"button\" id=\"sidebarCollapse\" class=\"btn btn-link\">\r\n        <span class=\"oi oi-menu\"></span>\r\n    </button>\r\n\r\n\r\n    <div class=\"navbar-nav-scroll\">\r\n\r\n        <ul class=\"navbar-nav sw-navbar-nav flex-row\">\r\n            <li class=\"nav-item\">\r\n                <a class=\"nav-link breadcrumb-item\" href=\"/\" onclick=\"\">Articles</a>\r\n            </li>\r\n            <li class=\"nav-item\">\r\n                <a class=\"nav-link active\" href=\"/\" onclick=\"\">Create</a>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n\r\n    <ul class=\"navbar-nav flex-row ml-md-auto d-none d-md-flex\">\r\n        <li class=\"nav-item dropdown\">\r\n            <a class=\"nav-item nav-link dropdown-toggle mr-md-2\" href=\"#\" id=\"sw-versions\" data-toggle=\"dropdown\" aria-haspopup=\"true\"\r\n               aria-expanded=\"false\">\r\n                Notification\r\n            </a>\r\n            <div class=\"dropdown-menu dropdown-menu-right\" aria-labelledby=\"sw-versions\">\r\n                <a class=\"dropdown-item active\" href=\"#\">Lorem...</a>\r\n                <a class=\"dropdown-item\" href=\"#\">Lorem...</a>\r\n                <a class=\"dropdown-item\" href=\"#\">Lorem...</a>\r\n                <a class=\"dropdown-item\" href=\"#\">Lorem...</a>\r\n            </div>\r\n        </li>\r\n\r\n        <li class=\"nav-item\">\r\n            <a class=\"nav-link p-2\" href=\"#\" target=\"_blank\" rel=\"noopener\" aria-label=\"GitHub\">\r\n                <svg class=\"navbar-nav-svg\" xmlns=\"http://www.w3.org/2000/svg\" viewbox=\"0 0 512 499.36\" focusable=\"false\">\r\n                    <title>GitHub</title>\r\n                    <path d=\"M256 0C114.64 0 0 114.61 0 256c0 113.09 73.34 209 175.08 242.9 12.8 2.35 17.47-5.56 17.47-12.34 0-6.08-.22-22.18-.35-43.54-71.2 15.49-86.2-34.34-86.2-34.34-11.64-29.57-28.42-37.45-28.42-37.45-23.27-15.84 1.73-15.55 1.73-15.55 25.69 1.81 39.21 26.38 39.21 26.38 22.84 39.12 59.92 27.82 74.5 21.27 2.33-16.54 8.94-27.82 16.25-34.22-56.84-6.43-116.6-28.43-116.6-126.49 0-27.95 10-50.8 26.35-68.69-2.63-6.48-11.42-32.5 2.51-67.75 0 0 21.49-6.88 70.4 26.24a242.65 242.65 0 0 1 128.18 0c48.87-33.13 70.33-26.24 70.33-26.24 14 35.25 5.18 61.27 2.55 67.75 16.41 17.9 26.31 40.75 26.31 68.69 0 98.35-59.85 120-116.88 126.32 9.19 7.9 17.38 23.53 17.38 47.41 0 34.22-.31 61.83-.31 70.23 0 6.85 4.61 14.81 17.6 12.31C438.72 464.97 512 369.08 512 256.02 512 114.62 397.37 0 256 0z\"\r\n                          fill=\"currentColor\" fill-rule=\"evenodd\" />\r\n                </svg>\r\n\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a class=\"nav-link p-2\" href=\"#\" target=\"_blank\" rel=\"noopener\" aria-label=\"Twitter\">\r\n                <svg class=\"navbar-nav-svg\" xmlns=\"http://www.w3.org/2000/svg\" viewbox=\"0 0 512 416.32\" focusable=\"false\">\r\n                    <title>Twitter</title>\r\n                    <path d=\"M160.83 416.32c193.2 0 298.92-160.22 298.92-298.92 0-4.51 0-9-.2-13.52A214 214 0 0 0 512 49.38a212.93 212.93 0 0 1-60.44 16.6 105.7 105.7 0 0 0 46.3-58.19 209 209 0 0 1-66.79 25.37 105.09 105.09 0 0 0-181.73 71.91 116.12 116.12 0 0 0 2.66 24c-87.28-4.3-164.73-46.3-216.56-109.82A105.48 105.48 0 0 0 68 159.6a106.27 106.27 0 0 1-47.53-13.11v1.43a105.28 105.28 0 0 0 84.21 103.06 105.67 105.67 0 0 1-47.33 1.84 105.06 105.06 0 0 0 98.14 72.94A210.72 210.72 0 0 1 25 370.84a202.17 202.17 0 0 1-25-1.43 298.85 298.85 0 0 0 160.83 46.92\"\r\n                          fill=\"currentColor\" />\r\n                </svg>\r\n\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a class=\"nav-link p-2\" href=\"#\" target=\"_blank\" rel=\"noopener\" aria-label=\"Slack\">\r\n                <svg class=\"navbar-nav-svg\" xmlns=\"http://www.w3.org/2000/svg\" viewbox=\"0 0 512 512\" focusable=\"false\">\r\n                    <title>Slack</title>\r\n                    <path fill=\"currentColor\" d=\"M210.787 234.832l68.31-22.883 22.1 65.977-68.309 22.882z\" />\r\n                    <path d=\"M490.54 185.6C437.7 9.59 361.6-31.34 185.6 21.46S-31.3 150.4 21.46 326.4 150.4 543.3 326.4 490.54 543.34 361.6 490.54 185.6zM401.7 299.8l-33.15 11.05 11.46 34.38c4.5 13.92-2.87 29.06-16.78 33.56-2.87.82-6.14 1.64-9 1.23a27.32 27.32 0 0 1-24.56-18l-11.46-34.38-68.36 22.92 11.46 34.38c4.5 13.92-2.87 29.06-16.78 33.56-2.87.82-6.14 1.64-9 1.23a27.32 27.32 0 0 1-24.56-18l-11.46-34.43-33.15 11.05c-2.87.82-6.14 1.64-9 1.23a27.32 27.32 0 0 1-24.56-18c-4.5-13.92 2.87-29.06 16.78-33.56l33.12-11.03-22.1-65.9-33.15 11.05c-2.87.82-6.14 1.64-9 1.23a27.32 27.32 0 0 1-24.56-18c-4.48-13.93 2.89-29.07 16.81-33.58l33.15-11.05-11.46-34.38c-4.5-13.92 2.87-29.06 16.78-33.56s29.06 2.87 33.56 16.78l11.46 34.38 68.36-22.92-11.46-34.38c-4.5-13.92 2.87-29.06 16.78-33.56s29.06 2.87 33.56 16.78l11.47 34.42 33.15-11.05c13.92-4.5 29.06 2.87 33.56 16.78s-2.87 29.06-16.78 33.56L329.7 194.6l22.1 65.9 33.15-11.05c13.92-4.5 29.06 2.87 33.56 16.78s-2.88 29.07-16.81 33.57z\"\r\n                          fill=\"currentColor\" />\r\n                </svg>\r\n\r\n            </a>\r\n        </li>\r\n\r\n        <li class=\"nav-item\">\r\n            <a class=\"nav-link p-2\" href=\"/?app=false\" id=\"sw-versions\">\r\n                Home (MVC)\r\n            </a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a class=\"nav-link p-2\" href=\"/\" id=\"sw-versions\">\r\n                Home (SPA)\r\n            </a>\r\n        </li>\r\n    </ul>\r\n    <img class=\"rounded-circle sw-avatar\" alt=\"200x200\" src=\"https://avatars1.githubusercontent.com/u/3785721?s=40&v=4\" data-holder-rendered=\"true\"\r\n         style=\"width: 36px; height: 36px;\">\r\n</header>\r\n";

/***/ }),

/***/ 92:
/***/ (function(module, exports) {

module.exports = "\r\n<div id=\"sidebar\" class=\"sw-sidebar\">\r\n    <form class=\"sw-search d-flex align-items-center\">\r\n        <input type=\"search\" class=\"form-control\" id=\"search-input\" placeholder=\"Search...\" aria-label=\"Search for...\" autocomplete=\"off\">\r\n        <button class=\"btn btn-link sw-search-docs-toggle d-md-none p-0 ml-3\" type=\"button\" data-toggle=\"collapse\" data-target=\"#sw-docs-nav\"\r\n                aria-controls=\"sw-docs-nav\" aria-expanded=\"false\" aria-label=\"Toggle docs navigation\">\r\n            <svg xmlns=\"http://www.w3.org/2000/svg\" viewbox=\"0 0 30 30\" width=\"30\" height=\"30\" focusable=\"false\">\r\n                <title>Menu</title>\r\n                <path stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-miterlimit=\"10\" d=\"M4 7h22M4 15h22M4 23h22\" />\r\n            </svg>\r\n\r\n        </button>\r\n    </form>\r\n\r\n\r\n    <nav class=\"collapse sw-links\" id=\"sw-docs-nav\">\r\n        <div class=\"sw-toc-item\">\r\n            <a routerLink=\"/portal\" class=\"sw-toc-link\">\r\n                <span class=\"oi oi-dashboard\"></span>\r\n                <span class=\"text\">Dashboard</span>\r\n            </a>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapseArticleSubMenus\" aria-expanded=\"false\" aria-controls=\"collapseArticleSubMenus\">\r\n                <span class=\"oi oi-document\"></span>\r\n                <span class=\"text\">Articles</span>\r\n            </a>\r\n            <ul id=\"collapseArticleSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a routerLink=\"/portal/article/create-article\">\r\n                        <span class=\"oi oi-plus\"></span>\r\n                        <span class=\"text\">Create Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a routerLink=\"/portal/article/list-article\">\r\n                        <span class=\"oi oi-list\"></span>\r\n                        <span class=\"text\">List Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a routerLink=\"/portal/article/list-draft-article\">\r\n                        <span class=\"oi oi-pencil\"></span>\r\n                        <span class=\"text\">Draft</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapsePageSubMenus\" aria-expanded=\"false\" aria-controls=\"collapsePageSubMenus\">\r\n                <span class=\"oi oi-browser\"></span>\r\n                <span class=\"text\">Pages</span>\r\n            </a>\r\n            <ul id=\"collapsePageSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-plus\"></span>\r\n                        <span class=\"text\">Create Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-list\"></span>\r\n                        <span class=\"text\">List Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-pencil\"></span>\r\n                        <span class=\"text\">Draft</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapseModuleSubMenus\" aria-expanded=\"false\" aria-controls=\"collapseModuleSubMenus\">\r\n                <span class=\"oi oi-puzzle-piece\"></span>\r\n                <span class=\"text\">Modules</span>\r\n            </a>\r\n            <ul id=\"collapseModuleSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-plus\"></span>\r\n                        <span class=\"text\">Create Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-list\"></span>\r\n                        <span class=\"text\">List Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-pencil\"></span>\r\n                        <span class=\"text\">Draft</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapseAppearanceSubMenus\" aria-expanded=\"false\" aria-controls=\"collapseAppearanceSubMenus\">\r\n                <span class=\"oi oi-brush\"></span>\r\n                <span class=\"text\">Appearance</span>\r\n            </a>\r\n            <ul id=\"collapseAppearanceSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-plus\"></span>\r\n                        <span class=\"text\">Create Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-list\"></span>\r\n                        <span class=\"text\">List Article</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-pencil\"></span>\r\n                        <span class=\"text\">Draft</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapseFileSubMenus\" aria-expanded=\"false\" aria-controls=\"collapseFileSubMenus\">\r\n                <span class=\"oi oi-image\"></span>\r\n                <span class=\"text\">Medias</span>\r\n            </a>\r\n            <ul id=\"collapseFileSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-image\"></span>\r\n                        <span class=\"text\">Medias</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-file\"></span>\r\n                        <span class=\"text\">Files</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"sw-toc-item\">\r\n            <a class=\"sw-toc-link\" data-toggle=\"collapse\" href=\"#collapseSettingSubMenus\" aria-expanded=\"false\" aria-controls=\"collapseSettingSubMenus\">\r\n                <span class=\"oi oi-wrench\"></span>\r\n                <span class=\"text\">Settings</span>\r\n            </a>\r\n            <ul id=\"collapseSettingSubMenus\" class=\"collapse list-unstyled\">\r\n                <li class=\"active sw-sidenav-active\">\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-list\"></span>\r\n                        <span class=\"text\">Configurations</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a href=\"#\">\r\n                        <span class=\"oi oi-globe\"></span>\r\n                        <span class=\"text\">Cultures</span>\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n</div>\r\n";

/***/ })

});
//# sourceMappingURL=0.js.map