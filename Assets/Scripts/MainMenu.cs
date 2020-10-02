using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int playerone, playertwo;
    public void mochione()
    {
        Character.Singleton.setCharacter(0);
    }
    public void mochitwo()
    {
        Character2.Singleton.setCharacter(0);
    }
    public void mochaone()
    {
        Character.Singleton.setCharacter(1);
    }
    public void mochatwo()
    {
        Character2.Singleton.setCharacter(1);
    }
    public void matchaone()
    {
        Character2.Singleton.setCharacter(2);
    }
    public void matchatwo()
    {
        Character2.Singleton.setCharacter(2);
    }

 
    public void playMap1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void playMap2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void playMap3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void MapSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void CharacterSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
