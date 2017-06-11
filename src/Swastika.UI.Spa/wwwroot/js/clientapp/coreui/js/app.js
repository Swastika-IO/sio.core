webpackJsonp([1],{

/***/ 227:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(6);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_router__ = __webpack_require__(544);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__containers_Full__ = __webpack_require__(489);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__containers_Full___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__containers_Full__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__views_Dashboard__ = __webpack_require__(491);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__views_Dashboard___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3__views_Dashboard__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__views_Charts__ = __webpack_require__(490);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__views_Charts___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4__views_Charts__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__views_Widgets__ = __webpack_require__(492);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__views_Widgets___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5__views_Widgets__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__views_components_Buttons__ = __webpack_require__(499);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__views_components_Buttons___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_6__views_components_Buttons__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__views_components_SocialButtons__ = __webpack_require__(503);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__views_components_SocialButtons___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_7__views_components_SocialButtons__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__views_components_Cards__ = __webpack_require__(500);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__views_components_Cards___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_8__views_components_Cards__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__views_components_Forms__ = __webpack_require__(501);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__views_components_Forms___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_9__views_components_Forms__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__views_components_Modals__ = __webpack_require__(502);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__views_components_Modals___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_10__views_components_Modals__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__views_components_Switches__ = __webpack_require__(504);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__views_components_Switches___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_11__views_components_Switches__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__views_components_Tables__ = __webpack_require__(505);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__views_components_Tables___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_12__views_components_Tables__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__views_icons_FontAwesome__ = __webpack_require__(512);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__views_icons_FontAwesome___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_13__views_icons_FontAwesome__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__views_icons_SimpleLineIcons__ = __webpack_require__(513);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14__views_icons_SimpleLineIcons___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_14__views_icons_SimpleLineIcons__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__views_pages_Page404__ = __webpack_require__(515);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__views_pages_Page404___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_15__views_pages_Page404__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__views_pages_Page500__ = __webpack_require__(516);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_16__views_pages_Page500___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_16__views_pages_Page500__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__views_pages_Login__ = __webpack_require__(514);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_17__views_pages_Login___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_17__views_pages_Login__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_18__views_pages_Register__ = __webpack_require__(517);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_18__views_pages_Register___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_18__views_pages_Register__);



// Containers


// Views




// Views - Components








// Views - Icons



// Views - Pages





__WEBPACK_IMPORTED_MODULE_0_vue__["default"].use(__WEBPACK_IMPORTED_MODULE_1_vue_router__["a" /* default */])

/* harmony default export */ __webpack_exports__["a"] = (new __WEBPACK_IMPORTED_MODULE_1_vue_router__["a" /* default */]({
  mode: 'hash', // Demo is living in GitHub.io, so required!
  linkActiveClass: 'open active',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    {
      path: '/',
      redirect: '/dashboard',
      name: 'Home',
      component: __WEBPACK_IMPORTED_MODULE_2__containers_Full___default.a,
      children: [
        {
          path: 'dashboard',
          name: 'Dashboard',
          component: __WEBPACK_IMPORTED_MODULE_3__views_Dashboard___default.a
        },
        {
          path: 'charts',
          name: 'Charts',
          component: __WEBPACK_IMPORTED_MODULE_4__views_Charts___default.a
        },
        {
          path: 'widgets',
          name: 'Widgets',
          component: __WEBPACK_IMPORTED_MODULE_5__views_Widgets___default.a
        },
        {
          path: 'components',
          redirect: '/components/buttons',
          name: 'Components',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'buttons',
              name: 'Buttons',
              component: __WEBPACK_IMPORTED_MODULE_6__views_components_Buttons___default.a
            },
            {
              path: 'social-buttons',
              name: 'Social Buttons',
              component: __WEBPACK_IMPORTED_MODULE_7__views_components_SocialButtons___default.a
            },
            {
              path: 'cards',
              name: 'Cards',
              component: __WEBPACK_IMPORTED_MODULE_8__views_components_Cards___default.a
            },
            {
              path: 'forms',
              name: 'Forms',
              component: __WEBPACK_IMPORTED_MODULE_9__views_components_Forms___default.a
            },
            {
              path: 'modals',
              name: 'Modals',
              component: __WEBPACK_IMPORTED_MODULE_10__views_components_Modals___default.a
            },
            {
              path: 'switches',
              name: 'Switches',
              component: __WEBPACK_IMPORTED_MODULE_11__views_components_Switches___default.a
            },
            {
              path: 'tables',
              name: 'Tables',
              component: __WEBPACK_IMPORTED_MODULE_12__views_components_Tables___default.a
            }
          ]
        },
        {
          path: 'icons',
          redirect: '/icons/font-awesome',
          name: 'Icons',
          component: {
            render (c) { return c('router-view') }
          },
          children: [
            {
              path: 'font-awesome',
              name: 'Font Awesome',
              component: __WEBPACK_IMPORTED_MODULE_13__views_icons_FontAwesome___default.a
            },
            {
              path: 'simple-line-icons',
              name: 'Simple Line Icons',
              component: __WEBPACK_IMPORTED_MODULE_14__views_icons_SimpleLineIcons___default.a
            }
          ]
        }
      ]
    },
    {
      path: '/pages',
      redirect: '/pages/p404',
      name: 'Pages',
      component: {
        render (c) { return c('router-view') }
      },
      children: [
        {
          path: '404',
          name: 'Page404',
          component: __WEBPACK_IMPORTED_MODULE_15__views_pages_Page404___default.a
        },
        {
          path: '500',
          name: 'Page500',
          component: __WEBPACK_IMPORTED_MODULE_16__views_pages_Page500___default.a
        },
        {
          path: 'login',
          name: 'Login',
          component: __WEBPACK_IMPORTED_MODULE_17__views_pages_Login___default.a
        },
        {
          path: 'register',
          name: 'Register',
          component: __WEBPACK_IMPORTED_MODULE_18__views_pages_Register___default.a
        }
      ]
    }
  ]
}));


/***/ }),

/***/ 228:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(230),
  /* template */
  __webpack_require__(537),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 229:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(6);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__App__ = __webpack_require__(228);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__App___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__App__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__router__ = __webpack_require__(227);
// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.




/* eslint-disable no-new */
new __WEBPACK_IMPORTED_MODULE_0_vue__["default"]({
    el: '#app',
    router: __WEBPACK_IMPORTED_MODULE_2__router__["a" /* default */],
    template: '<App/>',
    components: { App: __WEBPACK_IMPORTED_MODULE_1__App___default.a }
})

/***/ }),

/***/ 230:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
    name: 'app'
});

/***/ }),

/***/ 231:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'aside'
});

/***/ }),

/***/ 232:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  props: {
    list: {
      type: Array,
      required: true,
      default: function _default() {
        return [];
      }
    },
    separator: String
  },
  methods: {
    isLast: function isLast(index) {
      return index === this.list.length - 1;
    },
    showName: function showName(item) {
      if (item.meta && item.meta.label) {
        item = item.meta && item.meta.label;
      }
      if (item.name) {
        item = item.name;
      }
      return item;
    }
  }
});

/***/ }),

/***/ 233:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'footer'
});

/***/ }),

/***/ 234:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Navbar__ = __webpack_require__(487);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Navbar___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__Navbar__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_strap__ = __webpack_require__(57);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_strap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_strap__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//





/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'header',
  components: {
    navbar: __WEBPACK_IMPORTED_MODULE_0__Navbar___default.a,
    dropdown: __WEBPACK_IMPORTED_MODULE_1_vue_strap__["dropdown"]
  },
  methods: {
    click: function click() {
      // do nothing
    },
    sidebarToggle: function sidebarToggle(e) {
      e.preventDefault();
      document.body.classList.toggle('sidebar-hidden');
    },
    sidebarMinimize: function sidebarMinimize(e) {
      e.preventDefault();
      document.body.classList.toggle('sidebar-minimized');
    },
    mobileSidebarToggle: function mobileSidebarToggle(e) {
      e.preventDefault();
      document.body.classList.toggle('sidebar-mobile-show');
    },
    asideToggle: function asideToggle(e) {
      e.preventDefault();
      document.body.classList.toggle('aside-menu-hidden');
    }
  }
});

/***/ }),

/***/ 235:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'navbar',
  created: function created() {
    this._navbar = true;
  }
});

/***/ }),

/***/ 236:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//


/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'sidebar',
  methods: {
    handleClick: function handleClick(e) {
      e.preventDefault();
      e.target.parentElement.classList.toggle('open');
    }
  }
});

/***/ }),

/***/ 237:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__components_Header__ = __webpack_require__(486);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__components_Header___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__components_Header__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__components_Sidebar__ = __webpack_require__(488);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__components_Sidebar___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__components_Sidebar__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__components_Aside__ = __webpack_require__(483);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__components_Aside___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__components_Aside__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__components_Footer__ = __webpack_require__(485);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__components_Footer___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3__components_Footer__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__components_Breadcrumb__ = __webpack_require__(484);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__components_Breadcrumb___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4__components_Breadcrumb__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//







/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'full',
  components: {
    AppHeader: __WEBPACK_IMPORTED_MODULE_0__components_Header___default.a,
    Sidebar: __WEBPACK_IMPORTED_MODULE_1__components_Sidebar___default.a,
    AppAside: __WEBPACK_IMPORTED_MODULE_2__components_Aside___default.a,
    AppFooter: __WEBPACK_IMPORTED_MODULE_3__components_Footer___default.a,
    Breadcrumb: __WEBPACK_IMPORTED_MODULE_4__components_Breadcrumb___default.a
  },
  computed: {
    name: function name() {
      return this.$route.name;
    },
    list: function list() {
      return this.$route.matched;
    }
  }
});

/***/ }),

/***/ 238:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__charts_BarExample__ = __webpack_require__(493);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__charts_BarExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__charts_BarExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__charts_LineExample__ = __webpack_require__(495);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__charts_LineExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__charts_LineExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__charts_DoughnutExample__ = __webpack_require__(494);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__charts_DoughnutExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__charts_DoughnutExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__charts_RadarExample__ = __webpack_require__(498);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__charts_RadarExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3__charts_RadarExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__charts_PieExample__ = __webpack_require__(496);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__charts_PieExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4__charts_PieExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__charts_PolarAreaExample__ = __webpack_require__(497);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__charts_PolarAreaExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5__charts_PolarAreaExample__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//









/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'charts',
  components: {
    BarExample: __WEBPACK_IMPORTED_MODULE_0__charts_BarExample___default.a,
    LineExample: __WEBPACK_IMPORTED_MODULE_1__charts_LineExample___default.a,
    DoughnutExample: __WEBPACK_IMPORTED_MODULE_2__charts_DoughnutExample___default.a,
    RadarExample: __WEBPACK_IMPORTED_MODULE_3__charts_RadarExample___default.a,
    PieExample: __WEBPACK_IMPORTED_MODULE_4__charts_PieExample___default.a,
    PolarAreaExample: __WEBPACK_IMPORTED_MODULE_5__charts_PolarAreaExample___default.a
  }
});

/***/ }),

/***/ 239:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__dashboard_CardLine1ChartExample__ = __webpack_require__(507);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__dashboard_CardLine1ChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__dashboard_CardLine1ChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__dashboard_CardLine2ChartExample__ = __webpack_require__(508);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__dashboard_CardLine2ChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__dashboard_CardLine2ChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__dashboard_CardLine3ChartExample__ = __webpack_require__(509);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__dashboard_CardLine3ChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2__dashboard_CardLine3ChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__dashboard_CardBarChartExample__ = __webpack_require__(506);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__dashboard_CardBarChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3__dashboard_CardBarChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__dashboard_MainChartExample__ = __webpack_require__(510);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__dashboard_MainChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4__dashboard_MainChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__dashboard_SocialBoxChartExample__ = __webpack_require__(511);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__dashboard_SocialBoxChartExample___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5__dashboard_SocialBoxChartExample__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_vue_strap__ = __webpack_require__(57);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_vue_strap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_6_vue_strap__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//










/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'dashboard',
  components: {
    CardLine1ChartExample: __WEBPACK_IMPORTED_MODULE_0__dashboard_CardLine1ChartExample___default.a,
    CardLine2ChartExample: __WEBPACK_IMPORTED_MODULE_1__dashboard_CardLine2ChartExample___default.a,
    CardLine3ChartExample: __WEBPACK_IMPORTED_MODULE_2__dashboard_CardLine3ChartExample___default.a,
    CardBarChartExample: __WEBPACK_IMPORTED_MODULE_3__dashboard_CardBarChartExample___default.a,
    MainChartExample: __WEBPACK_IMPORTED_MODULE_4__dashboard_MainChartExample___default.a,
    SocialBoxChartExample: __WEBPACK_IMPORTED_MODULE_5__dashboard_SocialBoxChartExample___default.a,
    dropdown: __WEBPACK_IMPORTED_MODULE_6_vue_strap__["dropdown"]
  }
});

/***/ }),

/***/ 240:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'widgets',
  data: function data() {
    return {
      msg: 'Widgets'
    };
  }
});

/***/ }),

/***/ 241:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Bar"].extend({
  mounted: function mounted() {
    // Overwriting base render method with actual data.
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
      datasets: [{
        label: 'GitHub Commits',
        backgroundColor: '#f87979',
        data: [40, 20, 12, 39, 10, 40, 39, 80, 40, 20, 12, 11]
      }]
    });
  }
}));

/***/ }),

/***/ 242:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Doughnut"].extend({
  mounted: function mounted() {
    this.renderChart({
      labels: ['VueJs', 'EmberJs', 'ReactJs', 'AngularJs'],
      datasets: [{
        backgroundColor: ['#41B883', '#E46651', '#00D8FF', '#DD1B16'],
        data: [40, 20, 80, 10]
      }]
    }, { responsive: true, maintainAspectRatio: false });
  }
}));

/***/ }),

/***/ 243:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  mounted: function mounted() {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [{
        label: 'Data One',
        backgroundColor: '#f87979',
        data: [40, 39, 10, 40, 39, 80, 40]
      }]
    }, { responsive: true, maintainAspectRatio: false });
  }
}));

/***/ }),

/***/ 244:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Pie"].extend({
  mounted: function mounted() {
    this.renderChart({
      labels: ['VueJs', 'EmberJs', 'ReactJs', 'AngularJs'],
      datasets: [{
        backgroundColor: ['#41B883', '#E46651', '#00D8FF', '#DD1B16'],
        data: [40, 20, 80, 10]
      }]
    }, { responsive: true, maintainAspectRatio: false });
  }
}));

/***/ }),

/***/ 245:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["PolarArea"].extend({
  mounted: function mounted() {
    this.renderChart({
      labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
      datasets: [{
        label: 'My First dataset',
        backgroundColor: 'rgba(179,181,198,0.2)',
        pointBackgroundColor: 'rgba(179,181,198,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(179,181,198,1)',
        data: [65, 59, 90, 81, 56, 55, 40]
      }, {
        label: 'My Second dataset',
        backgroundColor: 'rgba(255,99,132,0.2)',
        pointBackgroundColor: 'rgba(255,99,132,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(255,99,132,1)',
        data: [28, 48, 40, 19, 96, 27, 100]
      }]
    }, { responsive: true, maintainAspectRatio: false });
  }
}));

/***/ }),

/***/ 246:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Radar"].extend({
  mounted: function mounted() {
    this.renderChart({
      labels: ['Eating', 'Drinking', 'Sleeping', 'Designing', 'Coding', 'Cycling', 'Running'],
      datasets: [{
        label: 'My First dataset',
        backgroundColor: 'rgba(179,181,198,0.2)',
        borderColor: 'rgba(179,181,198,1)',
        pointBackgroundColor: 'rgba(179,181,198,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(179,181,198,1)',
        data: [65, 59, 90, 81, 56, 55, 40]
      }, {
        label: 'My Second dataset',
        backgroundColor: 'rgba(255,99,132,0.2)',
        borderColor: 'rgba(255,99,132,1)',
        pointBackgroundColor: 'rgba(255,99,132,1)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgba(255,99,132,1)',
        data: [28, 48, 40, 19, 96, 27, 100]
      }]
    }, { responsive: true, maintainAspectRatio: false });
  }
}));

/***/ }),

/***/ 247:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'buttons'
});

/***/ }),

/***/ 248:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'cards'
});

/***/ }),

/***/ 249:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_strap__ = __webpack_require__(57);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_strap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_strap__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//




/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'fomrs',
  components: {
    dropdown: __WEBPACK_IMPORTED_MODULE_0_vue_strap__["dropdown"]
  },
  methods: {
    click: function click() {
      // do nothing
    }
  }
});

/***/ }),

/***/ 250:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_strap_src_Modal__ = __webpack_require__(518);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_strap_src_Modal___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_strap_src_Modal__);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//



/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'modals',
  components: {
    modal: __WEBPACK_IMPORTED_MODULE_0_vue_strap_src_Modal___default.a
  },
  data: function data() {
    return {
      myModal: false,
      largeModal: false,
      smallModal: false,
      primaryModal: false,
      successModal: false,
      warningModal: false,
      dangerModal: false,
      infoModal: false
    };
  }
});

/***/ }),

/***/ 251:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'social-buttons'
});

/***/ }),

/***/ 252:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'switches'
});

/***/ }),

/***/ 253:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'tables'
});

/***/ }),

/***/ 254:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



var datasets = [{
  label: 'My First dataset',
  backgroundColor: 'rgba(255,255,255,.3)',
  borderColor: 'transparent',
  data: [78, 81, 80, 45, 34, 12, 40, 75, 34, 89, 32, 68, 54, 72, 18, 98]
}];

/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Bar"].extend({
  props: ['height'],
  mounted: function mounted() {
    this.renderChart({
      labels: ['', '', '', '', '', '', '', '', '', '', '', '', '', '', '', ''],
      datasets: datasets
    }, {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          display: false,
          categoryPercentage: 1,
          barPercentage: 0.5
        }],
        yAxes: [{
          display: false
        }]
      }
    });
  }
}));

/***/ }),

/***/ 255:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



var brandPrimary = '#20a8d8';
var datasets = [{
  label: 'My First dataset',
  backgroundColor: brandPrimary,
  borderColor: 'rgba(255,255,255,.55)',
  data: [65, 59, 84, 84, 51, 55, 40]
}];

/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  props: ['height'],
  mounted: function mounted() {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: datasets
    }, {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          gridLines: {
            color: 'transparent',
            zeroLineColor: 'transparent'
          },
          ticks: {
            fontSize: 2,
            fontColor: 'transparent'
          }
        }],
        yAxes: [{
          display: false,
          ticks: {
            display: false,
            min: Math.min.apply(Math, datasets[0].data) - 5,
            max: Math.max.apply(Math, datasets[0].data) + 5
          }
        }]
      },
      elements: {
        line: {
          borderWidth: 1
        },
        point: {
          radius: 4,
          hitRadius: 10,
          hoverRadius: 4
        }
      }
    });
  }
}));

/***/ }),

/***/ 256:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



var brandInfo = '#63c2de';
var datasets = [{
  label: 'My First dataset',
  backgroundColor: brandInfo,
  borderColor: 'rgba(255,255,255,.55)',
  data: [1, 18, 9, 17, 34, 22, 11]
}];

/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  props: ['height'],
  mounted: function mounted() {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: datasets
    }, {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          gridLines: {
            color: 'transparent',
            zeroLineColor: 'transparent'
          },
          ticks: {
            fontSize: 2,
            fontColor: 'transparent'
          }

        }],
        yAxes: [{
          display: false,
          ticks: {
            display: false,
            min: Math.min.apply(Math, datasets[0].data) - 5,
            max: Math.max.apply(Math, datasets[0].data) + 5
          }
        }]
      },
      elements: {
        line: {
          tension: 0.00001,
          borderWidth: 1
        },
        point: {
          radius: 4,
          hitRadius: 10,
          hoverRadius: 4
        }
      }
    });
  }
}));

/***/ }),

/***/ 257:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



var datasets = [{
  label: 'My First dataset',
  backgroundColor: 'rgba(255,255,255,.2)',
  borderColor: 'rgba(255,255,255,.55)',
  data: [78, 81, 80, 45, 34, 12, 40]
}];

/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  props: ['height'],
  mounted: function mounted() {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: datasets
    }, {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          display: false
        }],
        yAxes: [{
          display: false
        }]
      },
      elements: {
        line: {
          borderWidth: 2
        },
        point: {
          radius: 0,
          hitRadius: 10,
          hoverRadius: 4
        }
      }
    });
  }
}));

/***/ }),

/***/ 258:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



// const brandPrimary = '#20a8d8'
var brandSuccess = '#4dbd74';
var brandInfo = '#63c2de';
var brandDanger = '#f86c6b';

function convertHex(hex, opacity) {
  hex = hex.replace('#', '');
  var r = parseInt(hex.substring(0, 2), 16);
  var g = parseInt(hex.substring(2, 4), 16);
  var b = parseInt(hex.substring(4, 6), 16);

  var result = 'rgba(' + r + ',' + g + ',' + b + ',' + opacity / 100 + ')';
  return result;
}

function random(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  props: ['height'],
  mounted: function mounted() {
    var elements = 27;
    var data1 = [];
    var data2 = [];
    var data3 = [];

    for (var i = 0; i <= elements; i++) {
      data1.push(random(50, 200));
      data2.push(random(80, 100));
      data3.push(65);
    }
    this.renderChart({
      labels: ['M', 'T', 'W', 'T', 'F', 'S', 'S', 'M', 'T', 'W', 'T', 'F', 'S', 'S', 'M', 'T', 'W', 'T', 'F', 'S', 'S', 'M', 'T', 'W', 'T', 'F', 'S', 'S'],
      datasets: [{
        label: 'My First dataset',
        backgroundColor: convertHex(brandInfo, 10),
        borderColor: brandInfo,
        pointHoverBackgroundColor: '#fff',
        borderWidth: 2,
        data: data1
      }, {
        label: 'My Second dataset',
        backgroundColor: 'transparent',
        borderColor: brandSuccess,
        pointHoverBackgroundColor: '#fff',
        borderWidth: 2,
        data: data2
      }, {
        label: 'My Third dataset',
        backgroundColor: 'transparent',
        borderColor: brandDanger,
        pointHoverBackgroundColor: '#fff',
        borderWidth: 1,
        borderDash: [8, 5],
        data: data3
      }]
    }, {
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          gridLines: {
            drawOnChartArea: false
          }
        }],
        yAxes: [{
          ticks: {
            beginAtZero: true,
            maxTicksLimit: 5,
            stepSize: Math.ceil(250 / 5),
            max: 250
          },
          gridLines: {
            display: true
          }
        }]
      },
      elements: {
        point: {
          radius: 0,
          hitRadius: 10,
          hoverRadius: 4,
          hoverBorderWidth: 3
        }
      }
    });
  }
}));

/***/ }),

/***/ 259:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs__ = __webpack_require__(4);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue_chartjs___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__);



/* harmony default export */ __webpack_exports__["default"] = (__WEBPACK_IMPORTED_MODULE_0_vue_chartjs__["Line"].extend({
  props: ['data', 'height'],
  mounted: function mounted() {
    this.renderChart({
      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
      datasets: [{
        backgroundColor: 'rgba(255,255,255,.1)',
        borderColor: 'rgba(255,255,255,.55)',
        pointHoverBackgroundColor: '#fff',
        borderWidth: 2,
        data: this.data
      }]
    }, {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          display: false
        }],
        yAxes: [{
          display: false
        }]
      },
      elements: {
        point: {
          radius: 0,
          hitRadius: 10,
          hoverRadius: 4,
          hoverBorderWidth: 3
        }
      }
    });
  }
}));

/***/ }),

/***/ 260:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'font-awesome'
});

/***/ }),

/***/ 261:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'simple-line-icons'
});

/***/ }),

/***/ 262:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'Login'
});

/***/ }),

/***/ 263:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'Page404'
});

/***/ }),

/***/ 264:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'Page500'
});

/***/ }),

/***/ 265:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//

/* harmony default export */ __webpack_exports__["default"] = ({
  name: 'Register'
});

/***/ }),

/***/ 266:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__utils_utils_js__ = __webpack_require__(545);
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//



