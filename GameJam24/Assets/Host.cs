using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Host : MonoBehaviour
{
    public bool isPantsObtained = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPantsObtained)
            {
                SceneManager.LoadScene(2);
            }
            
        }
    }
    public void pantsObtained()
    {
        isPantsObtained=true;
    }
}
