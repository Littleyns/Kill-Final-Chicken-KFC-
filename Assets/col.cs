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
            Debug.Log("Collision avec : " + otherObject.name);

            if (otherObject.name == "Floor_B" && GameObject.FindWithTag("Enemy") == null)
            {
                Instantiate(enemy, new Vector3(50f, 0, 170f), Quaternion.identity);
                roomParent.AddComponent<NavMeshSurface>();
                roomParent.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
            if (otherObject.name == "mixamorig:RightHand" || otherObject.name == "mixamorig:RightForeArm")
            {

                this.GetComponent<ThirdPersonController>().Health -= 1;
                Debug.Log(this.GetComponent<ThirdPersonController>().Health);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {

    }


}
