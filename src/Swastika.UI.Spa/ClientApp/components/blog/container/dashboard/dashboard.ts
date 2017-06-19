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
    apiUrl: string = '/api/Blog';
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'title', display: 'Title' },
        { key: 'name', display: 'Name' }
    ];
    mounted() {
        fetch(this.apiUrl)
            .then(response => response.json())
            .then(data => {
                this.blogs = data;
                this.title = 'Blogs';
            });
    }
}

