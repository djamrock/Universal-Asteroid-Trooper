using UnityEngine;


//abstract class used to specify a behavior for dieing

public abstract class Death : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void Die();

}
