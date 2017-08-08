using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class StartScreen : MonoBehaviour {

    AudioSource swap;

	// Use this for initialization
	void Start () {

        //DontDestroyOnLoad(gameObject);
        swap = gameObject.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LoadLvl1Regular()
    {
        SceneManager.LoadScene("Lvl1Regular");
        swap.Play();
    }
    public void LoadLvl1TimeTrial()
    {
        SceneManager.LoadScene("Lvl1TimeTrial");
        swap.Play();

    }
    public void LoadLvl2Regular()
    {
        SceneManager.LoadScene("Lvl2Regular");
        swap.Play();

    }
    public void LoadLvl2TimeTrial()
    {
        SceneManager.LoadScene("Lvl2TimeTrial");
        swap.Play();

    }
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
        swap.Play();

    }
    public void LoadRegularLevels()
    {
        SceneManager.LoadScene("RegularLevels");
        swap.Play();

    }
    public void LoadTimeTrialLevels()
    {
        SceneManager.LoadScene("TimeTrialLevels");
        swap.Play();

    }
}