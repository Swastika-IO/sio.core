import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    props: {
        title: String,
        models: JSON,
        headers: Object,
        getListUrl: String,
        getDetailsUrl: String,
        saveUrl: String,
        removeUrl: String,
        createUrl: String
    }
})
export default class PagingComponent extends Vue {
    title: string;
    models: object;
    getListUrl: string;
    getDetailsUrl: string;
    saveUrl: string;
    removeUrl: string;
    createUrl: string;
    headers: Array<String>;

    pagination: object = {
        total: 0,
        per_page: 12,    // required 
        current_page: 1, // required 
        last_page: 0,    // required 
        from: 1,
        to: 12           // required 
    };

    paginationOptions: object = {
        offset: 4,
        previousText: 'Prev',
        nextText: 'Next',
        alwaysShowPrevNext: true
    };
    mounted() {

    }
}

