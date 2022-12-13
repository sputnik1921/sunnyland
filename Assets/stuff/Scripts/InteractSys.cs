using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractSys : MonoBehaviour
{
    public Transform _detectionPoint;
    private const float _detectionRadius=0.2f;
    public LayerMask _detectionLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                
            }
        }
        
    }
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    bool DetectObject()
    {
        return Physics2D.OverlapCircle(_detectionPoint.position, _detectionRadius, _detectionLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_detectionPoint.position, _detectionRadius);
    }
}
