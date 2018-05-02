modules.component('mainSideBar', {
    templateUrl: '/app-portal/pages/shared/components/main-side-bar/main-side-bar.html',
    controller: function ($scope) {
        var ctrl = this;
        var culture = $('#lang').val();
        ctrl.items = [
            {
                title: 'Articles',
                shortTitle: 'Articles ...',
                icon: 'mi mi-ReadingList',
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
                icon: 'mi mi-Package',
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
            {
                title: 'Pages',
                shortTitle: 'Products ...',
                icon: 'mi mi-Page',
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
            {
                title: 'Forms',
                shortTitle: 'Products ...',
                icon: 'mi mi-wpform',
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
            {
                title: 'Modules',
                shortTitle: 'Products ...',
                icon: 'mi mi-ResolutionLegacy',
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
            {
                title: 'Widgets',
                shortTitle: 'Products ...',
                icon: 'mi mi-Component',
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
            {
                title: 'Themes',
                shortTitle: 'Products ...',
                icon: 'mi mi-Personalize',
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
            {
                title: 'Media',
                shortTitle: 'Products ...',
                icon: 'mi mi-Photo2 mi-fw',
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
            {
                title: 'Team',
                shortTitle: 'Products ...',
                icon: 'mi mi-Contact',
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
            {
                title: 'Settings',
                shortTitle: 'Products ...',
                icon: 'mi mi-Settings mi-spin',
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
            }
        ]
    },
    bindings: {
    }
});
