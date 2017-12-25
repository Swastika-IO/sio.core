import { Component, Input, Output, OnInit, OnChanges, EventEmitter, Injectable } from '@angular/core';
import {
  ApiResult, SWDataTable, ArticleModuleNav,
  ModuleFullDetails, ModuleDataDetails, PagingData, DataType
} from '../viewmodels/viewmodels.component';
import { CKEditorComponent } from 'ng2-ckeditor';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ImageRenderComponent, DatetimeRenderComponent, HtmlRenderComponent } from '../components/data-render/data-render.components';
import { LocalDataSource } from 'ng2-smart-table';
import { environment } from "../environment";
@Injectable()
export class ModuleDetailsService {
    domain = environment.domain;
    apiUrl = environment.apiUrl;
    pagingData = new PagingData();
    constructor(private http: Http) {
        this.pagingData.pageIndex = 0;
        this.pagingData.pageSize = 15;

    }
    initModuleDetails(module: ModuleFullDetails, articleId: string = ''): SWDataTable {
        this.pagingData.endPoint = this.apiUrl + 'api/vi-vn/moduleData/';
        var result = new SWDataTable();
        result.models = module;
        if (articleId != '') {
            this.pagingData.endPoint += 'getByArticle/' + articleId + '/';
        }
        result.settings = {
            mode: 'inline',
            columns: {},
            add: {
                addButtonContent: '<i class="nb-plus"></i>',
                createButtonContent: '<i class="nb-checkmark"></i>',
                cancelButtonContent: '<i class="nb-close"></i>',
                // confirmCreate: true,
            },
            edit: {
                editButtonContent: '<i class="nb-edit"></i>',
                saveButtonContent: '<i class="nb-checkmark"></i>',
                cancelButtonContent: '<i class="nb-close"></i>',
                // confirmSave: true,
            },
            delete: {
                deleteButtonContent: '<i class="nb-trash"></i>',
                confirmDelete: true,
            },

            actions: {
                add: true,
            },
        };
        // result.settings.columns['id'] = {
        //     title: 'ID',
        //     type: 'string',
        //     filter: false,
            
        // };
        module.columns.forEach(col => {
            result.settings.columns[col.name] = {};
            result.settings.columns[col.name]['title'] = col.name;
            switch (col.dataType) {
                case DataType.Image:
                    result.settings.columns[col.name]['type'] = 'custom';
                    result.settings.columns[col.name]['renderComponent'] = ImageRenderComponent;
                    break;
                case DataType.Html:
                    result.settings.columns[col.name]['type'] = 'custom';
                    result.settings.columns[col.name]['renderComponent'] = HtmlRenderComponent;
                    // module.settings.columns[col.name]['editor'] = {
                    //     type: 'custom',
                    //     component: CKEditorComponent,
                    // };
                    break;
                default:
                    result.settings.columns[col.name]['type'] = 'text';
                    break;
            }
            result.settings.columns[col.name]['filter'] = false;
        });

        result.source = new LocalDataSource();

        result.source.load(module.data.jsonItems);
        // (this.http,
        //     {
        //         endPoint: this.pagingData.endPoint + module.id,
        //         dataKey: 'data.jsonItems',
        //         pagerLimitKey: 'data.pageSize',
        //         pagerPageKey: 'data.pageIndex',
        //         totalKey: 'data.totalItems',
        //     },
        // );

        return result;
    }
    saveModuleData(url: string, data: ModuleDataDetails): Promise<ApiResult> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers['Access-Control-Allow-Origin'] = '*'
        let options = new RequestOptions({ headers: headers });

        var result = this.http.post(url, data, options).toPromise()
            .then(this.extractData)
            .catch(this.handleErrorPromise);
        return result;
    }

    deleteModuleDataWithPromise(culture: string, id: string): Promise<ApiResult> {
        const getUrl = this.domain + 'api/' + culture + '/ModuleData/delete/' + id;
        return this.http.get(getUrl).toPromise()
            .then(this.extractData)
            .catch(this.handleErrorPromise);
    }

    addToArticle(url: string, data: ArticleModuleNav): Promise<ApiResult> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers['Access-Control-Allow-Origin'] = '*';
        let options = new RequestOptions({ headers: headers });
        var result = this.http.post(this.domain + url, data, options).toPromise()
            .then(this.extractData)
            .catch(this.handleErrorPromise);
        return result;
    }

    private extractData(res: Response) {
        const body = res.json();
        return body || {};
    }

    private handleErrorPromise(error: Response | any) {
        console.error(error.message || error);
        return Promise.reject(error.message || error);
    }

}
