'use strict';
app.controller('ProductController', ['$scope', '$rootScope','$routeParams', '$timeout', '$location', 'authService', 'ProductServices',
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
        $scope.data = [];
        $scope.errors = [];
        $scope.message = {
            class: 'info',
            content: ''
        };
        $scope.lang = $('#lang').val();
        $scope.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };

        $scope.getArticle = function (id) {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                articleServices.getArticle(id, 'be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedArticle = response.data;
                        $rootScope.initEditor();
                    }
                    $rootScope.isBusy = false;
                    $scope.$apply();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $rootScope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    $scope.$apply();
                });
            }
        };

        $scope.initArticle = function () {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                articleServices.initArticle('be').then(function (response) {
                    if (response.isSucceed) {
                        $scope.activedArticle = response.data;
                        $rootScope.initEditor();
                    }
                    $rootScope.isBusy = false;
                    $scope.$apply();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $rootScope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);                    
                });
            }
        };

        $scope.loadArticle = function () {
            if (!$rootScope.isBusy) {
                $rootScope.isBusy = true;
                var id = $routeParams.id;

                articleServices.getArticle(id,'be').then(function (response) {
                    if (response.data.isSucceed) {
                        $scope.activedArticle = response.data.data;
                        $rootScope.initEditor();
                    }
                    else {
                        alert('failed! ' + data.errors);
                    }

                }, function (a, b, c) {
                    errors.push(a, b, c);
                    $rootScope.isBusy = false;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                    
                });
            }
        };
        $scope.loadArticles = async function (pageIndex) {
            if (!$rootScope.isBusy) {
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
                if (resp.isSucceed) {

                    ($scope.data = resp.data);
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
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
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                }
                else {
                    $scope.errors = resp.errors;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                }
                //articleServices.getArticles($scope.request).then(function (result) {
                //    var resp = result.data;
                //    if (resp.isSucceed) {

                //        ($scope.data = resp.data);
                //        $("html, body").animate({ "scrollTop": "0px" }, 500);
                //        $.each($scope.data.items, function (i, article) {

                //            $.each($scope.activedArticles, function (i, e) {
                //                if (e.articleId == article.id) {
                //                    article.isHidden = true;
                //                }
                //            })
                //        })
                //        $rootScope.isBusy = false;
                //        setTimeout(function () {
                //            $('[data-toggle="popover"]').popover({
                //                html: true,
                //                content: function () {
                //                    var content = $(this).next('.popover-body');
                //                    return $(content).html();
                //                },
                //                title: function () {
                //                    var title = $(this).attr("data-popover-content");
                //                    return $(title).children(".popover-heading").html();
                //                }
                //            });
                //        }, 200);
                //    }
                //    else {
                //        alert('failed! ' + data.errors);
                //    }
                //}, function (a, b, c) {
                //    errors.push(a, b, c);
                //    $rootScope.isBusy = false;
                //    $("html, body").animate({ "scrollTop": "0px" }, 500);
                //    $scope.$apply();
                //});
            }
        };

        $scope.removeArticle = function (id) {
            if (confirm("Are you sure!")) {
                articleServices.removeArticle(id).then(function (response) {
                    $scope.loadArticles();
                }).error(function (a, b, c) {
                    errors.push(a, b, c);
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                });;
            }
        };
        $scope.saveArticle = async function (article) {
            if (!isBusy) {

                article.content = $('.editor-content').val();
                var resp = await articleServices.saveArticle(article);
                if (resp.isSucceed) {
                    $scope.activedArticle = resp.data;
                    $scope.message.content = 'Thành công';
                    $scope.message.class = 'success';
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                }
                else {
                    $scope.errors = resp.errors;
                    $("html, body").animate({ "scrollTop": "0px" }, 500);
                }
              

                //articleServices.saveArticle(article).then(function (response) {
                //    if (data.isSucceed) {
                //        $scope.activedArticle = data.data;
                //        $scope.message.content = 'Thành công';
                //        $scope.message.class = 'success';
                //    }
                //    else {
                //        $scope.errors = data.errors;
                //    }
                //    $("html, body").animate({ "scrollTop": "0px" }, 500);
                //    $rootScope.isBusy = false;
                //}).error(function (a, b, c) {
                //    errors.push(a, b, c);
                //    $rootScope.isBusy = false;
                //    $("html, body").animate({ "scrollTop": "0px" }, 500);
                //});
            }
        };

        $scope.$watch('isBusy', function (newValue, oldValue) {
            if (newValue) {
                $scope.message.content = '';
                $scope.errors = [];
            }
        });
    }]);
