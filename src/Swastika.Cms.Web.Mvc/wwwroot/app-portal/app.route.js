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

    $routeProvider.when("/backend/module/list", {
        controller: "ModuleController",
        templateUrl: "/app-portal/pages/module/list.html"
    });

    $routeProvider.when("/backend/module/data/:id", {
        controller: "ModuleController",
        templateUrl: "/app-portal/pages/module/data.html"
    });

    $routeProvider.when("/backend/module-data/details/:moduleId/:id", {
        controller: "ModuleDataController",
        templateUrl: "/app-portal/pages/moduleData/details.html"
    });

    $routeProvider.when("/backend/module-data/details/:moduleId", {
        controller: "ModuleDataController",
        templateUrl: "/app-portal/pages/moduleData/details.html"
    });

    $routeProvider.when("/backend/module/details/:id", {
        controller: "ModuleController",
        templateUrl: "/app-portal/pages/module/details.html"
    });

    $routeProvider.when("/backend/module/create", {
        controller: "ModuleController",
        templateUrl: "/app-portal/pages/module/details.html"
    });

    
    $routeProvider.when("/backend/media/list", {
        controller: "MediaController",
        templateUrl: "/app-portal/pages/media/list.html"
    });

    $routeProvider.when("/backend/media/details/:id", {
        controller: "MediaController",
        templateUrl: "/app-portal/pages/media/details.html"
    });

    $routeProvider.when("/backend/media/create", {
        controller: "MediaController",
        templateUrl: "/app-portal/pages/media/details.html"
    });

    $routeProvider.when("/backend/theme/list", {
        controller: "ThemeController",
        templateUrl: "/app-portal/pages/theme/list.html"
    });

    $routeProvider.when("/backend/theme/details/:id", {
        controller: "ThemeController",
        templateUrl: "/app-portal/pages/theme/details.html"
    });

    $routeProvider.when("/backend/theme/create", {
        controller: "ThemeController",
        templateUrl: "/app-portal/pages/theme/details.html"
    });

    $routeProvider.otherwise({ redirectTo: "/backend" });
});
