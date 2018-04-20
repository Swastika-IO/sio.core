
app.component('productParents', {
    templateUrl: '/app/portal/components/product/parents/productParents.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});