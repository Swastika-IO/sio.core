app.component('moduleMain', {
    templateUrl: '/app/portal/components/module/main/moduleMain.html',
    bindings: {
        module: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});