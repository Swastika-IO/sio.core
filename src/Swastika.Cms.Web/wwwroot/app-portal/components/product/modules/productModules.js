
app.component('productModules', {
    templateUrl: '/app/portal/components/product/modules/productModules.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});