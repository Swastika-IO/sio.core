'use strict';
app.controller('PortalController', function PhoneListController($scope) {
    $scope.mediaData = {};
    $scope.productData = {};
    $scope.activedMedias = {};
    $scope.activedProducts = [];
    $scope.request = {
        "pageSize": 16,
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

    $scope.loadMedia = function (pageIndex = 0, pageSize = 16, orderBy = 'fileName', direction = 0) {
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

    $scope.loadProduct = function (pageIndex = 0, pageSize = 16, orderBy = 'title', direction = 0) {
        var request = {
            "pageSize": pageSize,
            "pageIndex": pageIndex,
            "orderBy": orderBy,
            "direction": direction,
            "keyword": $('#keyword').val()
        }
        var url = '/api/vi-vn/product/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = request;
        $.ajax($scope.settings).done(function (response) {
            $scope.productData = response.data;
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
                priority: $scope.activedMedias.length + 1,
                isActived: true
            };
            media.isHidden = true;
            $scope.activedMedias.push(currentItem);
        }
    }

    $scope.changeProduct = function (product) {
        var currentItem = null;
        $.each($scope.activedProducts, function (i, e) {
            if (e.relatedProductId == product.id) {
                e.isActived = product.isActived;
                currentItem = e;
                return false;
            }
        });
        if (currentItem == null) {
            currentItem = {
                relatedProductId: product.id,
                sourceProductId: $('#product-id').val(),
                specificulture: product.specificulture,
                priority: $scope.activedMedias.length + 1,
                product: product,
                isActived: true
            };
            product.isHidden = true;
            $scope.activedProducts.push(currentItem);
        }
    }
    $scope.addProperty = function (type) {
        var i = $(".product-property").length;
        $.ajax({
            method: 'GET',
            url: '/vi-vn/Portal/'+ type + '/AddEmptyProperty/' + i,
            success: function (data) {
                $('#tbl-properties > tbody').append(data);
                $(data).find('.prop-data-type').trigger('change');
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    }
    $(document).ready(function () {
        if ($('#arr-medias').length > 0 && $('#arr-medias').val() != '') {
            $scope.activedMedias = $.parseJSON($('#arr-medias').val());
        }
        else {
            $scope.activedMedias = [];
        }

        if ($('#arr-products').length > 0 && $('#arr-products').val() != '') {
            $scope.activedProducts = $.parseJSON($('#arr-products').val());
        }
        else {
            $scope.activedProducts = [];
        }
        $scope.loadMedia();
        $scope.loadProduct();
    });
});
