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

    $routeProvider.when("/backend/article/list", {
        controller: "ArticleController",
        templateUrl: "/app-portal/pages/article/list.html"
    });

    $routeProvider.when("/backend/article/details/:id", {
        controller: "ArticleController",
        templateUrl: "/app-portal/pages/article/details.html"
    });

    $routeProvider.when("/backend/article/create", {
        controller: "ArticleController",
        templateUrl: "/app-portal/pages/article/details.html"
    });

    $routeProvider.when("/backend/page/list", {
        controller: "PageController",
        templateUrl: "/app-portal/pages/page/list.html"
    });

    $routeProvider.when("/backend/page/details/:id", {
        controller: "PageController",
        templateUrl: "/app-portal/pages/page/details.html"
    });

    $routeProvider.when("/backend/page/create", {
        controller: "PageController",
        templateUrl: "/app-portal/pages/page/details.html"
    });

    $routeProvider.otherwise({ redirectTo: "/backend" });
});
