import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RedirectComponent } from '../components/redirect/redirect.component';
import { UrlShortenerComponent } from '../components/url-shortener/url-shortener.component';

const routes: Routes = [
  { path: '', component: UrlShortenerComponent, pathMatch: 'full' },
  { path: ':path', component: RedirectComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
