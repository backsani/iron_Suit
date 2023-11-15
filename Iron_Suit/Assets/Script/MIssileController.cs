using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIssileController : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explosion", 2.9f);
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity =  Vector3.forward * speed * Time.deltaTime;
    }

    private void Explosion()
    {
        
    }
}
