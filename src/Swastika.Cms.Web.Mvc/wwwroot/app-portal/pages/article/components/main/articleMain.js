
app.component('articleMain', {
    templateUrl: '/app-portal/pages/article/components/main/articleMain.html',
    bindings: {
        article: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});