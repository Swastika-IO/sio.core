'use strict';
app.controller('loginController', ['$rootScope', '$scope', '$location', 'authService', 'ngAuthSettings', function ($rootScope, $scope, $location, authService, ngAuthSettings) {
    if (authService.authentication.isAuth && authService.authentication.isAdmin) {
        authService.authentication.referredUrl = $location.path();
        $location.path('/admin');
    }

    $scope.pageClass = 'page-login';

    $scope.loginData = {
        username: "",
        password: "",
        rememberme: false
    };

    $scope.message = "";
    $scope.$on('$viewContentLoaded', function () {
        $rootScope.isBusy = false;
    });
    $scope.login = function () {
        $rootScope.isBusy = true;
        if (authService.authentication.referredUrl == "/backend/login") {
            authService.authentication.referredUrl = "/backend";
        }
        authService.login($scope.loginData).then(function (response) {
            $scope.message = "";
            $rootScope.isBusy = false;
            $location.path(authService.authentication.referredUrl);
        },
            function (err) {
                $scope.message = err.error_description;
            });
    };

    $scope.authExternalProvider = function (provider) {

        var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';

        var externalProviderUrl = ngAuthSettings.apiServiceBaseUri + "api/Account/ExternalLogin?provider=" + provider
            + "&response_type=token&client_id=" + ngAuthSettings.clientId
            + "&redirect_uri=" + redirectUri;
        window.$windowScope = $scope;

        var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
    };

    $scope.authCompletedCB = function (fragment) {

        $scope.$apply(function () {

            if (fragment.haslocalaccount == 'False') {

                authService.logOut();

                authService.externalAuthData = {
                    provider: fragment.provider,
                    userName: fragment.external_user_name,
                    externalAccessToken: fragment.external_access_token
                };

                $location.path('/associate');

            }
            else {
                //Obtain access token and redirect to orders
                var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                authService.obtainAccessToken(externalData).then(function (response) {

                    $location.path('/orders');

                },
                    function (err) {
                        $scope.message = err.error_description;
                    });
            }

        });
    }
}]);