using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float maxHealthPoints;
    public float startingHealthPoints;

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(int damage, float interval);


    // Start is called before the first frame update
    
}
