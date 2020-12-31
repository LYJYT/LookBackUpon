using UnityEngine;

public class EnemyA2 : Enemy2
{

    public override void GetHit(float damage)
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyDeadFall");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        base.GetHit(damage);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

}
