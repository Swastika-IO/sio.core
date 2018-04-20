
modules.component('codeEditor', {
    templateUrl: '/app/portal/components/shared/code-editor/codeEditor.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});