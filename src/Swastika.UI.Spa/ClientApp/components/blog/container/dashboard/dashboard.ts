import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        paging: require('../../paging-container/paging-container.vue.html'),

    }
})
export default class DashboardComponent extends Vue {
    blogs: object = {};
    title: string = 'Blogs';
    
    getListUrl: string = '/api/Blog';
    getDetailsUrl: string = '/blog/details/';
    createUrl: string = '/blog/details/00000000-0000-0000-0000-000000000000';
    saveUrl: string = '/api/Blog/save';
    removeUrl: string = '/api/Blog/remove/';
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'title', display: 'Title' },
        { key: 'name', display: 'Name' }
    ];
    mounted() {
        
    }
}

