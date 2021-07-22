using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	private void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
			Attack();
			StartCoroutine(FindObjectOfType<CameraContrller>().CameraShake(0.4f, 0.4f));
		}
	}

	private void Attack()
    {
		//鼠标位置【目标点位置】-当前位置【人物所在位置】
		Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;// Radius -> Degree弧度转角度
		transform.rotation = Quaternion.Euler(0, 0, rotZ);
		transform.GetChild(0).gameObject.SetActive(true);
    }
}
