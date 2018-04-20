app.component('moduleRelated', {
    templateUrl: '/app/portal/components/module/related/moduleRelated.html',
    controller: function () {
        var ctrl = this;
        ctrl.activeModule = function (pr) {
            var currentItem = null;
            $.each(ctrl.module.moduleNavs, function (i, e) {
                if (e.relatedModuleId == pr.id) {
                    e.isActived = pr.isActived;
                    currentItem = e;
                    return false;
                }
            });
            if (currentItem == null) {
                currentItem = {
                    relatedModuleId: pr.id,
                    sourceModuleId: ctrl.module.id,
                    specificulture: ctrl.module.specificulture,
                    priority: ctrl.module.moduleNavs.length + 1,
                    relatedModule: pr,
                    isActived: true
                };
                pr.isHidden = true;
                ctrl.module.moduleNavs.push(currentItem);
            }
        }
    },
    bindings: {
        module: '=',
        list: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});