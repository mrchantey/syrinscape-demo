import { Injectable } from '@angular/core';
import { WeaponType } from '../utility/types';

// const url = `http://127.0.0.1:7100`
// const url = `http://13.210.198.100:7000`

const ip = '13.210.246.148'
const port = `7000`
const url = `http://${ip}:${port}`

@Injectable({
	providedIn: 'root'
})
export class DatabaseService {

	constructor() { }

	async getWeapon(): Promise<WeaponType> {
		const data = await fetch(`${url}/weapon`)
		const json = await data.json()
		let val = parseInt(json.weaponType)
		if (Number.isNaN(val))
			val = 0
		console.log(val);
		return val
	}

	async setWeapon(weaponType: WeaponType): Promise<void> {
		await fetch(`${url}/weapon?type=${weaponType}`)
	}
}