/* harmony default export */ __webpack_exports__["default"] = ({
  props: {
    backdrop: { type: Boolean, default: true },
    callback: { type: Function, default: null },
    cancelText: { type: String, default: 'Close' },
    effect: { type: String, default: null },
    large: { type: Boolean, default: false },
    okText: { type: String, default: 'Save changes' },
    small: { type: Boolean, default: false },
    title: { type: String, default: '' },
    value: { type: Boolean, required: true },
    width: { default: null }
  },
  data: function data() {
    return {
      transition: false,
      val: null
    };
  },

  computed: {
    optionalWidth: function optionalWidth() {
      if (this.width === null) {
        return null;
      } else if (Number.isInteger(this.width)) {
        return this.width + 'px';
      }
      return this.width;
    }
  },
  watch: {
    transition: function transition(val, old) {
      if (val === old) {
        return;
      }
      var el = this.$el;
      var body = document.body;
      if (val) {
        //starting
        if (this.val) {
          el.querySelector('.modal-content').focus();
          el.style.display = 'block';
          setTimeout(function () {
            return el.classList.add('in');
          }, 0);
          body.classList.add('modal-open');
          if (__webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__utils_utils_js__["a" /* getScrollBarWidth */])() !== 0) {
            body.style.paddingRight = __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_0__utils_utils_js__["a" /* getScrollBarWidth */])() + 'px';
          }
        } else {
          el.classList.remove('in');
        }
      } else {
        //ending
        this.$emit(this.val ? 'opened' : 'closed');
        if (!this.val) {
          el.style.display = 'none';
          body.style.paddingRight = null;
          body.classList.remove('modal-open');
        }
      }
    },
    val: function val(_val, old) {
      this.$emit('input', _val);
      if (old === null ? _val === true : _val !== old) this.transition = true;
    },
    value: function value(val, old) {
      if (val !== old) this.val = val;
    }
  },
  methods: {
    action: function action(val, p) {
      if (val === null) {
        return;
      }
      if (val && this.callback instanceof Function) this.callback();
      this.$emit(val ? 'ok' : 'cancel', p);
      this.val = val || false;
    }
  },
  mounted: function mounted() {
    this.val = this.value;
  }
});

/***/ }),

/***/ 340:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 341:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 342:
/***/ (function(module, exports) {

// removed by extract-text-webpack-plugin

/***/ }),

/***/ 470:
/***/ (function(module, exports, __webpack_require__) {

var map = {
	"./af": 111,
	"./af.js": 111,
	"./ar": 118,
	"./ar-dz": 112,
	"./ar-dz.js": 112,
	"./ar-kw": 113,
	"./ar-kw.js": 113,
	"./ar-ly": 114,
	"./ar-ly.js": 114,
	"./ar-ma": 115,
	"./ar-ma.js": 115,
	"./ar-sa": 116,
	"./ar-sa.js": 116,
	"./ar-tn": 117,
	"./ar-tn.js": 117,
	"./ar.js": 118,
	"./az": 119,
	"./az.js": 119,
	"./be": 120,
	"./be.js": 120,
	"./bg": 121,
	"./bg.js": 121,
	"./bn": 122,
	"./bn.js": 122,
	"./bo": 123,
	"./bo.js": 123,
	"./br": 124,
	"./br.js": 124,
	"./bs": 125,
	"./bs.js": 125,
	"./ca": 126,
	"./ca.js": 126,
	"./cs": 127,
	"./cs.js": 127,
	"./cv": 128,
	"./cv.js": 128,
	"./cy": 129,
	"./cy.js": 129,
	"./da": 130,
	"./da.js": 130,
	"./de": 133,
	"./de-at": 131,
	"./de-at.js": 131,
	"./de-ch": 132,
	"./de-ch.js": 132,
	"./de.js": 133,
	"./dv": 134,
	"./dv.js": 134,
	"./el": 135,
	"./el.js": 135,
	"./en-au": 136,
	"./en-au.js": 136,
	"./en-ca": 137,
	"./en-ca.js": 137,
	"./en-gb": 138,
	"./en-gb.js": 138,
	"./en-ie": 139,
	"./en-ie.js": 139,
	"./en-nz": 140,
	"./en-nz.js": 140,
	"./eo": 141,
	"./eo.js": 141,
	"./es": 143,
	"./es-do": 142,
	"./es-do.js": 142,
	"./es.js": 143,
	"./et": 144,
	"./et.js": 144,
	"./eu": 145,
	"./eu.js": 145,
	"./fa": 146,
	"./fa.js": 146,
	"./fi": 147,
	"./fi.js": 147,
	"./fo": 148,
	"./fo.js": 148,
	"./fr": 151,
	"./fr-ca": 149,
	"./fr-ca.js": 149,
	"./fr-ch": 150,
	"./fr-ch.js": 150,
	"./fr.js": 151,
	"./fy": 152,
	"./fy.js": 152,
	"./gd": 153,
	"./gd.js": 153,
	"./gl": 154,
	"./gl.js": 154,
	"./gom-latn": 155,
	"./gom-latn.js": 155,
	"./he": 156,
	"./he.js": 156,
	"./hi": 157,
	"./hi.js": 157,
	"./hr": 158,
	"./hr.js": 158,
	"./hu": 159,
	"./hu.js": 159,
	"./hy-am": 160,
	"./hy-am.js": 160,
	"./id": 161,
	"./id.js": 161,
	"./is": 162,
	"./is.js": 162,
	"./it": 163,
	"./it.js": 163,
	"./ja": 164,
	"./ja.js": 164,
	"./jv": 165,
	"./jv.js": 165,
	"./ka": 166,
	"./ka.js": 166,
	"./kk": 167,
	"./kk.js": 167,
	"./km": 168,
	"./km.js": 168,
	"./kn": 169,
	"./kn.js": 169,
	"./ko": 170,
	"./ko.js": 170,
	"./ky": 171,
	"./ky.js": 171,
	"./lb": 172,
	"./lb.js": 172,
	"./lo": 173,
	"./lo.js": 173,
	"./lt": 174,
	"./lt.js": 174,
	"./lv": 175,
	"./lv.js": 175,
	"./me": 176,
	"./me.js": 176,
	"./mi": 177,
	"./mi.js": 177,
	"./mk": 178,
	"./mk.js": 178,
	"./ml": 179,
	"./ml.js": 179,
	"./mr": 180,
	"./mr.js": 180,
	"./ms": 182,
	"./ms-my": 181,
	"./ms-my.js": 181,
	"./ms.js": 182,
	"./my": 183,
	"./my.js": 183,
	"./nb": 184,
	"./nb.js": 184,
	"./ne": 185,
	"./ne.js": 185,
	"./nl": 187,
	"./nl-be": 186,
	"./nl-be.js": 186,
	"./nl.js": 187,
	"./nn": 188,
	"./nn.js": 188,
	"./pa-in": 189,
	"./pa-in.js": 189,
	"./pl": 190,
	"./pl.js": 190,
	"./pt": 192,
	"./pt-br": 191,
	"./pt-br.js": 191,
	"./pt.js": 192,
	"./ro": 193,
	"./ro.js": 193,
	"./ru": 194,
	"./ru.js": 194,
	"./sd": 195,
	"./sd.js": 195,
	"./se": 196,
	"./se.js": 196,
	"./si": 197,
	"./si.js": 197,
	"./sk": 198,
	"./sk.js": 198,
	"./sl": 199,
	"./sl.js": 199,
	"./sq": 200,
	"./sq.js": 200,
	"./sr": 202,
	"./sr-cyrl": 201,
	"./sr-cyrl.js": 201,
	"./sr.js": 202,
	"./ss": 203,
	"./ss.js": 203,
	"./sv": 204,
	"./sv.js": 204,
	"./sw": 205,
	"./sw.js": 205,
	"./ta": 206,
	"./ta.js": 206,
	"./te": 207,
	"./te.js": 207,
	"./tet": 208,
	"./tet.js": 208,
	"./th": 209,
	"./th.js": 209,
	"./tl-ph": 210,
	"./tl-ph.js": 210,
	"./tlh": 211,
	"./tlh.js": 211,
	"./tr": 212,
	"./tr.js": 212,
	"./tzl": 213,
	"./tzl.js": 213,
	"./tzm": 215,
	"./tzm-latn": 214,
	"./tzm-latn.js": 214,
	"./tzm.js": 215,
	"./uk": 216,
	"./uk.js": 216,
	"./ur": 217,
	"./ur.js": 217,
	"./uz": 219,
	"./uz-latn": 218,
	"./uz-latn.js": 218,
	"./uz.js": 219,
	"./vi": 220,
	"./vi.js": 220,
	"./x-pseudo": 221,
	"./x-pseudo.js": 221,
	"./yo": 222,
	"./yo.js": 222,
	"./zh-cn": 223,
	"./zh-cn.js": 223,
	"./zh-hk": 224,
	"./zh-hk.js": 224,
	"./zh-tw": 225,
	"./zh-tw.js": 225
};
function webpackContext(req) {
	return __webpack_require__(webpackContextResolve(req));
};
function webpackContextResolve(req) {
	var id = map[req];
	if(!(id + 1)) // check for number or string
		throw new Error("Cannot find module '" + req + "'.");
	return id;
};
webpackContext.keys = function webpackContextKeys() {
	return Object.keys(map);
};
webpackContext.resolve = webpackContextResolve;
module.exports = webpackContext;
webpackContext.id = 470;

/***/ }),

/***/ 482:
/***/ (function(module, exports) {

module.exports = {
	"_args": [
		[
			"vue-chartjs@^2.6.3",
			"D:\\_Workspace\\_Github\\Swastika-Core\\src\\Swastika.UI.Spa"
		]
	],
	"_from": "vue-chartjs@>=2.6.3-0 <3.0.0-0",
	"_id": "vue-chartjs@2.6.4",
	"_inCache": true,
	"_location": "/vue-chartjs",
	"_nodeVersion": "8.0.0",
	"_npmOperationalInternal": {
		"host": "s3://npm-registry-packages",
		"tmp": "tmp/vue-chartjs-2.6.4.tgz_1496583685479_0.34330985764972866"
	},
	"_npmUser": {
		"email": "juszczak.j@googlemail.com",
		"name": "apertureless"
	},
	"_npmVersion": "5.0.1",
	"_phantomChildren": {},
	"_requested": {
		"name": "vue-chartjs",
		"raw": "vue-chartjs@^2.6.3",
		"rawSpec": "^2.6.3",
		"scope": null,
		"spec": ">=2.6.3-0 <3.0.0-0",
		"type": "range"
	},
	"_requiredBy": [
		"/"
	],
	"_resolved": "https://registry.npmjs.org/vue-chartjs/-/vue-chartjs-2.6.4.tgz",
	"_shasum": "ffb2b31349c09aac599def227b3e66ffe19f2d64",
	"_shrinkwrap": null,
	"_spec": "vue-chartjs@^2.6.3",
	"_where": "D:\\_Workspace\\_Github\\Swastika-Core\\src\\Swastika.UI.Spa",
	"author": {
		"email": "jakub@posteo.de",
		"name": "Jakub Juszczak"
	},
	"babel": {
		"presets": [
			"es2015"
		]
	},
	"browserify": {
		"transform": [
			"babelify"
		]
	},
	"bugs": {
		"url": "https://github.com/apertureless/vue-chartjs/issues"
	},
	"contributors": [
		{
			"name": "Thorsten Lünborg",
			"url": "https://github.com/LinusBorg"
		},
		{
			"name": "Juan Carlos Alonso",
			"url": "https://github.com/jcalonso"
		}
	],
	"dependencies": {
		"lodash": "^4.17.4"
	},
	"description": "vue.js wrapper for chart.js",
	"devDependencies": {
		"babel-cli": "^6.24.1",
		"babel-core": "^6.24.1",
		"babel-loader": "^7.0.0",
		"babel-plugin-transform-runtime": "^6.23.0",
		"babel-preset-es2015": "^6.24.1",
		"babel-preset-stage-2": "^6.24.1",
		"babel-runtime": "^6.23.0",
		"chai": "^3.5.0",
		"chart.js": "^2.5.0",
		"chromedriver": "^2.28.0",
		"connect-history-api-fallback": "^1.1.0",
		"cross-env": "^3.2.4",
		"cross-spawn": "^5.1.0",
		"css-loader": "^0.28.0",
		"eslint": "^3.19.0",
		"eslint-config-standard": "^10.2.1",
		"eslint-friendly-formatter": "^2.0.7",
		"eslint-loader": "^1.7.1",
		"eslint-plugin-html": "^2.0.1",
		"eslint-plugin-import": "^2.2.0",
		"eslint-plugin-node": "^4.2.2",
		"eslint-plugin-promise": "^3.5.0",
		"eslint-plugin-standard": "^3.0.1",
		"eventsource-polyfill": "^0.9.6",
		"express": "^4.15.2",
		"extract-text-webpack-plugin": "^1.0.1",
		"file-loader": "^0.10.1",
		"function-bind": "^1.0.2",
		"html-webpack-plugin": "^2.28.0",
		"http-proxy-middleware": "^0.17.4",
		"inject-loader": "^3.0.0",
		"isparta-loader": "^2.0.0",
		"jasmine-core": "^2.5.2",
		"json-loader": "^0.5.4",
		"karma": "^1.5.0",
		"karma-coverage": "^1.1.1",
		"karma-jasmine": "^1.0.2",
		"karma-mocha": "^1.2.0",
		"karma-phantomjs-launcher": "^1.0.4",
		"karma-sinon-chai": "^1.2.0",
		"karma-sourcemap-loader": "^0.3.7",
		"karma-spec-reporter": "0.0.30",
		"karma-webpack": "1.8.1",
		"lolex": "^1.6.0",
		"mocha": "^3.1.0",
		"nightwatch": "^0.9.14",
		"ora": "^1.2.0",
		"phantomjs-prebuilt": "^2.1.13",
		"selenium-server": "^3.3.1",
		"shelljs": "^0.7.7",
		"sinon": "^2.1.0",
		"sinon-chai": "^2.9.0",
		"url-loader": "^0.5.8",
		"vue": "^2.3.3",
		"vue-hot-reload-api": "^2.1.0",
		"vue-html-loader": "^1.2.4",
		"vue-loader": "^12.0.4",
		"vue-style-loader": "^3.0.1",
		"vue-template-compiler": "^2.3.3",
		"webpack": "^1.13.2",
		"webpack-dev-middleware": "^1.10.1",
		"webpack-hot-middleware": "^2.17.1",
		"webpack-merge": "1.1.1"
	},
	"directories": {},
	"dist": {
		"integrity": "sha512-nVI+MI24tVZgBUQf5NK0sdHfnfV+ur6ji8KYobpvzTl0YXh+KeEXTP42MdJ/581DJW/FGFssEnhyMBtW1BRigA==",
		"shasum": "ffb2b31349c09aac599def227b3e66ffe19f2d64",
		"tarball": "https://registry.npmjs.org/vue-chartjs/-/vue-chartjs-2.6.4.tgz"
	},
	"engines": {
		"node": ">=6.9.0"
	},
	"files": [
		"dist",
		"es",
		"src"
	],
	"gitHead": "cc869c979d74b5a876d8d954e1c4d6bdd01d859a",
	"greenkeeper": {
		"ignore": [
			"extract-text-webpack-plugin",
			"karma-webpack",
			"webpack",
			"webpack-merge"
		]
	},
	"homepage": "http://vue-chartjs.org",
	"installable": true,
	"jsnext:main": "es/index.js",
	"keywords": [
		"ChartJs",
		"Charts",
		"Visualisation",
		"Vue",
		"Wrapper"
	],
	"license": "MIT",
	"main": "dist/vue-chartjs.js",
	"maintainers": [
		{
			"email": "juszczak.j@googlemail.com",
			"name": "apertureless"
		}
	],
	"module": "es/index.js",
	"name": "vue-chartjs",
	"optionalDependencies": {},
	"peerDependencies": {
		"chart.js": "^2.5.0",
		"vue": "^2.3.3"
	},
	"repository": {
		"type": "git",
		"url": "git+ssh://git@github.com/apertureless/vue-chartjs.git"
	},
	"scripts": {
		"build": "yarn run release && yarn run build:es",
		"build:es": "cross-env BABEL_ENV=es babel src --out-dir es",
		"dev": "node build/dev-server.js",
		"e2e": "node test/e2e/runner.js",
		"lint": "eslint --ext .js,.vue src test/unit/specs test/e2e/specs",
		"prepublish": "yarn run lint && yarn run test && yarn run build",
		"release": "webpack --progress --hide-modules --config  ./build/webpack.release.js && NODE_ENV=production webpack --progress --hide-modules --config  ./build/webpack.release.min.js && webpack --progress --hide-modules --config  ./build/webpack.release.full.js && NODE_ENV=production webpack --progress --hide-modules --config  ./build/webpack.release.full.min.js",
		"test": "npm run unit",
		"unit": "karma start test/unit/karma.conf.js --single-run"
	},
	"unpkg": "dist/vue-chartjs.full.min.js",
	"version": "2.6.4"
};

/***/ }),

/***/ 483:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(231),
  /* template */
  __webpack_require__(533),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 484:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(232),
  /* template */
  __webpack_require__(526),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 485:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(233),
  /* template */
  __webpack_require__(520),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 486:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(234),
  /* template */
  __webpack_require__(523),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 487:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(235),
  /* template */
  __webpack_require__(535),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 488:
