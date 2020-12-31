using UnityEngine;

public class EnemyC2 : Enemy2
{
    public LayerMask targetLayer;
    public float radius;
    public float bombForce;

    public override void GetHit(float damage)
    {
        InvokeRepeating("Explotion", 2, 0);

        base.GetHit(damage);
    }

    public void CanntSee()
    {
        
        gameObject.layer = LayerMask.NameToLayer("EnemyC");
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Explotion()
    {
        anim.SetBool("explotion", true);

        Collider2D[] aroundObjects = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        rig.gravityScale = 0;

        foreach (var item in aroundObjects)
        {
            PlayerController2 player = GetComponent<PlayerController2>();

            Vector3 pos = transform.position - item.transform.position;

            item.GetComponent<Rigidbody2D>().AddForce((-pos + Vector3.up) * bombForce, ForceMode2D.Impulse);

            if (item.CompareTag("Player"))
            {
                item.GetComponent<Idamage2>().GetHit(1f);
            }

        }
    }
}
