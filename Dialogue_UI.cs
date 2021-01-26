using System;
using UnityEngine.Events;
using UnityEngine.Experimental.PlayerLoop;

namespace VamDialogue
{
    public class DialogueUI
    {
        private string _texture = "default";
        private Atom _textSign = null;
        private MVRScript _plugin;
        private UIDynamicButton _testButton = null;

        private UIDynamicSlider _textYPosSlider;
        private UIDynamicSlider _textXPosSlider;
        public DialogueUI(MVRScript plugin)
        {
            _plugin = plugin;
            _testButton = plugin.CreateButton("Test");
        }

        public void InitTextXPosSlider(JSONStorableFloat xScale, UnityAction<float> listener)
        {
            _textXPosSlider = _plugin.CreateSlider(xScale);
            _textXPosSlider.slider.onValueChanged.AddListener(listener);
        }

        public void InitTextYPosSlider(JSONStorableFloat yScale, UnityAction<float> listener)
        {
            _textYPosSlider = _plugin.CreateSlider(yScale);
            _textYPosSlider.slider.onValueChanged.AddListener(listener);
        }
    }
}
