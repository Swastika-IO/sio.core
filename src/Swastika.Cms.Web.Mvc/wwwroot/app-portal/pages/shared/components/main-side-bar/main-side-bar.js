modules.component('mainSideBar', {
    templateUrl: '/app-portal/pages/shared/components/main-side-bar/main-side-bar.html',
    controller: function ($scope) {
        var ctrl = this;
        var culture = $('#lang').val();
        ctrl.items = [
            {
                title: 'Articles',
                shortTitle: 'Articles',
                icon: 'mi mi-ReadingList',
                subMenus: [
                    {
                        title: 'Create',
                        href: '#',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '#',
                        icon: 'mi mi-List'
                    },
                    {
                        title: 'Draft',
                        href: '#',
                        icon: 'mi mi-Paste'
                    }
                ]
            },
            {
                title: 'Products',
                shortTitle: 'Products',
                icon: 'mi mi-Package',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/product/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/product/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Pages',
                shortTitle: 'Pages',
                icon: 'mi mi-Page',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/page/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/page/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Forms',
                shortTitle: 'Forms',
                icon: 'mi mi-wpform',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/forms/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/forms/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Modules',
                shortTitle: 'Modules',
                icon: 'mi mi-ResolutionLegacy',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/modules/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/modules/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Widgets',
                shortTitle: 'Widgets',
                icon: 'mi mi-Component',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/widgets/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/widgets/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Themes',
                shortTitle: 'Themes',
                icon: 'mi mi-Personalize',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/themes/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/themes/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Media',
                shortTitle: 'Media',
                icon: 'mi mi-Photo2',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/media/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/media/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Team',
                shortTitle: 'Team',
                icon: 'mi mi-Contact',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/team/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/team/list',
                        icon: 'mi mi-List'
                    }
                ]
            },
            {
                title: 'Settings',
                shortTitle: 'Settings',
                icon: 'mi mi-Settings mi-spin',
                subMenus: [
                    {
                        title: 'Create',
                        href: '/admin/settings/create',
                        icon: 'mi mi-Add'
                    },
                    {
                        title: 'List',
                        href: '/admin/settings/list',
                        icon: 'mi mi-List'
                    }
                ]
            }
        ]
    },
    bindings: {
    }
});
