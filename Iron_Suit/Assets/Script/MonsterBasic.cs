using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBasic : MonoBehaviour
{
    PlayerController player;
    CircleCollider2D colliderMonster;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    private bool CanMove;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        colliderMonster = GetComponentInChildren<"Range">
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Move();
            return;
        }
        Attack();
    }

    public virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    public virtual void Attack()
    {
        float cooltime = attackSpeed;
        cooltime -= Time.deltaTime;
        if(cooltime <= 0)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanMove = false;
        }
    }
}
