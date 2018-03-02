'use strict';
app.controller('PortalController', function PhoneListController($scope) {
    $scope.mediaData = {};
    $scope.mediaFile = {
        file: null,
        fullPath: '',
        folder: 'Media',
        title: '',
        description: ''
    };
    $scope.templates = [];
    $scope.medias = [];
    $scope.productData = {};
    $scope.activedTemplate = {};
    $scope.activedMedias = [];
    $scope.activedProducts = [];
    $scope.request = {
        "pageSize": 16,
        "pageIndex": 0,
        "orderBy": 'CreatedDateTime',
        "direction": 1,
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

    $scope.loadMedia = function (pageIndex = 0, pageSize = 16, orderBy = 'CreatedDateTime', direction = 1) {
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
    $scope.uploadMedia = function () {
        //var container = $(this).parents('.model-media').first().find('.custom-file').first();        
        if ($scope.mediaFile.file !== undefined && $scope.mediaFile.file !== null) {            
            // Create FormData object
            var files = new FormData();

            // Looping over all files and add it to FormData object
            files.append($scope.mediaFile.file.name, $scope.mediaFile.file);

            // Adding one more key to FormData object
            files.append('fileFolder', $scope.mediaFile.folder);
            files.append('title', $scope.mediaFile.title);
            files.append('description', $scope.mediaFile.description);
            $.ajax({
                url: '/api/vi-vn/media/upload', //'/api/tts/UploadImage',
                type: "POST",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                data: files,
                success: function (result) {
                    if (result.isSucceed) {

                        $scope.mediaFile.fullPath = result.data.fullPath;                        
                        $scope.mediaFile.file = null;
                        $scope.loadMedia();
                        $('.upload-image-modal-lg').modal('hide');
                        return result;

                    }
                },
                error: function (err) {
                    return '';
                }
            });
        }
    };

    $scope.removeMedia = function (mediaId) {
        if (confirm("Are you sure!")) {
            var url = '/api/vi-vn/media/delete/' + mediaId;
            $.ajax({
                method: 'GET',
                url: url,
                success: function (data) {
                    $scope.loadMedia();
                },
                error: function (a, b, c) {
                    console.log(a + " " + b + " " + c);
                }
            });
        }

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
        if ($scope.activedMedias == undefined) {
            $scope.activedMedias = [];
        }
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
        var i = $(".property").length;
        $.ajax({
            method: 'GET',
            url: '/vi-vn/Portal/' + type + '/AddEmptyProperty/' + i,
            success: function (data) {
                $('#tbl-properties > tbody').append(data);
                $(data).find('.prop-data-type').trigger('change');
            },
            error: function (a, b, c) {
                console.log(a + " " + b + " " + c);
            }
        });
    }

    $scope.loadTemplates = function (activedId, folder) {
        var request = {
            "pageSize": null,
            "pageIndex": 0,
            "orderBy": 'fileName',
            "direction": 0,
            "keyword": folder
        }
        var url = '/api/vi-vn/template/list';//byProduct/' + productId;
        $scope.settings.url = url;// + '/true';
        $scope.settings.data = request;
        $.ajax($scope.settings).done(function (response) {
            $scope.templates = response.data.items;
            if ($scope.templates.length > 0) {
                var newTemplate = angular.copy($scope.templates[0]);
                newTemplate.id = 0;
                newTemplate.fileName = 'NewTemplate';
                newTemplate.content = "<div></div>";
                $scope.templates.splice(0, 0, newTemplate);
            }
            $.each($scope.templates, function (i, e) {
                if (e.id == activedId) {
                    $scope.activedTemplate = e;
                    $scope.updateEditors();
                    return false;
                }
            });
            $scope.$apply();
        });
    }
    $scope.updateEditors = function () {
        setTimeout(function () {
            $.each($('.code-editor'), function (i, e) {
                var container = $(this);
                var editor = ace.edit(e);
                var val = $(this).next('input').val();
                editor.setValue(val);
                if (container.hasClass('json')) {
                    editor.session.setMode("ace/mode/json");
                }
                else {
                    editor.session.setMode("ace/mode/razor");
                }
                editor.setTheme("ace/theme/chrome");
                //editor.setReadOnly(true);

                editor.session.setUseWrapMode(true);
                editor.setOptions({
                    maxLines: Infinity
                });
                editor.getSession().on('change', function (e) {
                    // e.type, etc
                    $(container).parent().find('.code-content').val(editor.getValue());
                });
            });
        }, 200);
    };
    $(document).ready(function () {
        //$scope.loadMedia();
        //$scope.loadProduct();
    });
});
