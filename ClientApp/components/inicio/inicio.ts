import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface interface_carusel {
    src: string;
}

@Component
export default class HomeComponent extends Vue {
    public bottomNav: string = 'recent';
    public lstitems: interface_carusel[] = [
        { src: './slide01.png' },
        { src: './slide02.png' }
    ];
    mounted() {
        localStorage.setItem('isMenu', 'false');
        return 0;
    }
}
