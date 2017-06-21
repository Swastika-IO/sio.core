import Vue from 'vue';
import { Component } from 'vue-property-decorator';

// Using vue-pagination-2
import { Pagination, PaginationEvent } from 'vue-pagination-2';
Vue.component('vuepagination2', Pagination);

@Component({
    components: {
        listItemPaging: require('../../paging-container/paging-container.vue.html'),

    }
})
export default class DashboardComponent extends Vue {
    blogs: object = {};
    title: string = 'Blogs';
    
    getListUrl: string = '/api/Blog';
    getDetailsUrl: string = '/portal/blog/details/';
    createUrl: string = '/portal/blog/details/00000000-0000-0000-0000-000000000000';
    saveUrl: string = '/api/Blog/save';
    removeUrl: string = '/api/Blog/remove/';
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'title', display: 'Title' },
        { key: 'name', display: 'Name' }
    ];
    mounted() {
        

        PaginationEvent.$on('vue-pagination::blogs', function (page) {
            // display the relevant records using the page param

            //this.filter.PageIndex = page;
            //alert();
            var request = {
                headers: {
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify({
                    Culture: '',
                    Key: '',
                    Keyword: '',
                    PageIndex: page,
                    PageSize: 2
                })
            }

            fetch(this.getListUrl, request)
                .then(response => response.json())
                .then(data => {
                    this.blogs = data['data'];
                    this.title = 'Blogs';
                });
        });
        
    };

    created() {
        
    }
    

    
}

