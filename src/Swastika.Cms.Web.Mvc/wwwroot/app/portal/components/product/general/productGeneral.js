
app.component('productGeneral', {
    templateUrl: '/app/portal/components/product/general/productGeneral.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});