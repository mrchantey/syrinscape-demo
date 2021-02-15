import { Injectable } from '@angular/core';
import { EnemyType, WeaponType } from '../utility/types';

const ip = '3.104.110.97'
const port = `7000`
const url = `http://${ip}:${port}`

@Injectable({
	providedIn: 'root'
})
export class DatabaseService {

	constructor() { }

	// async getWeapon(): Promise<WeaponType> {
	// 	const data = await fetch(`${url}/weapon`)
	// 	const json = await data.json()
	// 	let val = parseInt(json.weaponType)
	// 	if (Number.isNaN(val))
	// 		val = 0
	// 	console.log(val);
	// 	return val
	// }
	// async getEnemy(): Promise<EnemyType> {
	// 	const data = await fetch(`${url}/enemy`)
	// 	const json = await data.json()
	// 	let val = parseInt(json.enemyType)
	// 	if (Number.isNaN(val))
	// 		val = 0
	// 	console.log(val);
	// 	return val
	// }

	async setWeapon(weaponType: WeaponType): Promise<void> {
		await fetch(`${url}/weapon?type=${weaponType}`)
	}
	async setEnemy(enemyType: EnemyType): Promise<void> {
		await fetch(`${url}/enemy?type=${enemyType}`)
	}
}