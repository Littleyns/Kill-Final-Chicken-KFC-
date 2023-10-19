using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
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
        foreach (ContactPoint contact in collision.contacts)
        {
            // Obtenez le GameObject de contact
            GameObject otherObject = contact.otherCollider.gameObject;
            
            // Faites quelque chose avec l'autre objet
            Debug.Log("Collision avec : " + otherObject.name);

            if(otherObject.name == "mixamorig:LeftShoulder"){
                
            }
        }
    }
    
}
