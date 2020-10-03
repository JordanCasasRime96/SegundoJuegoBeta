using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void Change(int Map1)
    {
        SceneManager.LoadScene(Map1);
    }

}
