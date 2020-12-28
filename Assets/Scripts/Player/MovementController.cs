using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonlanderCode.TDS.Player {

	public class MovementController : MonoBehaviour {

		private PlayerController player;

		private void Awake() {
			player = this.GetComponent<PlayerController>();
		}

		private void FixedUpdate() {
			MovePlayer();
			LookAtMouse();
		}

		public void MovePlayer() {
			Vector2 moveDir = player.inputController.MovementDirection.normalized;
			Vector2 movePosition = player.rb.position + moveDir * player.moveSpeed * Time.fixedDeltaTime;

			player.rb.MovePosition(movePosition);
		}

		private void LookAtMouse() {
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(player.inputController.MouseScreenPostion);
			Vector3 targetDirection = mouseWorldPosition - transform.position;
			float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle - 90.0f));
		}
	}
}

