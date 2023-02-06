using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerrespawn : MonoBehaviour
{
    public Animator animator;
    public void playerdamage()
    {
        animator.Play("hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
