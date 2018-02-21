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
    $scope.loadMedia = function (keyword = '', pageSize = 12, pageIndex = 0, orderBy = 'fileName', direction = 0) {
        $scope.request = {
            "pageSize": pageSize,
            "pageIndex": pageIndex,
            "orderBy": orderBy,
            "direction": direction,
            "keyword": keyword
        }
        var url = '/api/vi-vn/media/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $.ajax($scope.settings).done(function (response) {
           
            $scope.$apply($scope.mediaData = response.data);

            $.each($scope.mediaData.items, function (i, media) {
                $.each($scope.activedMedias.items, function (i, e) {
                    if (e.mediaId == media.id) {
                        media.isHidden = true;
                        return false;
                    }

                })

            })
        });

       
    };

    $scope.changeMedia = function (media) {
        console.log(media);
        var currentItem = null;
        $.each($scope.activedMedias.items, function (i, e) {
            if (e.mediaId == media.id) {
                e.isActived = media.isActived;
                currentItem = e;
                return false;
            }
            
        })
        if (currentItem == null) {
            currentItem = {
                title: media.fileName,
                image: media.fullPath,
                mediaId: media.id,
                product: $('#product-id').val(),
                specificulture: media.specificulture,
                isActived: media.isActived
            };
            media.isHidden = true;
            $scope.activedMedias.items.push(currentItem);
        }
       
    }

    $(document).ready(function () {
        $scope.loadMedia();
        $scope.settings.url = '/api/vi-vn/media/list/byProduct/' + $('#product-id').val();
        $.ajax($scope.settings).done(function (response) {
            $scope.$apply($scope.activedMedias = response.data);
        });
    });
});