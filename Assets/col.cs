using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class col : MonoBehaviour
{
    public GameObject enemy;
    public GameObject room;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load("Enemy1") as GameObject;
        room = GameObject.Find("Room1");
        animator = enemy.GetComponent<Animator>();
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
            GameObject roomParent = otherObject.transform.parent.gameObject.transform.parent.gameObject;
            //Debug.Log("Collision avec : " + otherObject.transform.parent.gameObject.transform.parent.gameObject);

            if(otherObject.name == "Floor_B (8)" && !GameObject.Find("Enemy1 (clone)"))
            {
                Instantiate(enemy, new Vector3(50, 0, 170), Quaternion.identity);
                roomParent.AddComponent<NavMeshSurface>();
                roomParent.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {

    }


}
