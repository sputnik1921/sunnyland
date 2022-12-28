using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;
using System;

public class Player_fox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float p_force = 11.0f;
    Rigidbody2D _rb;
    protected Animator animator;
    public Transform groundCheckTransform;
    private bool isGrounded;
    public LayerMask groundCheckLayerMask;
    //[SerializeField] BoxCollider2D _colli;
    [SerializeField] PlayerState _playerState = PlayerState.IDLE;
    [SerializeField] AnimUpdate _anim;
    public static int point = 0;
    public static int max_hp = 2;
    public static int hp = 2;
    public static int gem = 0;
    [SerializeField] private Text pointText;
    [SerializeField] float hurtForce = 10f;
    [SerializeField] Text HP;
    [SerializeField] Text _hp;

    public static int index = 1;
    public static int s;

    bool isHurt = false;
    public GameObject FX;
    

    public Text iText;

    public AudioSource Hurt;
    public AudioSource Collect;



    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        //_colli = this.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        
        HPUpdate();
        pointUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerState != PlayerState.HURT)
        {
            movement();
        }
        UpdateGroundedStatus();
        UpdateState();
        _anim.UpdateAnim(_playerState);
        //Debug.Log(_playerState);
        pointUpdate();
        HPUpdate();
        deadcheck();

        quit();
    }
    void quit()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            FindObjectOfType<LevelManager>().back2main();
        }
    }
    void movement()
    {
        float Move = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(Move * speed, _rb.velocity.y);
        if (Move < 0) this.transform.localScale = new Vector3(-1, 1, 1);
        else if (Move > 0) this.transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(Vector2.up * p_force, ForceMode2D.Impulse);
        }
       
    }
    

    void UpdateGroundedStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.2f, groundCheckLayerMask);
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheckTransform.position, 0.2f);
    }
    void UpdateState()
    {
        if (isHurt)
        {
            _playerState = PlayerState.HURT;
        }
        
        else if (!isGrounded)
        {
            if (_rb.velocity.y > 0) _playerState = PlayerState.JUMP;
            else _playerState = PlayerState.FALL;
        }
        else
        {
            if (_rb.velocity.x != 0)
            {
                _playerState = PlayerState.RUN;
            }
            else _playerState = PlayerState.IDLE;
        }
        
    }

    public enum PlayerState
    {
        IDLE,
        RUN,
        JUMP,
        FALL,
        HURT
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            point += 1;
            fxSetup();
        }
        if (collision.tag == "HP")
        {
            Destroy(collision.gameObject);
            gem += 1;
            HPModifier();
            fxSetup();
        }
        if(collision.tag == "Objective")
        {
            index += 1;
            s = index;
            FindObjectOfType<LevelManager>().Next(index);
            
        }

    }
    void fxSetup()
    {
        GameObject fx =Instantiate(FX, this.transform.position, Quaternion.identity);
        Collect.Play();
        Destroy(fx, 1f);
        
    }
    void HPModifier()
    {
        if (gem == 2)
        {
            gem =0;
            hp += 1;
            max_hp += 1;
        }
    }
    void HPUpdate()
    {
        HP.text = String.Format("HP:    {0}", hp);
        _hp.text = String.Format("GEMS:  {0}", gem);
    }
    void pointUpdate()
    {
        pointText.text = string.Format("POINTS:   {0}", point);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (_playerState == PlayerState.FALL)
            {
                Destroy(collision.gameObject);
                _rb.AddForce(Vector2.up * p_force, ForceMode2D.Impulse);
                point += 5;
                Collect.Play();
            }
            else
            {
                hp--;
                isHurt = true;
                _rb.velocity = Vector2.zero;
                _rb.inertia = 0;
                if (collision.gameObject.transform.position.x < this.transform.position.x)
                {
                    _rb.AddForce(Vector2.right * hurtForce, ForceMode2D.Impulse);
                }
                else if (collision.gameObject.transform.position.x > this.transform.position.x)
                {
                    _rb.AddForce(Vector2.left * hurtForce, ForceMode2D.Impulse);
                    
                }
                StartCoroutine(SetHurt());
                Hurt.Play();
            }
        }
        if (collision.gameObject.tag == "barrier")
        {
            hp -= hp;
        }
    }
    void deadcheck()
    {
        if (hp <= 0)
        {
            FindObjectOfType<LevelManager>().Restart();
            hp = max_hp;
            index = s;
        }
    }
    private IEnumerator SetHurt()
    {
        yield return new WaitForSeconds(0.5f);
        _rb.velocity = Vector2.zero;
        isHurt = false;
    }
}
