app.config(function ($routeProvider, $locationProvider, $sceProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider.when("/portal/init", {
        controller: "Step1Controller",
        templateUrl: "/app-init/pages/step1/index.html"
    });

    $routeProvider.when("/portal/init/step2", {
        controller: "Step2Controller",
        templateUrl: "/app-init/pages/step2/index.html"
    });

    $routeProvider.otherwise({ redirectTo: "/portal/init" });
});
