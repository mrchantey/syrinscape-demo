import { Component, OnInit } from '@angular/core';
import { WeaponType, EnemyType } from 'src/app/utility/types';
import { DatabaseService } from '../../services/database.service';

const weaponImageLookup = [
	"../../../assets/question_white_192x192.png",
	"../../../assets/heart_white_192x192.png",
	"../../../assets/read_white_192x192.png",
	"../../../assets/dollar_white_192x192.png",
]
const enemyImageLookup = [
	"../../../assets/question_white_192x192.png",
	"../../../assets/sentiment_neutral_white_192x192.png",
	"../../../assets/sentiment_dissatisfied_white_192x192.png",
	"../../../assets/sentiment_very_dissatisfied_white_192x192.png",
]

@Component({
	selector: 'app-job-interview',
	templateUrl: './job-interview.component.html',
	styleUrls: ['./job-interview.component.css']
})
export class JobInterviewComponent implements OnInit {
	playerName: string
	public get weaponType() { return WeaponType; }
	public get enemyType() { return EnemyType; }
	weaponImgSrc = weaponImageLookup[WeaponType.None]
	enemyImgSrc = enemyImageLookup[EnemyType.None]
	constructor(private databaseService: DatabaseService) {
		this.playerName = `Applicant #${Math.floor(Math.random() * 1000)}`
		this.selectWeapon(WeaponType.None)
		this.selectEnemy(EnemyType.None)
		// this.getWeapon()
	}

	// async getWeapon() {
	// 	const weaponType = await this.databaseService.getWeapon()
	// 	this.weaponImgSrc = weaponImageLookup[weaponType]
	// }

	ngOnInit(): void {
	}

	async selectWeapon(weaponType: WeaponType) {
		this.weaponImgSrc = weaponImageLookup[weaponType]
		await this.databaseService.setWeapon(weaponType)
	}
	async selectEnemy(enemyType: EnemyType) {
		this.enemyImgSrc = enemyImageLookup[enemyType]
		await this.databaseService.setEnemy(enemyType)
	}
}
