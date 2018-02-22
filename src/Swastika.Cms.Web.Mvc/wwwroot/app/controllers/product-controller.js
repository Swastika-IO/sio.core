'use strict';
app.controller('ProductController', function PhoneListController($scope) {
    $scope.mediaData = {};
    $scope.activedMedias = {};
    $scope.request = {
        "pageSize": 12,
        "pageIndex": 0,
        "orderBy": 'id',
        "direction": 0,
        "keyword": ''
    };
    $scope.settings = {
        "async": true,
        "crossDomain": true,
        "url": "",
        "method": "POST",
        "headers": {
            "Content-Type": "application/x-www-form-urlencoded"
        },
        "data": $scope.request
    };

    $scope.range = function (max) {
        var input = [];
        for (var i = 1; i <= max; i += 1) input.push(i);
        return input;
    };

    $scope.loadMedia = function (pageIndex = 0, pageSize = 12, orderBy = 'fileName', direction = 0) {
        $scope.request = {
            "pageSize": pageSize,
            "pageIndex": pageIndex,
            "orderBy": orderBy,
            "direction": direction,
            "keyword": $('#keyword').val()
        }
        var url = '/api/vi-vn/media/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = $scope.request;
        $.ajax($scope.settings).done(function (response) {
           
            $scope.$apply($scope.mediaData = response.data);

            $.each($scope.mediaData.items, function (i, media) {
                $.each($scope.activedMedias, function (i, e) {
                    if (e.mediaId == media.id) {
                        media.isHidden = true;
                    }

                })

            })
        });

       
    };

    $scope.changeMedia = function (media) {
        var currentItem = null;
        $.each($scope.activedMedias, function (i, e) {
            if (e.mediaId == media.id) {
                e.isActived = media.isActived;
                currentItem = e;
                return false;
            }
           
        });
        if (currentItem == null) {
            currentItem = {
                description: media.description,
                image: media.fullPath,
                mediaId: media.id,
                product: $('#product-id').val(),
                specificulture: media.specificulture,
                position: 0,
                isActived: true
            };
            media.isHidden = true;
            $scope.activedMedias.push(currentItem);
        }

    }

    $(document).ready(function () {
        if ($('#arr-medias').val() != '') {
            $scope.activedMedias = $.parseJSON($('#arr-medias').val());
        }
        else {
            $scope.activedMedias = [];
        }
        $scope.loadMedia();
    });
});