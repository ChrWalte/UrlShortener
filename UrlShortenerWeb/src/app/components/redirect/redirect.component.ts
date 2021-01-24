import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShortenService } from 'src/app/services/shorten.service';

@Component({
  selector: 'app-redirect',
  templateUrl: './redirect.component.html',
  styleUrls: ['./redirect.component.scss'],
})
export class RedirectComponent implements OnInit {
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private shortenService: ShortenService
  ) {}

  ngOnInit(): void {
    this.handleParams();
  }

  private handleParams(): void {
    this.route.params.subscribe((params) => {
      this.shortenService.getOriginalUrl(params.path).subscribe((response) => {
        if (response.Status === 'Success') {
          document.location.href = response.Value;
        } else {
          // TODO: Pass information back to the home screen
          this.router.navigateByUrl('');
        }
      });
    });

    // TODO: Pass information back to the home screen
    this.router.navigateByUrl('');
  }
}
