
app.component('productMain', {
    templateUrl: '/app-portal/pages/product/components/main/productMain.html',
    controller: ['$rootScope', '$scope',
        function ($rootScope, $scope) {
            var ctrl = this;
            ctrl.generateSEO = function () {
                if (!ctrl.product.id) {
                    ctrl.product.seoName = $rootScope.generateKeyword(ctrl.product.title, '-');
                }
                if (!ctrl.product.id) {
                    ctrl.product.urlAlias.alias = $rootScope.generateKeyword(ctrl.product.title, '-');
                }
                $scope.$apply();
            };
        }
    ],
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});