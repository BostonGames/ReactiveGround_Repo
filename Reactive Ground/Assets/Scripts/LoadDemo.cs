using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDemo : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadDemoScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadDemoScene_ObjectTrail()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadDemoScene_GroundTrailOnly()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadDemoScene_Visited()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadDemoScene_ReVisited()
    {
        SceneManager.LoadScene(5);
    }
}
