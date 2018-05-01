modules.component('codeEditor', {
    templateUrl: '/app-portal/pages/shared/components/code-editor/codeEditor.html',
    controller: 'PortalTemplateController',
    bindings: {
        template: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});