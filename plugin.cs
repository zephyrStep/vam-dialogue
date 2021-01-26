using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

namespace VamDialogue
{
    public class DialoguePlugin : MVRScript
    {
        private Atom _simpleSign;
        private DialogueController _dialogueController;
        public override void Init()
        {
            try
            {
                SuperController.LogMessage($"{nameof(DialoguePlugin)} initialized");
                _simpleSign = containingAtom;
                DialogueDebug.PrintStorables(_simpleSign);
                _dialogueController = new DialogueController(_simpleSign, this);
                _dialogueController.SetText("test123");
                _dialogueController.SetColor(0,0,255);
                DialogueDebug.LogColor(_dialogueController.GetColor());

                _dialogueController.SetObjectScale(1.25f);
                // _dialogueController.SetTextSize(100,100);

                // _dialogueController

            }
            catch (Exception e)
            {
                SuperController.LogError($"{nameof(DialoguePlugin)}.{nameof(Init)}: {e}");
            }
        }



        public void OnEnable()
        {
            try
            {
                SuperController.LogMessage($"{nameof(DialoguePlugin)} enabled");
            }
            catch (Exception e)
            {
                SuperController.LogError($"{nameof(DialoguePlugin)}.{nameof(OnEnable)}: {e}");
            }
        }

        public void OnDisable()
        {
            try
            {
                SuperController.LogMessage($"{nameof(DialoguePlugin)} disabled");
            }
            catch (Exception e)
            {
                SuperController.LogError($"{nameof(DialoguePlugin)}.{nameof(OnDisable)}: {e}");
            }
        }

        public void OnDestroy()
        {
            try
            {
                SuperController.LogMessage($"{nameof(DialoguePlugin)} destroyed");
            }
            catch (Exception e)
            {
                SuperController.LogError($"{nameof(DialoguePlugin)}.{nameof(OnDestroy)}: {e}");
            }
        }
    }
}
