using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fend : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        
        {
            CompleteLevel(); 
        }
        
    }

    private void CompleteLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
