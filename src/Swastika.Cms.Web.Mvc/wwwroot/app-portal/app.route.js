app.config(function ($routeProvider, $locationProvider, $sceProvider) {
    $locationProvider.html5Mode(true);

    $routeProvider.when("/backend", {
        controller: "DashboardController",
        templateUrl: "/app-portal/pages/dashboard/dashboard.html"
    });

    $routeProvider.when("/backend/login", {
        controller: "loginController",
        templateUrl: "/app-portal/pages/login/login.html"
    });

    $routeProvider.when("/backend/product/list", {
        controller: "ProductController",
        templateUrl: "/app-portal/pages/product/list.html"
    });

    $routeProvider.when("/backend/product/details/:id", {
        controller: "ProductController",
        templateUrl: "/app-portal/pages/product/details.html"
    });

    $routeProvider.when("/backend/product/create", {
        controller: "ProductController",
        templateUrl: "/app-portal/pages/product/details.html"
    });

    $routeProvider.otherwise({ redirectTo: "/backend" });
});
