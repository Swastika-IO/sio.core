export const environment = {
  production: false,  
  isBusy: false,
  apiUrl: '/api/',
  domain: '/',
  culture: 'vi-vn', // 'en-UK', //
  pagingConfig: {
    endPoint: '/api/vi-vn/moduleData/',
    dataKey: 'data.items',
    pagerLimitKey: 'data.pageSize',
    pagerPageKey: 'data.pageIndex',
    totalKey: 'data.totalItems',

  },
  localStorageKeys:{
    accessToken: 'accessToken'
  },
  listSupportedCulture:[
    'vi-vn', 
    'en-UK',
  ]
};
