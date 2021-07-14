using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        name = Data.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        Data.Instance.playerName = name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Data.Instance.SaveScore();
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
