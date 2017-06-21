import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import ClickConfirm from 'click-confirm';

@Component({
    components: {
        clickConfirm: ClickConfirm
    }
})
export default class PagingComponent extends Vue {
    @Prop()
    title: string;
    @Prop()
    models: object;
    @Prop()
    getListUrl: string;
    @Prop()
    getDetailsUrl: string;
    @Prop()
    saveUrl: string;
    @Prop()
    removeUrl: string;
    @Prop()
    createUrl: string;
    @Prop()
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
    filter: object = {
        Culture: '',
        Key: '',
        Keyword: '',
        PageIndex: 0,
        PageSize: null
    };
    remove(id) {
        var request = {
            headers: {
                'Content-Type': 'application/json'
            },
            method: "Delete"
        }
        fetch(this.removeUrl + id, request)
            .then(response => response.json())
            .then(data => {
                if (data.status == 1) {
                    this.loadPage();
                }
            });
    }
    loadPage() {
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
                this.models = data['data'];
                this.title = 'Blogs';
            });
    }
    mounted() {
        this.loadPage();
    }
}

