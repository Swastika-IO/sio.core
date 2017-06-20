import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    props: {
        id: String

    }
})
export default class DetailsComponent extends Vue {
    id: string;
    model: JSON = null;
    obj: JSON = null;
    test: String;
    submit() {
        var request = {
            headers: {
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(this.model)
        }
        fetch('/api/blog/save', request)
            .then(response => response.json())
            .then(data => {
                if (data.status == 1) {
                    this.$router.push('/blog');
                }
            });
    }
    mounted() {

        this.id = this.$route.params.id;
        if (this.id != undefined && this.id != '') {

            fetch('/api/blog/' + this.id, )
                .then(response => response.json())
                .then(data => {
                    this.model = data['data'];//new BlogViewModel(this.obj['data']);
                });
        }


    }
}

