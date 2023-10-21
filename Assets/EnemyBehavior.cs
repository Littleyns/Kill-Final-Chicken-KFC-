using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    private Animator animator;
    public bool isDead = false;
    private GameObject player;
    private bool isPlayerClose = false;
    public Health enemyHealth;
    public Score points;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("[ PLAYER SIMPLE ]");
        enemyHealth = new Health();
        points = new Score();
        animator.SetBool("EnemyDeath", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Atack 1 
        //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        if(Vector3.Distance(this.transform.position, player.transform.position) < 0.9f){

            //Attack 2 
                //Debug.Log("Attack trigered");
                animator.SetBool("beginAttack", true);
                isPlayerClose = true;
            
        }
        else
            animator.SetBool("beginAttack", false);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Falling Back Death") && stateInfo.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);

            // Update score when player kill enemy
            points.UpdateScore();
        }

    }

     private void OnCollisionEnter(Collision collision)
    {
        
        // Boucle à travers tous les contacts de la collision
        foreach (ContactPoint contact in collision.contacts)
        {
            // Obtenez le GameObject de contact
            GameObject otherObject = contact.otherCollider.gameObject;
            
            // Faites quelque chose avec l'autre objet
            //Debug.Log("ENEMY Collision avec : " + otherObject.name);

            // Animation balle
            if(otherObject.name == "Bullet(Clone)"){
                animator.SetBool("bulletBehavior", true);

                // Dimunuer la vie
                enemyHealth.TakeDamage(10);
            }
            if (otherObject.name == "[ PLAYER SIMPLE ]")
            {

                player.GetComponent<ThirdPersonController>().Health -= 5;
                Debug.Log(player.GetComponent<ThirdPersonController>().Health);
            }
        }
        if (enemyHealth.health == 0)
        {
            animator.SetBool("beginAttack", false);
            animator.SetBool("EnemyDeath", true);
            Debug.Log("Enemy health : " + enemyHealth.health.ToString());
        }


    }

    private void OnCollisionExit(Collision collision)
    {

    }

    public void EndBulletBehavior(){
        animator.SetBool("bulletBehavior", false);
        animator.SetBool("beginAttack", false);
    }

    public void IsAttackEnd(){
        if(!isPlayerClose){
            animator.SetBool("beginAttack", false);
            //Debug.Log(isPlayerClose);
        }
            //Debug.Log("Not close");*/
    }


}
