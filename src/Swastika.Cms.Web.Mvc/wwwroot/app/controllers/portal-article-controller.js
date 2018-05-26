'use strict';

///////////////////////////////////////
//
//  PRODUCT CONTROLLER
//
///////////////////////////////////////
app.controller('ArticleController', function ArticleController($scope) {
    // Actived article
    $scope.activedArticle = null;

    // Related articles array
    $scope.relatedArticles = [];

    // Data array
    $scope.data = [];

    // Error array
    $scope.errors = [];

    // Message object
    $scope.message = {
        class: 'info',
        content: ''
    }

    // Range ???
    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    // Load article from API
    $scope.loadArticle = function (articleId, isNew) {
        $scope.isBusy = true;
        var url = '';

        if (isNew) {
            // If create article then call create API
            url = '/api/' + $scope.currentLanguage + '/article/create';
        }
        else {
            // Else create article then call get API
            url = '/api/' + $scope.currentLanguage + '/article/details/be/' + articleId;//byArticle/' + articleId;
        }

        // Ajax setting
        $scope.settings.method = "GET";
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = JSON.stringify($scope.request);

        // Ajax call
        $.ajax($scope.settings).done(function (response) {
            // Done

            if (response.isSucceed) {
                // If reponse is succeed
                $scope.activedArticle = response.data;
                $scope.initEditor();
            }

            $scope.isBusy = false;
            $scope.$apply();
        });
    };

    // Load list of article from API
    $scope.loadArticles = function (pageIndex) {
        if (pageIndex != undefined) {
            $scope.request.pageIndex = pageIndex;
        }
        if ($scope.request.fromDate != null) {
            $scope.request.fromDate = $filter('date')($scope.request.fromDate, "yyyy-MM-dd");
        }
        if ($scope.request.toDate != null) {
            $scope.request.toDate = $filter('date')($scope.request.toDate, "yyyy-MM-dd");
        }
        var url = '/api/' + $scope.currentLanguage + '/article/list';//byArticle/' + articleId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = JSON.stringify($scope.request);
        $scope.isBusy = true;
        $.ajax($scope.settings).done(function (response) {

            if (response.isSucceed) {
                // If ajax call is succeed
                ($scope.data = response.data);
                $("html, body").animate({ "scrollTop": "0px" }, 500);

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
            }
            else {
                alert('failed! ' + data.errors);
            }
        });
    };

    // Remove article
    $scope.removeArticle = function (articleId) {
        if (confirm("Are you sure that you want to delete this article!?")) {

            // Set ajax call URL to remove article with article ID
            var url = '/api/' + $scope.currentLanguage + '/article/delete/' + articleId;

            // Ajax call
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    // Ajax request is succeed then load article list again
                    $scope.loadArticles();
                    $scope.$apply();
                },
                error: function (a, b, c) {
                    // Write error content to console
                    console.log(a + " " + b + " " + c);
                }
            });
        }
    };

    // Save article
    $scope.saveArticle = function (article) {
        $scope.isBusy = true;
        article.content = $('.editor-content.content').val();
        article.excerpt = $('.editor-content.excerpt').val();
        var json = (angular.toJson(article));

        // Set ajax call URL to save article API
        var url = '/api/' + $scope.currentLanguage + '/article/save';

        // Ajax call
        $.ajax({
            method: 'POST',
            contentType: "application/json; charset=utf-8",
            url: url,
            data: json,
            success: function (data) {
                //$scope.loadArticles();
                if (data.isSucceed) {
                    // Ajax request is succeed
                    $scope.activedArticle = data.data;
                    $scope.message.content = 'Success';
                    $scope.message.class = 'success';
                }
                else {
                    // Display error
                    $scope.errors = data.errors;
                }

                $("html, body").animate({ "scrollTop": "0px" }, 500);
                $scope.isBusy = false;
                $scope.$apply();
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
                $scope.isBusy = false;
                $scope.$apply();
            }
        });
    };

    // Add article's property
    $scope.addProperty = function (type) {
        var i = $(".property").length;

        $.ajax({
            method: 'GET',
            url: '/' + $scope.currentLanguage + '/Portal/' + type + '/AddEmptyProperty/' + i,
            success: function (data) {
                $('#tbl-properties > tbody').append(data);
                $(data).find('.prop-data-type').trigger('change');
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    }

    $scope.$watch('isBusy', function (newValue, oldValue) {
        if (newValue) {
            $scope.message.content = '';
            $scope.errors = [];
        }
    });
});