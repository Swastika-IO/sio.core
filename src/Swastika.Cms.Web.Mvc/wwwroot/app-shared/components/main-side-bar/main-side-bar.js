modules.component('mainSideBar', {
    templateUrl: '/app-shared/components/main-side-bar/main-side-bar.html',
    controller: ['$rootScope', '$scope', 'ngAppSettings', 'TranslatorService', function ($rootScope, $scope, ngAppSettings, translatorService) {
        var ctrl = this;
        ctrl.init = async function () {
            ctrl.items = [
                {
                    title: 'portal_dashboard',
                    shortTitle: 'portal_short_dashboard',
                    icon: 'mi mi-Tiles',
                    href: '/backend',
                    subMenus: []
                },
                {
                    title: 'portal_articles',
                    shortTitle: ('portal_articles'),
                    icon: 'mi mi-ReadingList',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/article/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/article/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_products',
                    shortTitle: 'portal_products',
                    icon: 'mi mi-Package',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/product/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/product/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_orders',
                    shortTitle: 'portal_orders',
                    icon: 'mi mi-Package',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/order/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/order/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_pages',
                    shortTitle: 'portal_pages',
                    icon: 'mi mi-Page',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/page/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/page/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_modules',
                    shortTitle: 'portal_modules',
                    icon: 'mi mi-ResolutionLegacy',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/module/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/module/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_themes',
                    shortTitle: 'portal_themes',
                    icon: 'mi mi-Personalize',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/theme/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/theme/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_media',
                    shortTitle: 'Media',
                    icon: 'mi mi-Photo2',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/media/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/media/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_file',
                    shortTitle: 'File',
                    icon: 'mi mi-FileExplorer',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/file/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/file/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_users',
                    shortTitle: 'Users',
                    icon: 'mi mi-Contact',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/user/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/user/list',
                            icon: 'mi mi-List'
                        },
                        {
                            title: 'Roles',
                            href: '/backend/role/list',
                            icon: 'mi mi-Permissions'
                        }
                    ]
                },
                {
                    title: 'portal_settings',
                    shortTitle: 'Settings',
                    icon: 'mi mi-Settings mi-spin',
                    href: '#',
                    subMenus: [
                        {
                            title: 'portal_app_settings',
                            href: '/backend/app-settings/details',
                            icon: 'mi mi-ViewAll'
                        },
                        {
                            title: ('portal_create'),
                            href: '/backend/configuration/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/configuration/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'language',
                    shortTitle: 'Language',
                    icon: 'mi mi-TimeLanguage',
                    href: '#',
                    subMenus: [
                        {
                            title: 'portal_create',
                            href: '/backend/language/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'List',
                            href: '/backend/language/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'portal_cultures',
                    shortTitle: 'portal_short_cultures',
                    icon: 'mi mi-Globe mi-spin',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/culture/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/culture/list',
                            icon: 'mi mi-List'
                        }
                    ]
                },
                {
                    title: 'Portal Pages',
                    shortTitle: 'portal_short_portal_pages',
                    icon: 'mi mi-Globe mi-spin',
                    href: '#',
                    subMenus: [
                        {
                            title: ('portal_create'),
                            href: '/backend/portal-page/create',
                            icon: 'mi mi-Add'
                        },
                        {
                            title: 'portal_list',
                            href: '/backend/portal-page/list',
                            icon: 'mi mi-List'
                        }
                    ]
                }
            ];
        };
    }],
    bindings: {
        translate:  '&'
    }
});