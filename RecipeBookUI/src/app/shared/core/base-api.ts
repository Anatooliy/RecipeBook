import { HttpClient } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class BaseApi {
    private baseUrl = '//localhost:50013/api/';

    constructor(public http: HttpClient){}

    private getUrl(url: string = ''): string{
        return this.baseUrl + url;
    }

    public get<T>(url: string = ''): Observable<T>{
        return this.http.get<T>(this.getUrl(url)).pipe(
            map((response: T) => response)
        );
    }

    public post(url: string = '', data: any = {}): Observable<any>{
        return this.http.post(this.getUrl(url), data).pipe(
            map((response: Response) => response)
        );
    }

    public put(url: string = '', data: any = {}): Observable<any>{
        return this.http.put(this.getUrl(url), data).pipe(
            map((response: Response) => response)
        );
    }

    public delete(url: string = '', data: any = {}): Observable<any>{
        return this.http.delete(this.getUrl(url)).pipe(
            map((response: Response) => response)
        );
    }
}
