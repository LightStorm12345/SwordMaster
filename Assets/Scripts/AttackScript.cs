using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator animator;
    private bool AllowAttack;
    public GameObject player;

    public bool isSword;
    public bool isShuriken;

    private bool throwShuriken = false;
    private Vector3 positionToMoveTo;

    private void Start()
    {
        player = GameObject.Find("character");
        AllowAttack = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    private void Update()
    {

        if (isSword)
        {
            // when left mouse button is pressed and the animation is complete then run the attack animation
            if (Input.GetKeyDown(KeyCode.Mouse0) && AllowAttack == true)
            {
                StartCoroutine(SwordAttack());
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && AllowAttack == true)
            {
                StartCoroutine(SwordSpin());
            }
        }

        if (isShuriken)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && AllowAttack == true)
            {
                

                //positionToMoveTo = gameObject.transform.up * 10f; replaced in favour of moving the shuriken towards the mouse

                gameObject.GetComponent<Collider2D>().enabled = true;
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                positionToMoveTo = mousePosition;

                // animator.SetBool("shurikenThrown", true);
                throwShuriken = true;
                AllowAttack = false;
            }
        }

        // this section is dedicated to things that need the update function
        if (throwShuriken)
        {
            gameObject.transform.SetParent(null);
            ThrowShuriken();
        }
    }

    private void ThrowShuriken()
    {
        float lerpSpeed = 1f;
        float destroySafeThreshold = 0.3f;
        float rotateSpeed = 500.0f;

        gameObject.transform.Rotate(new Vector3(0f, 0f, 90), rotateSpeed * Time.deltaTime);

        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, positionToMoveTo, lerpSpeed * 3.0f * Time.deltaTime);

        if (Vector2.Distance(gameObject.transform.position, positionToMoveTo) <= destroySafeThreshold)
        {
            Destroy(gameObject);
            FindObjectOfType<inventorySystem>().SpawnItem();
        }
    }

    public void DestroyThrowable()
    {
        Destroy(gameObject);
        FindObjectOfType<inventorySystem>().SpawnItem();
    }



    // this is just for referance, this is not needed as of now
    // Description:
    // this is a function that can be called in the animator, the interted string will be read
    // and code can be excecuted based on that string

    /*public void AlertObserver(string message)
    {
        if (message.Equals("SpearAnimationComplete"))
        {

        }
    }*/


    

    // UPDATE THIS SCRIPT TO WORK WITH animation.isPlaying()
    private IEnumerator SwordAttack()
    {
        // run the attack animation and wait for 0.8 seconds before allowing the user to use it again

        AllowAttack = false;

        gameObject.GetComponent<Collider2D>().enabled = true;

        animator.SetBool("SwordAttack", true);

        yield return new WaitForSeconds(0.8f);

        //print(animator.GetCurrentAnimatorStateInfo(0).tagHash);
        
        animator.SetBool("SwordAttack", false);


        animator.SetBool("SwordAttack", false);

        gameObject.GetComponent<Collider2D>().enabled = false;

        AllowAttack = true;
    }
    private IEnumerator SwordSpin()
    {
        AllowAttack = false;

        player.GetComponent<playerscript>().currSprite = 1;

        gameObject.GetComponent<Collider2D>().enabled = true;

        animator.SetBool("SwordSpin", true);

        yield return new WaitForSeconds(2f);

        animator.SetBool("SwordSpin", false);

        gameObject.GetComponent<Collider2D>().enabled = false;

        player.GetComponent<playerscript>().currSprite = 0;

        AllowAttack = true;
    }
}
