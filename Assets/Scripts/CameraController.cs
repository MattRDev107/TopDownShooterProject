using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonlanderCode.TDS.Player;

public class CameraController : MonoBehaviour {

	[SerializeField] private float dampTime = 0.5f;
	[SerializeField] private Vector3 velocity = Vector3.zero;

	private float offset = -10.0f;

	private PlayerController playerCon;
	private Transform playerTrans;

	private void Start() {
		playerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate() {
		FollowBetweenPlayerCamera();
	}

	private void FollowBetweenPlayerCamera() {
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(playerCon.inputController.MouseScreenPostion);
		Vector3 target = playerTrans.position + mouseWorldPosition/2;

		transform.position = new Vector3(target.x, target.y, offset);
	}
}
