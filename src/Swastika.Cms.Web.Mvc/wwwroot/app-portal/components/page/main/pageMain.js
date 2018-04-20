
app.component('pageMain', {
    templateUrl: '/app/portal/components/page/main/pageMain.html',
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});