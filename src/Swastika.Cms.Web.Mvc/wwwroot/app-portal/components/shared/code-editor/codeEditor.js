
modules.component('codeEditor', {
    templateUrl: '/app/portal/components/shared/code-editor/codeEditor.html',
    controller: 'PortalTemplateController',
    bindings: {
        template: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});