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
    filter: object = {
        Culture: '',
        Key: '',
        Keyword: '',
        PageIndex: 0,
        PageSize: null
    };

    getListUrl: string = '/api/Blog';
    getDetailsUrl: string = '/blog/details/';
    createUrl: string = '/blog/details/00000000-0000-0000-0000-000000000000';
    saveUrl: string = '/api/Blog/save';
    removeUrl: string = '/api/Blog/remove';
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'title', display: 'Title' },
        { key: 'name', display: 'Name' }
    ];
    mounted() {
        var request = {
            headers: {
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(this.filter)
        }

        fetch(this.getListUrl, request)
            .then(response => response.json())
            .then(data => {
                this.blogs = data['data'];
                this.title = 'Blogs';
            });
    }
}

