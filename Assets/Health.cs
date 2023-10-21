using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

}
