
app.component('pageChildren', {
    templateUrl: '/app/portal/components/page/children/pageChildren.html',
    bindings: {
        page: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});