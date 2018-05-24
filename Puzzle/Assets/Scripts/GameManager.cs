using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public FrozyController frozy;

    public SparkyController sparky;

    private GameObject cameraFrozy;

    private GameObject cameraSparky;

    public ExtraCam extraCam;

    public bool cameraFrozyOn;

    public bool cameraSparkyOn;

    private Vector3 sparkyPos;

    private Vector3 frozyPos;

    public bool pause;

    public GameObject pausePanel;

    private bool isPauseMusic = true;

    private void Start ()
    {
        sparky = GameObject.FindGameObjectWithTag("Sparky").GetComponent<SparkyController>();
        frozy = GameObject.FindGameObjectWithTag("Frozy").GetComponent<FrozyController>();

        cameraFrozy = GameObject.FindGameObjectWithTag("CameraFrozy");
        cameraSparky = GameObject.FindGameObjectWithTag("CameraSparky");
        extraCam = GameObject.FindGameObjectWithTag("ExtraCam").GetComponent<ExtraCam>();

        sparky.enabled = false;
        frozy.enabled = true;

        cameraFrozyOn = true;
        cameraSparkyOn = false;

        if (SceneManager.GetActiveScene().name == "Intro")
        {
            frozy.invertZ = true;
            sparky.invertZ = true;
        }
        StartMusicScene();
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if (pause)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);

            if(isPauseMusic)
            {
                FindObjectOfType<AudioManager>().Play("Pause");
                StopMusicScene();
                isPauseMusic = false;
            }
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);

            if(!isPauseMusic)
            {
                FindObjectOfType<AudioManager>().Stop("Pause");
                StartMusicScene();
                isPauseMusic = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Tab))
        {
            if(cameraFrozyOn && frozy.controller.isGrounded || cameraSparkyOn && sparky.controller.isGrounded)
            {
                ChangeCharacter();
            }
        }

        if(extraCam.frozyIn && extraCam.sparkyIn)
        {
            extraCam.extraCamActive = true;
        }
        else
        {
            if (extraCam.frozyIn && cameraFrozyOn)
            {
                cameraFrozy.SetActive(false);
                extraCam.extraCamActive = cameraFrozyOn;

                return;
            }
            else
            {
                extraCam.extraCamActive = false;

                cameraFrozy.SetActive(cameraFrozyOn);

            }

            if (extraCam.sparkyIn && cameraSparkyOn)
            {
                cameraSparky.SetActive(false);
                extraCam.extraCamActive = cameraSparkyOn;

                return;
            }
            else
            {
                extraCam.extraCamActive = false;

                cameraSparky.SetActive(cameraSparkyOn);
            }
        }
    }

    private void ChangeCharacter()
    {
        Debug.Log("CHANGE");

        cameraSparkyOn = !cameraSparkyOn;
        cameraFrozyOn = !cameraFrozyOn;
        
        if (cameraSparkyOn)
        {
            frozy.anim.SetBool("isRunning", false);
            frozy.anim.SetBool("isIdle", true);
        }
        if(cameraFrozyOn)
        {
            sparky.anim.SetBool("isRunning", false);
            sparky.anim.SetBool("isIdle", true);
        }

        sparky.enabled = !sparky.enabled;
        frozy.enabled = !frozy.enabled;
    }

    private void StartMusicScene()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            FindObjectOfType<AudioManager>().Play("Intro");
        }

        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
            FindObjectOfType<AudioManager>().Play("Lvl1");
        }

        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            FindObjectOfType<AudioManager>().Play("Intro");
        }
    }

    private void StopMusicScene()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            FindObjectOfType<AudioManager>().Stop("Intro");
        }

        if (SceneManager.GetActiveScene().name == "Lvl1")
        {
            FindObjectOfType<AudioManager>().Stop("Lvl1");
        }

        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            FindObjectOfType<AudioManager>().Stop("Intro");
        }
    }
}