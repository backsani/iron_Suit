using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterBasic : MonoBehaviour
{
    PlayerController player;
    CircleCollider2D attackCollider;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    private bool CanMove = true;
    private bool CanAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        Transform childTransform = transform.Find("Range");
        attackCollider = childTransform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove) Move();
        else if (CanAttack) Attack();

    }

    public virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    public virtual void Attack()
    {
        float cooltime = attackSpeed;
        if (CanAttack)
        {
            Debug.Log("공격중");            
            cooltime -= Time.deltaTime;
            if (cooltime <= 0)
            {
                attackCollider.enabled = true;
                Debug.Log("공격");
            }
            else if(cooltime <= -1)
            {
                Debug.Log("공격끝");
                CanAttack = false;
                attackCollider.enabled = true;
            }
        }
        else CanMove = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("충돌");
            CanMove = false;
            CanAttack = true;
        }
    }
}
