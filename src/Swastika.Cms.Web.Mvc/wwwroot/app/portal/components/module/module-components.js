(function (angular) {
    'use strict';
    function ModuleDetailsController($scope, $element, $attrs) {
        var ctrl = this;
        ctrl.activedModule = null;
        ctrl.relatedModules = [];
        ctrl.data = [];
        ctrl.errors = [];
        ctrl.range = function (max) {
            var input = [];
            for (var i = 1; i <= max; i += 1) input.push(i);
            return input;
        };
        ctrl.loadModule = function (moduleId) {
            ctrl.isBusy = true;
            var url = '/api/' + ctrl.currentLanguage + '/module/details/be/' + moduleId;//byModule/' + moduleId;
            ctrl.settings.method = "GET";
            ctrl.settings.url = url;// + '/true';
            ctrl.settings.data = ctrl.request;
            $.ajax(ctrl.settings).done(function (response) {
                if (response.isSucceed) {
                    ctrl.activedModule = response.data;
                    ctrl.initEditor();
                }
                ctrl.isBusy = false;
                ctrl.$apply();
            });
        };
        ctrl.loadModules = function (pageIndex) {
            ctrl.isBusy = true;
            if (pageIndex != undefined) {
                ctrl.request.pageIndex = pageIndex;
            }
            if (ctrl.request.fromDate != null) {
                ctrl.request.fromDate = ctrl.request.fromDate.toISOString();
            }
            if (ctrl.request.toDate != null) {
                ctrl.request.toDate = ctrl.request.toDate.toISOString();
            }
            var url = '/api/' + ctrl.currentLanguage + '/module/list';//byModule/' + moduleId;
            ctrl.settings.method = "POST";
            ctrl.settings.url = url;// + '/true';
            ctrl.settings.data = ctrl.request;
            $.ajax(ctrl.settings).done(function (response) {
                (ctrl.data = response.data);

                $.each(ctrl.data.items, function (i, module) {
                    $.each(ctrl.activedModules, function (i, e) {
                        if (e.moduleId == module.id) {
                            module.isHidden = true;
                        }
                    })
                })
                ctrl.isBusy = false;
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
                ctrl.$apply();
            });
        };

        ctrl.removeModule = function (moduleId) {
            if (confirm("Are you sure!")) {
                var url = '/api/' + ctrl.currentLanguage + '/module/delete/' + moduleId;
                $.ajax({
                    method: 'GET',
                    url: url,
                    success: function (data) {
                        ctrl.loadModules();
                        ctrl.$apply();
                    },
                    error: function (a, b, c) {
                        console.log(a + " " + b + " " + c);
                    }
                });
            }
        };
        ctrl.saveModule = function (module) {
            var url = '/api/' + ctrl.currentLanguage + '/module/save';
            $.ajax({
                method: 'POST',
                url: url,
                data: module,
                success: function (data) {
                    //ctrl.loadModules();
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

        ctrl.changeMedia = function (media) {
            var currentItem = null;
            if (ctrl.activedModule.mediaNavs == undefined) {
                ctrl.activedModule.mediaNavs = [];
            }
            $.each(ctrl.activedModule.mediaNavs, function (i, e) {
                if (e.mediaId == media.id) {
                    e.isActived = media.isActived;
                    currentItem = e;
                    return false;
                }
            });
            if (currentItem == null) {
                currentItem = {
                    description: media.description != 'undefined' ? media.description : '',
                    image: media.fullPath,
                    mediaId: media.id,
                    module: ctrl.activedModule.id,
                    specificulture: media.specificulture,
                    position: 0,
                    priority: ctrl.activedMedias.length + 1,
                    isActived: true
                };
                media.isHidden = true;
                ctrl.activedModule.mediaNavs.push(currentItem);
            }
        }

        ctrl.changeModule = function (module) {
            var currentItem = null;
            $.each(ctrl.activedModule.moduleNavs, function (i, e) {
                if (e.relatedModuleId == module.id) {
                    e.isActived = module.isActived;
                    currentItem = e;
                    return false;
                }
            });
            if (currentItem == null) {
                currentItem = {
                    relatedModuleId: module.id,
                    sourceModuleId: $('#module-id').val(),
                    specificulture: module.specificulture,
                    priority: ctrl.activedModule.moduleNavs.length + 1,
                    module: module,
                    isActived: true
                };
                module.isHidden = true;
                ctrl.activedModule.moduleNavs.push(currentItem);
            }
        }

        ctrl.addProperty = function (type) {
            var i = $(".property").length;
            $.ajax({
                method: 'GET',
                url: '/' + ctrl.currentLanguage + '/Portal/' + type + '/AddEmptyProperty/' + i,
                success: function (data) {
                    $('#tbl-properties > tbody').append(data);
                    $(data).find('.prop-data-type').trigger('change');
                },
                error: function (a, b, c) {
                    console.log(a + " " + b + " " + c);
                }
            });
            ctrl.updateHero = function (hero, prop, value) {
                hero[prop] = value;
            };

            ctrl.deleteHero = function (hero) {
                var idx = ctrl.list.indexOf(hero);
                if (idx >= 0) {
                    ctrl.list.splice(idx, 1);
                }
            };
        }

        angular.module(appName).component('moduleDetails', {
            templateUrl: 'moduleDetails.html',
            controller: ModuleDetailsController
        });
    }
})(window.angular)