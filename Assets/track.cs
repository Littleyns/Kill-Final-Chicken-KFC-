using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class track : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Référence vers le composant 'text' de notre 
        player = GameObject.Find("[ PLAYER SIMPLE ]");
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
    }
}

