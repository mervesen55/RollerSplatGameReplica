using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;   
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }
    void OnCollisionEnter(Collision collision)
        {
        
            if (collision.collider.tag == "ground")
            {
                collision.transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                GameManager.instance.uncoloredTiles -= 1;
                Debug.Log(GameManager.instance.uncoloredTiles);
                collision.collider.tag = "coloredTiles";
            if (GameManager.instance.uncoloredTiles == 0)
                GameManager.instance.setLevel();
            }
        }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

           
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

           
            currentSwipe.Normalize();

            
            if (currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("up swipe");
                rb.velocity = new Vector3(0, 0, 200);
               
            }
            
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("down swipe");
                rb.velocity = new Vector3(0, 0, -200);
                
               
            }
            
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                Debug.Log("left swipe");
                rb.velocity = new Vector3(-200, 0, 0);
                
            }
          
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f)
        {
                
                rb.velocity = new Vector3(200, 0, 0);
                
            }
        }
    }

 

 
}
