using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 10;

    public int Damage
    {
        get
        {
            return damage;
        }
    }


    public void Hit()
    {
        Destroy(gameObject);
    }

}
