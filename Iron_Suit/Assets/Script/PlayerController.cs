using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    None,
    Move,
    Skill1,
    Skill2
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbodyPlayer;
    public GameObject missile;
    [SerializeField] private float speed;
    [SerializeField] private float skill1Cooltime;
    [SerializeField] private float skill2Cooltime;
    private bool skill1Able = true;
    private bool skill2Able = true;
    public Vector2 Direction { get => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); }
    protected Stat stat = Stat.None;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && skill1Able)
        {
            skill1Able = false;
            Skill1();
            stat = Stat.Skill1;
            Invoke("InitSkill1", skill1Cooltime);
        }
        if (Input.GetKeyDown(KeyCode.E) && skill2Able)
        {
            skill2Able = false;
            Skill2();
            stat = Stat.Skill2;
            Invoke("InitSkill2", skill2Cooltime);
        }
        if (stat == Stat.None || stat == Stat.Move)
        {
            if (Direction != Vector2.zero) Move();
            else stat = Stat.None;
        }
    }

    public virtual void Move()
    {
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + Direction * speed * Time.deltaTime);
        stat = Stat.Move;
    }

    private void InitSkill1()
    {
        skill1Able = true;
    }

    private void InitSkill2()
    {
        skill2Able = true;
    }

    protected virtual void Skill1()
    {
        Instantiate(missile, this.transform.position, transform.rotation);
        Destroy(missile, 3.0f);
        stat = Stat.None;
    }

    protected virtual void Skill2()
    {

    }
}
