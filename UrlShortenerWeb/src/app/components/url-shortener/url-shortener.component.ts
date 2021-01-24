import { Component, OnInit } from '@angular/core';
import { IUrl } from 'src/app/interfaces/IUrl';
import { ShortenService } from 'src/app/services/shorten.service';

@Component({
  selector: 'app-url-shortener',
  templateUrl: './url-shortener.component.html',
  styleUrls: ['./url-shortener.component.scss'],
})
export class UrlShortenerComponent implements OnInit {
  completeUrl: IUrl = {
    Identifier: '',
    OriginalUrl: '',
    ShortUrlPath: '',
  };

  baseShortUrl: string = 'https://chrwalte.com/';
  newShortUrl: string = `${this.baseShortUrl}cmpw`;
  responseMessage: string = '';

  constructor(private shortenService: ShortenService) {}

  ngOnInit(): void {}

  isForumValid(): boolean {
    return this.completeUrl.OriginalUrl !== '';
  }

  submitShortUrlRequest(): void {
    this.shortenService
      .createShortUrl(this.completeUrl)
      .subscribe((response) => {
        if (response.Status === 'Success') {
          this.newShortUrl = `${this.baseShortUrl}${response.Value.shortUrlPath}`;
          this.responseMessage = `Short Url Created Successfully For: ${response.Value.OriginalUrl}`;
        } else {
          this.responseMessage = `${response.Message}`;
        }
      });
  }
}
