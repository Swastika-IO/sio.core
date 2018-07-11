
app.component('productMain', {
    templateUrl: '/app/portal/components/product/main/productMain.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});