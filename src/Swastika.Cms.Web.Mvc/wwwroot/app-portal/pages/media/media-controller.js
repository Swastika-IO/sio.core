'use strict';
app.controller('MediaController', ['$scope', '$rootScope', '$routeParams', '$timeout', '$location', 'authService', 'MediaServices',
    function ($scope, $rootScope, $routeParams, $timeout, $location, authService, mediaServices) {
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
        $scope.mediaFile = {
            file: null,
            fullPath: '',
            folder: 'Media',
            title: '',
            description: ''
        };
        $scope.activedMedia = null;
        $scope.relatedMedias = [];
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

        $scope.getMedia = async function (id) {
            $rootScope.isBusy = true;
            var resp = await mediaServices.getMedia(id, 'be');
            if (resp.isSucceed) {
                $scope.activedMedia = resp.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };
        $scope.loadMedia = async function () {
            $rootScope.isBusy = true;
            var id = $routeParams.id;
            var response = await mediaServices.getMedia(id, 'be');
            if (response.isSucceed) {
                $scope.activedMedia = response.data;
                $rootScope.initEditor();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(response.errors);
                $scope.$apply();
            }
        };


        $scope.uploadMedia = async function () {
            var resp = await mediaServices.uploadMedia($scope.mediaFile);
            if (resp.isSucceed) {
                $scope.activedMedia = resp.data;
                $scope.loadMedias();
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };


        $scope.loadMedias = async function (pageIndex) {
            if (pageIndex != undefined) {
                $scope.request.pageIndex = pageIndex;
            }
            
            var resp = await mediaServices.getMedias($scope.request);
            if (resp.isSucceed) {

                ($scope.data = resp.data);
                $.each($scope.data.items, function (i, media) {

                    $.each($scope.activedMedias, function (i, e) {
                        if (e.mediaId == media.id) {
                            media.isHidden = true;
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
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

        $scope.removeMedia = async function (id) {
            if (confirm("Are you sure!")) {
                var resp = await mediaServices.removeMedia(id);
                if (resp.isSucceed) {
                    $scope.loadMedias();
                }
                else {
                    $rootScope.showErrors(resp.errors);
                }
            }
        };

        $scope.saveMedia = async function (media) {
            media.content = $('.editor-content').val();
            var resp = await mediaServices.saveMedia(media);
            if (resp.isSucceed) {
                $scope.activedMedia = resp.data;
                $rootScope.showMessage('Thành công', 'success');
                $rootScope.isBusy = false;
                $scope.$apply();
            }
            else {
                $rootScope.showErrors(resp.errors);
                $scope.$apply();
            }
        };

    }]);
