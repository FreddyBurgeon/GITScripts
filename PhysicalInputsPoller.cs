using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The class polls the physical inputs the game is receiving, like an old consolle gamepad.
 * 
 *  - HOW TO USE: 
 *      - Call the Poll() function, to check in what state currently are the physical buttons (call it just once each update). 
 *      - Now you can get the public properties, to know the state of each single button.
 *      
 *  Example: To know if the leftButton is pressed, call Poll(), then physicalInputsPollerInstance.isLeftButtonDown will tell you if it's true or false. 
 *  If, in the same Update, you need to know if also the action1Button is pressed, you can just get physicalInputsPollerInstance.isAction1ButtonDown. Poll() was already called, no need to call it another time.
 */
public class PhysicalInputsPoller {

    // the states of each button
    public bool isUpButtonDown;
    public bool isDownButtonDown;
    public bool isLeftButtonDown;
    public bool isRightButtonDown;
    public bool isAction1ButtonDown;
    public bool isAction2ButtonDown;
    public bool isAction3ButtonDown;

    /** The last frame where we performed a poll. We do the poll maximum 1 time each frame. */
    private int lastFramePolled;

    /** This function polls for the interesting physical inputs. */
    public void Poll()
    {
        // if we already have polled this frame, no need to redo it.
        if (lastFramePolled == Time.frameCount) return;

        ResetAllPhysicalInputs();
        PollAxis();
        PollActionButtons();

        // we register that, this frame, we already polled. To avoid to redo the work if someone call again Poll() in the same frame.
        lastFramePolled = Time.frameCount;
    }

    /** Reset all the physical inputs to their default Up state. */
    private void ResetAllPhysicalInputs()
    {
        isUpButtonDown = false;
        isDownButtonDown = false;
        isRightButtonDown = false;
        isLeftButtonDown = false;
        isAction1ButtonDown = false;
        isAction2ButtonDown = false;
        isAction3ButtonDown = false;
    }

    /** This function tells us in what state are the axis. */
    private void PollAxis()
    {
        // we convert the vertical axis input, into the pression of the "upButton" or "downButton".
        float verticalAxisInput = Input.GetAxis("Vertical");

        // if the vertical axis has a positive value, then we set the "upButton" as pressed.
        if (verticalAxisInput > 0)
        {
            isUpButtonDown = true;
        }

        // if the vertical axis has a n valuegative, then we set the "downButton" as pressed.
        else if (verticalAxisInput < 0)
        {
            isDownButtonDown = true;
        }

        // we convert the horizontal axis input, into the pression of the "leftButton" or "rightButton".
        float horizontalAxisInput = Input.GetAxis("Horizontal");

        // if the horizontal axis has a positive value, then we set the "rightButton" as pressed.
        if (horizontalAxisInput > 0)
        {
            isRightButtonDown = true;
        }

        // if the horizontal axis has a negative value, then we set the "leftButton" as pressed.
        else if (horizontalAxisInput < 0)
        {
            isLeftButtonDown = true;
        }
    }

    /** This function tells us in what state are the action buttons. */
    private void PollActionButtons()
    {
        // we register the pression of the fire1 button
        if (Input.GetButton("Fire1") == true)
        {
            isAction1ButtonDown = true;
        }
        // we register the pression of the fire2 button
        if (Input.GetButton("Fire2") == true)
        {
            isAction2ButtonDown = true;
        }
        // we register the pression of the fire3 button
        if (Input.GetButton("Fire3") == true)
        {
            isAction3ButtonDown = true;
        }
        
    }

}
