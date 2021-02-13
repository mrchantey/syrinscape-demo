import { Component, OnInit } from '@angular/core';
import { WeaponType } from 'src/app/utility/types';
import { DatabaseService } from '../../services/database.service';

const imageLookup = [
	"../../../assets/question_white_192x192.png",
	"../../../assets/heart_white_192x192.png",
	"../../../assets/read_white_192x192.png",
	"../../../assets/dollar_white_192x192.png",
]

@Component({
	selector: 'app-job-interview',
	templateUrl: './job-interview.component.html',
	styleUrls: ['./job-interview.component.css']
})
export class JobInterviewComponent implements OnInit {
	playerName: string
	public get weaponType(): typeof WeaponType { return WeaponType; }
	imgSrc = imageLookup[WeaponType.None]
	constructor(private databaseService: DatabaseService) {
		this.playerName = `Job Applicant #${Math.floor(Math.random() * 1000)}`
		this.getWeapon()
	}

	async getWeapon() {
		const weaponType = await this.databaseService.getWeapon()
		this.imgSrc = imageLookup[weaponType]
	}

	ngOnInit(): void {
	}

	async selectWeapon(weaponType: WeaponType) {
		this.imgSrc = imageLookup[weaponType]
		await this.databaseService.setWeapon(weaponType)
	}
}
