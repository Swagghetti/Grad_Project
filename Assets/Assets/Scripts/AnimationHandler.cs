using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject warrior;
    public GameObject elena;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WarriorReturn()
    {
        warrior.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
    }

    private void DieAndFinish()
    {
        Time.timeScale = 0;
    }

    private void ElenaReturn()
    {
        elena.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
    }
}
