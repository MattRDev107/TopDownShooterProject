using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonlanderCode.TDS.Player;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform parent;
    [SerializeField] private float radius = 5.0f;
	[SerializeField] private float smoothTime = 0.5f;

	private InputController input;

	private void Start() {
		input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inputController;
		parent = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void FixedUpdate() {
		FollowBetweenPlayerCamera();
	}

	private void FollowBetweenPlayerCamera() {
		Vector3 mouseWorldPostion = Camera.main.ScreenToWorldPoint(input.MouseScreenPostion);
		Vector3 mouseOffset = mouseWorldPostion - parent.position;
		Vector3 target = new Vector3(mouseOffset.x / 2.0f + parent.position.x, mouseOffset.y / 2.0f + parent.position.y, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, target, smoothTime);

		//float Distance = Vector2.Distance((Vector2)transform.position, (Vector2)parent.position);

		//if(Distance >= radius) {
		//	Vector2 norm = mouseOffset.normalized;
		//	transform.position = new Vector3(norm.x * radius + parent.position.x, norm.y * radius + parent.position.y, transform.position.z);
		//}
	}
}