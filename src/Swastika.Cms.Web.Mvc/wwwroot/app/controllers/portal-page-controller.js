'use strict';

///////////////////////////////////////
//
//  PAGE CONTROLLER
//
///////////////////////////////////////
app.controller('PageController', function PhoneListController($filter, $scope) {
    $scope.activedPage = {};
    $scope.data = [];

    $scope.loadPages = function (pageIndex) {
        $rootScope.isBusy = true;
        if (pageIndex != undefined) {
            $scope.request.pageIndex = pageIndex;
        }
        if ($scope.request.fromDate != null) {
            $scope.request.fromDate = $filter('date')($scope.request.fromDate, "yyyy-MM-dd");
        }
        if ($scope.request.toDate != null) {
            $scope.request.toDate = $filter('date')($scope.request.toDate, "yyyy-MM-dd");
        }
        var url = '/api/' + $scope.currentLanguage + '/page/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = $scope.request;
        $.ajax($scope.settings).done(function (response) {
            $scope.data = response.data;

            $.each($scope.data.items, function (i, page) {
                $.each($scope.activedPages, function (i, e) {
                    if (e.pageId == page.id) {
                        page.isHidden = true;
                    }
                })
            })
            $rootScope.isBusy = false;
            $scope.$apply();
        });
    };

    $scope.removePage = function (pageId) {
        if (confirm("Are you sure!")) {
            var url = '/api/vi-vn/page/delete/' + pageId;
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    $scope.loadPages();
                },
                error: function (a, b, c) {
                    console.log(a + " " + b + " " + c);
                }
            });
        }
    };
    $scope.savePage = function (page) {
        var url = '/api/' + $scope.currentLanguage + '/page/save';
        $.ajax({
            method: 'POST',
            url: url,
            data: page,
            success: function (data) {
                //$scope.loadPage();
                if (data.isSucceed) {
                    alert('success');
                }
                else {
                    alert('failed! ' + data.errors);
                }
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    };
});