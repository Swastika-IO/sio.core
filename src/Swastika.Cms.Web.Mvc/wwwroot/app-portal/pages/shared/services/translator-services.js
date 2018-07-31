'use strict';
app.service('translator', ['commonServices', function (commonServices) {

    var translator = {};
    this.init = async function () {
        translator = await commonServices.getTranslator();
    }
    this.get = function (keyword) {
        if (translator) {
            return translator[keyword] || '[' + keyword + ']';
        }
        else {
            return keyword;
        }
    };
}]);