/***/ (function(module, exports, __webpack_require__) {

function injectStyle (ssrContext) {
  __webpack_require__(340)
}
var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(236),
  /* template */
  __webpack_require__(536),
  /* styles */
  injectStyle,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 489:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(237),
  /* template */
  __webpack_require__(541),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 490:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(238),
  /* template */
  __webpack_require__(528),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 491:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(239),
  /* template */
  __webpack_require__(521),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 492:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(240),
  /* template */
  __webpack_require__(532),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 493:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(241),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 494:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(242),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 495:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(243),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 496:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(244),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 497:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(245),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 498:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(246),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 499:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(247),
  /* template */
  __webpack_require__(543),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 500:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(248),
  /* template */
  __webpack_require__(530),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 501:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(249),
  /* template */
  __webpack_require__(525),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 502:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(250),
  /* template */
  __webpack_require__(539),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 503:
/***/ (function(module, exports, __webpack_require__) {

function injectStyle (ssrContext) {
  __webpack_require__(341)
}
var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(251),
  /* template */
  __webpack_require__(538),
  /* styles */
  injectStyle,
  /* scopeId */
  "data-v-cbe846b8",
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 504:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(252),
  /* template */
  __webpack_require__(524),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 505:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(253),
  /* template */
  __webpack_require__(540),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 506:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(254),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 507:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(255),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 508:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(256),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 509:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(257),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 510:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(258),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 511:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(259),
  /* template */
  null,
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 512:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(260),
  /* template */
  __webpack_require__(519),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 513:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(261),
  /* template */
  __webpack_require__(534),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 514:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(262),
  /* template */
  __webpack_require__(531),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 515:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(263),
  /* template */
  __webpack_require__(522),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 516:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(264),
  /* template */
  __webpack_require__(529),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 517:
/***/ (function(module, exports, __webpack_require__) {

var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(265),
  /* template */
  __webpack_require__(527),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 518:
/***/ (function(module, exports, __webpack_require__) {

function injectStyle (ssrContext) {
  __webpack_require__(342)
}
var Component = __webpack_require__(1)(
  /* script */
  __webpack_require__(266),
  /* template */
  __webpack_require__(542),
  /* styles */
  injectStyle,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)

module.exports = Component.exports


/***/ }),

/***/ 519:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "card",
    attrs: {
      "id": "new"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("20 New Icons in 4.5")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth-b fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth-b\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-codiepie fa-lg mt-4"
  }), _c('br'), _vm._v("codiepie\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-credit-card-alt fa-lg mt-4"
  }), _c('br'), _vm._v("credit-card-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-edge fa-lg mt-4"
  }), _c('br'), _vm._v("edge\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fort-awesome fa-lg mt-4"
  }), _c('br'), _vm._v("fort-awesome\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hashtag fa-lg mt-4"
  }), _c('br'), _vm._v("hashtag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mixcloud fa-lg mt-4"
  }), _c('br'), _vm._v("mixcloud\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-modx fa-lg mt-4"
  }), _c('br'), _vm._v("modx\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pause-circle fa-lg mt-4"
  }), _c('br'), _vm._v("pause-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pause-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("pause-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-percent fa-lg mt-4"
  }), _c('br'), _vm._v("percent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-product-hunt fa-lg mt-4"
  }), _c('br'), _vm._v("product-hunt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reddit-alien fa-lg mt-4"
  }), _c('br'), _vm._v("reddit-alien\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-scribd fa-lg mt-4"
  }), _c('br'), _vm._v("scribd\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shopping-bag fa-lg mt-4"
  }), _c('br'), _vm._v("shopping-bag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shopping-basket fa-lg mt-4"
  }), _c('br'), _vm._v("shopping-basket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stop-circle fa-lg mt-4"
  }), _c('br'), _vm._v("stop-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stop-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("stop-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-usb fa-lg mt-4"
  }), _c('br'), _vm._v("usb\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "web-application"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Web Application Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-adjust fa-lg mt-4"
  }), _c('br'), _vm._v("adjust\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-anchor fa-lg mt-4"
  }), _c('br'), _vm._v("anchor\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-archive fa-lg mt-4"
  }), _c('br'), _vm._v("archive\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-area-chart fa-lg mt-4"
  }), _c('br'), _vm._v("area-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows fa-lg mt-4"
  }), _c('br'), _vm._v("arrows\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-h fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-h\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-v fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-v\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-asterisk fa-lg mt-4"
  }), _c('br'), _vm._v("asterisk\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-at fa-lg mt-4"
  }), _c('br'), _vm._v("at\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-automobile fa-lg mt-4"
  }), _c('br'), _vm._v("automobile "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-balance-scale fa-lg mt-4"
  }), _c('br'), _vm._v("balance-scale\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ban fa-lg mt-4"
  }), _c('br'), _vm._v("ban\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bank fa-lg mt-4"
  }), _c('br'), _vm._v("bank "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bar-chart fa-lg mt-4"
  }), _c('br'), _vm._v("bar-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bar-chart-o fa-lg mt-4"
  }), _c('br'), _vm._v("bar-chart-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-barcode fa-lg mt-4"
  }), _c('br'), _vm._v("barcode\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bars fa-lg mt-4"
  }), _c('br'), _vm._v("bars\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-0 fa-lg mt-4"
  }), _c('br'), _vm._v("battery-0 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-1 fa-lg mt-4"
  }), _c('br'), _vm._v("battery-1 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-2 fa-lg mt-4"
  }), _c('br'), _vm._v("battery-2 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-3 fa-lg mt-4"
  }), _c('br'), _vm._v("battery-3 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-4 fa-lg mt-4"
  }), _c('br'), _vm._v("battery-4 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-empty fa-lg mt-4"
  }), _c('br'), _vm._v("battery-empty\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-full fa-lg mt-4"
  }), _c('br'), _vm._v("battery-full\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-half fa-lg mt-4"
  }), _c('br'), _vm._v("battery-half\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-quarter fa-lg mt-4"
  }), _c('br'), _vm._v("battery-quarter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-battery-three-quarters fa-lg mt-4"
  }), _c('br'), _vm._v("battery-three-quarters\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bed fa-lg mt-4"
  }), _c('br'), _vm._v("bed\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-beer fa-lg mt-4"
  }), _c('br'), _vm._v("beer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bell fa-lg mt-4"
  }), _c('br'), _vm._v("bell\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bell-o fa-lg mt-4"
  }), _c('br'), _vm._v("bell-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bell-slash fa-lg mt-4"
  }), _c('br'), _vm._v("bell-slash\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bell-slash-o fa-lg mt-4"
  }), _c('br'), _vm._v("bell-slash-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bicycle fa-lg mt-4"
  }), _c('br'), _vm._v("bicycle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-binoculars fa-lg mt-4"
  }), _c('br'), _vm._v("binoculars\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-birthday-cake fa-lg mt-4"
  }), _c('br'), _vm._v("birthday-cake\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth-b fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth-b\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bolt fa-lg mt-4"
  }), _c('br'), _vm._v("bolt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bomb fa-lg mt-4"
  }), _c('br'), _vm._v("bomb\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-book fa-lg mt-4"
  }), _c('br'), _vm._v("book\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bookmark fa-lg mt-4"
  }), _c('br'), _vm._v("bookmark\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bookmark-o fa-lg mt-4"
  }), _c('br'), _vm._v("bookmark-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-briefcase fa-lg mt-4"
  }), _c('br'), _vm._v("briefcase\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bug fa-lg mt-4"
  }), _c('br'), _vm._v("bug\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-building fa-lg mt-4"
  }), _c('br'), _vm._v("building\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-building-o fa-lg mt-4"
  }), _c('br'), _vm._v("building-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bullhorn fa-lg mt-4"
  }), _c('br'), _vm._v("bullhorn\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bullseye fa-lg mt-4"
  }), _c('br'), _vm._v("bullseye\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bus fa-lg mt-4"
  }), _c('br'), _vm._v("bus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cab fa-lg mt-4"
  }), _c('br'), _vm._v("cab "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calculator fa-lg mt-4"
  }), _c('br'), _vm._v("calculator\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar fa-lg mt-4"
  }), _c('br'), _vm._v("calendar\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar-check-o fa-lg mt-4"
  }), _c('br'), _vm._v("calendar-check-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar-minus-o fa-lg mt-4"
  }), _c('br'), _vm._v("calendar-minus-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar-o fa-lg mt-4"
  }), _c('br'), _vm._v("calendar-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar-plus-o fa-lg mt-4"
  }), _c('br'), _vm._v("calendar-plus-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-calendar-times-o fa-lg mt-4"
  }), _c('br'), _vm._v("calendar-times-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-camera fa-lg mt-4"
  }), _c('br'), _vm._v("camera\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-camera-retro fa-lg mt-4"
  }), _c('br'), _vm._v("camera-retro\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-car fa-lg mt-4"
  }), _c('br'), _vm._v("car\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-left fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-right fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cart-arrow-down fa-lg mt-4"
  }), _c('br'), _vm._v("cart-arrow-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cart-plus fa-lg mt-4"
  }), _c('br'), _vm._v("cart-plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc fa-lg mt-4"
  }), _c('br'), _vm._v("cc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-certificate fa-lg mt-4"
  }), _c('br'), _vm._v("certificate\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check fa-lg mt-4"
  }), _c('br'), _vm._v("check\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-circle fa-lg mt-4"
  }), _c('br'), _vm._v("check-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("check-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-square fa-lg mt-4"
  }), _c('br'), _vm._v("check-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("check-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-child fa-lg mt-4"
  }), _c('br'), _vm._v("child\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle fa-lg mt-4"
  }), _c('br'), _vm._v("circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle-o-notch fa-lg mt-4"
  }), _c('br'), _vm._v("circle-o-notch\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle-thin fa-lg mt-4"
  }), _c('br'), _vm._v("circle-thin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-clock-o fa-lg mt-4"
  }), _c('br'), _vm._v("clock-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-clone fa-lg mt-4"
  }), _c('br'), _vm._v("clone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-close fa-lg mt-4"
  }), _c('br'), _vm._v("close "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cloud fa-lg mt-4"
  }), _c('br'), _vm._v("cloud\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cloud-download fa-lg mt-4"
  }), _c('br'), _vm._v("cloud-download\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cloud-upload fa-lg mt-4"
  }), _c('br'), _vm._v("cloud-upload\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-code fa-lg mt-4"
  }), _c('br'), _vm._v("code\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-code-fork fa-lg mt-4"
  }), _c('br'), _vm._v("code-fork\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-coffee fa-lg mt-4"
  }), _c('br'), _vm._v("coffee\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cog fa-lg mt-4"
  }), _c('br'), _vm._v("cog\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cogs fa-lg mt-4"
  }), _c('br'), _vm._v("cogs\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-comment fa-lg mt-4"
  }), _c('br'), _vm._v("comment\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-comment-o fa-lg mt-4"
  }), _c('br'), _vm._v("comment-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-commenting fa-lg mt-4"
  }), _c('br'), _vm._v("commenting\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-commenting-o fa-lg mt-4"
  }), _c('br'), _vm._v("commenting-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-comments fa-lg mt-4"
  }), _c('br'), _vm._v("comments\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-comments-o fa-lg mt-4"
  }), _c('br'), _vm._v("comments-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-compass fa-lg mt-4"
  }), _c('br'), _vm._v("compass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-copyright fa-lg mt-4"
  }), _c('br'), _vm._v("copyright\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-creative-commons fa-lg mt-4"
  }), _c('br'), _vm._v("creative-commons\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-credit-card fa-lg mt-4"
  }), _c('br'), _vm._v("credit-card\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-credit-card-alt fa-lg mt-4"
  }), _c('br'), _vm._v("credit-card-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-crop fa-lg mt-4"
  }), _c('br'), _vm._v("crop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-crosshairs fa-lg mt-4"
  }), _c('br'), _vm._v("crosshairs\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cube fa-lg mt-4"
  }), _c('br'), _vm._v("cube\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cubes fa-lg mt-4"
  }), _c('br'), _vm._v("cubes\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cutlery fa-lg mt-4"
  }), _c('br'), _vm._v("cutlery\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dashboard fa-lg mt-4"
  }), _c('br'), _vm._v("dashboard "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-database fa-lg mt-4"
  }), _c('br'), _vm._v("database\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-desktop fa-lg mt-4"
  }), _c('br'), _vm._v("desktop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-diamond fa-lg mt-4"
  }), _c('br'), _vm._v("diamond\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("dot-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-download fa-lg mt-4"
  }), _c('br'), _vm._v("download\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-edit fa-lg mt-4"
  }), _c('br'), _vm._v("edit "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ellipsis-h fa-lg mt-4"
  }), _c('br'), _vm._v("ellipsis-h\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ellipsis-v fa-lg mt-4"
  }), _c('br'), _vm._v("ellipsis-v\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-envelope fa-lg mt-4"
  }), _c('br'), _vm._v("envelope\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-envelope-o fa-lg mt-4"
  }), _c('br'), _vm._v("envelope-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-envelope-square fa-lg mt-4"
  }), _c('br'), _vm._v("envelope-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eraser fa-lg mt-4"
  }), _c('br'), _vm._v("eraser\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-exchange fa-lg mt-4"
  }), _c('br'), _vm._v("exchange\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-exclamation fa-lg mt-4"
  }), _c('br'), _vm._v("exclamation\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-exclamation-circle fa-lg mt-4"
  }), _c('br'), _vm._v("exclamation-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-exclamation-triangle fa-lg mt-4"
  }), _c('br'), _vm._v("exclamation-triangle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-external-link fa-lg mt-4"
  }), _c('br'), _vm._v("external-link\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-external-link-square fa-lg mt-4"
  }), _c('br'), _vm._v("external-link-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eye fa-lg mt-4"
  }), _c('br'), _vm._v("eye\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eye-slash fa-lg mt-4"
  }), _c('br'), _vm._v("eye-slash\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eyedropper fa-lg mt-4"
  }), _c('br'), _vm._v("eyedropper\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fax fa-lg mt-4"
  }), _c('br'), _vm._v("fax\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-feed fa-lg mt-4"
  }), _c('br'), _vm._v("feed "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-female fa-lg mt-4"
  }), _c('br'), _vm._v("female\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fighter-jet fa-lg mt-4"
  }), _c('br'), _vm._v("fighter-jet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-archive-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-archive-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-audio-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-audio-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-code-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-code-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-excel-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-excel-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-image-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-image-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-movie-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-movie-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-pdf-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-pdf-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-photo-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-photo-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-picture-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-picture-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-powerpoint-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-powerpoint-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-sound-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-sound-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-video-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-video-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-word-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-word-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-zip-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-zip-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-film fa-lg mt-4"
  }), _c('br'), _vm._v("film\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-filter fa-lg mt-4"
  }), _c('br'), _vm._v("filter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fire fa-lg mt-4"
  }), _c('br'), _vm._v("fire\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fire-extinguisher fa-lg mt-4"
  }), _c('br'), _vm._v("fire-extinguisher\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flag fa-lg mt-4"
  }), _c('br'), _vm._v("flag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flag-checkered fa-lg mt-4"
  }), _c('br'), _vm._v("flag-checkered\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flag-o fa-lg mt-4"
  }), _c('br'), _vm._v("flag-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flash fa-lg mt-4"
  }), _c('br'), _vm._v("flash "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flask fa-lg mt-4"
  }), _c('br'), _vm._v("flask\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-folder fa-lg mt-4"
  }), _c('br'), _vm._v("folder\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-folder-o fa-lg mt-4"
  }), _c('br'), _vm._v("folder-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-folder-open fa-lg mt-4"
  }), _c('br'), _vm._v("folder-open\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-folder-open-o fa-lg mt-4"
  }), _c('br'), _vm._v("folder-open-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-frown-o fa-lg mt-4"
  }), _c('br'), _vm._v("frown-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-futbol-o fa-lg mt-4"
  }), _c('br'), _vm._v("futbol-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gamepad fa-lg mt-4"
  }), _c('br'), _vm._v("gamepad\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gavel fa-lg mt-4"
  }), _c('br'), _vm._v("gavel\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gear fa-lg mt-4"
  }), _c('br'), _vm._v("gear "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gears fa-lg mt-4"
  }), _c('br'), _vm._v("gears "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gift fa-lg mt-4"
  }), _c('br'), _vm._v("gift\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-glass fa-lg mt-4"
  }), _c('br'), _vm._v("glass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-globe fa-lg mt-4"
  }), _c('br'), _vm._v("globe\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-graduation-cap fa-lg mt-4"
  }), _c('br'), _vm._v("graduation-cap\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-group fa-lg mt-4"
  }), _c('br'), _vm._v("group "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-grab-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-grab-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-lizard-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-lizard-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-paper-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-paper-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-peace-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-peace-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-pointer-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-pointer-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-rock-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-rock-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-scissors-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-scissors-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-spock-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-spock-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-stop-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-stop-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hashtag fa-lg mt-4"
  }), _c('br'), _vm._v("hashtag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hdd-o fa-lg mt-4"
  }), _c('br'), _vm._v("hdd-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-headphones fa-lg mt-4"
  }), _c('br'), _vm._v("headphones\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heart fa-lg mt-4"
  }), _c('br'), _vm._v("heart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heart-o fa-lg mt-4"
  }), _c('br'), _vm._v("heart-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heartbeat fa-lg mt-4"
  }), _c('br'), _vm._v("heartbeat\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-history fa-lg mt-4"
  }), _c('br'), _vm._v("history\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-home fa-lg mt-4"
  }), _c('br'), _vm._v("home\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hotel fa-lg mt-4"
  }), _c('br'), _vm._v("hotel "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-1 fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-1 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-2 fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-2 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-3 fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-3 "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-end fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-end\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-half fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-half\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-o fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hourglass-start fa-lg mt-4"
  }), _c('br'), _vm._v("hourglass-start\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-i-cursor fa-lg mt-4"
  }), _c('br'), _vm._v("i-cursor\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-image fa-lg mt-4"
  }), _c('br'), _vm._v("image "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-inbox fa-lg mt-4"
  }), _c('br'), _vm._v("inbox\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-industry fa-lg mt-4"
  }), _c('br'), _vm._v("industry\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-info fa-lg mt-4"
  }), _c('br'), _vm._v("info\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-info-circle fa-lg mt-4"
  }), _c('br'), _vm._v("info-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-institution fa-lg mt-4"
  }), _c('br'), _vm._v("institution "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-key fa-lg mt-4"
  }), _c('br'), _vm._v("key\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-keyboard-o fa-lg mt-4"
  }), _c('br'), _vm._v("keyboard-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-language fa-lg mt-4"
  }), _c('br'), _vm._v("language\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-laptop fa-lg mt-4"
  }), _c('br'), _vm._v("laptop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-leaf fa-lg mt-4"
  }), _c('br'), _vm._v("leaf\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-legal fa-lg mt-4"
  }), _c('br'), _vm._v("legal "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-lemon-o fa-lg mt-4"
  }), _c('br'), _vm._v("lemon-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-level-down fa-lg mt-4"
  }), _c('br'), _vm._v("level-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-level-up fa-lg mt-4"
  }), _c('br'), _vm._v("level-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-life-bouy fa-lg mt-4"
  }), _c('br'), _vm._v("life-bouy "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-life-buoy fa-lg mt-4"
  }), _c('br'), _vm._v("life-buoy "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-life-ring fa-lg mt-4"
  }), _c('br'), _vm._v("life-ring\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-life-saver fa-lg mt-4"
  }), _c('br'), _vm._v("life-saver "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-lightbulb-o fa-lg mt-4"
  }), _c('br'), _vm._v("lightbulb-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-line-chart fa-lg mt-4"
  }), _c('br'), _vm._v("line-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-location-arrow fa-lg mt-4"
  }), _c('br'), _vm._v("location-arrow\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-lock fa-lg mt-4"
  }), _c('br'), _vm._v("lock\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-magic fa-lg mt-4"
  }), _c('br'), _vm._v("magic\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-magnet fa-lg mt-4"
  }), _c('br'), _vm._v("magnet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mail-forward fa-lg mt-4"
  }), _c('br'), _vm._v("mail-forward "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mail-reply fa-lg mt-4"
  }), _c('br'), _vm._v("mail-reply "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mail-reply-all fa-lg mt-4"
  }), _c('br'), _vm._v("mail-reply-all "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-male fa-lg mt-4"
  }), _c('br'), _vm._v("male\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-map fa-lg mt-4"
  }), _c('br'), _vm._v("map\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-map-marker fa-lg mt-4"
  }), _c('br'), _vm._v("map-marker\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-map-o fa-lg mt-4"
  }), _c('br'), _vm._v("map-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-map-pin fa-lg mt-4"
  }), _c('br'), _vm._v("map-pin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-map-signs fa-lg mt-4"
  }), _c('br'), _vm._v("map-signs\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-meh-o fa-lg mt-4"
  }), _c('br'), _vm._v("meh-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-microphone fa-lg mt-4"
  }), _c('br'), _vm._v("microphone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-microphone-slash fa-lg mt-4"
  }), _c('br'), _vm._v("microphone-slash\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus fa-lg mt-4"
  }), _c('br'), _vm._v("minus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus-circle fa-lg mt-4"
  }), _c('br'), _vm._v("minus-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus-square fa-lg mt-4"
  }), _c('br'), _vm._v("minus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("minus-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mobile fa-lg mt-4"
  }), _c('br'), _vm._v("mobile\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mobile-phone fa-lg mt-4"
  }), _c('br'), _vm._v("mobile-phone "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-money fa-lg mt-4"
  }), _c('br'), _vm._v("money\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-moon-o fa-lg mt-4"
  }), _c('br'), _vm._v("moon-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mortar-board fa-lg mt-4"
  }), _c('br'), _vm._v("mortar-board "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-motorcycle fa-lg mt-4"
  }), _c('br'), _vm._v("motorcycle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mouse-pointer fa-lg mt-4"
  }), _c('br'), _vm._v("mouse-pointer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-music fa-lg mt-4"
  }), _c('br'), _vm._v("music\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-navicon fa-lg mt-4"
  }), _c('br'), _vm._v("navicon "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-newspaper-o fa-lg mt-4"
  }), _c('br'), _vm._v("newspaper-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-object-group fa-lg mt-4"
  }), _c('br'), _vm._v("object-group\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-object-ungroup fa-lg mt-4"
  }), _c('br'), _vm._v("object-ungroup\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paint-brush fa-lg mt-4"
  }), _c('br'), _vm._v("paint-brush\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paper-plane fa-lg mt-4"
  }), _c('br'), _vm._v("paper-plane\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paper-plane-o fa-lg mt-4"
  }), _c('br'), _vm._v("paper-plane-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paw fa-lg mt-4"
  }), _c('br'), _vm._v("paw\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pencil fa-lg mt-4"
  }), _c('br'), _vm._v("pencil\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pencil-square fa-lg mt-4"
  }), _c('br'), _vm._v("pencil-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pencil-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("pencil-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-percent fa-lg mt-4"
  }), _c('br'), _vm._v("percent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-phone fa-lg mt-4"
  }), _c('br'), _vm._v("phone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-phone-square fa-lg mt-4"
  }), _c('br'), _vm._v("phone-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-photo fa-lg mt-4"
  }), _c('br'), _vm._v("photo "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-picture-o fa-lg mt-4"
  }), _c('br'), _vm._v("picture-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pie-chart fa-lg mt-4"
  }), _c('br'), _vm._v("pie-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plane fa-lg mt-4"
  }), _c('br'), _vm._v("plane\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plug fa-lg mt-4"
  }), _c('br'), _vm._v("plug\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus fa-lg mt-4"
  }), _c('br'), _vm._v("plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-circle fa-lg mt-4"
  }), _c('br'), _vm._v("plus-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-square fa-lg mt-4"
  }), _c('br'), _vm._v("plus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("plus-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-power-off fa-lg mt-4"
  }), _c('br'), _vm._v("power-off\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-print fa-lg mt-4"
  }), _c('br'), _vm._v("print\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-puzzle-piece fa-lg mt-4"
  }), _c('br'), _vm._v("puzzle-piece\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-qrcode fa-lg mt-4"
  }), _c('br'), _vm._v("qrcode\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-question fa-lg mt-4"
  }), _c('br'), _vm._v("question\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-question-circle fa-lg mt-4"
  }), _c('br'), _vm._v("question-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-quote-left fa-lg mt-4"
  }), _c('br'), _vm._v("quote-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-quote-right fa-lg mt-4"
  }), _c('br'), _vm._v("quote-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-random fa-lg mt-4"
  }), _c('br'), _vm._v("random\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-recycle fa-lg mt-4"
  }), _c('br'), _vm._v("recycle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-refresh fa-lg mt-4"
  }), _c('br'), _vm._v("refresh\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-registered fa-lg mt-4"
  }), _c('br'), _vm._v("registered\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-remove fa-lg mt-4"
  }), _c('br'), _vm._v("remove "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reorder fa-lg mt-4"
  }), _c('br'), _vm._v("reorder "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reply fa-lg mt-4"
  }), _c('br'), _vm._v("reply\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reply-all fa-lg mt-4"
  }), _c('br'), _vm._v("reply-all\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-retweet fa-lg mt-4"
  }), _c('br'), _vm._v("retweet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-road fa-lg mt-4"
  }), _c('br'), _vm._v("road\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rocket fa-lg mt-4"
  }), _c('br'), _vm._v("rocket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rss fa-lg mt-4"
  }), _c('br'), _vm._v("rss\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rss-square fa-lg mt-4"
  }), _c('br'), _vm._v("rss-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-search fa-lg mt-4"
  }), _c('br'), _vm._v("search\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-search-minus fa-lg mt-4"
  }), _c('br'), _vm._v("search-minus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-search-plus fa-lg mt-4"
  }), _c('br'), _vm._v("search-plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-send fa-lg mt-4"
  }), _c('br'), _vm._v("send "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-send-o fa-lg mt-4"
  }), _c('br'), _vm._v("send-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-server fa-lg mt-4"
  }), _c('br'), _vm._v("server\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share fa-lg mt-4"
  }), _c('br'), _vm._v("share\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-alt fa-lg mt-4"
  }), _c('br'), _vm._v("share-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-alt-square fa-lg mt-4"
  }), _c('br'), _vm._v("share-alt-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-square fa-lg mt-4"
  }), _c('br'), _vm._v("share-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("share-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shield fa-lg mt-4"
  }), _c('br'), _vm._v("shield\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ship fa-lg mt-4"
  }), _c('br'), _vm._v("ship\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shopping-bag fa-lg mt-4"
  }), _c('br'), _vm._v("shopping-bag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shopping-basket fa-lg mt-4"
  }), _c('br'), _vm._v("shopping-basket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shopping-cart fa-lg mt-4"
  }), _c('br'), _vm._v("shopping-cart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sign-in fa-lg mt-4"
  }), _c('br'), _vm._v("sign-in\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sign-out fa-lg mt-4"
  }), _c('br'), _vm._v("sign-out\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-signal fa-lg mt-4"
  }), _c('br'), _vm._v("signal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sitemap fa-lg mt-4"
  }), _c('br'), _vm._v("sitemap\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sliders fa-lg mt-4"
  }), _c('br'), _vm._v("sliders\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-smile-o fa-lg mt-4"
  }), _c('br'), _vm._v("smile-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-soccer-ball-o fa-lg mt-4"
  }), _c('br'), _vm._v("soccer-ball-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort fa-lg mt-4"
  }), _c('br'), _vm._v("sort\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-alpha-asc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-alpha-asc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-alpha-desc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-alpha-desc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-amount-asc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-amount-asc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-amount-desc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-amount-desc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-asc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-asc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-desc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-desc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-down fa-lg mt-4"
  }), _c('br'), _vm._v("sort-down "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-numeric-asc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-numeric-asc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-numeric-desc fa-lg mt-4"
  }), _c('br'), _vm._v("sort-numeric-desc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sort-up fa-lg mt-4"
  }), _c('br'), _vm._v("sort-up "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-space-shuttle fa-lg mt-4"
  }), _c('br'), _vm._v("space-shuttle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-spinner fa-lg mt-4"
  }), _c('br'), _vm._v("spinner\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-spoon fa-lg mt-4"
  }), _c('br'), _vm._v("spoon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-square fa-lg mt-4"
  }), _c('br'), _vm._v("square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star fa-lg mt-4"
  }), _c('br'), _vm._v("star\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star-half fa-lg mt-4"
  }), _c('br'), _vm._v("star-half\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star-half-empty fa-lg mt-4"
  }), _c('br'), _vm._v("star-half-empty "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star-half-full fa-lg mt-4"
  }), _c('br'), _vm._v("star-half-full "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star-half-o fa-lg mt-4"
  }), _c('br'), _vm._v("star-half-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-star-o fa-lg mt-4"
  }), _c('br'), _vm._v("star-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sticky-note fa-lg mt-4"
  }), _c('br'), _vm._v("sticky-note\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sticky-note-o fa-lg mt-4"
  }), _c('br'), _vm._v("sticky-note-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-street-view fa-lg mt-4"
  }), _c('br'), _vm._v("street-view\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-suitcase fa-lg mt-4"
  }), _c('br'), _vm._v("suitcase\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sun-o fa-lg mt-4"
  }), _c('br'), _vm._v("sun-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-support fa-lg mt-4"
  }), _c('br'), _vm._v("support "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tablet fa-lg mt-4"
  }), _c('br'), _vm._v("tablet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tachometer fa-lg mt-4"
  }), _c('br'), _vm._v("tachometer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tag fa-lg mt-4"
  }), _c('br'), _vm._v("tag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tags fa-lg mt-4"
  }), _c('br'), _vm._v("tags\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tasks fa-lg mt-4"
  }), _c('br'), _vm._v("tasks\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-taxi fa-lg mt-4"
  }), _c('br'), _vm._v("taxi\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-television fa-lg mt-4"
  }), _c('br'), _vm._v("television\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-terminal fa-lg mt-4"
  }), _c('br'), _vm._v("terminal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumb-tack fa-lg mt-4"
  }), _c('br'), _vm._v("thumb-tack\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-down fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-up fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ticket fa-lg mt-4"
  }), _c('br'), _vm._v("ticket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-times fa-lg mt-4"
  }), _c('br'), _vm._v("times\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-times-circle fa-lg mt-4"
  }), _c('br'), _vm._v("times-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-times-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("times-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tint fa-lg mt-4"
  }), _c('br'), _vm._v("tint\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-down fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-down "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-left fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-left "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-off fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-off\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-on fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-on\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-right fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-right "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-up fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-up "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-trademark fa-lg mt-4"
  }), _c('br'), _vm._v("trademark\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-trash fa-lg mt-4"
  }), _c('br'), _vm._v("trash\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-trash-o fa-lg mt-4"
  }), _c('br'), _vm._v("trash-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tree fa-lg mt-4"
  }), _c('br'), _vm._v("tree\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-trophy fa-lg mt-4"
  }), _c('br'), _vm._v("trophy\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-truck fa-lg mt-4"
  }), _c('br'), _vm._v("truck\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tty fa-lg mt-4"
  }), _c('br'), _vm._v("tty\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tv fa-lg mt-4"
  }), _c('br'), _vm._v("tv "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-umbrella fa-lg mt-4"
  }), _c('br'), _vm._v("umbrella\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-university fa-lg mt-4"
  }), _c('br'), _vm._v("university\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-unlock fa-lg mt-4"
  }), _c('br'), _vm._v("unlock\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-unlock-alt fa-lg mt-4"
  }), _c('br'), _vm._v("unlock-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-unsorted fa-lg mt-4"
  }), _c('br'), _vm._v("unsorted "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-upload fa-lg mt-4"
  }), _c('br'), _vm._v("upload\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-user fa-lg mt-4"
  }), _c('br'), _vm._v("user\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-user-plus fa-lg mt-4"
  }), _c('br'), _vm._v("user-plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-user-secret fa-lg mt-4"
  }), _c('br'), _vm._v("user-secret\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-user-times fa-lg mt-4"
  }), _c('br'), _vm._v("user-times\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-users fa-lg mt-4"
  }), _c('br'), _vm._v("users\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-video-camera fa-lg mt-4"
  }), _c('br'), _vm._v("video-camera\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-volume-down fa-lg mt-4"
  }), _c('br'), _vm._v("volume-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-volume-off fa-lg mt-4"
  }), _c('br'), _vm._v("volume-off\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-volume-up fa-lg mt-4"
  }), _c('br'), _vm._v("volume-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-warning fa-lg mt-4"
  }), _c('br'), _vm._v("warning "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wheelchair fa-lg mt-4"
  }), _c('br'), _vm._v("wheelchair\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wifi fa-lg mt-4"
  }), _c('br'), _vm._v("wifi\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wrench fa-lg mt-4"
  }), _c('br'), _vm._v("wrench\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "hand"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Hand Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-grab-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-grab-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-lizard-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-lizard-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-left fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-right fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-paper-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-paper-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-peace-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-peace-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-pointer-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-pointer-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-rock-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-rock-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-scissors-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-scissors-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-spock-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-spock-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-stop-o fa-lg mt-4"
  }), _c('br'), _vm._v("hand-stop-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-down fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-thumbs-up fa-lg mt-4"
  }), _c('br'), _vm._v("thumbs-up\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "transportation"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Transportation Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ambulance fa-lg mt-4"
  }), _c('br'), _vm._v("ambulance\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-automobile fa-lg mt-4"
  }), _c('br'), _vm._v("automobile "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bicycle fa-lg mt-4"
  }), _c('br'), _vm._v("bicycle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bus fa-lg mt-4"
  }), _c('br'), _vm._v("bus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cab fa-lg mt-4"
  }), _c('br'), _vm._v("cab "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-car fa-lg mt-4"
  }), _c('br'), _vm._v("car\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fighter-jet fa-lg mt-4"
  }), _c('br'), _vm._v("fighter-jet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-motorcycle fa-lg mt-4"
  }), _c('br'), _vm._v("motorcycle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plane fa-lg mt-4"
  }), _c('br'), _vm._v("plane\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rocket fa-lg mt-4"
  }), _c('br'), _vm._v("rocket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ship fa-lg mt-4"
  }), _c('br'), _vm._v("ship\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-space-shuttle fa-lg mt-4"
  }), _c('br'), _vm._v("space-shuttle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-subway fa-lg mt-4"
  }), _c('br'), _vm._v("subway\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-taxi fa-lg mt-4"
  }), _c('br'), _vm._v("taxi\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-train fa-lg mt-4"
  }), _c('br'), _vm._v("train\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-truck fa-lg mt-4"
  }), _c('br'), _vm._v("truck\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wheelchair fa-lg mt-4"
  }), _c('br'), _vm._v("wheelchair\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "gender"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Gender Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-genderless fa-lg mt-4"
  }), _c('br'), _vm._v("genderless\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-intersex fa-lg mt-4"
  }), _c('br'), _vm._v("intersex "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mars fa-lg mt-4"
  }), _c('br'), _vm._v("mars\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mars-double fa-lg mt-4"
  }), _c('br'), _vm._v("mars-double\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mars-stroke fa-lg mt-4"
  }), _c('br'), _vm._v("mars-stroke\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mars-stroke-h fa-lg mt-4"
  }), _c('br'), _vm._v("mars-stroke-h\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mars-stroke-v fa-lg mt-4"
  }), _c('br'), _vm._v("mars-stroke-v\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mercury fa-lg mt-4"
  }), _c('br'), _vm._v("mercury\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-neuter fa-lg mt-4"
  }), _c('br'), _vm._v("neuter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-transgender fa-lg mt-4"
  }), _c('br'), _vm._v("transgender\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-transgender-alt fa-lg mt-4"
  }), _c('br'), _vm._v("transgender-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-venus fa-lg mt-4"
  }), _c('br'), _vm._v("venus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-venus-double fa-lg mt-4"
  }), _c('br'), _vm._v("venus-double\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-venus-mars fa-lg mt-4"
  }), _c('br'), _vm._v("venus-mars\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "file-type"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("File Type Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file fa-lg mt-4"
  }), _c('br'), _vm._v("file\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-archive-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-archive-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-audio-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-audio-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-code-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-code-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-excel-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-excel-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-image-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-image-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-movie-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-movie-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-pdf-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-pdf-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-photo-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-photo-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-picture-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-picture-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-powerpoint-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-powerpoint-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-sound-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-sound-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-text fa-lg mt-4"
  }), _c('br'), _vm._v("file-text\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-text-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-text-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-video-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-video-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-word-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-word-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-zip-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-zip-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "spinner"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Spinner Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "alert alert-success"
  }, [_c('ul', {
    staticClass: "fa-ul"
  }, [_c('li', [_c('i', {
    staticClass: "fa fa-info-circle fa-li"
  }), _vm._v("\n            These icons work great with the "), _c('code', [_vm._v("fa-spin")]), _vm._v(" class.\n          ")])])]), _vm._v(" "), _c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle-o-notch fa-lg mt-4"
  }), _c('br'), _vm._v("circle-o-notch\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cog fa-lg mt-4"
  }), _c('br'), _vm._v("cog\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gear fa-lg mt-4"
  }), _c('br'), _vm._v("gear "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-refresh fa-lg mt-4"
  }), _c('br'), _vm._v("refresh\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-spinner fa-lg mt-4"
  }), _c('br'), _vm._v("spinner\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "form-control"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Form Control Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-square fa-lg mt-4"
  }), _c('br'), _vm._v("check-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-check-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("check-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle fa-lg mt-4"
  }), _c('br'), _vm._v("circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("dot-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus-square fa-lg mt-4"
  }), _c('br'), _vm._v("minus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-minus-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("minus-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-square fa-lg mt-4"
  }), _c('br'), _vm._v("plus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("plus-square-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-square fa-lg mt-4"
  }), _c('br'), _vm._v("square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-square-o fa-lg mt-4"
  }), _c('br'), _vm._v("square-o\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "payment"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Payment Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-amex fa-lg mt-4"
  }), _c('br'), _vm._v("cc-amex\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-diners-club fa-lg mt-4"
  }), _c('br'), _vm._v("cc-diners-club\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-discover fa-lg mt-4"
  }), _c('br'), _vm._v("cc-discover\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-jcb fa-lg mt-4"
  }), _c('br'), _vm._v("cc-jcb\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-mastercard fa-lg mt-4"
  }), _c('br'), _vm._v("cc-mastercard\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-paypal fa-lg mt-4"
  }), _c('br'), _vm._v("cc-paypal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-stripe fa-lg mt-4"
  }), _c('br'), _vm._v("cc-stripe\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-visa fa-lg mt-4"
  }), _c('br'), _vm._v("cc-visa\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-credit-card fa-lg mt-4"
  }), _c('br'), _vm._v("credit-card\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-credit-card-alt fa-lg mt-4"
  }), _c('br'), _vm._v("credit-card-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-google-wallet fa-lg mt-4"
  }), _c('br'), _vm._v("google-wallet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paypal fa-lg mt-4"
  }), _c('br'), _vm._v("paypal\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "chart"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Chart Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-area-chart fa-lg mt-4"
  }), _c('br'), _vm._v("area-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bar-chart fa-lg mt-4"
  }), _c('br'), _vm._v("bar-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bar-chart-o fa-lg mt-4"
  }), _c('br'), _vm._v("bar-chart-o "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-line-chart fa-lg mt-4"
  }), _c('br'), _vm._v("line-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pie-chart fa-lg mt-4"
  }), _c('br'), _vm._v("pie-chart\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "currency"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Currency Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bitcoin fa-lg mt-4"
  }), _c('br'), _vm._v("bitcoin "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-btc fa-lg mt-4"
  }), _c('br'), _vm._v("btc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cny fa-lg mt-4"
  }), _c('br'), _vm._v("cny "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dollar fa-lg mt-4"
  }), _c('br'), _vm._v("dollar "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eur fa-lg mt-4"
  }), _c('br'), _vm._v("eur\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-euro fa-lg mt-4"
  }), _c('br'), _vm._v("euro "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gbp fa-lg mt-4"
  }), _c('br'), _vm._v("gbp\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gg fa-lg mt-4"
  }), _c('br'), _vm._v("gg\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gg-circle fa-lg mt-4"
  }), _c('br'), _vm._v("gg-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ils fa-lg mt-4"
  }), _c('br'), _vm._v("ils\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-inr fa-lg mt-4"
  }), _c('br'), _vm._v("inr\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-jpy fa-lg mt-4"
  }), _c('br'), _vm._v("jpy\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-krw fa-lg mt-4"
  }), _c('br'), _vm._v("krw\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-money fa-lg mt-4"
  }), _c('br'), _vm._v("money\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rmb fa-lg mt-4"
  }), _c('br'), _vm._v("rmb "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rouble fa-lg mt-4"
  }), _c('br'), _vm._v("rouble "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rub fa-lg mt-4"
  }), _c('br'), _vm._v("rub\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ruble fa-lg mt-4"
  }), _c('br'), _vm._v("ruble "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rupee fa-lg mt-4"
  }), _c('br'), _vm._v("rupee "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shekel fa-lg mt-4"
  }), _c('br'), _vm._v("shekel "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sheqel fa-lg mt-4"
  }), _c('br'), _vm._v("sheqel "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-try fa-lg mt-4"
  }), _c('br'), _vm._v("try\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-turkish-lira fa-lg mt-4"
  }), _c('br'), _vm._v("turkish-lira "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-usd fa-lg mt-4"
  }), _c('br'), _vm._v("usd\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-won fa-lg mt-4"
  }), _c('br'), _vm._v("won "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-yen fa-lg mt-4"
  }), _c('br'), _vm._v("yen "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "text-editor"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Text Editor Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-align-center fa-lg mt-4"
  }), _c('br'), _vm._v("align-center\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-align-justify fa-lg mt-4"
  }), _c('br'), _vm._v("align-justify\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-align-left fa-lg mt-4"
  }), _c('br'), _vm._v("align-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-align-right fa-lg mt-4"
  }), _c('br'), _vm._v("align-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bold fa-lg mt-4"
  }), _c('br'), _vm._v("bold\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chain fa-lg mt-4"
  }), _c('br'), _vm._v("chain "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chain-broken fa-lg mt-4"
  }), _c('br'), _vm._v("chain-broken\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-clipboard fa-lg mt-4"
  }), _c('br'), _vm._v("clipboard\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-columns fa-lg mt-4"
  }), _c('br'), _vm._v("columns\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-copy fa-lg mt-4"
  }), _c('br'), _vm._v("copy "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cut fa-lg mt-4"
  }), _c('br'), _vm._v("cut "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dedent fa-lg mt-4"
  }), _c('br'), _vm._v("dedent "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eraser fa-lg mt-4"
  }), _c('br'), _vm._v("eraser\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file fa-lg mt-4"
  }), _c('br'), _vm._v("file\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-text fa-lg mt-4"
  }), _c('br'), _vm._v("file-text\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-file-text-o fa-lg mt-4"
  }), _c('br'), _vm._v("file-text-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-files-o fa-lg mt-4"
  }), _c('br'), _vm._v("files-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-floppy-o fa-lg mt-4"
  }), _c('br'), _vm._v("floppy-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-font fa-lg mt-4"
  }), _c('br'), _vm._v("font\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-header fa-lg mt-4"
  }), _c('br'), _vm._v("header\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-indent fa-lg mt-4"
  }), _c('br'), _vm._v("indent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-italic fa-lg mt-4"
  }), _c('br'), _vm._v("italic\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-link fa-lg mt-4"
  }), _c('br'), _vm._v("link\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-list fa-lg mt-4"
  }), _c('br'), _vm._v("list\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-list-alt fa-lg mt-4"
  }), _c('br'), _vm._v("list-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-list-ol fa-lg mt-4"
  }), _c('br'), _vm._v("list-ol\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-list-ul fa-lg mt-4"
  }), _c('br'), _vm._v("list-ul\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-outdent fa-lg mt-4"
  }), _c('br'), _vm._v("outdent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paperclip fa-lg mt-4"
  }), _c('br'), _vm._v("paperclip\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paragraph fa-lg mt-4"
  }), _c('br'), _vm._v("paragraph\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paste fa-lg mt-4"
  }), _c('br'), _vm._v("paste "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-repeat fa-lg mt-4"
  }), _c('br'), _vm._v("repeat\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rotate-left fa-lg mt-4"
  }), _c('br'), _vm._v("rotate-left "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rotate-right fa-lg mt-4"
  }), _c('br'), _vm._v("rotate-right "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-save fa-lg mt-4"
  }), _c('br'), _vm._v("save "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-scissors fa-lg mt-4"
  }), _c('br'), _vm._v("scissors\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-strikethrough fa-lg mt-4"
  }), _c('br'), _vm._v("strikethrough\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-subscript fa-lg mt-4"
  }), _c('br'), _vm._v("subscript\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-superscript fa-lg mt-4"
  }), _c('br'), _vm._v("superscript\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-table fa-lg mt-4"
  }), _c('br'), _vm._v("table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-text-height fa-lg mt-4"
  }), _c('br'), _vm._v("text-height\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-text-width fa-lg mt-4"
  }), _c('br'), _vm._v("text-width\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-th fa-lg mt-4"
  }), _c('br'), _vm._v("th\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-th-large fa-lg mt-4"
  }), _c('br'), _vm._v("th-large\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-th-list fa-lg mt-4"
  }), _c('br'), _vm._v("th-list\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-underline fa-lg mt-4"
  }), _c('br'), _vm._v("underline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-undo fa-lg mt-4"
  }), _c('br'), _vm._v("undo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-unlink fa-lg mt-4"
  }), _c('br'), _vm._v("unlink "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "directional"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Directional Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-double-down fa-lg mt-4"
  }), _c('br'), _vm._v("angle-double-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-double-left fa-lg mt-4"
  }), _c('br'), _vm._v("angle-double-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-double-right fa-lg mt-4"
  }), _c('br'), _vm._v("angle-double-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-double-up fa-lg mt-4"
  }), _c('br'), _vm._v("angle-double-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-down fa-lg mt-4"
  }), _c('br'), _vm._v("angle-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-left fa-lg mt-4"
  }), _c('br'), _vm._v("angle-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-right fa-lg mt-4"
  }), _c('br'), _vm._v("angle-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angle-up fa-lg mt-4"
  }), _c('br'), _vm._v("angle-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-down fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-left fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-o-left fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-o-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-o-right fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-o-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-right fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-circle-up fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-circle-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-down fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-left fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-right fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrow-up fa-lg mt-4"
  }), _c('br'), _vm._v("arrow-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows fa-lg mt-4"
  }), _c('br'), _vm._v("arrows\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-alt fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-h fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-h\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-v fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-v\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-down fa-lg mt-4"
  }), _c('br'), _vm._v("caret-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-left fa-lg mt-4"
  }), _c('br'), _vm._v("caret-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-right fa-lg mt-4"
  }), _c('br'), _vm._v("caret-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-left fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-right fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-square-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("caret-square-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-caret-up fa-lg mt-4"
  }), _c('br'), _vm._v("caret-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-circle-down fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-circle-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-circle-left fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-circle-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-circle-right fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-circle-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-circle-up fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-circle-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-down fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-left fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-right fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chevron-up fa-lg mt-4"
  }), _c('br'), _vm._v("chevron-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-exchange fa-lg mt-4"
  }), _c('br'), _vm._v("exchange\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-down fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-left fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-right fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hand-o-up fa-lg mt-4"
  }), _c('br'), _vm._v("hand-o-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-long-arrow-down fa-lg mt-4"
  }), _c('br'), _vm._v("long-arrow-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-long-arrow-left fa-lg mt-4"
  }), _c('br'), _vm._v("long-arrow-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-long-arrow-right fa-lg mt-4"
  }), _c('br'), _vm._v("long-arrow-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-long-arrow-up fa-lg mt-4"
  }), _c('br'), _vm._v("long-arrow-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-down fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-down "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-left fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-left "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-right fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-right "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-toggle-up fa-lg mt-4"
  }), _c('br'), _vm._v("toggle-up "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "video-player"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Video Player Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-arrows-alt fa-lg mt-4"
  }), _c('br'), _vm._v("arrows-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-backward fa-lg mt-4"
  }), _c('br'), _vm._v("backward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-compress fa-lg mt-4"
  }), _c('br'), _vm._v("compress\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-eject fa-lg mt-4"
  }), _c('br'), _vm._v("eject\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-expand fa-lg mt-4"
  }), _c('br'), _vm._v("expand\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fast-backward fa-lg mt-4"
  }), _c('br'), _vm._v("fast-backward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fast-forward fa-lg mt-4"
  }), _c('br'), _vm._v("fast-forward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-forward fa-lg mt-4"
  }), _c('br'), _vm._v("forward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pause fa-lg mt-4"
  }), _c('br'), _vm._v("pause\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pause-circle fa-lg mt-4"
  }), _c('br'), _vm._v("pause-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pause-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("pause-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-play fa-lg mt-4"
  }), _c('br'), _vm._v("play\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-play-circle fa-lg mt-4"
  }), _c('br'), _vm._v("play-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-play-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("play-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-random fa-lg mt-4"
  }), _c('br'), _vm._v("random\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-step-backward fa-lg mt-4"
  }), _c('br'), _vm._v("step-backward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-step-forward fa-lg mt-4"
  }), _c('br'), _vm._v("step-forward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stop fa-lg mt-4"
  }), _c('br'), _vm._v("stop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stop-circle fa-lg mt-4"
  }), _c('br'), _vm._v("stop-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stop-circle-o fa-lg mt-4"
  }), _c('br'), _vm._v("stop-circle-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-youtube-play fa-lg mt-4"
  }), _c('br'), _vm._v("youtube-play\n        ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "brand"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Brand Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "alert alert-warning"
  }, [_c('h4', [_c('i', {
    staticClass: "fa fa-warning"
  }), _vm._v(" Warning!")]), _vm._v("\n        Apparently, Adblock Plus can remove Font Awesome brand icons with their \"Remove Social\n        Media Buttons\" setting. We will not use hacks to force them to display. Please\n        "), _c('a', {
    staticClass: "alert-link",
    attrs: {
      "href": "https://adblockplus.org/en/bugs"
    }
  }, [_vm._v("report an issue with Adblock Plus")]), _vm._v(" if you believe this to be\n        an error. To work around this, you'll need to modify the social icon class names.\n      ")]), _vm._v(" "), _c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-500px fa-lg mt-4"
  }), _c('br'), _vm._v("500px\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-adn fa-lg mt-4"
  }), _c('br'), _vm._v("adn\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-amazon fa-lg mt-4"
  }), _c('br'), _vm._v("amazon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-android fa-lg mt-4"
  }), _c('br'), _vm._v("android\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-angellist fa-lg mt-4"
  }), _c('br'), _vm._v("angellist\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-apple fa-lg mt-4"
  }), _c('br'), _vm._v("apple\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-behance fa-lg mt-4"
  }), _c('br'), _vm._v("behance\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-behance-square fa-lg mt-4"
  }), _c('br'), _vm._v("behance-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bitbucket fa-lg mt-4"
  }), _c('br'), _vm._v("bitbucket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bitbucket-square fa-lg mt-4"
  }), _c('br'), _vm._v("bitbucket-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bitcoin fa-lg mt-4"
  }), _c('br'), _vm._v("bitcoin "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-black-tie fa-lg mt-4"
  }), _c('br'), _vm._v("black-tie\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-bluetooth-b fa-lg mt-4"
  }), _c('br'), _vm._v("bluetooth-b\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-btc fa-lg mt-4"
  }), _c('br'), _vm._v("btc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-buysellads fa-lg mt-4"
  }), _c('br'), _vm._v("buysellads\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-amex fa-lg mt-4"
  }), _c('br'), _vm._v("cc-amex\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-diners-club fa-lg mt-4"
  }), _c('br'), _vm._v("cc-diners-club\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-discover fa-lg mt-4"
  }), _c('br'), _vm._v("cc-discover\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-jcb fa-lg mt-4"
  }), _c('br'), _vm._v("cc-jcb\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-mastercard fa-lg mt-4"
  }), _c('br'), _vm._v("cc-mastercard\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-paypal fa-lg mt-4"
  }), _c('br'), _vm._v("cc-paypal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-stripe fa-lg mt-4"
  }), _c('br'), _vm._v("cc-stripe\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-cc-visa fa-lg mt-4"
  }), _c('br'), _vm._v("cc-visa\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-chrome fa-lg mt-4"
  }), _c('br'), _vm._v("chrome\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-codepen fa-lg mt-4"
  }), _c('br'), _vm._v("codepen\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-codiepie fa-lg mt-4"
  }), _c('br'), _vm._v("codiepie\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-connectdevelop fa-lg mt-4"
  }), _c('br'), _vm._v("connectdevelop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-contao fa-lg mt-4"
  }), _c('br'), _vm._v("contao\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-css3 fa-lg mt-4"
  }), _c('br'), _vm._v("css3\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dashcube fa-lg mt-4"
  }), _c('br'), _vm._v("dashcube\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-delicious fa-lg mt-4"
  }), _c('br'), _vm._v("delicious\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-deviantart fa-lg mt-4"
  }), _c('br'), _vm._v("deviantart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-digg fa-lg mt-4"
  }), _c('br'), _vm._v("digg\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dribbble fa-lg mt-4"
  }), _c('br'), _vm._v("dribbble\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-dropbox fa-lg mt-4"
  }), _c('br'), _vm._v("dropbox\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-drupal fa-lg mt-4"
  }), _c('br'), _vm._v("drupal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-edge fa-lg mt-4"
  }), _c('br'), _vm._v("edge\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-empire fa-lg mt-4"
  }), _c('br'), _vm._v("empire\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-expeditedssl fa-lg mt-4"
  }), _c('br'), _vm._v("expeditedssl\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-facebook fa-lg mt-4"
  }), _c('br'), _vm._v("facebook\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-facebook-f fa-lg mt-4"
  }), _c('br'), _vm._v("facebook-f "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-facebook-official fa-lg mt-4"
  }), _c('br'), _vm._v("facebook-official\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-facebook-square fa-lg mt-4"
  }), _c('br'), _vm._v("facebook-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-firefox fa-lg mt-4"
  }), _c('br'), _vm._v("firefox\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-flickr fa-lg mt-4"
  }), _c('br'), _vm._v("flickr\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fonticons fa-lg mt-4"
  }), _c('br'), _vm._v("fonticons\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-fort-awesome fa-lg mt-4"
  }), _c('br'), _vm._v("fort-awesome\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-forumbee fa-lg mt-4"
  }), _c('br'), _vm._v("forumbee\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-foursquare fa-lg mt-4"
  }), _c('br'), _vm._v("foursquare\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ge fa-lg mt-4"
  }), _c('br'), _vm._v("ge "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-get-pocket fa-lg mt-4"
  }), _c('br'), _vm._v("get-pocket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gg fa-lg mt-4"
  }), _c('br'), _vm._v("gg\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gg-circle fa-lg mt-4"
  }), _c('br'), _vm._v("gg-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-git fa-lg mt-4"
  }), _c('br'), _vm._v("git\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-git-square fa-lg mt-4"
  }), _c('br'), _vm._v("git-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-github fa-lg mt-4"
  }), _c('br'), _vm._v("github\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-github-alt fa-lg mt-4"
  }), _c('br'), _vm._v("github-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-github-square fa-lg mt-4"
  }), _c('br'), _vm._v("github-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gittip fa-lg mt-4"
  }), _c('br'), _vm._v("gittip "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-google fa-lg mt-4"
  }), _c('br'), _vm._v("google\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-google-plus fa-lg mt-4"
  }), _c('br'), _vm._v("google-plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-google-plus-square fa-lg mt-4"
  }), _c('br'), _vm._v("google-plus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-google-wallet fa-lg mt-4"
  }), _c('br'), _vm._v("google-wallet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-gratipay fa-lg mt-4"
  }), _c('br'), _vm._v("gratipay\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hacker-news fa-lg mt-4"
  }), _c('br'), _vm._v("hacker-news\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-houzz fa-lg mt-4"
  }), _c('br'), _vm._v("houzz\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-html5 fa-lg mt-4"
  }), _c('br'), _vm._v("html5\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-instagram fa-lg mt-4"
  }), _c('br'), _vm._v("instagram\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-internet-explorer fa-lg mt-4"
  }), _c('br'), _vm._v("internet-explorer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ioxhost fa-lg mt-4"
  }), _c('br'), _vm._v("ioxhost\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-joomla fa-lg mt-4"
  }), _c('br'), _vm._v("joomla\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-jsfiddle fa-lg mt-4"
  }), _c('br'), _vm._v("jsfiddle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-lastfm fa-lg mt-4"
  }), _c('br'), _vm._v("lastfm\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-lastfm-square fa-lg mt-4"
  }), _c('br'), _vm._v("lastfm-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-leanpub fa-lg mt-4"
  }), _c('br'), _vm._v("leanpub\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-linkedin fa-lg mt-4"
  }), _c('br'), _vm._v("linkedin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-linkedin-square fa-lg mt-4"
  }), _c('br'), _vm._v("linkedin-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-linux fa-lg mt-4"
  }), _c('br'), _vm._v("linux\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-maxcdn fa-lg mt-4"
  }), _c('br'), _vm._v("maxcdn\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-meanpath fa-lg mt-4"
  }), _c('br'), _vm._v("meanpath\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-medium fa-lg mt-4"
  }), _c('br'), _vm._v("medium\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-mixcloud fa-lg mt-4"
  }), _c('br'), _vm._v("mixcloud\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-modx fa-lg mt-4"
  }), _c('br'), _vm._v("modx\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-odnoklassniki fa-lg mt-4"
  }), _c('br'), _vm._v("odnoklassniki\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-odnoklassniki-square fa-lg mt-4"
  }), _c('br'), _vm._v("odnoklassniki-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-opencart fa-lg mt-4"
  }), _c('br'), _vm._v("opencart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-openid fa-lg mt-4"
  }), _c('br'), _vm._v("openid\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-opera fa-lg mt-4"
  }), _c('br'), _vm._v("opera\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-optin-monster fa-lg mt-4"
  }), _c('br'), _vm._v("optin-monster\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pagelines fa-lg mt-4"
  }), _c('br'), _vm._v("pagelines\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-paypal fa-lg mt-4"
  }), _c('br'), _vm._v("paypal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pied-piper fa-lg mt-4"
  }), _c('br'), _vm._v("pied-piper\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pied-piper-alt fa-lg mt-4"
  }), _c('br'), _vm._v("pied-piper-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pinterest fa-lg mt-4"
  }), _c('br'), _vm._v("pinterest\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pinterest-p fa-lg mt-4"
  }), _c('br'), _vm._v("pinterest-p\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-pinterest-square fa-lg mt-4"
  }), _c('br'), _vm._v("pinterest-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-product-hunt fa-lg mt-4"
  }), _c('br'), _vm._v("product-hunt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-qq fa-lg mt-4"
  }), _c('br'), _vm._v("qq\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ra fa-lg mt-4"
  }), _c('br'), _vm._v("ra "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-rebel fa-lg mt-4"
  }), _c('br'), _vm._v("rebel\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reddit fa-lg mt-4"
  }), _c('br'), _vm._v("reddit\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reddit-alien fa-lg mt-4"
  }), _c('br'), _vm._v("reddit-alien\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-reddit-square fa-lg mt-4"
  }), _c('br'), _vm._v("reddit-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-renren fa-lg mt-4"
  }), _c('br'), _vm._v("renren\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-safari fa-lg mt-4"
  }), _c('br'), _vm._v("safari\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-scribd fa-lg mt-4"
  }), _c('br'), _vm._v("scribd\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-sellsy fa-lg mt-4"
  }), _c('br'), _vm._v("sellsy\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-alt fa-lg mt-4"
  }), _c('br'), _vm._v("share-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-share-alt-square fa-lg mt-4"
  }), _c('br'), _vm._v("share-alt-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-shirtsinbulk fa-lg mt-4"
  }), _c('br'), _vm._v("shirtsinbulk\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-simplybuilt fa-lg mt-4"
  }), _c('br'), _vm._v("simplybuilt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-skyatlas fa-lg mt-4"
  }), _c('br'), _vm._v("skyatlas\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-skype fa-lg mt-4"
  }), _c('br'), _vm._v("skype\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-slack fa-lg mt-4"
  }), _c('br'), _vm._v("slack\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-slideshare fa-lg mt-4"
  }), _c('br'), _vm._v("slideshare\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-soundcloud fa-lg mt-4"
  }), _c('br'), _vm._v("soundcloud\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-spotify fa-lg mt-4"
  }), _c('br'), _vm._v("spotify\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stack-exchange fa-lg mt-4"
  }), _c('br'), _vm._v("stack-exchange\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stack-overflow fa-lg mt-4"
  }), _c('br'), _vm._v("stack-overflow\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-steam fa-lg mt-4"
  }), _c('br'), _vm._v("steam\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-steam-square fa-lg mt-4"
  }), _c('br'), _vm._v("steam-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stumbleupon fa-lg mt-4"
  }), _c('br'), _vm._v("stumbleupon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stumbleupon-circle fa-lg mt-4"
  }), _c('br'), _vm._v("stumbleupon-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tencent-weibo fa-lg mt-4"
  }), _c('br'), _vm._v("tencent-weibo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-trello fa-lg mt-4"
  }), _c('br'), _vm._v("trello\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tripadvisor fa-lg mt-4"
  }), _c('br'), _vm._v("tripadvisor\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tumblr fa-lg mt-4"
  }), _c('br'), _vm._v("tumblr\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-tumblr-square fa-lg mt-4"
  }), _c('br'), _vm._v("tumblr-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-twitch fa-lg mt-4"
  }), _c('br'), _vm._v("twitch\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-twitter fa-lg mt-4"
  }), _c('br'), _vm._v("twitter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-twitter-square fa-lg mt-4"
  }), _c('br'), _vm._v("twitter-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-usb fa-lg mt-4"
  }), _c('br'), _vm._v("usb\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-viacoin fa-lg mt-4"
  }), _c('br'), _vm._v("viacoin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-vimeo fa-lg mt-4"
  }), _c('br'), _vm._v("vimeo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-vimeo-square fa-lg mt-4"
  }), _c('br'), _vm._v("vimeo-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-vine fa-lg mt-4"
  }), _c('br'), _vm._v("vine\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-vk fa-lg mt-4"
  }), _c('br'), _vm._v("vk\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wechat fa-lg mt-4"
  }), _c('br'), _vm._v("wechat "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-weibo fa-lg mt-4"
  }), _c('br'), _vm._v("weibo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-weixin fa-lg mt-4"
  }), _c('br'), _vm._v("weixin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-whatsapp fa-lg mt-4"
  }), _c('br'), _vm._v("whatsapp\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wikipedia-w fa-lg mt-4"
  }), _c('br'), _vm._v("wikipedia-w\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-windows fa-lg mt-4"
  }), _c('br'), _vm._v("windows\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wordpress fa-lg mt-4"
  }), _c('br'), _vm._v("wordpress\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-xing fa-lg mt-4"
  }), _c('br'), _vm._v("xing\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-xing-square fa-lg mt-4"
  }), _c('br'), _vm._v("xing-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-y-combinator fa-lg mt-4"
  }), _c('br'), _vm._v("y-combinator\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-y-combinator-square fa-lg mt-4"
  }), _c('br'), _vm._v("y-combinator-square "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-yahoo fa-lg mt-4"
  }), _c('br'), _vm._v("yahoo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-yc fa-lg mt-4"
  }), _c('br'), _vm._v("yc "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-yc-square fa-lg mt-4"
  }), _c('br'), _vm._v("yc-square "), _c('span', {
    staticClass: "text-muted"
  }, [_vm._v("(alias)")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-yelp fa-lg mt-4"
  }), _c('br'), _vm._v("yelp\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-youtube fa-lg mt-4"
  }), _c('br'), _vm._v("youtube\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-youtube-play fa-lg mt-4"
  }), _c('br'), _vm._v("youtube-play\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-youtube-square fa-lg mt-4"
  }), _c('br'), _vm._v("youtube-square\n        ")])]), _vm._v(" "), _c('div', {
    staticClass: "alert alert-success mt-4"
  }, [_c('ul', {
    staticClass: "margin-bottom-none padding-left-lg"
  }, [_c('li', [_vm._v("All brand icons are trademarks of their respective owners.")]), _vm._v(" "), _c('li', [_vm._v("The use of these trademarks does not indicate endorsement of the trademark holder by Font Awesome, nor vice versa.")]), _vm._v(" "), _c('li', [_vm._v("Brand icons should only be used to represent the company or product to which they refer.")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card",
    attrs: {
      "id": "medical"
    }
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("Medical Icons")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-ambulance fa-lg mt-4"
  }), _c('br'), _vm._v("ambulance\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-h-square fa-lg mt-4"
  }), _c('br'), _vm._v("h-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heart fa-lg mt-4"
  }), _c('br'), _vm._v("heart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heart-o fa-lg mt-4"
  }), _c('br'), _vm._v("heart-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-heartbeat fa-lg mt-4"
  }), _c('br'), _vm._v("heartbeat\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-hospital-o fa-lg mt-4"
  }), _c('br'), _vm._v("hospital-o\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-medkit fa-lg mt-4"
  }), _c('br'), _vm._v("medkit\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-plus-square fa-lg mt-4"
  }), _c('br'), _vm._v("plus-square\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-stethoscope fa-lg mt-4"
  }), _c('br'), _vm._v("stethoscope\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-user-md fa-lg mt-4"
  }), _c('br'), _vm._v("user-md\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3 col-lg-2"
  }, [_c('i', {
    staticClass: "fa fa-wheelchair fa-lg mt-4"
  }), _c('br'), _vm._v("wheelchair\n        ")])])])])])
}]}

