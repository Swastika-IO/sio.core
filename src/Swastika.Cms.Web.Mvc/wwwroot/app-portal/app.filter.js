'use strict'
app.filter('utcToLocal', Filter)
    .constant('ngAuthSettings', {
        apiServiceBaseUri: '',
        serviceBase: '',
        clientId: 'ngAuthApp',
        facebookAppId: '464285300363325'
    });

function Filter($filter) {
    return function (utcDateString, format) {
        // return if input date is null or undefined
        if (!utcDateString) {
            return;
        }

        // append 'Z' to the date string to indicate UTC time if the timezone isn't already specified
        if (utcDateString.indexOf('Z') === -1 && utcDateString.indexOf('+') === -1) {
            utcDateString += 'Z';
        }

        // convert and format date using the built in angularjs date filter
        return $filter('date')(utcDateString, format);
    };
}