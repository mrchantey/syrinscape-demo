import { Component, OnInit } from '@angular/core';

enum WeaponType {
	None,
	Confidence,
	Experience,
	Rich
}

enum Image {
	Question = "../../../assets/question_white_192x192.png",
	Dollar = "../../../assets/dollar_white_192x192.png",
	Heart = "../../../assets/heart_white_192x192.png",
	Read = "../../../assets/read_white_192x192.png",
}

@Component({
	selector: 'app-job-interview',
	templateUrl: './job-interview.component.html',
	styleUrls: ['./job-interview.component.css']
})
export class JobInterviewComponent implements OnInit {
	playerName: string
	public get weaponType(): typeof WeaponType { return WeaponType; }
	imgSrc = Image.Question
	constructor() {
		this.playerName = `Job Applicant #${Math.floor(Math.random() * 1000)}`
	}

	ngOnInit(): void {
	}

	selectWeapon(weaponType: WeaponType) {
		switch (weaponType) {
			case WeaponType.Confidence:
				this.imgSrc = Image.Heart
				break
			case WeaponType.Experience:
				this.imgSrc = Image.Read
				break
			case WeaponType.Rich:
				this.imgSrc = Image.Dollar
				break
		}

	}

}