/***/ }),

/***/ 520:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('footer', {
    staticClass: "app-footer"
  }, [_c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")]), _vm._v(" © 2017.\n  "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("Powered by "), _c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")])])])
}]}

/***/ }),

/***/ 521:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('dropdown', {
    staticClass: "float-right",
    attrs: {
      "type": "transparent p-0"
    }
  }, [_c('i', {
    staticClass: "icon-settings",
    slot: "button"
  }), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")])])]), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])], 1), _vm._v(" "), _c('card-line1-chart-example', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    },
    attrs: {
      "height": "70"
    }
  })], 1)]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('dropdown', {
    staticClass: "float-right",
    attrs: {
      "type": "transparent p-0"
    }
  }, [_c('i', {
    staticClass: "icon-settings",
    slot: "button"
  }), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")])])]), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])], 1), _vm._v(" "), _c('card-line2-chart-example', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    },
    attrs: {
      "height": "70"
    }
  })], 1)]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('dropdown', {
    staticClass: "float-right",
    attrs: {
      "type": "transparent p-0"
    }
  }, [_c('i', {
    staticClass: "icon-settings",
    slot: "button"
  }), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")])])])], 1), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('card-line3-chart-example', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "70px"
    },
    attrs: {
      "height": "70"
    }
  })], 1)]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('dropdown', {
    staticClass: "float-right",
    attrs: {
      "type": "transparent p-0"
    }
  }, [_c('i', {
    staticClass: "icon-settings",
    slot: "button"
  }), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")])])])], 1), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('card-bar-chart-example', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    },
    attrs: {
      "height": "70"
    }
  })], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_vm._m(0), _vm._v(" "), _c('main-chart-example', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "300px",
      "margin-top": "40px"
    },
    attrs: {
      "height": "300"
    }
  })], 1), _vm._v(" "), _vm._m(1)]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box facebook"
  }, [_c('i', {
    staticClass: "fa fa-facebook"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('social-box-chart-example', {
    attrs: {
      "data": [65, 59, 84, 84, 51, 55, 40],
      "height": "90"
    }
  })], 1), _vm._v(" "), _vm._m(2)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box twitter"
  }, [_c('i', {
    staticClass: "fa fa-twitter"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('social-box-chart-example', {
    attrs: {
      "data": [1, 13, 9, 17, 34, 41, 38],
      "height": "90"
    }
  })], 1), _vm._v(" "), _vm._m(3)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box linkedin"
  }, [_c('i', {
    staticClass: "fa fa-linkedin"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('social-box-chart-example', {
    attrs: {
      "data": [78, 81, 80, 45, 34, 12, 40],
      "height": "90"
    }
  })], 1), _vm._v(" "), _vm._m(4)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box google-plus"
  }, [_c('i', {
    staticClass: "fa fa-google-plus"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('social-box-chart-example', {
    attrs: {
      "data": [35, 23, 56, 22, 97, 23, 64],
      "height": "90"
    }
  })], 1), _vm._v(" "), _vm._m(5)])])]), _vm._v(" "), _vm._m(6)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-5"
  }, [_c('h4', {
    staticClass: "card-title mb-0"
  }, [_vm._v("Traffic")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("November 2016")])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-7 hidden-sm-down"
  }, [_c('button', {
    staticClass: "btn btn-primary float-right",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-cloud-download"
  })]), _vm._v(" "), _c('div', {
    staticClass: "btn-toolbar float-right",
    attrs: {
      "role": "toolbar",
      "aria-label": "Toolbar with button groups"
    }
  }, [_c('div', {
    staticClass: "btn-group mr-3",
    attrs: {
      "data-toggle": "buttons",
      "aria-label": "First group"
    }
  }, [_c('label', {
    staticClass: "btn btn-outline-secondary"
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "name": "options",
      "id": "option1"
    }
  }), _vm._v(" Day\n              ")]), _vm._v(" "), _c('label', {
    staticClass: "btn btn-outline-secondary active"
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "name": "options",
      "id": "option2",
      "checked": ""
    }
  }), _vm._v(" Month\n              ")]), _vm._v(" "), _c('label', {
    staticClass: "btn btn-outline-secondary"
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "name": "options",
      "id": "option3"
    }
  }), _vm._v(" Year\n              ")])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-footer"
  }, [_c('ul', [_c('li', [_c('div', {
    staticClass: "text-muted"
  }, [_vm._v("Visits")]), _vm._v(" "), _c('strong', [_vm._v("29.703 Users (40%)")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-2"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "40%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "40",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('li', {
    staticClass: "hidden-sm-down"
  }, [_c('div', {
    staticClass: "text-muted"
  }, [_vm._v("Unique")]), _vm._v(" "), _c('strong', [_vm._v("24.093 Users (20%)")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-2"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "20%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "20",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "text-muted"
  }, [_vm._v("Pageviews")]), _vm._v(" "), _c('strong', [_vm._v("78.706 Views (60%)")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-2"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "60%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "60",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('li', {
    staticClass: "hidden-sm-down"
  }, [_c('div', {
    staticClass: "text-muted"
  }, [_vm._v("New Users")]), _vm._v(" "), _c('strong', [_vm._v("22.123 Users (80%)")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-2"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "80%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "80",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('li', {
    staticClass: "hidden-sm-down"
  }, [_c('div', {
    staticClass: "text-muted"
  }, [_vm._v("Bounce Rate")]), _vm._v(" "), _c('strong', [_vm._v("40.15%")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-2"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "40%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "40",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', [_c('li', [_c('strong', [_vm._v("89k")]), _vm._v(" "), _c('span', [_vm._v("friends")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("459")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', [_c('li', [_c('strong', [_vm._v("973k")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("1.792")]), _vm._v(" "), _c('span', [_vm._v("tweets")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', [_c('li', [_c('strong', [_vm._v("500+")]), _vm._v(" "), _c('span', [_vm._v("contacts")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("292")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', [_c('li', [_c('strong', [_vm._v("894")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("92")]), _vm._v(" "), _c('span', [_vm._v("circles")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Traffic & Sales\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12 col-lg-4"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-info"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("New Clients")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("9,123")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-danger"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Recuring Clients")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("22,643")])])])]), _vm._v(" "), _c('hr', {
    staticClass: "mt-0"
  }), _vm._v(" "), _c('ul', {
    staticClass: "horizontal-bars"
  }, [_c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Monday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "34%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "34",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "78%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "78",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Tuesday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "56%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "56",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "94%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "94",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Wednesday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "12%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "12",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "67%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "67",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Thursday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "43%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "43",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "91%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "91",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Friday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "22%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "22",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "73%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "73",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Saturday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "53%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "53",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "82%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "82",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                    Sunday\n                  ")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "9%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "9",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "69%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "69",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', {
    staticClass: "legend"
  }, [_c('span', {
    staticClass: "badge badge-pill badge-info"
  }), _vm._v(" "), _c('small', [_vm._v("New clients")]), _vm._v("   "), _c('span', {
    staticClass: "badge badge-pill badge-danger"
  }), _vm._v(" "), _c('small', [_vm._v("Recurring clients")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-4"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-warning"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Pageviews")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("78,623")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-success"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Organic")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("49,123")])])])]), _vm._v(" "), _c('hr', {
    staticClass: "mt-0"
  }), _vm._v(" "), _c('ul', {
    staticClass: "horizontal-bars type-2"
  }, [_c('li', [_c('i', {
    staticClass: "icon-user"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("Male")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("43%")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "43%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "43",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-user-female"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("Female")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("37%")]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "37%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "37",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', {
    staticClass: "divider"
  }), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-globe"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("Organic Search")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("191,235 "), _c('span', {
    staticClass: "text-muted small"
  }, [_vm._v("(56%)")])]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "56%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "56",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-social-facebook"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("Facebook")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("51,223 "), _c('span', {
    staticClass: "text-muted small"
  }, [_vm._v("(15%)")])]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "15%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "15",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-social-twitter"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("Twitter")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("37,564 "), _c('span', {
    staticClass: "text-muted small"
  }, [_vm._v("(11%)")])]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "11%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "11",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-social-linkedin"
  }), _vm._v(" "), _c('span', {
    staticClass: "title"
  }, [_vm._v("LinkedIn")]), _vm._v(" "), _c('span', {
    staticClass: "value"
  }, [_vm._v("27,319 "), _c('span', {
    staticClass: "text-muted small"
  }, [_vm._v("(8%)")])]), _vm._v(" "), _c('div', {
    staticClass: "bars"
  }, [_c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "8%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "8",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('li', {
    staticClass: "divider text-center"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-link text-muted",
    attrs: {
      "type": "button",
      "data-toggle": "tooltip",
      "data-placement": "top",
      "title": "",
      "data-original-title": "show more"
    }
  }, [_c('i', {
    staticClass: "icon-options"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-4"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("CTR")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("23%")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-primary"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Bounce Rate")]), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("5%")])])])]), _vm._v(" "), _c('hr', {
    staticClass: "mt-0"
  }), _vm._v(" "), _c('ul', {
    staticClass: "icons-list"
  }, [_c('li', [_c('i', {
    staticClass: "icon-screen-desktop bg-primary"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("iMac 4k")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Sold this week")]), _vm._v(" "), _c('strong', [_vm._v("1.924")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-screen-smartphone bg-info"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("Samsung Galaxy Edge")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Sold this week")]), _vm._v(" "), _c('strong', [_vm._v("1.224")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-screen-smartphone bg-warning"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("iPhone 6S")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Sold this week")]), _vm._v(" "), _c('strong', [_vm._v("1.163")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-user bg-danger"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("Premium accounts")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Sold this week")]), _vm._v(" "), _c('strong', [_vm._v("928")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-social-spotify bg-success"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("Spotify Subscriptions")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Sold this week")]), _vm._v(" "), _c('strong', [_vm._v("893")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-cloud-download bg-danger"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("Ebook")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Downloads")]), _vm._v(" "), _c('strong', [_vm._v("121.924")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', [_c('i', {
    staticClass: "icon-camera bg-warning"
  }), _vm._v(" "), _c('div', {
    staticClass: "desc"
  }, [_c('div', {
    staticClass: "title"
  }, [_vm._v("Photos")]), _vm._v(" "), _c('small', [_vm._v("Lorem ipsum dolor sit amet")])]), _vm._v(" "), _c('div', {
    staticClass: "value"
  }, [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Uploaded")]), _vm._v(" "), _c('strong', [_vm._v("12.125")])]), _vm._v(" "), _c('div', {
    staticClass: "actions"
  }, [_c('button', {
    staticClass: "btn btn-link text-muted",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('li', {
    staticClass: "divider text-center"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-link text-muted",
    attrs: {
      "type": "button",
      "data-toggle": "tooltip",
      "data-placement": "top",
      "title": "show more"
    }
  }, [_c('i', {
    staticClass: "icon-options"
  })])])])])]), _vm._v(" "), _c('br'), _vm._v(" "), _c('table', {
    staticClass: "table table-hover table-outline mb-0"
  }, [_c('thead', {
    staticClass: "thead-default"
  }, [_c('tr', [_c('th', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "icon-people"
  })]), _vm._v(" "), _c('th', [_vm._v("User")]), _vm._v(" "), _c('th', {
    staticClass: "text-center"
  }, [_vm._v("Country")]), _vm._v(" "), _c('th', [_vm._v("Usage")]), _vm._v(" "), _c('th', {
    staticClass: "text-center"
  }, [_vm._v("Payment Method")]), _vm._v(" "), _c('th', [_vm._v("Activity")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/1.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-success"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Yiorgos Avraamu")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/USA.png",
      "alt": "USA"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("50%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "50%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "50",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-cc-mastercard",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("10 sec ago")])])]), _vm._v(" "), _c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/2.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-danger"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Avram Tarasios")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("Recurring")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/Brazil.png",
      "alt": "Brazil"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("10%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "10%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "10",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-cc-visa",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("5 minutes ago")])])]), _vm._v(" "), _c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/3.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-warning"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Quintin Ed")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/India.png",
      "alt": "India"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("74%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "74%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "74",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-cc-stripe",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("1 hour ago")])])]), _vm._v(" "), _c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/4.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-default"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Enéas Kwadwo")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/France.png",
      "alt": "France"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("98%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "98%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "98",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-paypal",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("Last month")])])]), _vm._v(" "), _c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/5.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-success"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Agapetus Tadeáš")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/Spain.png",
      "alt": "Spain"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("22%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "22%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "22",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-google-wallet",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("Last week")])])]), _vm._v(" "), _c('tr', [_c('td', {
    staticClass: "text-center"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status badge-danger"
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Friderik Dávid")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v(" | Registered: Jan 1, 2015\n                  ")])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('img', {
    staticStyle: {
      "height": "24px"
    },
    attrs: {
      "src": "images/flags/Poland.png",
      "alt": "Poland"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "clearfix"
  }, [_c('div', {
    staticClass: "float-left"
  }, [_c('strong', [_vm._v("43%")])]), _vm._v(" "), _c('div', {
    staticClass: "float-right"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Jun 11, 2015 - Jul 10, 2015")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "43%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "43",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])]), _vm._v(" "), _c('td', {
    staticClass: "text-center"
  }, [_c('i', {
    staticClass: "fa fa-cc-amex",
    staticStyle: {
      "font-size": "24px"
    }
  })]), _vm._v(" "), _c('td', [_c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("Yesterday")])])])])])])])])])
}]}

/***/ }),

/***/ 522:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app flex-row align-items-center"
  }, [_c('div', {
    staticClass: "container"
  }, [_c('div', {
    staticClass: "row justify-content-center"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "clearfix"
  }, [_c('h1', {
    staticClass: "float-left display-3 mr-4"
  }, [_vm._v("404")]), _vm._v(" "), _c('h4', {
    staticClass: "pt-3"
  }, [_vm._v("Oops! You're lost.")]), _vm._v(" "), _c('p', {
    staticClass: "text-muted"
  }, [_vm._v("The page you are looking for was not found.")])]), _vm._v(" "), _c('div', {
    staticClass: "input-prepend input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-search"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "prependedInput",
      "size": "16",
      "type": "text",
      "placeholder": "What are you looking for?"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-info",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Search")])])])])])])])
}]}

/***/ }),

/***/ 523:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('navbar', [_c('button', {
    staticClass: "navbar-toggler mobile-sidebar-toggler d-lg-none",
    attrs: {
      "type": "button"
    },
    on: {
      "click": _vm.mobileSidebarToggle
    }
  }, [_vm._v("☰")]), _vm._v(" "), _c('a', {
    staticClass: "navbar-brand",
    attrs: {
      "href": "#"
    }
  }), _vm._v(" "), _c('ul', {
    staticClass: "nav navbar-nav d-md-down-none"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link navbar-toggler sidebar-toggler",
    attrs: {
      "href": "#"
    },
    on: {
      "click": _vm.sidebarMinimize
    }
  }, [_vm._v("☰")])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item px-3"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Dashboard")])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item px-3"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Users")])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item px-3"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Settings")])])]), _vm._v(" "), _c('ul', {
    staticClass: "nav navbar-nav ml-auto"
  }, [_c('li', {
    staticClass: "nav-item d-md-down-none"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-bell"
  }), _c('span', {
    staticClass: "badge badge-pill badge-danger"
  }, [_vm._v("5")])])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item d-md-down-none"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-list"
  })])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item d-md-down-none"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-location-pin"
  })])]), _vm._v(" "), _c('dropdown', {
    staticClass: "nav-item",
    attrs: {
      "size": "nav"
    }
  }, [_c('span', {
    slot: "button"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "images/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "d-md-down-none"
  }, [_vm._v("admin")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right",
    slot: "dropdown-menu"
  }, [_c('div', {
    staticClass: "dropdown-header text-center"
  }, [_c('strong', [_vm._v("Account")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-bell-o"
  }), _vm._v(" Updates"), _c('span', {
    staticClass: "badge badge-info"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-envelope-o"
  }), _vm._v(" Messages"), _c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-tasks"
  }), _vm._v(" Tasks"), _c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-comments"
  }), _vm._v(" Comments"), _c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("42")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-header text-center"
  }, [_c('strong', [_vm._v("Settings")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-user"
  }), _vm._v(" Profile")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-wrench"
  }), _vm._v(" Settings")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-usd"
  }), _vm._v(" Payments"), _c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-file"
  }), _vm._v(" Projects"), _c('span', {
    staticClass: "badge badge-primary"
  }, [_vm._v("42")])]), _vm._v(" "), _c('div', {
    staticClass: "divider"
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-shield"
  }), _vm._v(" Lock Account")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-lock"
  }), _vm._v(" Logout")])])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item d-md-down-none"
  }, [_c('a', {
    staticClass: "nav-link navbar-toggler aside-menu-toggler",
    attrs: {
      "href": "#"
    },
    on: {
      "click": _vm.asideToggle
    }
  }, [_vm._v("☰")])])], 1)])
},staticRenderFns: []}

