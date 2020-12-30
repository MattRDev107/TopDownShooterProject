using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonlanderCode.TDS.Player;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform parent;
    [SerializeField] private float radius = 2f;
	[SerializeField] private float smoothTime = 0.5f;

	private float distance;
	private InputController input;

	private void Start() {
		input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputController;
		parent = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate() {
		FollowBetweenPlayerCamera();
	}

	private void FollowBetweenPlayerCamera() {
		Vector2 mouseWorldPostion = Camera.main.ScreenToWorldPoint(input.MouseScreenPostion);
		Vector3 mouseOffset = (Vector3)mouseWorldPostion - parent.position;
		Vector3 target = new Vector3(mouseOffset.x / 2.0f + parent.position.x, mouseOffset.y / 2.0f + parent.position.y, transform.position.z);

		distance = Vector2.Distance((Vector2) target, (Vector2)parent.position);

		if(distance >= radius) {
			Vector2 norm = mouseOffset.normalized;
			target = new Vector3(norm.x * radius + parent.position.x, norm.y * radius + parent.position.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, target, smoothTime);
		}
		else {
			transform.position = Vector3.Lerp(transform.position, target, smoothTime);
		}
	}
}