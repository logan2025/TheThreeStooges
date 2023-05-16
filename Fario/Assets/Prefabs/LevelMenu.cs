using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool menuOn = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOn)
        {
            pauseMenu.SetActive(true);
            menuOn = true;
            Pause();
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
        menuOn = false;

    }
}
