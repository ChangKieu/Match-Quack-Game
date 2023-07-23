using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public ParticleSystem effect1,effect2;
    public Line draw;
    public float speed = 10f;
    bool startMove ;
    public Vector3[] pos;
    int moveIndex ;
    public GameObject duck;
    bool heart,dead;
    GameControl gc;
    public Vector3 posGO;
    private void Start()
    {
        heart= false;
        startMove= false;
        moveIndex= 0;
        posGO= gameObject.transform.position;
        gc = FindObjectOfType<GameControl>();
    }
    private void OnMouseDown()
    {
        draw.StartLine(transform.position); 
    }
    private void OnMouseDrag()
    {
        draw.UpdateLine();
    }
     private void OnMouseUp() 
    {
        pos = new Vector3[draw.line.positionCount];
        draw.line.GetPositions(pos);
        moveIndex= 0;
    }
    public void StartMove()
    {
        startMove = true;
    }
    public void SetStart()
    {
        gameObject.transform.position = posGO;
        dead= false;
        heart = false;
        startMove = false;
        moveIndex = 0;
    }
    private void Update()
    {
        dead=gc.IsDead();
        if(dead)
        {
            draw.StartLine(transform.position);
            return;
        }
        if(startMove)
        {
            Vector2 curr= pos[moveIndex];
            transform.position = Vector2.MoveTowards(transform.position,curr,speed*Time.deltaTime);
            
            //rotate
            //Vector2 dir=curr-(Vector2)transform.position;
            //float angle = Mathf.Atan2(dir.normalized.y,dir.normalized.x);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90f), speed);

            float dis=Vector2.Distance(curr,transform.position);
            if(dis<=0.05f)
            {
                moveIndex++;
            }
            if(moveIndex > pos.Length - 1)
            {
                draw.StartLine(transform.position);
                startMove = false;
                if (heart)
                {
                    effect1.transform.position = transform.position;
                    effect2.transform.position = duck.transform.position;
                    effect1.Play();
                    effect2.Play();
                    gc.IsTrue();
                }
                else
                {
                    gc.SetGameover(true);
                }
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            heart = true;
        }
        if(collision.CompareTag("Dead"))
        {
            startMove = false;
            gc.SetGameover(true);
        }
    }
}
