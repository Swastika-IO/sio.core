'use strict';
app.controller('ProductController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ProductServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, productServices) {
        $scope.request = {
            pageSize: '10',
            pageIndex: 0,
            status: $rootScope.swStatus[1],
            orderBy: 'CreatedDateTime',
            direction: '1',
            fromDate: null,
            toDate: null,
            keyword: ''
        };

        $scope.activedProduct = null;
        $scope.relatedProducts = [];
        $rootScope.isBusy = false;
        $scope.data = {
            pageIndex: 0,
            pageSize: 1,
            totalItems: 0,
        };
        $scope.errors = [];
        
        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        }

        $scope.loadProduct = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await productServices.getProduct(id, 'be');
            if (response.isSucceed) {
                $scope.activedProduct = response.data;
                $rootScope.initEditor();
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        };
        $scope.loadProducts = async function (pageIndex) {
            if (pageIndex != undefined) {
                $scope.request.pageIndex = pageIndex;
            }
            if ($scope.request.fromDate != null) {
                var d = new Date($scope.request.fromDate);
                $scope.request.fromDate = d.toISOString();
            }
            if ($scope.request.toDate != null) {
                $scope.request.toDate = $scope.request.toDate.toISOString();
            }
            var resp = await productServices.getProducts($scope.request);
            if (resp && resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, product) {

                    $.each($scope.activedProducts, function (i, e) {
                        if (e.productId == product.id) {
                            product.isHidden = true;
                        }
                    })
                })
                setTimeout(function () {
                    $('[data-toggle="popover"]').popover({
                        html: true,
                        content: function () {
                            var content = $(this).next('.popover-body');
                            return $(content).html();
                        },
                        title: function () {
                            var title = $(this).attr("data-popover-content");
                            return $(title).children(".popover-heading").html();
                        }
                    });
                }, 200);
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        };

        $scope.removeProduct = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await productServices.removeProduct(id);
                if (resp && resp.isSucceed) {
                    $scope.loadProducts();
                }
                else {
                    if (resp) { $rootScope.showErrors(resp.errors); }
                }
            }
        };

        $scope.saveProduct = async function (product) {
            product.content = $('.editor-content.content').val();
            product.excerpt = $('.editor-content.excerpt').val();
            var resp = await productServices.saveProduct(product);
            if (resp && resp.isSucceed) {
                $scope.activedProduct = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
                //$location.path('/backend/product/details/' + resp.data.id);
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $rootScope.isBusy = false;
                $scope.$apply();
            }
        };

    }]);
