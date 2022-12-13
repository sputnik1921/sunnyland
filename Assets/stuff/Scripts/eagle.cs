using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject self;
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        flip();
    }
    void movement()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        if (Mathf.Abs(dir.sqrMagnitude) < 70)
        {
            dir = dir.normalized;
            this.transform.position += dir * speed * Time.deltaTime;
        }
    }
    void flip()
    {
        int x = 1;
        if (this.transform.position.x > target.transform.position.x)
        {
            x = 1;
        }
        else if (this.transform.position.x < target.transform.position.x)
        {
            x = -1;
        }
        this.transform.localScale = new Vector3(x, 1, 1);
    }
}
