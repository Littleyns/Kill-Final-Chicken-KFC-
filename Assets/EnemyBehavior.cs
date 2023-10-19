using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Animator animator;
    public bool isDead = false;
    private GameObject player;
    private bool isPlayerClose = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("[ PLAYER SIMPLE ]");
    }

    // Update is called once per frame
    void Update()
    {
        //Atack 1 
        //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        /*if(Vector3.Distance(this.transform.position, player.transform.position) < 0.9f){
            //Debug.Log("Attack trigered");
            animator.SetBool("beginAttack", true);
            isPlayerClose = true;
        }else
            isPlayerClose = false;*/
    }

     private void OnCollisionEnter(Collision collision)
    {
        
        // Boucle à travers tous les contacts de la collision
        foreach (ContactPoint contact in collision.contacts)
        {
            // Obtenez le GameObject de contact
            GameObject otherObject = contact.otherCollider.gameObject;
            
            // Faites quelque chose avec l'autre objet
            //Debug.Log("Collision avec : " + otherObject.name);

            // Animation balle
            if(otherObject.name == "Bullet(Clone)"){
                animator.SetBool("bulletBehavior", true);
            }

            //Attack 2 
            if(otherObject.name == "[ PLAYER SIMPLE ]"){
                //Debug.Log("Attack trigered");
                animator.SetBool("beginAttack", true);
                isPlayerClose = true;
            }else
                isPlayerClose = false;
            }

    }

    public void EndBulletBehavior(){
        animator.SetBool("bulletBehavior", false);
    }

    public void IsAttackEnd(){
        if(isPlayerClose){
            //Debug.Log("Close");
            animator.SetBool("LoopAttack", true);
        }
            //Debug.Log("Not close");
    }
}
