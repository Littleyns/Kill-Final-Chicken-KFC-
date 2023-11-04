using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;
    private ProgressBarPro pb;

    private void Start()
    {
        pb = this.transform.Find("HorizontalBoxGradient").gameObject.GetComponent<ProgressBarPro>() as ProgressBarPro;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        pb.SetValue(health / 100);
    }

}
