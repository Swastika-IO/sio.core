
app.component('productMain', {
    templateUrl: '/app-portal/pages/product/components/main/productMain.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});