modules.component('templateEditor', {
    templateUrl: '/app-portal/pages/shared/components/template-editor/templateEditor.html',
    controller: 'TemplateController',
    bindings: {
        template: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});