/***/ }),

/***/ 524:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          3d Switch\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-3d switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-3d switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-3d switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-3d switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-3d switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-3d switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch default\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch default - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-pill switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch outline - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-pill switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch outline alternative\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch outline alternative - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-default switch-pill switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-default switch-pill switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-pill switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text outline - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-pill switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text outline alternative\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with text outline alternative - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-text switch-pill switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-pill switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-secondary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-success"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-warning"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-info"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-danger"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon outline - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-pill switch-primary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-secondary-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-success-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-warning-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-info-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-danger-outline"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon outline alternative\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Switch with icon outline alternative - pills\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('label', {
    staticClass: "switch switch-icon switch-pill switch-primary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-secondary-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-success-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-warning-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-info-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })]), _vm._v("\n             \n          "), _c('label', {
    staticClass: "switch switch-icon switch-pill switch-danger-outline-alt"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "&#xf00c",
      "data-off": "&#xf00d"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Sizes\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block p-0"
  }, [_c('table', {
    staticClass: "table table-hover table-striped table-align-middle mb-0"
  }, [_c('thead', [_c('th', [_vm._v("Size")]), _vm._v(" "), _c('th', [_vm._v("Example")]), _vm._v(" "), _c('th', [_vm._v("CSS Class")])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("\n                  Large\n                ")]), _vm._v(" "), _c('td', [_c('label', {
    staticClass: "switch switch-lg switch-3d switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('td', [_vm._v("\n                  Add following class "), _c('code', [_vm._v(".switch-lg")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("\n                  Normal\n                ")]), _vm._v(" "), _c('td', [_c('label', {
    staticClass: "switch switch-3d switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('td', [_vm._v("\n                  -\n                ")])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("\n                  Small\n                ")]), _vm._v(" "), _c('td', [_c('label', {
    staticClass: "switch switch-sm switch-3d switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('td', [_vm._v("\n                  Add following class "), _c('code', [_vm._v(".switch-sm")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("\n                  Extra small\n                ")]), _vm._v(" "), _c('td', [_c('label', {
    staticClass: "switch switch-xs switch-3d switch-primary"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label"
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('td', [_vm._v("\n                  Add following class "), _c('code', [_vm._v(".switch-sm")])])])])])])])])])])
}]}

/***/ }),

/***/ 525:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_vm._m(0), _vm._v(" "), _vm._m(1), _vm._v(" "), _vm._m(2), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_vm._m(3), _vm._v(" "), _vm._m(4), _vm._v(" "), _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_vm._m(5), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('div', {
    staticClass: "input-group-btn"
  }, [_c('dropdown', {
    attrs: {
      "text": "Action",
      "type": "primary"
    }
  }, [_c('div', {
    staticClass: "dropdown-menu",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-divider",
    attrs: {
      "role": "separator"
    }
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Separated link")])])])], 1), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input1-group3",
      "name": "input1-group3",
      "placeholder": "Username"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "input2-group3",
      "name": "input2-group3",
      "placeholder": "Email"
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "input-group-btn"
  }, [_c('dropdown', {
    attrs: {
      "text": "Action",
      "type": "primary"
    }
  }, [_c('div', {
    staticClass: "dropdown-menu",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-divider",
    attrs: {
      "role": "separator"
    }
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Separated link")])])])], 1)])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('div', {
    staticClass: "input-group-btn"
  }, [_c('dropdown', {
    attrs: {
      "type": "primary"
    }
  }, [_c('button', {
    staticClass: "btn btn-info",
    attrs: {
      "type": "button"
    },
    slot: "before"
  }, [_vm._v("Segmented")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-divider",
    attrs: {
      "role": "separator"
    }
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Separated link")])])])], 1), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input3-group3",
      "name": "input3-group3",
      "placeholder": ".."
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "input-group-btn"
  }, [_c('dropdown', {
    attrs: {
      "text": "Action",
      "type": "primary"
    }
  }, [_c('div', {
    staticClass: "dropdown-menu",
    slot: "dropdown-menu"
  }, [_c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Another action")]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Something else here")]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-divider",
    attrs: {
      "role": "separator"
    }
  }), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Separated link")])])])], 1)])])])])]), _vm._v(" "), _vm._m(6)])])]), _vm._v(" "), _vm._m(7), _vm._v(" "), _vm._m(8), _vm._v(" "), _vm._m(9)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Credit Card")]), _vm._v(" "), _c('small', [_vm._v("Form")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "name"
    }
  }, [_vm._v("Name")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "name",
      "placeholder": "Enter your name"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "ccnumber"
    }
  }, [_vm._v("Credit Card Number")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "ccnumber",
      "placeholder": "0000 0000 0000 0000"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "form-group col-sm-4"
  }, [_c('label', {
    attrs: {
      "for": "ccmonth"
    }
  }, [_vm._v("Month")]), _vm._v(" "), _c('select', {
    staticClass: "form-control",
    attrs: {
      "id": "ccmonth"
    }
  }, [_c('option', [_vm._v("1")]), _vm._v(" "), _c('option', [_vm._v("2")]), _vm._v(" "), _c('option', [_vm._v("3")]), _vm._v(" "), _c('option', [_vm._v("4")]), _vm._v(" "), _c('option', [_vm._v("5")]), _vm._v(" "), _c('option', [_vm._v("6")]), _vm._v(" "), _c('option', [_vm._v("7")]), _vm._v(" "), _c('option', [_vm._v("8")]), _vm._v(" "), _c('option', [_vm._v("9")]), _vm._v(" "), _c('option', [_vm._v("10")]), _vm._v(" "), _c('option', [_vm._v("11")]), _vm._v(" "), _c('option', [_vm._v("12")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group col-sm-4"
  }, [_c('label', {
    attrs: {
      "for": "ccyear"
    }
  }, [_vm._v("Year")]), _vm._v(" "), _c('select', {
    staticClass: "form-control",
    attrs: {
      "id": "ccyear"
    }
  }, [_c('option', [_vm._v("2014")]), _vm._v(" "), _c('option', [_vm._v("2015")]), _vm._v(" "), _c('option', [_vm._v("2016")]), _vm._v(" "), _c('option', [_vm._v("2017")]), _vm._v(" "), _c('option', [_vm._v("2018")]), _vm._v(" "), _c('option', [_vm._v("2019")]), _vm._v(" "), _c('option', [_vm._v("2020")]), _vm._v(" "), _c('option', [_vm._v("2021")]), _vm._v(" "), _c('option', [_vm._v("2022")]), _vm._v(" "), _c('option', [_vm._v("2023")]), _vm._v(" "), _c('option', [_vm._v("2024")]), _vm._v(" "), _c('option', [_vm._v("2025")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "cvv"
    }
  }, [_vm._v("CVV/CVC")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "cvv",
      "placeholder": "123"
    }
  })])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Company")]), _vm._v(" "), _c('small', [_vm._v("Form")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "company"
    }
  }, [_vm._v("Company")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "company",
      "placeholder": "Enter your company name"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "vat"
    }
  }, [_vm._v("VAT")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "vat",
      "placeholder": "PL1234567890"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "street"
    }
  }, [_vm._v("Street")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "street",
      "placeholder": "Enter street name"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "form-group col-sm-8"
  }, [_c('label', {
    attrs: {
      "for": "city"
    }
  }, [_vm._v("City")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "city",
      "placeholder": "Enter your city"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group col-sm-4"
  }, [_c('label', {
    attrs: {
      "for": "postal-code"
    }
  }, [_vm._v("Postal Code")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "postal-code",
      "placeholder": "Postal Code"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "country"
    }
  }, [_vm._v("Country")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "country",
      "placeholder": "Country name"
    }
  })])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Basic Form")]), _vm._v(" Elements\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post",
      "enctype": "multipart/form-data"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label"
  }, [_vm._v("Static")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('p', {
    staticClass: "form-control-static"
  }, [_vm._v("Username")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "text-input"
    }
  }, [_vm._v("Text Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "text-input",
      "name": "text-input",
      "placeholder": "Text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("This is a help text")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "email-input"
    }
  }, [_vm._v("Email Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "email-input",
      "name": "email-input",
      "placeholder": "Enter Email"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter your email")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "password-input"
    }
  }, [_vm._v("Password")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "password-input",
      "name": "password-input",
      "placeholder": "Password"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter a complex password")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "disabled-input"
    }
  }, [_vm._v("Disabled Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "disabled-input",
      "name": "disabled-input",
      "placeholder": "Disabled",
      "disabled": ""
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "textarea-input"
    }
  }, [_vm._v("Textarea")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('textarea', {
    staticClass: "form-control",
    attrs: {
      "id": "textarea-input",
      "name": "textarea-input",
      "rows": "9",
      "placeholder": "Content.."
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "select"
    }
  }, [_vm._v("Select")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('select', {
    staticClass: "form-control",
    attrs: {
      "id": "select",
      "name": "select"
    }
  }, [_c('option', {
    attrs: {
      "value": "0"
    }
  }, [_vm._v("Please select")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "1"
    }
  }, [_vm._v("Option #1")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "2"
    }
  }, [_vm._v("Option #2")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "3"
    }
  }, [_vm._v("Option #3")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "select"
    }
  }, [_vm._v("Select Large")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('select', {
    staticClass: "form-control form-control-lg",
    attrs: {
      "id": "select",
      "name": "select"
    }
  }, [_c('option', {
    attrs: {
      "value": "0"
    }
  }, [_vm._v("Please select")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "1"
    }
  }, [_vm._v("Option #1")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "2"
    }
  }, [_vm._v("Option #2")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "3"
    }
  }, [_vm._v("Option #3")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "select"
    }
  }, [_vm._v("Select Small")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('select', {
    staticClass: "form-control form-control-sm",
    attrs: {
      "id": "select",
      "name": "select"
    }
  }, [_c('option', {
    attrs: {
      "value": "0"
    }
  }, [_vm._v("Please select")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "1"
    }
  }, [_vm._v("Option #1")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "2"
    }
  }, [_vm._v("Option #2")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "3"
    }
  }, [_vm._v("Option #3")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "select"
    }
  }, [_vm._v("Disabled Select")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('select', {
    staticClass: "form-control",
    attrs: {
      "id": "disabledSelect",
      "disabled": ""
    }
  }, [_c('option', {
    attrs: {
      "value": "0"
    }
  }, [_vm._v("Please select")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "1"
    }
  }, [_vm._v("Option #1")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "2"
    }
  }, [_vm._v("Option #2")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "3"
    }
  }, [_vm._v("Option #3")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "multiple-select"
    }
  }, [_vm._v("Multiple select")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('select', {
    staticClass: "form-control",
    attrs: {
      "id": "multiple-select",
      "name": "multiple-select",
      "size": "5",
      "multiple": ""
    }
  }, [_c('option', {
    attrs: {
      "value": "1"
    }
  }, [_vm._v("Option #1")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "2"
    }
  }, [_vm._v("Option #2")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "3"
    }
  }, [_vm._v("Option #3")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "4"
    }
  }, [_vm._v("Option #4")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "5"
    }
  }, [_vm._v("Option #5")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "6"
    }
  }, [_vm._v("Option #6")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "7"
    }
  }, [_vm._v("Option #7")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "8"
    }
  }, [_vm._v("Option #8")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "9"
    }
  }, [_vm._v("Option #9")]), _vm._v(" "), _c('option', {
    attrs: {
      "value": "10"
    }
  }, [_vm._v("Option #10")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label"
  }, [_vm._v("Radios")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('div', {
    staticClass: "radio"
  }, [_c('label', {
    attrs: {
      "for": "radio1"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "radio1",
      "name": "radios",
      "value": "option1"
    }
  }), _vm._v(" Option 1\n                  ")])]), _vm._v(" "), _c('div', {
    staticClass: "radio"
  }, [_c('label', {
    attrs: {
      "for": "radio2"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "radio2",
      "name": "radios",
      "value": "option2"
    }
  }), _vm._v(" Option 2\n                  ")])]), _vm._v(" "), _c('div', {
    staticClass: "radio"
  }, [_c('label', {
    attrs: {
      "for": "radio3"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "radio3",
      "name": "radios",
      "value": "option3"
    }
  }), _vm._v(" Option 3\n                  ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label"
  }, [_vm._v("Inline Radios")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('label', {
    staticClass: "radio-inline",
    attrs: {
      "for": "inline-radio1"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "inline-radio1",
      "name": "inline-radios",
      "value": "option1"
    }
  }), _vm._v(" One\n                ")]), _vm._v(" "), _c('label', {
    staticClass: "radio-inline",
    attrs: {
      "for": "inline-radio2"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "inline-radio2",
      "name": "inline-radios",
      "value": "option2"
    }
  }), _vm._v(" Two\n                ")]), _vm._v(" "), _c('label', {
    staticClass: "radio-inline",
    attrs: {
      "for": "inline-radio3"
    }
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "id": "inline-radio3",
      "name": "inline-radios",
      "value": "option3"
    }
  }), _vm._v(" Three\n                ")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label"
  }, [_vm._v("Checkboxes")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('div', {
    staticClass: "checkbox"
  }, [_c('label', {
    attrs: {
      "for": "checkbox1"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "checkbox1",
      "name": "checkbox1",
      "value": "option1"
    }
  }), _vm._v(" Option 1\n                  ")])]), _vm._v(" "), _c('div', {
    staticClass: "checkbox"
  }, [_c('label', {
    attrs: {
      "for": "checkbox2"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "checkbox2",
      "name": "checkbox2",
      "value": "option2"
    }
  }), _vm._v(" Option 2\n                  ")])]), _vm._v(" "), _c('div', {
    staticClass: "checkbox"
  }, [_c('label', {
    attrs: {
      "for": "checkbox3"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "checkbox3",
      "name": "checkbox3",
      "value": "option3"
    }
  }), _vm._v(" Option 3\n                  ")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label"
  }, [_vm._v("Inline Checkboxes")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('label', {
    staticClass: "checkbox-inline",
    attrs: {
      "for": "inline-checkbox1"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "inline-checkbox1",
      "name": "inline-checkbox1",
      "value": "option1"
    }
  }), _vm._v("One\n                ")]), _vm._v(" "), _c('label', {
    staticClass: "checkbox-inline",
    attrs: {
      "for": "inline-checkbox2"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "inline-checkbox2",
      "name": "inline-checkbox2",
      "value": "option2"
    }
  }), _vm._v("Two\n                ")]), _vm._v(" "), _c('label', {
    staticClass: "checkbox-inline",
    attrs: {
      "for": "inline-checkbox3"
    }
  }, [_c('input', {
    attrs: {
      "type": "checkbox",
      "id": "inline-checkbox3",
      "name": "inline-checkbox3",
      "value": "option3"
    }
  }), _vm._v("Three\n                ")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "file-input"
    }
  }, [_vm._v("File input")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    attrs: {
      "type": "file",
      "id": "file-input",
      "name": "file-input"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "file-multiple-input"
    }
  }, [_vm._v("Multiple File input")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    attrs: {
      "type": "file",
      "id": "file-multiple-input",
      "name": "file-multiple-input",
      "multiple": ""
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Inline")]), _vm._v(" Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-inline",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "exampleInputName2"
    }
  }, [_vm._v("Name")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "exampleInputName2",
      "placeholder": "Jane Doe"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "exampleInputEmail2"
    }
  }, [_vm._v("Email")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "exampleInputEmail2",
      "placeholder": "jane.doe@example.com"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Horizontal")]), _vm._v(" Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "hf-email"
    }
  }, [_vm._v("Email")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "hf-email",
      "name": "hf-email",
      "placeholder": "Enter Email.."
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter your email")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-md-3 form-control-label",
    attrs: {
      "for": "hf-password"
    }
  }, [_vm._v("Password")]), _vm._v(" "), _c('div', {
    staticClass: "col-md-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "hf-password",
      "name": "hf-password",
      "placeholder": "Enter Password.."
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter your password")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Normal")]), _vm._v(" Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "nf-email"
    }
  }, [_vm._v("Email")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "nf-email",
      "name": "nf-email",
      "placeholder": "Enter Email.."
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter your email")])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "nf-password"
    }
  }, [_vm._v("Password")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "nf-password",
      "name": "nf-password",
      "placeholder": "Enter Password.."
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Please enter your password")])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Input "), _c('strong', [_vm._v("Grid")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-3"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-3"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-4"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-4"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-5"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-5"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-6"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-7"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-7"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-8"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-8"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-9"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-9"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-10"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-10"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-11"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-11"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-sm-12"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-sm-12"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-user"
  }), _vm._v(" Login")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Input "), _c('strong', [_vm._v("Sizes")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-sm-5 form-control-label",
    attrs: {
      "for": "input-small"
    }
  }, [_vm._v("Small Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('input', {
    staticClass: "form-control form-control-sm",
    attrs: {
      "type": "text",
      "id": "input-small",
      "name": "input-small",
      "placeholder": ".form-control-sm"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-sm-5 form-control-label",
    attrs: {
      "for": "input-normal"
    }
  }, [_vm._v("Normal Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input-normal",
      "name": "input-normal",
      "placeholder": "Normal"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('label', {
    staticClass: "col-sm-5 form-control-label",
    attrs: {
      "for": "input-large"
    }
  }, [_vm._v("Large Input")]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('input', {
    staticClass: "form-control form-control-lg",
    attrs: {
      "type": "text",
      "id": "input-large",
      "name": "input-large",
      "placeholder": ".form-control-lg"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Validation states")]), _vm._v(" Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group has-success"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputSuccess1"
    }
  }, [_vm._v("Input with success")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "inputSuccess1"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group has-warning"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputWarning1"
    }
  }, [_vm._v("Input with warning")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "inputWarning1"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group has-danger"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputError1"
    }
  }, [_vm._v("Input with error")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "inputError1"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Validation states")]), _vm._v(" with optional icons\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group has-success"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputSuccess2"
    }
  }, [_vm._v("Input with success")]), _vm._v(" "), _c('input', {
    staticClass: "form-control form-control-success",
    attrs: {
      "type": "text",
      "id": "inputSuccess2"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group has-warning"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputWarning2"
    }
  }, [_vm._v("Input with warning")]), _vm._v(" "), _c('input', {
    staticClass: "form-control form-control-warning",
    attrs: {
      "type": "text",
      "id": "inputWarning2"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group has-danger has-feedback"
  }, [_c('label', {
    staticClass: "form-form-control-label",
    attrs: {
      "for": "inputError2"
    }
  }, [_vm._v("Input with error")]), _vm._v(" "), _c('input', {
    staticClass: "form-control form-control-danger",
    attrs: {
      "type": "text",
      "id": "inputError2"
    }
  })])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Icon/Text")]), _vm._v(" Groups\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-user"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input1-group1",
      "name": "input1-group1",
      "placeholder": "Username"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "input2-group1",
      "name": "input2-group1",
      "placeholder": "Email"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-envelope-o"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-euro"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input3-group1",
      "name": "input3-group1",
      "placeholder": ".."
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v(".00")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Buttons")]), _vm._v(" Groups\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-search"
  }), _vm._v(" Search")])]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input1-group2",
      "name": "input1-group2",
      "placeholder": "Username"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "input2-group2",
      "name": "input2-group2",
      "placeholder": "Email"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Submit")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-facebook"
  })])]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "input3-group2",
      "name": "input3-group2",
      "placeholder": "Search"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-twitter"
  })])])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Dropdowns")]), _vm._v(" Groups\n        ")])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "submit"
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Use the grid for big devices! "), _c('small', [_c('code', [_vm._v(".col-lg-*")]), _vm._v(" "), _c('code', [_vm._v(".col-md-*")]), _vm._v(" "), _c('code', [_vm._v(".col-sm-*")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-8"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-8"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-md-4"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-4"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-7"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-7"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-md-5"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-5"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-6"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-6"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-5"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-5"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-md-7"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-7"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-md-4"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-4"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-md-8"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-md-8"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-warning",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-info",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Input Grid for small devices! "), _c('small', [_c('code', [_vm._v(".col-*")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-horizontal",
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-4"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-4"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-8"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-8"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-5"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-5"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-7"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-7"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-6"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-6"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-6"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-7"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-5"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-5"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-5"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group row"
  }, [_c('div', {
    staticClass: "col-8"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-8"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "col-4"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": ".col-4"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-warning",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-info",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Action")])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Example Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("Username")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "username3",
      "name": "username3"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-user"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("Email")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "email3",
      "name": "email3"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-envelope"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("Password")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "password3",
      "name": "password3"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-asterisk"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group form-actions"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Submit")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Example Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "username2",
      "name": "username2",
      "placeholder": "Username"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-user"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "email2",
      "name": "email2",
      "placeholder": "Email"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-envelope"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "password2",
      "name": "password2",
      "placeholder": "Password"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-asterisk"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group form-actions"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-default",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Submit")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Example Form\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    attrs: {
      "action": "",
      "method": "post"
    }
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-user"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "id": "username",
      "name": "username",
      "placeholder": "Username"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-envelope"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "email",
      "id": "email",
      "name": "email",
      "placeholder": "Email"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-asterisk"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "id": "password",
      "name": "password",
      "placeholder": "Password"
    }
  })])]), _vm._v(" "), _c('div', {
    staticClass: "form-group form-actions"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-success",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Submit")])])])])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-lg-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-edit"
  }), _vm._v("Form Elements\n          "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    staticClass: "btn-setting",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn-minimize",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-arrow-up"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn-close",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-close"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('form', {
    staticClass: "form-2orizontal"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "form-control-label",
    attrs: {
      "for": "prependedInput"
    }
  }, [_vm._v("Prepended text")]), _vm._v(" "), _c('div', {
    staticClass: "controls"
  }, [_c('div', {
    staticClass: "input-prepend input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("@")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "prependedInput",
      "size": "16",
      "type": "text"
    }
  })]), _vm._v(" "), _c('p', {
    staticClass: "help-block"
  }, [_vm._v("Here's some help text")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "form-control-label",
    attrs: {
      "for": "appendedInput"
    }
  }, [_vm._v("Appended text")]), _vm._v(" "), _c('div', {
    staticClass: "controls"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "appendedInput",
      "size": "16",
      "type": "text"
    }
  }), _c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v(".00")])]), _vm._v(" "), _c('span', {
    staticClass: "help-block"
  }, [_vm._v("Here's more help text")])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "form-control-label",
    attrs: {
      "for": "appendedPrependedInput"
    }
  }, [_vm._v("Append and prepend")]), _vm._v(" "), _c('div', {
    staticClass: "controls"
  }, [_c('div', {
    staticClass: "input-prepend input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("$")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "appendedPrependedInput",
      "size": "16",
      "type": "text"
    }
  }), _c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v(".00")])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "form-control-label",
    attrs: {
      "for": "appendedInputButton"
    }
  }, [_vm._v("Append with button")]), _vm._v(" "), _c('div', {
    staticClass: "controls"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "appendedInputButton",
      "size": "16",
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-default",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Go!")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    staticClass: "form-control-label",
    attrs: {
      "for": "appendedInputButtons"
    }
  }, [_vm._v("Two-button append")]), _vm._v(" "), _c('div', {
    staticClass: "controls"
  }, [_c('div', {
    staticClass: "input-group"
  }, [_c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "appendedInputButtons",
      "size": "16",
      "type": "text"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-default",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Search")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-default",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Options")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "form-actions"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "submit"
    }
  }, [_vm._v("Save changes")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-default",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Cancel")])])])])])])])
}]}

/***/ }),

/***/ 526:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ol', {
    staticClass: "breadcrumb"
  }, _vm._l((_vm.list), function(item, index) {
    return _c('li', {
      staticClass: "breadcrumb-item"
    }, [(_vm.isLast(index)) ? _c('span', {
      staticClass: "active"
    }, [_vm._v(_vm._s(_vm.showName(item)))]) : _c('router-link', {
      attrs: {
        "to": item.path
      }
    }, [_vm._v(_vm._s(_vm.showName(item)))])], 1)
  }))
},staticRenderFns: []}

