
app.component('customerOrders', {
    templateUrl: '/app-portal/pages/customer/components/orders/customer-orders.html',
    bindings: {
        customer: '=',
        onDelete: '&',
        onUpdate: '&'
    }
});