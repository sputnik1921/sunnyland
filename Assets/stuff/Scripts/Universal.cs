using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal : MonoBehaviour
{
    public void fly(GameObject ai,GameObject target, float speed)
    {
        Vector3 dir = target.transform.position-ai.transform.position;
        if(Mathf.Abs(dir.magnitude) < 70f)
        {
            
        }
        dir = dir.normalized;
        Vector3 pos = ai.transform.position;
        pos += dir * speed * Time.deltaTime;
        pos.z = 0;
        ai.transform.position = pos;

    }
}