/***/ }),

/***/ 527:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app flex-row align-items-center"
  }, [_c('div', {
    staticClass: "container"
  }, [_c('div', {
    staticClass: "row justify-content-center"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card mx-4"
  }, [_c('div', {
    staticClass: "card-block p-4"
  }, [_c('h1', [_vm._v("Register")]), _vm._v(" "), _c('p', {
    staticClass: "text-muted"
  }, [_vm._v("Create your account")]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-3"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "icon-user"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Username"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-3"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_vm._v("@")]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Email"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-3"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "icon-lock"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "placeholder": "Password"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-4"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "icon-lock"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "placeholder": "Repeat password"
    }
  })]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-block btn-success",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Create Account")])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer p-4"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-6"
  }, [_c('button', {
    staticClass: "btn btn-block btn-facebook",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("facebook")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6"
  }, [_c('button', {
    staticClass: "btn btn-block btn-twitter",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("twitter")])])])])])])])])])])
}]}

/***/ }),

/***/ 528:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "card-columns cols-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('line-example')], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_vm._m(1), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('bar-example')], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_vm._m(2), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('doughnut-example')], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_vm._m(3), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('radar-example')], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_vm._m(4), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('pie-example')], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_vm._m(5), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "chart-wrapper"
  }, [_c('polar-area-example')], 1)])])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Line Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Bar Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Doughnut Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Radar Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Pie Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n        Polar Area Chart\n        "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    attrs: {
      "href": "http://www.chartjs.org"
    }
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("docs")])])])])
}]}

/***/ }),

/***/ 529:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app flex-row align-items-center"
  }, [_c('div', {
    staticClass: "container"
  }, [_c('div', {
    staticClass: "row justify-content-center"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "clearfix"
  }, [_c('h1', {
    staticClass: "float-left display-3 mr-4"
  }, [_vm._v("500")]), _vm._v(" "), _c('h4', {
    staticClass: "pt-3"
  }, [_vm._v("Houston, we have a problem!")]), _vm._v(" "), _c('p', {
    staticClass: "text-muted"
  }, [_vm._v("The page you are looking for is temporarily unavailable.")])]), _vm._v(" "), _c('div', {
    staticClass: "input-prepend input-group"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "fa fa-search"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "id": "prependedInput",
      "size": "16",
      "type": "text",
      "placeholder": "What are you looking for?"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "input-group-btn"
  }, [_c('button', {
    staticClass: "btn btn-info",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Search")])])])])])])])
}]}

/***/ }),

/***/ 530:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_vm._m(0), _vm._v(" "), _vm._m(1), _vm._v(" "), _vm._m(2), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-success text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-info text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary text-center"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('blockquote', {
    staticClass: "card-blockquote"
  }, [_c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.")]), _vm._v(" "), _c('footer', [_vm._v("Someone famous in\n              "), _c('cite', {
    attrs: {
      "title": "Source Title"
    }
  }, [_vm._v("Source Title")])])])], 1)])])]), _vm._v(" "), _vm._m(3)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_vm._v("Card footer")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-check"
  }), _vm._v("Card with icon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with switch\n          "), _c('label', {
    staticClass: "switch switch-sm switch-text switch-info float-right mb-0"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with label\n          "), _c('span', {
    staticClass: "badge badge-success float-right"
  }, [_vm._v("Success")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with label\n          "), _c('span', {
    staticClass: "badge badge-pill badge-danger float-right"
  }, [_vm._v("42")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-primary"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-secondary"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-success"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-info"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-warning"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-outline-danger"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card outline\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-primary"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-secondary"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-success"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-info"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-warning"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-accent-danger"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card with accent\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-success"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-4"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n          Card title\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_vm._v("\n          Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.\n        ")])])])])
}]}

/***/ }),

/***/ 531:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app flex-row align-items-center"
  }, [_c('div', {
    staticClass: "container"
  }, [_c('div', {
    staticClass: "row justify-content-center"
  }, [_c('div', {
    staticClass: "col-md-8"
  }, [_c('div', {
    staticClass: "card-group mb-0"
  }, [_c('div', {
    staticClass: "card p-4"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('h1', [_vm._v("Login")]), _vm._v(" "), _c('p', {
    staticClass: "text-muted"
  }, [_vm._v("Sign In to your account")]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-3"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "icon-user"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Username"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "input-group mb-4"
  }, [_c('span', {
    staticClass: "input-group-addon"
  }, [_c('i', {
    staticClass: "icon-lock"
  })]), _vm._v(" "), _c('input', {
    staticClass: "form-control",
    attrs: {
      "type": "password",
      "placeholder": "Password"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-6"
  }, [_c('button', {
    staticClass: "btn btn-primary px-4",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Login")])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 text-right"
  }, [_c('button', {
    staticClass: "btn btn-link px-0",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Forgot password?")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card card-inverse card-primary py-5 d-md-down-none",
    staticStyle: {
      "width": "44%"
    }
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', [_c('h2', [_vm._v("Sign up")]), _vm._v(" "), _c('p', [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-primary active mt-3",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Register Now!")])])])])])])])])])
}]}

/***/ }),

/***/ 532:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("89.9%")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("12.124")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("$98.111,00")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("2 TB")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("89.9%")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("12.124")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("$98.111,00")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h4 m-0"
  }, [_vm._v("2 TB")]), _vm._v(" "), _c('div', [_vm._v("Lorem ipsum...")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs my-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet enim.")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-cogs bg-primary p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-primary mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-laptop bg-info p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-info mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-moon-o bg-warning p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-warning mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-bell bg-danger p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-danger mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-cogs bg-primary p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-primary mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer px-3 py-2"
  }, [_c('a', {
    staticClass: "font-weight-bold font-xs btn-block text-muted",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("View More "), _c('i', {
    staticClass: "fa fa-angle-right float-right font-lg"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-laptop bg-info p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-info mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer px-3 py-2"
  }, [_c('a', {
    staticClass: "font-weight-bold font-xs btn-block text-muted",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("View More "), _c('i', {
    staticClass: "fa fa-angle-right float-right font-lg"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-moon-o bg-warning p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-warning mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer px-3 py-2"
  }, [_c('a', {
    staticClass: "font-weight-bold font-xs btn-block text-muted",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("View More "), _c('i', {
    staticClass: "fa fa-angle-right float-right font-lg"
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-3 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-bell bg-danger p-3 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-danger mb-0 mt-2"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])]), _vm._v(" "), _c('div', {
    staticClass: "card-footer px-3 py-2"
  }, [_c('a', {
    staticClass: "font-weight-bold font-xs btn-block text-muted",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("View More "), _c('i', {
    staticClass: "fa fa-angle-right float-right font-lg"
  })])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-cogs bg-primary p-4 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-primary mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-laptop bg-info p-4 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-info mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-moon-o bg-warning p-4 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-warning mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-bell bg-danger p-4 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-danger mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-cogs bg-primary p-4 px-5 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-primary mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-laptop bg-info p-4 px-5 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-info mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-moon-o bg-warning p-4 px-5 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-warning mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block p-0 clearfix"
  }, [_c('i', {
    staticClass: "fa fa-bell bg-danger p-4 px-5 font-2xl mr-3 float-left"
  }), _vm._v(" "), _c('div', {
    staticClass: "h5 text-danger mb-0 pt-3"
  }, [_vm._v("$1.999,50")]), _vm._v(" "), _c('div', {
    staticClass: "text-muted text-uppercase font-weight-bold font-xs"
  }, [_vm._v("Income")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-3 col-sm-6"
  }, [_c('div', {
    staticClass: "social-box facebook"
  }, [_c('i', {
    staticClass: "fa fa-facebook"
  }), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("89k")]), _vm._v(" "), _c('span', [_vm._v("friends")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("459")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-3 col-sm-6"
  }, [_c('div', {
    staticClass: "social-box twitter"
  }, [_c('i', {
    staticClass: "fa fa-twitter"
  }), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("973k")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("1.792")]), _vm._v(" "), _c('span', [_vm._v("tweets")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-3 col-sm-6"
  }, [_c('div', {
    staticClass: "social-box linkedin"
  }, [_c('i', {
    staticClass: "fa fa-linkedin"
  }), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("500+")]), _vm._v(" "), _c('span', [_vm._v("contacts")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("292")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-3 col-sm-6"
  }, [_c('div', {
    staticClass: "social-box google-plus"
  }, [_c('i', {
    staticClass: "fa fa-google-plus"
  }), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("894")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("92")]), _vm._v(" "), _c('span', [_vm._v("circles")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "card-group"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-people"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("87.500")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-user-follow"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("385")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("New Clients")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-basket-loaded"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("1238")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Products sold")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-pie-chart"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("28%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Returning Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-speedometer"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("5:34:11")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Avg. Time")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-people"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("87.500")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-user-follow"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("385")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("New Clients")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-basket-loaded"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("1238")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Products sold")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-pie-chart"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("28%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Returning Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-speedometer"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("5:34:11")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Avg. Time")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-speech"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("972")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Comments")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs mt-3 mb-0"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-people"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("87.500")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-success"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-user-follow"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("385")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("New Clients")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-basket-loaded"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("1238")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Products sold")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-pie-chart"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("28%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Returning Visitors")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-speedometer"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("5:34:11")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Avg. Time")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-md-2"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "h1 text-muted text-right mb-4"
  }, [_c('i', {
    staticClass: "icon-speech"
  })]), _vm._v(" "), _c('div', {
    staticClass: "h4 mb-0"
  }, [_vm._v("972")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted text-uppercase font-weight-bold"
  }, [_vm._v("Comments")]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-white progress-xs mt-3"
  }, [_c('div', {
    staticClass: "progress-bar",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })])])])])])])
}]}

/***/ }),

/***/ 533:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('aside', {
    staticClass: "aside-menu px-4"
  }, [_c('div', {
    staticClass: "aside-options"
  }, [_c('div', {
    staticClass: "clearfix mt-4"
  }, [_c('small', [_c('b', [_vm._v("Option 1")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm float-right"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")])])]), _vm._v(" "), _c('div', {
    staticClass: "aside-options"
  }, [_c('div', {
    staticClass: "clearfix mt-3"
  }, [_c('small', [_c('b', [_vm._v("Option 2")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm float-right"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")])])]), _vm._v(" "), _c('div', {
    staticClass: "aside-options"
  }, [_c('div', {
    staticClass: "clearfix mt-3"
  }, [_c('small', [_c('b', [_vm._v("Option 3")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm float-right"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "aside-options"
  }, [_c('div', {
    staticClass: "clearfix mt-3"
  }, [_c('small', [_c('b', [_vm._v("Option 4")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm float-right"
  }, [_c('input', {
    staticClass: "switch-input",
    attrs: {
      "type": "checkbox",
      "checked": ""
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-label",
    attrs: {
      "data-on": "On",
      "data-off": "Off"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "switch-handle"
  })])])]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('h6', [_vm._v("System Utilization")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase mb-1 mt-4"
  }, [_c('small', [_c('b', [_vm._v("CPU Usage")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-info",
    staticStyle: {
      "width": "25%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "25",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("348 Processes. 1/4 Cores.")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase mb-1 mt-2"
  }, [_c('small', [_c('b', [_vm._v("Memory Usage")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-warning",
    staticStyle: {
      "width": "70%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "70",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("11444GB/16384MB")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase mb-1 mt-2"
  }, [_c('small', [_c('b', [_vm._v("SSD 1 Usage")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-danger",
    staticStyle: {
      "width": "95%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "95",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("243GB/256GB")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase mb-1 mt-2"
  }, [_c('small', [_c('b', [_vm._v("SSD 2 Usage")])])]), _vm._v(" "), _c('div', {
    staticClass: "progress progress-xs"
  }, [_c('div', {
    staticClass: "progress-bar bg-success",
    staticStyle: {
      "width": "10%"
    },
    attrs: {
      "role": "progressbar",
      "aria-valuenow": "10",
      "aria-valuemin": "0",
      "aria-valuemax": "100"
    }
  })]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("25GB/256GB")])])
}]}

/***/ }),

/***/ 534:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "card card-default"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-picture-o"
  }), _vm._v(" Simple Line Icons\n    ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row text-center"
  }, [_c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-user icons font-2xl d-block mt-4"
  }), _vm._v("icon-user\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-people icons font-2xl d-block mt-4"
  }), _vm._v("icon-people\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-user-female icons font-2xl d-block mt-4"
  }), _vm._v("icon-user-female\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-user-follow icons font-2xl d-block mt-4"
  }), _vm._v("icon-user-follow\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-user-following icons font-2xl d-block mt-4"
  }), _vm._v("icon-user-following\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-user-unfollow icons font-2xl d-block mt-4"
  }), _vm._v("icon-user-unfollow\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-login icons font-2xl d-block mt-4"
  }), _vm._v("icon-login\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-logout icons font-2xl d-block mt-4"
  }), _vm._v("icon-logout\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-emotsmile icons font-2xl d-block mt-4"
  }), _vm._v("icon-emotsmile\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-phone icons font-2xl d-block mt-4"
  }), _vm._v("icon-phone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-call-end icons font-2xl d-block mt-4"
  }), _vm._v("icon-call-end\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-call-in icons font-2xl d-block mt-4"
  }), _vm._v("icon-call-in\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-call-out icons font-2xl d-block mt-4"
  }), _vm._v("icon-call-out\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-map icons font-2xl d-block mt-4"
  }), _vm._v("icon-map\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-location-pin icons font-2xl d-block mt-4"
  }), _vm._v("icon-location-pin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-direction icons font-2xl d-block mt-4"
  }), _vm._v("icon-direction\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-directions icons font-2xl d-block mt-4"
  }), _vm._v("icon-directions\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-compass icons font-2xl d-block mt-4"
  }), _vm._v("icon-compass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-layers icons font-2xl d-block mt-4"
  }), _vm._v("icon-layers\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-menu icons font-2xl d-block mt-4"
  }), _vm._v("icon-menu\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-list icons font-2xl d-block mt-4"
  }), _vm._v("icon-list\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-options-vertical icons font-2xl d-block mt-4"
  }), _vm._v("icon-options-vertical\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-options icons font-2xl d-block mt-4"
  }), _vm._v("icon-options\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-down icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-down\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-left icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-left\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-right icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-right\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-up icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-up\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-up-circle icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-up-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-left-circle icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-left-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-right-circle icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-right-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-arrow-down-circle icons font-2xl d-block mt-4"
  }), _vm._v("icon-arrow-down-circle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-check icons font-2xl d-block mt-4"
  }), _vm._v("icon-check\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-clock icons font-2xl d-block mt-4"
  }), _vm._v("icon-clock\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-plus icons font-2xl d-block mt-4"
  }), _vm._v("icon-plus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-close icons font-2xl d-block mt-4"
  }), _vm._v("icon-close\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-trophy icons font-2xl d-block mt-4"
  }), _vm._v("icon-trophy\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-screen-smartphone icons font-2xl d-block mt-4"
  }), _vm._v("icon-screen-smartphone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-screen-desktop icons font-2xl d-block mt-4"
  }), _vm._v("icon-screen-desktop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-plane icons font-2xl d-block mt-4"
  }), _vm._v("icon-plane\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-notebook icons font-2xl d-block mt-4"
  }), _vm._v("icon-notebook\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-mustache icons font-2xl d-block mt-4"
  }), _vm._v("icon-mustache\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-mouse icons font-2xl d-block mt-4"
  }), _vm._v("icon-mouse\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-magnet icons font-2xl d-block mt-4"
  }), _vm._v("icon-magnet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-energy icons font-2xl d-block mt-4"
  }), _vm._v("icon-energy\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-disc icons font-2xl d-block mt-4"
  }), _vm._v("icon-disc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-cursor icons font-2xl d-block mt-4"
  }), _vm._v("icon-cursor\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-cursor-move icons font-2xl d-block mt-4"
  }), _vm._v("icon-cursor-move\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-crop icons font-2xl d-block mt-4"
  }), _vm._v("icon-crop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-chemistry icons font-2xl d-block mt-4"
  }), _vm._v("icon-chemistry\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-speedometer icons font-2xl d-block mt-4"
  }), _vm._v("icon-speedometer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-shield icons font-2xl d-block mt-4"
  }), _vm._v("icon-shield\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-screen-tablet icons font-2xl d-block mt-4"
  }), _vm._v("icon-screen-tablet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-magic-wand icons font-2xl d-block mt-4"
  }), _vm._v("icon-magic-wand\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-hourglass icons font-2xl d-block mt-4"
  }), _vm._v("icon-hourglass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-graduation icons font-2xl d-block mt-4"
  }), _vm._v("icon-graduation\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-ghost icons font-2xl d-block mt-4"
  }), _vm._v("icon-ghost\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-game-controller icons font-2xl d-block mt-4"
  }), _vm._v("icon-game-controller\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-fire icons font-2xl d-block mt-4"
  }), _vm._v("icon-fire\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-eyeglass icons font-2xl d-block mt-4"
  }), _vm._v("icon-eyeglass\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-envelope-open icons font-2xl d-block mt-4"
  }), _vm._v("icon-envelope-open\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-envelope-letter icons font-2xl d-block mt-4"
  }), _vm._v("icon-envelope-letter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-bell icons font-2xl d-block mt-4"
  }), _vm._v("icon-bell\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-badge icons font-2xl d-block mt-4"
  }), _vm._v("icon-badge\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-anchor icons font-2xl d-block mt-4"
  }), _vm._v("icon-anchor\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-wallet icons font-2xl d-block mt-4"
  }), _vm._v("icon-wallet\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-vector icons font-2xl d-block mt-4"
  }), _vm._v("icon-vector\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-speech icons font-2xl d-block mt-4"
  }), _vm._v("icon-speech\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-puzzle icons font-2xl d-block mt-4"
  }), _vm._v("icon-puzzle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-printer icons font-2xl d-block mt-4"
  }), _vm._v("icon-printer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-present icons font-2xl d-block mt-4"
  }), _vm._v("icon-present\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-playlist icons font-2xl d-block mt-4"
  }), _vm._v("icon-playlist\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-pin icons font-2xl d-block mt-4"
  }), _vm._v("icon-pin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-picture icons font-2xl d-block mt-4"
  }), _vm._v("icon-picture\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-handbag icons font-2xl d-block mt-4"
  }), _vm._v("icon-handbag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-globe-alt icons font-2xl d-block mt-4"
  }), _vm._v("icon-globe-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-globe icons font-2xl d-block mt-4"
  }), _vm._v("icon-globe\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-folder-alt icons font-2xl d-block mt-4"
  }), _vm._v("icon-folder-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-folder icons font-2xl d-block mt-4"
  }), _vm._v("icon-folder\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-film icons font-2xl d-block mt-4"
  }), _vm._v("icon-film\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-feed icons font-2xl d-block mt-4"
  }), _vm._v("icon-feed\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-drop icons font-2xl d-block mt-4"
  }), _vm._v("icon-drop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-drawer icons font-2xl d-block mt-4"
  }), _vm._v("icon-drawer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-docs icons font-2xl d-block mt-4"
  }), _vm._v("icon-docs\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-doc icons font-2xl d-block mt-4"
  }), _vm._v("icon-doc\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-diamond icons font-2xl d-block mt-4"
  }), _vm._v("icon-diamond\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-cup icons font-2xl d-block mt-4"
  }), _vm._v("icon-cup\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-calculator icons font-2xl d-block mt-4"
  }), _vm._v("icon-calculator\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-bubbles icons font-2xl d-block mt-4"
  }), _vm._v("icon-bubbles\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-briefcase icons font-2xl d-block mt-4"
  }), _vm._v("icon-briefcase\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-book-open icons font-2xl d-block mt-4"
  }), _vm._v("icon-book-open\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-basket-loaded icons font-2xl d-block mt-4"
  }), _vm._v("icon-basket-loaded\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-basket icons font-2xl d-block mt-4"
  }), _vm._v("icon-basket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-bag icons font-2xl d-block mt-4"
  }), _vm._v("icon-bag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-action-undo icons font-2xl d-block mt-4"
  }), _vm._v("icon-action-undo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-action-redo icons font-2xl d-block mt-4"
  }), _vm._v("icon-action-redo\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-wrench icons font-2xl d-block mt-4"
  }), _vm._v("icon-wrench\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-umbrella icons font-2xl d-block mt-4"
  }), _vm._v("icon-umbrella\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-trash icons font-2xl d-block mt-4"
  }), _vm._v("icon-trash\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-tag icons font-2xl d-block mt-4"
  }), _vm._v("icon-tag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-support icons font-2xl d-block mt-4"
  }), _vm._v("icon-support\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-frame icons font-2xl d-block mt-4"
  }), _vm._v("icon-frame\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-size-fullscreen icons font-2xl d-block mt-4"
  }), _vm._v("icon-size-fullscreen\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-size-actual icons font-2xl d-block mt-4"
  }), _vm._v("icon-size-actual\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-shuffle icons font-2xl d-block mt-4"
  }), _vm._v("icon-shuffle\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-share-alt icons font-2xl d-block mt-4"
  }), _vm._v("icon-share-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-share icons font-2xl d-block mt-4"
  }), _vm._v("icon-share\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-rocket icons font-2xl d-block mt-4"
  }), _vm._v("icon-rocket\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-question icons font-2xl d-block mt-4"
  }), _vm._v("icon-question\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-pie-chart icons font-2xl d-block mt-4"
  }), _vm._v("icon-pie-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-pencil icons font-2xl d-block mt-4"
  }), _vm._v("icon-pencil\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-note icons font-2xl d-block mt-4"
  }), _vm._v("icon-note\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-loop icons font-2xl d-block mt-4"
  }), _vm._v("icon-loop\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-home icons font-2xl d-block mt-4"
  }), _vm._v("icon-home\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-grid icons font-2xl d-block mt-4"
  }), _vm._v("icon-grid\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-graph icons font-2xl d-block mt-4"
  }), _vm._v("icon-graph\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-microphone icons font-2xl d-block mt-4"
  }), _vm._v("icon-microphone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-music-tone-alt icons font-2xl d-block mt-4"
  }), _vm._v("icon-music-tone-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-music-tone icons font-2xl d-block mt-4"
  }), _vm._v("icon-music-tone\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-earphones-alt icons font-2xl d-block mt-4"
  }), _vm._v("icon-earphones-alt\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-earphones icons font-2xl d-block mt-4"
  }), _vm._v("icon-earphones\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-equalizer icons font-2xl d-block mt-4"
  }), _vm._v("icon-equalizer\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-like icons font-2xl d-block mt-4"
  }), _vm._v("icon-like\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-dislike icons font-2xl d-block mt-4"
  }), _vm._v("icon-dislike\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-start icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-start\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-rewind icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-rewind\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-play icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-play\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-pause icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-pause\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-forward icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-forward\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-control-end icons font-2xl d-block mt-4"
  }), _vm._v("icon-control-end\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-volume-1 icons font-2xl d-block mt-4"
  }), _vm._v("icon-volume-1\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-volume-2 icons font-2xl d-block mt-4"
  }), _vm._v("icon-volume-2\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-volume-off icons font-2xl d-block mt-4"
  }), _vm._v("icon-volume-off\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-calendar icons font-2xl d-block mt-4"
  }), _vm._v("icon-calendar\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-bulb icons font-2xl d-block mt-4"
  }), _vm._v("icon-bulb\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-chart icons font-2xl d-block mt-4"
  }), _vm._v("icon-chart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-ban icons font-2xl d-block mt-4"
  }), _vm._v("icon-ban\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-bubble icons font-2xl d-block mt-4"
  }), _vm._v("icon-bubble\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-camrecorder icons font-2xl d-block mt-4"
  }), _vm._v("icon-camrecorder\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-camera icons font-2xl d-block mt-4"
  }), _vm._v("icon-camera\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-cloud-download icons font-2xl d-block mt-4"
  }), _vm._v("icon-cloud-download\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-cloud-upload icons font-2xl d-block mt-4"
  }), _vm._v("icon-cloud-upload\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-envelope icons font-2xl d-block mt-4"
  }), _vm._v("icon-envelope\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-eye icons font-2xl d-block mt-4"
  }), _vm._v("icon-eye\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-flag icons font-2xl d-block mt-4"
  }), _vm._v("icon-flag\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-heart icons font-2xl d-block mt-4"
  }), _vm._v("icon-heart\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-info icons font-2xl d-block mt-4"
  }), _vm._v("icon-info\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-key icons font-2xl d-block mt-4"
  }), _vm._v("icon-key\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-link icons font-2xl d-block mt-4"
  }), _vm._v("icon-link\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-lock icons font-2xl d-block mt-4"
  }), _vm._v("icon-lock\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-lock-open icons font-2xl d-block mt-4"
  }), _vm._v("icon-lock-open\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-magnifier icons font-2xl d-block mt-4"
  }), _vm._v("icon-magnifier\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-magnifier-add icons font-2xl d-block mt-4"
  }), _vm._v("icon-magnifier-add\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-magnifier-remove icons font-2xl d-block mt-4"
  }), _vm._v("icon-magnifier-remove\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-paper-clip icons font-2xl d-block mt-4"
  }), _vm._v("icon-paper-clip\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-paper-plane icons font-2xl d-block mt-4"
  }), _vm._v("icon-paper-plane\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-power icons font-2xl d-block mt-4"
  }), _vm._v("icon-power\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-refresh icons font-2xl d-block mt-4"
  }), _vm._v("icon-refresh\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-reload icons font-2xl d-block mt-4"
  }), _vm._v("icon-reload\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-settings icons font-2xl d-block mt-4"
  }), _vm._v("icon-settings\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-star icons font-2xl d-block mt-4"
  }), _vm._v("icon-star\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-symbol-female icons font-2xl d-block mt-4"
  }), _vm._v("icon-symbol-female\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-symbol-male icons font-2xl d-block mt-4"
  }), _vm._v("icon-symbol-male\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-target icons font-2xl d-block mt-4"
  }), _vm._v("icon-target\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-credit-card icons font-2xl d-block mt-4"
  }), _vm._v("icon-credit-card\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-paypal icons font-2xl d-block mt-4"
  }), _vm._v("icon-paypal\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-tumblr icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-tumblr\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-twitter icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-twitter\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-facebook icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-facebook\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-instagram icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-instagram\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-linkedin icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-linkedin\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-pinterest icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-pinterest\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-github icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-github\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-gplus icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-gplus\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-reddit icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-reddit\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-skype icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-skype\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-dribbble icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-dribbble\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-behance icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-behance\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-foursqare icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-foursqare\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-soundcloud icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-soundcloud\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-spotify icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-spotify\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-stumbleupon icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-stumbleupon\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-youtube icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-youtube\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "col-6 col-sm-4 col-md-3"
  }, [_c('i', {
    staticClass: "icon-social-dropbox icons font-2xl d-block mt-4"
  }), _vm._v("icon-social-dropbox\n        ")])])])])])
}]}

