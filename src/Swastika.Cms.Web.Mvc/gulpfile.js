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

paths.js = paths.webroot + "app-portal/pages/**/*.js";
paths.minJs = paths.webroot + "app-portal/app.min.js";
paths.concatJsDest = paths.webroot + "js/site.min.js";

paths.sharedJs = paths.webroot + "app-shared/**/*.js";
paths.minJs = paths.webroot + "app-portal/app.min.js";
paths.concatSharedJsDest = paths.webroot + "js/shared.min.js";

paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:sharedJs", function (cb) {
    rimraf(paths.concatSharedJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:sharedJs", "clean:css"]);

gulp.task("min:js", function (cb) {
    var options = {};
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(minify(options))
        .pipe(gulp.dest("."));

});
gulp.task("min:sharedJs", function (cb) {
    var options = {};
    return gulp.src([paths.sharedJs, "!" + paths.minSharedJs], { base: "." })
        .pipe(concat(paths.concatSharedJsDest))
        .pipe(minify(options))
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:sharedJs", "min:css"]);