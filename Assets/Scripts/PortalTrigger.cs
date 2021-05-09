using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    Collider2D trigger;
    GameObject triggerLeft, triggerRight;
    public float distanceFromTrigger;

    void Awake()
    {
        triggerLeft = GameObject.Find("TriggerLeft");
        triggerRight = GameObject.Find("TriggerRight");
    }

    void Start()
    {
        trigger = gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        Vector2 pacManRightPos = new Vector2(triggerRight.transform.position.x - distanceFromTrigger, triggerRight.transform.position.y);
        Vector2 pacManLeftPos = new Vector2(triggerLeft.transform.position.x + distanceFromTrigger, triggerLeft.transform.position.y);

        if (trigger.name == triggerLeft.name)
        {
            collider.transform.SetPositionAndRotation(pacManRightPos, transform.rotation);
        } else if (trigger.name == triggerRight.name)
        {
            collider.transform.SetPositionAndRotation(pacManLeftPos, transform.rotation);
        }
    }
}
