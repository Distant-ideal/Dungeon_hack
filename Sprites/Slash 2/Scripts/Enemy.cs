 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;
    private Transform target;
    [SerializeField]
    private float maxHp;

    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength; //持续时间
    private float hurtCounter; //计数器

    [HideInInspector]
    public bool IsAttacked;
    public GameObject ExplosionEffect;


    private void Start()
    {
        hp = maxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FllowPlayer();
        if(hurtCounter <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
        } else
        {
            hurtCounter -= Time.deltaTime;
        }
    }

    private void FllowPlayer()
    {
        //敌人当前坐标 目标位置坐标信息 最大距离 = 速度 * 时间
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); 
    }

    public void TakenDamage(float _amount)
    {
        IsAttacked = true;
        hp -= _amount;
        StartCoroutine(IsAttack()); //使用协程进行对攻击判定的检测，保证只进行一次攻击
        HurtShaker();
        if (hp <= 0)
        {
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void HurtShaker()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }

    IEnumerator IsAttack()
    {
        yield return new WaitForSeconds(0.2f);
        IsAttacked = false;
    }
}
