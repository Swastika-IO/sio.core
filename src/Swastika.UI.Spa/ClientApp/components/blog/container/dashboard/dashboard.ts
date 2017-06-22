import Vue from 'vue';
import { Component } from 'vue-property-decorator';

// Using vue-pagination-2
//import { Pagination, PaginationEvent } from 'vue-pagination-2';
//Vue.component('vuepagination2', Pagination);

@Component({
    components: {
        listItemPaging: require('../../paging-container/paging-container.vue.html'),

    }
})
export default class DashboardComponent extends Vue {
    blogs: object = {};
    title: string = 'Blogs';
    pageSize: number = 10;
    getListUrl: string = '/api/Blog';
    getDetailsUrl: string = '/portal/blog/details/';
    createUrl: string = '/portal/blog/details/00000000-0000-0000-0000-000000000000';
    saveUrl: string = '/api/Blog/save';
    removeUrl: string = '/api/Blog/remove/';
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'name', display: 'Name' },
        { key: 'description', display: 'Description' },
        { key: 'slug', display: 'Slug' },
        { key: 'createdUtc', display: 'Created Date' }
    ];
    mounted() {
        

        
    };

    created() {
        
    }
    

    
}

