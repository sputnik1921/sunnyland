using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Next(int i)
    {
        switch (i)
        {
            case 2:
                SceneManager.LoadScene("Lv2");
                break;
            case 3:
                SceneManager.LoadScene("End");
                break;
        }
    }

    public void back2main()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
