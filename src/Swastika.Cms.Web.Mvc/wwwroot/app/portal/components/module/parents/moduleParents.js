app.component('moduleParents', {
    templateUrl: '/app/portal/components/module/parents/moduleParents.html',
    bindings: {
        module: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});