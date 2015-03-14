using SeriousGameToolbox.Commands;
using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I3D.Commands
{
    /// <summary>
    /// The command listener will sit in the Unity scene and listen to any input.
    /// When a key sequence is detected, it will send it to the CommandManager for evaluation.
    /// </summary>
    public class CommandListener : IUpdatable
    {
        char letter;

        bool CtrlPressed
        {
            get
            {
                bool isPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
                return isPressed;
            }
        }

        bool AltPressed
        {
            get
            {

                bool isPressed = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
                return isPressed;
            }
        }

        bool ShiftPressed
        {
            get
            {
                bool isPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                return isPressed;
            }
        }

        bool AnyLetterPressed(out char letter)
        {
            if (Input.GetKeyDown(KeyCode.A)) { letter = 'A'; return true; }
            if (Input.GetKeyDown(KeyCode.B)) { letter = 'B'; return true; }
            if (Input.GetKeyDown(KeyCode.C)) { letter = 'C'; return true; }
            if (Input.GetKeyDown(KeyCode.D)) { letter = 'D'; return true; }
            if (Input.GetKeyDown(KeyCode.E)) { letter = 'E'; return true; }
            if (Input.GetKeyDown(KeyCode.F)) { letter = 'F'; return true; }
            if (Input.GetKeyDown(KeyCode.G)) { letter = 'G'; return true; }
            if (Input.GetKeyDown(KeyCode.H)) { letter = 'H'; return true; }
            if (Input.GetKeyDown(KeyCode.I)) { letter = 'I'; return true; }
            if (Input.GetKeyDown(KeyCode.J)) { letter = 'J'; return true; }
            if (Input.GetKeyDown(KeyCode.K)) { letter = 'K'; return true; }
            if (Input.GetKeyDown(KeyCode.L)) { letter = 'L'; return true; }
            if (Input.GetKeyDown(KeyCode.M)) { letter = 'M'; return true; }
            if (Input.GetKeyDown(KeyCode.N)) { letter = 'N'; return true; }
            if (Input.GetKeyDown(KeyCode.O)) { letter = 'O'; return true; }
            if (Input.GetKeyDown(KeyCode.P)) { letter = 'P'; return true; }
            if (Input.GetKeyDown(KeyCode.Q)) { letter = 'Q'; return true; }
            if (Input.GetKeyDown(KeyCode.R)) { letter = 'R'; return true; }
            if (Input.GetKeyDown(KeyCode.S)) { letter = 'S'; return true; }
            if (Input.GetKeyDown(KeyCode.T)) { letter = 'T'; return true; }
            if (Input.GetKeyDown(KeyCode.U)) { letter = 'U'; return true; }
            if (Input.GetKeyDown(KeyCode.V)) { letter = 'V'; return true; }
            if (Input.GetKeyDown(KeyCode.W)) { letter = 'W'; return true; }
            if (Input.GetKeyDown(KeyCode.X)) { letter = 'X'; return true; }
            if (Input.GetKeyDown(KeyCode.Y)) { letter = 'Y'; return true; }
            if (Input.GetKeyDown(KeyCode.Z)) { letter = 'Z'; return true; }

            letter = '\0';
            return false;
        }

        public void Update(double dt)
        {
            if (CtrlPressed && AltPressed && ShiftPressed && AnyLetterPressed(out letter))
            {
                CommandManager.EvaluateSequence("CTRL", "ALT", "SHIFT", letter.ToString());
            }
            else if (CtrlPressed && AltPressed && AnyLetterPressed(out letter))
            {
                CommandManager.EvaluateSequence("CTRL", "ALT", letter.ToString());
            }
            else if (CtrlPressed && ShiftPressed && AnyLetterPressed(out letter))
            {
                CommandManager.EvaluateSequence("CTRL", "SHIFT", letter.ToString());
            }
            else if (CtrlPressed && AnyLetterPressed(out letter))
            {
                CommandManager.EvaluateSequence("CTRL", letter.ToString());
            }

            letter = '\0';
        }
    }
}
