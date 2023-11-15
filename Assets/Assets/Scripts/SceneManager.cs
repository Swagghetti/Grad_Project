using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    [SerializeField] private Button loginButton, signupButton;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Login()
    {

        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
        //loginButton.onClick.AddListener(() => { UnityEngine.SceneManagement.SceneManager.LoadScene(1); });
        //SceneManager.LoadScene("Login");
        //SceneManager.LoadScene(2);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

/*
    public void Signup()
    {
        //signupButton.onClick.AddListener(() => { UnityEngine.SceneManagement.SceneManager.LoadScene(2); });
        //SceneManager.LoadScene("Signup");
        //SceneManager.LoadScene(3);

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
*/

    public void Combat()
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
