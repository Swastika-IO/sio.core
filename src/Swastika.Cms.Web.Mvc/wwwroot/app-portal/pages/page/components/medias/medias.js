
app.component('pageMedias', {
    templateUrl: '/app-portal/pages/page/components/medias/medias.html',
    controller: function () {
        var ctrl = this;
        ctrl.activeMedia = function (media) {
            var currentItem = null;
            if (ctrl.page.mediaNavs == null) {
                ctrl.page.mediaNavs = [];
            }
            $.each(ctrl.page.mediaNavs, function (i, e) {
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
                    page: ctrl.page.id,
                    specificulture: media.specificulture,
                    position: 0,
                    priority: ctrl.page.mediaNavs.length + 1,
                    isActived: true
                };
                media.isHidden = true;
                ctrl.page.mediaNavs.push(currentItem);
            }
        }
    },
    bindings: {
        page: '=',
        medias: '=',
        loadMedia: '&',
        onDelete: '&',
        onUpdate: '&'
    }
});