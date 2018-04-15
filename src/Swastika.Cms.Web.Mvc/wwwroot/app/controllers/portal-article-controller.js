/// <reference path="portal-page-controller.js" />
'use strict';
app.controller('ArticleController', function PhoneListController($scope) {
    $scope.activedArticle = {};
    $scope.data = [];

    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    $scope.loadArticles = function (articleIndex) {
        $scope.isBusy = true;
        if (articleIndex != undefined) {
            $scope.request.articleIndex = articleIndex;
        }
        if ($scope.request.fromDate != null) {
            $scope.request.fromDate = $scope.request.fromDate.toISOString();
        }
        if ($scope.request.toDate != null) {
            $scope.request.toDate = $scope.request.toDate.toISOString();
        }
        var url = '/api/' + $scope.currentLanguage + '/article/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = $scope.request;
        $.ajax($scope.settings).done(function (response) {
            $scope.$apply($scope.data = response.data);

            $.each($scope.data.items, function (i, article) {
                $.each($scope.activedArticles, function (i, e) {
                    if (e.articleId == article.id) {
                        article.isHidden = true;
                    }
                })
            })
            $scope.isBusy = false;
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
        });
    };

    $scope.removeArticle = function (articleId) {
        if (confirm("Are you sure!")) {
            var url = '/api/' + $scope.currentLanguage + '/article/delete/' + articleId;
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    $scope.loadArticle();
                    $scope.$apply();
                },
                error: function (a, b, c) {
                    console.log(a + " " + b + " " + c);
                }
            });
        }
    };
    $scope.saveArticle = function (article) {
        var url = '/api/' + $scope.currentLanguage + '/article/save';
        $.ajax({
            method: 'POST',
            url: url,
            data: article,
            success: function (data) {
                //$scope.loadArticle();
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
