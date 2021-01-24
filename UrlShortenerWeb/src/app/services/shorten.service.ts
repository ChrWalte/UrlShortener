import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IResponse } from '../interfaces/IResponse';
import { IUrl } from '../interfaces/IUrl';

@Injectable({
  providedIn: 'root',
})
export class ShortenService {
  // TODO: Get information from config
  private readonly api = '';
  private readonly headers = new HttpHeaders().set(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient) {}

  getUrlCount() {}

  getOriginalUrl(shortUrlPath: string): Observable<IResponse> {
    return this.http
      .get(`${this.api}?path=${shortUrlPath}`, { headers: this.headers })
      .pipe(map((response: any) => response as IResponse));
  }

  createShortUrl(newUrl: IUrl): Observable<IResponse> {
    return this.http
      .post(this.api, newUrl, { headers: this.headers })
      .pipe(map((response: any) => response as IResponse));
  }
}
