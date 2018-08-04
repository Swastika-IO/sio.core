'use strict';
app.controller('ArticleController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'ArticleServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, articleServices) {
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

        $scope.activedArticle = null;
        $scope.relatedArticles = [];
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
        };
        
        $scope.loadArticle = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await articleServices.getArticle(id, 'be');
            if (response.isSucceed) {
                $scope.activedArticle = response.data;
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
        $scope.loadArticles = async function (pageIndex) {
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
            var resp = await articleServices.getArticles($scope.request);
            if (resp && resp.isSucceed) {

                ($scope.data = resp.data);
                //$("html, body").animate({ "scrollTop": "0px" }, 500);
                $.each($scope.data.items, function (i, article) {

                    $.each($scope.activedArticles, function (i, e) {
                        if (e.articleId == article.id) {
                            article.isHidden = true;
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
                $scope.$apply();
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

        $scope.removeArticle = function (id) {
            $rootScope.showConfirm($scope, 'removeArticleConfirmed', [id], null, 'Remove Article', 'Are you sure');
        }

        $scope.removeArticleConfirmed = async function (id) {
            var result = await articleServices.removeArticle(id);
            if (result.isSucceed) {
                $scope.loadArticles();
            }
            else {
                $rootScope.showMessage('failed');
                $scope.$apply();
            }
        }


        $scope.saveArticle = async function (article) {
            article.content = $('.editor-content').val();
            var resp = await articleServices.saveArticle(article);
            if (resp && resp.isSucceed) {
                $scope.activedArticle = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
                //$location.path('/backend/article/details/' + resp.data.id);
            }
            else {
                if (resp) { $rootScope.showErrors(resp.errors); }
                $scope.$apply();
            }
        };

    }]);
