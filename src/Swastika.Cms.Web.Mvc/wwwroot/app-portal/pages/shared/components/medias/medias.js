
modules.component('medias', {
    templateUrl: '/app-portal/pages/shared/components/medias/medias.html',
    controller: ['$rootScope', '$scope', function ($rootScope, $scope) {
        $scope.medias = [];
        this.loadMedias = function () {
            $scope.medias = awa
        }
    }],
    bindings: {
        
    }
});