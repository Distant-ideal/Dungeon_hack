using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //强制要求对象必须含有rigidbody2D组件没如果没有会自动添加一个
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //获得刚体组件
    }

    private void Update() 
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed; //x轴方向位移量 * 移动速度控制角色移动快慢
        moveV = Input.GetAxis("Vertical") * moveSpeed; //y轴
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV); //水平方向和垂直方向速度
    }

    private void Flip()
    {
        //if (moveH > 0)
        if(transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x) //人物在鼠标的左半面
            transform.eulerAngles = new Vector3(0, 0, 0); //如果向右移动
        //if (moveH < 0) 
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            transform.eulerAngles = new Vector3(0, 180, 0); //调整欧拉角180度旋转左右旋转
    }
}
