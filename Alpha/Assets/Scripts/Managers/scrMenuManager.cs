using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMenuManager : MonoBehaviour
{
    public void NextScene(string cena) 
    {
        SceneManager.LoadScene(cena);
    }
}
