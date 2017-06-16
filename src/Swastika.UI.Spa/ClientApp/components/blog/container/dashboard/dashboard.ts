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
    headers: Array<object> = [
        { key: 'id', display: 'Id' },
        { key: 'title', display: 'Title' },
        { key: 'name', display: 'Name' }
    ];
    mounted() {
        fetch('/api/Blog')
            .then(response => response.json())
            .then(data => {
                this.blogs = data;
                this.title = 'Blogs';
            });
    }
}

