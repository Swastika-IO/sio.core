import Vue from 'vue';

export default class SideBarComponent extends Vue {
    handleClick(e) {
        e.preventDefault()
        e.target.classList.toggle('open')
    }
}

