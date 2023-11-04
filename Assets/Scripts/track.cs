using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

[RequireComponent(typeof(Animator))]
public class track : MonoBehaviour
{

    private GameObject player;
    public float currentTime;
    public float delay;
    public float initPosX, initPosZ;
    public Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        
        delay = 1;
        currentTime = 0;
        // Référence vers le composant 'text' de notre 
        player = GameObject.Find("[ PLAYER SIMPLE ]");

        initPosX = this.transform.position.x;
        initPosZ = this.transform.position.z; 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        pos = new Vector3 (Random.Range(initPosX - 1, initPosX + 5 ), 0, Random.Range(initPosZ - 5, initPosZ + 10));

        if(Vector3.Distance(this.transform.position, player.transform.position) < 10f)
        {
            this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
        }
        else
        {
            if (currentTime > delay)
            {
                if(this.transform.position.y >= player.transform.position.y)
                //Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), pos, Quaternion.identity);
                this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(pos);
                currentTime = 0;
            }
        }
        
        
    }
}

