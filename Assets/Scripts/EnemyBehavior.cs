using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyBehavior : MonoBehaviour
{

    private Animator animator;
    public bool isDead = false;
    private GameObject player;
    private bool isPlayerClose = false;
    public Health enemyHealth;
    public Score points;
    public PlayerManager pm;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        player = GameObject.Find("[ PLAYER SIMPLE ]");
        enemyHealth = gameObject.AddComponent<Health>();
        points = gameObject.AddComponent<Score>();
        animator.SetBool("EnemyDeath", false);
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Atack 1 
        //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        if (Vector3.Distance(this.transform.position, player.transform.position) < 1f)
        {

            //Attack 2 
            //Debug.Log("Attack trigered");
            
            if (enemyHealth.health > 0)
            {
                animator.SetBool("beginAttack", true);
                isPlayerClose = true;
            }

        }
        else
            animator.SetBool("beginAttack", false);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Falling Back Death") && stateInfo.normalizedTime >= 1.0f)
        {
            animator.speed = 1;
            Destroy(this.gameObject);

            // Update score when player kill enemy
            //points.UpdateScore();
            pm.coins += 200;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Animation balle
        if (collision.collider.name == "Bullet(Clone)")
        {
            animator.SetBool("bulletBehavior", true);

            //changement de couleur
            this.transform.Find("EnemyDamageMesh").gameObject.SetActive(true);
            // Dimunuer la vie
            enemyHealth.TakeDamage(10);

            if (enemyHealth.health == 0)
            {
                animator.SetBool("beginAttack", false);
                animator.SetBool("EnemyDeath", true);
                //Debug.Log("Enemy health : " + enemyHealth.health.ToString());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    public void EndBulletBehavior()
    {
        animator.SetBool("bulletBehavior", false);
        animator.SetBool("beginAttack", false);
        this.transform.Find("EnemyDamageMesh").gameObject.SetActive(false);
    }

    public void nomove()
    {

    }

    public void IsAttackEnd()
    {
        if (!isPlayerClose)
        {
            animator.SetBool("beginAttack", false);
            //Debug.Log(isPlayerClose);
        }
        //Debug.Log("Not close");*/
    }


}
