app.component('moduleMedias', {
    templateUrl: '/app/portal/components/module/medias/moduleMedias.html',
    controller: function () {
        var ctrl = this;
        ctrl.activeMedia = function (media) {
            var currentItem = null;
            if (ctrl.module.mediaNavs == null) {
                ctrl.module.mediaNavs = [];
            }
            $.each(ctrl.module.mediaNavs, function (i, e) {
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
                    module: ctrl.module.id,
                    specificulture: media.specificulture,
                    position: 0,
                    priority: ctrl.module.mediaNavs.length + 1,
                    isActived: true
                };
                media.isHidden = true;
                ctrl.module.mediaNavs.push(currentItem);
            }
        }
    },
    bindings: {
        module: '=',
        medias: '=',
        loadMedia: '&',
        onDelete: '&',
        onUpdate: '&'
    }
});