import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        AppHeader: require('./app-header/header.vue.html'),
        SidebarComponent: require('./sidebar/sidebar.vue.html'),
        BreadcrumbComponent: require('./breadcrumb/breadcrumb.vue.html')
    }
})
export default class AppComponent extends Vue {
}
