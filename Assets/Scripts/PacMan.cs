using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    private Animator animator;

    float minX, maxX, minY, maxY; 
    float speed = 4f;
    private Vector2 startPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    private bool setDirectionX(string direction, float directionValue, float speed, bool animationEnabled = true)
    {
        animator.enabled = animationEnabled;
        animator.SetFloat(direction, directionValue);
        animator.SetFloat("directionY", 0);
        transform.Translate(speed, 0, 0);
        return true;
    }

    private bool setDirectionY(string direction, float directionValue, float speed, bool animationEnabled = true)
    {
        animator.enabled = animationEnabled;
        animator.SetFloat(direction, directionValue);
        animator.SetFloat("directionX", 0);
        transform.Translate(0, speed, 0);
        return true;
    }

    private bool disableAnimation()
    {
        setDirectionX("directionX", 0, 0, false);
        setDirectionY("directionY", 0, 0, false);
        return true;
    }

    public void setPosition()
    {
        float calibratedSpeed = speed * Time.deltaTime;

        var down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        var up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        var left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        var right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        bool isMoving =
            (down) ? setDirectionY("directionY", -transform.position.y, -calibratedSpeed) :
            (up) ? setDirectionY("directionY", transform.position.y, calibratedSpeed) :
            (left) ? setDirectionX("directionX", -transform.position.x, -calibratedSpeed) :
            (right) && setDirectionX("directionX", transform.position.x, calibratedSpeed);

        bool isIdle = (!isMoving) && disableAnimation();
    }

    void Update()
    {
        setPosition();
    }   

    public void ResetPosition()
    {
        transform.position = new Vector2(startPosition.x, startPosition.y);
        gameObject.SetActive(true);
    }
}