/***/ }),

/***/ 535:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('header', {
    staticClass: "app-header navbar"
  }, [_vm._t("default")], 2)
},staticRenderFns: []}

/***/ }),

/***/ 536:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "sidebar"
  }, [_c('nav', {
    staticClass: "sidebar-nav"
  }, [_c('ul', {
    staticClass: "nav"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/dashboard'
    }
  }, [_c('i', {
    staticClass: "icon-speedometer"
  }), _vm._v(" Dashboard "), _c('span', {
    staticClass: "badge badge-info"
  }, [_vm._v("NEW")])])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-title"
  }, [_vm._v("\n        UI Elements\n      ")]), _vm._v(" "), _c('router-link', {
    staticClass: "nav-item nav-dropdown",
    attrs: {
      "tag": "li",
      "to": {
        path: '/components'
      },
      "disabled": ""
    }
  }, [_c('div', {
    staticClass: "nav-link nav-dropdown-toggle",
    on: {
      "click": _vm.handleClick
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Components")]), _vm._v(" "), _c('ul', {
    staticClass: "nav-dropdown-items"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/buttons',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Buttons")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/social-buttons',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Social Buttons")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/cards',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Cards")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/forms',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Forms")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/modals',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Modals")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/switches',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Switches")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/components/tables',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-puzzle"
  }), _vm._v(" Tables")])], 1)])]), _vm._v(" "), _c('router-link', {
    staticClass: "nav-item nav-dropdown",
    attrs: {
      "tag": "li",
      "to": {
        path: '/icons'
      },
      "disabled": ""
    }
  }, [_c('div', {
    staticClass: "nav-link nav-dropdown-toggle",
    on: {
      "click": _vm.handleClick
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Icons")]), _vm._v(" "), _c('ul', {
    staticClass: "nav-dropdown-items"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/icons/font-awesome',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Font Awesome")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/icons/simple-line-icons',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Simple Line Icons")])], 1)])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/widgets',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-calculator"
  }), _vm._v(" Widgets "), _c('span', {
    staticClass: "badge badge-info"
  }, [_vm._v("NEW")])])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/charts',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-pie-chart"
  }), _vm._v(" Charts")])], 1), _vm._v(" "), _c('li', {
    staticClass: "divider"
  }), _vm._v(" "), _c('li', {
    staticClass: "nav-title"
  }, [_vm._v("\n        Extras\n      ")]), _vm._v(" "), _c('li', {
    staticClass: "nav-item nav-dropdown"
  }, [_c('a', {
    staticClass: "nav-link nav-dropdown-toggle",
    attrs: {
      "href": "#"
    },
    on: {
      "click": _vm.handleClick
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Pages")]), _vm._v(" "), _c('ul', {
    staticClass: "nav-dropdown-items"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/pages/login',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Login")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/pages/register',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Register")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/pages/404',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Error 404")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": '/pages/500',
      "exact": ""
    }
  }, [_c('i', {
    staticClass: "icon-star"
  }), _vm._v(" Error 500")])], 1)])])], 1)])])
},staticRenderFns: []}

/***/ }),

/***/ 537:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('router-view')
},staticRenderFns: []}

/***/ }),

/***/ 538:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Social Media Button")]), _vm._v(" "), _c('small', [_vm._v("Usage ex.")]), _c('code', {
    staticStyle: {
      "text-transform": "lowercase"
    }
  }, [_vm._v("<button class=\"btn btn-facebook\"><span>Facebook</span></button>")]), _vm._v(" "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    staticClass: "btn-setting",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('button', {
    staticClass: "btn-minimize",
    attrs: {
      "type": "button",
      "data-toggle": "collapse",
      "data-target": "",
      "aria-expanded": "false",
      "aria-controls": "collapseExample"
    }
  }, [_c('i', {
    staticClass: "icon-arrow-up"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn-close",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-close"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('h6', [_vm._v("Size Small "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-sm")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-sm btn-facebook",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-twitter",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-linkedin",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-flickr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-tumblr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-xing",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-github",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-html5",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-openid",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-stack-overflow",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-css3",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-youtube",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dribbble",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-google-plus",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-instagram",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-pinterest",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vk",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-yahoo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-behance",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dropbox",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-reddit",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-spotify",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vine",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-foursquare",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vimeo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Normal")]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-facebook",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-twitter",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-linkedin",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-flickr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-tumblr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-xing",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-github",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-html5",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-openid",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-stack-overflow",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-css3",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-youtube",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dribbble",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-google-plus",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-instagram",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-pinterest",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vk",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-yahoo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-behance",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dropbox",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-reddit",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-spotify",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vine",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-foursquare",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vimeo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Large "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-lg")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-lg btn-facebook",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-twitter",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-linkedin",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-flickr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-tumblr",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-xing",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-github",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-html5",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-openid",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-stack-overflow",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-css3",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-youtube",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dribbble",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-google-plus",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-instagram",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-pinterest",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vk",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-yahoo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-behance",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dropbox",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-reddit",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-spotify",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vine",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-foursquare",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vimeo",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Social Media Button")]), _vm._v(" "), _c('small', [_vm._v("Only icons. Usage ex.")]), _vm._v(" "), _c('code', {
    staticStyle: {
      "text-transform": "lowercase"
    }
  }, [_vm._v("<button class=\"btn btn-facebook icon\"><span>Facebook</span></button>")]), _vm._v(" "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    staticClass: "btn-setting",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('button', {
    staticClass: "btn-minimize",
    attrs: {
      "type": "button",
      "data-toggle": "collapse",
      "data-target": "",
      "aria-expanded": "false",
      "aria-controls": "collapseExample"
    }
  }, [_c('i', {
    staticClass: "icon-arrow-up"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn-close",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-close"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('h6', [_vm._v("Size Small "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-sm")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-sm btn-facebook icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-twitter icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-linkedin icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-flickr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-tumblr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-xing icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-github icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-html5 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-openid icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-stack-overflow icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-css3 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-youtube icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dribbble icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-google-plus icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-instagram icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-pinterest icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vk icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-yahoo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-behance icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dropbox icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-reddit icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-spotify icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vine icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-foursquare icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vimeo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Normal")]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-facebook icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-twitter icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-linkedin icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-flickr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-tumblr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-xing icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-github icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-html5 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-openid icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-stack-overflow icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-css3 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-youtube icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dribbble icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-google-plus icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-instagram icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-pinterest icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vk icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-yahoo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-behance icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dropbox icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-reddit icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-spotify icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vine icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-foursquare icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vimeo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Large "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-lg")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-lg btn-facebook icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-twitter icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-linkedin icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-flickr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-tumblr icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-xing icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-github icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-html5 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-openid icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-stack-overflow icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-css3 icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-youtube icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dribbble icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-google-plus icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-instagram icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-pinterest icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vk icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-yahoo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-behance icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dropbox icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-reddit icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-spotify icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vine icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-foursquare icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vimeo icon",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Social Media Button")]), _vm._v(" "), _c('small', [_vm._v("Only text. Usage ex.")]), _vm._v(" "), _c('code', {
    staticStyle: {
      "text-transform": "lowercase"
    }
  }, [_vm._v("<button class=\"btn btn-facebook text\"><span>Facebook</span></button>")]), _vm._v(" "), _c('div', {
    staticClass: "card-actions"
  }, [_c('a', {
    staticClass: "btn-setting",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('button', {
    staticClass: "btn-minimize",
    attrs: {
      "type": "button",
      "data-toggle": "collapse",
      "data-target": "",
      "aria-expanded": "false",
      "aria-controls": "collapseExample"
    }
  }, [_c('i', {
    staticClass: "icon-arrow-up"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn-close",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-close"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('h6', [_vm._v("Size Small "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-sm")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-sm btn-facebook text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-twitter text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-linkedin text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-flickr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-tumblr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-xing text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-github text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-html5 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-openid text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-stack-overflow text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-css3 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-youtube text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dribbble text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-google-plus text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-instagram text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-pinterest text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vk text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-yahoo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-behance text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-dropbox text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-reddit text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-spotify text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vine text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-foursquare text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-sm btn-vimeo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Normal")]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-facebook text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-twitter text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-linkedin text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-flickr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-tumblr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-xing text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-github text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-html5 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-openid text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-stack-overflow text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-css3 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-youtube text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dribbble text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-google-plus text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-instagram text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-pinterest text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vk text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-yahoo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-behance text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-dropbox text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-reddit text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-spotify text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vine text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-foursquare text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-vimeo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])]), _vm._v(" "), _c('h6', [_vm._v("Size Large "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-lg")])])]), _vm._v(" "), _c('p', [_c('button', {
    staticClass: "btn btn-lg btn-facebook text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Facebook")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-twitter text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Twitter")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-linkedin text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("LinkedIn")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-flickr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Flickr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-tumblr text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Tumblr")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-xing text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Xing")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-github text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Github")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-html5 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("HTML5")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-openid text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("OpenID")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-stack-overflow text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("StackOverflow")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-css3 text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("CSS3")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-youtube text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("YouTube")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dribbble text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dribbble")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-google-plus text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Google+")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-instagram text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Instagram")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-pinterest text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Pinterest")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vk text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("VK")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-yahoo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Yahoo")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-behance text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Behance")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-dropbox text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Dropbox")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-reddit text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Reddit")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-spotify text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Spotify")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vine text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vine")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-foursquare text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Forsquare")])]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-lg btn-vimeo text",
    attrs: {
      "type": "button"
    }
  }, [_c('span', [_vm._v("Vimeo")])])])])])])])])
}]}

/***/ }),

/***/ 539:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "wrapper"
  }, [_c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-lg-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_vm._m(0), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.myModal = true
      }
    }
  }, [_vm._v("Launch demo modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.largeModal = true
      }
    }
  }, [_vm._v("Launch large modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.smallModal = true
      }
    }
  }, [_vm._v("Launch small modal")]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.primaryModal = true
      }
    }
  }, [_vm._v("Launch primary modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.successModal = true
      }
    }
  }, [_vm._v("Launch success modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.warningModal = true
      }
    }
  }, [_vm._v("Launch warning modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.dangerModal = true
      }
    }
  }, [_vm._v("Launch danger modal")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.infoModal = true
      }
    }
  }, [_vm._v("Launch info modal")])])])])])]), _vm._v(" "), _c('modal', {
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.myModal = false
      }
    },
    model: {
      value: (_vm.myModal),
      callback: function($$v) {
        _vm.myModal = $$v
      },
      expression: "myModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    attrs: {
      "title": "Modal title",
      "large": "",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.largeModal = false
      }
    },
    model: {
      value: (_vm.largeModal),
      callback: function($$v) {
        _vm.largeModal = $$v
      },
      expression: "largeModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    attrs: {
      "title": "Modal title",
      "small": "",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.smallModal = false
      }
    },
    model: {
      value: (_vm.smallModal),
      callback: function($$v) {
        _vm.smallModal = $$v
      },
      expression: "smallModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    staticClass: "modal-primary",
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.primaryModal = false
      }
    },
    model: {
      value: (_vm.primaryModal),
      callback: function($$v) {
        _vm.primaryModal = $$v
      },
      expression: "primaryModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    staticClass: "modal-success",
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.successModal = false
      }
    },
    model: {
      value: (_vm.successModal),
      callback: function($$v) {
        _vm.successModal = $$v
      },
      expression: "successModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    staticClass: "modal-warning",
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.warningModal = false
      }
    },
    model: {
      value: (_vm.warningModal),
      callback: function($$v) {
        _vm.warningModal = $$v
      },
      expression: "warningModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    staticClass: "modal-danger",
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.dangerModal = false
      }
    },
    model: {
      value: (_vm.dangerModal),
      callback: function($$v) {
        _vm.dangerModal = $$v
      },
      expression: "dangerModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")]), _vm._v(" "), _c('modal', {
    staticClass: "modal-info",
    attrs: {
      "title": "Modal title",
      "effect": "fade/zoom"
    },
    on: {
      "ok": function($event) {
        _vm.infoModal = false
      }
    },
    model: {
      value: (_vm.infoModal),
      callback: function($$v) {
        _vm.infoModal = $$v
      },
      expression: "infoModal"
    }
  }, [_c('div', {
    staticClass: "modal-header",
    slot: "modal-header"
  }, [_c('h4', {
    staticClass: "modal-title"
  }, [_vm._v("Modal title")])]), _vm._v("\n    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod\n    tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,\n    quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo\n    consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n    cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non\n    proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\n  ")])], 1)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Bootstrap Modals\n          ")])
}]}

/***/ }),

/***/ 540:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-lg-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Simple Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table"
  }, [_c('thead', [_c('tr', [_c('th', [_vm._v("Username")]), _vm._v(" "), _c('th', [_vm._v("Date registered")]), _vm._v(" "), _c('th', [_vm._v("Role")]), _vm._v(" "), _c('th', [_vm._v("Status")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("Samppa Nori")]), _vm._v(" "), _c('td', [_vm._v("2012/01/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Estavan Lykos")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("Banned")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Chetan Mohamed")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Admin")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("Inactive")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Derick Maximinus")]), _vm._v(" "), _c('td', [_vm._v("2012/03/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("Pending")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Friderik Dávid")]), _vm._v(" "), _c('td', [_vm._v("2012/01/21")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])])])]), _vm._v(" "), _c('ul', {
    staticClass: "pagination"
  }, [_c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Prev")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item active"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("1")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("2")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("3")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("4")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Next")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-lg-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Striped Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-striped"
  }, [_c('thead', [_c('tr', [_c('th', [_vm._v("Username")]), _vm._v(" "), _c('th', [_vm._v("Date registered")]), _vm._v(" "), _c('th', [_vm._v("Role")]), _vm._v(" "), _c('th', [_vm._v("Status")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("Yiorgos Avraamu")]), _vm._v(" "), _c('td', [_vm._v("2012/01/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Avram Tarasios")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("Banned")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Quintin Ed")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Admin")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("Inactive")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Enéas Kwadwo")]), _vm._v(" "), _c('td', [_vm._v("2012/03/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("Pending")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Agapetus Tadeáš")]), _vm._v(" "), _c('td', [_vm._v("2012/01/21")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])])])]), _vm._v(" "), _c('ul', {
    staticClass: "pagination"
  }, [_c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Prev")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item active"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("1")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("2")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("3")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("4")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Next")])])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-lg-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Condensed Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-sm"
  }, [_c('thead', [_c('tr', [_c('th', [_vm._v("Username")]), _vm._v(" "), _c('th', [_vm._v("Date registered")]), _vm._v(" "), _c('th', [_vm._v("Role")]), _vm._v(" "), _c('th', [_vm._v("Status")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("Carwyn Fachtna")]), _vm._v(" "), _c('td', [_vm._v("2012/01/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Nehemiah Tatius")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("Banned")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Ebbe Gemariah")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Admin")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("Inactive")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Eustorgios Amulius")]), _vm._v(" "), _c('td', [_vm._v("2012/03/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("Pending")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Leopold Gáspár")]), _vm._v(" "), _c('td', [_vm._v("2012/01/21")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])])])]), _vm._v(" "), _c('ul', {
    staticClass: "pagination"
  }, [_c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Prev")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item active"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("1")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("2")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("3")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("4")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Next")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-lg-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Bordered Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-bordered"
  }, [_c('thead', [_c('tr', [_c('th', [_vm._v("Username")]), _vm._v(" "), _c('th', [_vm._v("Date registered")]), _vm._v(" "), _c('th', [_vm._v("Role")]), _vm._v(" "), _c('th', [_vm._v("Status")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("Pompeius René")]), _vm._v(" "), _c('td', [_vm._v("2012/01/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Paĉjo Jadon")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("Banned")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Micheal Mercurius")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Admin")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("Inactive")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Ganesha Dubhghall")]), _vm._v(" "), _c('td', [_vm._v("2012/03/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("Pending")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Hiroto Šimun")]), _vm._v(" "), _c('td', [_vm._v("2012/01/21")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])])])]), _vm._v(" "), _c('ul', {
    staticClass: "pagination"
  }, [_c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Prev")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item active"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("1")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("2")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("3")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("4")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Next")])])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" Combined All Table\n        ")]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-bordered table-striped table-sm"
  }, [_c('thead', [_c('tr', [_c('th', [_vm._v("Username")]), _vm._v(" "), _c('th', [_vm._v("Date registered")]), _vm._v(" "), _c('th', [_vm._v("Role")]), _vm._v(" "), _c('th', [_vm._v("Status")])])]), _vm._v(" "), _c('tbody', [_c('tr', [_c('td', [_vm._v("Vishnu Serghei")]), _vm._v(" "), _c('td', [_vm._v("2012/01/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Zbyněk Phoibos")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-danger"
  }, [_vm._v("Banned")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Einar Randall")]), _vm._v(" "), _c('td', [_vm._v("2012/02/01")]), _vm._v(" "), _c('td', [_vm._v("Admin")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-default"
  }, [_vm._v("Inactive")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Félix Troels")]), _vm._v(" "), _c('td', [_vm._v("2012/03/01")]), _vm._v(" "), _c('td', [_vm._v("Member")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-warning"
  }, [_vm._v("Pending")])])]), _vm._v(" "), _c('tr', [_c('td', [_vm._v("Aulus Agmundr")]), _vm._v(" "), _c('td', [_vm._v("2012/01/21")]), _vm._v(" "), _c('td', [_vm._v("Staff")]), _vm._v(" "), _c('td', [_c('span', {
    staticClass: "badge badge-success"
  }, [_vm._v("Active")])])])])]), _vm._v(" "), _c('nav', [_c('ul', {
    staticClass: "pagination"
  }, [_c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Prev")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item active"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("1")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("2")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("3")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("4")])]), _vm._v(" "), _c('li', {
    staticClass: "page-item"
  }, [_c('a', {
    staticClass: "page-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Next")])])])])])])])])])
}]}

/***/ }),

/***/ 541:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app"
  }, [_c('AppHeader'), _vm._v(" "), _c('div', {
    staticClass: "app-body"
  }, [_c('Sidebar'), _vm._v(" "), _c('main', {
    staticClass: "main"
  }, [_c('breadcrumb', {
    attrs: {
      "list": _vm.list
    }
  }), _vm._v(" "), _c('div', {
    staticClass: "container-fluid"
  }, [_c('router-view')], 1)], 1), _vm._v(" "), _c('AppAside')], 1), _vm._v(" "), _c('AppFooter')], 1)
},staticRenderFns: []}

/***/ }),

/***/ 542:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    class: ['modal', _vm.effect],
    attrs: {
      "role": "dialog"
    },
    on: {
      "click": function($event) {
        _vm.backdrop && _vm.action(false, 1)
      },
      "transitionend": function($event) {
        _vm.transition = false
      }
    }
  }, [_c('div', {
    class: ['modal-dialog', {
      'modal-lg': _vm.large,
      'modal-sm': _vm.small
    }],
    style: ({
      width: _vm.optionalWidth
    }),
    attrs: {
      "role": "document"
    },
    on: {
      "click": function($event) {
        $event.stopPropagation();
        _vm.action(null)
      }
    }
  }, [_c('div', {
    staticClass: "modal-content"
  }, [_vm._t("modal-header", [_c('div', {
    staticClass: "modal-header"
  }, [_c('button', {
    staticClass: "close",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.action(false, 2)
      }
    }
  }, [_c('span', [_vm._v("×")])]), _vm._v(" "), _c('h4', {
    staticClass: "modal-title"
  }, [_vm._t("title", [_vm._v(_vm._s(_vm.title))])], 2)])]), _vm._v(" "), _vm._t("modal-body", [_c('div', {
    staticClass: "modal-body"
  }, [_vm._t("default")], 2)]), _vm._v(" "), _vm._t("modal-footer", [_c('div', {
    staticClass: "modal-footer"
  }, [_c('button', {
    staticClass: "btn btn-default",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.action(false, 3)
      }
    }
  }, [_vm._v(_vm._s(_vm.cancelText))]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    },
    on: {
      "click": function($event) {
        _vm.action(true, 4)
      }
    }
  }, [_vm._v(_vm._s(_vm.okText))])])])], 2)])])
},staticRenderFns: []}

/***/ }),

/***/ 543:
/***/ (function(module, exports) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Options")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("With Icons")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-star"
  }), _vm._v("  Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-lightbulb-o"
  }), _vm._v("  Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-magic"
  }), _vm._v("  Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-map-marker"
  }), _vm._v("  Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-rss"
  }), _vm._v("  Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-link"
  }), _vm._v("  Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Size Large")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-lg")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Size Small")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-sm")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Disabled state")]), _vm._v(" "), _c('small', [_vm._v("Add this "), _c('code', [_vm._v("disabled=\"disabled\"")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Active state")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".active")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-primary active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-secondary active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Link")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Block Level Buttons")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-block")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-secondary btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-primary btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-info btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-warning btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-danger btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-link btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-6"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Options")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("With Icons")])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-star"
  }), _vm._v("  Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-lightbulb-o"
  }), _vm._v("  Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-magic"
  }), _vm._v("  Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-map-marker"
  }), _vm._v("  Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "fa fa-rss"
  }), _vm._v("  Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Size Large")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-lg")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-info btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger btn-lg",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Size Small")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-sm")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-info btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger btn-sm",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Disabled state")]), _vm._v(" "), _c('small', [_vm._v("Add this "), _c('code', [_vm._v("disabled=\"disabled\"")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-success",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-info",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger",
    attrs: {
      "type": "button",
      "disabled": "disabled"
    }
  }, [_vm._v("Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Active state")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".active")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-primary active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Primary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-secondary active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Secondary")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Success")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-info active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Info")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Warning")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger active",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Danger")])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('strong', [_vm._v("Block Level Buttons")]), _vm._v(" "), _c('small', [_vm._v("Add this class "), _c('code', [_vm._v(".btn-block")])])]), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('button', {
    staticClass: "btn btn-outline-secondary btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-primary btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-success btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-info btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-warning btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")]), _vm._v(" "), _c('button', {
    staticClass: "btn btn-outline-danger btn-lg btn-block",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("Block level button")])])])])])])
}]}

/***/ })

},[229]);
//# sourceMappingURL=app.js.map