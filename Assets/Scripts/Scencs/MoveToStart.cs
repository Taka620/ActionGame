using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToStart : MonoBehaviour
{
    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }

}
