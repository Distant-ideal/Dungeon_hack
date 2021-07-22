using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
    [SerializeField] private float minDamage, maxDamage;
    private float AttackDamage;
    

    public GameObject damageCanvas;

    public void EndAttack()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Debug.Log("1");
            AttackDamage = Random.Range(minDamage, maxDamage);
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (!enemy.IsAttacked)
            {
                //other.gameObject.GetComponent<Enemy>().TakenDamage(AttackDamage);
                enemy.TakenDamage(AttackDamage);
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>();
                damagable.ShowUIDamage(Mathf.RoundToInt(AttackDamage));

                #region 击退效果 反向移动 从角色中心店【当前位置】向敌人位置方向【目标点】移动
                Vector2 difference = other.transform.position - transform.position;
                other.transform.position = new Vector2(other.transform.position.x + difference.x, other.transform.position.y + difference.y);
                #endregion
            }

        }
    } 
}
