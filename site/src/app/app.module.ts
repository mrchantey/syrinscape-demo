import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { JobInterviewComponent } from './components/job-interview/job-interview.component';

@NgModule({
	declarations: [
		AppComponent,
		JobInterviewComponent
	],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		MatSliderModule,
		MatButtonModule,
		MatCardModule,
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }