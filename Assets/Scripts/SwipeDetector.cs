using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public float swipeThreshold = 50f;
    public float timeThreshold = 0.3f;

    public bool swipeable = true;

    public bool leftCheck,rightCheck,upCheck,downCheck;
    private Vector2 fingerDown;
    private DateTime fingerDownTime;
    private Vector2 fingerUp;
    private DateTime fingerUpTime;

    private void Awake()
    {
        leftCheck = false;
        rightCheck = false;
        upCheck = false;
        downCheck = false;
    }

    private void Update () {
        if(swipeable)
        {
            if (Input.GetMouseButtonDown(0)) {
                this.fingerDown = Input.mousePosition;
                this.fingerDownTime = DateTime.Now;
            }
                if (Input.GetMouseButtonUp(0)) {
                this.fingerUp = Input.mousePosition;
                this.fingerUpTime = DateTime.Now;
                this.CheckSwipe();
            }
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    this.fingerDown = touch.position;
                    this.fingerDownTime = DateTime.Now;
                }
                if (touch.phase == TouchPhase.Ended) {
                    this.fingerUp = touch.position;
                    this.fingerUpTime = DateTime.Now;
                    this.CheckSwipe();
                }
            }
        }
        
    }

    private void CheckSwipe() {
        float duration = (float)this.fingerUpTime.Subtract(this.fingerDownTime).TotalSeconds;
        if (duration > this.timeThreshold) return;

        float deltaX = this.fingerUp.x - this.fingerDown.x;
        if (Mathf.Abs(deltaX) > this.swipeThreshold) {
            if (deltaX > 0) {
                leftCheck = false;
                rightCheck = true;
                upCheck = false;
                downCheck = false;
            } else if (deltaX < 0) {
                leftCheck = true;
                rightCheck = false;
                upCheck = false;
                downCheck = false;
            }
        }

        float deltaY = fingerUp.y - fingerDown.y;
        if (Mathf.Abs(deltaY) > this.swipeThreshold) {
            if (deltaY > 0) {
                leftCheck = false;
                rightCheck = false;
                upCheck = true;
                downCheck = false;
            } else if (deltaY < 0) {
                leftCheck = false;
                rightCheck = false;
                upCheck = false;
                downCheck = true;
            }
        }
        this.fingerUp = this.fingerDown;
    }
}
