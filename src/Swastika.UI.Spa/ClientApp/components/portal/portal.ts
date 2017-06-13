//import Vue from 'vue';
//import { Component } from 'vue-property-decorator';

//@Component({
//    components: {
//        MenuComponent: require('../navmenu/navmenu.vue.html')
//    }
//})
//export default class AppComponent extends Vue {
//}
import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
    components: {
        AppHeader: require('./app-header/header.vue.html')
    }
})
export default class AppComponent extends Vue {
}
