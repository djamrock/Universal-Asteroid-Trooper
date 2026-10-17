//using UnityEngine;

//public class DeathAnimation : Death
//{

//    public Animator animator;

//    public Obstacle obstacleToRemoveOnDeath;

//    public override void Die()
//    {
//        if (GameManager.instance != null)
//        {
//            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null)
//            {
//                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
//            }
//        }

//        animator.SetTrigger("Explode");
//    }

//    public override void Start()
//    {
//        animator = GetComponent<Animator>();
//        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
//    }

//    public override void Update()
//    {

//    }

//    public void DestroyAsteroid()
//    {
//        Destroy(gameObject);
//    }
//}