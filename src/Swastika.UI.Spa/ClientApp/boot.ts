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
    { path: '/', name: 'Home', component: require('./components/home/home.vue.html') },
    {
        path: '/portal',
        name: 'Portal',
        component: require('./components/portal/portal.vue.html'),
        children: [
            { path: '', name: 'Dashboard', component: require('./components/portal/container/dashboard/dashboard.vue.html') },
            { path: 'widgets', name: 'Widgets', component: require('./components/portal/container/widgets/widgets.vue.html') },
        ]
    },
    {
        path: '/blog',
        name: 'Blog',
        component: require('./components/blog/blog.vue.html'),
        children: [
            { path: '', name: 'Dashboard', component: require('./components/blog/container/dashboard/dashboard.vue.html') },
            { path: 'widgets', name: 'Widgets', component: require('./components/blog/container/widgets/widgets.vue.html') },
        ]
    },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
];

new Vue({
    el: '#app-root',
    router: new VueRouter({
        mode: 'history',        
        linkActiveClass: 'open active',
        routes: routes
    }),
    render: h => h(require('./components/app/app.vue.html'))
});