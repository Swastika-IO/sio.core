
app.component('pageMain', {
    templateUrl: '/app-portal/pages/page/components/main/main.html',
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});