import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import ClickConfirm from 'click-confirm';
import { Pagination, PaginationEvent } from 'vue-pagination-2';
Vue.component('vuepagination2', Pagination);

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

    filter: object = {
        Culture: '',
        Key: '',
        Keyword: '',
        PageIndex: 0,
        PageSize: 10
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
    loadPage: Function = function (page) {
        this.filter.pageIndex = page;
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
        this.loadPage(0);
        var me = this;
        PaginationEvent.$on('vue-pagination::models', function (page) {
            // display the relevant records using the page param
            me.loadPage(page - 1);
        });

    }
}

