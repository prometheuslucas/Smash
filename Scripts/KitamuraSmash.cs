using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitamuraSmash : MonoBehaviour
{

    // Use this for initialization
    private float timeBtwSmash;
    public float starttimeBtwSmash;

    public Transform attackPos1;
    public Transform attackPos2;
    public float attackRange;
    public float damage;
	public float dmgmultiplier;
    public LayerMask everythingIsPatriarchy;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool airborne = GetComponent<KitamuraController>().GetAirborne();
        if (timeBtwSmash <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                timeBtwSmash = starttimeBtwSmash;
                if (airborne)
                {
                    Collider2D[] patriarchyToSmash = Physics2D.OverlapCircleAll(attackPos2.position, attackRange, everythingIsPatriarchy);
                    for (int i = 0; i < patriarchyToSmash.Length; i++)
                    {
                        patriarchyToSmash[i].GetComponent<Patriarchy>().hp -= damage*dmgmultiplier;
                        Debug.Log(patriarchyToSmash[i].GetComponent<Patriarchy>().hp);
                    }

                }
                else
                {
                    Collider2D[] patriarchyToSmash = Physics2D.OverlapCircleAll(attackPos1.position, attackRange, everythingIsPatriarchy);
                    for (int i = 0; i < patriarchyToSmash.Length; i++)
                    {
                        patriarchyToSmash[i].GetComponent<Patriarchy>().hp -= damage;
                        Debug.Log(patriarchyToSmash[i].GetComponent<Patriarchy>().hp);
                    }
                }
            }
        }
        else
        {
            timeBtwSmash -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos1.position, attackRange);
		Gizmos.DrawWireSphere(attackPos2.position, attackRange);
    }
}
