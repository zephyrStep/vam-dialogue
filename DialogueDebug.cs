using System.Collections.Generic;
using System;
using System.Linq;
using Leap.Unity;

namespace VamDialogue
{
    public static class DialogueDebug
    {
        public static void PrintStorables(Atom a)
        {
            SuperController.LogMessage("PRINTING STORABLEIDs FROM: " + a.ToString());
            foreach (var VARIABLE in a.GetStorableIDs())
            {
                SuperController.LogMessage(VARIABLE);
            }

            SuperController.LogMessage("");
        }

        public static void PrintActions(JSONStorable storable, string title="")
        {
            SuperController.LogMessage("\n\n");
            SuperController.LogMessage(title);
            SuperController.LogMessage("Printing actions and params for " + storable.name + " \ttype(" + storable.GetType() + ")");

            var paramsAndActions = storable.GetAllParamAndActionNames();
            var actions = storable.GetActionNames();
            var paramNames = paramsAndActions.Except(actions).ToList();

            SuperController.LogMessage("-Actions-");
            foreach (var actionName in actions)
            {
                SuperController.LogMessage(actionName + " \ttype(" + storable.GetAction(actionName).GetType() + ")");
            }
            SuperController.LogMessage("-Params-");
            foreach (var paramName in paramNames)
            {
                SuperController.LogMessage(paramName + " \ttype(" + storable.GetParam(paramName).GetType() + ")");
            }
            SuperController.LogMessage("\n\n");
        }

        public static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var VARIABLE in list)
            {
                SuperController.LogMessage(VARIABLE.ToString());
            }

            SuperController.LogMessage("");
        }

        public static void PrintAtoms(List<Atom> atoms)
        {
            foreach (var VARIABLE in atoms)
            {
                SuperController.LogMessage(VARIABLE.ToString());
                SuperController.LogMessage(VARIABLE.uid);
            }
        }

        public static void LogColor(JSONStorableColor color)
        {
            var c = "H:" + color.val.H + " S:" + color.val.S + " V:" + color.val.V;
            SuperController.LogMessage(c);
        }

        public static void LogJSONStorable(JSONStorable js)
        {
            SuperController.LogMessage(js.name);
            PrintList(js.GetAllParamAndActionNames());
        }
    }
}
