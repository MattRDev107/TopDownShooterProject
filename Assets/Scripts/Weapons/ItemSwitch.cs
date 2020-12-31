using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonlanderCode.TDS.Player;

namespace MoonlanderCode.TDS.Weapons {

	public class ItemSwitch : MonoBehaviour {

		private WeaponSelection weaponSelected;
		private GameObject primary, secondary, equipmentSlot;
		private InputController input;

		enum WeaponSelection { primary, secondary, equipment }

		private void Start() {
			input = GameObject.FindObjectOfType<PlayerController>().inputController;

			primary = GameObject.FindGameObjectWithTag("Primary");
			secondary = GameObject.FindGameObjectWithTag("Secondary");
			equipmentSlot = GameObject.FindGameObjectWithTag("EquipmentSlot");

			weaponSelected = WeaponSelection.primary;
			secondary.SetActive(false);
			equipmentSlot.SetActive(false);
		}

		private void Update() {
			if (input.SwitchToPrimary) {
				if(weaponSelected != WeaponSelection.primary) {
					SwitchWeapon(WeaponSelection.primary);
				}
			}
			if (input.SwitchToSecondary) {
				if (weaponSelected != WeaponSelection.secondary) {
					SwitchWeapon(WeaponSelection.secondary);
				}
			}
			if (input.SwitchToEquipment) {
				if(weaponSelected != WeaponSelection.equipment) {
					SwitchWeapon(WeaponSelection.equipment);
				}
			}
		}

		private void SwitchWeapon(WeaponSelection SelectWeapon) {
			switch (SelectWeapon) {
				case WeaponSelection.primary:
					weaponSelected = WeaponSelection.primary;
					primary.SetActive(true);
					secondary.SetActive(false);
					equipmentSlot.SetActive(false);
					break;
				case WeaponSelection.secondary:
					weaponSelected = WeaponSelection.secondary;
					primary.SetActive(false);
					secondary.SetActive(true);
					equipmentSlot.SetActive(false);
					break;
				case WeaponSelection.equipment:
					weaponSelected = WeaponSelection.equipment;
					primary.SetActive(false);
					secondary.SetActive(false);
					equipmentSlot.SetActive(true);
					break;
				default:
					Debug.LogError("Switch Weapon Failed to Switch");
					break;
			}
		}
	}
}