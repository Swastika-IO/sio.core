import Vue from 'vue';
import { Component } from 'vue-property-decorator';

declare function initPagination(): any;
@Component({
    props: {
        title: String,
        models: JSON,
        headers: Object
    }
})
export default class PagingComponent extends Vue {
    title: string;
    models: object;
    headers: Array<String>;

    
    mounted() {
        if (initPagination !== undefined) {
            console.log(this.models)
            initPagination();
        }
    }
}

