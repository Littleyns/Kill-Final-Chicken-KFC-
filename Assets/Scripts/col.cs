using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class col : MonoBehaviour
{
    public GameObject enemy;
    public GameObject boss;
    public GameObject room;
    private Animator animator;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Resources.Load("Enemy1") as GameObject;
        boss = Resources.Load("Boss") as GameObject;
        room = GameObject.Find("Room1");
        animator = enemy.GetComponent<Animator>();
        gameManager = GameObject.FindWithTag("Map").GetComponent<GameManager>();
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
            
            //Debug.Log("Collision avec : " + otherObject.name);

            if (otherObject.name == "Floor_B" && GameObject.FindWithTag("Enemy") == null)
            {
                GameObject roomParent = otherObject.transform.parent.gameObject.transform.parent.gameObject;
                for (int x = 0; x < 3 + gameManager.Difficulty; x++)
                {
                    float posX = -8 + (x * 29);
                    for (int z = 0; z < 3 + gameManager.Difficulty; z++)
                    {
                        float posZ = 165 + (z * 29);
                        if (x == 3 + gameManager.Difficulty - 1 && z == 3 + gameManager.Difficulty - 1)
                        {
                            Instantiate(boss, new Vector3(posX, 1f, posZ), Quaternion.identity);
                        }
                        else
                        {
                            for (int i = 0; i < 4 + gameManager.Difficulty; i++)
                            {

                                Instantiate(enemy, new Vector3(posX, 0.5f, posZ), Quaternion.identity);
                            }
                            
                        }
                        
                    }
                }
                roomParent.AddComponent<NavMeshSurface>();
                roomParent.GetComponent<NavMeshSurface>().BuildNavMesh();
            }
            if (otherObject.CompareTag("EnemyAttackHand"))
                this.GetComponent<ThirdPersonController>().Health -= 5;

            if (otherObject.CompareTag("BossAttackHand"))
                this.GetComponent<ThirdPersonController>().Health -= 10;
        }
    }

    private void OnCollisionExit(Collision other)
    {

    }


}
