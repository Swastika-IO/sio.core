import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { dropdown } from 'vue-strap';

@Component({
    components: {
        navbar: require('../nav-bar/nav-bar.vue.html'),
        dropdown: dropdown
    }
})
export default class AppHeaderComponent extends Vue {
    click() {
        // do nothing
    }
    sidebarToggle(e) {
        e.preventDefault()
        document.body.classList.toggle('sidebar-hidden')
    }
    sidebarMinimize(e) {
        e.preventDefault()
        document.body.classList.toggle('sidebar-minimized')
    }
    mobileSidebarToggle(e) {
        e.preventDefault()
        document.body.classList.toggle('sidebar-mobile-show')
    }
    asideToggle(e) {
        e.preventDefault()
        document.body.classList.toggle('aside-menu-hidden')
    }
}

