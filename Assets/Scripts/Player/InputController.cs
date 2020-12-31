using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MoonlanderCode.TDS.Player {

	public class InputController : MonoBehaviour {

		public bool IsShooting { get => isShooting; }
		public bool SwitchToPrimary { get => switchToPrimary; }
		public bool SwitchToSecondary { get => switchToSecondary; }
		public bool SwitchToEquipment { get => switchToEquipment; }
		public Vector2 MovementDirection { get => movementDirection; }
		public Vector2 MouseScreenPostion { get => mousePostion; }

		private bool isShooting = false;
		private bool switchToPrimary = false;
		private bool switchToSecondary = false;
		private bool switchToEquipment = false;
		private Vector2 movementDirection;
		private Vector2 mousePostion;

		private PlayerController playerCon;

		private Controls input;

		private void OnEnable() => input.Player.Enable();
		private void OnDisable() => input.Player.Disable();

		private void Awake() {
			input = new Controls();
			playerCon = GameObject.FindObjectOfType<PlayerController>();

			input.Player.movement.performed += ctx => OnMovement(ctx);

			input.Player.MousePostion.performed += ctx => OnMousePostion(ctx);

			input.Player.Shoot.started += ctx => isShooting = true;
			input.Player.Shoot.canceled += ctx => isShooting = false;

			input.Player.PrimaryWeapon.started += ctx => switchToPrimary = true;
			input.Player.PrimaryWeapon.canceled += ctx => switchToPrimary = false;

			input.Player.SecondaryWeapon.started += ctx => switchToSecondary = true;
			input.Player.SecondaryWeapon.canceled += ctx => switchToSecondary = false;

			input.Player.EquipmentSlot.started += ctx => switchToEquipment = true;
			input.Player.EquipmentSlot.canceled += ctx => switchToEquipment = false;
		}

		private void OnMousePostion(InputAction.CallbackContext ctx) {
			mousePostion = ctx.ReadValue<Vector2>();
		}

		private void OnMovement(InputAction.CallbackContext ctx) {
			movementDirection = ctx.ReadValue<Vector2>();
		}
	}
}
