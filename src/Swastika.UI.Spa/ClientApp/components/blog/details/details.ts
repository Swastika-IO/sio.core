import Vue from 'vue';
import { Component } from 'vue-property-decorator';

class BlogViewModel {
    constructor(public data: Object) {
        
    };
}

@Component({
    props: {
        id: String
     
    }
})
export default class DetailsComponent extends Vue {
    id: string;
    model: BlogViewModel = null;
    obj: JSON = null;
    test: String;
    mounted() {
        
        this.id = this.$route.params.id;
        if (this.id != undefined && this.id != '') {
            
            fetch('/api/blog/' + this.id)
                .then(response => response.json())
                .then(data => {
                    this.obj = data;
                    this.test = this.obj['status'];
                    this.model = this.obj['data'];//new BlogViewModel(this.obj['data']);
                });
        }
        
        
    }
}

