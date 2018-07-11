
app.component('productSeo', {
    templateUrl: '/app/portal/components/product/seo/productSeo.html',
    bindings: {
        product: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});