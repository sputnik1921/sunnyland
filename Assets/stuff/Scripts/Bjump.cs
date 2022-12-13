using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bjump : MonoBehaviour
{
    public float fallMult = 2.5f;
    public float lowMult = 2f;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1)*Time.deltaTime;
            
            
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMult - 1) * Time.deltaTime;
            
        }
    }
}
