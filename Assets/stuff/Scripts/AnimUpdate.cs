using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = Player_fox.PlayerState;


public class AnimUpdate : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateAnim(PlayerState playerState)
    {
        for(int i = 0; i <= (int)PlayerState.HURT; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if(playerState == (PlayerState)i)
            {
                anim.SetBool(stateName, true);
            }
            else anim.SetBool(stateName, false);
        }
    }
}
