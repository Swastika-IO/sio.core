
modules.component('navs', {
    templateUrl: '/app-portal/pages/shared/components/navigations/navigations.html',
    bindings: {
        prefix: '=',
        data: '=',
        callback: '&'
    }
});