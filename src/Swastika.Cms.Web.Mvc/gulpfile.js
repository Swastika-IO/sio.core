/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var uglifyjs = require('uglify-es'); // can be a git checkout
// or another module (such as `uglify-es` for ES6 support)
var composer = require('gulp-uglify/composer');
var pump = require('pump');

var minify = composer(uglifyjs, console);

var paths = {
    webroot: "./wwwroot/"
};

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

paths.css = {
    src: [
        paths.webroot + "css/**/*.css"
    ],
    dest : paths.webroot + "css/site.min.css"
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

gulp.task("min:js", function (cb) {
    var options = {};
    return gulp.src(paths.portal.src, { base: "." })
        .pipe(concat(paths.portal.dest))
        //.pipe(minify(options))
        .pipe(gulp.dest("."));

});
gulp.task("min:clientJs", function (cb) {
    var options = {};
    return gulp.src(paths.client.src, { base: "." })
        .pipe(concat(paths.client.dest))
        //.pipe(minify(options))
        .pipe(gulp.dest("."));

});

gulp.task("min:sharedJs", function (cb) {
    var options = {};
    return gulp.src(paths.sharedJs.src, { base: "." })
        .pipe(concat(paths.sharedJs.dest))
        //.pipe(minify(options))
        .pipe(gulp.dest("."));

});

gulp.task("min:css", function (cb) {
    var options = {};
    return gulp.src(paths.css.src, { base: "." })
        .pipe(concat(paths.css.dest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));

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

gulp.task("min", ["min:js", "min:clientJs","min:sharedJs", "min:css"]);