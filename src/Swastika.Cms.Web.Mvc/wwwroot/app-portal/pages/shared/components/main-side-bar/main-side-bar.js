
modules.component('mainSideBar', {
    templateUrl: '/app-portal/pages/shared/components/main-side-bar/main-side-bar.html',
    controller: function ($scope) {
        var ctrl = this;
        var culture = $('#lang').val();
        ctrl.items = [
            {
                title: 'Articles',
                shortTitle: 'Articles ...',
                subMenus: [
                    {
                        title: 'Create',
                        href: '#',
                        icon: 'mi mi-Add mi-fw'
                    },
                    {
                        title: 'List',
                        href: '#',
                        icon: 'mi mi-List mi-fw'
                    },
                    {
                        title: 'Draft',
                        href: '#',
                        icon: 'mi mi-Paste mi-fw'
                    }
                ]
            },
            {
                title: 'Products',
                shortTitle: 'Products ...',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/product/create',
                        icon: 'mi mi-Add mi-fw'
                    },
                    {
                        title: 'List',
                        href: '/admin/product/list',
                        icon: 'mi mi-List mi-fw'
                    }
                ]
            },
        ]
    },
    bindings: {
    }
});