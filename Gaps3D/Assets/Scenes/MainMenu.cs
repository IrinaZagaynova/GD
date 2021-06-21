using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Lvl11()
    {
        SceneManager.LoadScene(2);
    }
	
	public void Lvl12()
    {
        SceneManager.LoadScene(3);
    }
	
	public void Lvl13()
    {
        SceneManager.LoadScene(4);
    }


	public void Lvl14()
    {
        SceneManager.LoadScene(5);
    }


	public void Lvl21()
    {
        SceneManager.LoadScene(6);
    }

	public void Lvl22()
    {
        SceneManager.LoadScene(7);
    }
	
	public void Lvl23()
    {
        SceneManager.LoadScene(8);
    }
	
	public void Home()
    {
        SceneManager.LoadScene(0);
    }
	
	public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
