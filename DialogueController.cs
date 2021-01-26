using System;
using UnityEngine;

namespace VamDialogue
{
    public class DialogueController
    {
        private bool _instant;

        // Atom
        private Atom _signAtom;

        // JSON
        private JSONStorable _textColorAlpha; // color + alpha
        private JSONStorable _textValueSize; // text + font size
        private JSONStorable _materials;
        private JSONStorable _canvas;

        private SetTransformScale _signTransform;

        private DialogueUI _dialogueUI;


        //Controllers
        private MaterialOptions _materialOptions;
        private string _texturePath = null;
        public DialogueController(Atom signAtom, MVRScript plugin, bool instant=true)
        {
            _dialogueUI = new DialogueUI(plugin);
            _signAtom = signAtom;
            // var signAtom = sign;
            _instant = instant;
            _textColorAlpha = signAtom.GetStorableByID("Text");
            _textValueSize = signAtom.GetStorableByID("Sign");
            _canvas = signAtom.GetStorableByID("Canvas");
            _materials = signAtom.GetStorableByID("materials");


            DialogueDebug.PrintActions(_materials);
            _signTransform = (SetTransformScale) signAtom.GetStorableByID("scale");

            _materialOptions = (MaterialOptions) signAtom.GetStorableByID("materials");
            // DialogueDebug.PrintActions(signAtom.GetStorableByID("materials"));

            SuperController.LogMessage(_canvas.GetFloatJSONParam("xSize").val.ToString());
            SuperController.LogMessage(_canvas.GetFloatJSONParam("ySize").val.ToString());

            InitUI();

        }

        public void InitUI()
        {
            _dialogueUI.InitTextXPosSlider(GetTextXPos(), TextXChangeHandler);
            _dialogueUI.InitTextYPosSlider(GetTextYPos(), TextYChangeHandler);
        }

        public void TextXChangeHandler(float position)
        {
            SetTextXPos(position);
        }

        public void TextYChangeHandler(float position)
        {
            SetTextYPos(position);
        }

        public void SetText(string text)
        {
            _textValueSize.SetStringParamValue("text", text);
        }

        public void SetFontSize(float size=100.0f)
        {
            _textValueSize.SetFloatParamValue("fontSize", size);
        }

        public void SetColor(float r, float g, float b)
        {

            var color = new Color(r, g, b);

            float h, s, v;
            Color.RGBToHSV(color, out h, out s, out v);

            var hsvColor = new HSVColor {H = h, S = s, V = v};

            _textColorAlpha.SetColorParamValue("color", hsvColor);
        }

        public JSONStorableColor GetColor()
        {
            // return _textControl.GetStringParamValue("color");
            return _textColorAlpha.GetColorJSONParam("color");
        }

        public Color GetColorAsRGB()
        {
            var color = GetColor();
            return Color.HSVToRGB(color.val.H, color.val.S, color.val.V);
        }

        public void SetObjectScale(float x)
        {
            _signTransform.SetFloatParamValue("scale", x);
        }

        public void SetTextSize(float x, float y)
        {
            SetTextXPos(x);
            SetTextYPos(y);
        }

        public void SetTextXPos(float x)
        {
            _canvas.SetFloatParamValue("xSize", x);
        }

        public void SetTextYPos(float y)
        {
            _canvas.SetFloatParamValue("ySize", y);
        }

        public JSONStorableFloat GetTextXPos()
        {
            return _canvas.GetFloatJSONParam("xSize");
        }

        public JSONStorableFloat GetTextYPos()
        {
            return _canvas.GetFloatJSONParam("ySize");
        }
    }
}
