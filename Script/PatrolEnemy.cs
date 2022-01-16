using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingLeft){

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);            
            if(transform.position.x > leftEdge)
            {
                run();
                
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                
            }
            else
            {
               movingLeft = false; 
            }
            
            
        }
        else{

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            if(transform.position.x < rightEdge)
            {
                run();
                
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                
            }
            else
            {
               movingLeft = true; 
            }
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
              
        }
        
    }

    public void run()
	{
		anim.SetTrigger("Run");
	}

}
