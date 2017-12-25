import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { ApiResult } from "../viewmodels/viewmodels.component";
import { environment } from "../environment";

@Injectable()
export class ModuleService {
  domain = environment.domain;
  constructor(private http: Http) {
  }
  getFullModuleWithPromise(culture: string, id: number): Promise<ApiResult> {
    const getUrl = this.domain + 'api/' + culture + '/modules/full/' + id;
    return this.http.get(getUrl).toPromise()
      .then(this.extractData)
      .catch(this.handleErrorPromise);
  }

  getFullModuleByArticle(culture: string, id: number, articleId: string): Promise<ApiResult> {
    const getUrl = this.domain + 'api/' + culture + '/modules/byArticle/' + id + '/' + articleId;
    return this.http.get(getUrl).toPromise()
      .then(this.extractData)
      .catch(this.handleErrorPromise);
  }

  deleteModuleWithPromise(culture: string, id: number): Promise<ApiResult> {
    const getUrl = this.domain + 'api/' + culture + '/Modules/delete/' + id;
    return this.http.get(getUrl).toPromise()
      .then(this.extractData)
      .catch(this.handleErrorPromise);
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
