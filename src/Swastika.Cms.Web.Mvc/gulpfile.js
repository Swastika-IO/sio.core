/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    fontmin = require("gulp-fontmin"),
    htmlmin = require("gulp-htmlmin"),
    
    uglify = require("gulp-uglify");

var uglifyjs = require('uglify-es'); // can be a git checkout
// or another module (such as `uglify-es` for ES6 support)
var composer = require('gulp-uglify/composer');
var pump = require('pump');

var minify = composer(uglifyjs, console);
var dest = '.';//For publish folder use "./bin/Release/PublishOutput/";
var paths = {
    webroot: "./wwwroot/",
    jsObtions:{},
    htmlOptions:{collapseWhitespace: false},
    cssOptions:{}, //showLog : (True, false) to trun on or off of the log
    fontOptions:{fontPath: dest+ '/wwwroot/fonts'}
};

paths.views = {
    src: [
        paths.webroot + "app-shared/**/*.html",
        paths.webroot + "app-portal/**/*.html",
        paths.webroot + "app-client/**/*.html"
    ],
    dest: paths.webroot + "html/*.html"
};
paths.fonts = {
    src: [
        paths.webroot + "lib/micon/fonts/*.*"        
    ],
    dest: paths.webroot + dest + "/fonts"
};
paths.css = {
    src: [

        paths.webroot + "lib/micon/css/micon.css",
        paths.webroot + "lib/fontawesome-free-5.0.10/css/fontawesome-all.css",
        paths.webroot + "lib/open-iconic-master/font/css/open-iconic-bootstrap.min.css",
        paths.webroot + "lib/bootstrap4-tagsinput-4.1.2/tagsinput.css",
        paths.webroot + "lib/Trumbowyg-2.9.0/ui/trumbowyg.min.css",
        paths.webroot + "lib/Trumbowyg-2.9.0/plugins/colors/ui/trumbowyg.colors.css",        
        paths.webroot + "lib/flag-icon-css/css/flag-icon.min.css",

        paths.webroot + "app-shared/**/*.css",
        paths.webroot + "app-portal/**/*.css",
        paths.webroot + "app-client/**/*.css"
    ],
    dest : paths.webroot + "css/vendor.min.css"
};
paths.plugins ={
    src: [
        paths.webroot + "lib/Trumbowyg-2.9.0/**/*.min.js",
        paths.webroot + "lib/ace/src/ace.js",
        paths.webroot + "lib/ace/src/mode-csharp.js",
        paths.webroot + "lib/ace/src/mode-razor.js",
        paths.webroot + "lib/ace/src/mode-json.js",
        paths.webroot + "lib/ace/src/mode-css.js",
        paths.webroot + "lib/ace/src/mode-javascript.js",
        paths.webroot + "lib/ace/src/mode-html.js",
        paths.webroot + "lib/ace/src/theme-chrome.js",
        paths.webroot + "lib/ace/src/theme-clouds_midnight.js",
        paths.webroot + "lib/ace/src/worker-json.js",
    ],
    dest: paths.webroot + "js/vendor.min.js"
}
paths.portal = {
    src: [
        paths.webroot + "app-portal/pages/**/*.js"
    ],
    dest: paths.webroot + "js/app-portal.min.js"
};

paths.client = {
    src: [
        paths.webroot + "app-client/components/**/*.js"
    ],
    dest: paths.webroot + "js/app-client.min.js"
};

paths.sharedJs = {
    src: [
        paths.webroot + "app-shared/**/*.js",
        paths.webroot + "app-shared/**/*.*.js"
    ],
    dest: paths.webroot + "js/app-shared.min.js"
};



gulp.task("clean:js", function (cb) {
    rimraf(paths.portal.dest, cb);
});

gulp.task("clean:clientJs", function (cb) {
    rimraf(paths.client.dest, cb);
});

gulp.task("clean:sharedJs", function (cb) {
    rimraf(paths.sharedJs.dest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.css.dest, cb);
});

gulp.task("clean", ["clean:js", "clean:clientJs","clean:sharedJs", "clean:css"]);

gulp.task("min:plugins", function (cb) {    
    return gulp.src(paths.plugins.src, { base: "." })
        .pipe(concat(paths.plugins.dest))
        //.pipe(minify(paths.jsOptions))
        .pipe(gulp.dest(dest));

});

gulp.task("min:js", function (cb) {    
    return gulp.src(paths.portal.src, { base: "." })
        .pipe(concat(paths.portal.dest))
        //.pipe(minify(paths.jsOptions))
        .pipe(gulp.dest(dest));

});

gulp.task("min:views", function (cb) {
    return gulp.src(paths.views.src, { base: "." })        
        .pipe(htmlmin(paths.htmlOptions))
        .pipe(gulp.dest(dest));

});
gulp.task("min:fonts", function (cb) {
    return gulp.src(paths.fonts.src, { base: "." })          
        .pipe(fontmin(paths.fontOptions))
        .pipe(gulp.dest(paths.fonts.dest));

});
gulp.task("min:clientJs", function (cb) {
    return gulp.src(paths.client.src, { base: "." })
        .pipe(concat(paths.client.dest))
        .pipe(minify(paths.jsOptions))
        .pipe(gulp.dest(dest));

});

gulp.task("min:sharedJs", function (cb) {    
    return gulp.src(paths.sharedJs.src, { base: "." })
        .pipe(concat(paths.sharedJs.dest))
        //.pipe(minify(paths.jsOptions))
        .pipe(gulp.dest(dest));

});

gulp.task("min:css", function (cb) {
    return gulp.src(paths.css.src, { base: "." })
        .pipe(concat(paths.css.dest))
        .pipe(cssmin(paths.cssOptions))
        .pipe(gulp.dest(dest));

});

//gulp.task("min:js", function (cb) {
//    var options = {};
//    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
//        .pipe(concat(paths.concatJsDest))
//        .pipe(minify(options))
//        .pipe(gulp.dest("."));

//});
//gulp.task("min:sharedJs", function (cb) {
//    var options = {};
//    return gulp.src([paths.sharedJs, "!" + paths.minSharedJs], { base: "." })
//        .pipe(concat(paths.concatSharedJsDest))
//        .pipe(minify(options))
//        .pipe(gulp.dest("."));
//});

//gulp.task("min:css", function () {
//    return gulp.src([paths.css, "!" + paths.minCss])
//        .pipe(concat(paths.concatCssDest))
//        .pipe(cssmin())
//        .pipe(gulp.dest("."));
//});

gulp.task("min", ["min:plugins", "min:js", "min:clientJs","min:sharedJs", "min:css", "min:fonts"]);