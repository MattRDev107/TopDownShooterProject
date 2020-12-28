using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoonlanderCode.TDS.Player {

	public class PlayerController : MonoBehaviour {

		public float moveSpeed = 5.0f;

		public Rigidbody2D rb;

		public InputController inputController;
		public MovementController movement;

		private void Awake() {
			rb = GetComponent<Rigidbody2D>();

			inputController = this.GetComponent<InputController>();
			movement = this.GetComponent<MovementController>();
		}
	}
}