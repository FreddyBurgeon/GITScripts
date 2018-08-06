using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The class that transforms the physical inputs of the player, into a Bolt-usable AvatarCommandInput.
 * 
 *  - HOW TO USE:
 *      - Call CreateCommandInput(), it will automatically transform the physical inputs that the game is receiving, into an AvatacCommandInput ready to be enqueued.
 */
public class AvatarCommandInputCreator{

    /** The poller that will check the state of the physical inputs (like if the "action1Button" or the "leftButton" is pressed). */
    private PhysicalInputsPoller physicalInputPoller = new PhysicalInputsPoller();
    
    /** This function create a Bolt-usable AvatarCommandInput, polling the physical inputs that the game is receiving. */
    public IAvatarCommandInput CreateCommandInput()
    {
        // we create the new command input
        IAvatarCommandInput avatarCommandInput = AvatarCommand.Create();

        // we check the physical state of each input
        physicalInputPoller.Poll();

        // we copy the data we gathered with the poll, into the command input
        avatarCommandInput.MoveUp = physicalInputPoller.isUpButtonDown;
        avatarCommandInput.MoveDown = physicalInputPoller.isDownButtonDown;
        avatarCommandInput.MoveLeft = physicalInputPoller.isLeftButtonDown;
        avatarCommandInput.MoveRight = physicalInputPoller.isRightButtonDown;
        avatarCommandInput.Fire1 = physicalInputPoller.isAction1ButtonDown;
        avatarCommandInput.Fire2 = physicalInputPoller.isAction2ButtonDown;
        avatarCommandInput.Fire3 = physicalInputPoller.isAction3ButtonDown;
        
        return avatarCommandInput;
    }
    
}
