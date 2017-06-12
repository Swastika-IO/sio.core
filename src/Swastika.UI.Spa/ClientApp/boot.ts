//import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

//const routes = [
//    { path: '/', component: require('./components/home/home.vue.html') },
//    { path: '/portal', component: require('./components/portal/portal.vue.html') },
//    { path: '/portal/dashboard', component: require('./components/portal/container/dashboard/dashboard.vue.html') },
//    { path: '/counter', component: require('./components/counter/counter.vue.html') },
//    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
//];

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    {
        path: '/portal',
        component: require('./components/portal/portal.vue.html'),
        children: [
            { path: '', component: require('./components/portal/container/dashboard/dashboard.vue.html') },
            { path: 'widgets', component: require('./components/portal/container/widgets/widgets.vue.html') },
        ]
    },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
