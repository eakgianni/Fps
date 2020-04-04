
using UnityEngine;

public class Target : MonoBehaviour
{
    public float hp = 50f;

    public void TakeDamage(float ammount)
    {
        hp -= ammount;

        if (hp <= 0f)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
