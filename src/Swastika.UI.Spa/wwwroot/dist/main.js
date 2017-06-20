/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// identity function for calling harmony imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/dist/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 20);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports) {

/* globals __VUE_SSR_CONTEXT__ */

// this module is a runtime utility for cleaner component module output and will
// be included in the final webpack user bundle

module.exports = function normalizeComponent (
  rawScriptExports,
  compiledTemplate,
  injectStyles,
  scopeId,
  moduleIdentifier /* server only */
) {
  var esModule
  var scriptExports = rawScriptExports = rawScriptExports || {}

  // ES6 modules interop
  var type = typeof rawScriptExports.default
  if (type === 'object' || type === 'function') {
    esModule = rawScriptExports
    scriptExports = rawScriptExports.default
  }

  // Vue.extend constructor export interop
  var options = typeof scriptExports === 'function'
    ? scriptExports.options
    : scriptExports

  // render functions
  if (compiledTemplate) {
    options.render = compiledTemplate.render
    options.staticRenderFns = compiledTemplate.staticRenderFns
  }

  // scopedId
  if (scopeId) {
    options._scopeId = scopeId
  }

  var hook
  if (moduleIdentifier) { // server build
    hook = function (context) {
      // 2.3 injection
      context =
        context || // cached call
        (this.$vnode && this.$vnode.ssrContext) || // stateful
        (this.parent && this.parent.$vnode && this.parent.$vnode.ssrContext) // functional
      // 2.2 with runInNewContext: true
      if (!context && typeof __VUE_SSR_CONTEXT__ !== 'undefined') {
        context = __VUE_SSR_CONTEXT__
      }
      // inject component styles
      if (injectStyles) {
        injectStyles.call(this, context)
      }
      // register component module identifier for async chunk inferrence
      if (context && context._registeredComponents) {
        context._registeredComponents.add(moduleIdentifier)
      }
    }
    // used by ssr in case component is cached and beforeCreate
    // never gets called
    options._ssrRegister = hook
  } else if (injectStyles) {
    hook = injectStyles
  }

  if (hook) {
    var functional = options.functional
    var existing = functional
      ? options.render
      : options.beforeCreate
    if (!functional) {
      // inject component registration as beforeCreate hook
      options.beforeCreate = existing
        ? [].concat(existing, hook)
        : [hook]
    } else {
      // register for functioal component in vue file
      options.render = function renderWithStyleInjection (h, context) {
        hook.call(context)
        return existing(h, context)
      }
    }
  }

  return {
    esModule: esModule,
    exports: scriptExports,
    options: options
  }
}


/***/ }),
/* 1 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(3))(6);

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/** vue-property-decorator verson 5.1.0 MIT LICENSE copyright 2017 kaorun343 */

Object.defineProperty(exports, "__esModule", { value: true });
var vue_1 = __webpack_require__(1);
exports.Vue = vue_1.default;
var vue_class_component_1 = __webpack_require__(37);
exports.Component = vue_class_component_1.default;
__webpack_require__(36);
/**
 * decorator of an inject
 * @param key key
 * @return PropertyDecorator
 */
function Inject(key) {
    return vue_class_component_1.createDecorator(function (componentOptions, k) {
        if (typeof componentOptions.inject === 'undefined') {
            componentOptions.inject = {};
        }
        if (!Array.isArray(componentOptions.inject)) {
            componentOptions.inject[k] = key || k;
        }
    });
}
exports.Inject = Inject;
/**
 * decorator of a provide
 * @param key key
 * @return PropertyDecorator | void
 */
function Provide(key) {
    return vue_class_component_1.createDecorator(function (componentOptions, k) {
        var provide = componentOptions.provide;
        if (typeof provide !== 'function' || !provide.managed) {
            var original_1 = componentOptions.provide;
            provide = componentOptions.provide = function () {
                var rv = Object.create((typeof original_1 === 'function' ? original_1.call(this) : original_1) || null);
                for (var i in provide.managed)
                    rv[provide.managed[i]] = this[i];
                return rv;
            };
            provide.managed = {};
        }
        provide.managed[k] = key || k;
    });
}
exports.Provide = Provide;
/**
 * decorator of model
 * @param  event event name
 * @return PropertyDecorator
 */
function Model(event) {
    return vue_class_component_1.createDecorator(function (componentOptions, prop) {
        componentOptions.model = { prop: prop, event: event || prop };
    });
}
exports.Model = Model;
/**
 * decorator of a prop
 * @param  options the options for the prop
 * @return PropertyDecorator | void
 */
function Prop(options) {
    if (options === void 0) { options = {}; }
    return function (target, key) {
        if (!Array.isArray(options) && typeof options.type === 'undefined') {
            options.type = Reflect.getMetadata('design:type', target, key);
        }
        vue_class_component_1.createDecorator(function (componentOptions, k) {
            (componentOptions.props || (componentOptions.props = {}))[k] = options;
        })(target, key);
    };
}
exports.Prop = Prop;
/**
 * decorator of a watch function
 * @param  path the path or the expression to observe
 * @param  WatchOption
 * @return MethodDecorator
 */
function Watch(path, options) {
    if (options === void 0) { options = {}; }
    var _a = options.deep, deep = _a === void 0 ? false : _a, _b = options.immediate, immediate = _b === void 0 ? false : _b;
    return vue_class_component_1.createDecorator(function (componentOptions, handler) {
        if (typeof componentOptions.watch !== 'object') {
            componentOptions.watch = Object.create(null);
        }
        componentOptions.watch[path] = { handler: handler, deep: deep, immediate: immediate };
    });
}
exports.Watch = Watch;


/***/ }),
/* 3 */
/***/ (function(module, exports) {

module.exports = vendor_d545163b8ba27af346a6;

/***/ }),
/* 4 */
/***/ (function(module, exports) {

/*
	MIT License http://www.opensource.org/licenses/mit-license.php
	Author Tobias Koppers @sokra
*/
// css base code, injected by the css-loader
module.exports = function(useSourceMap) {
	var list = [];

	// return the list of modules as css string
	list.toString = function toString() {
		return this.map(function (item) {
			var content = cssWithMappingToString(item, useSourceMap);
			if(item[2]) {
				return "@media " + item[2] + "{" + content + "}";
			} else {
				return content;
			}
		}).join("");
	};

	// import a list of modules into the list
	list.i = function(modules, mediaQuery) {
		if(typeof modules === "string")
			modules = [[null, modules, ""]];
		var alreadyImportedModules = {};
		for(var i = 0; i < this.length; i++) {
			var id = this[i][0];
			if(typeof id === "number")
				alreadyImportedModules[id] = true;
		}
		for(i = 0; i < modules.length; i++) {
			var item = modules[i];
			// skip already imported module
			// this implementation is not 100% perfect for weird media query combinations
			//  when a module is imported multiple times with different media queries.
			//  I hope this will never occur (Hey this way we have smaller bundles)
			if(typeof item[0] !== "number" || !alreadyImportedModules[item[0]]) {
				if(mediaQuery && !item[2]) {
					item[2] = mediaQuery;
				} else if(mediaQuery) {
					item[2] = "(" + item[2] + ") and (" + mediaQuery + ")";
				}
				list.push(item);
			}
		}
	};
	return list;
};

function cssWithMappingToString(item, useSourceMap) {
	var content = item[1] || '';
	var cssMapping = item[3];
	if (!cssMapping) {
		return content;
	}

	if (useSourceMap && typeof btoa === 'function') {
		var sourceMapping = toComment(cssMapping);
		var sourceURLs = cssMapping.sources.map(function (source) {
			return '/*# sourceURL=' + cssMapping.sourceRoot + source + ' */'
		});

		return [content].concat(sourceURLs).concat([sourceMapping]).join('\n');
	}

	return [content].join('\n');
}

// Adapted from convert-source-map (MIT)
function toComment(sourceMap) {
	// eslint-disable-next-line no-undef
	var base64 = btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap))));
	var data = 'sourceMappingURL=data:application/json;charset=utf-8;base64,' + base64;

	return '/*# ' + data + ' */';
}


/***/ }),
/* 5 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
function injectStyle (ssrContext) {
  if (disposed) return
  __webpack_require__(68)
}
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(47),
  /* styles */
  injectStyle,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\navmenu\\navmenu.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] navmenu.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-0a10699e", Component.options)
  } else {
    hotAPI.reload("data-v-0a10699e", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 6 */
/***/ (function(module, exports, __webpack_require__) {

/*
  MIT License http://www.opensource.org/licenses/mit-license.php
  Author Tobias Koppers @sokra
  Modified by Evan You @yyx990803
*/

var hasDocument = typeof document !== 'undefined'

if (typeof DEBUG !== 'undefined' && DEBUG) {
  if (!hasDocument) {
    throw new Error(
    'vue-style-loader cannot be used in a non-browser environment. ' +
    "Use { target: 'node' } in your Webpack config to indicate a server-rendering environment."
  ) }
}

var listToStyles = __webpack_require__(70)

/*
type StyleObject = {
  id: number;
  parts: Array<StyleObjectPart>
}

type StyleObjectPart = {
  css: string;
  media: string;
  sourceMap: ?string
}
*/

var stylesInDom = {/*
  [id: number]: {
    id: number,
    refs: number,
    parts: Array<(obj?: StyleObjectPart) => void>
  }
*/}

var head = hasDocument && (document.head || document.getElementsByTagName('head')[0])
var singletonElement = null
var singletonCounter = 0
var isProduction = false
var noop = function () {}

// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
// tags it will allow on a page
var isOldIE = typeof navigator !== 'undefined' && /msie [6-9]\b/.test(navigator.userAgent.toLowerCase())

module.exports = function (parentId, list, _isProduction) {
  isProduction = _isProduction

  var styles = listToStyles(parentId, list)
  addStylesToDom(styles)

  return function update (newList) {
    var mayRemove = []
    for (var i = 0; i < styles.length; i++) {
      var item = styles[i]
      var domStyle = stylesInDom[item.id]
      domStyle.refs--
      mayRemove.push(domStyle)
    }
    if (newList) {
      styles = listToStyles(parentId, newList)
      addStylesToDom(styles)
    } else {
      styles = []
    }
    for (var i = 0; i < mayRemove.length; i++) {
      var domStyle = mayRemove[i]
      if (domStyle.refs === 0) {
        for (var j = 0; j < domStyle.parts.length; j++) {
          domStyle.parts[j]()
        }
        delete stylesInDom[domStyle.id]
      }
    }
  }
}

function addStylesToDom (styles /* Array<StyleObject> */) {
  for (var i = 0; i < styles.length; i++) {
    var item = styles[i]
    var domStyle = stylesInDom[item.id]
    if (domStyle) {
      domStyle.refs++
      for (var j = 0; j < domStyle.parts.length; j++) {
        domStyle.parts[j](item.parts[j])
      }
      for (; j < item.parts.length; j++) {
        domStyle.parts.push(addStyle(item.parts[j]))
      }
      if (domStyle.parts.length > item.parts.length) {
        domStyle.parts.length = item.parts.length
      }
    } else {
      var parts = []
      for (var j = 0; j < item.parts.length; j++) {
        parts.push(addStyle(item.parts[j]))
      }
      stylesInDom[item.id] = { id: item.id, refs: 1, parts: parts }
    }
  }
}

function createStyleElement () {
  var styleElement = document.createElement('style')
  styleElement.type = 'text/css'
  head.appendChild(styleElement)
  return styleElement
}

function addStyle (obj /* StyleObjectPart */) {
  var update, remove
  var styleElement = document.querySelector('style[data-vue-ssr-id~="' + obj.id + '"]')

  if (styleElement) {
    if (isProduction) {
      // has SSR styles and in production mode.
      // simply do nothing.
      return noop
    } else {
      // has SSR styles but in dev mode.
      // for some reason Chrome can't handle source map in server-rendered
      // style tags - source maps in <style> only works if the style tag is
      // created and inserted dynamically. So we remove the server rendered
      // styles and inject new ones.
      styleElement.parentNode.removeChild(styleElement)
    }
  }

  if (isOldIE) {
    // use singleton mode for IE9.
    var styleIndex = singletonCounter++
    styleElement = singletonElement || (singletonElement = createStyleElement())
    update = applyToSingletonTag.bind(null, styleElement, styleIndex, false)
    remove = applyToSingletonTag.bind(null, styleElement, styleIndex, true)
  } else {
    // use multi-style-tag mode in all other cases
    styleElement = createStyleElement()
    update = applyToTag.bind(null, styleElement)
    remove = function () {
      styleElement.parentNode.removeChild(styleElement)
    }
  }

  update(obj)

  return function updateStyle (newObj /* StyleObjectPart */) {
    if (newObj) {
      if (newObj.css === obj.css &&
          newObj.media === obj.media &&
          newObj.sourceMap === obj.sourceMap) {
        return
      }
      update(obj = newObj)
    } else {
      remove()
    }
  }
}

var replaceText = (function () {
  var textStore = []

  return function (index, replacement) {
    textStore[index] = replacement
    return textStore.filter(Boolean).join('\n')
  }
})()

function applyToSingletonTag (styleElement, index, remove, obj) {
  var css = remove ? '' : obj.css

  if (styleElement.styleSheet) {
    styleElement.styleSheet.cssText = replaceText(index, css)
  } else {
    var cssNode = document.createTextNode(css)
    var childNodes = styleElement.childNodes
    if (childNodes[index]) styleElement.removeChild(childNodes[index])
    if (childNodes.length) {
      styleElement.insertBefore(cssNode, childNodes[index])
    } else {
      styleElement.appendChild(cssNode)
    }
  }
}

function applyToTag (styleElement, obj) {
  var css = obj.css
  var media = obj.media
  var sourceMap = obj.sourceMap

  if (media) {
    styleElement.setAttribute('media', media)
  }

  if (sourceMap) {
    // https://developer.chrome.com/devtools/docs/javascript-debugging
    // this makes source maps inside style tags work properly in Chrome
    css += '\n/*# sourceURL=' + sourceMap.sources[0] + ' */'
    // http://stackoverflow.com/a/26603875
    css += '\n/*# sourceMappingURL=data:application/json;base64,' + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + ' */'
  }

  if (styleElement.styleSheet) {
    styleElement.styleSheet.cssText = css
  } else {
    while (styleElement.firstChild) {
      styleElement.removeChild(styleElement.firstChild)
    }
    styleElement.appendChild(document.createTextNode(css))
  }
}


/***/ }),
/* 7 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(21),
  /* template */
  __webpack_require__(59),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\app\\app.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] app.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-79ebcd20", Component.options)
  } else {
    hotAPI.reload("data-v-79ebcd20", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 8 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(23),
  /* template */
  __webpack_require__(64),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\blog.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] blog.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-d2426138", Component.options)
  } else {
    hotAPI.reload("data-v-d2426138", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 9 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(24),
  /* template */
  __webpack_require__(63),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\container\\dashboard\\dashboard.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] dashboard.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-9f96111e", Component.options)
  } else {
    hotAPI.reload("data-v-9f96111e", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 10 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(51),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\container\\widgets\\widgets.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] widgets.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-4f87ae3b", Component.options)
  } else {
    hotAPI.reload("data-v-4f87ae3b", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 11 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(25),
  /* template */
  __webpack_require__(46),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\details\\details.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] details.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-06a39e72", Component.options)
  } else {
    hotAPI.reload("data-v-06a39e72", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 12 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(29),
  /* template */
  __webpack_require__(58),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\counter\\counter.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] counter.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7473f42a", Component.options)
  } else {
    hotAPI.reload("data-v-7473f42a", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 13 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(30),
  /* template */
  __webpack_require__(62),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\fetchdata\\fetchdata.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] fetchdata.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-969460cc", Component.options)
  } else {
    hotAPI.reload("data-v-969460cc", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 14 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
function injectStyle (ssrContext) {
  if (disposed) return
  __webpack_require__(69)
}
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(31),
  /* template */
  __webpack_require__(50),
  /* styles */
  injectStyle,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\home\\home.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] home.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-4937f544", Component.options)
  } else {
    hotAPI.reload("data-v-4937f544", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 15 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(61),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\container\\dashboard\\dashboard.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] dashboard.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7e77a3e7", Component.options)
  } else {
    hotAPI.reload("data-v-7e77a3e7", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 16 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(49),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\container\\widgets\\widgets.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] widgets.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-48cf05b1", Component.options)
  } else {
    hotAPI.reload("data-v-48cf05b1", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 17 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(32),
  /* template */
  __webpack_require__(55),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\portal.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] portal.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-6a168ce4", Component.options)
  } else {
    hotAPI.reload("data-v-6a168ce4", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 18 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(66)

/***/ }),
/* 19 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(3))(5);

/***/ }),
/* 20 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_router__ = __webpack_require__(19);
//import 'bootstrap';


__WEBPACK_IMPORTED_MODULE_0_vue__["default"].use(__WEBPACK_IMPORTED_MODULE_1_vue_router__["default"]);
//const routes = [
//    { path: '/', component: require('./components/home/home.vue.html') },
//    { path: '/portal', component: require('./components/portal/portal.vue.html') },
//    { path: '/portal/dashboard', component: require('./components/portal/container/dashboard/dashboard.vue.html') },
//    { path: '/counter', component: require('./components/counter/counter.vue.html') },
//    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
//];
var routes = [
    { path: '/', name: 'Home', component: __webpack_require__(14) },
    {
        path: '/portal',
        name: 'Portal',
        component: __webpack_require__(17),
        children: [
            { path: '', name: 'Dashboard', component: __webpack_require__(15) },
            { path: 'widgets', name: 'Widgets', component: __webpack_require__(16) },
        ]
    },
    {
        path: '/blog',
        name: 'Blog',
        component: __webpack_require__(8),
        children: [
            { path: '', name: 'Dashboard', component: __webpack_require__(9) },
            { path: 'details/:id?', name: 'BlogDetails', component: __webpack_require__(11) },
            { path: 'widgets', name: 'Widgets', component: __webpack_require__(10) },
        ]
    },
    { path: '/counter', component: __webpack_require__(12) },
    { path: '/fetchdata', component: __webpack_require__(13) }
];
var vuePages = __webpack_require__(18);
new __WEBPACK_IMPORTED_MODULE_0_vue__["default"]({
    el: '#app-root',
    router: new __WEBPACK_IMPORTED_MODULE_1_vue_router__["default"]({
        mode: 'history',
        linkActiveClass: 'open active',
        routes: routes
    }),
    render: function (h) { return h(__webpack_require__(7)); }
});


/***/ }),
/* 21 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var AppComponent = (function (_super) {
    __extends(AppComponent, _super);
    function AppComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                MenuComponent: __webpack_require__(5)
            }
        })
    ], AppComponent);
    return AppComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppComponent);


/***/ }),
/* 22 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_vue_strap__ = __webpack_require__(67);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_vue_strap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_vue_strap__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var AppHeaderComponent = (function (_super) {
    __extends(AppHeaderComponent, _super);
    function AppHeaderComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppHeaderComponent.prototype.click = function () {
        // do nothing
    };
    AppHeaderComponent.prototype.sidebarToggle = function (e) {
        e.preventDefault();
        document.body.classList.toggle('sidebar-hidden');
    };
    AppHeaderComponent.prototype.sidebarMinimize = function (e) {
        e.preventDefault();
        document.body.classList.toggle('sidebar-minimized');
    };
    AppHeaderComponent.prototype.mobileSidebarToggle = function (e) {
        e.preventDefault();
        document.body.classList.toggle('sidebar-mobile-show');
    };
    AppHeaderComponent.prototype.asideToggle = function (e) {
        e.preventDefault();
        document.body.classList.toggle('aside-menu-hidden');
    };
    AppHeaderComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                navbar: __webpack_require__(40),
                dropdown: __WEBPACK_IMPORTED_MODULE_2_vue_strap__["dropdown"]
            }
        })
    ], AppHeaderComponent);
    return AppHeaderComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppHeaderComponent);


/***/ }),
/* 23 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var AppComponent = (function (_super) {
    __extends(AppComponent, _super);
    function AppComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                AppHeader: __webpack_require__(38),
                SidebarComponent: __webpack_require__(42),
                BreadcrumbComponent: __webpack_require__(39)
            }
        })
    ], AppComponent);
    return AppComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppComponent);


/***/ }),
/* 24 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var DashboardComponent = (function (_super) {
    __extends(DashboardComponent, _super);
    function DashboardComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.blogs = {};
        _this.title = 'Blogs';
        _this.filter = {
            Culture: '',
            Key: '',
            Keyword: '',
            PageIndex: 0,
            PageSize: null
        };
        _this.getListUrl = '/api/Blog';
        _this.getDetailsUrl = '/blog/details/';
        _this.createUrl = '/blog/details/00000000-0000-0000-0000-000000000000';
        _this.saveUrl = '/api/Blog/save';
        _this.removeUrl = '/api/Blog/remove';
        _this.headers = [
            { key: 'id', display: 'Id' },
            { key: 'title', display: 'Title' },
            { key: 'name', display: 'Name' }
        ];
        return _this;
    }
    DashboardComponent.prototype.mounted = function () {
        var _this = this;
        var request = {
            headers: {
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(this.filter)
        };
        fetch(this.getListUrl, request)
            .then(function (response) { return response.json(); })
            .then(function (data) {
            _this.blogs = data['data'];
            _this.title = 'Blogs';
        });
    };
    DashboardComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                paging: __webpack_require__(41),
            }
        })
    ], DashboardComponent);
    return DashboardComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (DashboardComponent);


/***/ }),
/* 25 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var DetailsComponent = (function (_super) {
    __extends(DetailsComponent, _super);
    function DetailsComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.model = null;
        _this.obj = null;
        return _this;
    }
    DetailsComponent.prototype.submit = function () {
        var _this = this;
        var request = {
            headers: {
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(this.model)
        };
        fetch('/api/blog/save', request)
            .then(function (response) { return response.json(); })
            .then(function (data) {
            if (data.status == 1) {
                _this.$router.push('/blog');
            }
        });
    };
    DetailsComponent.prototype.mounted = function () {
        var _this = this;
        this.id = this.$route.params.id;
        if (this.id != undefined && this.id != '') {
            fetch('/api/blog/' + this.id)
                .then(function (response) { return response.json(); })
                .then(function (data) {
                _this.model = data['data']; //new BlogViewModel(this.obj['data']);
            });
        }
    };
    DetailsComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            props: {
                id: String
            }
        })
    ], DetailsComponent);
    return DetailsComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (DetailsComponent);


/***/ }),
/* 26 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var AppHeaderComponent = (function (_super) {
    __extends(AppHeaderComponent, _super);
    function AppHeaderComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppHeaderComponent.prototype.created = function () {
        //this._navbar = true
    };
    AppHeaderComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {}
        })
    ], AppHeaderComponent);
    return AppHeaderComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppHeaderComponent);


/***/ }),
/* 27 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var PagingComponent = (function (_super) {
    __extends(PagingComponent, _super);
    function PagingComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.pagination = {
            total: 0,
            per_page: 12,
            current_page: 1,
            last_page: 0,
            from: 1,
            to: 12 // required 
        };
        _this.paginationOptions = {
            offset: 4,
            previousText: 'Prev',
            nextText: 'Next',
            alwaysShowPrevNext: true
        };
        return _this;
    }
    PagingComponent.prototype.mounted = function () {
    };
    PagingComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            props: {
                title: String,
                models: JSON,
                headers: Object,
                getListUrl: String,
                getDetailsUrl: String,
                saveUrl: String,
                removeUrl: String,
                createUrl: String
            }
        })
    ], PagingComponent);
    return PagingComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (PagingComponent);


/***/ }),
/* 28 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();

var SideBarComponent = (function (_super) {
    __extends(SideBarComponent, _super);
    function SideBarComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    SideBarComponent.prototype.handleClick = function (e) {
        e.preventDefault();
        e.target.classList.toggle('open');
    };
    return SideBarComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (SideBarComponent);


/***/ }),
/* 29 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var CounterComponent = (function (_super) {
    __extends(CounterComponent, _super);
    function CounterComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.currentcount = 0;
        return _this;
    }
    CounterComponent.prototype.incrementCounter = function () {
        this.currentcount++;
    };
    CounterComponent = __decorate([
        __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"]
    ], CounterComponent);
    return CounterComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (CounterComponent);


/***/ }),
/* 30 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var FetchDataComponent = (function (_super) {
    __extends(FetchDataComponent, _super);
    function FetchDataComponent() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.forecasts = [];
        return _this;
    }
    FetchDataComponent.prototype.mounted = function () {
        var _this = this;
        fetch('/api/SampleData/WeatherForecasts')
            .then(function (response) { return response.json(); })
            .then(function (data) {
            _this.forecasts = data;
        });
    };
    FetchDataComponent = __decorate([
        __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"]
    ], FetchDataComponent);
    return FetchDataComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (FetchDataComponent);


/***/ }),
/* 31 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var AppComponent = (function (_super) {
    __extends(AppComponent, _super);
    function AppComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                MenuComponent: __webpack_require__(5)
            }
        })
    ], AppComponent);
    return AppComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppComponent);


/***/ }),
/* 32 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_vue__ = __webpack_require__(1);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__ = __webpack_require__(2);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_vue_property_decorator___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


var AppComponent = (function (_super) {
    __extends(AppComponent, _super);
    function AppComponent() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    AppComponent = __decorate([
        __webpack_require__.i(__WEBPACK_IMPORTED_MODULE_1_vue_property_decorator__["Component"])({
            components: {
                MenuComponent: __webpack_require__(44),
                SidebarComponent: __webpack_require__(45),
                BreadcrumbComponent: __webpack_require__(43)
            }
        })
    ], AppComponent);
    return AppComponent;
}(__WEBPACK_IMPORTED_MODULE_0_vue__["default"]));
/* harmony default export */ __webpack_exports__["default"] = (AppComponent);


/***/ }),
/* 33 */
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(4)(true);
// imports


// module
exports.push([module.i, "", "", {"version":3,"sources":[],"names":[],"mappings":"","file":"navmenu.css","sourceRoot":""}]);

// exports


/***/ }),
/* 34 */
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(4)(true);
// imports


// module
exports.push([module.i, "/*\r\n * Globals\r\n */\r\n\r\n/* Links */\na,\r\na:focus,\r\na:hover {\r\n    color: #fff;\n}\r\n\r\n/* Custom default button */\n.btn-secondary,\r\n.btn-secondary:hover,\r\n.btn-secondary:focus {\r\n    color: #333;\r\n    text-shadow: none; /* Prevent inheritance from `body` */\r\n    background-color: #fff;\r\n    border: .05rem solid #fff;\n}\r\n\r\n\r\n/*\r\n * Base structure\r\n */\nhtml,\r\nbody {\r\n    height: 100%;\r\n    background-color: #333;\n}\nbody {\r\n    color: #fff;\r\n    text-align: center;\r\n    text-shadow: 0 .05rem .1rem rgba(0,0,0,.5);\n}\n#app-root{\r\n    height:100%;\n}\r\n\r\n/* Extra markup and styles for table-esque vertical and horizontal centering */\n.site-wrapper {\r\n    display: table;\r\n    width: 100%;\r\n    height: 100%; /* For at least Firefox */\r\n    min-height: 100%;\r\n    -webkit-box-shadow: inset 0 0 5rem rgba(0,0,0,.5);\r\n    box-shadow: inset 0 0 5rem rgba(0,0,0,.5);\n}\n.site-wrapper-inner {\r\n    display: table-cell;\r\n    vertical-align: top;\n}\n.cover-container {\r\n    margin-right: auto;\r\n    margin-left: auto;\n}\r\n\r\n/* Padding for spacing */\n.inner {\r\n    padding: 2rem;\n}\r\n\r\n\r\n/*\r\n * Header\r\n */\n.masthead {\r\n    margin-bottom: 2rem;\n}\n.masthead-brand {\r\n    margin-bottom: 0;\n}\n.nav-masthead .nav-link {\r\n    padding: .25rem 0;\r\n    font-weight: bold;\r\n    color: rgba(255,255,255,.5);\r\n    background-color: transparent;\r\n    border-bottom: .25rem solid transparent;\n}\n.nav-masthead .nav-link:hover,\r\n    .nav-masthead .nav-link:focus {\r\n        border-bottom-color: rgba(255,255,255,.25);\n}\n.nav-masthead .nav-link + .nav-link {\r\n        margin-left: 1rem;\n}\n.nav-masthead .active {\r\n    color: #fff;\r\n    border-bottom-color: #fff;\n}\n@media (min-width: 48em) {\n.masthead-brand {\r\n        float: left;\n}\n.nav-masthead {\r\n        float: right;\n}\n}\r\n\r\n\r\n/*\r\n * Cover\r\n */\n.cover {\r\n    padding: 0 1.5rem;\n}\n.cover .btn-lg {\r\n        padding: .75rem 1.25rem;\r\n        font-weight: bold;\n}\r\n\r\n\r\n/*\r\n * Footer\r\n */\n.mastfoot {\r\n    color: rgba(255,255,255,.5);\n}\r\n\r\n\r\n/*\r\n * Affix and center\r\n */\n@media (min-width: 40em) {\r\n    /* Pull out the header and footer */\n.masthead {\r\n        position: fixed;\r\n        top: 0;\n}\n.mastfoot {\r\n        position: fixed;\r\n        bottom: 0;\n}\r\n    /* Start the vertical centering */\n.site-wrapper-inner {\r\n        vertical-align: middle;\n}\r\n    /* Handle the widths */\n.masthead,\r\n    .mastfoot,\r\n    .cover-container {\r\n        width: 100%; /* Must be percentage or pixels for horizontal alignment */\n}\n}\n@media (min-width: 62em) {\n.masthead,\r\n    .mastfoot,\r\n    .cover-container {\r\n        width: 42rem;\n}\n}\r\n", "", {"version":3,"sources":["D:/NhatHoang/Git/GitHub/Swastika-Core/src/Swastika.UI.Spa/ClientApp/components/home/home.css"],"names":[],"mappings":"AAAA;;GAEG;;AAEH,WAAW;AACX;;;IAGI,YAAY;CACf;;AAED,2BAA2B;AAC3B;;;IAGI,YAAY;IACZ,kBAAkB,CAAC,qCAAqC;IACxD,uBAAuB;IACvB,0BAA0B;CAC7B;;;AAGD;;GAEG;AAEH;;IAEI,aAAa;IACb,uBAAuB;CAC1B;AAED;IACI,YAAY;IACZ,mBAAmB;IACnB,2CAA2C;CAC9C;AAED;IACI,YAAY;CACf;;AAED,+EAA+E;AAC/E;IACI,eAAe;IACf,YAAY;IACZ,aAAa,CAAC,0BAA0B;IACxC,iBAAiB;IACjB,kDAAkD;IAClD,0CAA0C;CAC7C;AAED;IACI,oBAAoB;IACpB,oBAAoB;CACvB;AAED;IACI,mBAAmB;IACnB,kBAAkB;CACrB;;AAED,yBAAyB;AACzB;IACI,cAAc;CACjB;;;AAGD;;GAEG;AAEH;IACI,oBAAoB;CACvB;AAED;IACI,iBAAiB;CACpB;AAED;IACI,kBAAkB;IAClB,kBAAkB;IAClB,4BAA4B;IAC5B,8BAA8B;IAC9B,wCAAwC;CAC3C;AAEG;;QAEI,2CAA2C;CAC9C;AAED;QACI,kBAAkB;CACrB;AAEL;IACI,YAAY;IACZ,0BAA0B;CAC7B;AAED;AACI;QACI,YAAY;CACf;AAED;QACI,aAAa;CAChB;CACJ;;;AAGD;;GAEG;AAEH;IACI,kBAAkB;CACrB;AAEG;QACI,wBAAwB;QACxB,kBAAkB;CACrB;;;AAGL;;GAEG;AAEH;IACI,4BAA4B;CAC/B;;;AAGD;;GAEG;AAEH;IACI,oCAAoC;AACpC;QACI,gBAAgB;QAChB,OAAO;CACV;AAED;QACI,gBAAgB;QAChB,UAAU;CACb;IACD,kCAAkC;AAClC;QACI,uBAAuB;CAC1B;IACD,uBAAuB;AACvB;;;QAGI,YAAY,CAAC,2DAA2D;CAC3E;CACJ;AAED;AACI;;;QAGI,aAAa;CAChB;CACJ","file":"home.css","sourcesContent":["/*\r\n * Globals\r\n */\r\n\r\n/* Links */\r\na,\r\na:focus,\r\na:hover {\r\n    color: #fff;\r\n}\r\n\r\n/* Custom default button */\r\n.btn-secondary,\r\n.btn-secondary:hover,\r\n.btn-secondary:focus {\r\n    color: #333;\r\n    text-shadow: none; /* Prevent inheritance from `body` */\r\n    background-color: #fff;\r\n    border: .05rem solid #fff;\r\n}\r\n\r\n\r\n/*\r\n * Base structure\r\n */\r\n\r\nhtml,\r\nbody {\r\n    height: 100%;\r\n    background-color: #333;\r\n}\r\n\r\nbody {\r\n    color: #fff;\r\n    text-align: center;\r\n    text-shadow: 0 .05rem .1rem rgba(0,0,0,.5);\r\n}\r\n\r\n#app-root{\r\n    height:100%;\r\n}\r\n\r\n/* Extra markup and styles for table-esque vertical and horizontal centering */\r\n.site-wrapper {\r\n    display: table;\r\n    width: 100%;\r\n    height: 100%; /* For at least Firefox */\r\n    min-height: 100%;\r\n    -webkit-box-shadow: inset 0 0 5rem rgba(0,0,0,.5);\r\n    box-shadow: inset 0 0 5rem rgba(0,0,0,.5);\r\n}\r\n\r\n.site-wrapper-inner {\r\n    display: table-cell;\r\n    vertical-align: top;\r\n}\r\n\r\n.cover-container {\r\n    margin-right: auto;\r\n    margin-left: auto;\r\n}\r\n\r\n/* Padding for spacing */\r\n.inner {\r\n    padding: 2rem;\r\n}\r\n\r\n\r\n/*\r\n * Header\r\n */\r\n\r\n.masthead {\r\n    margin-bottom: 2rem;\r\n}\r\n\r\n.masthead-brand {\r\n    margin-bottom: 0;\r\n}\r\n\r\n.nav-masthead .nav-link {\r\n    padding: .25rem 0;\r\n    font-weight: bold;\r\n    color: rgba(255,255,255,.5);\r\n    background-color: transparent;\r\n    border-bottom: .25rem solid transparent;\r\n}\r\n\r\n    .nav-masthead .nav-link:hover,\r\n    .nav-masthead .nav-link:focus {\r\n        border-bottom-color: rgba(255,255,255,.25);\r\n    }\r\n\r\n    .nav-masthead .nav-link + .nav-link {\r\n        margin-left: 1rem;\r\n    }\r\n\r\n.nav-masthead .active {\r\n    color: #fff;\r\n    border-bottom-color: #fff;\r\n}\r\n\r\n@media (min-width: 48em) {\r\n    .masthead-brand {\r\n        float: left;\r\n    }\r\n\r\n    .nav-masthead {\r\n        float: right;\r\n    }\r\n}\r\n\r\n\r\n/*\r\n * Cover\r\n */\r\n\r\n.cover {\r\n    padding: 0 1.5rem;\r\n}\r\n\r\n    .cover .btn-lg {\r\n        padding: .75rem 1.25rem;\r\n        font-weight: bold;\r\n    }\r\n\r\n\r\n/*\r\n * Footer\r\n */\r\n\r\n.mastfoot {\r\n    color: rgba(255,255,255,.5);\r\n}\r\n\r\n\r\n/*\r\n * Affix and center\r\n */\r\n\r\n@media (min-width: 40em) {\r\n    /* Pull out the header and footer */\r\n    .masthead {\r\n        position: fixed;\r\n        top: 0;\r\n    }\r\n\r\n    .mastfoot {\r\n        position: fixed;\r\n        bottom: 0;\r\n    }\r\n    /* Start the vertical centering */\r\n    .site-wrapper-inner {\r\n        vertical-align: middle;\r\n    }\r\n    /* Handle the widths */\r\n    .masthead,\r\n    .mastfoot,\r\n    .cover-container {\r\n        width: 100%; /* Must be percentage or pixels for horizontal alignment */\r\n    }\r\n}\r\n\r\n@media (min-width: 62em) {\r\n    .masthead,\r\n    .mastfoot,\r\n    .cover-container {\r\n        width: 42rem;\r\n    }\r\n}\r\n"],"sourceRoot":""}]);

// exports


/***/ }),
/* 35 */
/***/ (function(module, exports) {

// shim for using process in browser
var process = module.exports = {};

// cached from whatever global is present so that test runners that stub it
// don't break things.  But we need to wrap it in a try catch in case it is
// wrapped in strict mode code which doesn't define any globals.  It's inside a
// function because try/catches deoptimize in certain engines.

var cachedSetTimeout;
var cachedClearTimeout;

function defaultSetTimout() {
    throw new Error('setTimeout has not been defined');
}
function defaultClearTimeout () {
    throw new Error('clearTimeout has not been defined');
}
(function () {
    try {
        if (typeof setTimeout === 'function') {
            cachedSetTimeout = setTimeout;
        } else {
            cachedSetTimeout = defaultSetTimout;
        }
    } catch (e) {
        cachedSetTimeout = defaultSetTimout;
    }
    try {
        if (typeof clearTimeout === 'function') {
            cachedClearTimeout = clearTimeout;
        } else {
            cachedClearTimeout = defaultClearTimeout;
        }
    } catch (e) {
        cachedClearTimeout = defaultClearTimeout;
    }
} ())
function runTimeout(fun) {
    if (cachedSetTimeout === setTimeout) {
        //normal enviroments in sane situations
        return setTimeout(fun, 0);
    }
    // if setTimeout wasn't available but was latter defined
    if ((cachedSetTimeout === defaultSetTimout || !cachedSetTimeout) && setTimeout) {
        cachedSetTimeout = setTimeout;
        return setTimeout(fun, 0);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedSetTimeout(fun, 0);
    } catch(e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't trust the global object when called normally
            return cachedSetTimeout.call(null, fun, 0);
        } catch(e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error
            return cachedSetTimeout.call(this, fun, 0);
        }
    }


}
function runClearTimeout(marker) {
    if (cachedClearTimeout === clearTimeout) {
        //normal enviroments in sane situations
        return clearTimeout(marker);
    }
    // if clearTimeout wasn't available but was latter defined
    if ((cachedClearTimeout === defaultClearTimeout || !cachedClearTimeout) && clearTimeout) {
        cachedClearTimeout = clearTimeout;
        return clearTimeout(marker);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedClearTimeout(marker);
    } catch (e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't  trust the global object when called normally
            return cachedClearTimeout.call(null, marker);
        } catch (e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error.
            // Some versions of I.E. have different rules for clearTimeout vs setTimeout
            return cachedClearTimeout.call(this, marker);
        }
    }



}
var queue = [];
var draining = false;
var currentQueue;
var queueIndex = -1;

function cleanUpNextTick() {
    if (!draining || !currentQueue) {
        return;
    }
    draining = false;
    if (currentQueue.length) {
        queue = currentQueue.concat(queue);
    } else {
        queueIndex = -1;
    }
    if (queue.length) {
        drainQueue();
    }
}

function drainQueue() {
    if (draining) {
        return;
    }
    var timeout = runTimeout(cleanUpNextTick);
    draining = true;

    var len = queue.length;
    while(len) {
        currentQueue = queue;
        queue = [];
        while (++queueIndex < len) {
            if (currentQueue) {
                currentQueue[queueIndex].run();
            }
        }
        queueIndex = -1;
        len = queue.length;
    }
    currentQueue = null;
    draining = false;
    runClearTimeout(timeout);
}

process.nextTick = function (fun) {
    var args = new Array(arguments.length - 1);
    if (arguments.length > 1) {
        for (var i = 1; i < arguments.length; i++) {
            args[i - 1] = arguments[i];
        }
    }
    queue.push(new Item(fun, args));
    if (queue.length === 1 && !draining) {
        runTimeout(drainQueue);
    }
};

// v8 likes predictible objects
function Item(fun, array) {
    this.fun = fun;
    this.array = array;
}
Item.prototype.run = function () {
    this.fun.apply(null, this.array);
};
process.title = 'browser';
process.browser = true;
process.env = {};
process.argv = [];
process.version = ''; // empty string to avoid regexp issues
process.versions = {};

function noop() {}

process.on = noop;
process.addListener = noop;
process.once = noop;
process.off = noop;
process.removeListener = noop;
process.removeAllListeners = noop;
process.emit = noop;
process.prependListener = noop;
process.prependOnceListener = noop;

process.listeners = function (name) { return [] }

process.binding = function (name) {
    throw new Error('process.binding is not supported');
};

process.cwd = function () { return '/' };
process.chdir = function (dir) {
    throw new Error('process.chdir is not supported');
};
process.umask = function() { return 0; };


/***/ }),
/* 36 */
/***/ (function(module, exports, __webpack_require__) {

/* WEBPACK VAR INJECTION */(function(process, global) {/*! *****************************************************************************
Copyright (C) Microsoft. All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0

THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABLITY OR NON-INFRINGEMENT.

See the Apache Version 2.0 License for specific language governing permissions
and limitations under the License.
***************************************************************************** */
var Reflect;
(function (Reflect) {
    "use strict";
    var hasOwn = Object.prototype.hasOwnProperty;
    // feature test for Symbol support
    var supportsSymbol = typeof Symbol === "function";
    var toPrimitiveSymbol = supportsSymbol && typeof Symbol.toPrimitive !== "undefined" ? Symbol.toPrimitive : "@@toPrimitive";
    var iteratorSymbol = supportsSymbol && typeof Symbol.iterator !== "undefined" ? Symbol.iterator : "@@iterator";
    var HashMap;
    (function (HashMap) {
        var supportsCreate = typeof Object.create === "function"; // feature test for Object.create support
        var supportsProto = { __proto__: [] } instanceof Array; // feature test for __proto__ support
        var downLevel = !supportsCreate && !supportsProto;
        // create an object in dictionary mode (a.k.a. "slow" mode in v8)
        HashMap.create = supportsCreate
            ? function () { return MakeDictionary(Object.create(null)); }
            : supportsProto
                ? function () { return MakeDictionary({ __proto__: null }); }
                : function () { return MakeDictionary({}); };
        HashMap.has = downLevel
            ? function (map, key) { return hasOwn.call(map, key); }
            : function (map, key) { return key in map; };
        HashMap.get = downLevel
            ? function (map, key) { return hasOwn.call(map, key) ? map[key] : undefined; }
            : function (map, key) { return map[key]; };
    })(HashMap || (HashMap = {}));
    // Load global or shim versions of Map, Set, and WeakMap
    var functionPrototype = Object.getPrototypeOf(Function);
    var usePolyfill = typeof process === "object" && __webpack_require__.i({"NODE_ENV":"development"}) && __webpack_require__.i({"NODE_ENV":"development"})["REFLECT_METADATA_USE_MAP_POLYFILL"] === "true";
    var _Map = !usePolyfill && typeof Map === "function" && typeof Map.prototype.entries === "function" ? Map : CreateMapPolyfill();
    var _Set = !usePolyfill && typeof Set === "function" && typeof Set.prototype.entries === "function" ? Set : CreateSetPolyfill();
    var _WeakMap = !usePolyfill && typeof WeakMap === "function" ? WeakMap : CreateWeakMapPolyfill();
    // [[Metadata]] internal slot
    // https://rbuckton.github.io/reflect-metadata/#ordinary-object-internal-methods-and-internal-slots
    var Metadata = new _WeakMap();
    /**
      * Applies a set of decorators to a property of a target object.
      * @param decorators An array of decorators.
      * @param target The target object.
      * @param propertyKey (Optional) The property key to decorate.
      * @param attributes (Optional) The property descriptor for the target key.
      * @remarks Decorators are applied in reverse order.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     Example = Reflect.decorate(decoratorsArray, Example);
      *
      *     // property (on constructor)
      *     Reflect.decorate(decoratorsArray, Example, "staticProperty");
      *
      *     // property (on prototype)
      *     Reflect.decorate(decoratorsArray, Example.prototype, "property");
      *
      *     // method (on constructor)
      *     Object.defineProperty(Example, "staticMethod",
      *         Reflect.decorate(decoratorsArray, Example, "staticMethod",
      *             Object.getOwnPropertyDescriptor(Example, "staticMethod")));
      *
      *     // method (on prototype)
      *     Object.defineProperty(Example.prototype, "method",
      *         Reflect.decorate(decoratorsArray, Example.prototype, "method",
      *             Object.getOwnPropertyDescriptor(Example.prototype, "method")));
      *
      */
    function decorate(decorators, target, propertyKey, attributes) {
        if (!IsUndefined(propertyKey)) {
            if (!IsArray(decorators))
                throw new TypeError();
            if (!IsObject(target))
                throw new TypeError();
            if (!IsObject(attributes) && !IsUndefined(attributes) && !IsNull(attributes))
                throw new TypeError();
            if (IsNull(attributes))
                attributes = undefined;
            propertyKey = ToPropertyKey(propertyKey);
            return DecorateProperty(decorators, target, propertyKey, attributes);
        }
        else {
            if (!IsArray(decorators))
                throw new TypeError();
            if (!IsConstructor(target))
                throw new TypeError();
            return DecorateConstructor(decorators, target);
        }
    }
    Reflect.decorate = decorate;
    // 4.1.2 Reflect.metadata(metadataKey, metadataValue)
    // https://rbuckton.github.io/reflect-metadata/#reflect.metadata
    /**
      * A default metadata decorator factory that can be used on a class, class member, or parameter.
      * @param metadataKey The key for the metadata entry.
      * @param metadataValue The value for the metadata entry.
      * @returns A decorator function.
      * @remarks
      * If `metadataKey` is already defined for the target and target key, the
      * metadataValue for that key will be overwritten.
      * @example
      *
      *     // constructor
      *     @Reflect.metadata(key, value)
      *     class Example {
      *     }
      *
      *     // property (on constructor, TypeScript only)
      *     class Example {
      *         @Reflect.metadata(key, value)
      *         static staticProperty;
      *     }
      *
      *     // property (on prototype, TypeScript only)
      *     class Example {
      *         @Reflect.metadata(key, value)
      *         property;
      *     }
      *
      *     // method (on constructor)
      *     class Example {
      *         @Reflect.metadata(key, value)
      *         static staticMethod() { }
      *     }
      *
      *     // method (on prototype)
      *     class Example {
      *         @Reflect.metadata(key, value)
      *         method() { }
      *     }
      *
      */
    function metadata(metadataKey, metadataValue) {
        function decorator(target, propertyKey) {
            if (!IsObject(target))
                throw new TypeError();
            if (!IsUndefined(propertyKey) && !IsPropertyKey(propertyKey))
                throw new TypeError();
            OrdinaryDefineOwnMetadata(metadataKey, metadataValue, target, propertyKey);
        }
        return decorator;
    }
    Reflect.metadata = metadata;
    /**
      * Define a unique metadata entry on the target.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param metadataValue A value that contains attached metadata.
      * @param target The target object on which to define metadata.
      * @param propertyKey (Optional) The property key for the target.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     Reflect.defineMetadata("custom:annotation", options, Example);
      *
      *     // property (on constructor)
      *     Reflect.defineMetadata("custom:annotation", options, Example, "staticProperty");
      *
      *     // property (on prototype)
      *     Reflect.defineMetadata("custom:annotation", options, Example.prototype, "property");
      *
      *     // method (on constructor)
      *     Reflect.defineMetadata("custom:annotation", options, Example, "staticMethod");
      *
      *     // method (on prototype)
      *     Reflect.defineMetadata("custom:annotation", options, Example.prototype, "method");
      *
      *     // decorator factory as metadata-producing annotation.
      *     function MyAnnotation(options): Decorator {
      *         return (target, key?) => Reflect.defineMetadata("custom:annotation", options, target, key);
      *     }
      *
      */
    function defineMetadata(metadataKey, metadataValue, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryDefineOwnMetadata(metadataKey, metadataValue, target, propertyKey);
    }
    Reflect.defineMetadata = defineMetadata;
    /**
      * Gets a value indicating whether the target object or its prototype chain has the provided metadata key defined.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns `true` if the metadata key was defined on the target object or its prototype chain; otherwise, `false`.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.hasMetadata("custom:annotation", Example);
      *
      *     // property (on constructor)
      *     result = Reflect.hasMetadata("custom:annotation", Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.hasMetadata("custom:annotation", Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.hasMetadata("custom:annotation", Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.hasMetadata("custom:annotation", Example.prototype, "method");
      *
      */
    function hasMetadata(metadataKey, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryHasMetadata(metadataKey, target, propertyKey);
    }
    Reflect.hasMetadata = hasMetadata;
    /**
      * Gets a value indicating whether the target object has the provided metadata key defined.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns `true` if the metadata key was defined on the target object; otherwise, `false`.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.hasOwnMetadata("custom:annotation", Example);
      *
      *     // property (on constructor)
      *     result = Reflect.hasOwnMetadata("custom:annotation", Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.hasOwnMetadata("custom:annotation", Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.hasOwnMetadata("custom:annotation", Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.hasOwnMetadata("custom:annotation", Example.prototype, "method");
      *
      */
    function hasOwnMetadata(metadataKey, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryHasOwnMetadata(metadataKey, target, propertyKey);
    }
    Reflect.hasOwnMetadata = hasOwnMetadata;
    /**
      * Gets the metadata value for the provided metadata key on the target object or its prototype chain.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns The metadata value for the metadata key if found; otherwise, `undefined`.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.getMetadata("custom:annotation", Example);
      *
      *     // property (on constructor)
      *     result = Reflect.getMetadata("custom:annotation", Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.getMetadata("custom:annotation", Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.getMetadata("custom:annotation", Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.getMetadata("custom:annotation", Example.prototype, "method");
      *
      */
    function getMetadata(metadataKey, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryGetMetadata(metadataKey, target, propertyKey);
    }
    Reflect.getMetadata = getMetadata;
    /**
      * Gets the metadata value for the provided metadata key on the target object.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns The metadata value for the metadata key if found; otherwise, `undefined`.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.getOwnMetadata("custom:annotation", Example);
      *
      *     // property (on constructor)
      *     result = Reflect.getOwnMetadata("custom:annotation", Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.getOwnMetadata("custom:annotation", Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.getOwnMetadata("custom:annotation", Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.getOwnMetadata("custom:annotation", Example.prototype, "method");
      *
      */
    function getOwnMetadata(metadataKey, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryGetOwnMetadata(metadataKey, target, propertyKey);
    }
    Reflect.getOwnMetadata = getOwnMetadata;
    /**
      * Gets the metadata keys defined on the target object or its prototype chain.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns An array of unique metadata keys.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.getMetadataKeys(Example);
      *
      *     // property (on constructor)
      *     result = Reflect.getMetadataKeys(Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.getMetadataKeys(Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.getMetadataKeys(Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.getMetadataKeys(Example.prototype, "method");
      *
      */
    function getMetadataKeys(target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryMetadataKeys(target, propertyKey);
    }
    Reflect.getMetadataKeys = getMetadataKeys;
    /**
      * Gets the unique metadata keys defined on the target object.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns An array of unique metadata keys.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.getOwnMetadataKeys(Example);
      *
      *     // property (on constructor)
      *     result = Reflect.getOwnMetadataKeys(Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.getOwnMetadataKeys(Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.getOwnMetadataKeys(Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.getOwnMetadataKeys(Example.prototype, "method");
      *
      */
    function getOwnMetadataKeys(target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        return OrdinaryOwnMetadataKeys(target, propertyKey);
    }
    Reflect.getOwnMetadataKeys = getOwnMetadataKeys;
    /**
      * Deletes the metadata entry from the target object with the provided key.
      * @param metadataKey A key used to store and retrieve metadata.
      * @param target The target object on which the metadata is defined.
      * @param propertyKey (Optional) The property key for the target.
      * @returns `true` if the metadata entry was found and deleted; otherwise, false.
      * @example
      *
      *     class Example {
      *         // property declarations are not part of ES6, though they are valid in TypeScript:
      *         // static staticProperty;
      *         // property;
      *
      *         constructor(p) { }
      *         static staticMethod(p) { }
      *         method(p) { }
      *     }
      *
      *     // constructor
      *     result = Reflect.deleteMetadata("custom:annotation", Example);
      *
      *     // property (on constructor)
      *     result = Reflect.deleteMetadata("custom:annotation", Example, "staticProperty");
      *
      *     // property (on prototype)
      *     result = Reflect.deleteMetadata("custom:annotation", Example.prototype, "property");
      *
      *     // method (on constructor)
      *     result = Reflect.deleteMetadata("custom:annotation", Example, "staticMethod");
      *
      *     // method (on prototype)
      *     result = Reflect.deleteMetadata("custom:annotation", Example.prototype, "method");
      *
      */
    function deleteMetadata(metadataKey, target, propertyKey) {
        if (!IsObject(target))
            throw new TypeError();
        if (!IsUndefined(propertyKey))
            propertyKey = ToPropertyKey(propertyKey);
        var metadataMap = GetOrCreateMetadataMap(target, propertyKey, /*Create*/ false);
        if (IsUndefined(metadataMap))
            return false;
        if (!metadataMap.delete(metadataKey))
            return false;
        if (metadataMap.size > 0)
            return true;
        var targetMetadata = Metadata.get(target);
        targetMetadata.delete(propertyKey);
        if (targetMetadata.size > 0)
            return true;
        Metadata.delete(target);
        return true;
    }
    Reflect.deleteMetadata = deleteMetadata;
    function DecorateConstructor(decorators, target) {
        for (var i = decorators.length - 1; i >= 0; --i) {
            var decorator = decorators[i];
            var decorated = decorator(target);
            if (!IsUndefined(decorated) && !IsNull(decorated)) {
                if (!IsConstructor(decorated))
                    throw new TypeError();
                target = decorated;
            }
        }
        return target;
    }
    function DecorateProperty(decorators, target, propertyKey, descriptor) {
        for (var i = decorators.length - 1; i >= 0; --i) {
            var decorator = decorators[i];
            var decorated = decorator(target, propertyKey, descriptor);
            if (!IsUndefined(decorated) && !IsNull(decorated)) {
                if (!IsObject(decorated))
                    throw new TypeError();
                descriptor = decorated;
            }
        }
        return descriptor;
    }
    function GetOrCreateMetadataMap(O, P, Create) {
        var targetMetadata = Metadata.get(O);
        if (IsUndefined(targetMetadata)) {
            if (!Create)
                return undefined;
            targetMetadata = new _Map();
            Metadata.set(O, targetMetadata);
        }
        var metadataMap = targetMetadata.get(P);
        if (IsUndefined(metadataMap)) {
            if (!Create)
                return undefined;
            metadataMap = new _Map();
            targetMetadata.set(P, metadataMap);
        }
        return metadataMap;
    }
    // 3.1.1.1 OrdinaryHasMetadata(MetadataKey, O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinaryhasmetadata
    function OrdinaryHasMetadata(MetadataKey, O, P) {
        var hasOwn = OrdinaryHasOwnMetadata(MetadataKey, O, P);
        if (hasOwn)
            return true;
        var parent = OrdinaryGetPrototypeOf(O);
        if (!IsNull(parent))
            return OrdinaryHasMetadata(MetadataKey, parent, P);
        return false;
    }
    // 3.1.2.1 OrdinaryHasOwnMetadata(MetadataKey, O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinaryhasownmetadata
    function OrdinaryHasOwnMetadata(MetadataKey, O, P) {
        var metadataMap = GetOrCreateMetadataMap(O, P, /*Create*/ false);
        if (IsUndefined(metadataMap))
            return false;
        return ToBoolean(metadataMap.has(MetadataKey));
    }
    // 3.1.3.1 OrdinaryGetMetadata(MetadataKey, O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinarygetmetadata
    function OrdinaryGetMetadata(MetadataKey, O, P) {
        var hasOwn = OrdinaryHasOwnMetadata(MetadataKey, O, P);
        if (hasOwn)
            return OrdinaryGetOwnMetadata(MetadataKey, O, P);
        var parent = OrdinaryGetPrototypeOf(O);
        if (!IsNull(parent))
            return OrdinaryGetMetadata(MetadataKey, parent, P);
        return undefined;
    }
    // 3.1.4.1 OrdinaryGetOwnMetadata(MetadataKey, O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinarygetownmetadata
    function OrdinaryGetOwnMetadata(MetadataKey, O, P) {
        var metadataMap = GetOrCreateMetadataMap(O, P, /*Create*/ false);
        if (IsUndefined(metadataMap))
            return undefined;
        return metadataMap.get(MetadataKey);
    }
    // 3.1.5.1 OrdinaryDefineOwnMetadata(MetadataKey, MetadataValue, O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinarydefineownmetadata
    function OrdinaryDefineOwnMetadata(MetadataKey, MetadataValue, O, P) {
        var metadataMap = GetOrCreateMetadataMap(O, P, /*Create*/ true);
        metadataMap.set(MetadataKey, MetadataValue);
    }
    // 3.1.6.1 OrdinaryMetadataKeys(O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinarymetadatakeys
    function OrdinaryMetadataKeys(O, P) {
        var ownKeys = OrdinaryOwnMetadataKeys(O, P);
        var parent = OrdinaryGetPrototypeOf(O);
        if (parent === null)
            return ownKeys;
        var parentKeys = OrdinaryMetadataKeys(parent, P);
        if (parentKeys.length <= 0)
            return ownKeys;
        if (ownKeys.length <= 0)
            return parentKeys;
        var set = new _Set();
        var keys = [];
        for (var _i = 0, ownKeys_1 = ownKeys; _i < ownKeys_1.length; _i++) {
            var key = ownKeys_1[_i];
            var hasKey = set.has(key);
            if (!hasKey) {
                set.add(key);
                keys.push(key);
            }
        }
        for (var _a = 0, parentKeys_1 = parentKeys; _a < parentKeys_1.length; _a++) {
            var key = parentKeys_1[_a];
            var hasKey = set.has(key);
            if (!hasKey) {
                set.add(key);
                keys.push(key);
            }
        }
        return keys;
    }
    // 3.1.7.1 OrdinaryOwnMetadataKeys(O, P)
    // https://rbuckton.github.io/reflect-metadata/#ordinaryownmetadatakeys
    function OrdinaryOwnMetadataKeys(O, P) {
        var keys = [];
        var metadataMap = GetOrCreateMetadataMap(O, P, /*Create*/ false);
        if (IsUndefined(metadataMap))
            return keys;
        var keysObj = metadataMap.keys();
        var iterator = GetIterator(keysObj);
        var k = 0;
        while (true) {
            var next = IteratorStep(iterator);
            if (!next) {
                keys.length = k;
                return keys;
            }
            var nextValue = IteratorValue(next);
            try {
                keys[k] = nextValue;
            }
            catch (e) {
                try {
                    IteratorClose(iterator);
                }
                finally {
                    throw e;
                }
            }
            k++;
        }
    }
    // 6 ECMAScript Data Typ0es and Values
    // https://tc39.github.io/ecma262/#sec-ecmascript-data-types-and-values
    function Type(x) {
        if (x === null)
            return 1 /* Null */;
        switch (typeof x) {
            case "undefined": return 0 /* Undefined */;
            case "boolean": return 2 /* Boolean */;
            case "string": return 3 /* String */;
            case "symbol": return 4 /* Symbol */;
            case "number": return 5 /* Number */;
            case "object": return x === null ? 1 /* Null */ : 6 /* Object */;
            default: return 6 /* Object */;
        }
    }
    // 6.1.1 The Undefined Type
    // https://tc39.github.io/ecma262/#sec-ecmascript-language-types-undefined-type
    function IsUndefined(x) {
        return x === undefined;
    }
    // 6.1.2 The Null Type
    // https://tc39.github.io/ecma262/#sec-ecmascript-language-types-null-type
    function IsNull(x) {
        return x === null;
    }
    // 6.1.5 The Symbol Type
    // https://tc39.github.io/ecma262/#sec-ecmascript-language-types-symbol-type
    function IsSymbol(x) {
        return typeof x === "symbol";
    }
    // 6.1.7 The Object Type
    // https://tc39.github.io/ecma262/#sec-object-type
    function IsObject(x) {
        return typeof x === "object" ? x !== null : typeof x === "function";
    }
    // 7.1 Type Conversion
    // https://tc39.github.io/ecma262/#sec-type-conversion
    // 7.1.1 ToPrimitive(input [, PreferredType])
    // https://tc39.github.io/ecma262/#sec-toprimitive
    function ToPrimitive(input, PreferredType) {
        switch (Type(input)) {
            case 0 /* Undefined */: return input;
            case 1 /* Null */: return input;
            case 2 /* Boolean */: return input;
            case 3 /* String */: return input;
            case 4 /* Symbol */: return input;
            case 5 /* Number */: return input;
        }
        var hint = PreferredType === 3 /* String */ ? "string" : PreferredType === 5 /* Number */ ? "number" : "default";
        var exoticToPrim = GetMethod(input, toPrimitiveSymbol);
        if (exoticToPrim !== undefined) {
            var result = exoticToPrim.call(input, hint);
            if (IsObject(result))
                throw new TypeError();
            return result;
        }
        return OrdinaryToPrimitive(input, hint === "default" ? "number" : hint);
    }
    // 7.1.1.1 OrdinaryToPrimitive(O, hint)
    // https://tc39.github.io/ecma262/#sec-ordinarytoprimitive
    function OrdinaryToPrimitive(O, hint) {
        if (hint === "string") {
            var toString_1 = O.toString;
            if (IsCallable(toString_1)) {
                var result = toString_1.call(O);
                if (!IsObject(result))
                    return result;
            }
            var valueOf = O.valueOf;
            if (IsCallable(valueOf)) {
                var result = valueOf.call(O);
                if (!IsObject(result))
                    return result;
            }
        }
        else {
            var valueOf = O.valueOf;
            if (IsCallable(valueOf)) {
                var result = valueOf.call(O);
                if (!IsObject(result))
                    return result;
            }
            var toString_2 = O.toString;
            if (IsCallable(toString_2)) {
                var result = toString_2.call(O);
                if (!IsObject(result))
                    return result;
            }
        }
        throw new TypeError();
    }
    // 7.1.2 ToBoolean(argument)
    // https://tc39.github.io/ecma262/2016/#sec-toboolean
    function ToBoolean(argument) {
        return !!argument;
    }
    // 7.1.12 ToString(argument)
    // https://tc39.github.io/ecma262/#sec-tostring
    function ToString(argument) {
        return "" + argument;
    }
    // 7.1.14 ToPropertyKey(argument)
    // https://tc39.github.io/ecma262/#sec-topropertykey
    function ToPropertyKey(argument) {
        var key = ToPrimitive(argument, 3 /* String */);
        if (IsSymbol(key))
            return key;
        return ToString(key);
    }
    // 7.2 Testing and Comparison Operations
    // https://tc39.github.io/ecma262/#sec-testing-and-comparison-operations
    // 7.2.2 IsArray(argument)
    // https://tc39.github.io/ecma262/#sec-isarray
    function IsArray(argument) {
        return Array.isArray
            ? Array.isArray(argument)
            : argument instanceof Object
                ? argument instanceof Array
                : Object.prototype.toString.call(argument) === "[object Array]";
    }
    // 7.2.3 IsCallable(argument)
    // https://tc39.github.io/ecma262/#sec-iscallable
    function IsCallable(argument) {
        // NOTE: This is an approximation as we cannot check for [[Call]] internal method.
        return typeof argument === "function";
    }
    // 7.2.4 IsConstructor(argument)
    // https://tc39.github.io/ecma262/#sec-isconstructor
    function IsConstructor(argument) {
        // NOTE: This is an approximation as we cannot check for [[Construct]] internal method.
        return typeof argument === "function";
    }
    // 7.2.7 IsPropertyKey(argument)
    // https://tc39.github.io/ecma262/#sec-ispropertykey
    function IsPropertyKey(argument) {
        switch (Type(argument)) {
            case 3 /* String */: return true;
            case 4 /* Symbol */: return true;
            default: return false;
        }
    }
    // 7.3 Operations on Objects
    // https://tc39.github.io/ecma262/#sec-operations-on-objects
    // 7.3.9 GetMethod(V, P)
    // https://tc39.github.io/ecma262/#sec-getmethod
    function GetMethod(V, P) {
        var func = V[P];
        if (func === undefined || func === null)
            return undefined;
        if (!IsCallable(func))
            throw new TypeError();
        return func;
    }
    // 7.4 Operations on Iterator Objects
    // https://tc39.github.io/ecma262/#sec-operations-on-iterator-objects
    function GetIterator(obj) {
        var method = GetMethod(obj, iteratorSymbol);
        if (!IsCallable(method))
            throw new TypeError(); // from Call
        var iterator = method.call(obj);
        if (!IsObject(iterator))
            throw new TypeError();
        return iterator;
    }
    // 7.4.4 IteratorValue(iterResult)
    // https://tc39.github.io/ecma262/2016/#sec-iteratorvalue
    function IteratorValue(iterResult) {
        return iterResult.value;
    }
    // 7.4.5 IteratorStep(iterator)
    // https://tc39.github.io/ecma262/#sec-iteratorstep
    function IteratorStep(iterator) {
        var result = iterator.next();
        return result.done ? false : result;
    }
    // 7.4.6 IteratorClose(iterator, completion)
    // https://tc39.github.io/ecma262/#sec-iteratorclose
    function IteratorClose(iterator) {
        var f = iterator["return"];
        if (f)
            f.call(iterator);
    }
    // 9.1 Ordinary Object Internal Methods and Internal Slots
    // https://tc39.github.io/ecma262/#sec-ordinary-object-internal-methods-and-internal-slots
    // 9.1.1.1 OrdinaryGetPrototypeOf(O)
    // https://tc39.github.io/ecma262/#sec-ordinarygetprototypeof
    function OrdinaryGetPrototypeOf(O) {
        var proto = Object.getPrototypeOf(O);
        if (typeof O !== "function" || O === functionPrototype)
            return proto;
        // TypeScript doesn't set __proto__ in ES5, as it's non-standard.
        // Try to determine the superclass constructor. Compatible implementations
        // must either set __proto__ on a subclass constructor to the superclass constructor,
        // or ensure each class has a valid `constructor` property on its prototype that
        // points back to the constructor.
        // If this is not the same as Function.[[Prototype]], then this is definately inherited.
        // This is the case when in ES6 or when using __proto__ in a compatible browser.
        if (proto !== functionPrototype)
            return proto;
        // If the super prototype is Object.prototype, null, or undefined, then we cannot determine the heritage.
        var prototype = O.prototype;
        var prototypeProto = prototype && Object.getPrototypeOf(prototype);
        if (prototypeProto == null || prototypeProto === Object.prototype)
            return proto;
        // If the constructor was not a function, then we cannot determine the heritage.
        var constructor = prototypeProto.constructor;
        if (typeof constructor !== "function")
            return proto;
        // If we have some kind of self-reference, then we cannot determine the heritage.
        if (constructor === O)
            return proto;
        // we have a pretty good guess at the heritage.
        return constructor;
    }
    // naive Map shim
    function CreateMapPolyfill() {
        var cacheSentinel = {};
        var arraySentinel = [];
        var MapIterator = (function () {
            function MapIterator(keys, values, selector) {
                this._index = 0;
                this._keys = keys;
                this._values = values;
                this._selector = selector;
            }
            MapIterator.prototype["@@iterator"] = function () { return this; };
            MapIterator.prototype[iteratorSymbol] = function () { return this; };
            MapIterator.prototype.next = function () {
                var index = this._index;
                if (index >= 0 && index < this._keys.length) {
                    var result = this._selector(this._keys[index], this._values[index]);
                    if (index + 1 >= this._keys.length) {
                        this._index = -1;
                        this._keys = arraySentinel;
                        this._values = arraySentinel;
                    }
                    else {
                        this._index++;
                    }
                    return { value: result, done: false };
                }
                return { value: undefined, done: true };
            };
            MapIterator.prototype.throw = function (error) {
                if (this._index >= 0) {
                    this._index = -1;
                    this._keys = arraySentinel;
                    this._values = arraySentinel;
                }
                throw error;
            };
            MapIterator.prototype.return = function (value) {
                if (this._index >= 0) {
                    this._index = -1;
                    this._keys = arraySentinel;
                    this._values = arraySentinel;
                }
                return { value: value, done: true };
            };
            return MapIterator;
        }());
        return (function () {
            function Map() {
                this._keys = [];
                this._values = [];
                this._cacheKey = cacheSentinel;
                this._cacheIndex = -2;
            }
            Object.defineProperty(Map.prototype, "size", {
                get: function () { return this._keys.length; },
                enumerable: true,
                configurable: true
            });
            Map.prototype.has = function (key) { return this._find(key, /*insert*/ false) >= 0; };
            Map.prototype.get = function (key) {
                var index = this._find(key, /*insert*/ false);
                return index >= 0 ? this._values[index] : undefined;
            };
            Map.prototype.set = function (key, value) {
                var index = this._find(key, /*insert*/ true);
                this._values[index] = value;
                return this;
            };
            Map.prototype.delete = function (key) {
                var index = this._find(key, /*insert*/ false);
                if (index >= 0) {
                    var size = this._keys.length;
                    for (var i = index + 1; i < size; i++) {
                        this._keys[i - 1] = this._keys[i];
                        this._values[i - 1] = this._values[i];
                    }
                    this._keys.length--;
                    this._values.length--;
                    if (key === this._cacheKey) {
                        this._cacheKey = cacheSentinel;
                        this._cacheIndex = -2;
                    }
                    return true;
                }
                return false;
            };
            Map.prototype.clear = function () {
                this._keys.length = 0;
                this._values.length = 0;
                this._cacheKey = cacheSentinel;
                this._cacheIndex = -2;
            };
            Map.prototype.keys = function () { return new MapIterator(this._keys, this._values, getKey); };
            Map.prototype.values = function () { return new MapIterator(this._keys, this._values, getValue); };
            Map.prototype.entries = function () { return new MapIterator(this._keys, this._values, getEntry); };
            Map.prototype["@@iterator"] = function () { return this.entries(); };
            Map.prototype[iteratorSymbol] = function () { return this.entries(); };
            Map.prototype._find = function (key, insert) {
                if (this._cacheKey !== key) {
                    this._cacheIndex = this._keys.indexOf(this._cacheKey = key);
                }
                if (this._cacheIndex < 0 && insert) {
                    this._cacheIndex = this._keys.length;
                    this._keys.push(key);
                    this._values.push(undefined);
                }
                return this._cacheIndex;
            };
            return Map;
        }());
        function getKey(key, _) {
            return key;
        }
        function getValue(_, value) {
            return value;
        }
        function getEntry(key, value) {
            return [key, value];
        }
    }
    // naive Set shim
    function CreateSetPolyfill() {
        return (function () {
            function Set() {
                this._map = new _Map();
            }
            Object.defineProperty(Set.prototype, "size", {
                get: function () { return this._map.size; },
                enumerable: true,
                configurable: true
            });
            Set.prototype.has = function (value) { return this._map.has(value); };
            Set.prototype.add = function (value) { return this._map.set(value, value), this; };
            Set.prototype.delete = function (value) { return this._map.delete(value); };
            Set.prototype.clear = function () { this._map.clear(); };
            Set.prototype.keys = function () { return this._map.keys(); };
            Set.prototype.values = function () { return this._map.values(); };
            Set.prototype.entries = function () { return this._map.entries(); };
            Set.prototype["@@iterator"] = function () { return this.keys(); };
            Set.prototype[iteratorSymbol] = function () { return this.keys(); };
            return Set;
        }());
    }
    // naive WeakMap shim
    function CreateWeakMapPolyfill() {
        var UUID_SIZE = 16;
        var keys = HashMap.create();
        var rootKey = CreateUniqueKey();
        return (function () {
            function WeakMap() {
                this._key = CreateUniqueKey();
            }
            WeakMap.prototype.has = function (target) {
                var table = GetOrCreateWeakMapTable(target, /*create*/ false);
                return table !== undefined ? HashMap.has(table, this._key) : false;
            };
            WeakMap.prototype.get = function (target) {
                var table = GetOrCreateWeakMapTable(target, /*create*/ false);
                return table !== undefined ? HashMap.get(table, this._key) : undefined;
            };
            WeakMap.prototype.set = function (target, value) {
                var table = GetOrCreateWeakMapTable(target, /*create*/ true);
                table[this._key] = value;
                return this;
            };
            WeakMap.prototype.delete = function (target) {
                var table = GetOrCreateWeakMapTable(target, /*create*/ false);
                return table !== undefined ? delete table[this._key] : false;
            };
            WeakMap.prototype.clear = function () {
                // NOTE: not a real clear, just makes the previous data unreachable
                this._key = CreateUniqueKey();
            };
            return WeakMap;
        }());
        function CreateUniqueKey() {
            var key;
            do
                key = "@@WeakMap@@" + CreateUUID();
            while (HashMap.has(keys, key));
            keys[key] = true;
            return key;
        }
        function GetOrCreateWeakMapTable(target, create) {
            if (!hasOwn.call(target, rootKey)) {
                if (!create)
                    return undefined;
                Object.defineProperty(target, rootKey, { value: HashMap.create() });
            }
            return target[rootKey];
        }
        function FillRandomBytes(buffer, size) {
            for (var i = 0; i < size; ++i)
                buffer[i] = Math.random() * 0xff | 0;
            return buffer;
        }
        function GenRandomBytes(size) {
            if (typeof Uint8Array === "function") {
                if (typeof crypto !== "undefined")
                    return crypto.getRandomValues(new Uint8Array(size));
                if (typeof msCrypto !== "undefined")
                    return msCrypto.getRandomValues(new Uint8Array(size));
                return FillRandomBytes(new Uint8Array(size), size);
            }
            return FillRandomBytes(new Array(size), size);
        }
        function CreateUUID() {
            var data = GenRandomBytes(UUID_SIZE);
            // mark as random - RFC 4122 § 4.4
            data[6] = data[6] & 0x4f | 0x40;
            data[8] = data[8] & 0xbf | 0x80;
            var result = "";
            for (var offset = 0; offset < UUID_SIZE; ++offset) {
                var byte = data[offset];
                if (offset === 4 || offset === 6 || offset === 8)
                    result += "-";
                if (byte < 16)
                    result += "0";
                result += byte.toString(16).toLowerCase();
            }
            return result;
        }
    }
    // uses a heuristic used by v8 and chakra to force an object into dictionary mode.
    function MakeDictionary(obj) {
        obj.__ = undefined;
        delete obj.__;
        return obj;
    }
    // patch global Reflect
    (function (__global) {
        if (typeof __global.Reflect !== "undefined") {
            if (__global.Reflect !== Reflect) {
                for (var p in Reflect) {
                    if (hasOwn.call(Reflect, p)) {
                        __global.Reflect[p] = Reflect[p];
                    }
                }
            }
        }
        else {
            __global.Reflect = Reflect;
        }
    })(typeof global !== "undefined" ? global :
        typeof self !== "undefined" ? self :
            Function("return this;")());
})(Reflect || (Reflect = {}));
//# sourceMappingURL=Reflect.js.map
/* WEBPACK VAR INJECTION */}.call(exports, __webpack_require__(35), __webpack_require__(71)))

/***/ }),
/* 37 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/**
  * vue-class-component v5.0.1
  * (c) 2015-2017 Evan You
  * @license MIT
  */


Object.defineProperty(exports, '__esModule', { value: true });

function _interopDefault (ex) { return (ex && (typeof ex === 'object') && 'default' in ex) ? ex['default'] : ex; }

var Vue = _interopDefault(__webpack_require__(1));

function createDecorator(factory) {
    return function (_, key, index) {
        if (typeof index !== 'number') {
            index = undefined;
        }
        $decoratorQueue.push(function (options) { return factory(options, key, index); });
    };
}
function warn(message) {
    if (typeof console !== 'undefined') {
        console.warn('[vue-class-component] ' + message);
    }
}

function collectDataFromConstructor(vm, Component) {
    Component.prototype._init = function () {
        var _this = this;
        var keys = Object.getOwnPropertyNames(vm);
        if (vm.$options.props) {
            for (var key in vm.$options.props) {
                if (!vm.hasOwnProperty(key)) {
                    keys.push(key);
                }
            }
        }
        keys.forEach(function (key) {
            if (key.charAt(0) !== '_') {
                Object.defineProperty(_this, key, {
                    get: function () { return vm[key]; },
                    set: function (value) { return vm[key] = value; }
                });
            }
        });
    };
    var data = new Component();
    var plainData = {};
    Object.keys(data).forEach(function (key) {
        if (data[key] !== undefined) {
            plainData[key] = data[key];
        }
    });
    if (true) {
        if (!(Component.prototype instanceof Vue) && Object.keys(plainData).length > 0) {
            warn('Component class must inherit Vue or its descendant class ' +
                'when class property is used.');
        }
    }
    return plainData;
}

var $internalHooks = [
    'data',
    'beforeCreate',
    'created',
    'beforeMount',
    'mounted',
    'beforeDestroy',
    'destroyed',
    'beforeUpdate',
    'updated',
    'activated',
    'deactivated',
    'render'
];
var $decoratorQueue = [];
function componentFactory(Component, options) {
    if (options === void 0) { options = {}; }
    options.name = options.name || Component._componentTag || Component.name;
    var proto = Component.prototype;
    Object.getOwnPropertyNames(proto).forEach(function (key) {
        if (key === 'constructor') {
            return;
        }
        if ($internalHooks.indexOf(key) > -1) {
            options[key] = proto[key];
            return;
        }
        var descriptor = Object.getOwnPropertyDescriptor(proto, key);
        if (typeof descriptor.value === 'function') {
            (options.methods || (options.methods = {}))[key] = descriptor.value;
        }
        else if (descriptor.get || descriptor.set) {
            (options.computed || (options.computed = {}))[key] = {
                get: descriptor.get,
                set: descriptor.set
            };
        }
    });
    (options.mixins || (options.mixins = [])).push({
        data: function () {
            return collectDataFromConstructor(this, Component);
        }
    });
    $decoratorQueue.forEach(function (fn) { return fn(options); });
    $decoratorQueue = [];
    var superProto = Object.getPrototypeOf(Component.prototype);
    var Super = superProto instanceof Vue
        ? superProto.constructor
        : Vue;
    return Super.extend(options);
}

function Component(options) {
    if (typeof options === 'function') {
        return componentFactory(options);
    }
    return function (Component) {
        return componentFactory(Component, options);
    };
}
(function (Component) {
    function registerHooks(keys) {
        $internalHooks.push.apply($internalHooks, keys);
    }
    Component.registerHooks = registerHooks;
})(Component || (Component = {}));
var Component$1 = Component;

exports['default'] = Component$1;
exports.createDecorator = createDecorator;


/***/ }),
/* 38 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(22),
  /* template */
  __webpack_require__(60),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\app-header\\header.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] header.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-7db92399", Component.options)
  } else {
    hotAPI.reload("data-v-7db92399", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 39 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(53),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\breadcrumb\\breadcrumb.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] breadcrumb.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-64d5bbad", Component.options)
  } else {
    hotAPI.reload("data-v-64d5bbad", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 40 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(26),
  /* template */
  __webpack_require__(52),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\nav-bar\\nav-bar.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] nav-bar.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-630aa339", Component.options)
  } else {
    hotAPI.reload("data-v-630aa339", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 41 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(27),
  /* template */
  __webpack_require__(48),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\paging-container\\paging-container.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] paging-container.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-3d11ae8d", Component.options)
  } else {
    hotAPI.reload("data-v-3d11ae8d", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 42 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  __webpack_require__(28),
  /* template */
  __webpack_require__(56),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\blog\\sidebar\\sidebar.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] sidebar.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-6e73b313", Component.options)
  } else {
    hotAPI.reload("data-v-6e73b313", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 43 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(65),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\breadcrumb\\breadcrumb.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] breadcrumb.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-f7a183ba", Component.options)
  } else {
    hotAPI.reload("data-v-f7a183ba", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 44 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(57),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\navbar\\navbar.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] navbar.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-70f6fdc3", Component.options)
  } else {
    hotAPI.reload("data-v-70f6fdc3", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 45 */
/***/ (function(module, exports, __webpack_require__) {

var disposed = false
var Component = __webpack_require__(0)(
  /* script */
  null,
  /* template */
  __webpack_require__(54),
  /* styles */
  null,
  /* scopeId */
  null,
  /* moduleIdentifier (server only) */
  null
)
Component.options.__file = "D:\\NhatHoang\\Git\\GitHub\\Swastika-Core\\src\\Swastika.UI.Spa\\ClientApp\\components\\portal\\sidebar\\sidebar.vue.html"
if (Component.esModule && Object.keys(Component.esModule).some(function (key) {return key !== "default" && key.substr(0, 2) !== "__"})) {console.error("named exports are not supported in *.vue files.")}
if (Component.options.functional) {console.error("[vue-loader] sidebar.vue.html: functional components are not supported with templates, they should use render functions.")}

/* hot reload */
if (false) {(function () {
  var hotAPI = require("vue-hot-reload-api")
  hotAPI.install(require("vue"), false)
  if (!hotAPI.compatible) return
  module.hot.accept()
  if (!module.hot.data) {
    hotAPI.createRecord("data-v-65e5c609", Component.options)
  } else {
    hotAPI.reload("data-v-65e5c609", Component.options)
  }
  module.hot.dispose(function (data) {
    disposed = true
  })
})()}

module.exports = Component.exports


/***/ }),
/* 46 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-lg-12",
    attrs: {
      "id": "details"
    }
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v("\n            " + _vm._s(_vm.model) + "\n        ")]), _vm._v(" "), (_vm.model != null) ? _c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "company"
    }
  }, [_vm._v("Name")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.model.name),
      expression: "model.name"
    }],
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Enter your company name"
    },
    domProps: {
      "value": (_vm.model.name)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.model.name = $event.target.value
      }
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "company"
    }
  }, [_vm._v("Title")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.model.title),
      expression: "model.title"
    }],
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Enter your company name"
    },
    domProps: {
      "value": (_vm.model.title)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.model.title = $event.target.value
      }
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "company"
    }
  }, [_vm._v("Slug")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.model.slug),
      expression: "model.slug"
    }],
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Enter your company name"
    },
    domProps: {
      "value": (_vm.model.slug)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.model.slug = $event.target.value
      }
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "form-group"
  }, [_c('label', {
    attrs: {
      "for": "company"
    }
  }, [_vm._v("description")]), _vm._v(" "), _c('input', {
    directives: [{
      name: "model",
      rawName: "v-model",
      value: (_vm.model.description),
      expression: "model.description"
    }],
    staticClass: "form-control",
    attrs: {
      "type": "text",
      "placeholder": "Enter your company name"
    },
    domProps: {
      "value": (_vm.model.description)
    },
    on: {
      "input": function($event) {
        if ($event.target.composing) { return; }
        _vm.model.description = $event.target.value
      }
    }
  })])]) : _vm._e(), _vm._v(" "), _c('div', {
    staticClass: "card-footer"
  }, [_c('button', {
    staticClass: "btn btn-sm btn-primary",
    attrs: {
      "type": "submit"
    },
    on: {
      "click": _vm.submit
    }
  }, [_c('i', {
    staticClass: "fa fa-dot-circle-o"
  }), _vm._v(" Submit")]), _vm._v(" "), _vm._m(0)])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-ban"
  }), _vm._v(" Reset")])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-06a39e72", module.exports)
  }
}

/***/ }),
/* 47 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('nav', {
    staticClass: "nav nav-masthead"
  }, [_c('a', {
    staticClass: "nav-link active",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Home")]), _vm._v(" "), _c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Features")]), _vm._v(" "), _c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Contact")]), _vm._v(" "), _c('a', {
    staticClass: "nav-link",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Register")]), _vm._v(" "), _c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": "/portal"
    }
  }, [_vm._v("Portal")])], 1)
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-0a10699e", module.exports)
  }
}

/***/ }),
/* 48 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "col-lg-12",
    attrs: {
      "id": "page-dashboard"
    }
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_c('i', {
    staticClass: "fa fa-align-justify"
  }), _vm._v(" "), _c('span', {
    domProps: {
      "textContent": _vm._s(_vm.title)
    }
  }), _vm._v(" "), _c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": _vm.createUrl
    }
  }, [_c('i', {
    staticClass: "icon-calculator"
  }), _vm._v(" Create New")])], 1), _vm._v(" "), _c('div', {
    staticClass: "card-block"
  }, [_c('table', {
    staticClass: "table table-bordered table-striped table-sm"
  }, [_c('thead', [_vm._l((_vm.headers), function(header) {
    return _c('th', [_c('span', {
      domProps: {
        "textContent": _vm._s(header.display)
      }
    })])
  }), _vm._v(" "), _c('th', [_vm._v("\n                    Actions\n                ")])], 2), _vm._v(" "), _c('tbody', _vm._l((_vm.models.items), function(item) {
    return _c('tr', [_vm._l((_vm.headers), function(header) {
      return _c('td', [_c('span', {
        domProps: {
          "textContent": _vm._s(item[header.key])
        }
      })])
    }), _vm._v(" "), _c('td', [_c('router-link', {
      staticClass: "btn btn-sm btn-info",
      attrs: {
        "to": _vm.getDetailsUrl + item.id
      }
    }, [_c('i', {
      staticClass: "fa fa-eye"
    })]), _vm._v(" "), _vm._m(0, true)], 1)], 2)
  }))]), _vm._v(" "), _c('div', {
    directives: [{
      name: "pagination",
      rawName: "v-pagination"
    }],
    attrs: {
      "pagination": _vm.pagination,
      "callback": _vm.loadData,
      "options": _vm.paginationOptions
    }
  })])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('button', {
    staticClass: "btn btn-sm btn-danger",
    attrs: {
      "type": "reset"
    }
  }, [_c('i', {
    staticClass: "fa fa-remove"
  })])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-3d11ae8d", module.exports)
  }
}

/***/ }),
/* 49 */
/***/ (function(module, exports, __webpack_require__) {

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
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart1",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('button', {
    staticClass: "btn btn-transparent active p-0 float-right",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-location-pin"
  })]), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart2",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart3",
      "height": "70"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "card-chart4",
      "height": "70"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-primary"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-danger"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-2 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-2 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-success"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-3 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-3 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-warning"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-4 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-4 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])])]), _vm._v(" "), _c('div', {
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
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-1",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-2",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-3",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-4",
      "height": "40",
      "width": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-5",
      "height": "40",
      "width": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-6",
      "height": "40",
      "width": "100"
    }
  })])])])])]), _vm._v(" "), _c('div', {
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
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-48cf05b1", module.exports)
  }
}

/***/ }),
/* 50 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "site-wrapper"
  }, [_c('div', {
    staticClass: "site-wrapper-inner"
  }, [_c('div', {
    staticClass: "cover-container"
  }, [_c('div', {
    staticClass: "masthead clearfix"
  }, [_c('div', {
    staticClass: "inner"
  }, [_c('h3', {
    staticClass: "masthead-brand"
  }, [_vm._v("Swastika I/O")]), _vm._v(" "), _c('menu-component')], 1)]), _vm._v(" "), _vm._m(0), _vm._v(" "), _vm._m(1)])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "inner cover"
  }, [_c('h1', {
    staticClass: "cover-heading"
  }, [_vm._v("All in One platform.")]), _vm._v(" "), _c('p', {
    staticClass: "lead"
  }, [_c('strong', [_vm._v("Swastika I/O")]), _vm._v(" is a fully open source, hackable platform for building and running a modern online publication.")]), _vm._v(" "), _c('p', {
    staticClass: "lead"
  }, [_c('a', {
    staticClass: "btn btn-lg btn-secondary",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Learn more")])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "mastfoot"
  }, [_c('div', {
    staticClass: "inner"
  }, [_c('p', [_vm._v("Powered with ❤ by "), _c('a', {
    attrs: {
      "href": "http://www.swastika.io"
    }
  }, [_vm._v("Swastika I/O")]), _vm._v(".")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-4937f544", module.exports)
  }
}

/***/ }),
/* 51 */
/***/ (function(module, exports, __webpack_require__) {

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
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart1",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('button', {
    staticClass: "btn btn-transparent active p-0 float-right",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-location-pin"
  })]), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart2",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "card-chart3",
      "height": "70"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "card-chart4",
      "height": "70"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-primary"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-danger"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-2 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-2 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-success"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-3 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-3 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header card-header-inverse card-header-warning"
  }, [_c('div', {
    staticClass: "font-weight-bold"
  }, [_c('span', [_vm._v("SALE")]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("$1.890,65")])]), _vm._v(" "), _c('div', [_c('span', [_c('small', [_vm._v("Today 6:43 AM")])]), _vm._v(" "), _c('span', {
    staticClass: "float-right"
  }, [_c('small', [_vm._v("+432,50 (15,78%)")])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-7-4 chart chart-line",
    attrs: {
      "height": "38"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "38px"
    }
  }, [_c('canvas', {
    staticClass: "chart-8-4 chart chart-bar",
    attrs: {
      "height": "38"
    }
  })])])])])]), _vm._v(" "), _c('div', {
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
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-1",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-2",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-bar",
    attrs: {
      "id": "chart-3",
      "height": "40",
      "width": "80"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-4",
      "height": "40",
      "width": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-5",
      "height": "40",
      "width": "100"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-md-2 col-sm-4"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block text-center"
  }, [_c('div', {
    staticClass: "text-muted small text-uppercase font-weight-bold"
  }, [_vm._v("Title")]), _vm._v(" "), _c('div', {
    staticClass: "h2 py-3"
  }, [_vm._v("1,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    staticClass: "chart chart-line",
    attrs: {
      "id": "chart-6",
      "height": "40",
      "width": "100"
    }
  })])])])])]), _vm._v(" "), _c('div', {
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
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-4f87ae3b", module.exports)
  }
}

/***/ }),
/* 52 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('header', {
    staticClass: "app-header navbar"
  }, [_vm._t("default")], 2)
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-630aa339", module.exports)
  }
}

/***/ }),
/* 53 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ol', {
    staticClass: "breadcrumb"
  }, [_c('li', {
    staticClass: "breadcrumb-item"
  }, [_vm._v("Home")]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-item"
  }, [_c('a', {
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Admin")])]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-item active"
  }, [_vm._v("Dashboard")]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-menu d-md-down-none"
  }, [_c('div', {
    staticClass: "btn-group",
    attrs: {
      "role": "group",
      "aria-label": "Button group with nested dropdown"
    }
  }, [_c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-speech"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "./"
    }
  }, [_c('i', {
    staticClass: "icon-graph"
  }), _vm._v("  Dashboard")]), _vm._v(" "), _c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  }), _vm._v("  Settings")])])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-64d5bbad", module.exports)
  }
}

/***/ }),
/* 54 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('nav', {
    staticClass: "sidebar-nav"
  }, [_c('nav', {
    staticClass: "sidebar-nav"
  }, [_c('ul', {
    staticClass: "nav"
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": "/portal"
    }
  }, [_c('i', {
    staticClass: "icon-speedometer"
  }), _vm._v(" Dashboard "), _c('span', {
    staticClass: "badge badge-info"
  }, [_vm._v("NEW")])])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": "/portal/widgets"
    }
  }, [_c('i', {
    staticClass: "icon-calculator"
  }), _vm._v(" Widgets "), _c('span', {
    staticClass: "badge badge-info"
  }, [_vm._v("NEW")])])], 1)])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-65e5c609", module.exports)
  }
}

/***/ }),
/* 55 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app header-fixed sidebar-fixed aside-menu-fixed aside-menu-hidden"
  }, [_c('link', {
    attrs: {
      "href": "/dist/coreui/css/font-awesome.min.css",
      "rel": "stylesheet"
    }
  }), _vm._v(" "), _c('link', {
    attrs: {
      "href": "/dist/coreui/css/simple-line-icons.css",
      "rel": "stylesheet"
    }
  }), _vm._v(" "), _c('link', {
    attrs: {
      "href": "/dist/coreui/css/style.css",
      "rel": "stylesheet"
    }
  }), _vm._v(" "), _c('header', {
    staticClass: "app-header navbar"
  }, [_c('button', {
    staticClass: "navbar-toggler mobile-sidebar-toggler d-lg-none",
    attrs: {
      "type": "button"
    }
  }, [_vm._v("☰")]), _vm._v(" "), _c('a', {
    staticClass: "navbar-brand",
    attrs: {
      "href": "#"
    }
  }), _vm._v(" "), _c('menu-component')], 1), _vm._v(" "), _c('div', {
    staticClass: "app-body"
  }, [_c('div', {
    staticClass: "sidebar"
  }, [_c('sidebar-component')], 1), _vm._v(" "), _c('main', {
    staticClass: "main"
  }, [_c('breadcrumb-component'), _vm._v(" "), _c('div', {
    staticClass: "container-fluid"
  }, [_c('router-view')], 1)], 1), _vm._v(" "), _vm._m(0)]), _vm._v(" "), _vm._m(1)])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('aside', {
    staticClass: "aside-menu"
  }, [_c('ul', {
    staticClass: "nav nav-tabs",
    attrs: {
      "role": "tablist"
    }
  }, [_c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link active",
    attrs: {
      "data-toggle": "tab",
      "href": "#timeline",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "icon-list"
  })])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "data-toggle": "tab",
      "href": "#messages",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "icon-speech"
  })])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link",
    attrs: {
      "data-toggle": "tab",
      "href": "#settings",
      "role": "tab"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "tab-content"
  }, [_c('div', {
    staticClass: "tab-pane active",
    attrs: {
      "id": "timeline",
      "role": "tabpanel"
    }
  }, [_c('div', {
    staticClass: "callout m-a-0 p-y-h text-muted text-xs-center bg-faded text-uppercase"
  }, [_c('small', [_c('b', [_vm._v("Today")])])]), _vm._v(" "), _c('hr', {
    staticClass: "transparent m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout callout-warning m-a-0 p-y-1"
  }, [_c('div', {
    staticClass: "avatar pull-xs-right"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', [_vm._v("\n                            Meeting with\n                            "), _c('strong', [_vm._v("Lucas")])]), _vm._v(" "), _c('small', {
    staticClass: "text-muted m-r-1"
  }, [_c('i', {
    staticClass: "icon-calendar"
  }), _vm._v("  1 - 3pm")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_c('i', {
    staticClass: "icon-location-pin"
  }), _vm._v("  Palo Alto, CA ")])]), _vm._v(" "), _c('hr', {
    staticClass: "m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout callout-info m-a-0 p-y-1"
  }, [_c('div', {
    staticClass: "avatar pull-xs-right"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/4.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', [_vm._v("\n                            Skype with\n                            "), _c('strong', [_vm._v("Megan")])]), _vm._v(" "), _c('small', {
    staticClass: "text-muted m-r-1"
  }, [_c('i', {
    staticClass: "icon-calendar"
  }), _vm._v("  4 - 5pm")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_c('i', {
    staticClass: "icon-social-skype"
  }), _vm._v("  On-line ")])]), _vm._v(" "), _c('hr', {
    staticClass: "transparent m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout m-a-0 p-y-h text-muted text-xs-center bg-faded text-uppercase"
  }, [_c('small', [_c('b', [_vm._v("Tomorrow")])])]), _vm._v(" "), _c('hr', {
    staticClass: "transparent m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout callout-danger m-a-0 p-y-1"
  }, [_c('div', [_vm._v("\n                            New UI Project -\n                            "), _c('strong', [_vm._v("deadline")])]), _vm._v(" "), _c('small', {
    staticClass: "text-muted m-r-1"
  }, [_c('i', {
    staticClass: "icon-calendar"
  }), _vm._v("  10 - 11pm")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_c('i', {
    staticClass: "icon-home"
  }), _vm._v("  creativeLabs HQ ")]), _vm._v(" "), _c('div', {
    staticClass: "avatars-stack m-t-h"
  }, [_c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/2.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/3.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/4.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/5.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })])])]), _vm._v(" "), _c('hr', {
    staticClass: "m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout callout-success m-a-0 p-y-1"
  }, [_c('div', [_c('strong', [_vm._v("#10 Startups.Garden")]), _vm._v(" Meetup\n                        ")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted m-r-1"
  }, [_c('i', {
    staticClass: "icon-calendar"
  }), _vm._v("  1 - 3pm")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_c('i', {
    staticClass: "icon-location-pin"
  }), _vm._v("  Palo Alto, CA ")])]), _vm._v(" "), _c('hr', {
    staticClass: "m-x-1 m-y-0"
  }), _vm._v(" "), _c('div', {
    staticClass: "callout callout-primary m-a-0 p-y-1"
  }, [_c('div', [_c('strong', [_vm._v("Team meeting")])]), _vm._v(" "), _c('small', {
    staticClass: "text-muted m-r-1"
  }, [_c('i', {
    staticClass: "icon-calendar"
  }), _vm._v("  4 - 6pm")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_c('i', {
    staticClass: "icon-home"
  }), _vm._v("  creativeLabs HQ ")]), _vm._v(" "), _c('div', {
    staticClass: "avatars-stack m-t-h"
  }, [_c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/2.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/3.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/4.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/5.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })]), _vm._v(" "), _c('div', {
    staticClass: "avatar avatar-xs"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/8.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  })])])]), _vm._v(" "), _c('hr', {
    staticClass: "m-x-1 m-y-0"
  })]), _vm._v(" "), _c('div', {
    staticClass: "tab-pane p-a-1",
    attrs: {
      "id": "messages",
      "role": "tabpanel"
    }
  }, [_c('div', {
    staticClass: "message"
  }, [_c('div', {
    staticClass: "p-y-1 p-b-3 m-r-1 pull-left"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status tag-success"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lukasz Holeczek")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted pull-right m-t-q"
  }, [_vm._v("1:52 PM")])]), _vm._v(" "), _c('div', {
    staticClass: "text-truncate font-weight-bold"
  }, [_vm._v("Lorem ipsum dolor sit amet")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt...")])]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('div', {
    staticClass: "message"
  }, [_c('div', {
    staticClass: "p-y-1 p-b-3 m-r-1 pull-left"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status tag-success"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lukasz Holeczek")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted pull-right m-t-q"
  }, [_vm._v("1:52 PM")])]), _vm._v(" "), _c('div', {
    staticClass: "text-truncate font-weight-bold"
  }, [_vm._v("Lorem ipsum dolor sit amet")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt...")])]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('div', {
    staticClass: "message"
  }, [_c('div', {
    staticClass: "p-y-1 p-b-3 m-r-1 pull-left"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status tag-success"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lukasz Holeczek")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted pull-right m-t-q"
  }, [_vm._v("1:52 PM")])]), _vm._v(" "), _c('div', {
    staticClass: "text-truncate font-weight-bold"
  }, [_vm._v("Lorem ipsum dolor sit amet")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt...")])]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('div', {
    staticClass: "message"
  }, [_c('div', {
    staticClass: "p-y-1 p-b-3 m-r-1 pull-left"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status tag-success"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lukasz Holeczek")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted pull-right m-t-q"
  }, [_vm._v("1:52 PM")])]), _vm._v(" "), _c('div', {
    staticClass: "text-truncate font-weight-bold"
  }, [_vm._v("Lorem ipsum dolor sit amet")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt...")])]), _vm._v(" "), _c('hr'), _vm._v(" "), _c('div', {
    staticClass: "message"
  }, [_c('div', {
    staticClass: "p-y-1 p-b-3 m-r-1 pull-left"
  }, [_c('div', {
    staticClass: "avatar"
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "assets/img/avatars/7.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "avatar-status tag-success"
  })])]), _vm._v(" "), _c('div', [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lukasz Holeczek")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted pull-right m-t-q"
  }, [_vm._v("1:52 PM")])]), _vm._v(" "), _c('div', {
    staticClass: "text-truncate font-weight-bold"
  }, [_vm._v("Lorem ipsum dolor sit amet")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt...")])])]), _vm._v(" "), _c('div', {
    staticClass: "tab-pane p-a-1",
    attrs: {
      "id": "settings",
      "role": "tabpanel"
    }
  }, [_c('h6', [_vm._v("Settings")]), _vm._v(" "), _c('div', {
    staticClass: "aside-options"
  }, [_c('div', {
    staticClass: "clearfix m-t-2"
  }, [_c('small', [_c('b', [_vm._v("Option 1")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm pull-right"
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
    staticClass: "clearfix m-t-1"
  }, [_c('small', [_c('b', [_vm._v("Option 2")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm pull-right"
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
    staticClass: "clearfix m-t-1"
  }, [_c('small', [_c('b', [_vm._v("Option 3")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm pull-right"
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
    staticClass: "clearfix m-t-1"
  }, [_c('small', [_c('b', [_vm._v("Option 4")])]), _vm._v(" "), _c('label', {
    staticClass: "switch switch-text switch-pill switch-success switch-sm pull-right"
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
    staticClass: "text-uppercase m-b-q m-t-2"
  }, [_c('small', [_c('b', [_vm._v("CPU Usage")])])]), _vm._v(" "), _c('progress', {
    staticClass: "progress progress-xs progress-info m-a-0",
    attrs: {
      "value": "25",
      "max": "100"
    }
  }, [_vm._v("25%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("348 Processes. 1/4 Cores.")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase m-b-q m-t-h"
  }, [_c('small', [_c('b', [_vm._v("Memory Usage")])])]), _vm._v(" "), _c('progress', {
    staticClass: "progress progress-xs progress-warning m-a-0",
    attrs: {
      "value": "70",
      "max": "100"
    }
  }, [_vm._v("70%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("11444GB/16384MB")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase m-b-q m-t-h"
  }, [_c('small', [_c('b', [_vm._v("SSD 1 Usage")])])]), _vm._v(" "), _c('progress', {
    staticClass: "progress progress-xs progress-danger m-a-0",
    attrs: {
      "value": "95",
      "max": "100"
    }
  }, [_vm._v("95%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("243GB/256GB")]), _vm._v(" "), _c('div', {
    staticClass: "text-uppercase m-b-q m-t-h"
  }, [_c('small', [_c('b', [_vm._v("SSD 2 Usage")])])]), _vm._v(" "), _c('progress', {
    staticClass: "progress progress-xs progress-success m-a-0",
    attrs: {
      "value": "10",
      "max": "100"
    }
  }, [_vm._v("10%")]), _vm._v(" "), _c('small', {
    staticClass: "text-muted"
  }, [_vm._v("25GB/256GB")])])])])
},function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('footer', {
    staticClass: "app-footer"
  }, [_c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")]), _vm._v(" © 2017 creativeLabs.\n        "), _c('span', {
    staticClass: "float-right"
  }, [_vm._v("\n            Powered by "), _c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-6a168ce4", module.exports)
  }
}

/***/ }),
/* 56 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('nav', {
    staticClass: "sidebar-nav"
  }, [_c('nav', {
    staticClass: "sidebar-nav"
  }, [_c('ul', {
    staticClass: "nav"
  }, [_c('li', {
    staticClass: "nav-item",
    on: {
      "click": _vm.handleClick
    }
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": "/blog"
    }
  }, [_c('i', {
    staticClass: "icon-speedometer"
  }), _vm._v(" Dashboard")])], 1), _vm._v(" "), _c('li', {
    staticClass: "nav-item",
    on: {
      "click": _vm.handleClick
    }
  }, [_c('router-link', {
    staticClass: "nav-link",
    attrs: {
      "to": "/blog/widgets"
    }
  }, [_c('i', {
    staticClass: "icon-calculator"
  }), _vm._v(" Widgets")])], 1)])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-6e73b313", module.exports)
  }
}

/***/ }),
/* 57 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ul', {
    staticClass: "nav navbar-nav d-md-down-none"
  }, [_c('li', {
    staticClass: "nav-item dropdown"
  }, [_c('a', {
    staticClass: "nav-link dropdown-toggle nav-link",
    attrs: {
      "data-toggle": "dropdown",
      "href": "#",
      "role": "button",
      "aria-haspopup": "true",
      "aria-expanded": "true"
    }
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "/images/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "hidden-md-down"
  }, [_vm._v("admin")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
  }, [_c('div', {
    staticClass: "dropdown-header text-xs-center"
  }, [_c('strong', [_vm._v("Account")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-bell-o"
  }), _vm._v(" Updates"), _c('span', {
    staticClass: "tag tag-info"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-envelope-o"
  }), _vm._v(" Messages"), _c('span', {
    staticClass: "tag tag-success"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-tasks"
  }), _vm._v(" Tasks"), _c('span', {
    staticClass: "tag tag-danger"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-comments"
  }), _vm._v(" Comments"), _c('span', {
    staticClass: "tag tag-warning"
  }, [_vm._v("42")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-header text-xs-center"
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
    staticClass: "tag tag-default"
  }, [_vm._v("42")])]), _vm._v(" "), _c('a', {
    staticClass: "dropdown-item",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "fa fa-file"
  }), _vm._v(" Projects"), _c('span', {
    staticClass: "tag tag-primary"
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
    staticClass: "nav-item"
  }, [_c('a', {
    staticClass: "nav-link navbar-toggler sidebar-toggler",
    attrs: {
      "href": "#"
    }
  }, [_vm._v("☰")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-70f6fdc3", module.exports)
  }
}

/***/ }),
/* 58 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', [_c('h1', [_vm._v("Counter")]), _vm._v(" "), _c('p', [_vm._v("This is a simple example of a Vue.js component.")]), _vm._v(" "), _c('p', [_vm._v("Current count: "), _c('strong', [_vm._v(_vm._s(_vm.currentcount))])]), _vm._v(" "), _c('button', {
    on: {
      "click": _vm.incrementCounter
    }
  }, [_vm._v("Increment")])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-7473f42a", module.exports)
  }
}

/***/ }),
/* 59 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    attrs: {
      "id": "app-root"
    }
  }, [_c('router-view')], 1)
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-79ebcd20", module.exports)
  }
}

/***/ }),
/* 60 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('navbar', [_c('button', {
    staticClass: "navbar-toggler mobile-sidebar-toggler d-lg-none",
    attrs: {
      "type": "button"
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
  })])]), _vm._v(" "), _c('li', {
    staticClass: "nav-item dropdown"
  }, [_c('a', {
    staticClass: "nav-link dropdown-toggle nav-link",
    attrs: {
      "data-toggle": "dropdown",
      "href": "#",
      "role": "button",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('img', {
    staticClass: "img-avatar",
    attrs: {
      "src": "img/avatars/6.jpg",
      "alt": "admin@bootstrapmaster.com"
    }
  }), _vm._v(" "), _c('span', {
    staticClass: "d-md-down-none"
  }, [_vm._v("admin")])]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
    }
  }, [_vm._v("☰")])])])])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-7db92399", module.exports)
  }
}

/***/ }),
/* 61 */
/***/ (function(module, exports, __webpack_require__) {

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
    staticClass: "card card-inverse card-primary"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart",
    attrs: {
      "id": "card-chart1",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-info"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('button', {
    staticClass: "btn btn-transparent active p-0 float-right",
    attrs: {
      "type": "button"
    }
  }, [_c('i', {
    staticClass: "icon-location-pin"
  })]), _vm._v(" "), _c('h4', {
    staticClass: "mb-0"
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart",
    attrs: {
      "id": "card-chart2",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-warning"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart",
    attrs: {
      "id": "card-chart3",
      "height": "70"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "card card-inverse card-danger"
  }, [_c('div', {
    staticClass: "card-block pb-0"
  }, [_c('div', {
    staticClass: "btn-group float-right"
  }, [_c('button', {
    staticClass: "btn btn-transparent active dropdown-toggle p-0",
    attrs: {
      "type": "button",
      "data-toggle": "dropdown",
      "aria-haspopup": "true",
      "aria-expanded": "false"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  })]), _vm._v(" "), _c('div', {
    staticClass: "dropdown-menu dropdown-menu-right"
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
  }, [_vm._v("9.823")]), _vm._v(" "), _c('p', [_vm._v("Members online")])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper px-3",
    staticStyle: {
      "height": "70px"
    }
  }, [_c('canvas', {
    staticClass: "chart",
    attrs: {
      "id": "card-chart4",
      "height": "70"
    }
  })])])])]), _vm._v(" "), _c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-block"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-5"
  }, [_c('h4', {
    staticClass: "card-title mb-0"
  }, [_vm._v("Traffic")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_vm._v("November 2015")])]), _vm._v(" "), _c('div', {
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
  }), _vm._v("Day\n                            ")]), _vm._v(" "), _c('label', {
    staticClass: "btn btn-outline-secondary active"
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "name": "options",
      "id": "option2",
      "checked": ""
    }
  }), _vm._v("Month\n                            ")]), _vm._v(" "), _c('label', {
    staticClass: "btn btn-outline-secondary"
  }, [_c('input', {
    attrs: {
      "type": "radio",
      "name": "options",
      "id": "option3"
    }
  }), _vm._v("Year\n                            ")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper",
    staticStyle: {
      "height": "300px",
      "margin-top": "40px"
    }
  }, [_c('canvas', {
    staticClass: "chart",
    attrs: {
      "id": "main-chart",
      "height": "300"
    }
  })])]), _vm._v(" "), _c('div', {
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
  })])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box facebook"
  }, [_c('i', {
    staticClass: "fa fa-facebook"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "social-box-chart-1",
      "height": "90"
    }
  })]), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("89k")]), _vm._v(" "), _c('span', [_vm._v("friends")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("459")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box twitter"
  }, [_c('i', {
    staticClass: "fa fa-twitter"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "social-box-chart-2",
      "height": "90"
    }
  })]), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("973k")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("1.792")]), _vm._v(" "), _c('span', [_vm._v("tweets")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box linkedin"
  }, [_c('i', {
    staticClass: "fa fa-linkedin"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "social-box-chart-3",
      "height": "90"
    }
  })]), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("500+")]), _vm._v(" "), _c('span', [_vm._v("contacts")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("292")]), _vm._v(" "), _c('span', [_vm._v("feeds")])])])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6 col-lg-3"
  }, [_c('div', {
    staticClass: "social-box google-plus"
  }, [_c('i', {
    staticClass: "fa fa-google-plus"
  }), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "social-box-chart-4",
      "height": "90"
    }
  })]), _vm._v(" "), _c('ul', [_c('li', [_c('strong', [_vm._v("894")]), _vm._v(" "), _c('span', [_vm._v("followers")])]), _vm._v(" "), _c('li', [_c('strong', [_vm._v("92")]), _vm._v(" "), _c('span', [_vm._v("circles")])])])])])]), _vm._v(" "), _c('div', {
    staticClass: "row"
  }, [_c('div', {
    staticClass: "col-md-12"
  }, [_c('div', {
    staticClass: "card"
  }, [_c('div', {
    staticClass: "card-header"
  }, [_vm._v("\n                    Traffic & Sales\n                ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("New Clients")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("9,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-1",
      "width": "100",
      "height": "30"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-danger"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Recuring Clients")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("22,643")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-2",
      "width": "100",
      "height": "30"
    }
  })])])])]), _vm._v(" "), _c('hr', {
    staticClass: "mt-0"
  }), _vm._v(" "), _c('ul', {
    staticClass: "horizontal-bars"
  }, [_c('li', [_c('div', {
    staticClass: "title"
  }, [_vm._v("\n                                        Monday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Tuesday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Wednesday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Thursday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Friday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Saturday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }, [_vm._v("\n                                        Sunday\n                                    ")]), _vm._v(" "), _c('div', {
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
  }), _vm._v(" "), _c('small', [_vm._v("New clients")]), _vm._v(" \n                                    "), _c('span', {
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
  }, [_vm._v("Pageviews")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("78,623")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-3",
      "width": "100",
      "height": "30"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-success"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Organic")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("49,123")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-4",
      "width": "100",
      "height": "30"
    }
  })])])])]), _vm._v(" "), _c('hr', {
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
  }, [_vm._v("\n                                        191,235\n                                        "), _c('span', {
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
  }, [_vm._v("\n                                        51,223\n                                        "), _c('span', {
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
  }, [_vm._v("\n                                        37,564\n                                        "), _c('span', {
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
  }, [_vm._v("\n                                        27,319\n                                        "), _c('span', {
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
  }, [_vm._v("CTR")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("23%")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-5",
      "width": "100",
      "height": "30"
    }
  })])])]), _vm._v(" "), _c('div', {
    staticClass: "col-sm-6"
  }, [_c('div', {
    staticClass: "callout callout-primary"
  }, [_c('small', {
    staticClass: "text-muted"
  }, [_vm._v("Bounce Rate")]), _vm._v(" "), _c('br'), _vm._v(" "), _c('strong', {
    staticClass: "h4"
  }, [_vm._v("5%")]), _vm._v(" "), _c('div', {
    staticClass: "chart-wrapper"
  }, [_c('canvas', {
    attrs: {
      "id": "sparkline-chart-6",
      "width": "100",
      "height": "30"
    }
  })])])])]), _vm._v(" "), _c('hr', {
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
    staticClass: "table table-responsive table-hover table-outline mb-0"
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
  }, [_c('span', [_vm._v("New")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  }, [_c('span', [_vm._v("Recurring")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  }, [_c('span', [_vm._v("New")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("En�as Kwadwo")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Agapetus Tade��")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  })])]), _vm._v(" "), _c('td', [_c('div', [_vm._v("Friderik D�vid")]), _vm._v(" "), _c('div', {
    staticClass: "small text-muted"
  }, [_c('span', [_vm._v("New")]), _vm._v("| Registered: Jan 1, 2015\n                                    ")])]), _vm._v(" "), _c('td', {
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
  }, [_vm._v("Last login")]), _vm._v(" "), _c('strong', [_vm._v("Yesterday")])])])])])])])])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-7e77a3e7", module.exports)
  }
}

/***/ }),
/* 62 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', [_c('h1', [_vm._v("Weather forecast")]), _vm._v(" "), _c('p', [_vm._v("This component demonstrates fetching data from the server.")]), _vm._v(" "), (_vm.forecasts.length) ? _c('table', {
    staticClass: "table"
  }, [_vm._m(0), _vm._v(" "), _c('tbody', _vm._l((_vm.forecasts), function(item) {
    return _c('tr', [_c('td', [_vm._v(_vm._s(item.dateFormatted))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(item.temperatureC))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(item.temperatureF))]), _vm._v(" "), _c('td', [_vm._v(_vm._s(item.summary))])])
  }))]) : _c('p', [_c('em', [_vm._v("Loading...")])])])
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('thead', [_c('tr', [_c('th', [_vm._v("Date")]), _vm._v(" "), _c('th', [_vm._v("Temp. (C)")]), _vm._v(" "), _c('th', [_vm._v("Temp. (F)")]), _vm._v(" "), _c('th', [_vm._v("Summary")])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-969460cc", module.exports)
  }
}

/***/ }),
/* 63 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "animated fadeIn"
  }, [_c('div', {
    staticClass: "row"
  }, [_c('simplert', {
    ref: "simplert",
    attrs: {
      "isUseRadius": "true",
      "isUseIcon": "true"
    }
  }), _vm._v(" "), _c('paging', {
    attrs: {
      "models": _vm.blogs,
      "title": _vm.title,
      "headers": _vm.headers,
      "getListUrl": _vm.getListUrl,
      "getDetailsUrl": _vm.getDetailsUrl,
      "saveUrl": _vm.saveUrl,
      "removeUrl": _vm.removeUrl,
      "createUrl": _vm.createUrl
    }
  })], 1)])
},staticRenderFns: []}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-9f96111e", module.exports)
  }
}

/***/ }),
/* 64 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('div', {
    staticClass: "app header-fixed sidebar-fixed aside-menu-fixed aside-menu-hidden"
  }, [_c('app-header'), _vm._v(" "), _c('div', {
    staticClass: "app-body"
  }, [_c('div', {
    staticClass: "sidebar"
  }, [_c('sidebar-component')], 1), _vm._v(" "), _c('main', {
    staticClass: "main"
  }, [_c('breadcrumb-component'), _vm._v(" "), _c('div', {
    staticClass: "container-fluid"
  }, [_c('router-view')], 1)], 1)]), _vm._v(" "), _c('footer', {
    staticClass: "app-footer"
  }, [_c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")]), _vm._v(" © 2017 creativeLabs.\n        "), _vm._m(0), _vm._v(" "), _c('vue-pages', {
    attrs: {
      "url": "#",
      "total": "100",
      "counts": "10",
      "current": "1",
      "fn": ""
    }
  })], 1)], 1)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('span', {
    staticClass: "float-right"
  }, [_vm._v("\n            Powered by "), _c('a', {
    attrs: {
      "href": "http://swastika.io"
    }
  }, [_vm._v("Swastika I/O")])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-d2426138", module.exports)
  }
}

/***/ }),
/* 65 */
/***/ (function(module, exports, __webpack_require__) {

module.exports={render:function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _vm._m(0)
},staticRenderFns: [function (){var _vm=this;var _h=_vm.$createElement;var _c=_vm._self._c||_h;
  return _c('ol', {
    staticClass: "breadcrumb"
  }, [_c('li', {
    staticClass: "breadcrumb-item"
  }, [_vm._v("Home")]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-item"
  }, [_c('a', {
    attrs: {
      "href": "#"
    }
  }, [_vm._v("Admin")])]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-item active"
  }, [_vm._v("Dashboard")]), _vm._v(" "), _c('li', {
    staticClass: "breadcrumb-menu d-md-down-none"
  }, [_c('div', {
    staticClass: "btn-group",
    attrs: {
      "role": "group",
      "aria-label": "Button group with nested dropdown"
    }
  }, [_c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-speech"
  })]), _vm._v(" "), _c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "./"
    }
  }, [_c('i', {
    staticClass: "icon-graph"
  }), _vm._v("  Dashboard")]), _vm._v(" "), _c('a', {
    staticClass: "btn btn-secondary",
    attrs: {
      "href": "#"
    }
  }, [_c('i', {
    staticClass: "icon-settings"
  }), _vm._v("  Settings")])])])])
}]}
module.exports.render._withStripped = true
if (false) {
  module.hot.accept()
  if (module.hot.data) {
     require("vue-hot-reload-api").rerender("data-v-f7a183ba", module.exports)
  }
}

/***/ }),
/* 66 */
/***/ (function(module, exports, __webpack_require__) {

!function(t,n){if(true)module.exports=n();else if("function"==typeof define&&define.amd)define([],n);else{var i=n();for(var e in i)("object"==typeof exports?exports:t)[e]=i[e]}}(this,function(){return function(t){function n(e){if(i[e])return i[e].exports;var r=i[e]={exports:{},id:e,loaded:!1};return t[e].call(r.exports,r,r.exports,n),r.loaded=!0,r.exports}var i={};return n.m=t,n.c=i,n.p="",n(0)}([function(t,n,i){var e,r;i(1),e=i(5);var a=i(6);r=e=e||{},"object"!=typeof e.default&&"function"!=typeof e.default||(r=e=e.default),"function"==typeof r&&(r=r.options),r.render=a.render,r.staticRenderFns=a.staticRenderFns,t.exports=e},function(t,n,i){var e=i(2);"string"==typeof e&&(e=[[t.id,e,""]]);i(4)(e,{});e.locals&&(t.exports=e.locals)},function(t,n,i){n=t.exports=i(3)(),n.push([t.id,".pagination{display:inline-block;padding-left:0;margin:20px 0;border-radius:4px}.pagination>li{display:inline}.pagination>li>a,.pagination>li>span{position:relative;float:left;padding:6px 12px;margin-left:-1px;line-height:1.42857143;color:#337ab7;text-decoration:none;background-color:#fff;border:1px solid #ddd}.pagination>li:first-child>a,.pagination>li:first-child>span{margin-left:0;border-top-left-radius:4px;border-bottom-left-radius:4px}.pagination>li:last-child>a,.pagination>li:last-child>span{border-top-right-radius:4px;border-bottom-right-radius:4px}.pagination>li>a:focus,.pagination>li>a:hover,.pagination>li>span:focus,.pagination>li>span:hover{z-index:2;color:#23527c;background-color:#eee;border-color:#ddd}.pagination>.active>a,.pagination>.active>a:focus,.pagination>.active>a:hover,.pagination>.active>span,.pagination>.active>span:focus,.pagination>.active>span:hover{z-index:3;color:#fff;cursor:default;background-color:#337ab7;border-color:#337ab7}.pagination>.disabled>a,.pagination>.disabled>a:focus,.pagination>.disabled>a:hover,.pagination>.disabled>span,.pagination>.disabled>span:focus,.pagination>.disabled>span:hover{color:#777;cursor:not-allowed;background-color:#fff;border-color:#ddd}.pagination-lg>li>a,.pagination-lg>li>span{padding:10px 16px;font-size:18px;line-height:1.3333333}.pagination-lg>li:first-child>a,.pagination-lg>li:first-child>span{border-top-left-radius:6px;border-bottom-left-radius:6px}.pagination-lg>li:last-child>a,.pagination-lg>li:last-child>span{border-top-right-radius:6px;border-bottom-right-radius:6px}.pagination-sm>li>a,.pagination-sm>li>span{padding:5px 10px;font-size:12px;line-height:1.5}.pagination-sm>li:first-child>a,.pagination-sm>li:first-child>span{border-top-left-radius:3px;border-bottom-left-radius:3px}.pagination-sm>li:last-child>a,.pagination-sm>li:last-child>span{border-top-right-radius:3px;border-bottom-right-radius:3px}",""])},function(t,n){t.exports=function(){var t=[];return t.toString=function(){for(var t=[],n=0;n<this.length;n++){var i=this[n];i[2]?t.push("@media "+i[2]+"{"+i[1]+"}"):t.push(i[1])}return t.join("")},t.i=function(n,i){"string"==typeof n&&(n=[[null,n,""]]);for(var e={},r=0;r<this.length;r++){var a=this[r][0];"number"==typeof a&&(e[a]=!0)}for(r=0;r<n.length;r++){var o=n[r];"number"==typeof o[0]&&e[o[0]]||(i&&!o[2]?o[2]=i:i&&(o[2]="("+o[2]+") and ("+i+")"),t.push(o))}},t}},function(t,n,i){function e(t,n){for(var i=0;i<t.length;i++){var e=t[i],r=d[e.id];if(r){r.refs++;for(var a=0;a<r.parts.length;a++)r.parts[a](e.parts[a]);for(;a<e.parts.length;a++)r.parts.push(l(e.parts[a],n))}else{for(var o=[],a=0;a<e.parts.length;a++)o.push(l(e.parts[a],n));d[e.id]={id:e.id,refs:1,parts:o}}}}function r(t){for(var n=[],i={},e=0;e<t.length;e++){var r=t[e],a=r[0],o=r[1],s=r[2],l=r[3],p={css:o,media:s,sourceMap:l};i[a]?i[a].parts.push(p):n.push(i[a]={id:a,parts:[p]})}return n}function a(t,n){var i=h(),e=b[b.length-1];if("top"===t.insertAt)e?e.nextSibling?i.insertBefore(n,e.nextSibling):i.appendChild(n):i.insertBefore(n,i.firstChild),b.push(n);else{if("bottom"!==t.insertAt)throw new Error("Invalid value for parameter 'insertAt'. Must be 'top' or 'bottom'.");i.appendChild(n)}}function o(t){t.parentNode.removeChild(t);var n=b.indexOf(t);n>=0&&b.splice(n,1)}function s(t){var n=document.createElement("style");return n.type="text/css",a(t,n),n}function l(t,n){var i,e,r;if(n.singleton){var a=v++;i=g||(g=s(n)),e=p.bind(null,i,a,!1),r=p.bind(null,i,a,!0)}else i=s(n),e=u.bind(null,i),r=function(){o(i)};return e(t),function(n){if(n){if(n.css===t.css&&n.media===t.media&&n.sourceMap===t.sourceMap)return;e(t=n)}else r()}}function p(t,n,i,e){var r=i?"":e.css;if(t.styleSheet)t.styleSheet.cssText=m(n,r);else{var a=document.createTextNode(r),o=t.childNodes;o[n]&&t.removeChild(o[n]),o.length?t.insertBefore(a,o[n]):t.appendChild(a)}}function u(t,n){var i=n.css,e=n.media,r=n.sourceMap;if(e&&t.setAttribute("media",e),r&&(i+="\n/*# sourceURL="+r.sources[0]+" */",i+="\n/*# sourceMappingURL=data:application/json;base64,"+btoa(unescape(encodeURIComponent(JSON.stringify(r))))+" */"),t.styleSheet)t.styleSheet.cssText=i;else{for(;t.firstChild;)t.removeChild(t.firstChild);t.appendChild(document.createTextNode(i))}}var d={},c=function(t){var n;return function(){return"undefined"==typeof n&&(n=t.apply(this,arguments)),n}},f=c(function(){return/msie [6-9]\b/.test(window.navigator.userAgent.toLowerCase())}),h=c(function(){return document.head||document.getElementsByTagName("head")[0]}),g=null,v=0,b=[];t.exports=function(t,n){n=n||{},"undefined"==typeof n.singleton&&(n.singleton=f()),"undefined"==typeof n.insertAt&&(n.insertAt="bottom");var i=r(t);return e(i,n),function(t){for(var a=[],o=0;o<i.length;o++){var s=i[o],l=d[s.id];l.refs--,a.push(l)}if(t){var p=r(t);e(p,n)}for(var o=0;o<a.length;o++){var l=a[o];if(0===l.refs){for(var u=0;u<l.parts.length;u++)l.parts[u]();delete d[l.id]}}}};var m=function(){var t=[];return function(n,i){return t[n]=i,t.filter(Boolean).join("\n")}}()},function(t,n){"use strict";Object.defineProperty(n,"__esModule",{value:!0}),n.default={name:"vue-pages",props:{url:{type:String,default:""},pageParam:{type:String,default:"p"},counts:{type:Number,default:10},total:{type:Number,default:1},current:{type:Number,default:1},fn:{type:Function}},computed:{c:function t(){var t=1;return t=this.current<1?1:this.current,t>this.total?this.total:t},start:function t(){var t=this.c-this.c%this.counts;return this.c%this.counts==0&&(t=this.c-this.counts),this.c>this.counts&&(t+=1),Math.max(1,t)},end:function t(){var t=this.start+this.counts-1;return this.c%this.counts==0&&(t=this.c),t=t>this.total?this.total:t,Math.min(t,this.total)},pageCounts:function(){for(var t=[],n=this.start;n<=this.end;n++)t.push(n);return t},prev:function(){return this.link(this.c)},next:function(){return this.link(this.c)}},methods:{link:function(t){if(this.url){var n=this.url.indexOf("?")>-1?"&":"?";return this.url+n+this.pageParam+"="+t}return""}}}},function(t,n){t.exports={render:function(){var t=this,n=t.$createElement;return n("div",{staticClass:"vue-pages"},[n("ul",{staticClass:"pagination"},[t.start>t.counts?n("li",[n("a",{attrs:{href:t.prev,"aria-label":"Previous"},on:{click:function(n){t.fn(t.current-1,n)}}},[n("span",{attrs:{"aria-hidden":"true"}},["«"])])]):t._e()," ",t._l(t.pageCounts,function(i){return t.pageCounts.length?n("li",{class:i==t.c?"active":""},[n("a",{attrs:{href:t.link(i)},domProps:{textContent:t._s(i)},on:{click:function(n){i==t.c?null:t.fn(i,n)}}})]):t._e()})," ",t.end!=t.total?n("li",[n("a",{attrs:{href:t.next,"aria-label":"Next"},on:{click:function(n){t.fn(t.current+1,n)}}},[n("span",{attrs:{"aria-hidden":"true"}},["»"])])]):t._e()])])},staticRenderFns:[]}}])});

/***/ }),
/* 67 */
/***/ (function(module, exports, __webpack_require__) {

(function webpackUniversalModuleDefinition(root, factory) {
	if(true)
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["VueStrap"] = factory();
	else
		root["VueStrap"] = factory();
})(this, function() {
return /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			exports: {},
/******/ 			id: moduleId,
/******/ 			loaded: false
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.loaded = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	var _Accordion = __webpack_require__(90);
	
	var _Accordion2 = _interopRequireDefault(_Accordion);
	
	var _Affix = __webpack_require__(94);
	
	var _Affix2 = _interopRequireDefault(_Affix);
	
	var _Alert = __webpack_require__(97);
	
	var _Alert2 = _interopRequireDefault(_Alert);
	
	var _Aside = __webpack_require__(104);
	
	var _Aside2 = _interopRequireDefault(_Aside);
	
	var _buttonGroup = __webpack_require__(109);
	
	var _buttonGroup2 = _interopRequireDefault(_buttonGroup);
	
	var _Carousel = __webpack_require__(112);
	
	var _Carousel2 = _interopRequireDefault(_Carousel);
	
	var _Checkbox = __webpack_require__(117);
	
	var _Checkbox2 = _interopRequireDefault(_Checkbox);
	
	var _Datepicker = __webpack_require__(122);
	
	var _Datepicker2 = _interopRequireDefault(_Datepicker);
	
	var _Dropdown = __webpack_require__(127);
	
	var _Dropdown2 = _interopRequireDefault(_Dropdown);
	
	var _FormGroup = __webpack_require__(132);
	
	var _FormGroup2 = _interopRequireDefault(_FormGroup);
	
	var _Input = __webpack_require__(135);
	
	var _Input2 = _interopRequireDefault(_Input);
	
	var _Modal = __webpack_require__(140);
	
	var _Modal2 = _interopRequireDefault(_Modal);
	
	var _Navbar = __webpack_require__(149);
	
	var _Navbar2 = _interopRequireDefault(_Navbar);
	
	var _Option = __webpack_require__(152);
	
	var _Option2 = _interopRequireDefault(_Option);
	
	var _Panel = __webpack_require__(155);
	
	var _Panel2 = _interopRequireDefault(_Panel);
	
	var _Popover = __webpack_require__(160);
	
	var _Popover2 = _interopRequireDefault(_Popover);
	
	var _Progressbar = __webpack_require__(166);
	
	var _Progressbar2 = _interopRequireDefault(_Progressbar);
	
	var _Radio = __webpack_require__(169);
	
	var _Radio2 = _interopRequireDefault(_Radio);
	
	var _Select = __webpack_require__(174);
	
	var _Select2 = _interopRequireDefault(_Select);
	
	var _Slider = __webpack_require__(194);
	
	var _Slider2 = _interopRequireDefault(_Slider);
	
	var _Spinner = __webpack_require__(197);
	
	var _Spinner2 = _interopRequireDefault(_Spinner);
	
	var _Tab = __webpack_require__(202);
	
	var _Tab2 = _interopRequireDefault(_Tab);
	
	var _TabGroup = __webpack_require__(205);
	
	var _TabGroup2 = _interopRequireDefault(_TabGroup);
	
	var _Tabset = __webpack_require__(210);
	
	var _Tabset2 = _interopRequireDefault(_Tabset);
	
	var _Tooltip = __webpack_require__(215);
	
	var _Tooltip2 = _interopRequireDefault(_Tooltip);
	
	var _Typeahead = __webpack_require__(220);
	
	var _Typeahead2 = _interopRequireDefault(_Typeahead);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	var VueStrap = {
	  $: _NodeList2.default,
	  accordion: _Accordion2.default,
	  affix: _Affix2.default,
	  alert: _Alert2.default,
	  aside: _Aside2.default,
	  buttonGroup: _buttonGroup2.default,
	  carousel: _Carousel2.default,
	  checkbox: _Checkbox2.default,
	  datepicker: _Datepicker2.default,
	  dropdown: _Dropdown2.default,
	  formGroup: _FormGroup2.default,
	  input: _Input2.default,
	  modal: _Modal2.default,
	  navbar: _Navbar2.default,
	  option: _Option2.default,
	  panel: _Panel2.default,
	  popover: _Popover2.default,
	  progressbar: _Progressbar2.default,
	  radio: _Radio2.default,
	  select: _Select2.default,
	  slider: _Slider2.default,
	  spinner: _Spinner2.default,
	  tab: _Tab2.default,
	  tabGroup: _TabGroup2.default,
	  tabset: _Tabset2.default,
	  tooltip: _Tooltip2.default,
	  typeahead: _Typeahead2.default
	};
	
	module.exports = VueStrap;

/***/ },
/* 1 */,
/* 2 */,
/* 3 */,
/* 4 */,
/* 5 */,
/* 6 */,
/* 7 */,
/* 8 */,
/* 9 */,
/* 10 */,
/* 11 */,
/* 12 */,
/* 13 */,
/* 14 */,
/* 15 */,
/* 16 */,
/* 17 */,
/* 18 */,
/* 19 */,
/* 20 */,
/* 21 */,
/* 22 */,
/* 23 */,
/* 24 */,
/* 25 */,
/* 26 */,
/* 27 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _defineProperty = __webpack_require__(28);
	
	var _defineProperty2 = _interopRequireDefault(_defineProperty);
	
	var _iterator = __webpack_require__(46);
	
	var _iterator2 = _interopRequireDefault(_iterator);
	
	var _getOwnPropertyNames = __webpack_require__(82);
	
	var _getOwnPropertyNames2 = _interopRequireDefault(_getOwnPropertyNames);
	
	var _classCallCheck2 = __webpack_require__(88);
	
	var _classCallCheck3 = _interopRequireDefault(_classCallCheck2);
	
	var _createClass2 = __webpack_require__(89);
	
	var _createClass3 = _interopRequireDefault(_createClass2);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	var ArrayProto = Array.prototype;
	var nodeError = new Error('Passed arguments must be of Node');
	var blurEvent = void 0;
	var blurList = [];
	var Events = [];
	
	function isNode(val) {
	  return val instanceof window.Node;
	}
	function isNodeList(val) {
	  return val instanceof window.NodeList || val instanceof NodeList || val instanceof window.HTMLCollection || val instanceof Array;
	}
	
	function splitWords(val) {
	  val = val.trim();return val.length ? val.replace(/\s+/, ' ').split(' ') : [];
	}
	function joinWords(val) {
	  return val.length ? val.join(' ') : '';
	}
	
	var NodeList = function () {
	  function NodeList(args) {
	    (0, _classCallCheck3.default)(this, NodeList);
	
	    var nodes = args;
	    if (args[0] === window) {
	      nodes = [window];
	    } else if (typeof args[0] === 'string') {
	      nodes = (args[1] || document).querySelectorAll(args[0]);
	      if (args[1]) {
	        this.owner = args[1];
	      }
	    } else if (0 in args && !isNode(args[0]) && args[0] && 'length' in args[0]) {
	      nodes = args[0];
	      if (args[1]) {
	        this.owner = args[1];
	      }
	    }
	    if (nodes) {
	      for (var i in nodes) {
	        this[i] = nodes[i];
	      }
	      this.length = nodes.length;
	    } else {
	      this.length = 0;
	    }
	  }
	
	  (0, _createClass3.default)(NodeList, [{
	    key: 'concat',
	    value: function concat() {
	      var nodes = ArrayProto.slice.call(this);
	      function flatten(arr) {
	        ArrayProto.forEach.call(arr, function (el) {
	          if (isNode(el)) {
	            if (!~nodes.indexOf(el)) nodes.push(el);
	          } else if (isNodeList(el)) {
	            flatten(el);
	          }
	        });
	      }
	
	      for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
	        args[_key] = arguments[_key];
	      }
	
	      ArrayProto.forEach.call(args, function (arg) {
	        if (isNode(arg)) {
	          if (!~nodes.indexOf(arg)) nodes.push(arg);
	        } else if (isNodeList(arg)) {
	          flatten(arg);
	        } else {
	          throw Error('Concat arguments must be of a Node, NodeList, HTMLCollection, or Array of (Node, NodeList, HTMLCollection, Array)');
	        }
	      });
	      return NodeListJS(nodes, this);
	    }
	  }, {
	    key: 'delete',
	    value: function _delete() {
	      var notRemoved = flatten(this).filter(function (el) {
	        if (el.remove) {
	          el.remove();
	        } else if (el.parentNode) {
	          el.parentNode.removeChild(el);
	        }
	        return document.body.contains(el);
	      });
	      if (notRemoved.length) console.warn('NodeList: Some nodes could not be deleted.');
	      return notRemoved;
	    }
	  }, {
	    key: 'each',
	    value: function each() {
	      for (var _len2 = arguments.length, args = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
	        args[_key2] = arguments[_key2];
	      }
	
	      ArrayProto.forEach.apply(this, args);
	      return this;
	    }
	  }, {
	    key: 'filter',
	    value: function filter() {
	      for (var _len3 = arguments.length, args = Array(_len3), _key3 = 0; _key3 < _len3; _key3++) {
	        args[_key3] = arguments[_key3];
	      }
	
	      return NodeListJS(ArrayProto.filter.apply(this, args), this);
	    }
	  }, {
	    key: 'find',
	    value: function find(element) {
	      var nodes = [];
	      flatten(this).forEach(function (node) {
	        ArrayProto.push.apply(nodes, node.querySelectorAll(element));
	      });
	      return flatten(nodes, this.owner);
	    }
	  }, {
	    key: 'findChildren',
	    value: function findChildren(element) {
	      var _this = this;
	
	      if (element) return this.find(element).filter(function (el) {
	        return _this.includes(el.parentElement);
	      });
	      return flatten(this.map(function (el) {
	        return el.children;
	      }));
	    }
	  }, {
	    key: 'forEach',
	    value: function forEach() {
	      for (var _len4 = arguments.length, args = Array(_len4), _key4 = 0; _key4 < _len4; _key4++) {
	        args[_key4] = arguments[_key4];
	      }
	
	      ArrayProto.forEach.apply(this, args);
	      return this;
	    }
	  }, {
	    key: 'includes',
	    value: function includes(element, index) {
	      return ~this.indexOf(element, index);
	    }
	  }, {
	    key: 'map',
	    value: function map() {
	      for (var _len5 = arguments.length, args = Array(_len5), _key5 = 0; _key5 < _len5; _key5++) {
	        args[_key5] = arguments[_key5];
	      }
	
	      var mapped = ArrayProto.map.apply(this, args);
	      return mapped.some(function (el) {
	        return isNode(el) || isNodeList(el);
	      }) ? flatten(mapped, this) : mapped;
	    }
	  }, {
	    key: 'parent',
	    value: function parent() {
	      return flatten(this.map(function (el) {
	        return el.parentNode;
	      }), this);
	    }
	  }, {
	    key: 'pop',
	    value: function pop(amount) {
	      if (typeof amount !== 'number') {
	        amount = 1;
	      }
	      var nodes = [];
	      var pop = ArrayProto.pop.bind(this);
	      while (amount--) {
	        nodes.push(pop());
	      }return NodeListJS(nodes, this);
	    }
	  }, {
	    key: 'push',
	    value: function push() {
	      var _this2 = this;
	
	      for (var _len6 = arguments.length, args = Array(_len6), _key6 = 0; _key6 < _len6; _key6++) {
	        args[_key6] = arguments[_key6];
	      }
	
	      ArrayProto.forEach.call(args, function (arg) {
	        if (!isNode(arg)) throw nodeError;
	        if (!~_this2.indexOf(arg)) ArrayProto.push.call(_this2, arg);
	      });
	      return this;
	    }
	  }, {
	    key: 'shift',
	    value: function shift(amount) {
	      if (typeof amount !== 'number') {
	        amount = 1;
	      }
	      var nodes = [];
	      while (amount--) {
	        nodes.push(ArrayProto.shift.call(this));
	      }return nodes.length == 1 ? nodes[0] : NodeListJS(nodes, this);
	    }
	  }, {
	    key: 'slice',
	    value: function slice() {
	      for (var _len7 = arguments.length, args = Array(_len7), _key7 = 0; _key7 < _len7; _key7++) {
	        args[_key7] = arguments[_key7];
	      }
	
	      return NodeListJS(ArrayProto.slice.apply(this, args), this);
	    }
	  }, {
	    key: 'splice',
	    value: function splice() {
	      for (var _len8 = arguments.length, args = Array(_len8), _key8 = 0; _key8 < _len8; _key8++) {
	        args[_key8] = arguments[_key8];
	      }
	
	      for (var i = 2, l = args.length; i < l; i++) {
	        if (!isNode(args[i])) throw nodeError;
	      }
	      ArrayProto.splice.apply(this, args);
	      return this;
	    }
	  }, {
	    key: 'unshift',
	    value: function unshift() {
	      var _this3 = this;
	
	      var unshift = ArrayProto.unshift.bind(this);
	
	      for (var _len9 = arguments.length, args = Array(_len9), _key9 = 0; _key9 < _len9; _key9++) {
	        args[_key9] = arguments[_key9];
	      }
	
	      ArrayProto.forEach.call(args, function (arg) {
	        if (!isNode(arg)) throw nodeError;
	        if (!~_this3.indexOf(arg)) unshift(arg);
	      });
	      return this;
	    }
	  }, {
	    key: 'addClass',
	    value: function addClass(classes) {
	      return this.toggleClass(classes, true);
	    }
	  }, {
	    key: 'removeClass',
	    value: function removeClass(classes) {
	      return this.toggleClass(classes, false);
	    }
	  }, {
	    key: 'toggleClass',
	    value: function toggleClass(classes, value) {
	      var method = value === undefined || value === null ? 'toggle' : value ? 'add' : 'remove';
	      if (typeof classes === 'string') {
	        classes = splitWords(classes);
	      }
	      this.each(function (el) {
	        var list = splitWords(el.className);
	        classes.forEach(function (c) {
	          var hasClass = ~list.indexOf(c);
	          if (!hasClass && method !== 'remove') list.push(c);
	          if (hasClass && method !== 'add') {
	            list = list.filter(function (el) {
	              return el !== c;
	            });
	          }
	        });
	        list = joinWords(list);
	        if (!list) el.removeAttribute('class');else el.className = list;
	      });
	      return this;
	    }
	  }, {
	    key: 'get',
	    value: function get(prop) {
	      var arr = [];
	      this.each(function (el) {
	        if (el !== null) {
	          el = el[prop];
	        }
	        arr.push(el);
	      });
	      return flatten(arr, this);
	    }
	  }, {
	    key: 'set',
	    value: function set(prop, value) {
	      if (prop.constructor === Object) {
	        this.each(function (el) {
	          if (el) {
	            for (var key in prop) {
	              if (key in el) {
	                el[key] = prop[key];
	              }
	            }
	          }
	        });
	      } else {
	        this.each(function (el) {
	          if (prop in el) {
	            el[prop] = value;
	          }
	        });
	      }
	      return this;
	    }
	  }, {
	    key: 'call',
	    value: function call() {
	      for (var _len10 = arguments.length, args = Array(_len10), _key10 = 0; _key10 < _len10; _key10++) {
	        args[_key10] = arguments[_key10];
	      }
	
	      var method = ArrayProto.shift.call(args);
	      var arr = [];
	      var returnThis = true;
	      this.each(function (el) {
	        if (el && el[method] instanceof Function) {
	          el = el[method].apply(el, args);
	          arr.push(el);
	          if (returnThis && el !== undefined) {
	            returnThis = false;
	          }
	        } else {
	          arr.push(undefined);
	        }
	      });
	      return returnThis ? this : flatten(arr, this);
	    }
	  }, {
	    key: 'item',
	    value: function item(index) {
	      return NodeListJS([this[index]], this);
	    }
	  }, {
	    key: 'on',
	
	
	    // event handlers
	    value: function on(events, selector, callback) {
	      if (typeof events === 'string') {
	        events = splitWords(events);
	      }
	      if (!this || !this.length) return this;
	      if (callback === undefined) {
	        callback = selector;
	        selector = null;
	      }
	      if (!callback) return this;
	      var fn = callback;
	      callback = selector ? function (e) {
	        var els = NodeListJS(selector, this);
	        if (!els.length) {
	          return;
	        }
	        els.some(function (el) {
	          var target = el.contains(e.target);
	          if (target) fn.call(el, e, el);
	          return target;
	        });
	      } : function (e) {
	        fn.apply(this, [e, this]);
	      };
	      this.each(function (el) {
	        events.forEach(function (event) {
	          if (el === window || isNode(el)) {
	            el.addEventListener(event, callback, false);
	            Events.push({
	              el: el,
	              event: event,
	              callback: callback
	            });
	          }
	        });
	      });
	      return this;
	    }
	  }, {
	    key: 'off',
	    value: function off(events, callback) {
	      if (events instanceof Function) {
	        callback = events;
	        events = null;
	      }
	      events = events instanceof Array ? events : typeof events === 'string' ? splitWords(events) : null;
	      this.each(function (el) {
	        Events = Events.filter(function (e) {
	          if (e && e.el === el && (!callback || callback === e.callback) && (!events || ~events.indexOf(e.event))) {
	            e.el.removeEventListener(e.event, e.callback);
	            return false;
	          }
	          return true;
	        });
	      });
	      return this;
	    }
	  }, {
	    key: 'onBlur',
	    value: function onBlur(callback) {
	      if (!this || !this.length) return this;
	      if (!callback) return this;
	      this.each(function (el) {
	        blurList.push({ el: el, callback: callback });
	      });
	      if (!blurEvent) {
	        blurEvent = function blurEvent(e) {
	          blurList.forEach(function (item) {
	            var target = item.el.contains(e.target) || item.el === e.target;
	            if (!target) item.callback.call(item.el, e, item.el);
	          });
	        };
	        document.addEventListener('click', blurEvent, false);
	        document.addEventListener('touchstart', blurEvent, false);
	      }
	      return this;
	    }
	  }, {
	    key: 'offBlur',
	    value: function offBlur(callback) {
	      this.each(function (el) {
	        blurList = blurList.filter(function (blur) {
	          if (blur && blur.el === el && (!callback || blur.callback === callback)) {
	            return false;
	          }
	          return el;
	        });
	      });
	      return this;
	    }
	  }, {
	    key: 'asArray',
	    get: function get() {
	      return ArrayProto.slice.call(this);
	    }
	  }]);
	  return NodeList;
	}();
	
	var NL = NodeList.prototype;
	
	function flatten(arr, owner) {
	  var list = [];
	  ArrayProto.forEach.call(arr, function (el) {
	    if (isNode(el)) {
	      if (!~list.indexOf(el)) list.push(el);
	    } else if (isNodeList(el)) {
	      for (var id in el) {
	        list.push(el[id]);
	      }
	    } else if (el !== null) {
	      arr.get = NL.get;
	      arr.set = NL.set;
	      arr.call = NL.call;
	      arr.owner = owner;
	      return arr;
	    }
	  });
	  return NodeListJS(list, owner);
	}
	
	(0, _getOwnPropertyNames2.default)(ArrayProto).forEach(function (key) {
	  if (key !== 'join' && key !== 'copyWithin' && key !== 'fill' && NL[key] === undefined) {
	    NL[key] = ArrayProto[key];
	  }
	});
	if (window.Symbol && _iterator2.default) {
	  NL[_iterator2.default] = NL.values = ArrayProto[_iterator2.default];
	}
	var div = document.createElement('div');
	function setterGetter(prop) {
	  var _this4 = this;
	
	  if (NL[prop]) return;
	  if (div[prop] instanceof Function) {
	    NL[prop] = function () {
	      for (var _len11 = arguments.length, args = Array(_len11), _key11 = 0; _key11 < _len11; _key11++) {
	        args[_key11] = arguments[_key11];
	      }
	
	      var arr = [];
	      var returnThis = true;
	      for (var i in NL) {
	        var el = NL[i];
	        if (el && el[prop] instanceof Function) {
	          el = el[prop].apply(el, args);
	          arr.push(el);
	          if (returnThis && el !== undefined) {
	            returnThis = false;
	          }
	        } else {
	          arr.push(undefined);
	        }
	      }
	      return returnThis ? _this4 : flatten(arr, _this4);
	    };
	  } else {
	    (0, _defineProperty2.default)(NL, prop, {
	      get: function get() {
	        var arr = [];
	        this.each(function (el) {
	          if (el !== null) {
	            el = el[prop];
	          }
	          arr.push(el);
	        });
	        return flatten(arr, this);
	      },
	      set: function set(value) {
	        this.each(function (el) {
	          if (el && prop in el) {
	            el[prop] = value;
	          }
	        });
	      }
	    });
	  }
	}
	for (var prop in div) {
	  setterGetter(prop);
	}function NodeListJS() {
	  for (var _len12 = arguments.length, args = Array(_len12), _key12 = 0; _key12 < _len12; _key12++) {
	    args[_key12] = arguments[_key12];
	  }
	
	  return new NodeList(args);
	}
	window.NL = NodeListJS;
	
	exports.default = NodeListJS;

/***/ },
/* 28 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = { "default": __webpack_require__(29), __esModule: true };

/***/ },
/* 29 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(30);
	var $Object = __webpack_require__(33).Object;
	module.exports = function defineProperty(it, key, desc){
	  return $Object.defineProperty(it, key, desc);
	};

/***/ },
/* 30 */
/***/ function(module, exports, __webpack_require__) {

	var $export = __webpack_require__(31);
	// 19.1.2.4 / 15.2.3.6 Object.defineProperty(O, P, Attributes)
	$export($export.S + $export.F * !__webpack_require__(41), 'Object', {defineProperty: __webpack_require__(37).f});

/***/ },
/* 31 */
/***/ function(module, exports, __webpack_require__) {

	var global    = __webpack_require__(32)
	  , core      = __webpack_require__(33)
	  , ctx       = __webpack_require__(34)
	  , hide      = __webpack_require__(36)
	  , PROTOTYPE = 'prototype';
	
	var $export = function(type, name, source){
	  var IS_FORCED = type & $export.F
	    , IS_GLOBAL = type & $export.G
	    , IS_STATIC = type & $export.S
	    , IS_PROTO  = type & $export.P
	    , IS_BIND   = type & $export.B
	    , IS_WRAP   = type & $export.W
	    , exports   = IS_GLOBAL ? core : core[name] || (core[name] = {})
	    , expProto  = exports[PROTOTYPE]
	    , target    = IS_GLOBAL ? global : IS_STATIC ? global[name] : (global[name] || {})[PROTOTYPE]
	    , key, own, out;
	  if(IS_GLOBAL)source = name;
	  for(key in source){
	    // contains in native
	    own = !IS_FORCED && target && target[key] !== undefined;
	    if(own && key in exports)continue;
	    // export native or passed
	    out = own ? target[key] : source[key];
	    // prevent global pollution for namespaces
	    exports[key] = IS_GLOBAL && typeof target[key] != 'function' ? source[key]
	    // bind timers to global for call from export context
	    : IS_BIND && own ? ctx(out, global)
	    // wrap global constructors for prevent change them in library
	    : IS_WRAP && target[key] == out ? (function(C){
	      var F = function(a, b, c){
	        if(this instanceof C){
	          switch(arguments.length){
	            case 0: return new C;
	            case 1: return new C(a);
	            case 2: return new C(a, b);
	          } return new C(a, b, c);
	        } return C.apply(this, arguments);
	      };
	      F[PROTOTYPE] = C[PROTOTYPE];
	      return F;
	    // make static versions for prototype methods
	    })(out) : IS_PROTO && typeof out == 'function' ? ctx(Function.call, out) : out;
	    // export proto methods to core.%CONSTRUCTOR%.methods.%NAME%
	    if(IS_PROTO){
	      (exports.virtual || (exports.virtual = {}))[key] = out;
	      // export proto methods to core.%CONSTRUCTOR%.prototype.%NAME%
	      if(type & $export.R && expProto && !expProto[key])hide(expProto, key, out);
	    }
	  }
	};
	// type bitmap
	$export.F = 1;   // forced
	$export.G = 2;   // global
	$export.S = 4;   // static
	$export.P = 8;   // proto
	$export.B = 16;  // bind
	$export.W = 32;  // wrap
	$export.U = 64;  // safe
	$export.R = 128; // real proto method for `library` 
	module.exports = $export;

/***/ },
/* 32 */
/***/ function(module, exports) {

	// https://github.com/zloirock/core-js/issues/86#issuecomment-115759028
	var global = module.exports = typeof window != 'undefined' && window.Math == Math
	  ? window : typeof self != 'undefined' && self.Math == Math ? self : Function('return this')();
	if(typeof __g == 'number')__g = global; // eslint-disable-line no-undef

/***/ },
/* 33 */
/***/ function(module, exports) {

	var core = module.exports = {version: '2.4.0'};
	if(typeof __e == 'number')__e = core; // eslint-disable-line no-undef

/***/ },
/* 34 */
/***/ function(module, exports, __webpack_require__) {

	// optional / simple context binding
	var aFunction = __webpack_require__(35);
	module.exports = function(fn, that, length){
	  aFunction(fn);
	  if(that === undefined)return fn;
	  switch(length){
	    case 1: return function(a){
	      return fn.call(that, a);
	    };
	    case 2: return function(a, b){
	      return fn.call(that, a, b);
	    };
	    case 3: return function(a, b, c){
	      return fn.call(that, a, b, c);
	    };
	  }
	  return function(/* ...args */){
	    return fn.apply(that, arguments);
	  };
	};

/***/ },
/* 35 */
/***/ function(module, exports) {

	module.exports = function(it){
	  if(typeof it != 'function')throw TypeError(it + ' is not a function!');
	  return it;
	};

/***/ },
/* 36 */
/***/ function(module, exports, __webpack_require__) {

	var dP         = __webpack_require__(37)
	  , createDesc = __webpack_require__(45);
	module.exports = __webpack_require__(41) ? function(object, key, value){
	  return dP.f(object, key, createDesc(1, value));
	} : function(object, key, value){
	  object[key] = value;
	  return object;
	};

/***/ },
/* 37 */
/***/ function(module, exports, __webpack_require__) {

	var anObject       = __webpack_require__(38)
	  , IE8_DOM_DEFINE = __webpack_require__(40)
	  , toPrimitive    = __webpack_require__(44)
	  , dP             = Object.defineProperty;
	
	exports.f = __webpack_require__(41) ? Object.defineProperty : function defineProperty(O, P, Attributes){
	  anObject(O);
	  P = toPrimitive(P, true);
	  anObject(Attributes);
	  if(IE8_DOM_DEFINE)try {
	    return dP(O, P, Attributes);
	  } catch(e){ /* empty */ }
	  if('get' in Attributes || 'set' in Attributes)throw TypeError('Accessors not supported!');
	  if('value' in Attributes)O[P] = Attributes.value;
	  return O;
	};

/***/ },
/* 38 */
/***/ function(module, exports, __webpack_require__) {

	var isObject = __webpack_require__(39);
	module.exports = function(it){
	  if(!isObject(it))throw TypeError(it + ' is not an object!');
	  return it;
	};

/***/ },
/* 39 */
/***/ function(module, exports) {

	module.exports = function(it){
	  return typeof it === 'object' ? it !== null : typeof it === 'function';
	};

/***/ },
/* 40 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = !__webpack_require__(41) && !__webpack_require__(42)(function(){
	  return Object.defineProperty(__webpack_require__(43)('div'), 'a', {get: function(){ return 7; }}).a != 7;
	});

/***/ },
/* 41 */
/***/ function(module, exports, __webpack_require__) {

	// Thank's IE8 for his funny defineProperty
	module.exports = !__webpack_require__(42)(function(){
	  return Object.defineProperty({}, 'a', {get: function(){ return 7; }}).a != 7;
	});

/***/ },
/* 42 */
/***/ function(module, exports) {

	module.exports = function(exec){
	  try {
	    return !!exec();
	  } catch(e){
	    return true;
	  }
	};

/***/ },
/* 43 */
/***/ function(module, exports, __webpack_require__) {

	var isObject = __webpack_require__(39)
	  , document = __webpack_require__(32).document
	  // in old IE typeof document.createElement is 'object'
	  , is = isObject(document) && isObject(document.createElement);
	module.exports = function(it){
	  return is ? document.createElement(it) : {};
	};

/***/ },
/* 44 */
/***/ function(module, exports, __webpack_require__) {

	// 7.1.1 ToPrimitive(input [, PreferredType])
	var isObject = __webpack_require__(39);
	// instead of the ES6 spec version, we didn't implement @@toPrimitive case
	// and the second argument - flag - preferred type is a string
	module.exports = function(it, S){
	  if(!isObject(it))return it;
	  var fn, val;
	  if(S && typeof (fn = it.toString) == 'function' && !isObject(val = fn.call(it)))return val;
	  if(typeof (fn = it.valueOf) == 'function' && !isObject(val = fn.call(it)))return val;
	  if(!S && typeof (fn = it.toString) == 'function' && !isObject(val = fn.call(it)))return val;
	  throw TypeError("Can't convert object to primitive value");
	};

/***/ },
/* 45 */
/***/ function(module, exports) {

	module.exports = function(bitmap, value){
	  return {
	    enumerable  : !(bitmap & 1),
	    configurable: !(bitmap & 2),
	    writable    : !(bitmap & 4),
	    value       : value
	  };
	};

/***/ },
/* 46 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = { "default": __webpack_require__(47), __esModule: true };

/***/ },
/* 47 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(48);
	__webpack_require__(77);
	module.exports = __webpack_require__(81).f('iterator');

/***/ },
/* 48 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	var $at  = __webpack_require__(49)(true);
	
	// 21.1.3.27 String.prototype[@@iterator]()
	__webpack_require__(52)(String, 'String', function(iterated){
	  this._t = String(iterated); // target
	  this._i = 0;                // next index
	// 21.1.5.2.1 %StringIteratorPrototype%.next()
	}, function(){
	  var O     = this._t
	    , index = this._i
	    , point;
	  if(index >= O.length)return {value: undefined, done: true};
	  point = $at(O, index);
	  this._i += point.length;
	  return {value: point, done: false};
	});

/***/ },
/* 49 */
/***/ function(module, exports, __webpack_require__) {

	var toInteger = __webpack_require__(50)
	  , defined   = __webpack_require__(51);
	// true  -> String#at
	// false -> String#codePointAt
	module.exports = function(TO_STRING){
	  return function(that, pos){
	    var s = String(defined(that))
	      , i = toInteger(pos)
	      , l = s.length
	      , a, b;
	    if(i < 0 || i >= l)return TO_STRING ? '' : undefined;
	    a = s.charCodeAt(i);
	    return a < 0xd800 || a > 0xdbff || i + 1 === l || (b = s.charCodeAt(i + 1)) < 0xdc00 || b > 0xdfff
	      ? TO_STRING ? s.charAt(i) : a
	      : TO_STRING ? s.slice(i, i + 2) : (a - 0xd800 << 10) + (b - 0xdc00) + 0x10000;
	  };
	};

/***/ },
/* 50 */
/***/ function(module, exports) {

	// 7.1.4 ToInteger
	var ceil  = Math.ceil
	  , floor = Math.floor;
	module.exports = function(it){
	  return isNaN(it = +it) ? 0 : (it > 0 ? floor : ceil)(it);
	};

/***/ },
/* 51 */
/***/ function(module, exports) {

	// 7.2.1 RequireObjectCoercible(argument)
	module.exports = function(it){
	  if(it == undefined)throw TypeError("Can't call method on  " + it);
	  return it;
	};

/***/ },
/* 52 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	var LIBRARY        = __webpack_require__(53)
	  , $export        = __webpack_require__(31)
	  , redefine       = __webpack_require__(54)
	  , hide           = __webpack_require__(36)
	  , has            = __webpack_require__(55)
	  , Iterators      = __webpack_require__(56)
	  , $iterCreate    = __webpack_require__(57)
	  , setToStringTag = __webpack_require__(73)
	  , getPrototypeOf = __webpack_require__(75)
	  , ITERATOR       = __webpack_require__(74)('iterator')
	  , BUGGY          = !([].keys && 'next' in [].keys()) // Safari has buggy iterators w/o `next`
	  , FF_ITERATOR    = '@@iterator'
	  , KEYS           = 'keys'
	  , VALUES         = 'values';
	
	var returnThis = function(){ return this; };
	
	module.exports = function(Base, NAME, Constructor, next, DEFAULT, IS_SET, FORCED){
	  $iterCreate(Constructor, NAME, next);
	  var getMethod = function(kind){
	    if(!BUGGY && kind in proto)return proto[kind];
	    switch(kind){
	      case KEYS: return function keys(){ return new Constructor(this, kind); };
	      case VALUES: return function values(){ return new Constructor(this, kind); };
	    } return function entries(){ return new Constructor(this, kind); };
	  };
	  var TAG        = NAME + ' Iterator'
	    , DEF_VALUES = DEFAULT == VALUES
	    , VALUES_BUG = false
	    , proto      = Base.prototype
	    , $native    = proto[ITERATOR] || proto[FF_ITERATOR] || DEFAULT && proto[DEFAULT]
	    , $default   = $native || getMethod(DEFAULT)
	    , $entries   = DEFAULT ? !DEF_VALUES ? $default : getMethod('entries') : undefined
	    , $anyNative = NAME == 'Array' ? proto.entries || $native : $native
	    , methods, key, IteratorPrototype;
	  // Fix native
	  if($anyNative){
	    IteratorPrototype = getPrototypeOf($anyNative.call(new Base));
	    if(IteratorPrototype !== Object.prototype){
	      // Set @@toStringTag to native iterators
	      setToStringTag(IteratorPrototype, TAG, true);
	      // fix for some old engines
	      if(!LIBRARY && !has(IteratorPrototype, ITERATOR))hide(IteratorPrototype, ITERATOR, returnThis);
	    }
	  }
	  // fix Array#{values, @@iterator}.name in V8 / FF
	  if(DEF_VALUES && $native && $native.name !== VALUES){
	    VALUES_BUG = true;
	    $default = function values(){ return $native.call(this); };
	  }
	  // Define iterator
	  if((!LIBRARY || FORCED) && (BUGGY || VALUES_BUG || !proto[ITERATOR])){
	    hide(proto, ITERATOR, $default);
	  }
	  // Plug for library
	  Iterators[NAME] = $default;
	  Iterators[TAG]  = returnThis;
	  if(DEFAULT){
	    methods = {
	      values:  DEF_VALUES ? $default : getMethod(VALUES),
	      keys:    IS_SET     ? $default : getMethod(KEYS),
	      entries: $entries
	    };
	    if(FORCED)for(key in methods){
	      if(!(key in proto))redefine(proto, key, methods[key]);
	    } else $export($export.P + $export.F * (BUGGY || VALUES_BUG), NAME, methods);
	  }
	  return methods;
	};

/***/ },
/* 53 */
/***/ function(module, exports) {

	module.exports = true;

/***/ },
/* 54 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(36);

/***/ },
/* 55 */
/***/ function(module, exports) {

	var hasOwnProperty = {}.hasOwnProperty;
	module.exports = function(it, key){
	  return hasOwnProperty.call(it, key);
	};

/***/ },
/* 56 */
/***/ function(module, exports) {

	module.exports = {};

/***/ },
/* 57 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	var create         = __webpack_require__(58)
	  , descriptor     = __webpack_require__(45)
	  , setToStringTag = __webpack_require__(73)
	  , IteratorPrototype = {};
	
	// 25.1.2.1.1 %IteratorPrototype%[@@iterator]()
	__webpack_require__(36)(IteratorPrototype, __webpack_require__(74)('iterator'), function(){ return this; });
	
	module.exports = function(Constructor, NAME, next){
	  Constructor.prototype = create(IteratorPrototype, {next: descriptor(1, next)});
	  setToStringTag(Constructor, NAME + ' Iterator');
	};

/***/ },
/* 58 */
/***/ function(module, exports, __webpack_require__) {

	// 19.1.2.2 / 15.2.3.5 Object.create(O [, Properties])
	var anObject    = __webpack_require__(38)
	  , dPs         = __webpack_require__(59)
	  , enumBugKeys = __webpack_require__(71)
	  , IE_PROTO    = __webpack_require__(68)('IE_PROTO')
	  , Empty       = function(){ /* empty */ }
	  , PROTOTYPE   = 'prototype';
	
	// Create object with fake `null` prototype: use iframe Object with cleared prototype
	var createDict = function(){
	  // Thrash, waste and sodomy: IE GC bug
	  var iframe = __webpack_require__(43)('iframe')
	    , i      = enumBugKeys.length
	    , lt     = '<'
	    , gt     = '>'
	    , iframeDocument;
	  iframe.style.display = 'none';
	  __webpack_require__(72).appendChild(iframe);
	  iframe.src = 'javascript:'; // eslint-disable-line no-script-url
	  // createDict = iframe.contentWindow.Object;
	  // html.removeChild(iframe);
	  iframeDocument = iframe.contentWindow.document;
	  iframeDocument.open();
	  iframeDocument.write(lt + 'script' + gt + 'document.F=Object' + lt + '/script' + gt);
	  iframeDocument.close();
	  createDict = iframeDocument.F;
	  while(i--)delete createDict[PROTOTYPE][enumBugKeys[i]];
	  return createDict();
	};
	
	module.exports = Object.create || function create(O, Properties){
	  var result;
	  if(O !== null){
	    Empty[PROTOTYPE] = anObject(O);
	    result = new Empty;
	    Empty[PROTOTYPE] = null;
	    // add "__proto__" for Object.getPrototypeOf polyfill
	    result[IE_PROTO] = O;
	  } else result = createDict();
	  return Properties === undefined ? result : dPs(result, Properties);
	};


/***/ },
/* 59 */
/***/ function(module, exports, __webpack_require__) {

	var dP       = __webpack_require__(37)
	  , anObject = __webpack_require__(38)
	  , getKeys  = __webpack_require__(60);
	
	module.exports = __webpack_require__(41) ? Object.defineProperties : function defineProperties(O, Properties){
	  anObject(O);
	  var keys   = getKeys(Properties)
	    , length = keys.length
	    , i = 0
	    , P;
	  while(length > i)dP.f(O, P = keys[i++], Properties[P]);
	  return O;
	};

/***/ },
/* 60 */
/***/ function(module, exports, __webpack_require__) {

	// 19.1.2.14 / 15.2.3.14 Object.keys(O)
	var $keys       = __webpack_require__(61)
	  , enumBugKeys = __webpack_require__(71);
	
	module.exports = Object.keys || function keys(O){
	  return $keys(O, enumBugKeys);
	};

/***/ },
/* 61 */
/***/ function(module, exports, __webpack_require__) {

	var has          = __webpack_require__(55)
	  , toIObject    = __webpack_require__(62)
	  , arrayIndexOf = __webpack_require__(65)(false)
	  , IE_PROTO     = __webpack_require__(68)('IE_PROTO');
	
	module.exports = function(object, names){
	  var O      = toIObject(object)
	    , i      = 0
	    , result = []
	    , key;
	  for(key in O)if(key != IE_PROTO)has(O, key) && result.push(key);
	  // Don't enum bug & hidden keys
	  while(names.length > i)if(has(O, key = names[i++])){
	    ~arrayIndexOf(result, key) || result.push(key);
	  }
	  return result;
	};

/***/ },
/* 62 */
/***/ function(module, exports, __webpack_require__) {

	// to indexed object, toObject with fallback for non-array-like ES3 strings
	var IObject = __webpack_require__(63)
	  , defined = __webpack_require__(51);
	module.exports = function(it){
	  return IObject(defined(it));
	};

/***/ },
/* 63 */
/***/ function(module, exports, __webpack_require__) {

	// fallback for non-array-like ES3 and non-enumerable old V8 strings
	var cof = __webpack_require__(64);
	module.exports = Object('z').propertyIsEnumerable(0) ? Object : function(it){
	  return cof(it) == 'String' ? it.split('') : Object(it);
	};

/***/ },
/* 64 */
/***/ function(module, exports) {

	var toString = {}.toString;
	
	module.exports = function(it){
	  return toString.call(it).slice(8, -1);
	};

/***/ },
/* 65 */
/***/ function(module, exports, __webpack_require__) {

	// false -> Array#indexOf
	// true  -> Array#includes
	var toIObject = __webpack_require__(62)
	  , toLength  = __webpack_require__(66)
	  , toIndex   = __webpack_require__(67);
	module.exports = function(IS_INCLUDES){
	  return function($this, el, fromIndex){
	    var O      = toIObject($this)
	      , length = toLength(O.length)
	      , index  = toIndex(fromIndex, length)
	      , value;
	    // Array#includes uses SameValueZero equality algorithm
	    if(IS_INCLUDES && el != el)while(length > index){
	      value = O[index++];
	      if(value != value)return true;
	    // Array#toIndex ignores holes, Array#includes - not
	    } else for(;length > index; index++)if(IS_INCLUDES || index in O){
	      if(O[index] === el)return IS_INCLUDES || index || 0;
	    } return !IS_INCLUDES && -1;
	  };
	};

/***/ },
/* 66 */
/***/ function(module, exports, __webpack_require__) {

	// 7.1.15 ToLength
	var toInteger = __webpack_require__(50)
	  , min       = Math.min;
	module.exports = function(it){
	  return it > 0 ? min(toInteger(it), 0x1fffffffffffff) : 0; // pow(2, 53) - 1 == 9007199254740991
	};

/***/ },
/* 67 */
/***/ function(module, exports, __webpack_require__) {

	var toInteger = __webpack_require__(50)
	  , max       = Math.max
	  , min       = Math.min;
	module.exports = function(index, length){
	  index = toInteger(index);
	  return index < 0 ? max(index + length, 0) : min(index, length);
	};

/***/ },
/* 68 */
/***/ function(module, exports, __webpack_require__) {

	var shared = __webpack_require__(69)('keys')
	  , uid    = __webpack_require__(70);
	module.exports = function(key){
	  return shared[key] || (shared[key] = uid(key));
	};

/***/ },
/* 69 */
/***/ function(module, exports, __webpack_require__) {

	var global = __webpack_require__(32)
	  , SHARED = '__core-js_shared__'
	  , store  = global[SHARED] || (global[SHARED] = {});
	module.exports = function(key){
	  return store[key] || (store[key] = {});
	};

/***/ },
/* 70 */
/***/ function(module, exports) {

	var id = 0
	  , px = Math.random();
	module.exports = function(key){
	  return 'Symbol('.concat(key === undefined ? '' : key, ')_', (++id + px).toString(36));
	};

/***/ },
/* 71 */
/***/ function(module, exports) {

	// IE 8- don't enum bug keys
	module.exports = (
	  'constructor,hasOwnProperty,isPrototypeOf,propertyIsEnumerable,toLocaleString,toString,valueOf'
	).split(',');

/***/ },
/* 72 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(32).document && document.documentElement;

/***/ },
/* 73 */
/***/ function(module, exports, __webpack_require__) {

	var def = __webpack_require__(37).f
	  , has = __webpack_require__(55)
	  , TAG = __webpack_require__(74)('toStringTag');
	
	module.exports = function(it, tag, stat){
	  if(it && !has(it = stat ? it : it.prototype, TAG))def(it, TAG, {configurable: true, value: tag});
	};

/***/ },
/* 74 */
/***/ function(module, exports, __webpack_require__) {

	var store      = __webpack_require__(69)('wks')
	  , uid        = __webpack_require__(70)
	  , Symbol     = __webpack_require__(32).Symbol
	  , USE_SYMBOL = typeof Symbol == 'function';
	
	var $exports = module.exports = function(name){
	  return store[name] || (store[name] =
	    USE_SYMBOL && Symbol[name] || (USE_SYMBOL ? Symbol : uid)('Symbol.' + name));
	};
	
	$exports.store = store;

/***/ },
/* 75 */
/***/ function(module, exports, __webpack_require__) {

	// 19.1.2.9 / 15.2.3.2 Object.getPrototypeOf(O)
	var has         = __webpack_require__(55)
	  , toObject    = __webpack_require__(76)
	  , IE_PROTO    = __webpack_require__(68)('IE_PROTO')
	  , ObjectProto = Object.prototype;
	
	module.exports = Object.getPrototypeOf || function(O){
	  O = toObject(O);
	  if(has(O, IE_PROTO))return O[IE_PROTO];
	  if(typeof O.constructor == 'function' && O instanceof O.constructor){
	    return O.constructor.prototype;
	  } return O instanceof Object ? ObjectProto : null;
	};

/***/ },
/* 76 */
/***/ function(module, exports, __webpack_require__) {

	// 7.1.13 ToObject(argument)
	var defined = __webpack_require__(51);
	module.exports = function(it){
	  return Object(defined(it));
	};

/***/ },
/* 77 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(78);
	var global        = __webpack_require__(32)
	  , hide          = __webpack_require__(36)
	  , Iterators     = __webpack_require__(56)
	  , TO_STRING_TAG = __webpack_require__(74)('toStringTag');
	
	for(var collections = ['NodeList', 'DOMTokenList', 'MediaList', 'StyleSheetList', 'CSSRuleList'], i = 0; i < 5; i++){
	  var NAME       = collections[i]
	    , Collection = global[NAME]
	    , proto      = Collection && Collection.prototype;
	  if(proto && !proto[TO_STRING_TAG])hide(proto, TO_STRING_TAG, NAME);
	  Iterators[NAME] = Iterators.Array;
	}

/***/ },
/* 78 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	var addToUnscopables = __webpack_require__(79)
	  , step             = __webpack_require__(80)
	  , Iterators        = __webpack_require__(56)
	  , toIObject        = __webpack_require__(62);
	
	// 22.1.3.4 Array.prototype.entries()
	// 22.1.3.13 Array.prototype.keys()
	// 22.1.3.29 Array.prototype.values()
	// 22.1.3.30 Array.prototype[@@iterator]()
	module.exports = __webpack_require__(52)(Array, 'Array', function(iterated, kind){
	  this._t = toIObject(iterated); // target
	  this._i = 0;                   // next index
	  this._k = kind;                // kind
	// 22.1.5.2.1 %ArrayIteratorPrototype%.next()
	}, function(){
	  var O     = this._t
	    , kind  = this._k
	    , index = this._i++;
	  if(!O || index >= O.length){
	    this._t = undefined;
	    return step(1);
	  }
	  if(kind == 'keys'  )return step(0, index);
	  if(kind == 'values')return step(0, O[index]);
	  return step(0, [index, O[index]]);
	}, 'values');
	
	// argumentsList[@@iterator] is %ArrayProto_values% (9.4.4.6, 9.4.4.7)
	Iterators.Arguments = Iterators.Array;
	
	addToUnscopables('keys');
	addToUnscopables('values');
	addToUnscopables('entries');

/***/ },
/* 79 */
/***/ function(module, exports) {

	module.exports = function(){ /* empty */ };

/***/ },
/* 80 */
/***/ function(module, exports) {

	module.exports = function(done, value){
	  return {value: value, done: !!done};
	};

/***/ },
/* 81 */
/***/ function(module, exports, __webpack_require__) {

	exports.f = __webpack_require__(74);

/***/ },
/* 82 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = { "default": __webpack_require__(83), __esModule: true };

/***/ },
/* 83 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(84);
	var $Object = __webpack_require__(33).Object;
	module.exports = function getOwnPropertyNames(it){
	  return $Object.getOwnPropertyNames(it);
	};

/***/ },
/* 84 */
/***/ function(module, exports, __webpack_require__) {

	// 19.1.2.7 Object.getOwnPropertyNames(O)
	__webpack_require__(85)('getOwnPropertyNames', function(){
	  return __webpack_require__(86).f;
	});

/***/ },
/* 85 */
/***/ function(module, exports, __webpack_require__) {

	// most Object methods by ES6 should accept primitives
	var $export = __webpack_require__(31)
	  , core    = __webpack_require__(33)
	  , fails   = __webpack_require__(42);
	module.exports = function(KEY, exec){
	  var fn  = (core.Object || {})[KEY] || Object[KEY]
	    , exp = {};
	  exp[KEY] = exec(fn);
	  $export($export.S + $export.F * fails(function(){ fn(1); }), 'Object', exp);
	};

/***/ },
/* 86 */
/***/ function(module, exports, __webpack_require__) {

	// fallback for IE11 buggy Object.getOwnPropertyNames with iframe and window
	var toIObject = __webpack_require__(62)
	  , gOPN      = __webpack_require__(87).f
	  , toString  = {}.toString;
	
	var windowNames = typeof window == 'object' && window && Object.getOwnPropertyNames
	  ? Object.getOwnPropertyNames(window) : [];
	
	var getWindowNames = function(it){
	  try {
	    return gOPN(it);
	  } catch(e){
	    return windowNames.slice();
	  }
	};
	
	module.exports.f = function getOwnPropertyNames(it){
	  return windowNames && toString.call(it) == '[object Window]' ? getWindowNames(it) : gOPN(toIObject(it));
	};


/***/ },
/* 87 */
/***/ function(module, exports, __webpack_require__) {

	// 19.1.2.7 / 15.2.3.4 Object.getOwnPropertyNames(O)
	var $keys      = __webpack_require__(61)
	  , hiddenKeys = __webpack_require__(71).concat('length', 'prototype');
	
	exports.f = Object.getOwnPropertyNames || function getOwnPropertyNames(O){
	  return $keys(O, hiddenKeys);
	};

/***/ },
/* 88 */
/***/ function(module, exports) {

	"use strict";
	
	exports.__esModule = true;
	
	exports.default = function (instance, Constructor) {
	  if (!(instance instanceof Constructor)) {
	    throw new TypeError("Cannot call a class as a function");
	  }
	};

/***/ },
/* 89 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	exports.__esModule = true;
	
	var _defineProperty = __webpack_require__(28);
	
	var _defineProperty2 = _interopRequireDefault(_defineProperty);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = function () {
	  function defineProperties(target, props) {
	    for (var i = 0; i < props.length; i++) {
	      var descriptor = props[i];
	      descriptor.enumerable = descriptor.enumerable || false;
	      descriptor.configurable = true;
	      if ("value" in descriptor) descriptor.writable = true;
	      (0, _defineProperty2.default)(target, descriptor.key, descriptor);
	    }
	  }
	
	  return function (Constructor, protoProps, staticProps) {
	    if (protoProps) defineProperties(Constructor.prototype, protoProps);
	    if (staticProps) defineProperties(Constructor, staticProps);
	    return Constructor;
	  };
	}();

/***/ },
/* 90 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(91)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(93)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Accordion.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Accordion.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Accordion.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Accordion.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Accordion.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 91 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    type: {
	      type: String,
	      default: null
	    },
	    oneAtAtime: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  },
	  created: function created() {
	    var _this = this;
	
	    this._isAccordion = true;
	    this.$on('isOpenEvent', function (child) {
	      if (_this.oneAtAtime) {
	        _this.$children.forEach(function (item) {
	          if (child !== item) {
	            item.isOpen = false;
	          }
	        });
	      }
	    });
	  }
	};
	// </script>
	// <template>
	
	//   <div class="panel-group">
	
	//     <slot></slot>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 92 */
/***/ function(module, exports) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	exports.getJSON = getJSON;
	exports.getScrollBarWidth = getScrollBarWidth;
	exports.translations = translations;
	exports.delayer = delayer;
	exports.VueFixer = VueFixer;
	// coerce convert som types of data into another type
	var coerce = exports.coerce = {
	  // Convert a string to booleam. Otherwise, return the value without modification, so if is not boolean, Vue throw a warning.
	  boolean: function boolean(val) {
	    return typeof val === 'string' ? val === '' || val === 'true' ? true : val === 'false' || val === 'null' || val === 'undefined' ? false : val : val;
	  },
	  // Attempt to convert a string value to a Number. Otherwise, return 0.
	  number: function number(val) {
	    var alt = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : null;
	    return typeof val === 'number' ? val : val === undefined || val === null || isNaN(Number(val)) ? alt : Number(val);
	  },
	  // Attempt to convert to string any value, except for null or undefined.
	  string: function string(val) {
	    return val === undefined || val === null ? '' : val + '';
	  },
	  // Pattern accept RegExp, function, or string (converted to RegExp). Otherwise return null.
	  pattern: function pattern(val) {
	    return val instanceof Function || val instanceof RegExp ? val : typeof val === 'string' ? new RegExp(val) : null;
	  }
	};
	
	function getJSON(url) {
	  var request = new window.XMLHttpRequest();
	  var data = {};
	  // p (-simulated- promise)
	  var p = {
	    then: function then(fn1, fn2) {
	      return p.done(fn1).fail(fn2);
	    },
	    catch: function _catch(fn) {
	      return p.fail(fn);
	    },
	    always: function always(fn) {
	      return p.done(fn).fail(fn);
	    }
	  };
	  ['done', 'fail'].forEach(function (name) {
	    data[name] = [];
	    p[name] = function (fn) {
	      if (fn instanceof Function) data[name].push(fn);
	      return p;
	    };
	  });
	  p.done(JSON.parse);
	  request.onreadystatechange = function () {
	    if (request.readyState === 4) {
	      var response;
	      var i;
	      var value;
	
	      (function () {
	        var e = { status: request.status };
	        if (request.status === 200) {
	          try {
	            response = request.responseText;
	
	            for (i in data.done) {
	              value = data.done[i](response);
	
	              if (value !== undefined) {
	                response = value;
	              }
	            }
	          } catch (err) {
	            data.fail.forEach(function (fail) {
	              return fail(err);
	            });
	          }
	        } else {
	          data.fail.forEach(function (fail) {
	            return fail(e);
	          });
	        }
	      })();
	    }
	  };
	  request.open('GET', url);
	  request.setRequestHeader('Accept', 'application/json');
	  request.send();
	  return p;
	}
	
	function getScrollBarWidth() {
	  if (document.documentElement.scrollHeight <= document.documentElement.clientHeight) {
	    return 0;
	  }
	  var inner = document.createElement('p');
	  inner.style.width = '100%';
	  inner.style.height = '200px';
	
	  var outer = document.createElement('div');
	  outer.style.position = 'absolute';
	  outer.style.top = '0px';
	  outer.style.left = '0px';
	  outer.style.visibility = 'hidden';
	  outer.style.width = '200px';
	  outer.style.height = '150px';
	  outer.style.overflow = 'hidden';
	  outer.appendChild(inner);
	
	  document.body.appendChild(outer);
	  var w1 = inner.offsetWidth;
	  outer.style.overflow = 'scroll';
	  var w2 = inner.offsetWidth;
	  if (w1 === w2) w2 = outer.clientWidth;
	
	  document.body.removeChild(outer);
	
	  return w1 - w2;
	}
	
	// return all the translations or the default language (english)
	function translations() {
	  var lang = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : 'en';
	
	  var text = {
	    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
	    limit: 'Limit reached ({{limit}} items max).',
	    loading: 'Loading...',
	    minLength: 'Min. Length',
	    months: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
	    notSelected: 'Nothing Selected',
	    required: 'Required',
	    search: 'Search'
	  };
	  return window.VueStrapLang ? window.VueStrapLang(lang) : text;
	}
	
	// delayer: set a function that execute after a delay
	// @params (function, delay_prop or value, default_value)
	function delayer(fn, varTimer) {
	  var ifNaN = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : 100;
	
	  function toInt(el) {
	    return (/^[0-9]+$/.test(el) ? Number(el) || 1 : null
	    );
	  }
	  var timerId;
	  return function () {
	    var _this = this;
	
	    for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
	      args[_key] = arguments[_key];
	    }
	
	    if (timerId) clearTimeout(timerId);
	    timerId = setTimeout(function () {
	      fn.apply(_this, args);
	    }, toInt(varTimer) || toInt(this[varTimer]) || ifNaN);
	  };
	}
	
	// Fix a vue instance Lifecycle to vue 1/2 (just the basic elements, is not a real parser, so this work only if your code is compatible with both)
	function VueFixer(vue) {
	  var vue2 = !window.Vue || !window.Vue.partial;
	  var mixin = {
	    computed: {
	      vue2: function vue2() {
	        return !this.$dispatch;
	      }
	    }
	  };
	  if (!vue2) {
	    if (vue.beforeCreate) {
	      mixin.create = vue.beforeCreate;
	      delete vue.beforeCreate;
	    }
	    if (vue.beforeMount) {
	      vue.beforeCompile = vue.beforeMount;
	      delete vue.beforeMount;
	    }
	    if (vue.mounted) {
	      vue.ready = vue.mounted;
	      delete vue.mounted;
	    }
	  } else {
	    if (vue.beforeCompile) {
	      vue.beforeMount = vue.beforeCompile;
	      delete vue.beforeCompile;
	    }
	    if (vue.compiled) {
	      mixin.compiled = vue.compiled;
	      delete vue.compiled;
	    }
	    if (vue.ready) {
	      vue.mounted = vue.ready;
	      delete vue.ready;
	    }
	  }
	  if (!vue.mixins) {
	    vue.mixins = [];
	  }
	  vue.mixins.unshift(mixin);
	  return vue;
	}

/***/ },
/* 93 */
/***/ function(module, exports) {

	module.exports = "<div class=\"panel-group\">\r\n    <slot></slot>\r\n  </div>";

/***/ },
/* 94 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(95)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(96)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Affix.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Affix.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Affix.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Affix.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Affix.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 95 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div class="hidden-print hidden-xs hidden-sm">
	
	//     <nav class="bs-docs-sidebar" :class="{affix:affixed}" :style="{marginTop:top}">
	
	//       <slot></slot>
	
	//     </nav>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    offset: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 0
	    }
	  },
	  data: function data() {
	    return {
	      affixed: false
	    };
	  },
	
	  computed: {
	    top: function top() {
	      return this.offset > 0 ? this.offset + 'px' : null;
	    }
	  },
	  methods: {
	    // from https://github.com/ant-design/ant-design/blob/master/components/affix/index.jsx#L20
	    checkScroll: function checkScroll() {
	      var _this = this;
	
	      // if is hidden don't calculate anything
	      if (!(this.$el.offsetWidth || this.$el.offsetHeight || this.$el.getClientRects().length)) {
	        return;
	      }
	      // get window scroll and element position to detect if have to be normal or affixed
	      var scroll = {};
	      var element = {};
	      var rect = this.$el.getBoundingClientRect();
	      var body = document.body;
	      ['Top', 'Left'].forEach(function (type) {
	        var t = type.toLowerCase();
	        var ret = window['page' + (type === 'Top' ? 'Y' : 'X') + 'Offset'];
	        var method = 'scroll' + type;
	        if (typeof ret !== 'number') {
	          // ie6,7,8 standard mode
	          ret = document.documentElement[method];
	          if (typeof ret !== 'number') {
	            // quirks mode
	            ret = document.body[method];
	          }
	        }
	        scroll[t] = ret;
	        element[t] = scroll[t] + rect[t] - (_this.$el['client' + type] || body['client' + type] || 0);
	      });
	      var fix = scroll.top > element.top - this.offset;
	      if (this.affixed !== fix) {
	        this.affixed = fix;
	      }
	    }
	  },
	  ready: function ready() {
	    var _this2 = this;
	
	    (0, _NodeList2.default)(window).on('scroll resize', function () {
	      return _this2.checkScroll();
	    });
	    setTimeout(function () {
	      return _this2.checkScroll();
	    }, 0);
	  },
	  beforeDestroy: function beforeDestroy() {
	    var _this3 = this;
	
	    (0, _NodeList2.default)(window).off('scroll resize', function () {
	      return _this3.checkScroll();
	    });
	  }
	};
	// </script>

/***/ },
/* 96 */
/***/ function(module, exports) {

	module.exports = "<div class=\"hidden-print hidden-xs hidden-sm\">\r\n    <nav class=\"bs-docs-sidebar\" :class=\"{affix:affixed}\" :style=\"{marginTop:top}\">\r\n      <slot></slot>\r\n    </nav>\r\n  </div>";

/***/ },
/* 97 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(98)
	module.exports = __webpack_require__(102)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(103)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Alert.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Alert.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Alert.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Alert.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Alert.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 98 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(99);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-200e8621&file=Alert.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Alert.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-200e8621&file=Alert.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Alert.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 99 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".fade-transition {\r\n  -webkit-transition: opacity .3s ease;\r\n  transition: opacity .3s ease;\r\n}\r\n.fade-enter,\r\n.fade-leave {\r\n  height: 0;\r\n  opacity: 0;\r\n}\r\n.alert.top {\r\n  position: fixed;\r\n  top: 30px;\r\n  margin: 0 auto;\r\n  left: 0;\r\n  right: 0;\r\n  z-index: 1050;\r\n}\r\n.alert.top-right {\r\n  position: fixed;\r\n  top: 30px;\r\n  right: 50px;\r\n  z-index: 1050;\r\n}", ""]);
	
	// exports


/***/ },
/* 100 */
/***/ function(module, exports) {

	/*
		MIT License http://www.opensource.org/licenses/mit-license.php
		Author Tobias Koppers @sokra
	*/
	// css base code, injected by the css-loader
	module.exports = function() {
		var list = [];
	
		// return the list of modules as css string
		list.toString = function toString() {
			var result = [];
			for(var i = 0; i < this.length; i++) {
				var item = this[i];
				if(item[2]) {
					result.push("@media " + item[2] + "{" + item[1] + "}");
				} else {
					result.push(item[1]);
				}
			}
			return result.join("");
		};
	
		// import a list of modules into the list
		list.i = function(modules, mediaQuery) {
			if(typeof modules === "string")
				modules = [[null, modules, ""]];
			var alreadyImportedModules = {};
			for(var i = 0; i < this.length; i++) {
				var id = this[i][0];
				if(typeof id === "number")
					alreadyImportedModules[id] = true;
			}
			for(i = 0; i < modules.length; i++) {
				var item = modules[i];
				// skip already imported module
				// this implementation is not 100% perfect for weird media query combinations
				//  when a module is imported multiple times with different media queries.
				//  I hope this will never occur (Hey this way we have smaller bundles)
				if(typeof item[0] !== "number" || !alreadyImportedModules[item[0]]) {
					if(mediaQuery && !item[2]) {
						item[2] = mediaQuery;
					} else if(mediaQuery) {
						item[2] = "(" + item[2] + ") and (" + mediaQuery + ")";
					}
					list.push(item);
				}
			}
		};
		return list;
	};


/***/ },
/* 101 */
/***/ function(module, exports, __webpack_require__) {

	/*
		MIT License http://www.opensource.org/licenses/mit-license.php
		Author Tobias Koppers @sokra
	*/
	var stylesInDom = {},
		memoize = function(fn) {
			var memo;
			return function () {
				if (typeof memo === "undefined") memo = fn.apply(this, arguments);
				return memo;
			};
		},
		isOldIE = memoize(function() {
			return /msie [6-9]\b/.test(window.navigator.userAgent.toLowerCase());
		}),
		getHeadElement = memoize(function () {
			return document.head || document.getElementsByTagName("head")[0];
		}),
		singletonElement = null,
		singletonCounter = 0,
		styleElementsInsertedAtTop = [];
	
	module.exports = function(list, options) {
		if(false) {
			if(typeof document !== "object") throw new Error("The style-loader cannot be used in a non-browser environment");
		}
	
		options = options || {};
		// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
		// tags it will allow on a page
		if (typeof options.singleton === "undefined") options.singleton = isOldIE();
	
		// By default, add <style> tags to the bottom of <head>.
		if (typeof options.insertAt === "undefined") options.insertAt = "bottom";
	
		var styles = listToStyles(list);
		addStylesToDom(styles, options);
	
		return function update(newList) {
			var mayRemove = [];
			for(var i = 0; i < styles.length; i++) {
				var item = styles[i];
				var domStyle = stylesInDom[item.id];
				domStyle.refs--;
				mayRemove.push(domStyle);
			}
			if(newList) {
				var newStyles = listToStyles(newList);
				addStylesToDom(newStyles, options);
			}
			for(var i = 0; i < mayRemove.length; i++) {
				var domStyle = mayRemove[i];
				if(domStyle.refs === 0) {
					for(var j = 0; j < domStyle.parts.length; j++)
						domStyle.parts[j]();
					delete stylesInDom[domStyle.id];
				}
			}
		};
	}
	
	function addStylesToDom(styles, options) {
		for(var i = 0; i < styles.length; i++) {
			var item = styles[i];
			var domStyle = stylesInDom[item.id];
			if(domStyle) {
				domStyle.refs++;
				for(var j = 0; j < domStyle.parts.length; j++) {
					domStyle.parts[j](item.parts[j]);
				}
				for(; j < item.parts.length; j++) {
					domStyle.parts.push(addStyle(item.parts[j], options));
				}
			} else {
				var parts = [];
				for(var j = 0; j < item.parts.length; j++) {
					parts.push(addStyle(item.parts[j], options));
				}
				stylesInDom[item.id] = {id: item.id, refs: 1, parts: parts};
			}
		}
	}
	
	function listToStyles(list) {
		var styles = [];
		var newStyles = {};
		for(var i = 0; i < list.length; i++) {
			var item = list[i];
			var id = item[0];
			var css = item[1];
			var media = item[2];
			var sourceMap = item[3];
			var part = {css: css, media: media, sourceMap: sourceMap};
			if(!newStyles[id])
				styles.push(newStyles[id] = {id: id, parts: [part]});
			else
				newStyles[id].parts.push(part);
		}
		return styles;
	}
	
	function insertStyleElement(options, styleElement) {
		var head = getHeadElement();
		var lastStyleElementInsertedAtTop = styleElementsInsertedAtTop[styleElementsInsertedAtTop.length - 1];
		if (options.insertAt === "top") {
			if(!lastStyleElementInsertedAtTop) {
				head.insertBefore(styleElement, head.firstChild);
			} else if(lastStyleElementInsertedAtTop.nextSibling) {
				head.insertBefore(styleElement, lastStyleElementInsertedAtTop.nextSibling);
			} else {
				head.appendChild(styleElement);
			}
			styleElementsInsertedAtTop.push(styleElement);
		} else if (options.insertAt === "bottom") {
			head.appendChild(styleElement);
		} else {
			throw new Error("Invalid value for parameter 'insertAt'. Must be 'top' or 'bottom'.");
		}
	}
	
	function removeStyleElement(styleElement) {
		styleElement.parentNode.removeChild(styleElement);
		var idx = styleElementsInsertedAtTop.indexOf(styleElement);
		if(idx >= 0) {
			styleElementsInsertedAtTop.splice(idx, 1);
		}
	}
	
	function createStyleElement(options) {
		var styleElement = document.createElement("style");
		styleElement.type = "text/css";
		insertStyleElement(options, styleElement);
		return styleElement;
	}
	
	function createLinkElement(options) {
		var linkElement = document.createElement("link");
		linkElement.rel = "stylesheet";
		insertStyleElement(options, linkElement);
		return linkElement;
	}
	
	function addStyle(obj, options) {
		var styleElement, update, remove;
	
		if (options.singleton) {
			var styleIndex = singletonCounter++;
			styleElement = singletonElement || (singletonElement = createStyleElement(options));
			update = applyToSingletonTag.bind(null, styleElement, styleIndex, false);
			remove = applyToSingletonTag.bind(null, styleElement, styleIndex, true);
		} else if(obj.sourceMap &&
			typeof URL === "function" &&
			typeof URL.createObjectURL === "function" &&
			typeof URL.revokeObjectURL === "function" &&
			typeof Blob === "function" &&
			typeof btoa === "function") {
			styleElement = createLinkElement(options);
			update = updateLink.bind(null, styleElement);
			remove = function() {
				removeStyleElement(styleElement);
				if(styleElement.href)
					URL.revokeObjectURL(styleElement.href);
			};
		} else {
			styleElement = createStyleElement(options);
			update = applyToTag.bind(null, styleElement);
			remove = function() {
				removeStyleElement(styleElement);
			};
		}
	
		update(obj);
	
		return function updateStyle(newObj) {
			if(newObj) {
				if(newObj.css === obj.css && newObj.media === obj.media && newObj.sourceMap === obj.sourceMap)
					return;
				update(obj = newObj);
			} else {
				remove();
			}
		};
	}
	
	var replaceText = (function () {
		var textStore = [];
	
		return function (index, replacement) {
			textStore[index] = replacement;
			return textStore.filter(Boolean).join('\n');
		};
	})();
	
	function applyToSingletonTag(styleElement, index, remove, obj) {
		var css = remove ? "" : obj.css;
	
		if (styleElement.styleSheet) {
			styleElement.styleSheet.cssText = replaceText(index, css);
		} else {
			var cssNode = document.createTextNode(css);
			var childNodes = styleElement.childNodes;
			if (childNodes[index]) styleElement.removeChild(childNodes[index]);
			if (childNodes.length) {
				styleElement.insertBefore(cssNode, childNodes[index]);
			} else {
				styleElement.appendChild(cssNode);
			}
		}
	}
	
	function applyToTag(styleElement, obj) {
		var css = obj.css;
		var media = obj.media;
	
		if(media) {
			styleElement.setAttribute("media", media)
		}
	
		if(styleElement.styleSheet) {
			styleElement.styleSheet.cssText = css;
		} else {
			while(styleElement.firstChild) {
				styleElement.removeChild(styleElement.firstChild);
			}
			styleElement.appendChild(document.createTextNode(css));
		}
	}
	
	function updateLink(linkElement, obj) {
		var css = obj.css;
		var sourceMap = obj.sourceMap;
	
		if(sourceMap) {
			// http://stackoverflow.com/a/26603875
			css += "\n/*# sourceMappingURL=data:application/json;base64," + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + " */";
		}
	
		var blob = new Blob([css], { type: "text/css" });
	
		var oldSrc = linkElement.href;
	
		linkElement.href = URL.createObjectURL(blob);
	
		if(oldSrc)
			URL.revokeObjectURL(oldSrc);
	}


/***/ },
/* 102 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    type: {
	      type: String
	    },
	    dismissable: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    show: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true,
	      twoWay: true
	    },
	    duration: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 0
	    },
	    width: {
	      type: String
	    },
	    placement: {
	      type: String
	    }
	  },
	  watch: {
	    show: function show(val) {
	      var _this = this;
	
	      if (this._timeout) clearTimeout(this._timeout);
	      if (val && Boolean(this.duration)) {
	        this._timeout = setTimeout(function () {
	          _this.show = false;
	        }, this.duration);
	      }
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .fade-transition {
	
	//   transition: opacity .3s ease;
	
	// }
	
	// .fade-enter,
	
	// .fade-leave {
	
	//   height: 0;
	
	//   opacity: 0;
	
	// }
	
	// .alert.top {
	
	//   position: fixed;
	
	//   top: 30px;
	
	//   margin: 0 auto;
	
	//   left: 0;
	
	//   right: 0;
	
	//   z-index: 1050;
	
	// }
	
	// .alert.top-right {
	
	//   position: fixed;
	
	//   top: 30px;
	
	//   right: 50px;
	
	//   z-index: 1050;
	
	// }
	
	// </style>
	// <template>
	
	//   <div
	
	//     v-show="show"
	
	//     v-bind:class="{
	
	//       'alert':		true,
	
	//       'alert-success':(type == 'success'),
	
	//       'alert-warning':(type == 'warning'),
	
	//       'alert-info':	(type == 'info'),
	
	//       'alert-danger':	(type == 'danger'),
	
	//       'top': 			(placement === 'top'),
	
	//       'top-right': 	(placement === 'top-right')
	
	//     }"
	
	//     transition="fade"
	
	//     v-bind:style="{width:width}"
	
	//     role="alert">
	
	//     <button v-show="dismissable" type="button" class="close"
	
	//       @click="show = false">
	
	//       <span>&times;</span>
	
	//     </button>
	
	//     <slot></slot>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 103 */
/***/ function(module, exports) {

	module.exports = "<div\r\n    v-show=\"show\"\r\n    v-bind:class=\"{\r\n      'alert':\t\ttrue,\r\n      'alert-success':(type == 'success'),\r\n      'alert-warning':(type == 'warning'),\r\n      'alert-info':\t(type == 'info'),\r\n      'alert-danger':\t(type == 'danger'),\r\n      'top': \t\t\t(placement === 'top'),\r\n      'top-right': \t(placement === 'top-right')\r\n    }\"\r\n    transition=\"fade\"\r\n    v-bind:style=\"{width:width}\"\r\n    role=\"alert\">\r\n    <button v-show=\"dismissable\" type=\"button\" class=\"close\"\r\n      @click=\"show = false\">\r\n      <span>&times;</span>\r\n    </button>\r\n    <slot></slot>\r\n  </div>";

/***/ },
/* 104 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(105)
	module.exports = __webpack_require__(107)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(108)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Aside.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Aside.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Aside.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Aside.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Aside.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 105 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(106);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-9bcf1806&file=Aside.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Aside.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-9bcf1806&file=Aside.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Aside.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 106 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".aside-open {\r\n  -webkit-transition: -webkit-transform 0.3s;\r\n  transition: -webkit-transform 0.3s;\r\n  transition: transform 0.3s;\r\n  transition: transform 0.3s, -webkit-transform 0.3s;\r\n}\r\n.aside-open.has-push-right {\r\n  -webkit-transform: translateX(-300px);\r\n          transform: translateX(-300px);\r\n}\r\n.aside {\r\n    position: fixed;\r\n    top: 0;\r\n    bottom: 0;\r\n    z-index: 1049;\r\n    overflow: auto;\r\n    background: #fff;\r\n}\r\n.aside.left {\r\n  left: 0;\r\n  right: auto;\r\n}\r\n.aside.right {\r\n  left: auto;\r\n  right: 0;\r\n}\r\n.slideleft-enter {\r\n  -webkit-animation:slideleft-in .3s;\r\n          animation:slideleft-in .3s;\r\n}\r\n.slideleft-leave {\r\n  -webkit-animation:slideleft-out .3s;\r\n          animation:slideleft-out .3s;\r\n}\r\n@-webkit-keyframes slideleft-in {\r\n  0% {\r\n    -webkit-transform: translateX(-100%);\r\n            transform: translateX(-100%);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n}\r\n@keyframes slideleft-in {\r\n  0% {\r\n    -webkit-transform: translateX(-100%);\r\n            transform: translateX(-100%);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n}\r\n@-webkit-keyframes slideleft-out {\r\n  0% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(-100%);\r\n            transform: translateX(-100%);\r\n    opacity: 0;\r\n  }\r\n}\r\n@keyframes slideleft-out {\r\n  0% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(-100%);\r\n            transform: translateX(-100%);\r\n    opacity: 0;\r\n  }\r\n}\r\n.slideright-enter {\r\n  -webkit-animation:slideright-in .3s;\r\n          animation:slideright-in .3s;\r\n}\r\n.slideright-leave {\r\n  -webkit-animation:slideright-out .3s;\r\n          animation:slideright-out .3s;\r\n}\r\n@-webkit-keyframes slideright-in {\r\n  0% {\r\n    -webkit-transform: translateX(100%);\r\n            transform: translateX(100%);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n}\r\n@keyframes slideright-in {\r\n  0% {\r\n    -webkit-transform: translateX(100%);\r\n            transform: translateX(100%);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n}\r\n@-webkit-keyframes slideright-out {\r\n  0% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(100%);\r\n            transform: translateX(100%);\r\n    opacity: 0;\r\n  }\r\n}\r\n@keyframes slideright-out {\r\n  0% {\r\n    -webkit-transform: translateX(0);\r\n            transform: translateX(0);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: translateX(100%);\r\n            transform: translateX(100%);\r\n    opacity: 0;\r\n  }\r\n}\r\n.aside:focus {\r\n    outline: 0\r\n}\r\n@media (max-width: 991px) {\r\n  .aside {\r\n    min-width:240px\r\n  }\r\n}\r\n.aside.left {\r\n  right: auto;\r\n  left: 0\r\n}\r\n.aside.right {\r\n  right: 0;\r\n  left: auto\r\n}\r\n.aside .aside-dialog .aside-header {\r\n  border-bottom: 1px solid #e5e5e5;\r\n  min-height: 16.43px;\r\n  padding: 6px 15px;\r\n  background: #337ab7;\r\n  color: #fff\r\n}\r\n.aside .aside-dialog .aside-header .close {\r\n  margin-right: -8px;\r\n  padding: 4px 8px;\r\n  color: #fff;\r\n  font-size: 25px;\r\n  opacity: .8\r\n}\r\n.aside .aside-dialog .aside-body {\r\n  position: relative;\r\n  padding: 15px\r\n}\r\n.aside .aside-dialog .aside-footer {\r\n  padding: 15px;\r\n  text-align: right;\r\n  border-top: 1px solid #e5e5e5\r\n}\r\n.aside .aside-dialog .aside-footer .btn+.btn {\r\n  margin-left: 5px;\r\n  margin-bottom: 0\r\n}\r\n.aside .aside-dialog .aside-footer .btn-group .btn+.btn {\r\n  margin-left: -1px\r\n}\r\n.aside .aside-dialog .aside-footer .btn-block+.btn-block {\r\n  margin-left: 0\r\n}\r\n.aside-backdrop {\r\n  position: fixed;\r\n  top: 0;\r\n  right: 0;\r\n  bottom: 0;\r\n  left: 0;\r\n  z-index: 1040;\r\n  opacity: 0;\r\n  -webkit-transition: opacity .3s ease;\r\n  transition: opacity .3s ease;\r\n  background-color: #000\r\n}\r\n.aside-backdrop.in {\r\n  opacity: .5;\r\n  filter: alpha(opacity=50)\r\n}", ""]);
	
	// exports


/***/ },
/* 107 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div class="aside"
	
	//     v-bind:style="{width:width + 'px'}"
	
	//     v-bind:class="{
	
	//     left:placement === 'left',
	
	//     right:placement === 'right'
	
	//     }"
	
	//     v-show="show"
	
	//     :transition="(this.placement === 'left') ? 'slideleft' : 'slideright'">
	
	//     <div class="aside-dialog">
	
	//       <div class="aside-content">
	
	//         <div class="aside-header">
	
	//           <button type="button" class="close" @click='close'><span>&times;</span></button>
	
	//           <h4 class="aside-title">
	
	//           <slot name="header">
	
	//             {{ header }}
	
	//           </slot>
	
	//           </h4>
	
	//         </div>
	
	//         <div class="aside-body">
	
	//           <slot></slot>
	
	//         </div>
	
	//       </div>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    show: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      required: true,
	      twoWay: true
	    },
	    placement: {
	      type: String,
	      default: 'right'
	    },
	    header: {
	      type: String
	    },
	    width: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 320
	    }
	  },
	  watch: {
	    show: function show(val) {
	      var _this = this;
	
	      var body = document.body;
	      var scrollBarWidth = (0, _utils.getScrollBarWidth)();
	      if (val) {
	        if (!this._backdrop) {
	          this._backdrop = document.createElement('div');
	        }
	        this._backdrop.className = 'aside-backdrop';
	        body.appendChild(this._backdrop);
	        body.classList.add('modal-open');
	        if (scrollBarWidth !== 0) {
	          body.style.paddingRight = scrollBarWidth + 'px';
	        }
	        // request property that requires layout to force a layout
	        var x = this._backdrop.clientHeight;
	        this._backdrop.classList.add('in');
	        (0, _NodeList2.default)(this._backdrop).on('click', function () {
	          return _this.close();
	        });
	      } else {
	        (0, _NodeList2.default)(this._backdrop).on('transitionend', function () {
	          (0, _NodeList2.default)(_this._backdrop).off();
	          try {
	            body.classList.remove('modal-open');
	            body.style.paddingRight = '0';
	            body.removeChild(_this._backdrop);
	            _this._backdrop = null;
	          } catch (e) {}
	        });
	        this._backdrop.className = 'aside-backdrop';
	      }
	    }
	  },
	  methods: {
	    close: function close() {
	      this.show = false;
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .aside-open {
	
	//   transition: transform 0.3s;
	
	// }
	
	// .aside-open.has-push-right {
	
	//   transform: translateX(-300px);
	
	// }
	
	// .aside {
	
	//     position: fixed;
	
	//     top: 0;
	
	//     bottom: 0;
	
	//     z-index: 1049;
	
	//     overflow: auto;
	
	//     background: #fff;
	
	// }
	
	// .aside.left {
	
	//   left: 0;
	
	//   right: auto;
	
	// }
	
	// .aside.right {
	
	//   left: auto;
	
	//   right: 0;
	
	// }
	
	// .slideleft-enter {
	
	//   animation:slideleft-in .3s;
	
	// }
	
	// .slideleft-leave {
	
	//   animation:slideleft-out .3s;
	
	// }
	
	// @keyframes slideleft-in {
	
	//   0% {
	
	//     transform: translateX(-100%);
	
	//     opacity: 0;
	
	//   }
	
	//   100% {
	
	//     transform: translateX(0);
	
	//     opacity: 1;
	
	//   }
	
	// }
	
	// @keyframes slideleft-out {
	
	//   0% {
	
	//     transform: translateX(0);
	
	//     opacity: 1;
	
	//   }
	
	//   100% {
	
	//     transform: translateX(-100%);
	
	//     opacity: 0;
	
	//   }
	
	// }
	
	// .slideright-enter {
	
	//   animation:slideright-in .3s;
	
	// }
	
	// .slideright-leave {
	
	//   animation:slideright-out .3s;
	
	// }
	
	// @keyframes slideright-in {
	
	//   0% {
	
	//     transform: translateX(100%);
	
	//     opacity: 0;
	
	//   }
	
	//   100% {
	
	//     transform: translateX(0);
	
	//     opacity: 1;
	
	//   }
	
	// }
	
	// @keyframes slideright-out {
	
	//   0% {
	
	//     transform: translateX(0);
	
	//     opacity: 1;
	
	//   }
	
	//   100% {
	
	//     transform: translateX(100%);
	
	//     opacity: 0;
	
	//   }
	
	// }
	
	// .aside:focus {
	
	//     outline: 0
	
	// }
	
	// @media (max-width: 991px) {
	
	//   .aside {
	
	//     min-width:240px
	
	//   }
	
	// }
	
	// .aside.left {
	
	//   right: auto;
	
	//   left: 0
	
	// }
	
	// .aside.right {
	
	//   right: 0;
	
	//   left: auto
	
	// }
	
	// .aside .aside-dialog .aside-header {
	
	//   border-bottom: 1px solid #e5e5e5;
	
	//   min-height: 16.43px;
	
	//   padding: 6px 15px;
	
	//   background: #337ab7;
	
	//   color: #fff
	
	// }
	
	// .aside .aside-dialog .aside-header .close {
	
	//   margin-right: -8px;
	
	//   padding: 4px 8px;
	
	//   color: #fff;
	
	//   font-size: 25px;
	
	//   opacity: .8
	
	// }
	
	// .aside .aside-dialog .aside-body {
	
	//   position: relative;
	
	//   padding: 15px
	
	// }
	
	// .aside .aside-dialog .aside-footer {
	
	//   padding: 15px;
	
	//   text-align: right;
	
	//   border-top: 1px solid #e5e5e5
	
	// }
	
	// .aside .aside-dialog .aside-footer .btn+.btn {
	
	//   margin-left: 5px;
	
	//   margin-bottom: 0
	
	// }
	
	// .aside .aside-dialog .aside-footer .btn-group .btn+.btn {
	
	//   margin-left: -1px
	
	// }
	
	// .aside .aside-dialog .aside-footer .btn-block+.btn-block {
	
	//   margin-left: 0
	
	// }
	
	// .aside-backdrop {
	
	//   position: fixed;
	
	//   top: 0;
	
	//   right: 0;
	
	//   bottom: 0;
	
	//   left: 0;
	
	//   z-index: 1040;
	
	//   opacity: 0;
	
	//   transition: opacity .3s ease;
	
	//   background-color: #000
	
	// }
	
	// .aside-backdrop.in {
	
	//   opacity: .5;
	
	//   filter: alpha(opacity=50)
	
	// }
	
	// </style>

/***/ },
/* 108 */
/***/ function(module, exports) {

	module.exports = "<div class=\"aside\"\r\n    v-bind:style=\"{width:width + 'px'}\"\r\n    v-bind:class=\"{\r\n    left:placement === 'left',\r\n    right:placement === 'right'\r\n    }\"\r\n    v-show=\"show\"\r\n    :transition=\"(this.placement === 'left') ? 'slideleft' : 'slideright'\">\r\n    <div class=\"aside-dialog\">\r\n      <div class=\"aside-content\">\r\n        <div class=\"aside-header\">\r\n          <button type=\"button\" class=\"close\" @click='close'><span>&times;</span></button>\r\n          <h4 class=\"aside-title\">\r\n          <slot name=\"header\">\r\n            {{ header }}\r\n          </slot>\r\n          </h4>\r\n        </div>\r\n        <div class=\"aside-body\">\r\n          <slot></slot>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>";

/***/ },
/* 109 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(110)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(111)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./buttonGroup.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./buttonGroup.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./buttonGroup.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./buttonGroup.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./buttonGroup.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 110 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    value: null,
	    buttons: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    justified: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    type: {
	      type: String,
	      default: 'default'
	    },
	    vertical: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  },
	  watch: {
	    value: {
	      deep: true,
	      handler: function handler(val) {
	        this.$children.forEach(function (el) {
	          if (el.group && el.eval) el.eval();
	        });
	      }
	    }
	  },
	  created: function created() {
	    this._btnGroup = true;
	  }
	};
	// </script>
	// <template>
	
	//   <div :class="{'btn-group':buttons,'btn-group-justified':justified,'btn-group-vertical':vertical}" :data-toggle="buttons&&'buttons'">
	
	//     <slot></slot>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 111 */
/***/ function(module, exports) {

	module.exports = "<div :class=\"{'btn-group':buttons,'btn-group-justified':justified,'btn-group-vertical':vertical}\" :data-toggle=\"buttons&&'buttons'\">\r\n    <slot></slot>\r\n  </div>";

/***/ },
/* 112 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(113)
	module.exports = __webpack_require__(115)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(116)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Carousel.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Carousel.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-5afe80ab&file=Carousel.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Carousel.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Carousel.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-5afe80ab&file=Carousel.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Carousel.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 113 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(114);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-5afe80ab&file=Carousel.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Carousel.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-5afe80ab&file=Carousel.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Carousel.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 114 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".carousel-control[_v-5afe80ab] {\r\n  cursor: pointer;\r\n}", ""]);
	
	// exports


/***/ },
/* 115 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	// <div class="carousel slide" data-ride="carousel">
	
	//   <!-- Indicators -->
	
	//   <ol class="carousel-indicators" v-show="indicators">
	
	//     <li v-for="i in indicator" @click="indicatorClick($index)" v-bind:class="{active:$index === index}"><span></span></li>
	
	//   </ol>
	
	//   <!-- Wrapper for slides -->
	
	//   <div class="carousel-inner" role="listbox">
	
	//     <slot></slot>
	
	//   </div>
	
	//   <!-- Controls -->
	
	//   <div v-show="controls" class="carousel-controls hidden-xs">
	
	//     <a class="left carousel-control" role="button" @click="prev">
	
	//       <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
	
	//     </a>
	
	//     <a class="right carousel-control" role="button" @click="next">
	
	//       <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
	
	//     </a>
	
	//   </div>
	
	// </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    indicators: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    controls: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    interval: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 5000
	    }
	  },
	  data: function data() {
	    return {
	      indicator: [],
	      index: 0,
	      isAnimating: false
	    };
	  },
	
	  watch: {
	    index: function index(newVal, oldVal) {
	      this.slide(newVal > oldVal ? 'left' : 'right', newVal, oldVal);
	    }
	  },
	  methods: {
	    indicatorClick: function indicatorClick(index) {
	      if (this.isAnimating || this.index === index) return false;
	      this.isAnimating = true;
	      this.index = index;
	    },
	    slide: function slide(direction, next, prev) {
	      var _this = this;
	
	      if (!this.$el) {
	        return;
	      }
	      var $slider = (0, _NodeList2.default)('.item', this.$el);
	      if (!$slider.length) {
	        return;
	      }
	      var selected = $slider[next] || $slider[0];
	      (0, _NodeList2.default)(selected).addClass(direction === 'left' ? 'next' : 'prev');
	      // request property that requires layout to force a layout
	      var x = selected.clientHeight;
	      (0, _NodeList2.default)([$slider[prev], selected]).addClass(direction).on('transitionend', function () {
	        $slider.off('transitionend').className = 'item';
	        (0, _NodeList2.default)(selected).addClass('active');
	        _this.isAnimating = false;
	      });
	    },
	    next: function next() {
	      if (!this.$el || this.isAnimating) {
	        return false;
	      }
	      this.isAnimating = true;
	      this.index + 1 < (0, _NodeList2.default)('.item', this.$el).length ? this.index += 1 : this.index = 0;
	    },
	    prev: function prev() {
	      if (!this.$el || this.isAnimating) {
	        return false;
	      }
	      this.isAnimating = true;
	      this.index === 0 ? this.index = (0, _NodeList2.default)('.item', this.$el).length - 1 : this.index -= 1;
	    },
	    toggleInterval: function toggleInterval(val) {
	      if (val === undefined) {
	        val = this._intervalID;
	      }
	      if (this._intervalID) {
	        clearInterval(this._intervalID);
	        delete this._intervalID;
	      }
	      if (val && this.interval > 0) {
	        this._intervalID = setInterval(this.next, this.interval);
	      }
	    }
	  },
	  ready: function ready() {
	    var _this2 = this;
	
	    this.toggleInterval(true);
	    (0, _NodeList2.default)(this.$el).on('mouseenter', function () {
	      return _this2.toggleInterval(false);
	    }).on('mouseleave', function () {
	      return _this2.toggleInterval(true);
	    });
	  },
	  beforeDestroy: function beforeDestroy() {
	    this.toggleInterval(false);
	    (0, _NodeList2.default)(this.$el).off('mouseenter mouseleave');
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// .carousel-control {
	
	//   cursor: pointer;
	
	// }
	
	// </style>

/***/ },
/* 116 */
/***/ function(module, exports) {

	module.exports = "<div class=\"carousel slide\" data-ride=\"carousel\" _v-5afe80ab=\"\">\n  <!-- Indicators -->\n  <ol class=\"carousel-indicators\" v-show=\"indicators\" _v-5afe80ab=\"\">\n    <li v-for=\"i in indicator\" @click=\"indicatorClick($index)\" v-bind:class=\"{active:$index === index}\" _v-5afe80ab=\"\"><span _v-5afe80ab=\"\"></span></li>\n  </ol>\n  <!-- Wrapper for slides -->\n  <div class=\"carousel-inner\" role=\"listbox\" _v-5afe80ab=\"\">\n    <slot _v-5afe80ab=\"\"></slot>\n  </div>\n  <!-- Controls -->\n  <div v-show=\"controls\" class=\"carousel-controls hidden-xs\" _v-5afe80ab=\"\">\n    <a class=\"left carousel-control\" role=\"button\" @click=\"prev\" _v-5afe80ab=\"\">\n      <span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\" _v-5afe80ab=\"\"></span>\n    </a>\n    <a class=\"right carousel-control\" role=\"button\" @click=\"next\" _v-5afe80ab=\"\">\n      <span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\" _v-5afe80ab=\"\"></span>\n    </a>\n  </div>\n</div>";

/***/ },
/* 117 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(118)
	module.exports = __webpack_require__(120)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(121)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Checkbox.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Checkbox.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-dc195ce4&file=Checkbox.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Checkbox.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Checkbox.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-dc195ce4&file=Checkbox.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Checkbox.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 118 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(119);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-dc195ce4&file=Checkbox.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Checkbox.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-dc195ce4&file=Checkbox.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Checkbox.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 119 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, "label.checkbox[_v-dc195ce4] {\r\n  position: relative;\r\n  padding-left: 18px;\r\n}\r\nlabel.checkbox > input[_v-dc195ce4] {\r\n  box-sizing: border-box;\r\n  position: absolute;\r\n  z-index: -1;\r\n  padding: 0;\r\n  opacity: 0;\r\n  margin: 0;\r\n}\r\nlabel.checkbox > .icon[_v-dc195ce4] {\r\n  position: absolute;\r\n  top: .2rem;\r\n  left: 0;\r\n  display: block;\r\n  width: 1.4rem;\r\n  height: 1.4rem;\r\n  line-height:1rem;\r\n  text-align: center;\r\n  -webkit-user-select: none;\r\n     -moz-user-select: none;\r\n      -ms-user-select: none;\r\n          user-select: none;\r\n  border-radius: .35rem;\r\n  background-repeat: no-repeat;\r\n  background-position: center center;\r\n  background-size: 50% 50%;\r\n}\r\nlabel.checkbox:not(.active) > .icon[_v-dc195ce4] {\r\n  background-color: #ddd;\r\n  border: 1px solid #bbb;\r\n}\r\nlabel.checkbox > input:focus ~ .icon[_v-dc195ce4] {\r\n  outline: 0;\r\n  border: 1px solid #66afe9;\r\n  box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);\r\n}\r\nlabel.checkbox.active > .icon[_v-dc195ce4] {\r\n  background-size: 1rem 1rem;\r\n  background-image: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iNyIgaGVpZ2h0PSI3Ij48cGF0aCBmaWxsPSIjZmZmIiBkPSJtNS43MywwLjUybC0zLjEyNDIyLDMuMzQxNjFsLTEuMzM4OTUsLTEuNDMyMTJsLTEuMjQ5NjksMS4zMzY2NWwyLjU4ODYzLDIuNzY4NzZsNC4zNzM5LC00LjY3ODI2bC0xLjI0OTY5LC0xLjMzNjY1bDAsMGwwLjAwMDAyLDAuMDAwMDF6Ii8+PC9zdmc+);\r\n}\r\nlabel.checkbox.active .btn-default[_v-dc195ce4] { -webkit-filter: brightness(75%); filter: brightness(75%); }\r\n\r\nlabel.checkbox.disabled[_v-dc195ce4],\r\nlabel.checkbox.readonly[_v-dc195ce4],\r\n.btn.readonly[_v-dc195ce4] {\r\n  filter: alpha(opacity=65);\r\n  box-shadow: none;\r\n  opacity: .65;\r\n}\r\nlabel.btn > input[type=checkbox][_v-dc195ce4] {\r\n  position: absolute;\r\n  clip: rect(0,0,0,0);\r\n  pointer-events: none;\r\n}", ""]);
	
	// exports


/***/ },
/* 120 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    value: {
	      default: true
	    },
	    checked: {
	      twoWay: true
	    },
	    button: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    name: {
	      type: String,
	      default: null
	    },
	    readonly: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    type: {
	      type: String,
	      default: null
	    }
	  },
	  computed: {
	    active: function active() {
	      return typeof this.value !== 'boolean' && this.group ? ~this.$parent.value.indexOf(this.value) : this.checked === this.value;
	    },
	    isButton: function isButton() {
	      return this.button || this.group && this.$parent.buttons;
	    },
	    group: function group() {
	      return this.$parent && this.$parent._checkboxGroup;
	    },
	    typeColor: function typeColor() {
	      return this.type || this.$parent && this.$parent.type || 'default';
	    }
	  },
	  watch: {
	    checked: function checked(val) {
	      if (typeof this.value !== 'boolean' && this.group) {
	        if (this.checked && !~this.$parent.value.indexOf(this.value)) this.$parent.value.push(this.value);
	        if (!this.checked && ~this.$parent.value.indexOf(this.value)) this.$parent.value.$remove(this.value);
	      }
	    }
	  },
	  created: function created() {
	    if (typeof this.value === 'boolean') {
	      return;
	    }
	    var parent = this.$parent;
	    if (parent && parent._btnGroup && !parent._radioGroup) {
	      parent._checkboxGroup = true;
	      if (!(parent.value instanceof Array)) {
	        parent.value = [];
	      }
	    }
	  },
	  ready: function ready() {
	    if (!this.$parent._checkboxGroup || typeof this.value === 'boolean') {
	      return;
	    }
	    if (this.$parent.value.length) {
	      this.checked = ~this.$parent.value.indexOf(this.value);
	    } else if (this.checked) {
	      this.$parent.value.push(this.value);
	    }
	  },
	
	  methods: {
	    eval: function _eval() {
	      if (typeof this.value !== 'boolean' && this.group) {
	        this.checked = ~this.$parent.value.indexOf(this.value);
	      }
	    },
	    focus: function focus() {
	      this.$els.input.focus();
	    },
	    toggle: function toggle() {
	      if (!this.disabled) {
	        this.focus();
	        if (!this.readonly) {
	          this.checked = this.checked ? null : this.value;
	          if (this.group && typeof this.value !== 'boolean') {
	            var index = this.$parent.value.indexOf(this.value);
	            this.$parent.value[~index ? '$remove' : 'push'](this.value);
	          }
	        }
	      }
	      return false;
	    }
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// label.checkbox {
	
	//   position: relative;
	
	//   padding-left: 18px;
	
	// }
	
	// label.checkbox > input {
	
	//   box-sizing: border-box;
	
	//   position: absolute;
	
	//   z-index: -1;
	
	//   padding: 0;
	
	//   opacity: 0;
	
	//   margin: 0;
	
	// }
	
	// label.checkbox > .icon {
	
	//   position: absolute;
	
	//   top: .2rem;
	
	//   left: 0;
	
	//   display: block;
	
	//   width: 1.4rem;
	
	//   height: 1.4rem;
	
	//   line-height:1rem;
	
	//   text-align: center;
	
	//   user-select: none;
	
	//   border-radius: .35rem;
	
	//   background-repeat: no-repeat;
	
	//   background-position: center center;
	
	//   background-size: 50% 50%;
	
	// }
	
	// label.checkbox:not(.active) > .icon {
	
	//   background-color: #ddd;
	
	//   border: 1px solid #bbb;
	
	// }
	
	// label.checkbox > input:focus ~ .icon {
	
	//   outline: 0;
	
	//   border: 1px solid #66afe9;
	
	//   box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
	
	// }
	
	// label.checkbox.active > .icon {
	
	//   background-size: 1rem 1rem;
	
	//   background-image: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iNyIgaGVpZ2h0PSI3Ij48cGF0aCBmaWxsPSIjZmZmIiBkPSJtNS43MywwLjUybC0zLjEyNDIyLDMuMzQxNjFsLTEuMzM4OTUsLTEuNDMyMTJsLTEuMjQ5NjksMS4zMzY2NWwyLjU4ODYzLDIuNzY4NzZsNC4zNzM5LC00LjY3ODI2bC0xLjI0OTY5LC0xLjMzNjY1bDAsMGwwLjAwMDAyLDAuMDAwMDF6Ii8+PC9zdmc+);
	
	// }
	
	// label.checkbox.active .btn-default { filter: brightness(75%); }
	
	
	// label.checkbox.disabled,
	
	// label.checkbox.readonly,
	
	// .btn.readonly {
	
	//   filter: alpha(opacity=65);
	
	//   box-shadow: none;
	
	//   opacity: .65;
	
	// }
	
	// label.btn > input[type=checkbox] {
	
	//   position: absolute;
	
	//   clip: rect(0,0,0,0);
	
	//   pointer-events: none;
	
	// }
	
	// </style>
	// <template>
	
	//   <label :class="[isButton?'btn btn-'+typeColor:'open checkbox '+typeColor,{active:checked,disabled:disabled,readonly:readonly}]" @click.prevent="toggle">
	
	//     <input type="checkbox" autocomplete="off"
	
	//       v-el:input
	
	//       :checked="active"
	
	//       :value="value"
	
	//       :name="name"
	
	//       :readonly="readonly"
	
	//       :disabled="disabled"
	
	//     />
	
	//     <span v-if="!isButton" class="icon dropdown-toggle" :class="[active?'btn-'+typeColor:'',{bg:typeColor==='default'}]"></span>
	
	//     <span v-if="!isButton&active&&typeColor==='default'" class="icon"></span>
	
	//     <slot></slot>
	
	//   </label>
	
	// </template>
	
	
	// <script>

/***/ },
/* 121 */
/***/ function(module, exports) {

	module.exports = "<label :class=\"[isButton?'btn btn-'+typeColor:'open checkbox '+typeColor,{active:checked,disabled:disabled,readonly:readonly}]\" @click.prevent=\"toggle\" _v-dc195ce4=\"\">\n    <input type=\"checkbox\" autocomplete=\"off\" v-el:input=\"\" :checked=\"active\" :value=\"value\" :name=\"name\" :readonly=\"readonly\" :disabled=\"disabled\" _v-dc195ce4=\"\">\n    <span v-if=\"!isButton\" class=\"icon dropdown-toggle\" :class=\"[active?'btn-'+typeColor:'',{bg:typeColor==='default'}]\" _v-dc195ce4=\"\"></span>\n    <span v-if=\"!isButton&amp;active&amp;&amp;typeColor==='default'\" class=\"icon\" _v-dc195ce4=\"\"></span>\n    <slot _v-dc195ce4=\"\"></slot>\n  </label>";

/***/ },
/* 122 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(123)
	module.exports = __webpack_require__(125)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(126)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Datepicker.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Datepicker.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Datepicker.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Datepicker.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Datepicker.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 123 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(124);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7e712e47&file=Datepicker.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Datepicker.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7e712e47&file=Datepicker.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Datepicker.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 124 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".datepicker{\r\n  position: relative;\r\n  display: inline-block;\r\n}\r\ninput.datepicker-input.with-reset-button {\r\n  padding-right: 25px;\r\n}\r\n.datepicker > button.close {\r\n  position: absolute;\r\n  top: 0;\r\n  right: 0;\r\n  outline: none;\r\n  z-index: 2;\r\n  display: block;\r\n  width: 34px;\r\n  height: 34px;\r\n  line-height: 34px;\r\n  text-align: center;\r\n}\r\n.datepicker > button.close:focus {\r\n  opacity: .2;\r\n}\r\n.datepicker-popup{\r\n  position: absolute;\r\n  border: 1px solid #ccc;\r\n  border-radius: 5px;\r\n  background: #fff;\r\n  margin-top: 2px;\r\n  z-index: 1000;\r\n  box-shadow: 0 6px 12px rgba(0,0,0,0.175);\r\n}\r\n.datepicker-inner{\r\n  width: 218px;\r\n}\r\n.datepicker-body{\r\n  padding: 10px 10px;\r\n}\r\n.datepicker-ctrl p,\r\n.datepicker-ctrl span,\r\n.datepicker-body span{\r\n  display: inline-block;\r\n  width: 28px;\r\n  line-height: 28px;\r\n  height: 28px;\r\n  border-radius: 4px;\r\n}\r\n.datepicker-ctrl p {\r\n  width: 65%;\r\n}\r\n.datepicker-ctrl span {\r\n  position: absolute;\r\n}\r\n.datepicker-body span {\r\n  text-align: center;\r\n}\r\n.datepicker-monthRange span{\r\n  width: 48px;\r\n  height: 50px;\r\n  line-height: 45px;\r\n}\r\n.datepicker-item-disable {\r\n  background-color: white!important;\r\n  cursor: not-allowed!important;\r\n}\r\n.decadeRange span:first-child,\r\n.decadeRange span:last-child,\r\n.datepicker-item-disable,\r\n.datepicker-item-gray{\r\n  color: #999;\r\n}\r\n\r\n.datepicker-dateRange-item-active:hover,\r\n.datepicker-dateRange-item-active {\r\n  background: rgb(50, 118, 177)!important;\r\n  color: white!important;\r\n}\r\n.datepicker-monthRange {\r\n  margin-top: 10px\r\n}\r\n.datepicker-monthRange span,\r\n.datepicker-ctrl span,\r\n.datepicker-ctrl p,\r\n.datepicker-dateRange span {\r\n  cursor: pointer;\r\n}\r\n.datepicker-monthRange span:hover,\r\n.datepicker-ctrl p:hover,\r\n.datepicker-ctrl i:hover,\r\n.datepicker-dateRange span:hover,\r\n.datepicker-dateRange-item-hover {\r\n  background-color : #eeeeee;\r\n}\r\n.datepicker-weekRange span{\r\n  font-weight: bold;\r\n}\r\n.datepicker-label{\r\n  background-color: #f8f8f8;\r\n  font-weight: 700;\r\n  padding: 7px 0;\r\n  text-align: center;\r\n}\r\n.datepicker-ctrl{\r\n  position: relative;\r\n  height: 30px;\r\n  line-height: 30px;\r\n  font-weight: bold;\r\n  text-align: center;\r\n}\r\n.month-btn{\r\n  font-weight: bold;\r\n  -webkit-user-select:none;\r\n  -moz-user-select:none;\r\n  -ms-user-select:none;\r\n  user-select:none;\r\n}\r\n.datepicker-preBtn{\r\n  left: 2px;\r\n}\r\n.datepicker-nextBtn{\r\n  right: 2px;\r\n}", ""]);
	
	// exports


/***/ },
/* 125 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div class="datepicker">
	
	//     <input class="form-control datepicker-input" :class="{'with-reset-button': clearButton}" type="text" :placeholder="placeholder"
	
	//         :style="{width:width}"
	
	//         @click="inputClick"
	
	//         v-model="value"/>
	
	//     <button v-if="clearButton && value" type="button" class="close" @click="value = ''">
	
	//       <span>&times;</span>
	
	//     </button>
	
	//     <div class="datepicker-popup" v-show="displayDayView">
	
	//       <div class="datepicker-inner">
	
	//         <div class="datepicker-body">
	
	//           <div class="datepicker-ctrl">
	
	//             <span class="datepicker-preBtn glyphicon glyphicon-chevron-left" aria-hidden="true" @click="preNextMonthClick(0)"></span>
	
	//             <span class="datepicker-nextBtn glyphicon glyphicon-chevron-right" aria-hidden="true" @click="preNextMonthClick(1)"></span>
	
	//             <p @click="switchMonthView">{{stringifyDayHeader(currDate)}}</p>
	
	//           </div>
	
	//           <div class="datepicker-weekRange">
	
	//             <span v-for="w in text.daysOfWeek">{{w}}</span>
	
	//           </div>
	
	//           <div class="datepicker-dateRange">
	
	//             <span v-for="d in dateRange" :class="d.sclass" @click="daySelect(d.date,this)">{{d.text}}</span>
	
	//           </div>
	
	//         </div>
	
	//       </div>
	
	//     </div>
	
	//     <div class="datepicker-popup" v-show="displayMonthView">
	
	//       <div class="datepicker-inner">
	
	//         <div class="datepicker-body">
	
	//           <div class="datepicker-ctrl">
	
	//             <span class="datepicker-preBtn glyphicon glyphicon-chevron-left" aria-hidden="true" @click="preNextYearClick(0)"></span>
	
	//             <span class="datepicker-nextBtn glyphicon glyphicon-chevron-right" aria-hidden="true" @click="preNextYearClick(1)"></span>
	
	//             <p @click="switchDecadeView">{{stringifyYearHeader(currDate)}}</p>
	
	//           </div>
	
	//           <div class="datepicker-monthRange">
	
	//             <template v-for="m in text.months">
	
	//               <span   :class="{'datepicker-dateRange-item-active':
	
	//                   (text.months[parse(value).getMonth()]  === m) &&
	
	//                   currDate.getFullYear() === parse(value).getFullYear()}"
	
	//                   @click="monthSelect($index)"
	
	//                 >{{m.substr(0,3)}}</span>
	
	//             </template>
	
	//           </div>
	
	//         </div>
	
	//       </div>
	
	//     </div>
	
	//     <div class="datepicker-popup" v-show="displayYearView">
	
	//       <div class="datepicker-inner">
	
	//         <div class="datepicker-body">
	
	//           <div class="datepicker-ctrl">
	
	//             <span class="datepicker-preBtn glyphicon glyphicon-chevron-left" aria-hidden="true" @click="preNextDecadeClick(0)"></span>
	
	//             <span class="datepicker-nextBtn glyphicon glyphicon-chevron-right" aria-hidden="true" @click="preNextDecadeClick(1)"></span>
	
	//             <p>{{stringifyDecadeHeader(currDate)}}</p>
	
	//           </div>
	
	//           <div class="datepicker-monthRange decadeRange">
	
	//             <template v-for="decade in decadeRange">
	
	//               <span :class="{'datepicker-dateRange-item-active':
	
	//                   parse(this.value).getFullYear() === decade.text}"
	
	//                   @click.stop="yearSelect(decade.text)"
	
	//                 >{{decade.text}}</span>
	
	//             </template>
	
	//           </div>
	
	//         </div>
	
	//       </div>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    value: {
	      type: String,
	      twoWay: true
	    },
	    format: {
	      default: 'MM/dd/yyyy'
	    },
	    disabledDaysOfWeek: {
	      type: Array,
	      default: function _default() {
	        return [];
	      }
	    },
	    width: {
	      type: String,
	      default: '200px'
	    },
	    clearButton: {
	      type: Boolean,
	      default: false
	    },
	    lang: {
	      type: String,
	      default: navigator.language
	    },
	    placeholder: {
	      type: String
	    }
	  },
	  ready: function ready() {
	    var _this = this;
	
	    this._blur = function (e) {
	      if (_this.$el !== null && !_this.$el.contains(e.target)) _this.close();
	    };
	    this.$dispatch('child-created', this);
	    this.currDate = this.parse(this.value) || this.parse(new Date());
	    (0, _NodeList2.default)(window).on('click', this._blur);
	  },
	  beforeDestroy: function beforeDestroy() {
	    (0, _NodeList2.default)(window).off('click', this._blur);
	  },
	  data: function data() {
	    return {
	      currDate: new Date(),
	      dateRange: [],
	      decadeRange: [],
	      displayDayView: false,
	      displayMonthView: false,
	      displayYearView: false
	    };
	  },
	
	  watch: {
	    currDate: function currDate() {
	      this.getDateRange();
	    }
	  },
	  computed: {
	    text: function text() {
	      return (0, _utils.translations)(this.lang);
	    }
	  },
	  methods: {
	    close: function close() {
	      this.displayDayView = this.displayMonthView = this.displayYearView = false;
	    },
	    inputClick: function inputClick() {
	      this.currDate = this.parse(this.value) || this.parse(new Date());
	      if (this.displayMonthView || this.displayYearView) {
	        this.displayDayView = false;
	      } else {
	        this.displayDayView = !this.displayDayView;
	      }
	    },
	    preNextDecadeClick: function preNextDecadeClick(flag) {
	      var year = this.currDate.getFullYear();
	      var months = this.currDate.getMonth();
	      var date = this.currDate.getDate();
	
	      if (flag === 0) {
	        this.currDate = new Date(year - 10, months, date);
	      } else {
	        this.currDate = new Date(year + 10, months, date);
	      }
	    },
	    preNextMonthClick: function preNextMonthClick(flag) {
	      var year = this.currDate.getFullYear();
	      var month = this.currDate.getMonth();
	      var date = this.currDate.getDate();
	
	      if (flag === 0) {
	        var preMonth = this.getYearMonth(year, month - 1);
	        this.currDate = new Date(preMonth.year, preMonth.month, date);
	      } else {
	        var nextMonth = this.getYearMonth(year, month + 1);
	        this.currDate = new Date(nextMonth.year, nextMonth.month, date);
	      }
	    },
	    preNextYearClick: function preNextYearClick(flag) {
	      var year = this.currDate.getFullYear();
	      var months = this.currDate.getMonth();
	      var date = this.currDate.getDate();
	
	      if (flag === 0) {
	        this.currDate = new Date(year - 1, months, date);
	      } else {
	        this.currDate = new Date(year + 1, months, date);
	      }
	    },
	    yearSelect: function yearSelect(year) {
	      this.displayYearView = false;
	      this.displayMonthView = true;
	      this.currDate = new Date(year, this.currDate.getMonth(), this.currDate.getDate());
	    },
	    daySelect: function daySelect(date, el) {
	      if (el.$el.classList[0] === 'datepicker-item-disable') {
	        return false;
	      } else {
	        this.currDate = date;
	        this.value = this.stringify(this.currDate);
	        this.displayDayView = false;
	      }
	    },
	    switchMonthView: function switchMonthView() {
	      this.displayDayView = false;
	      this.displayMonthView = true;
	    },
	    switchDecadeView: function switchDecadeView() {
	      this.displayMonthView = false;
	      this.displayYearView = true;
	    },
	    monthSelect: function monthSelect(index) {
	      this.displayMonthView = false;
	      this.displayDayView = true;
	      this.currDate = new Date(this.currDate.getFullYear(), index, this.currDate.getDate());
	    },
	    getYearMonth: function getYearMonth(year, month) {
	      if (month > 11) {
	        year++;
	        month = 0;
	      } else if (month < 0) {
	        year--;
	        month = 11;
	      }
	      return { year: year, month: month };
	    },
	    stringifyDecadeHeader: function stringifyDecadeHeader(date) {
	      var yearStr = date.getFullYear().toString();
	      var firstYearOfDecade = yearStr.substring(0, yearStr.length - 1) + 0;
	      var lastYearOfDecade = parseInt(firstYearOfDecade, 10) + 10;
	      return firstYearOfDecade + '-' + lastYearOfDecade;
	    },
	    stringifyDayHeader: function stringifyDayHeader(date) {
	      return this.text.months[date.getMonth()] + ' ' + date.getFullYear();
	    },
	    parseMonth: function parseMonth(date) {
	      return this.text.months[date.getMonth()];
	    },
	    stringifyYearHeader: function stringifyYearHeader(date) {
	      return date.getFullYear();
	    },
	    stringify: function stringify(date) {
	      var format = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : this.format;
	
	      if (!date) date = this.parse();
	      if (!date) return '';
	      var year = date.getFullYear();
	      var month = date.getMonth() + 1;
	      var day = date.getDate();
	      var monthName = this.parseMonth(date);
	
	      return format.replace(/yyyy/g, year).replace(/MMMM/g, monthName).replace(/MMM/g, monthName.substring(0, 3)).replace(/MM/g, ('0' + month).slice(-2)).replace(/dd/g, ('0' + day).slice(-2)).replace(/yy/g, year).replace(/M(?!a)/g, month).replace(/d/g, day);
	    },
	    parse: function parse() {
	      var str = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : this.value;
	
	      var date = void 0;
	      if (str.length === 10 && (this.format === 'dd-MM-yyyy' || this.format === 'dd/MM/yyyy')) {
	        date = new Date(str.substring(6, 10), str.substring(3, 5) - 1, str.substring(0, 2));
	      } else {
	        date = new Date(str);
	      }
	      return isNaN(date.getFullYear()) ? new Date() : date;
	    },
	    getDayCount: function getDayCount(year, month) {
	      var dict = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
	      if (month === 1) {
	        if (year % 400 === 0 || year % 4 === 0 && year % 100 !== 0) {
	          return 29;
	        }
	      }
	      return dict[month];
	    },
	    getDateRange: function getDateRange() {
	      var _this2 = this;
	
	      this.dateRange = [];
	      this.decadeRange = [];
	      var time = {
	        year: this.currDate.getFullYear(),
	        month: this.currDate.getMonth(),
	        day: this.currDate.getDate()
	      };
	      var yearStr = time.year.toString();
	      var firstYearOfDecade = yearStr.substring(0, yearStr.length - 1) + 0 - 1;
	      for (var i = 0; i < 12; i++) {
	        this.decadeRange.push({
	          text: firstYearOfDecade + i
	        });
	      }
	
	      var currMonthFirstDay = new Date(time.year, time.month, 1);
	      var firstDayWeek = currMonthFirstDay.getDay() + 1;
	      if (firstDayWeek === 0) {
	        firstDayWeek = 7;
	      }
	      var dayCount = this.getDayCount(time.year, time.month);
	      if (firstDayWeek > 1) {
	        var preMonth = this.getYearMonth(time.year, time.month - 1);
	        var prevMonthDayCount = this.getDayCount(preMonth.year, preMonth.month);
	        for (var _i = 1; _i < firstDayWeek; _i++) {
	          var dayText = prevMonthDayCount - firstDayWeek + _i + 1;
	          this.dateRange.push({
	            text: dayText,
	            date: new Date(preMonth.year, preMonth.month, dayText),
	            sclass: 'datepicker-item-gray'
	          });
	        }
	      }
	
	      var _loop = function _loop(_i2) {
	        var date = new Date(time.year, time.month, _i2);
	        var week = date.getDay();
	        var sclass = '';
	        _this2.disabledDaysOfWeek.forEach(function (el) {
	          if (week === parseInt(el, 10)) sclass = 'datepicker-item-disable';
	        });
	        if (_i2 === time.day) {
	          if (_this2.value) {
	            var valueDate = _this2.parse(_this2.value);
	            if (valueDate) {
	              if (valueDate.getFullYear() === time.year && valueDate.getMonth() === time.month) {
	                sclass = 'datepicker-dateRange-item-active';
	              }
	            }
	          }
	        }
	        _this2.dateRange.push({
	          text: _i2,
	          date: date,
	          sclass: sclass
	        });
	      };
	
	      for (var _i2 = 1; _i2 <= dayCount; _i2++) {
	        _loop(_i2);
	      }
	
	      if (this.dateRange.length < 42) {
	        var nextMonthNeed = 42 - this.dateRange.length;
	        var nextMonth = this.getYearMonth(time.year, time.month + 1);
	
	        for (var _i3 = 1; _i3 <= nextMonthNeed; _i3++) {
	          this.dateRange.push({
	            text: _i3,
	            date: new Date(nextMonth.year, nextMonth.month, _i3),
	            sclass: 'datepicker-item-gray'
	          });
	        }
	      }
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .datepicker{
	
	//   position: relative;
	
	//   display: inline-block;
	
	// }
	
	// input.datepicker-input.with-reset-button {
	
	//   padding-right: 25px;
	
	// }
	
	// .datepicker > button.close {
	
	//   position: absolute;
	
	//   top: 0;
	
	//   right: 0;
	
	//   outline: none;
	
	//   z-index: 2;
	
	//   display: block;
	
	//   width: 34px;
	
	//   height: 34px;
	
	//   line-height: 34px;
	
	//   text-align: center;
	
	// }
	
	// .datepicker > button.close:focus {
	
	//   opacity: .2;
	
	// }
	
	// .datepicker-popup{
	
	//   position: absolute;
	
	//   border: 1px solid #ccc;
	
	//   border-radius: 5px;
	
	//   background: #fff;
	
	//   margin-top: 2px;
	
	//   z-index: 1000;
	
	//   box-shadow: 0 6px 12px rgba(0,0,0,0.175);
	
	// }
	
	// .datepicker-inner{
	
	//   width: 218px;
	
	// }
	
	// .datepicker-body{
	
	//   padding: 10px 10px;
	
	// }
	
	// .datepicker-ctrl p,
	
	// .datepicker-ctrl span,
	
	// .datepicker-body span{
	
	//   display: inline-block;
	
	//   width: 28px;
	
	//   line-height: 28px;
	
	//   height: 28px;
	
	//   border-radius: 4px;
	
	// }
	
	// .datepicker-ctrl p {
	
	//   width: 65%;
	
	// }
	
	// .datepicker-ctrl span {
	
	//   position: absolute;
	
	// }
	
	// .datepicker-body span {
	
	//   text-align: center;
	
	// }
	
	// .datepicker-monthRange span{
	
	//   width: 48px;
	
	//   height: 50px;
	
	//   line-height: 45px;
	
	// }
	
	// .datepicker-item-disable {
	
	//   background-color: white!important;
	
	//   cursor: not-allowed!important;
	
	// }
	
	// .decadeRange span:first-child,
	
	// .decadeRange span:last-child,
	
	// .datepicker-item-disable,
	
	// .datepicker-item-gray{
	
	//   color: #999;
	
	// }
	
	
	// .datepicker-dateRange-item-active:hover,
	
	// .datepicker-dateRange-item-active {
	
	//   background: rgb(50, 118, 177)!important;
	
	//   color: white!important;
	
	// }
	
	// .datepicker-monthRange {
	
	//   margin-top: 10px
	
	// }
	
	// .datepicker-monthRange span,
	
	// .datepicker-ctrl span,
	
	// .datepicker-ctrl p,
	
	// .datepicker-dateRange span {
	
	//   cursor: pointer;
	
	// }
	
	// .datepicker-monthRange span:hover,
	
	// .datepicker-ctrl p:hover,
	
	// .datepicker-ctrl i:hover,
	
	// .datepicker-dateRange span:hover,
	
	// .datepicker-dateRange-item-hover {
	
	//   background-color : #eeeeee;
	
	// }
	
	// .datepicker-weekRange span{
	
	//   font-weight: bold;
	
	// }
	
	// .datepicker-label{
	
	//   background-color: #f8f8f8;
	
	//   font-weight: 700;
	
	//   padding: 7px 0;
	
	//   text-align: center;
	
	// }
	
	// .datepicker-ctrl{
	
	//   position: relative;
	
	//   height: 30px;
	
	//   line-height: 30px;
	
	//   font-weight: bold;
	
	//   text-align: center;
	
	// }
	
	// .month-btn{
	
	//   font-weight: bold;
	
	//   -webkit-user-select:none;
	
	//   -moz-user-select:none;
	
	//   -ms-user-select:none;
	
	//   user-select:none;
	
	// }
	
	// .datepicker-preBtn{
	
	//   left: 2px;
	
	// }
	
	// .datepicker-nextBtn{
	
	//   right: 2px;
	
	// }
	
	// </style>

/***/ },
/* 126 */
/***/ function(module, exports) {

	module.exports = "<div class=\"datepicker\">\r\n    <input class=\"form-control datepicker-input\" :class=\"{'with-reset-button': clearButton}\" type=\"text\" :placeholder=\"placeholder\"\r\n        :style=\"{width:width}\"\r\n        @click=\"inputClick\"\r\n        v-model=\"value\"/>\r\n    <button v-if=\"clearButton && value\" type=\"button\" class=\"close\" @click=\"value = ''\">\r\n      <span>&times;</span>\r\n    </button>\r\n    <div class=\"datepicker-popup\" v-show=\"displayDayView\">\r\n      <div class=\"datepicker-inner\">\r\n        <div class=\"datepicker-body\">\r\n          <div class=\"datepicker-ctrl\">\r\n            <span class=\"datepicker-preBtn glyphicon glyphicon-chevron-left\" aria-hidden=\"true\" @click=\"preNextMonthClick(0)\"></span>\r\n            <span class=\"datepicker-nextBtn glyphicon glyphicon-chevron-right\" aria-hidden=\"true\" @click=\"preNextMonthClick(1)\"></span>\r\n            <p @click=\"switchMonthView\">{{stringifyDayHeader(currDate)}}</p>\r\n          </div>\r\n          <div class=\"datepicker-weekRange\">\r\n            <span v-for=\"w in text.daysOfWeek\">{{w}}</span>\r\n          </div>\r\n          <div class=\"datepicker-dateRange\">\r\n            <span v-for=\"d in dateRange\" :class=\"d.sclass\" @click=\"daySelect(d.date,this)\">{{d.text}}</span>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"datepicker-popup\" v-show=\"displayMonthView\">\r\n      <div class=\"datepicker-inner\">\r\n        <div class=\"datepicker-body\">\r\n          <div class=\"datepicker-ctrl\">\r\n            <span class=\"datepicker-preBtn glyphicon glyphicon-chevron-left\" aria-hidden=\"true\" @click=\"preNextYearClick(0)\"></span>\r\n            <span class=\"datepicker-nextBtn glyphicon glyphicon-chevron-right\" aria-hidden=\"true\" @click=\"preNextYearClick(1)\"></span>\r\n            <p @click=\"switchDecadeView\">{{stringifyYearHeader(currDate)}}</p>\r\n          </div>\r\n          <div class=\"datepicker-monthRange\">\r\n            <template v-for=\"m in text.months\">\r\n              <span   :class=\"{'datepicker-dateRange-item-active':\r\n                  (text.months[parse(value).getMonth()]  === m) &&\r\n                  currDate.getFullYear() === parse(value).getFullYear()}\"\r\n                  @click=\"monthSelect($index)\"\r\n                >{{m.substr(0,3)}}</span>\r\n            </template>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <div class=\"datepicker-popup\" v-show=\"displayYearView\">\r\n      <div class=\"datepicker-inner\">\r\n        <div class=\"datepicker-body\">\r\n          <div class=\"datepicker-ctrl\">\r\n            <span class=\"datepicker-preBtn glyphicon glyphicon-chevron-left\" aria-hidden=\"true\" @click=\"preNextDecadeClick(0)\"></span>\r\n            <span class=\"datepicker-nextBtn glyphicon glyphicon-chevron-right\" aria-hidden=\"true\" @click=\"preNextDecadeClick(1)\"></span>\r\n            <p>{{stringifyDecadeHeader(currDate)}}</p>\r\n          </div>\r\n          <div class=\"datepicker-monthRange decadeRange\">\r\n            <template v-for=\"decade in decadeRange\">\r\n              <span :class=\"{'datepicker-dateRange-item-active':\r\n                  parse(this.value).getFullYear() === decade.text}\"\r\n                  @click.stop=\"yearSelect(decade.text)\"\r\n                >{{decade.text}}</span>\r\n            </template>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>";

/***/ },
/* 127 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(128)
	module.exports = __webpack_require__(130)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(131)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Dropdown.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Dropdown.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-628ea2dc&file=Dropdown.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Dropdown.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Dropdown.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-628ea2dc&file=Dropdown.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Dropdown.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 128 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(129);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-628ea2dc&file=Dropdown.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Dropdown.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-628ea2dc&file=Dropdown.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Dropdown.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 129 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".secret[_v-628ea2dc] {\r\n  position: absolute;\r\n  clip: rect(0 0 0 0);\r\n  overflow: hidden;\r\n  margin: -1px;\r\n  height: 1px;\r\n  width: 1px;\r\n  padding: 0;\r\n  border: 0;\r\n}", ""]);
	
	// exports


/***/ },
/* 130 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <li v-if="isLi" v-el:dropdown :class="classes">
	
	//     <slot name="button">
	
	//       <a class="dropdown-toggle" role="button" :class="{disabled: disabled}" @keyup.esc="show = false">
	
	//         {{ text }}
	
	//         <span class="caret"></span>
	
	//       </a>
	
	//     </slot>
	
	//     <slot name="dropdown-menu">
	
	//       <ul v-else class="dropdown-menu">
	
	//         <slot></slot>
	
	//       </ul>
	
	//     </slot>
	
	//   </li>
	
	//   <div v-else v-el:dropdown :class="classes">
	
	//     <slot name="before"></slot>
	
	//     <slot name="button">
	
	//       <button type="button" class="btn btn-{{type}} dropdown-toggle" @keyup.esc="show = false" :disabled="disabled">
	
	//         {{ text }}
	
	//         <span class="caret"></span>
	
	//       </button>
	
	//     </slot>
	
	//     <slot name="dropdown-menu">
	
	//       <ul class="dropdown-menu">
	
	//         <slot></slot>
	
	//       </ul>
	
	//     </slot>
	
	//   </div>
	
	// </template>
	
	// <script>
	exports.default = {
	  props: {
	    show: {
	      twoWay: true,
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    'class': null,
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    text: {
	      type: String,
	      default: null
	    },
	    type: {
	      type: String,
	      default: 'default'
	    }
	  },
	  computed: {
	    classes: function classes() {
	      return [{ open: this.show, disabled: this.disabled }, this.class, this.isLi ? 'dropdown' : this.inInput ? 'input-group-btn' : 'btn-group'];
	    },
	    inInput: function inInput() {
	      return this.$parent._input;
	    },
	    isLi: function isLi() {
	      return this.$parent._navbar || this.$parent.menu || this.$parent._tabset;
	    },
	    menu: function menu() {
	      return !this.$parent || this.$parent.navbar;
	    },
	    submenu: function submenu() {
	      return this.$parent && (this.$parent.menu || this.$parent.submenu);
	    },
	    slots: function slots() {
	      return this._slotContents;
	    }
	  },
	  methods: {
	    blur: function blur() {
	      var _this = this;
	
	      this.unblur();
	      this._hide = setTimeout(function () {
	        _this._hide = null;
	        _this.show = false;
	      }, 100);
	    },
	    unblur: function unblur() {
	      if (this._hide) {
	        clearTimeout(this._hide);
	        this._hide = null;
	      }
	    }
	  },
	  ready: function ready() {
	    var _this2 = this;
	
	    var $el = (0, _NodeList2.default)(this.$els.dropdown);
	    $el.onBlur(function (e) {
	      _this2.show = false;
	    });
	    $el.findChildren('a,button.dropdown-toggle').on('click', function (e) {
	      e.preventDefault();
	      if (_this2.disabled) {
	        return false;
	      }
	      _this2.show = !_this2.show;
	      return false;
	    });
	    $el.findChildren('ul').on('click', 'li>a', function (e) {
	      _this2.show = false;
	    });
	  },
	  beforeDestroy: function beforeDestroy() {
	    var $el = (0, _NodeList2.default)(this.$els.dropdown);
	    $el.offBlur();
	    $el.findChildren('a,button').off();
	    $el.findChildren('ul').off();
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// .secret {
	
	//   position: absolute;
	
	//   clip: rect(0 0 0 0);
	
	//   overflow: hidden;
	
	//   margin: -1px;
	
	//   height: 1px;
	
	//   width: 1px;
	
	//   padding: 0;
	
	//   border: 0;
	
	// }
	
	// </style>

/***/ },
/* 131 */
/***/ function(module, exports) {

	module.exports = "<li v-if=\"isLi\" v-el:dropdown=\"\" :class=\"classes\" _v-628ea2dc=\"\">\n    <slot name=\"button\" _v-628ea2dc=\"\">\n      <a class=\"dropdown-toggle\" role=\"button\" :class=\"{disabled: disabled}\" @keyup.esc=\"show = false\" _v-628ea2dc=\"\">\n        {{ text }}\n        <span class=\"caret\" _v-628ea2dc=\"\"></span>\n      </a>\n    </slot>\n    <slot name=\"dropdown-menu\" _v-628ea2dc=\"\">\n      <ul v-else=\"\" class=\"dropdown-menu\" _v-628ea2dc=\"\">\n        <slot _v-628ea2dc=\"\"></slot>\n      </ul>\n    </slot>\n  </li>\n  <div v-else=\"\" v-el:dropdown=\"\" :class=\"classes\" _v-628ea2dc=\"\">\n    <slot name=\"before\" _v-628ea2dc=\"\"></slot>\n    <slot name=\"button\" _v-628ea2dc=\"\">\n      <button type=\"button\" class=\"btn btn-{{type}} dropdown-toggle\" @keyup.esc=\"show = false\" :disabled=\"disabled\" _v-628ea2dc=\"\">\n        {{ text }}\n        <span class=\"caret\" _v-628ea2dc=\"\"></span>\n      </button>\n    </slot>\n    <slot name=\"dropdown-menu\" _v-628ea2dc=\"\">\n      <ul class=\"dropdown-menu\" _v-628ea2dc=\"\">\n        <slot _v-628ea2dc=\"\"></slot>\n      </ul>\n    </slot>\n  </div>";

/***/ },
/* 132 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(133)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(134)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./FormGroup.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./FormGroup.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./FormGroup.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./FormGroup.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./FormGroup.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 133 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <slot></slot>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    valid: {
	      twoWay: true,
	      default: null
	    },
	    enterSubmit: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    icon: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    lang: {
	      type: String,
	      default: navigator.language
	    }
	  },
	  data: function data() {
	    return {
	      children: [],
	      timeout: null
	    };
	  },
	
	  watch: {
	    valid: function valid(val, old) {
	      if (val === old) {
	        return;
	      }
	      this._parent && this._parent.validate();
	    }
	  },
	  methods: {
	    focus: function focus() {
	      this.$els.input.focus();
	    },
	    validate: function validate() {
	      var valid = true;
	      this.children.some(function (el) {
	        var v = el.validate ? el.validate() : el.valid !== undefined ? el.valid : el.required && !~['', null, undefined].indexOf(el.value);
	        if (!v) valid = false;
	        return !valid;
	      });
	      this.valid = valid;
	      return valid === true;
	    }
	  },
	  created: function created() {
	    this._formGroup = true;
	    var parent = this.$parent;
	    while (parent && !parent._formGroup) {
	      parent = parent.$parent;
	    }
	    if (parent && parent._formGroup) {
	      parent.children.push(this);
	      this._parent = parent;
	    }
	  },
	  ready: function ready() {
	    this.validate();
	  },
	  beforeDestroy: function beforeDestroy() {
	    if (this._parent) this._parent.children.$remove(this);
	  }
	};
	// </script>

/***/ },
/* 134 */
/***/ function(module, exports) {

	module.exports = "<slot></slot>";

/***/ },
/* 135 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(136)
	module.exports = __webpack_require__(138)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(139)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Input.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Input.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-461124e2&file=Input.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Input.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Input.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-461124e2&file=Input.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Input.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 136 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(137);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-461124e2&file=Input.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Input.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-461124e2&file=Input.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Input.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 137 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".form-group[_v-461124e2] {\r\n  position: relative;\r\n}\r\nlabel~.close[_v-461124e2] {\r\n  top: 25px;\r\n}\r\n.input-group>.icon[_v-461124e2] {\r\n  position: relative;\r\n  display: table-cell;\r\n  width:0;\r\n  z-index: 3;\r\n}\r\n.close[_v-461124e2] {\r\n  position: absolute;\r\n  top: 0;\r\n  right: 0;\r\n  z-index: 2;\r\n  display: block;\r\n  width: 34px;\r\n  height: 34px;\r\n  line-height: 34px;\r\n  text-align: center;\r\n}\r\n.has-feedback .close[_v-461124e2] {\r\n  right: 20px;\r\n}", ""]);
	
	// exports


/***/ },
/* 138 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div class="form-group" :class="{validate:canValidate,'has-feedback':icon,'has-error':canValidate&&valid===false,'has-success':canValidate&&valid}">
	
	//     <slot name="label"><label v-if="label" class="control-label" @click="focus">{{label}}</label></slot>
	
	//     <div v-if="slots.before||slots.after" class="input-group">
	
	//       <slot name="before"></slot>
	
	//       <textarea v-if="type=='textarea'" class="form-control" v-el:input v-model="value"
	
	//         :cols="cols"
	
	//         :rows="rows"
	
	//         :name="name"
	
	//         :title="attr(title)"
	
	//         :readonly="readonly"
	
	//         :required="required"
	
	//         :disabled="disabled"
	
	//         :maxlength="maxlength"
	
	//         :placeholder="placeholder"
	
	//         @blur="onblur" @focus="onfocus"
	
	//       ></textarea>
	
	//       <input v-else class="form-control" v-el:input v-model="value"
	
	//         :name="name"
	
	//         :max="attr(max)"
	
	//         :min="attr(min)"
	
	//         :step="step"
	
	//         :type="type"
	
	//         :title="attr(title)"
	
	//         :readonly="readonly"
	
	//         :required="required"
	
	//         :disabled="disabled"
	
	//         :maxlength="maxlength"
	
	//         :placeholder="placeholder"
	
	//         @keyup.enter="enterSubmit&&submit()"
	
	//         @blur="onblur" @focus="onfocus"
	
	//       />
	
	//       <div v-if="showClear && value" :class="{icon:icon}">
	
	//         <span class="close" @click="value = ''">&times;</span>
	
	//       </div>
	
	//       <div v-if="icon" class="icon">
	
	//         <span v-if="icon&&valid!==null" :class="['form-control-feedback glyphicon','glyphicon-'+(valid?'ok':'remove')]" aria-hidden="true"></span>
	
	//       </div>
	
	//       <slot name="after"></slot>
	
	//     </div>
	
	//     <template v-else>
	
	//       <textarea v-if="type=='textarea'" class="form-control" v-el:input v-model="value"
	
	//         :cols="cols"
	
	//         :rows="rows"
	
	//         :name="name"
	
	//         :title="attr(title)"
	
	//         :readonly="readonly"
	
	//         :required="required"
	
	//         :disabled="disabled"
	
	//         :maxlength="maxlength"
	
	//         :placeholder="placeholder"
	
	//         @blur="onblur" @focus="onfocus"
	
	//       ></textarea>
	
	//       <input v-else class="form-control" v-el:input v-model="value"
	
	//         :name="name"
	
	//         :max="attr(max)"
	
	//         :min="attr(min)"
	
	//         :step="step"
	
	//         :type="type"
	
	//         :title="attr(title)"
	
	//         :readonly="readonly"
	
	//         :required="required"
	
	//         :disabled="disabled"
	
	//         :maxlength="maxlength"
	
	//         :placeholder="placeholder"
	
	//         @keyup.enter="enterSubmit&&submit()"
	
	//         @blur="onblur" @focus="onfocus"
	
	//       />
	
	//       <span v-if="showClear && value" class="close" @click="value = ''">&times;</span>
	
	//       <span v-if="icon&&valid!==null" :class="['form-control-feedback glyphicon','glyphicon-'+(valid?'ok':'remove')]" aria-hidden="true"></span>
	
	//     </template>
	
	//     <div v-if="showHelp" class="help-block" @click="focus">{{help}}</div>
	
	//     <div v-if="showError" class="help-block with-errors" @click="focus">{{errorText}}</div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    value: {
	      twoWay: true,
	      default: null
	    },
	    match: {
	      type: String,
	      default: null
	    },
	    clearButton: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    enterSubmit: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    error: {
	      type: String,
	      default: null
	    },
	    help: {
	      type: String,
	      default: null
	    },
	    hideHelp: { // hide when have error
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    icon: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    label: {
	      type: String,
	      default: null
	    },
	    lang: {
	      type: String,
	      default: navigator.language
	    },
	    mask: null,
	    maskDelay: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 100
	    },
	    max: {
	      type: String,
	      coerce: _utils.coerce.string,
	      default: null
	    },
	    maxlength: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: null
	    },
	    min: {
	      type: String,
	      coerce: _utils.coerce.string,
	      default: null
	    },
	    minlength: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 0
	    },
	    name: {
	      type: String,
	      default: null
	    },
	    pattern: {
	      coerce: _utils.coerce.pattern,
	      default: null
	    },
	    placeholder: {
	      type: String,
	      default: null
	    },
	    readonly: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    required: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    rows: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 3
	    },
	    step: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: null
	    },
	    type: {
	      type: String,
	      default: 'text'
	    },
	    validationDelay: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 250
	    }
	  },
	  data: function data() {
	    return {
	      valid: null,
	      timeout: null
	    };
	  },
	
	  computed: {
	    canValidate: function canValidate() {
	      return !this.disabled && !this.readonly && (this.required || this.pattern || this.nativeValidate || this.match !== null);
	    },
	    errorText: function errorText() {
	      var value = this.value;
	      var error = [this.error];
	      if (!value && this.required) error.push('(' + this.text.required.toLowerCase() + ')');
	      if (value && value.length < this.minlength) error.push('(' + this.text.minLength.toLowerCase() + ': ' + this.minlength + ')');
	      return error.join(' ');
	    },
	    input: function input() {
	      return this.$els.input;
	    },
	    nativeValidate: function nativeValidate() {
	      return (this.input || {}).checkValidity && (~['url', 'email'].indexOf(this.type.toLowerCase()) || this.min || this.max);
	    },
	    showClear: function showClear() {
	      // Disable the clear-button on Edge if is enabled. Edge has a native clear button.
	      return (/\bEdge\//.test(window.navigator.userAgent) ? false : this.clearButton
	      );
	    },
	    showError: function showError() {
	      return this.error && this.valid === false;
	    },
	    showHelp: function showHelp() {
	      return this.help && (!this.showError || !this.hideHelp);
	    },
	    slots: function slots() {
	      return this._slotContents || {};
	    },
	    text: function text() {
	      return (0, _utils.translations)(this.lang);
	    },
	    title: function title() {
	      return this.errorText || this.help || '';
	    }
	  },
	  watch: {
	    match: function match(val) {
	      this.eval();
	    },
	    valid: function valid(val, old) {
	      if (val !== old) {
	        this._parent && this._parent.validate();
	      }
	    },
	    value: function value(val, old) {
	      var _this = this;
	
	      if (val !== old) {
	        if (this.mask instanceof Function) {
	          val = this.mask(val || '');
	          if (this.value !== val) {
	            if (this._timeout.mask) clearTimeout(this._timeout.mask);
	            this._timeout.mask = setTimeout(function () {
	              _this.value = val;
	              _this.$els.input.value = val;
	            }, this.maskDelay);
	          }
	        }
	        this.eval();
	      }
	    }
	  },
	  methods: {
	    attr: function attr(value) {
	      return ~['', null, undefined].indexOf(value) || value instanceof Function ? undefined : value;
	    },
	    focus: function focus() {
	      this.input.focus();
	    },
	    eval: function _eval() {
	      var _this2 = this;
	
	      if (this._timeout.eval) clearTimeout(this._timeout.eval);
	      if (!this.canValidate) {
	        this.valid = true;
	      } else {
	        this._timeout.eval = setTimeout(function () {
	          _this2.valid = _this2.validate();
	          _this2._timeout.eval = null;
	        }, this.validationDelay);
	      }
	    },
	    onblur: function onblur(e) {
	      if (this.canValidate) {
	        this.valid = this.validate();
	      }
	      this.$emit('blur', e);
	    },
	    onfocus: function onfocus(e) {
	      this.$emit('focus', e);
	    },
	    submit: function submit() {
	      if (this.$parent._formGroup) {
	        return this.$parent.validate();
	      }
	      if (this.input.form) {
	        var invalids = (0, _NodeList2.default)('.form-group.validate:not(.has-success)', this.input.form);
	        if (invalids.length) {
	          invalids.find('input,textarea,select')[0].focus();
	        } else {
	          this.input.form.submit();
	        }
	      }
	    },
	    validate: function validate() {
	      if (!this.canValidate) {
	        return true;
	      }
	      var value = (this.value || '').trim();
	      if (!value) {
	        return !this.required;
	      }
	      if (this.match !== null) {
	        return this.match === value;
	      }
	      if (value.length < this.minlength) {
	        return false;
	      }
	      if (this.nativeValidate && !this.input.checkValidity()) {
	        return false;
	      }
	      if (this.pattern) {
	        return this.pattern instanceof Function ? this.pattern(this.value) : this.pattern.test(this.value);
	      }
	      return true;
	    }
	  },
	  created: function created() {
	    this._input = true;
	    this._timeout = {};
	    var parent = this.$parent;
	    while (parent && !parent._formGroup) {
	      parent = parent.$parent;
	    }
	    if (parent && parent._formGroup) {
	      this._parent = parent;
	    }
	  },
	  ready: function ready() {
	    var _this3 = this;
	
	    this._parent && this._parent.children.push(this);
	    (0, _NodeList2.default)(this.input).on('focus', function (e) {
	      return _this3.$emit('focus', e);
	    }).on('blur', function (e) {
	      if (_this3.canValidate) {
	        _this3.valid = _this3.validate();
	      }
	      _this3.$emit('blur', e);
	    });
	  },
	  beforeDestroy: function beforeDestroy() {
	    this._parent && this._parent.children.$remove(this);
	    (0, _NodeList2.default)(this.input).off();
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// .form-group {
	
	//   position: relative;
	
	// }
	
	// label~.close {
	
	//   top: 25px;
	
	// }
	
	// .input-group>.icon {
	
	//   position: relative;
	
	//   display: table-cell;
	
	//   width:0;
	
	//   z-index: 3;
	
	// }
	
	// .close {
	
	//   position: absolute;
	
	//   top: 0;
	
	//   right: 0;
	
	//   z-index: 2;
	
	//   display: block;
	
	//   width: 34px;
	
	//   height: 34px;
	
	//   line-height: 34px;
	
	//   text-align: center;
	
	// }
	
	// .has-feedback .close {
	
	//   right: 20px;
	
	// }
	
	// </style>

/***/ },
/* 139 */
/***/ function(module, exports) {

	module.exports = "<div class=\"form-group\" :class=\"{validate:canValidate,'has-feedback':icon,'has-error':canValidate&amp;&amp;valid===false,'has-success':canValidate&amp;&amp;valid}\" _v-461124e2=\"\">\n    <slot name=\"label\" _v-461124e2=\"\"><label v-if=\"label\" class=\"control-label\" @click=\"focus\" _v-461124e2=\"\">{{label}}</label></slot>\n    <div v-if=\"slots.before||slots.after\" class=\"input-group\" _v-461124e2=\"\">\n      <slot name=\"before\" _v-461124e2=\"\"></slot>\n      <textarea v-if=\"type=='textarea'\" class=\"form-control\" v-el:input=\"\" v-model=\"value\" :cols=\"cols\" :rows=\"rows\" :name=\"name\" :title=\"attr(title)\" :readonly=\"readonly\" :required=\"required\" :disabled=\"disabled\" :maxlength=\"maxlength\" :placeholder=\"placeholder\" @blur=\"onblur\" @focus=\"onfocus\" _v-461124e2=\"\"></textarea>\n      <input v-else=\"\" class=\"form-control\" v-el:input=\"\" v-model=\"value\" :name=\"name\" :max=\"attr(max)\" :min=\"attr(min)\" :step=\"step\" :type=\"type\" :title=\"attr(title)\" :readonly=\"readonly\" :required=\"required\" :disabled=\"disabled\" :maxlength=\"maxlength\" :placeholder=\"placeholder\" @keyup.enter=\"enterSubmit&amp;&amp;submit()\" @blur=\"onblur\" @focus=\"onfocus\" _v-461124e2=\"\">\n      <div v-if=\"showClear &amp;&amp; value\" :class=\"{icon:icon}\" _v-461124e2=\"\">\n        <span class=\"close\" @click=\"value = ''\" _v-461124e2=\"\">×</span>\n      </div>\n      <div v-if=\"icon\" class=\"icon\" _v-461124e2=\"\">\n        <span v-if=\"icon&amp;&amp;valid!==null\" :class=\"['form-control-feedback glyphicon','glyphicon-'+(valid?'ok':'remove')]\" aria-hidden=\"true\" _v-461124e2=\"\"></span>\n      </div>\n      <slot name=\"after\" _v-461124e2=\"\"></slot>\n    </div>\n    <template v-else=\"\" _v-461124e2=\"\">\n      <textarea v-if=\"type=='textarea'\" class=\"form-control\" v-el:input=\"\" v-model=\"value\" :cols=\"cols\" :rows=\"rows\" :name=\"name\" :title=\"attr(title)\" :readonly=\"readonly\" :required=\"required\" :disabled=\"disabled\" :maxlength=\"maxlength\" :placeholder=\"placeholder\" @blur=\"onblur\" @focus=\"onfocus\" _v-461124e2=\"\"></textarea>\n      <input v-else=\"\" class=\"form-control\" v-el:input=\"\" v-model=\"value\" :name=\"name\" :max=\"attr(max)\" :min=\"attr(min)\" :step=\"step\" :type=\"type\" :title=\"attr(title)\" :readonly=\"readonly\" :required=\"required\" :disabled=\"disabled\" :maxlength=\"maxlength\" :placeholder=\"placeholder\" @keyup.enter=\"enterSubmit&amp;&amp;submit()\" @blur=\"onblur\" @focus=\"onfocus\" _v-461124e2=\"\">\n      <span v-if=\"showClear &amp;&amp; value\" class=\"close\" @click=\"value = ''\" _v-461124e2=\"\">×</span>\n      <span v-if=\"icon&amp;&amp;valid!==null\" :class=\"['form-control-feedback glyphicon','glyphicon-'+(valid?'ok':'remove')]\" aria-hidden=\"true\" _v-461124e2=\"\"></span>\n    </template>\n    <div v-if=\"showHelp\" class=\"help-block\" @click=\"focus\" _v-461124e2=\"\">{{help}}</div>\n    <div v-if=\"showError\" class=\"help-block with-errors\" @click=\"focus\" _v-461124e2=\"\">{{errorText}}</div>\n  </div>";

/***/ },
/* 140 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(141)
	module.exports = __webpack_require__(143)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(148)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Modal.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Modal.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Modal.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Modal.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Modal.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 141 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(142);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-0ee4321c&file=Modal.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Modal.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-0ee4321c&file=Modal.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Modal.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 142 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".modal {\r\n  -webkit-transition: all 0.3s ease;\r\n  transition: all 0.3s ease;\r\n}\r\n.modal.in {\r\n  background-color: rgba(0,0,0,0.5);\r\n}\r\n.modal.zoom .modal-dialog {\r\n  -webkit-transform: scale(0.1);\r\n  transform: scale(0.1);\r\n  top: 300px;\r\n  opacity: 0;\r\n  -webkit-transition: all 0.3s;\r\n  transition: all 0.3s;\r\n}\r\n.modal.zoom.in .modal-dialog {\r\n  -webkit-transform: scale(1);\r\n  transform: scale(1);\r\n  -webkit-transform: translate3d(0, -300px, 0);\r\n  transform: translate3d(0, -300px, 0);\r\n  opacity: 1;\r\n}", ""]);
	
	// exports


/***/ },
/* 143 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _isInteger = __webpack_require__(144);
	
	var _isInteger2 = _interopRequireDefault(_isInteger);
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div role="dialog"
	
	//     v-bind:class="{
	
	//     'modal':true,
	
	//     'fade':effect === 'fade',
	
	//     'zoom':effect === 'zoom'
	
	//     }"
	
	//     >
	
	//     <div v-bind:class="{'modal-dialog':true,'modal-lg':large,'modal-sm':small}" role="document"
	
	//       v-bind:style="{width: optionalWidth}">
	
	//       <div class="modal-content">
	
	//         <slot name="modal-header">
	
	//           <div class="modal-header">
	
	//             <button type="button" class="close" @click="close"><span>&times;</span></button>
	
	//             <h4 class="modal-title">
	
	//               <slot name="title">
	
	//                 {{title}}
	
	//               </slot>
	
	//             </h4>
	
	//           </div>
	
	//         </slot>
	
	//         <slot name="modal-body">
	
	//           <div class="modal-body"></div>
	
	//         </slot>
	
	//         <slot name="modal-footer">
	
	//           <div class="modal-footer">
	
	//             <button type="button" class="btn btn-default" @click="close">{{ cancelText }}</button>
	
	//             <button type="button" class="btn btn-primary" @click="callback">{{ okText }}</button>
	
	//           </div>
	
	//         </slot>
	
	//       </div>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    okText: {
	      type: String,
	      default: 'Save changes'
	    },
	    cancelText: {
	      type: String,
	      default: 'Close'
	    },
	    title: {
	      type: String,
	      default: ''
	    },
	    show: {
	      required: true,
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      twoWay: true
	    },
	    width: {
	      default: null
	    },
	    callback: {
	      type: Function,
	      default: function _default() {}
	    },
	    effect: {
	      type: String,
	      default: null
	    },
	    backdrop: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    large: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    small: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  },
	  computed: {
	    optionalWidth: function optionalWidth() {
	      if (this.width === null) {
	        return null;
	      } else if ((0, _isInteger2.default)(this.width)) {
	        return this.width + 'px';
	      }
	      return this.width;
	    }
	  },
	  watch: {
	    show: function show(val) {
	      var _this = this;
	
	      var el = this.$el;
	      var body = document.body;
	      var scrollBarWidth = (0, _utils.getScrollBarWidth)();
	      if (val) {
	        (0, _NodeList2.default)(el).find('.modal-content').focus();
	        el.style.display = 'block';
	        setTimeout(function () {
	          return (0, _NodeList2.default)(el).addClass('in');
	        }, 0);
	        (0, _NodeList2.default)(body).addClass('modal-open');
	        if (scrollBarWidth !== 0) {
	          body.style.paddingRight = scrollBarWidth + 'px';
	        }
	        if (this.backdrop) {
	          (0, _NodeList2.default)(el).on('click', function (e) {
	            if (e.target === el) _this.show = false;
	          });
	        }
	      } else {
	        body.style.paddingRight = null;
	        (0, _NodeList2.default)(body).removeClass('modal-open');
	        (0, _NodeList2.default)(el).removeClass('in').on('transitionend', function () {
	          (0, _NodeList2.default)(el).off('click transitionend');
	          el.style.display = 'none';
	        });
	      }
	    }
	  },
	  methods: {
	    close: function close() {
	      this.show = false;
	    }
	  }
	};
	// </script>
	
	// <style>
	
	// .modal {
	
	//   transition: all 0.3s ease;
	
	// }
	
	// .modal.in {
	
	//   background-color: rgba(0,0,0,0.5);
	
	// }
	
	// .modal.zoom .modal-dialog {
	
	//   -webkit-transform: scale(0.1);
	
	//   -moz-transform: scale(0.1);
	
	//   -ms-transform: scale(0.1);
	
	//   transform: scale(0.1);
	
	//   top: 300px;
	
	//   opacity: 0;
	
	//   -webkit-transition: all 0.3s;
	
	//   -moz-transition: all 0.3s;
	
	//   transition: all 0.3s;
	
	// }
	
	// .modal.zoom.in .modal-dialog {
	
	//   -webkit-transform: scale(1);
	
	//   -moz-transform: scale(1);
	
	//   -ms-transform: scale(1);
	
	//   transform: scale(1);
	
	//   -webkit-transform: translate3d(0, -300px, 0);
	
	//   transform: translate3d(0, -300px, 0);
	
	//   opacity: 1;
	
	// }
	
	// </style>

/***/ },
/* 144 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = { "default": __webpack_require__(145), __esModule: true };

/***/ },
/* 145 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(146);
	module.exports = __webpack_require__(33).Number.isInteger;

/***/ },
/* 146 */
/***/ function(module, exports, __webpack_require__) {

	// 20.1.2.3 Number.isInteger(number)
	var $export = __webpack_require__(31);
	
	$export($export.S, 'Number', {isInteger: __webpack_require__(147)});

/***/ },
/* 147 */
/***/ function(module, exports, __webpack_require__) {

	// 20.1.2.3 Number.isInteger(number)
	var isObject = __webpack_require__(39)
	  , floor    = Math.floor;
	module.exports = function isInteger(it){
	  return !isObject(it) && isFinite(it) && floor(it) === it;
	};

/***/ },
/* 148 */
/***/ function(module, exports) {

	module.exports = "<div role=\"dialog\"\r\n    v-bind:class=\"{\r\n    'modal':true,\r\n    'fade':effect === 'fade',\r\n    'zoom':effect === 'zoom'\r\n    }\"\r\n    >\r\n    <div v-bind:class=\"{'modal-dialog':true,'modal-lg':large,'modal-sm':small}\" role=\"document\"\r\n      v-bind:style=\"{width: optionalWidth}\">\r\n      <div class=\"modal-content\">\r\n        <slot name=\"modal-header\">\r\n          <div class=\"modal-header\">\r\n            <button type=\"button\" class=\"close\" @click=\"close\"><span>&times;</span></button>\r\n            <h4 class=\"modal-title\">\r\n              <slot name=\"title\">\r\n                {{title}}\r\n              </slot>\r\n            </h4>\r\n          </div>\r\n        </slot>\r\n        <slot name=\"modal-body\">\r\n          <div class=\"modal-body\"></div>\r\n        </slot>\r\n        <slot name=\"modal-footer\">\r\n          <div class=\"modal-footer\">\r\n            <button type=\"button\" class=\"btn btn-default\" @click=\"close\">{{ cancelText }}</button>\r\n            <button type=\"button\" class=\"btn btn-primary\" @click=\"callback\">{{ okText }}</button>\r\n          </div>\r\n        </slot>\r\n      </div>\r\n    </div>\r\n  </div>";

/***/ },
/* 149 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(150)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(151)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Navbar.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Navbar.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Navbar.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Navbar.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Navbar.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 150 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = {
	  props: {
	    type: {
	      type: String,
	      default: 'default'
	    },
	    placement: {
	      type: String,
	      default: ''
	    }
	  },
	  data: function data() {
	    return {
	      id: 'bs-example-navbar-collapse-1',
	      collapsed: true,
	      styles: {}
	    };
	  },
	
	  computed: {
	    slots: function slots() {
	      return this._slotContents;
	    }
	  },
	  methods: {
	    toggleCollapse: function toggleCollapse(e) {
	      e && e.preventDefault();
	      this.collapsed = !this.collapsed;
	    }
	  },
	  created: function created() {
	    this._navbar = true;
	  },
	  ready: function ready() {
	    var _this = this;
	
	    var $dropdown = (0, _NodeList2.default)('.dropdown>[data-toggle="dropdown"]', this.$el).parent();
	    $dropdown.on('click', '.dropdown-toggle', function (e) {
	      e.preventDefault();
	      $dropdown.each(function (content) {
	        if (content.contains(e.target)) content.classList.toggle('open');
	      });
	    }).on('click', '.dropdown-menu>li>a', function (e) {
	      $dropdown.each(function (content) {
	        if (content.contains(e.target)) content.classList.remove('open');
	      });
	    }).onBlur(function (e) {
	      $dropdown.each(function (content) {
	        if (!content.contains(e.target)) content.classList.remove('open');
	      });
	    });
	    (0, _NodeList2.default)(this.$el).on('click touchstart', 'li:not(.dropdown)>a', function (e) {
	      setTimeout(function () {
	        _this.collapsed = true;
	      }, 200);
	    }).onBlur(function (e) {
	      if (!_this.$el.contains(e.target)) {
	        _this.collapsed = true;
	      }
	    });
	    var height = this.$el.offsetHeight;
	    if (this.placement === 'top') {
	      document.body.style.paddingTop = height + 'px';
	    }
	    if (this.placement === 'bottom') {
	      document.body.style.paddingBottom = height + 'px';
	    }
	    if (this.slots.collapse) (0, _NodeList2.default)('[data-toggle="collapse"]', this.$el).on('click', function (e) {
	      return _this.toggleCollapse(e);
	    });
	  },
	  beforeDestroy: function beforeDestroy() {
	    (0, _NodeList2.default)('.dropdown', this.$el).off('click').offBlur();
	    if (this.slots.collapse) (0, _NodeList2.default)('[data-toggle="collapse"]', this.$el).off('click');
	  }
	};
	// </script>
	// <template>
	
	//   <nav v-el:navbar :class="['navbar',{
	
	//     'navbar-inverse':(type == 'inverse'),
	
	//     'navbar-default':(type == 'default'),
	
	//     'navbar-fixed-top':(placement === 'top'),
	
	//     'navbar-fixed-bottom':(placement === 'bottom'),
	
	//     'navbar-static-top':(placement === 'static')
	
	//   }]">
	
	//     <div class="container-fluid">
	
	//       <div class="navbar-header">
	
	//         <button v-if="!slots.collapse" type="button" class="navbar-toggle collapsed"  aria-expanded="false" @click="toggleCollapse">
	
	//           <span class="sr-only">Toggle navigation</span>
	
	//           <span class="icon-bar"></span>
	
	//           <span class="icon-bar"></span>
	
	//           <span class="icon-bar"></span>
	
	//         </button>
	
	//         <slot name="collapse"></slot>
	
	//         <slot name="brand"></slot>
	
	//       </div>
	
	//       <div :class="['navbar-collapse',{collapse:collapsed}]">
	
	//         <ul class="nav navbar-nav">
	
	//           <slot></slot>
	
	//         </ul>
	
	//         <ul v-if="slots.right" class="nav navbar-nav navbar-right">
	
	//           <slot name="right"></slot>
	
	//         </ul>
	
	//       </div>
	
	//     </div>
	
	//   </nav>
	
	// </template>
	
	
	// <script>

/***/ },
/* 151 */
/***/ function(module, exports) {

	module.exports = "<nav v-el:navbar :class=\"['navbar',{\r\n    'navbar-inverse':(type == 'inverse'),\r\n    'navbar-default':(type == 'default'),\r\n    'navbar-fixed-top':(placement === 'top'),\r\n    'navbar-fixed-bottom':(placement === 'bottom'),\r\n    'navbar-static-top':(placement === 'static')\r\n  }]\">\r\n    <div class=\"container-fluid\">\r\n      <div class=\"navbar-header\">\r\n        <button v-if=\"!slots.collapse\" type=\"button\" class=\"navbar-toggle collapsed\"  aria-expanded=\"false\" @click=\"toggleCollapse\">\r\n          <span class=\"sr-only\">Toggle navigation</span>\r\n          <span class=\"icon-bar\"></span>\r\n          <span class=\"icon-bar\"></span>\r\n          <span class=\"icon-bar\"></span>\r\n        </button>\r\n        <slot name=\"collapse\"></slot>\r\n        <slot name=\"brand\"></slot>\r\n      </div>\r\n      <div :class=\"['navbar-collapse',{collapse:collapsed}]\">\r\n        <ul class=\"nav navbar-nav\">\r\n          <slot></slot>\r\n        </ul>\r\n        <ul v-if=\"slots.right\" class=\"nav navbar-nav navbar-right\">\r\n          <slot name=\"right\"></slot>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n  </nav>";

/***/ },
/* 152 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(153)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(154)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Option.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Option.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Option.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Option.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Option.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 153 */
/***/ function(module, exports) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	// <template><li v-el:v v-if="loading"><slot></slot></li></template>
	
	// <script>
	exports.default = {
	  props: { value: null },
	  data: function data() {
	    return { loading: true };
	  },
	  ready: function ready() {
	    if (this.$parent._select) {
	      if (!this.$parent.options) {
	        this.$parent.options = [];
	      }
	      var el = {};
	      el[this.$parent.optionsLabel] = this.$els.v.innerHTML;
	      el[this.$parent.optionsValue] = this.value;
	      this.$parent.options.push(el);
	      this.loading = false;
	    } else {
	      console.warn('options only work inside a select component');
	    }
	  }
	};
	// </script>

/***/ },
/* 154 */
/***/ function(module, exports) {

	module.exports = "<li v-el:v v-if=\"loading\"><slot></slot></li>";

/***/ },
/* 155 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(156)
	module.exports = __webpack_require__(158)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(159)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Panel.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Panel.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Panel.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Panel.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Panel.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 156 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(157);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-1edc72c9&file=Panel.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Panel.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-1edc72c9&file=Panel.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Panel.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 157 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".accordion-toggle {\r\n  cursor: pointer;\r\n}\r\n.collapse-transition {\r\n  -webkit-transition: max-height .5s ease;\r\n  transition: max-height .5s ease;\r\n}\r\n.collapse-enter, .collapse-leave {\r\n  max-height: 0!important;\r\n}", ""]);
	
	// exports


/***/ },
/* 158 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    header: {
	      type: String
	    },
	    isOpen: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: null
	    },
	    type: {
	      type: String,
	      default: null
	    }
	  },
	  computed: {
	    inAccordion: function inAccordion() {
	      return this.$parent && this.$parent._isAccordion;
	    },
	    panelType: function panelType() {
	      return 'panel panel-' + (this.type || this.$parent && this.$parent.type || 'default');
	    }
	  },
	  methods: {
	    toggle: function toggle() {
	      this.isOpen = !this.isOpen;
	      this.$dispatch('isOpenEvent', this);
	    }
	  },
	  transitions: {
	    collapse: {
	      afterEnter: function afterEnter(el) {
	        el.style.maxHeight = '';
	        el.style.overflow = '';
	      },
	      beforeLeave: function beforeLeave(el) {
	        el.style.maxHeight = el.offsetHeight + 'px';
	        el.style.overflow = 'hidden';
	        // Recalculate DOM before the class gets added.
	        return el.offsetHeight;
	      }
	    }
	  },
	  created: function created() {
	    if (this.isOpen === null) {
	      this.isOpen = !this.inAccordion;
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .accordion-toggle {
	
	//   cursor: pointer;
	
	// }
	
	// .collapse-transition {
	
	//   transition: max-height .5s ease;
	
	// }
	
	// .collapse-enter, .collapse-leave {
	
	//   max-height: 0!important;
	
	// }
	
	// </style>
	// <template>
	
	//   <div :class="panelType">
	
	//     <div :class="['panel-heading',{'accordion-toggle':inAccordion}]" @click.prevent="inAccordion&&toggle()">
	
	//       <slot name="header">
	
	//         <h4 class="panel-title">{{ header }}</h4>
	
	//       </slot>
	
	//     </div>
	
	//     <div class="panel-collapse"
	
	//       v-el:panel
	
	//       v-show="isOpen"
	
	//       transition="collapse"
	
	//     >
	
	//       <div class="panel-body">
	
	//         <slot></slot>
	
	//       </div>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 159 */
/***/ function(module, exports) {

	module.exports = "<div :class=\"panelType\">\r\n    <div :class=\"['panel-heading',{'accordion-toggle':inAccordion}]\" @click.prevent=\"inAccordion&&toggle()\">\r\n      <slot name=\"header\">\r\n        <h4 class=\"panel-title\">{{ header }}</h4>\r\n      </slot>\r\n    </div>\r\n    <div class=\"panel-collapse\"\r\n      v-el:panel\r\n      v-show=\"isOpen\"\r\n      transition=\"collapse\"\r\n    >\r\n      <div class=\"panel-body\">\r\n        <slot></slot>\r\n      </div>\r\n    </div>\r\n  </div>";

/***/ },
/* 160 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(161)
	module.exports = __webpack_require__(163)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(165)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Popover.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Popover.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Popover.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Popover.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Popover.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 161 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(162);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-493790ac&file=Popover.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Popover.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-493790ac&file=Popover.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Popover.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 162 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".popover.top,\r\n.popover.left,\r\n.popover.right,\r\n.popover.bottom {\r\n  display: block;\r\n}\r\n.scale-enter {\r\n  -webkit-animation:scale-in 0.15s ease-in;\r\n          animation:scale-in 0.15s ease-in;\r\n}\r\n.scale-leave {\r\n  -webkit-animation:scale-out 0.15s ease-out;\r\n          animation:scale-out 0.15s ease-out;\r\n}\r\n@-webkit-keyframes scale-in {\r\n  0% {\r\n    -webkit-transform: scale(0);\r\n            transform: scale(0);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: scale(1);\r\n            transform: scale(1);\r\n    opacity: 1;\r\n  }\r\n}\r\n@keyframes scale-in {\r\n  0% {\r\n    -webkit-transform: scale(0);\r\n            transform: scale(0);\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    -webkit-transform: scale(1);\r\n            transform: scale(1);\r\n    opacity: 1;\r\n  }\r\n}\r\n@-webkit-keyframes scale-out {\r\n  0% {\r\n    -webkit-transform: scale(1);\r\n            transform: scale(1);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: scale(0);\r\n            transform: scale(0);\r\n    opacity: 0;\r\n  }\r\n}\r\n@keyframes scale-out {\r\n  0% {\r\n    -webkit-transform: scale(1);\r\n            transform: scale(1);\r\n    opacity: 1;\r\n  }\r\n  100% {\r\n    -webkit-transform: scale(0);\r\n            transform: scale(0);\r\n    opacity: 0;\r\n  }\r\n}", ""]);
	
	// exports


/***/ },
/* 163 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _popoverMixins = __webpack_require__(164);
	
	var _popoverMixins2 = _interopRequireDefault(_popoverMixins);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = {
	  mixins: [_popoverMixins2.default],
	  props: {
	    trigger: {
	      type: String,
	      default: 'click'
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .popover.top,
	
	// .popover.left,
	
	// .popover.right,
	
	// .popover.bottom {
	
	//   display: block;
	
	// }
	
	// .scale-enter {
	
	//   animation:scale-in 0.15s ease-in;
	
	// }
	
	// .scale-leave {
	
	//   animation:scale-out 0.15s ease-out;
	
	// }
	
	// @keyframes scale-in {
	
	//   0% {
	
	//     transform: scale(0);
	
	//     opacity: 0;
	
	//   }
	
	//   100% {
	
	//     transform: scale(1);
	
	//     opacity: 1;
	
	//   }
	
	// }
	
	// @keyframes scale-out {
	
	//   0% {
	
	//     transform: scale(1);
	
	//     opacity: 1;
	
	//   }
	
	//   100% {
	
	//     transform: scale(0);
	
	//     opacity: 0;
	
	//   }
	
	// }
	
	// </style>
	// <template>
	
	//   <span v-el:trigger>
	
	//     <slot></slot>
	
	//     <div v-el:popover v-if="show"
	
	//       :class="['popover',placement]"
	
	//       :transition="effect"
	
	//     >
	
	//       <div class="arrow"></div>
	
	//       <h3 class="popover-title" v-if="title">
	
	//         <slot name="title">{{title}}</slot>
	
	//       </h3>
	
	//       <div class="popover-content">
	
	//         <slot name="content">{{{content}}}</slot>
	
	//       </div>
	
	//     </div>
	
	//   </span>
	
	// </template>
	
	
	// <script>

/***/ },
/* 164 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = {
	  props: {
	    trigger: {
	      type: String
	    },
	    effect: {
	      type: String,
	      default: 'fade'
	    },
	    title: {
	      type: String
	    },
	    content: {
	      type: String
	    },
	    header: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: true
	    },
	    placement: {
	      type: String,
	      default: 'top'
	    }
	  },
	  data: function data() {
	    return {
	      position: {
	        top: 0,
	        left: 0
	      },
	      show: false
	    };
	  },
	
	  methods: {
	    toggle: function toggle(e) {
	      var _this = this;
	
	      if (e && this.trigger === 'contextmenu') e.preventDefault();
	      if (!(this.show = !this.show)) {
	        return;
	      }
	      setTimeout(function () {
	        var popover = _this.$els.popover;
	        var trigger = _this.$els.trigger.children[0];
	        switch (_this.placement) {
	          case 'top':
	            _this.position.left = trigger.offsetLeft - popover.offsetWidth / 2 + trigger.offsetWidth / 2;
	            _this.position.top = trigger.offsetTop - popover.offsetHeight;
	            break;
	          case 'left':
	            _this.position.left = trigger.offsetLeft - popover.offsetWidth;
	            _this.position.top = trigger.offsetTop + trigger.offsetHeight / 2 - popover.offsetHeight / 2;
	            break;
	          case 'right':
	            _this.position.left = trigger.offsetLeft + trigger.offsetWidth;
	            _this.position.top = trigger.offsetTop + trigger.offsetHeight / 2 - popover.offsetHeight / 2;
	            break;
	          case 'bottom':
	            _this.position.left = trigger.offsetLeft - popover.offsetWidth / 2 + trigger.offsetWidth / 2;
	            _this.position.top = trigger.offsetTop + trigger.offsetHeight;
	            break;
	          default:
	            console.warn('Wrong placement prop');
	        }
	        popover.style.top = _this.position.top + 'px';
	        popover.style.left = _this.position.left + 'px';
	      }, 0);
	    }
	  },
	  ready: function ready() {
	    var trigger = this.$els.trigger;
	    if (!trigger) return console.error('Could not find trigger v-el in your component that uses popoverMixin.');
	
	    if (this.trigger === 'focus' && !~trigger.tabIndex) {
	      trigger = (0, _NodeList2.default)('a,input,select,textarea,button', trigger);
	      if (!trigger.length) {
	        trigger = null;
	      }
	    }
	    if (trigger) {
	      var events = { contextmenu: 'contextmenu', hover: 'mouseleave mouseenter', focus: 'blur focus' };
	      (0, _NodeList2.default)(trigger).on(events[this.trigger] || 'click', this.toggle);
	      this._trigger = trigger;
	    }
	  },
	  beforeDestroy: function beforeDestroy() {
	    if (this._trigger) (0, _NodeList2.default)(this._trigger).off();
	  }
	};

/***/ },
/* 165 */
/***/ function(module, exports) {

	module.exports = "<span v-el:trigger>\r\n    <slot></slot>\r\n    <div v-el:popover v-if=\"show\"\r\n      :class=\"['popover',placement]\"\r\n      :transition=\"effect\"\r\n    >\r\n      <div class=\"arrow\"></div>\r\n      <h3 class=\"popover-title\" v-if=\"title\">\r\n        <slot name=\"title\">{{title}}</slot>\r\n      </h3>\r\n      <div class=\"popover-content\">\r\n        <slot name=\"content\">{{{content}}}</slot>\r\n      </div>\r\n    </div>\r\n  </span>";

/***/ },
/* 166 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(167)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(168)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Progressbar.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Progressbar.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Progressbar.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Progressbar.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Progressbar.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 167 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    now: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      required: true
	    },
	    label: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    type: {
	      type: String
	    },
	    striped: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    animated: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  }
	};
	// </script>
	// <template>
	
	//   <div role="progressbar" 
	
	//     :class="['progress-bar',{
	
	//       'progress-bar-success':type == 'success',
	
	//       'progress-bar-warning':type == 'warning',
	
	//       'progress-bar-info':type == 'info',
	
	//       'progress-bar-danger':type == 'danger',
	
	//       'progress-bar-striped':striped,
	
	//       'active':animated
	
	//     }]"
	
	//     :style="{width: now + '%'}"
	
	//   >
	
	//     {{label ? now + '%' : ''}}
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 168 */
/***/ function(module, exports) {

	module.exports = "<div role=\"progressbar\" \r\n    :class=\"['progress-bar',{\r\n      'progress-bar-success':type == 'success',\r\n      'progress-bar-warning':type == 'warning',\r\n      'progress-bar-info':type == 'info',\r\n      'progress-bar-danger':type == 'danger',\r\n      'progress-bar-striped':striped,\r\n      'active':animated\r\n    }]\"\r\n    :style=\"{width: now + '%'}\"\r\n  >\r\n    {{label ? now + '%' : ''}}\r\n  </div>";

/***/ },
/* 169 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(170)
	module.exports = __webpack_require__(172)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(173)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Radio.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Radio.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Radio.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Radio.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Radio.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 170 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(171);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-3d64a940&file=Radio.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Radio.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-3d64a940&file=Radio.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Radio.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 171 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".radio { position: relative; }\r\n.radio > label > input {\r\n  position: absolute;\r\n  margin: 0;\r\n  padding: 0;\r\n  opacity: 0;\r\n  z-index: -1;\r\n  box-sizing: border-box;\r\n}\r\n.radio > label > .icon {\r\n  position: absolute;\r\n  top: .15rem;\r\n  left: 0;\r\n  display: block;\r\n  width: 1.4rem;\r\n  height: 1.4rem;\r\n  text-align: center;\r\n  -webkit-user-select: none;\r\n     -moz-user-select: none;\r\n      -ms-user-select: none;\r\n          user-select: none;\r\n  border-radius: .7rem;\r\n  background-repeat: no-repeat;\r\n  background-position: center center;\r\n  background-size: 50% 50%;\r\n}\r\n.radio:not(.active) > label > .icon {\r\n  background-color: #ddd;\r\n  border: 1px solid #bbb;\r\n}\r\n.radio > label > input:focus ~ .icon {\r\n  outline: 0;\r\n  border: 1px solid #66afe9;\r\n  box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);\r\n}\r\n.radio.active > label > .icon {\r\n  background-size: 1rem 1rem;\r\n  background-image: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxzdmcgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPjxjaXJjbGUgY3g9IjUiIGN5PSI1IiByPSI0IiBmaWxsPSIjZmZmIi8+PC9zdmc+);\r\n}\r\n.radio.active .btn-default { -webkit-filter: brightness(75%); filter: brightness(75%); }\r\n\r\n.radio.disabled > label > .icon,\r\n.radio.readonly > label > .icon,\r\n.btn.readonly {\r\n  filter: alpha(opacity=65);\r\n  box-shadow: none;\r\n  opacity: .65;\r\n}\r\nlabel.btn > input[type=radio] {\r\n  position: absolute;\r\n  clip: rect(0,0,0,0);\r\n  pointer-events: none;\r\n}", ""]);
	
	// exports


/***/ },
/* 172 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    value: {
	      default: true
	    },
	    checked: {
	      twoWay: true
	    },
	    button: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    name: {
	      type: String,
	      default: null
	    },
	    readonly: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    type: {
	      type: String,
	      default: null
	    }
	  },
	  computed: {
	    active: function active() {
	      return this.group ? this.$parent.value === this.value : this.value === this.checked;
	    },
	    buttonStyle: function buttonStyle() {
	      return this.button || this.group && this.$parent.buttons;
	    },
	    group: function group() {
	      return this.$parent && this.$parent._radioGroup;
	    },
	    typeColor: function typeColor() {
	      return this.type || this.$parent && this.$parent.type || 'default';
	    }
	  },
	  created: function created() {
	    var parent = this.$parent;
	    if (!parent) return;
	    if (parent._btnGroup && !parent._checkboxGroup) {
	      parent._radioGroup = true;
	    }
	  },
	  ready: function ready() {
	    if (!this.$parent._radioGroup) return;
	    if (this.$parent.value) {
	      this.checked = this.$parent.value === this.value;
	    } else if (this.checked) {
	      this.$parent.value = this.value;
	    }
	  },
	
	  methods: {
	    focus: function focus() {
	      this.$els.input.focus();
	    },
	    toggle: function toggle() {
	      if (this.disabled) {
	        return;
	      }
	      this.focus();
	      if (this.readonly) {
	        return;
	      }
	      this.checked = this.value;
	      if (this.group) {
	        this.$parent.value = this.value;
	      }
	    }
	  }
	};
	// </script>
	
	
	// <style scope>
	
	// .radio { position: relative; }
	
	// .radio > label > input {
	
	//   position: absolute;
	
	//   margin: 0;
	
	//   padding: 0;
	
	//   opacity: 0;
	
	//   z-index: -1;
	
	//   box-sizing: border-box;
	
	// }
	
	// .radio > label > .icon {
	
	//   position: absolute;
	
	//   top: .15rem;
	
	//   left: 0;
	
	//   display: block;
	
	//   width: 1.4rem;
	
	//   height: 1.4rem;
	
	//   text-align: center;
	
	//   user-select: none;
	
	//   border-radius: .7rem;
	
	//   background-repeat: no-repeat;
	
	//   background-position: center center;
	
	//   background-size: 50% 50%;
	
	// }
	
	// .radio:not(.active) > label > .icon {
	
	//   background-color: #ddd;
	
	//   border: 1px solid #bbb;
	
	// }
	
	// .radio > label > input:focus ~ .icon {
	
	//   outline: 0;
	
	//   border: 1px solid #66afe9;
	
	//   box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
	
	// }
	
	// .radio.active > label > .icon {
	
	//   background-size: 1rem 1rem;
	
	//   background-image: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4NCjxzdmcgdmVyc2lvbj0iMS4xIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciPjxjaXJjbGUgY3g9IjUiIGN5PSI1IiByPSI0IiBmaWxsPSIjZmZmIi8+PC9zdmc+);
	
	// }
	
	// .radio.active .btn-default { filter: brightness(75%); }
	
	
	// .radio.disabled > label > .icon,
	
	// .radio.readonly > label > .icon,
	
	// .btn.readonly {
	
	//   filter: alpha(opacity=65);
	
	//   box-shadow: none;
	
	//   opacity: .65;
	
	// }
	
	// label.btn > input[type=radio] {
	
	//   position: absolute;
	
	//   clip: rect(0,0,0,0);
	
	//   pointer-events: none;
	
	// }
	
	// </style>
	// <template>
	
	//   <label v-if="buttonStyle" :class="['btn btn-'+typeColor,{active:active,disabled:disabled,readonly:readonly}]" @click.prevent="toggle">
	
	//     <input type="radio" autocomplete="off"
	
	//       v-el:input
	
	//       v-show="!readonly"
	
	//       :checked="active"
	
	//       :value="value"
	
	//       :name="name"
	
	//       :readonly="readonly"
	
	//       :disabled="disabled"
	
	//     />
	
	//     <slot></slot>
	
	//   </label>
	
	//   <div v-else :class="['radio',typeColor,{active:active,disabled:disabled,readonly:readonly}]" @click.prevent="toggle">
	
	//     <label class="open">
	
	//       <input type="radio" autocomplete="off"
	
	//         v-el:input
	
	//         :checked="active"
	
	//         :value="value"
	
	//         :name="name"
	
	//         :readonly="readonly"
	
	//         :disabled="disabled"
	
	//       />
	
	//       <span class="icon dropdown-toggle" :class="[active?'btn-'+typeColor:'',{bg:typeColor==='default'}]"></span>
	
	//       <span v-if="active&&typeColor==='default'" class="icon"></span>
	
	//       <slot></slot>
	
	//     </label>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 173 */
/***/ function(module, exports) {

	module.exports = "<label v-if=\"buttonStyle\" :class=\"['btn btn-'+typeColor,{active:active,disabled:disabled,readonly:readonly}]\" @click.prevent=\"toggle\">\r\n    <input type=\"radio\" autocomplete=\"off\"\r\n      v-el:input\r\n      v-show=\"!readonly\"\r\n      :checked=\"active\"\r\n      :value=\"value\"\r\n      :name=\"name\"\r\n      :readonly=\"readonly\"\r\n      :disabled=\"disabled\"\r\n    />\r\n    <slot></slot>\r\n  </label>\r\n  <div v-else :class=\"['radio',typeColor,{active:active,disabled:disabled,readonly:readonly}]\" @click.prevent=\"toggle\">\r\n    <label class=\"open\">\r\n      <input type=\"radio\" autocomplete=\"off\"\r\n        v-el:input\r\n        :checked=\"active\"\r\n        :value=\"value\"\r\n        :name=\"name\"\r\n        :readonly=\"readonly\"\r\n        :disabled=\"disabled\"\r\n      />\r\n      <span class=\"icon dropdown-toggle\" :class=\"[active?'btn-'+typeColor:'',{bg:typeColor==='default'}]\"></span>\r\n      <span v-if=\"active&&typeColor==='default'\" class=\"icon\"></span>\r\n      <slot></slot>\r\n    </label>\r\n  </div>";

/***/ },
/* 174 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(175)
	module.exports = __webpack_require__(177)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(193)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Select.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Select.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-0f3bb707&file=Select.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Select.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Select.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-0f3bb707&file=Select.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Select.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 175 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(176);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-0f3bb707&file=Select.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Select.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-0f3bb707&file=Select.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Select.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 176 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, "button.form-control.dropdown-toggle[_v-0f3bb707]{\r\n  height: auto;\r\n  padding-right: 24px;\r\n}\r\nbutton.form-control.dropdown-toggle[_v-0f3bb707]:after{\r\n  content: ' ';\r\n  position: absolute;\r\n  right: 13px;\r\n  top: 50%;\r\n  margin: -1px 0 0;\r\n  border-top: 4px dashed;\r\n  border-top: 4px solid \\9;\r\n  border-right: 4px solid transparent;\r\n  border-left: 4px solid transparent;\r\n}\r\n.bs-searchbox[_v-0f3bb707] {\r\n  position: relative;\r\n  margin: 4px 8px;\r\n}\r\n.bs-searchbox .close[_v-0f3bb707] {\r\n  position: absolute;\r\n  top: 0;\r\n  right: 0;\r\n  z-index: 2;\r\n  display: block;\r\n  width: 34px;\r\n  height: 34px;\r\n  line-height: 34px;\r\n  text-align: center;\r\n}\r\n.bs-searchbox input[_v-0f3bb707]:focus,\r\n.secret:focus + button[_v-0f3bb707] {\r\n  outline: 0;\r\n  border-color: #66afe9 !important;\r\n  box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);\r\n}\r\n.secret[_v-0f3bb707] {\r\n  border: 0;\r\n  clip: rect(0 0 0 0);\r\n  height: 1px;\r\n  margin: -1px;\r\n  overflow: hidden;\r\n  padding: 0;\r\n  position: absolute;\r\n  width: 1px;\r\n}\r\nbutton>.close[_v-0f3bb707] { margin-left: 5px;}\r\n.notify.out[_v-0f3bb707] { position: relative; }\r\n.notify.in[_v-0f3bb707],\r\n.notify>div[_v-0f3bb707] {\r\n  position: absolute;\r\n  width: 96%;\r\n  margin: 0 2%;\r\n  min-height: 26px;\r\n  padding: 3px 5px;\r\n  background: #f5f5f5;\r\n  border: 1px solid #e3e3e3;\r\n  box-shadow: inset 0 1px 1px rgba(0,0,0,.05);\r\n  pointer-events: none;\r\n}\r\n.notify>div[_v-0f3bb707] {\r\n  top: 5px;\r\n  z-index: 1;\r\n}\r\n.notify.in[_v-0f3bb707] {\r\n  opacity: .9;\r\n  bottom: 5px;\r\n}\r\n.btn-group-justified .dropdown-toggle>span[_v-0f3bb707]:not(.close) {\r\n  width: calc(100% - 18px);\r\n  display: inline-block;\r\n  overflow: hidden;\r\n  white-space: nowrap;\r\n  text-overflow: ellipsis;\r\n  margin-bottom: -4px;\r\n}\r\n.btn-group-justified .dropdown-menu[_v-0f3bb707] { width: 100%; }", ""]);
	
	// exports


/***/ },
/* 177 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _typeof2 = __webpack_require__(178);
	
	var _typeof3 = _interopRequireDefault(_typeof2);
	
	var _utils = __webpack_require__(92);
	
	var _NodeList = __webpack_require__(27);
	
	var _NodeList2 = _interopRequireDefault(_NodeList);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div v-el:select :class="classes">
	
	//     <button type="button" class="form-control dropdown-toggle"
	
	//       :disabled="disabled || !hasParent"
	
	//       :readonly="readonly"
	
	//       @click="toggle()"
	
	//       @keyup.esc="show = false"
	
	//     >
	
	//       <span class="btn-content" v-html="loading ? text.loading : showPlaceholder || selected"></span>
	
	//       <span v-if="clearButton&&values.length" class="close" @click="clear()">&times;</span>
	
	//     </button>
	
	//     <select v-el:sel v-model="value" v-show="show" name="{{name}}" class="secret" :multiple="multiple" :required="required" :readonly="readonly" :disabled="disabled">
	
	//       <option v-if="required" value=""></option>
	
	//       <option v-for="option in options" :value="option[optionsValue]||option">{{ option[optionsLabel]||option }}</option>
	
	//     </select>
	
	//     <ul class="dropdown-menu">
	
	//       <template v-if="options.length">
	
	//         <li v-if="canSearch" class="bs-searchbox">
	
	//           <input type="text" placeholder="{{searchText||text.search}}" class="form-control" autocomplete="off"
	
	//             v-el:search
	
	//             v-model="searchValue"
	
	//             @keyup.esc="show = false"
	
	//           />
	
	//           <span v-show="searchValue" class="close" @click="clearSearch">&times;</span>
	
	//         </li>
	
	//         <li v-if="required&&!clearButton"><a @mousedown.prevent="clear() && blur()">{{ placeholder || text.notSelected }}</a></li>
	
	//         <li v-for="option in options | filterBy searchValue" :id="option[optionsValue]||option">
	
	//           <a @mousedown.prevent="select(option[optionsValue],option)">
	
	//             <span v-html="option[optionsLabel]||option"></span>
	
	//             <span class="glyphicon glyphicon-ok check-mark" v-show="isSelected(option[optionsValue])"></span>
	
	//           </a>
	
	//         </li>
	
	//       </template>
	
	//       <slot></slot>
	
	//       <div v-if="showNotify && !closeOnSelect" class="notify in" transition="fadein">{{limitText}}</div>
	
	//     </ul>
	
	//     <div v-if="showNotify && closeOnSelect" class="notify out" transition="fadein"><div>{{limitText}}</div></div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	var timeout = {};
	exports.default = {
	  props: {
	    value: {
	      twoWay: true
	    },
	    options: {
	      type: Array,
	      default: function _default() {
	        return [];
	      }
	    },
	    multiple: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    clearButton: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    closeOnSelect: { // only works when multiple
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    lang: {
	      type: String,
	      default: navigator.language
	    },
	    limit: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 1024
	    },
	    name: {
	      type: String,
	      default: null
	    },
	    optionsLabel: {
	      type: String,
	      default: 'label'
	    },
	    optionsValue: {
	      type: String,
	      default: 'value'
	    },
	    parent: {
	      default: true
	    },
	    placeholder: {
	      type: String,
	      default: null
	    },
	    readonly: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: null
	    },
	    required: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: null
	    },
	    minSearch: {
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 0
	    },
	    search: { // Allow searching (only works when options are provided)
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    searchText: {
	      type: String,
	      default: null
	    },
	    url: {
	      type: String,
	      default: null
	    }
	  },
	  data: function data() {
	    return {
	      loading: null,
	      searchValue: null,
	      show: false,
	      showNotify: false,
	      valid: null
	    };
	  },
	
	  computed: {
	    selected: function selected() {
	      var _this = this;
	
	      if (this.options.length === 0) {
	        return '';
	      }
	      var foundItems = [];
	      this.values.forEach(function (item) {
	        if (~['number', 'string'].indexOf(typeof item === 'undefined' ? 'undefined' : (0, _typeof3.default)(item))) {
	          var option = null;
	          if (_this.options.some(function (o) {
	            if (o instanceof Object ? o[_this.optionsValue] === item : o === item) {
	              option = o;
	              return true;
	            }
	          })) {
	            foundItems.push(option[_this.optionsLabel] || option);
	          }
	        }
	      });
	      return foundItems.join(', ');
	    },
	    classes: function classes() {
	      return [{ open: this.show, disabled: this.disabled }, this.class, this.isLi ? 'dropdown' : this.inInput ? 'input-group-btn' : 'btn-group'];
	    },
	    inInput: function inInput() {
	      return this.$parent._input;
	    },
	    isLi: function isLi() {
	      return this.$parent._navbar || this.$parent.menu || this.$parent._tabset;
	    },
	    canSearch: function canSearch() {
	      return this.minSearch ? this.options.length >= this.minSearch : this.search;
	    },
	    limitText: function limitText() {
	      return this.text.limit.replace('{{limit}}', this.limit);
	    },
	    showPlaceholder: function showPlaceholder() {
	      return this.values.length === 0 || !this.hasParent ? this.placeholder || this.text.notSelected : null;
	    },
	    text: function text() {
	      return (0, _utils.translations)(this.lang);
	    },
	    hasParent: function hasParent() {
	      return this.parent instanceof Array ? this.parent.length : this.parent;
	    },
	    values: function values() {
	      return this.value instanceof Array ? this.value : this.value !== null && this.value !== undefined ? [this.value] : [];
	    }
	  },
	  watch: {
	    options: function options(_options) {
	      var _this2 = this;
	
	      var changed = false;
	      if (_options instanceof Array && _options.length) {
	        _options.map(function (el) {
	          if (!(el instanceof Object)) {
	            var obj = {};
	            obj[_this2.optionsLabel] = el;
	            obj[_this2.optionsValue] = el;
	            changed = true;
	            return obj;
	          }
	          return el;
	        });
	      }
	      if (changed) {
	        this.options = _options;
	      }
	    },
	    show: function show(val) {
	      if (val) {
	        this.$els.sel.focus();
	        this.$els.search && this.$els.search.focus();
	      }
	    },
	    url: function url() {
	      this.update();
	    },
	    value: function value(val) {
	      var _this3 = this;
	
	      this.$emit('change', val);
	      this.$emit('selected', this.selected);
	      if (this.value instanceof Array && val.length > this.limit) {
	        this.showNotify = true;
	        if (timeout.limit) clearTimeout(timeout.limit);
	        timeout.limit = setTimeout(function () {
	          timeout.limit = false;
	          _this3.showNotify = false;
	        }, 1500);
	      }
	      this.checkValue();
	      this.valid = this.validate();
	    },
	    valid: function valid(val, old) {
	      if (val === old) {
	        return;
	      }
	      this._parent && this._parent.validate();
	    }
	  },
	  methods: {
	    blur: function blur() {
	      this.show = false;
	    },
	    clear: function clear() {
	      if (this.disabled || this.readonly) {
	        return;
	      }
	      this.value = this.value instanceof Array ? [] : null;
	      this.toggle();
	    },
	    clearSearch: function clearSearch() {
	      this.searchValue = '';
	      this.$els.search.focus();
	    },
	    checkValue: function checkValue() {
	      if (this.multiple && !(this.value instanceof Array)) {
	        this.value = this.value === null || this.value === undefined ? [] : [this.value];
	      }
	      if (!this.multiple && this.value instanceof Array) {
	        this.value = this.value.length ? this.value.pop() : null;
	      }
	      if (this.limit < 1) {
	        this.limit = 1;
	      }
	      if (this.values.length > this.limit) {
	        this.value = this.value.slice(0, this.limit);
	      }
	    },
	    isSelected: function isSelected(v) {
	      return this.values.indexOf(v) > -1;
	    },
	    select: function select(v, alt) {
	      if (this.value instanceof Array) {
	        if (~this.value.indexOf(v)) {
	          this.value.$remove(v);
	        } else {
	          this.value.push(v);
	        }
	        if (this.closeOnSelect) {
	          this.toggle();
	        }
	      } else {
	        this.value = !~['', null, undefined].indexOf(v) ? v : alt;
	        this.toggle();
	      }
	    },
	    toggle: function toggle() {
	      this.show = !this.show;
	    },
	    update: function update() {
	      var _this4 = this;
	
	      if (!this.url) return;
	      this.loading = true;
	      (0, _utils.getJSON)(this.url).then(function (data) {
	        var options = [];
	        data.forEach(function (opc) {
	          if (opc[_this4.optionsValue] !== undefined && opc[_this4.optionsLabel] !== undefined) options.push(opc);
	        });
	        _this4.options = options;
	        if (!options.length) {
	          _this4.value = _this4.value instanceof Array ? [] : null;
	        }
	      }).always(function () {
	        _this4.loading = false;
	        _this4.checkValue();
	      });
	    },
	    validate: function validate() {
	      return !this.required ? true : this.value instanceof Array ? this.value.length > 0 : this.value !== null;
	    }
	  },
	  created: function created() {
	    this._select = true;
	    if (this.value === undefined || !this.parent) {
	      this.value = null;
	    }
	    if (!this.multiple && this.value instanceof Array) {
	      this.value = this.value.shift();
	    }
	    this.checkValue();
	    if (this.url) this.update();
	    var parent = this.$parent;
	    while (parent && !parent._formGroup) {
	      parent = parent.$parent;
	    }
	    if (parent && parent._formGroup) {
	      parent.children.push(this);
	      this._parent = parent;
	    }
	  },
	  ready: function ready() {
	    var _this5 = this;
	
	    (0, _NodeList2.default)(this.$els.select).onBlur(function (e) {
	      _this5.show = false;
	    });
	  },
	  beforeDestroy: function beforeDestroy() {
	    if (this._parent) this._parent.children.$remove(this);
	    (0, _NodeList2.default)(this.$els.select).offBlur();
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// button.form-control.dropdown-toggle{
	
	//   height: auto;
	
	//   padding-right: 24px;
	
	// }
	
	// button.form-control.dropdown-toggle:after{
	
	//   content: ' ';
	
	//   position: absolute;
	
	//   right: 13px;
	
	//   top: 50%;
	
	//   margin: -1px 0 0;
	
	//   border-top: 4px dashed;
	
	//   border-top: 4px solid \9;
	
	//   border-right: 4px solid transparent;
	
	//   border-left: 4px solid transparent;
	
	// }
	
	// .bs-searchbox {
	
	//   position: relative;
	
	//   margin: 4px 8px;
	
	// }
	
	// .bs-searchbox .close {
	
	//   position: absolute;
	
	//   top: 0;
	
	//   right: 0;
	
	//   z-index: 2;
	
	//   display: block;
	
	//   width: 34px;
	
	//   height: 34px;
	
	//   line-height: 34px;
	
	//   text-align: center;
	
	// }
	
	// .bs-searchbox input:focus,
	
	// .secret:focus + button {
	
	//   outline: 0;
	
	//   border-color: #66afe9 !important;
	
	//   box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgba(102,175,233,.6);
	
	// }
	
	// .secret {
	
	//   border: 0;
	
	//   clip: rect(0 0 0 0);
	
	//   height: 1px;
	
	//   margin: -1px;
	
	//   overflow: hidden;
	
	//   padding: 0;
	
	//   position: absolute;
	
	//   width: 1px;
	
	// }
	
	// button>.close { margin-left: 5px;}
	
	// .notify.out { position: relative; }
	
	// .notify.in,
	
	// .notify>div {
	
	//   position: absolute;
	
	//   width: 96%;
	
	//   margin: 0 2%;
	
	//   min-height: 26px;
	
	//   padding: 3px 5px;
	
	//   background: #f5f5f5;
	
	//   border: 1px solid #e3e3e3;
	
	//   box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
	
	//   pointer-events: none;
	
	// }
	
	// .notify>div {
	
	//   top: 5px;
	
	//   z-index: 1;
	
	// }
	
	// .notify.in {
	
	//   opacity: .9;
	
	//   bottom: 5px;
	
	// }
	
	// .btn-group-justified .dropdown-toggle>span:not(.close) {
	
	//   width: calc(100% - 18px);
	
	//   display: inline-block;
	
	//   overflow: hidden;
	
	//   white-space: nowrap;
	
	//   text-overflow: ellipsis;
	
	//   margin-bottom: -4px;
	
	// }
	
	// .btn-group-justified .dropdown-menu { width: 100%; }
	
	// </style>

/***/ },
/* 178 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	exports.__esModule = true;
	
	var _iterator = __webpack_require__(46);
	
	var _iterator2 = _interopRequireDefault(_iterator);
	
	var _symbol = __webpack_require__(179);
	
	var _symbol2 = _interopRequireDefault(_symbol);
	
	var _typeof = typeof _symbol2.default === "function" && typeof _iterator2.default === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof _symbol2.default === "function" && obj.constructor === _symbol2.default && obj !== _symbol2.default.prototype ? "symbol" : typeof obj; };
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = typeof _symbol2.default === "function" && _typeof(_iterator2.default) === "symbol" ? function (obj) {
	  return typeof obj === "undefined" ? "undefined" : _typeof(obj);
	} : function (obj) {
	  return obj && typeof _symbol2.default === "function" && obj.constructor === _symbol2.default && obj !== _symbol2.default.prototype ? "symbol" : typeof obj === "undefined" ? "undefined" : _typeof(obj);
	};

/***/ },
/* 179 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = { "default": __webpack_require__(180), __esModule: true };

/***/ },
/* 180 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(181);
	__webpack_require__(190);
	__webpack_require__(191);
	__webpack_require__(192);
	module.exports = __webpack_require__(33).Symbol;

/***/ },
/* 181 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	// ECMAScript 6 symbols shim
	var global         = __webpack_require__(32)
	  , has            = __webpack_require__(55)
	  , DESCRIPTORS    = __webpack_require__(41)
	  , $export        = __webpack_require__(31)
	  , redefine       = __webpack_require__(54)
	  , META           = __webpack_require__(182).KEY
	  , $fails         = __webpack_require__(42)
	  , shared         = __webpack_require__(69)
	  , setToStringTag = __webpack_require__(73)
	  , uid            = __webpack_require__(70)
	  , wks            = __webpack_require__(74)
	  , wksExt         = __webpack_require__(81)
	  , wksDefine      = __webpack_require__(183)
	  , keyOf          = __webpack_require__(184)
	  , enumKeys       = __webpack_require__(185)
	  , isArray        = __webpack_require__(188)
	  , anObject       = __webpack_require__(38)
	  , toIObject      = __webpack_require__(62)
	  , toPrimitive    = __webpack_require__(44)
	  , createDesc     = __webpack_require__(45)
	  , _create        = __webpack_require__(58)
	  , gOPNExt        = __webpack_require__(86)
	  , $GOPD          = __webpack_require__(189)
	  , $DP            = __webpack_require__(37)
	  , $keys          = __webpack_require__(60)
	  , gOPD           = $GOPD.f
	  , dP             = $DP.f
	  , gOPN           = gOPNExt.f
	  , $Symbol        = global.Symbol
	  , $JSON          = global.JSON
	  , _stringify     = $JSON && $JSON.stringify
	  , PROTOTYPE      = 'prototype'
	  , HIDDEN         = wks('_hidden')
	  , TO_PRIMITIVE   = wks('toPrimitive')
	  , isEnum         = {}.propertyIsEnumerable
	  , SymbolRegistry = shared('symbol-registry')
	  , AllSymbols     = shared('symbols')
	  , OPSymbols      = shared('op-symbols')
	  , ObjectProto    = Object[PROTOTYPE]
	  , USE_NATIVE     = typeof $Symbol == 'function'
	  , QObject        = global.QObject;
	// Don't use setters in Qt Script, https://github.com/zloirock/core-js/issues/173
	var setter = !QObject || !QObject[PROTOTYPE] || !QObject[PROTOTYPE].findChild;
	
	// fallback for old Android, https://code.google.com/p/v8/issues/detail?id=687
	var setSymbolDesc = DESCRIPTORS && $fails(function(){
	  return _create(dP({}, 'a', {
	    get: function(){ return dP(this, 'a', {value: 7}).a; }
	  })).a != 7;
	}) ? function(it, key, D){
	  var protoDesc = gOPD(ObjectProto, key);
	  if(protoDesc)delete ObjectProto[key];
	  dP(it, key, D);
	  if(protoDesc && it !== ObjectProto)dP(ObjectProto, key, protoDesc);
	} : dP;
	
	var wrap = function(tag){
	  var sym = AllSymbols[tag] = _create($Symbol[PROTOTYPE]);
	  sym._k = tag;
	  return sym;
	};
	
	var isSymbol = USE_NATIVE && typeof $Symbol.iterator == 'symbol' ? function(it){
	  return typeof it == 'symbol';
	} : function(it){
	  return it instanceof $Symbol;
	};
	
	var $defineProperty = function defineProperty(it, key, D){
	  if(it === ObjectProto)$defineProperty(OPSymbols, key, D);
	  anObject(it);
	  key = toPrimitive(key, true);
	  anObject(D);
	  if(has(AllSymbols, key)){
	    if(!D.enumerable){
	      if(!has(it, HIDDEN))dP(it, HIDDEN, createDesc(1, {}));
	      it[HIDDEN][key] = true;
	    } else {
	      if(has(it, HIDDEN) && it[HIDDEN][key])it[HIDDEN][key] = false;
	      D = _create(D, {enumerable: createDesc(0, false)});
	    } return setSymbolDesc(it, key, D);
	  } return dP(it, key, D);
	};
	var $defineProperties = function defineProperties(it, P){
	  anObject(it);
	  var keys = enumKeys(P = toIObject(P))
	    , i    = 0
	    , l = keys.length
	    , key;
	  while(l > i)$defineProperty(it, key = keys[i++], P[key]);
	  return it;
	};
	var $create = function create(it, P){
	  return P === undefined ? _create(it) : $defineProperties(_create(it), P);
	};
	var $propertyIsEnumerable = function propertyIsEnumerable(key){
	  var E = isEnum.call(this, key = toPrimitive(key, true));
	  if(this === ObjectProto && has(AllSymbols, key) && !has(OPSymbols, key))return false;
	  return E || !has(this, key) || !has(AllSymbols, key) || has(this, HIDDEN) && this[HIDDEN][key] ? E : true;
	};
	var $getOwnPropertyDescriptor = function getOwnPropertyDescriptor(it, key){
	  it  = toIObject(it);
	  key = toPrimitive(key, true);
	  if(it === ObjectProto && has(AllSymbols, key) && !has(OPSymbols, key))return;
	  var D = gOPD(it, key);
	  if(D && has(AllSymbols, key) && !(has(it, HIDDEN) && it[HIDDEN][key]))D.enumerable = true;
	  return D;
	};
	var $getOwnPropertyNames = function getOwnPropertyNames(it){
	  var names  = gOPN(toIObject(it))
	    , result = []
	    , i      = 0
	    , key;
	  while(names.length > i){
	    if(!has(AllSymbols, key = names[i++]) && key != HIDDEN && key != META)result.push(key);
	  } return result;
	};
	var $getOwnPropertySymbols = function getOwnPropertySymbols(it){
	  var IS_OP  = it === ObjectProto
	    , names  = gOPN(IS_OP ? OPSymbols : toIObject(it))
	    , result = []
	    , i      = 0
	    , key;
	  while(names.length > i){
	    if(has(AllSymbols, key = names[i++]) && (IS_OP ? has(ObjectProto, key) : true))result.push(AllSymbols[key]);
	  } return result;
	};
	
	// 19.4.1.1 Symbol([description])
	if(!USE_NATIVE){
	  $Symbol = function Symbol(){
	    if(this instanceof $Symbol)throw TypeError('Symbol is not a constructor!');
	    var tag = uid(arguments.length > 0 ? arguments[0] : undefined);
	    var $set = function(value){
	      if(this === ObjectProto)$set.call(OPSymbols, value);
	      if(has(this, HIDDEN) && has(this[HIDDEN], tag))this[HIDDEN][tag] = false;
	      setSymbolDesc(this, tag, createDesc(1, value));
	    };
	    if(DESCRIPTORS && setter)setSymbolDesc(ObjectProto, tag, {configurable: true, set: $set});
	    return wrap(tag);
	  };
	  redefine($Symbol[PROTOTYPE], 'toString', function toString(){
	    return this._k;
	  });
	
	  $GOPD.f = $getOwnPropertyDescriptor;
	  $DP.f   = $defineProperty;
	  __webpack_require__(87).f = gOPNExt.f = $getOwnPropertyNames;
	  __webpack_require__(187).f  = $propertyIsEnumerable;
	  __webpack_require__(186).f = $getOwnPropertySymbols;
	
	  if(DESCRIPTORS && !__webpack_require__(53)){
	    redefine(ObjectProto, 'propertyIsEnumerable', $propertyIsEnumerable, true);
	  }
	
	  wksExt.f = function(name){
	    return wrap(wks(name));
	  }
	}
	
	$export($export.G + $export.W + $export.F * !USE_NATIVE, {Symbol: $Symbol});
	
	for(var symbols = (
	  // 19.4.2.2, 19.4.2.3, 19.4.2.4, 19.4.2.6, 19.4.2.8, 19.4.2.9, 19.4.2.10, 19.4.2.11, 19.4.2.12, 19.4.2.13, 19.4.2.14
	  'hasInstance,isConcatSpreadable,iterator,match,replace,search,species,split,toPrimitive,toStringTag,unscopables'
	).split(','), i = 0; symbols.length > i; )wks(symbols[i++]);
	
	for(var symbols = $keys(wks.store), i = 0; symbols.length > i; )wksDefine(symbols[i++]);
	
	$export($export.S + $export.F * !USE_NATIVE, 'Symbol', {
	  // 19.4.2.1 Symbol.for(key)
	  'for': function(key){
	    return has(SymbolRegistry, key += '')
	      ? SymbolRegistry[key]
	      : SymbolRegistry[key] = $Symbol(key);
	  },
	  // 19.4.2.5 Symbol.keyFor(sym)
	  keyFor: function keyFor(key){
	    if(isSymbol(key))return keyOf(SymbolRegistry, key);
	    throw TypeError(key + ' is not a symbol!');
	  },
	  useSetter: function(){ setter = true; },
	  useSimple: function(){ setter = false; }
	});
	
	$export($export.S + $export.F * !USE_NATIVE, 'Object', {
	  // 19.1.2.2 Object.create(O [, Properties])
	  create: $create,
	  // 19.1.2.4 Object.defineProperty(O, P, Attributes)
	  defineProperty: $defineProperty,
	  // 19.1.2.3 Object.defineProperties(O, Properties)
	  defineProperties: $defineProperties,
	  // 19.1.2.6 Object.getOwnPropertyDescriptor(O, P)
	  getOwnPropertyDescriptor: $getOwnPropertyDescriptor,
	  // 19.1.2.7 Object.getOwnPropertyNames(O)
	  getOwnPropertyNames: $getOwnPropertyNames,
	  // 19.1.2.8 Object.getOwnPropertySymbols(O)
	  getOwnPropertySymbols: $getOwnPropertySymbols
	});
	
	// 24.3.2 JSON.stringify(value [, replacer [, space]])
	$JSON && $export($export.S + $export.F * (!USE_NATIVE || $fails(function(){
	  var S = $Symbol();
	  // MS Edge converts symbol values to JSON as {}
	  // WebKit converts symbol values to JSON as null
	  // V8 throws on boxed symbols
	  return _stringify([S]) != '[null]' || _stringify({a: S}) != '{}' || _stringify(Object(S)) != '{}';
	})), 'JSON', {
	  stringify: function stringify(it){
	    if(it === undefined || isSymbol(it))return; // IE8 returns string on undefined
	    var args = [it]
	      , i    = 1
	      , replacer, $replacer;
	    while(arguments.length > i)args.push(arguments[i++]);
	    replacer = args[1];
	    if(typeof replacer == 'function')$replacer = replacer;
	    if($replacer || !isArray(replacer))replacer = function(key, value){
	      if($replacer)value = $replacer.call(this, key, value);
	      if(!isSymbol(value))return value;
	    };
	    args[1] = replacer;
	    return _stringify.apply($JSON, args);
	  }
	});
	
	// 19.4.3.4 Symbol.prototype[@@toPrimitive](hint)
	$Symbol[PROTOTYPE][TO_PRIMITIVE] || __webpack_require__(36)($Symbol[PROTOTYPE], TO_PRIMITIVE, $Symbol[PROTOTYPE].valueOf);
	// 19.4.3.5 Symbol.prototype[@@toStringTag]
	setToStringTag($Symbol, 'Symbol');
	// 20.2.1.9 Math[@@toStringTag]
	setToStringTag(Math, 'Math', true);
	// 24.3.3 JSON[@@toStringTag]
	setToStringTag(global.JSON, 'JSON', true);

/***/ },
/* 182 */
/***/ function(module, exports, __webpack_require__) {

	var META     = __webpack_require__(70)('meta')
	  , isObject = __webpack_require__(39)
	  , has      = __webpack_require__(55)
	  , setDesc  = __webpack_require__(37).f
	  , id       = 0;
	var isExtensible = Object.isExtensible || function(){
	  return true;
	};
	var FREEZE = !__webpack_require__(42)(function(){
	  return isExtensible(Object.preventExtensions({}));
	});
	var setMeta = function(it){
	  setDesc(it, META, {value: {
	    i: 'O' + ++id, // object ID
	    w: {}          // weak collections IDs
	  }});
	};
	var fastKey = function(it, create){
	  // return primitive with prefix
	  if(!isObject(it))return typeof it == 'symbol' ? it : (typeof it == 'string' ? 'S' : 'P') + it;
	  if(!has(it, META)){
	    // can't set metadata to uncaught frozen object
	    if(!isExtensible(it))return 'F';
	    // not necessary to add metadata
	    if(!create)return 'E';
	    // add missing metadata
	    setMeta(it);
	  // return object ID
	  } return it[META].i;
	};
	var getWeak = function(it, create){
	  if(!has(it, META)){
	    // can't set metadata to uncaught frozen object
	    if(!isExtensible(it))return true;
	    // not necessary to add metadata
	    if(!create)return false;
	    // add missing metadata
	    setMeta(it);
	  // return hash weak collections IDs
	  } return it[META].w;
	};
	// add metadata on freeze-family methods calling
	var onFreeze = function(it){
	  if(FREEZE && meta.NEED && isExtensible(it) && !has(it, META))setMeta(it);
	  return it;
	};
	var meta = module.exports = {
	  KEY:      META,
	  NEED:     false,
	  fastKey:  fastKey,
	  getWeak:  getWeak,
	  onFreeze: onFreeze
	};

/***/ },
/* 183 */
/***/ function(module, exports, __webpack_require__) {

	var global         = __webpack_require__(32)
	  , core           = __webpack_require__(33)
	  , LIBRARY        = __webpack_require__(53)
	  , wksExt         = __webpack_require__(81)
	  , defineProperty = __webpack_require__(37).f;
	module.exports = function(name){
	  var $Symbol = core.Symbol || (core.Symbol = LIBRARY ? {} : global.Symbol || {});
	  if(name.charAt(0) != '_' && !(name in $Symbol))defineProperty($Symbol, name, {value: wksExt.f(name)});
	};

/***/ },
/* 184 */
/***/ function(module, exports, __webpack_require__) {

	var getKeys   = __webpack_require__(60)
	  , toIObject = __webpack_require__(62);
	module.exports = function(object, el){
	  var O      = toIObject(object)
	    , keys   = getKeys(O)
	    , length = keys.length
	    , index  = 0
	    , key;
	  while(length > index)if(O[key = keys[index++]] === el)return key;
	};

/***/ },
/* 185 */
/***/ function(module, exports, __webpack_require__) {

	// all enumerable object keys, includes symbols
	var getKeys = __webpack_require__(60)
	  , gOPS    = __webpack_require__(186)
	  , pIE     = __webpack_require__(187);
	module.exports = function(it){
	  var result     = getKeys(it)
	    , getSymbols = gOPS.f;
	  if(getSymbols){
	    var symbols = getSymbols(it)
	      , isEnum  = pIE.f
	      , i       = 0
	      , key;
	    while(symbols.length > i)if(isEnum.call(it, key = symbols[i++]))result.push(key);
	  } return result;
	};

/***/ },
/* 186 */
/***/ function(module, exports) {

	exports.f = Object.getOwnPropertySymbols;

/***/ },
/* 187 */
/***/ function(module, exports) {

	exports.f = {}.propertyIsEnumerable;

/***/ },
/* 188 */
/***/ function(module, exports, __webpack_require__) {

	// 7.2.2 IsArray(argument)
	var cof = __webpack_require__(64);
	module.exports = Array.isArray || function isArray(arg){
	  return cof(arg) == 'Array';
	};

/***/ },
/* 189 */
/***/ function(module, exports, __webpack_require__) {

	var pIE            = __webpack_require__(187)
	  , createDesc     = __webpack_require__(45)
	  , toIObject      = __webpack_require__(62)
	  , toPrimitive    = __webpack_require__(44)
	  , has            = __webpack_require__(55)
	  , IE8_DOM_DEFINE = __webpack_require__(40)
	  , gOPD           = Object.getOwnPropertyDescriptor;
	
	exports.f = __webpack_require__(41) ? gOPD : function getOwnPropertyDescriptor(O, P){
	  O = toIObject(O);
	  P = toPrimitive(P, true);
	  if(IE8_DOM_DEFINE)try {
	    return gOPD(O, P);
	  } catch(e){ /* empty */ }
	  if(has(O, P))return createDesc(!pIE.f.call(O, P), O[P]);
	};

/***/ },
/* 190 */
/***/ function(module, exports) {



/***/ },
/* 191 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(183)('asyncIterator');

/***/ },
/* 192 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(183)('observable');

/***/ },
/* 193 */
/***/ function(module, exports) {

	module.exports = "<div v-el:select=\"\" :class=\"classes\" _v-0f3bb707=\"\">\n    <button type=\"button\" class=\"form-control dropdown-toggle\" :disabled=\"disabled || !hasParent\" :readonly=\"readonly\" @click=\"toggle()\" @keyup.esc=\"show = false\" _v-0f3bb707=\"\">\n      <span class=\"btn-content\" v-html=\"loading ? text.loading : showPlaceholder || selected\" _v-0f3bb707=\"\"></span>\n      <span v-if=\"clearButton&amp;&amp;values.length\" class=\"close\" @click=\"clear()\" _v-0f3bb707=\"\">×</span>\n    </button>\n    <select v-el:sel=\"\" v-model=\"value\" v-show=\"show\" name=\"{{name}}\" class=\"secret\" :multiple=\"multiple\" :required=\"required\" :readonly=\"readonly\" :disabled=\"disabled\" _v-0f3bb707=\"\">\n      <option v-if=\"required\" value=\"\" _v-0f3bb707=\"\"></option>\n      <option v-for=\"option in options\" :value=\"option[optionsValue]||option\" _v-0f3bb707=\"\">{{ option[optionsLabel]||option }}</option>\n    </select>\n    <ul class=\"dropdown-menu\" _v-0f3bb707=\"\">\n      <template v-if=\"options.length\" _v-0f3bb707=\"\">\n        <li v-if=\"canSearch\" class=\"bs-searchbox\" _v-0f3bb707=\"\">\n          <input type=\"text\" placeholder=\"{{searchText||text.search}}\" class=\"form-control\" autocomplete=\"off\" v-el:search=\"\" v-model=\"searchValue\" @keyup.esc=\"show = false\" _v-0f3bb707=\"\">\n          <span v-show=\"searchValue\" class=\"close\" @click=\"clearSearch\" _v-0f3bb707=\"\">×</span>\n        </li>\n        <li v-if=\"required&amp;&amp;!clearButton\" _v-0f3bb707=\"\"><a @mousedown.prevent=\"clear() &amp;&amp; blur()\" _v-0f3bb707=\"\">{{ placeholder || text.notSelected }}</a></li>\n        <li v-for=\"option in options | filterBy searchValue\" :id=\"option[optionsValue]||option\" _v-0f3bb707=\"\">\n          <a @mousedown.prevent=\"select(option[optionsValue],option)\" _v-0f3bb707=\"\">\n            <span v-html=\"option[optionsLabel]||option\" _v-0f3bb707=\"\"></span>\n            <span class=\"glyphicon glyphicon-ok check-mark\" v-show=\"isSelected(option[optionsValue])\" _v-0f3bb707=\"\"></span>\n          </a>\n        </li>\n      </template>\n      <slot _v-0f3bb707=\"\"></slot>\n      <div v-if=\"showNotify &amp;&amp; !closeOnSelect\" class=\"notify in\" transition=\"fadein\" _v-0f3bb707=\"\">{{limitText}}</div>\n    </ul>\n    <div v-if=\"showNotify &amp;&amp; closeOnSelect\" class=\"notify out\" transition=\"fadein\" _v-0f3bb707=\"\"><div _v-0f3bb707=\"\">{{limitText}}</div></div>\n  </div>";

/***/ },
/* 194 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(195)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(196)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Slider.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Slider.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Slider.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Slider.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Slider.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 195 */
/***/ function(module, exports) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	// <template>
	
	//   <div class="item">
	
	//     <slot></slot>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  data: function data() {
	    return {
	      index: 0,
	      show: false
	    };
	  },
	
	  computed: {
	    show: function show() {
	      return this.$parent.index === this.index;
	    }
	  },
	  ready: function ready() {
	    for (var c in this.$parent.$children) {
	      if (this.$parent.$children[c] === this) {
	        this.index = parseInt(c, 10);
	        break;
	      }
	    }
	    //this.index = [...this.$el.parentNode.children].indexOf(this.$el)
	    this.$parent.indicator.push(this.index);
	    if (this.index === 0) {
	      this.$el.classList.add('active');
	    }
	  }
	};
	// </script>

/***/ },
/* 196 */
/***/ function(module, exports) {

	module.exports = "<div class=\"item\">\r\n    <slot></slot>\r\n  </div>";

/***/ },
/* 197 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(198)
	module.exports = __webpack_require__(200)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(201)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Spinner.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Spinner.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Spinner.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Spinner.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Spinner.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 198 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(199);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7169b11e&file=Spinner.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Spinner.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7169b11e&file=Spinner.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Spinner.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 199 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, "@-webkit-keyframes spin {\r\n  100% {\r\n    -webkit-transform: rotate(360deg);\r\n            transform: rotate(360deg);\r\n  }\r\n}\r\n@keyframes spin {\r\n  100% {\r\n    -webkit-transform: rotate(360deg);\r\n            transform: rotate(360deg);\r\n  }\r\n}\r\n.spinner-gritcode {\r\n  top: 0;\r\n  left: 0;\r\n  bottom: 0;\r\n  right: 0;\r\n  z-index: 9998;\r\n  position: absolute;\r\n  width: 100%;\r\n  text-align: center;\r\n  background: rgba(255, 255, 255, 0.9);\r\n}\r\n.spinner-gritcode.spinner-fixed {\r\n  position: fixed;\r\n}\r\n.spinner-gritcode .spinner-wrapper {\r\n  position: absolute;\r\n  top: 50%;\r\n  left: 50%;\r\n  -webkit-transform: translate(-50%, -50%);\r\n          transform: translate(-50%, -50%);\r\n  -ms-transform: translate(-50%, -50%);\r\n}\r\n.spinner-gritcode .spinner-circle {\r\n  position: relative;\r\n  border: 4px solid #ccc;\r\n  border-right-color: #337ab7;\r\n  border-radius: 50%;\r\n  display: inline-block;\r\n  -webkit-animation: spin 0.6s linear;\r\n          animation: spin 0.6s linear;\r\n  -webkit-animation-iteration-count: infinite;\r\n          animation-iteration-count: infinite;\r\n  width: 3em;\r\n  height: 3em;\r\n  z-index: 2;\r\n}\r\n.spinner-gritcode .spinner-text {\r\n  position: relative;\r\n  text-align: center;\r\n  margin-top: 0.5em;\r\n  z-index: 2;\r\n  width: 100%;\r\n  font-size: 95%;\r\n  color: #337ab7;\r\n}\r\n.spinner-gritcode.spinner-sm .spinner-circle {\r\n  width: 1.5em;\r\n  height: 1.5em;\r\n}\r\n.spinner-gritcode.spinner-md .spinner-circle {\r\n  width: 2em;\r\n  height: 2em;\r\n}\r\n.spinner-gritcode.spinner-lg .spinner-circle {\r\n  width: 2.5em;\r\n  height: 2.5em;\r\n}\r\n.spinner-gritcode.spinner-xl .spinner-circle {\r\n  width: 3.5em;\r\n  height: 3.5em;\r\n}\r\n.lt-ie10 .spinner-gritcode .spinner-circle,\r\n.ie9 .spinner-gritcode .spinner-circle,\r\n.oldie .spinner-gritcode .spinner-circle,\r\n.no-csstransitions .spinner-gritcode .spinner-circle,\r\n.no-csstransforms3d .spinner-gritcode .spinner-circle {\r\n  background: url(\"http://i2.wp.com/www.thegreatnovelingadventure.com/wp-content/plugins/wp-polls/images/loading.gif\") center center no-repeat;\r\n  -webkit-animation: none;\r\n          animation: none;\r\n  margin-left: 0;\r\n  margin-top: 5px;\r\n  border: none;\r\n  width: 32px;\r\n  height: 32px;\r\n}", ""]);
	
	// exports


/***/ },
/* 200 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var MIN_WAIT = 500; // in ms
	
	// <template>
	
	//   <div :class="['spinner spinner-gritcode',spinnerSize,{'spinner-fixed':fixed}]" v-show="active">
	
	//     <div class="spinner-wrapper">
	
	//       <div class="spinner-circle"></div>
	
	//       <div class="spinner-text">{{text}}</div>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  props: {
	    size: {
	      type: String,
	      default: 'md'
	    },
	    text: {
	      type: String,
	      default: ''
	    },
	    fixed: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  },
	  data: function data() {
	    return {
	      active: false
	    };
	  },
	
	  computed: {
	    spinnerSize: function spinnerSize() {
	      return this.size ? 'spinner-' + this.size : 'spinner-sm';
	    }
	  },
	  ready: function ready() {
	    this._body = document.querySelector('body');
	    this._bodyOverflow = this._body.style.overflowY || '';
	  },
	
	  methods: {
	    getMinWait: function getMinWait(delay) {
	      delay = delay || 0;
	      return new Date().getTime() - this._started.getTime() < MIN_WAIT ? MIN_WAIT - parseInt(new Date().getTime() - this._started.getTime(), 10) + delay : 0 + delay;
	    },
	    show: function show(options) {
	      if (options && options.text) {
	        this.text = options.text;
	      }
	      if (options && options.size) {
	        this.size = options.size;
	      }
	      if (options && options.fixed) {
	        this.fixed = options.fixed;
	      }
	
	      // block scrolling when spinner is on
	      this._body.style.overflowY = 'hidden';
	
	      // activate spinner
	      this._started = new Date();
	      this.active = true;
	      this.$root.$broadcast('shown::spinner');
	    },
	    hide: function hide() {
	      var _this = this;
	
	      var delay = 0;
	      this._spinnerAnimation = setTimeout(function () {
	        _this.active = false;
	        _this._body.style.overflowY = _this._bodyOverflow;
	        _this.$root.$broadcast('hidden::spinner');
	      }, this.getMinWait(delay));
	    }
	  },
	  events: {
	    'show::spinner': function showSpinner(options) {
	      this.show(options);
	    },
	    'hide::spinner': function hideSpinner() {
	      this.hide();
	    },
	    'start::ajax': function startAjax(options) {
	      this.show(options);
	    },
	    'end::ajax': function endAjax() {
	      this.hide();
	    }
	  },
	  beforeDestroy: function beforeDestroy() {
	    clearTimeout(this._spinnerAnimation);
	    this._body.style.overflowY = this._bodyOverflow;
	  }
	};
	// </script>
	
	
	// <style>
	
	// @keyframes spin {
	
	//   100% {
	
	//     transform: rotate(360deg);
	
	//   }
	
	// }
	
	// .spinner-gritcode {
	
	//   top: 0;
	
	//   left: 0;
	
	//   bottom: 0;
	
	//   right: 0;
	
	//   z-index: 9998;
	
	//   position: absolute;
	
	//   width: 100%;
	
	//   text-align: center;
	
	//   background: rgba(255, 255, 255, 0.9);
	
	// }
	
	// .spinner-gritcode.spinner-fixed {
	
	//   position: fixed;
	
	// }
	
	// .spinner-gritcode .spinner-wrapper {
	
	//   position: absolute;
	
	//   top: 50%;
	
	//   left: 50%;
	
	//   transform: translate(-50%, -50%);
	
	//   -ms-transform: translate(-50%, -50%);
	
	// }
	
	// .spinner-gritcode .spinner-circle {
	
	//   position: relative;
	
	//   border: 4px solid #ccc;
	
	//   border-right-color: #337ab7;
	
	//   border-radius: 50%;
	
	//   display: inline-block;
	
	//   animation: spin 0.6s linear;
	
	//   animation-iteration-count: infinite;
	
	//   width: 3em;
	
	//   height: 3em;
	
	//   z-index: 2;
	
	// }
	
	// .spinner-gritcode .spinner-text {
	
	//   position: relative;
	
	//   text-align: center;
	
	//   margin-top: 0.5em;
	
	//   z-index: 2;
	
	//   width: 100%;
	
	//   font-size: 95%;
	
	//   color: #337ab7;
	
	// }
	
	// .spinner-gritcode.spinner-sm .spinner-circle {
	
	//   width: 1.5em;
	
	//   height: 1.5em;
	
	// }
	
	// .spinner-gritcode.spinner-md .spinner-circle {
	
	//   width: 2em;
	
	//   height: 2em;
	
	// }
	
	// .spinner-gritcode.spinner-lg .spinner-circle {
	
	//   width: 2.5em;
	
	//   height: 2.5em;
	
	// }
	
	// .spinner-gritcode.spinner-xl .spinner-circle {
	
	//   width: 3.5em;
	
	//   height: 3.5em;
	
	// }
	
	// .lt-ie10 .spinner-gritcode .spinner-circle,
	
	// .ie9 .spinner-gritcode .spinner-circle,
	
	// .oldie .spinner-gritcode .spinner-circle,
	
	// .no-csstransitions .spinner-gritcode .spinner-circle,
	
	// .no-csstransforms3d .spinner-gritcode .spinner-circle {
	
	//   background: url("http://i2.wp.com/www.thegreatnovelingadventure.com/wp-content/plugins/wp-polls/images/loading.gif") center center no-repeat;
	
	//   animation: none;
	
	//   margin-left: 0;
	
	//   margin-top: 5px;
	
	//   border: none;
	
	//   width: 32px;
	
	//   height: 32px;
	
	// }
	
	// </style>

/***/ },
/* 201 */
/***/ function(module, exports) {

	module.exports = "<div :class=\"['spinner spinner-gritcode',spinnerSize,{'spinner-fixed':fixed}]\" v-show=\"active\">\r\n    <div class=\"spinner-wrapper\">\r\n      <div class=\"spinner-circle\"></div>\r\n      <div class=\"spinner-text\">{{text}}</div>\r\n    </div>\r\n  </div>";

/***/ },
/* 202 */
/***/ function(module, exports, __webpack_require__) {

	module.exports = __webpack_require__(203)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(204)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tab.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tab.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tab.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tab.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tab.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 203 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    header: {
	      type: String
	    },
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    }
	  },
	  computed: {
	    active: function active() {
	      return this._tabset.show === this;
	    },
	    index: function index() {
	      return this._tabset.tabs.indexOf(this);
	    },
	    show: function show() {
	      return this._tabset && this._tabset.show === this;
	    },
	    transition: function transition() {
	      return this._tabset ? this._tabset.effect : null;
	    }
	  },
	  created: function created() {
	    this._ingroup = this.$parent && this.$parent._tabgroup;
	    var tabset = this;
	    while (tabset && tabset._tabset !== true && tabset.$parent) {
	      tabset = tabset.$parent;
	    }
	    if (!tabset._tabset) {
	      this._tabset = {};
	      console.warn('Warning: "tab" depend on "tabset" to work properly.');
	    } else {
	      tabset.tabs.push(this);
	      if (!this._ingroup) {
	        tabset.headers.push(this);
	      } else {
	        if (!~tabset.headers.indexOf(this.$parent)) {
	          tabset.headers.push(this.$parent);
	        }
	      }
	      this._tabset = tabset;
	    }
	    if (this._ingroup) {
	      this.$parent.tabs.push(this);
	    }
	  },
	  beforeDestroy: function beforeDestroy() {
	    if (this._tabset.active === this.index) {
	      this._tabset.active = 0;
	    }
	    if (this._ingroup) {
	      this.$parent.tabs.$remove(this);
	    }
	    this._tabset.tabs.$remove(this);
	  }
	};
	// </script>
	// <template>
	
	//   <div role="tabpanel" class="tab-pane active" v-show="show"
	
	//     :class="{hide:!show}"
	
	//     :transition="transition"
	
	//   >
	
	//     <slot></slot>
	
	//   </div>
	
	// </template>
	
	
	// <script>

/***/ },
/* 204 */
/***/ function(module, exports) {

	module.exports = "<div role=\"tabpanel\" class=\"tab-pane active\" v-show=\"show\"\r\n    :class=\"{hide:!show}\"\r\n    :transition=\"transition\"\r\n  >\r\n    <slot></slot>\r\n  </div>";

/***/ },
/* 205 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(206)
	module.exports = __webpack_require__(208)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(209)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./TabGroup.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./TabGroup.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-7ecb8635&file=TabGroup.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./TabGroup.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./TabGroup.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-7ecb8635&file=TabGroup.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./TabGroup.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 206 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(207);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7ecb8635&file=TabGroup.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./TabGroup.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-7ecb8635&file=TabGroup.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./TabGroup.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 207 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".nav-tabs[_v-7ecb8635] {\r\n  margin-bottom: 15px;\r\n}", ""]);
	
	// exports


/***/ },
/* 208 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	exports.default = {
	  props: {
	    disabled: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    header: {
	      type: String
	    }
	  },
	  data: function data() {
	    return {
	      tabs: [],
	      show: false
	    };
	  },
	
	  computed: {
	    active: function active() {
	      return ~this.tabs.indexOf(this._tabset.show);
	    }
	  },
	  created: function created() {
	    this._tabgroup = true;
	    var tabset = this.$parent && this.$parent._tabset === true ? this.$parent : {};
	    if (this.$parent && this.$parent._tabgroup) {
	      console.error('Can\'t nest tabgroups.');
	    }
	    while (tabset && !tabset._tabset && tabset.$parent) {
	      tabset = tabset.$parent;
	    }
	    if (!tabset._tabset) {
	      this._tabset = {};
	      this.show = true;
	      console.warn('Warning: tabgroup depend on tabset to work properly.');
	    } else {
	      this._tabset = tabset;
	    }
	  },
	
	  methods: {
	    blur: function blur() {
	      this.show = false;
	    },
	    toggle: function toggle() {
	      this.show = !this.show;
	    }
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// .nav-tabs {
	
	//   margin-bottom: 15px;
	
	// }
	
	// </style>
	// <template><slot></slot></template>
	
	
	// <script>

/***/ },
/* 209 */
/***/ function(module, exports) {

	module.exports = "<slot _v-7ecb8635=\"\"></slot>";

/***/ },
/* 210 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(211)
	module.exports = __webpack_require__(213)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(214)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tabset.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tabset.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-e8aecb90&file=Tabset.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tabset.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tabset.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/template-rewriter.js?id=_v-e8aecb90&file=Tabset.vue!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tabset.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 211 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(212);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-e8aecb90&file=Tabset.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Tabset.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-e8aecb90&file=Tabset.vue&scoped=true!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Tabset.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 212 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".nav-tabs[_v-e8aecb90] {\r\n  margin-bottom: 15px;\r\n}", ""]);
	
	// exports


/***/ },
/* 213 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var _Dropdown = __webpack_require__(127);
	
	var _Dropdown2 = _interopRequireDefault(_Dropdown);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	// <template>
	
	//   <div>
	
	//     <!-- Nav tabs -->
	
	//     <ul class="nav nav-{{navStyle}}" role="tablist">
	
	//       <template v-for="t in headers">
	
	//         <li v-if="!t._tabgroup" :class="{active:t.active, disabled:t.disabled}" @click.prevent="select(t)">
	
	//           <a href="#"><slot name="header">{{{t.header}}}</slot></a>
	
	//         </li>
	
	//         <dropdown v-else :text="t.header" :class="{active:t.active}" :disabled="t.disabled">
	
	//           <li v-for="tab in t.tabs" :class="{disabled:tab.disabled}"><a href="#" @click.prevent="select(tab)">{{tab.header}}</a></li>
	
	//         </dropdown>
	
	//       </template>
	
	//     </ul>
	
	//     <div class="tab-content" v-el:tab-content>
	
	//       <slot></slot>
	
	//     </div>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	exports.default = {
	  components: {
	    dropdown: _Dropdown2.default
	  },
	  props: {
	    navStyle: {
	      type: String,
	      default: 'tabs'
	    },
	    effect: {
	      type: String,
	      default: 'fadein'
	    },
	    active: {
	      twoWay: true,
	      type: Number,
	      coerce: _utils.coerce.number,
	      default: 0
	    }
	  },
	  data: function data() {
	    return {
	      show: null,
	      headers: [],
	      tabs: []
	    };
	  },
	  created: function created() {
	    this._tabset = true;
	  },
	
	  watch: {
	    active: function active(val) {
	      this.show = this.tabs[val];
	    }
	  },
	  ready: function ready() {
	    this.show = this.tabs[this.active];
	  },
	
	  methods: {
	    select: function select(tab) {
	      if (!tab.disabled) {
	        this.active = tab.index;
	      }
	    }
	  }
	};
	// </script>
	
	
	// <style scoped>
	
	// .nav-tabs {
	
	//   margin-bottom: 15px;
	
	// }
	
	// </style>

/***/ },
/* 214 */
/***/ function(module, exports) {

	module.exports = "<div _v-e8aecb90=\"\">\n    <!-- Nav tabs -->\n    <ul class=\"nav nav-{{navStyle}}\" role=\"tablist\" _v-e8aecb90=\"\">\n      <template v-for=\"t in headers\" _v-e8aecb90=\"\">\n        <li v-if=\"!t._tabgroup\" :class=\"{active:t.active, disabled:t.disabled}\" @click.prevent=\"select(t)\" _v-e8aecb90=\"\">\n          <a href=\"#\" _v-e8aecb90=\"\"><slot name=\"header\" _v-e8aecb90=\"\">{{{t.header}}}</slot></a>\n        </li>\n        <dropdown v-else=\"\" :text=\"t.header\" :class=\"{active:t.active}\" :disabled=\"t.disabled\" _v-e8aecb90=\"\">\n          <li v-for=\"tab in t.tabs\" :class=\"{disabled:tab.disabled}\" _v-e8aecb90=\"\"><a href=\"#\" @click.prevent=\"select(tab)\" _v-e8aecb90=\"\">{{tab.header}}</a></li>\n        </dropdown>\n      </template>\n    </ul>\n    <div class=\"tab-content\" v-el:tab-content=\"\" _v-e8aecb90=\"\">\n      <slot _v-e8aecb90=\"\"></slot>\n    </div>\n  </div>";

/***/ },
/* 215 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(216)
	module.exports = __webpack_require__(218)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(219)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tooltip.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tooltip.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tooltip.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Tooltip.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Tooltip.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 216 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(217);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-000c6bf0&file=Tooltip.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Tooltip.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-000c6bf0&file=Tooltip.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Tooltip.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 217 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".tooltip.top,\r\n.tooltip.left,\r\n.tooltip.right,\r\n.tooltip.bottom {\r\n  opacity: .9\r\n}\r\n.fadein-enter {\r\n  -webkit-animation:fadein-in 0.3s ease-in;\r\n          animation:fadein-in 0.3s ease-in;\r\n}\r\n.fadein-leave {\r\n  -webkit-animation:fadein-out 0.3s ease-out;\r\n          animation:fadein-out 0.3s ease-out;\r\n}\r\n@-webkit-keyframes fadein-in {\r\n  0% {\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    opacity: .9;\r\n  }\r\n}\r\n@keyframes fadein-in {\r\n  0% {\r\n    opacity: 0;\r\n  }\r\n  100% {\r\n    opacity: .9;\r\n  }\r\n}\r\n@-webkit-keyframes fadein-out {\r\n  0% {\r\n    opacity: .9;\r\n  }\r\n  100% {\r\n    opacity: 0;\r\n  }\r\n}\r\n@keyframes fadein-out {\r\n  0% {\r\n    opacity: .9;\r\n  }\r\n  100% {\r\n    opacity: 0;\r\n  }\r\n}", ""]);
	
	// exports


/***/ },
/* 218 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _popoverMixins = __webpack_require__(164);
	
	var _popoverMixins2 = _interopRequireDefault(_popoverMixins);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	exports.default = {
	  mixins: [_popoverMixins2.default],
	  props: {
	    trigger: {
	      type: String,
	      default: 'hover'
	    },
	    effect: {
	      type: String,
	      default: 'scale'
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .tooltip.top,
	
	// .tooltip.left,
	
	// .tooltip.right,
	
	// .tooltip.bottom {
	
	//   opacity: .9
	
	// }
	
	// .fadein-enter {
	
	//   animation:fadein-in 0.3s ease-in;
	
	// }
	
	// .fadein-leave {
	
	//   animation:fadein-out 0.3s ease-out;
	
	// }
	
	// @keyframes fadein-in {
	
	//   0% {
	
	//     opacity: 0;
	
	//   }
	
	//   100% {
	
	//     opacity: .9;
	
	//   }
	
	// }
	
	// @keyframes fadein-out {
	
	//   0% {
	
	//     opacity: .9;
	
	//   }
	
	//   100% {
	
	//     opacity: 0;
	
	//   }
	
	// }
	
	// </style>
	// <template>
	
	//   <span v-el:trigger>
	
	//     <slot></slot>
	
	//     <div v-el:popover v-if="show" style="display:block;"
	
	//       :class="['tooltip',placement]"
	
	//       :transition="effect"
	
	//     >
	
	//       <div class="tooltip-arrow"></div>
	
	//       <div class="tooltip-inner">
	
	//         <slot name="content">{{{content}}}</slot>
	
	//     </div>
	
	//     </div>
	
	//   </span>
	
	// </template>
	
	
	// <script>

/***/ },
/* 219 */
/***/ function(module, exports) {

	module.exports = "<span v-el:trigger>\r\n    <slot></slot>\r\n    <div v-el:popover v-if=\"show\" style=\"display:block;\"\r\n      :class=\"['tooltip',placement]\"\r\n      :transition=\"effect\"\r\n    >\r\n      <div class=\"tooltip-arrow\"></div>\r\n      <div class=\"tooltip-inner\">\r\n        <slot name=\"content\">{{{content}}}</slot>\r\n    </div>\r\n    </div>\r\n  </span>";

/***/ },
/* 220 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(221)
	module.exports = __webpack_require__(223)
	
	if (module.exports.__esModule) module.exports = module.exports.default
	;(typeof module.exports === "function" ? module.exports.options : module.exports).template = __webpack_require__(224)
	if (false) {
	(function () {
	var hotAPI = require("vue-hot-reload-api")
	hotAPI.install(require("vue"))
	if (!hotAPI.compatible) return
	var id = "-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Typeahead.vue"
	hotAPI.createRecord(id, module.exports)
	module.hot.accept(["-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Typeahead.vue","-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Typeahead.vue"], function () {
	var newOptions = require("-!babel!./../node_modules/vue-loader/lib/selector.js?type=script&index=0!./Typeahead.vue")
	if (newOptions && newOptions.__esModule) newOptions = newOptions.default
	var newTemplate = require("-!vue-html-loader!./../node_modules/vue-loader/lib/selector.js?type=template&index=0!./Typeahead.vue")
	hotAPI.update(id, newOptions, newTemplate)
	})
	})()
	}

/***/ },
/* 221 */
/***/ function(module, exports, __webpack_require__) {

	// style-loader: Adds some css to the DOM by adding a <style> tag
	
	// load the styles
	var content = __webpack_require__(222);
	if(typeof content === 'string') content = [[module.id, content, '']];
	// add the styles to the DOM
	var update = __webpack_require__(101)(content, {});
	if(content.locals) module.exports = content.locals;
	// Hot Module Replacement
	if(false) {
		// When the styles change, update the <style> tags
		if(!content.locals) {
			module.hot.accept("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-78dbe8e8&file=Typeahead.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Typeahead.vue", function() {
				var newContent = require("!!./../node_modules/css-loader/index.js!./../node_modules/vue-loader/lib/style-rewriter.js?id=_v-78dbe8e8&file=Typeahead.vue!./../node_modules/vue-loader/lib/selector.js?type=style&index=0!./Typeahead.vue");
				if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
				update(newContent);
			});
		}
		// When the module is disposed, remove the <style> tags
		module.hot.dispose(function() { update(); });
	}

/***/ },
/* 222 */
/***/ function(module, exports, __webpack_require__) {

	exports = module.exports = __webpack_require__(100)();
	// imports
	
	
	// module
	exports.push([module.id, ".dropdown-menu > li > a {\r\n  cursor: pointer;\r\n}", ""]);
	
	// exports


/***/ },
/* 223 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	Object.defineProperty(exports, "__esModule", {
	  value: true
	});
	
	var _utils = __webpack_require__(92);
	
	var Vue = window.Vue; // <template>
	
	//   <div style="position: relative"
	
	//        v-bind:class="{'open':showDropdown}"
	
	//   >
	
	//     <input type="text" class="form-control"
	
	//       :placeholder="placeholder"
	
	//       autocomplete="off"
	
	//       v-model="value"
	
	//       @input="update"
	
	//       @keydown.up="up"
	
	//       @keydown.down="down"
	
	//       @keydown.enter= "hit"
	
	//       @keydown.esc="reset"
	
	//       @blur="showDropdown = false"
	
	//     />
	
	//     <ul class="dropdown-menu" v-el:dropdown>
	
	//       <li v-for="item in items" v-bind:class="{'active': isActive($index)}">
	
	//         <a @mousedown.prevent="hit" @mousemove="setActive($index)">
	
	//           <partial :name="templateName"></partial>
	
	//         </a>
	
	//       </li>
	
	//     </ul>
	
	//   </div>
	
	// </template>
	
	
	// <script>
	
	var _DELAY_ = 200;
	
	exports.default = {
	  created: function created() {
	    this.items = this.primitiveData;
	  },
	
	  partials: {
	    default: '<span v-html="item | highlight value"></span>'
	  },
	  props: {
	    value: {
	      twoWay: true,
	      type: String,
	      default: ''
	    },
	    data: {
	      type: Array
	    },
	    limit: {
	      type: Number,
	      default: 8
	    },
	    async: {
	      type: String
	    },
	    template: {
	      type: String
	    },
	    templateName: {
	      type: String,
	      default: 'default'
	    },
	    key: {
	      type: String,
	      default: null
	    },
	    matchCase: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    matchStart: {
	      type: Boolean,
	      coerce: _utils.coerce.boolean,
	      default: false
	    },
	    onHit: {
	      type: Function,
	      default: function _default(items) {
	        this.reset();
	        this.value = items;
	      }
	    },
	    placeholder: {
	      type: String
	    },
	    delay: {
	      type: Number,
	      default: _DELAY_,
	      coerce: _utils.coerce.number
	    }
	  },
	  data: function data() {
	    return {
	      showDropdown: false,
	      noResults: true,
	      current: 0,
	      items: []
	    };
	  },
	
	  computed: {
	    primitiveData: function primitiveData() {
	      var _this = this;
	
	      if (this.data) {
	        return this.data.filter(function (value) {
	          value = _this.matchCase ? value : value.toLowerCase();
	          var query = _this.matchCase ? _this.value : _this.value.toLowerCase();
	          return _this.matchStart ? value.indexOf(query) === 0 : value.indexOf(query) !== -1;
	        }).slice(0, this.limit);
	      }
	    }
	  },
	  ready: function ready() {
	    // register a partial:
	    if (this.templateName && this.templateName !== 'default') {
	      Vue.partial(this.templateName, this.template);
	    }
	  },
	
	  methods: {
	    update: function update() {
	      if (!this.value) {
	        this.reset();
	        return false;
	      }
	      if (this.data) {
	        this.items = this.primitiveData;
	        this.showDropdown = this.items.length > 0;
	      }
	      if (this.async) this.query();
	    },
	
	    query: (0, _utils.delayer)(function () {
	      var _this2 = this;
	
	      (0, _utils.getJSON)(this.async + this.value).then(function (data) {
	        _this2.items = (_this2.key ? data[_this2.key] : data).slice(0, _this2.limit);
	        _this2.showDropdown = _this2.items.length;
	      });
	    }, 'delay', _DELAY_),
	    reset: function reset() {
	      this.items = [];
	      this.value = '';
	      this.loading = false;
	      this.showDropdown = false;
	    },
	    setActive: function setActive(index) {
	      this.current = index;
	    },
	    isActive: function isActive(index) {
	      return this.current === index;
	    },
	    hit: function hit(e) {
	      e.preventDefault();
	      this.onHit(this.items[this.current], this);
	    },
	    up: function up() {
	      if (this.current > 0) this.current--;
	    },
	    down: function down() {
	      if (this.current < this.items.length - 1) this.current++;
	    }
	  },
	  filters: {
	    highlight: function highlight(value, phrase) {
	      return value.replace(new RegExp('(' + phrase + ')', 'gi'), '<strong>$1</strong>');
	    }
	  }
	};
	// </script>
	
	
	// <style>
	
	// .dropdown-menu > li > a {
	
	//   cursor: pointer;
	
	// }
	
	// </style>

/***/ },
/* 224 */
/***/ function(module, exports) {

	module.exports = "<div style=\"position: relative\"\r\n       v-bind:class=\"{'open':showDropdown}\"\r\n  >\r\n    <input type=\"text\" class=\"form-control\"\r\n      :placeholder=\"placeholder\"\r\n      autocomplete=\"off\"\r\n      v-model=\"value\"\r\n      @input=\"update\"\r\n      @keydown.up=\"up\"\r\n      @keydown.down=\"down\"\r\n      @keydown.enter= \"hit\"\r\n      @keydown.esc=\"reset\"\r\n      @blur=\"showDropdown = false\"\r\n    />\r\n    <ul class=\"dropdown-menu\" v-el:dropdown>\r\n      <li v-for=\"item in items\" v-bind:class=\"{'active': isActive($index)}\">\r\n        <a @mousedown.prevent=\"hit\" @mousemove=\"setActive($index)\">\r\n          <partial :name=\"templateName\"></partial>\r\n        </a>\r\n      </li>\r\n    </ul>\r\n  </div>";

/***/ }
/******/ ])
});
;
//# sourceMappingURL=vue-strap.js.map

/***/ }),
/* 68 */
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(33);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(6)("2e3f064e", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js?sourceMap!../../../node_modules/vue-loader/lib/style-compiler/index.js?{\"vue\":true,\"id\":\"data-v-0a10699e\",\"scoped\":false,\"hasInlineConfig\":false}!./navmenu.css", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js?sourceMap!../../../node_modules/vue-loader/lib/style-compiler/index.js?{\"vue\":true,\"id\":\"data-v-0a10699e\",\"scoped\":false,\"hasInlineConfig\":false}!./navmenu.css");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),
/* 69 */
/***/ (function(module, exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(34);
if(typeof content === 'string') content = [[module.i, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var update = __webpack_require__(6)("3c18abd9", content, false);
// Hot Module Replacement
if(false) {
 // When the styles change, update the <style> tags
 if(!content.locals) {
   module.hot.accept("!!../../../node_modules/css-loader/index.js?sourceMap!../../../node_modules/vue-loader/lib/style-compiler/index.js?{\"vue\":true,\"id\":\"data-v-4937f544\",\"scoped\":false,\"hasInlineConfig\":false}!./home.css", function() {
     var newContent = require("!!../../../node_modules/css-loader/index.js?sourceMap!../../../node_modules/vue-loader/lib/style-compiler/index.js?{\"vue\":true,\"id\":\"data-v-4937f544\",\"scoped\":false,\"hasInlineConfig\":false}!./home.css");
     if(typeof newContent === 'string') newContent = [[module.id, newContent, '']];
     update(newContent);
   });
 }
 // When the module is disposed, remove the <style> tags
 module.hot.dispose(function() { update(); });
}

/***/ }),
/* 70 */
/***/ (function(module, exports) {

/**
 * Translates the list format produced by css-loader into something
 * easier to manipulate.
 */
module.exports = function listToStyles (parentId, list) {
  var styles = []
  var newStyles = {}
  for (var i = 0; i < list.length; i++) {
    var item = list[i]
    var id = item[0]
    var css = item[1]
    var media = item[2]
    var sourceMap = item[3]
    var part = {
      id: parentId + ':' + i,
      css: css,
      media: media,
      sourceMap: sourceMap
    }
    if (!newStyles[id]) {
      styles.push(newStyles[id] = { id: id, parts: [part] })
    } else {
      newStyles[id].parts.push(part)
    }
  }
  return styles
}


/***/ }),
/* 71 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(3))(7);

/***/ })
/******/ ]);
//# sourceMappingURL=main.js.map