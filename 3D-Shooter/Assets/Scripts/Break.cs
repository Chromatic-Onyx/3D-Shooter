using UnityEngine;

public class Break : MonoBehaviour
{
    private float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f) 
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
