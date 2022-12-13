
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Rigidbody2D _rb;//private float Cam_speed = 6;
    [SerializeField] private GameObject _target;
    [Range(1, 10)] public float smoothFactor;
    public Vector3 minValues, maxValues;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        
        Vector3 pos = _target.transform.position;
        pos.z = -10;
        pos.y += 2;
        Vector3 smoothedPos = Vector3.Lerp(this.transform.position,pos,smoothFactor*Time.fixedDeltaTime);
        this.transform.position = smoothedPos;
    }
}
