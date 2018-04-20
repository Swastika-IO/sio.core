
app.component('pageModules', {
    templateUrl: '/app/portal/components/page/modules/pageModules.html',
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});