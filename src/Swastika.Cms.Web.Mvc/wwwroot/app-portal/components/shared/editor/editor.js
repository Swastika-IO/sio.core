
modules.component('editor', {
    templateUrl: '/app/portal/components/shared/editor/editor.html',
    controller: function ($scope) {

    },
    bindings: {
        dataType: '=',
        value: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});