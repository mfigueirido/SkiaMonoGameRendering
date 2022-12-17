using System.Linq;
namespace SkiaTest.GumRuntimes
{
    public partial class TextRuntime : Gum.Wireframe.GraphicalUiElement
    {
        public TextRuntime () 
        	: this(true, true)
        {
        }
        public TextRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
        {
            this.HasEvents = false;
            this.ExposeChildrenEvents = false;
            if (fullInstantiation)
            {
                Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.StandardElements.First(item => item.Name == "Text");
                this.ElementSave = elementSave;
                string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
            }
        }
        RenderingLibrary.Graphics.Text mContainedText;
        RenderingLibrary.Graphics.Text ContainedText
        {
            get
            {
                if (mContainedText == null)
                {
                    mContainedText = this.RenderableComponent as RenderingLibrary.Graphics.Text;
                }
                return mContainedText;
            }
        }
        #region State Enums
        public enum VariableState
        {
            Default
        }
        #endregion
        #region State Fields
        VariableState mCurrentVariableState;
        #endregion
        #region State Properties
        public VariableState CurrentVariableState
        {
            get
            {
                return mCurrentVariableState;
            }
            set
            {
                mCurrentVariableState = value;
                switch(mCurrentVariableState)
                {
                    case  VariableState.Default:
                        Alpha = 255;
                        Blue = 255;
                        SetProperty("CustomFontFile", "");
                        ExposeChildrenEvents = false;
                        Font = "Arial";
                        FontScale = 1f;
                        FontSize = 18;
                        Green = 255;
                        HasEvents = false;
                        Height = 50f;
                        HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        IsBold = false;
                        IsItalic = false;
                        OutlineThickness = 0;
                        Red = 255;
                        Rotation = 0f;
                        Text = "Hello";
                        UseCustomFont = false;
                        UseFontSmoothing = true;
                        VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        Visible = true;
                        Width = 100f;
                        WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        X = 0f;
                        XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        Y = 0f;
                        YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        break;
                }
            }
        }
        #endregion
        #region State Interpolation
        public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
        {
            #if DEBUG
            if (float.IsNaN(interpolationValue))
            {
                throw new System.Exception("interpolationValue cannot be NaN");
            }
            #endif
            bool setAlphaFirstValue = false;
            bool setAlphaSecondValue = false;
            int AlphaFirstValue= 0;
            int AlphaSecondValue= 0;
            bool setBlueFirstValue = false;
            bool setBlueSecondValue = false;
            int BlueFirstValue= 0;
            int BlueSecondValue= 0;
            bool setFontScaleFirstValue = false;
            bool setFontScaleSecondValue = false;
            float FontScaleFirstValue= 0;
            float FontScaleSecondValue= 0;
            bool setFontSizeFirstValue = false;
            bool setFontSizeSecondValue = false;
            int FontSizeFirstValue= 0;
            int FontSizeSecondValue= 0;
            bool setGreenFirstValue = false;
            bool setGreenSecondValue = false;
            int GreenFirstValue= 0;
            int GreenSecondValue= 0;
            bool setHeightFirstValue = false;
            bool setHeightSecondValue = false;
            float HeightFirstValue= 0;
            float HeightSecondValue= 0;
            bool setOutlineThicknessFirstValue = false;
            bool setOutlineThicknessSecondValue = false;
            int OutlineThicknessFirstValue= 0;
            int OutlineThicknessSecondValue= 0;
            bool setRedFirstValue = false;
            bool setRedSecondValue = false;
            int RedFirstValue= 0;
            int RedSecondValue= 0;
            bool setRotationFirstValue = false;
            bool setRotationSecondValue = false;
            float RotationFirstValue= 0;
            float RotationSecondValue= 0;
            bool setWidthFirstValue = false;
            bool setWidthSecondValue = false;
            float WidthFirstValue= 0;
            float WidthSecondValue= 0;
            bool setXFirstValue = false;
            bool setXSecondValue = false;
            float XFirstValue= 0;
            float XSecondValue= 0;
            bool setYFirstValue = false;
            bool setYSecondValue = false;
            float YFirstValue= 0;
            float YSecondValue= 0;
            switch(firstState)
            {
                case  VariableState.Default:
                    setAlphaFirstValue = true;
                    AlphaFirstValue = 255;
                    setBlueFirstValue = true;
                    BlueFirstValue = 255;
                    if (interpolationValue < 1)
                    {
                        SetProperty("CustomFontFile", "");
                    }
                    if (interpolationValue < 1)
                    {
                        this.ExposeChildrenEvents = false;
                    }
                    if (interpolationValue < 1)
                    {
                        this.Font = "Arial";
                    }
                    setFontScaleFirstValue = true;
                    FontScaleFirstValue = 1f;
                    setFontSizeFirstValue = true;
                    FontSizeFirstValue = 18;
                    setGreenFirstValue = true;
                    GreenFirstValue = 255;
                    if (interpolationValue < 1)
                    {
                        this.HasEvents = false;
                    }
                    setHeightFirstValue = true;
                    HeightFirstValue = 50f;
                    if (interpolationValue < 1)
                    {
                        this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    if (interpolationValue < 1)
                    {
                        this.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                    }
                    if (interpolationValue < 1)
                    {
                        this.IsBold = false;
                    }
                    if (interpolationValue < 1)
                    {
                        this.IsItalic = false;
                    }
                    setOutlineThicknessFirstValue = true;
                    OutlineThicknessFirstValue = 0;
                    setRedFirstValue = true;
                    RedFirstValue = 255;
                    setRotationFirstValue = true;
                    RotationFirstValue = 0f;
                    if (interpolationValue < 1)
                    {
                        this.Text = "Hello";
                    }
                    if (interpolationValue < 1)
                    {
                        this.UseCustomFont = false;
                    }
                    if (interpolationValue < 1)
                    {
                        this.UseFontSmoothing = true;
                    }
                    if (interpolationValue < 1)
                    {
                        this.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Top;
                    }
                    if (interpolationValue < 1)
                    {
                        this.Visible = true;
                    }
                    setWidthFirstValue = true;
                    WidthFirstValue = 100f;
                    if (interpolationValue < 1)
                    {
                        this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    setXFirstValue = true;
                    XFirstValue = 0f;
                    if (interpolationValue < 1)
                    {
                        this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                    }
                    if (interpolationValue < 1)
                    {
                        this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    setYFirstValue = true;
                    YFirstValue = 0f;
                    if (interpolationValue < 1)
                    {
                        this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                    }
                    if (interpolationValue < 1)
                    {
                        this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    break;
            }
            switch(secondState)
            {
                case  VariableState.Default:
                    setAlphaSecondValue = true;
                    AlphaSecondValue = 255;
                    setBlueSecondValue = true;
                    BlueSecondValue = 255;
                    if (interpolationValue >= 1)
                    {
                        SetProperty("CustomFontFile", "");
                    }
                    if (interpolationValue >= 1)
                    {
                        this.ExposeChildrenEvents = false;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.Font = "Arial";
                    }
                    setFontScaleSecondValue = true;
                    FontScaleSecondValue = 1f;
                    setFontSizeSecondValue = true;
                    FontSizeSecondValue = 18;
                    setGreenSecondValue = true;
                    GreenSecondValue = 255;
                    if (interpolationValue >= 1)
                    {
                        this.HasEvents = false;
                    }
                    setHeightSecondValue = true;
                    HeightSecondValue = 50f;
                    if (interpolationValue >= 1)
                    {
                        this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.IsBold = false;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.IsItalic = false;
                    }
                    setOutlineThicknessSecondValue = true;
                    OutlineThicknessSecondValue = 0;
                    setRedSecondValue = true;
                    RedSecondValue = 255;
                    setRotationSecondValue = true;
                    RotationSecondValue = 0f;
                    if (interpolationValue >= 1)
                    {
                        this.Text = "Hello";
                    }
                    if (interpolationValue >= 1)
                    {
                        this.UseCustomFont = false;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.UseFontSmoothing = true;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Top;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.Visible = true;
                    }
                    setWidthSecondValue = true;
                    WidthSecondValue = 100f;
                    if (interpolationValue >= 1)
                    {
                        this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    setXSecondValue = true;
                    XSecondValue = 0f;
                    if (interpolationValue >= 1)
                    {
                        this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    setYSecondValue = true;
                    YSecondValue = 0f;
                    if (interpolationValue >= 1)
                    {
                        this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    break;
            }
            var wasSuppressed = mIsLayoutSuspended;
            var shouldSuspend = wasSuppressed == false;
            var suspendRecursively = true;
            if (shouldSuspend)
            {
                SuspendLayout(suspendRecursively);
            }
            if (setAlphaFirstValue && setAlphaSecondValue)
            {
                Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(AlphaFirstValue* (1 - interpolationValue) + AlphaSecondValue * interpolationValue);
            }
            if (setBlueFirstValue && setBlueSecondValue)
            {
                Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BlueFirstValue* (1 - interpolationValue) + BlueSecondValue * interpolationValue);
            }
            if (setFontScaleFirstValue && setFontScaleSecondValue)
            {
                FontScale = FontScaleFirstValue * (1 - interpolationValue) + FontScaleSecondValue * interpolationValue;
            }
            if (setFontSizeFirstValue && setFontSizeSecondValue)
            {
                FontSize = FlatRedBall.Math.MathFunctions.RoundToInt(FontSizeFirstValue* (1 - interpolationValue) + FontSizeSecondValue * interpolationValue);
            }
            if (setGreenFirstValue && setGreenSecondValue)
            {
                Green = FlatRedBall.Math.MathFunctions.RoundToInt(GreenFirstValue* (1 - interpolationValue) + GreenSecondValue * interpolationValue);
            }
            if (setHeightFirstValue && setHeightSecondValue)
            {
                Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
            }
            if (setOutlineThicknessFirstValue && setOutlineThicknessSecondValue)
            {
                OutlineThickness = FlatRedBall.Math.MathFunctions.RoundToInt(OutlineThicknessFirstValue* (1 - interpolationValue) + OutlineThicknessSecondValue * interpolationValue);
            }
            if (setRedFirstValue && setRedSecondValue)
            {
                Red = FlatRedBall.Math.MathFunctions.RoundToInt(RedFirstValue* (1 - interpolationValue) + RedSecondValue * interpolationValue);
            }
            if (setRotationFirstValue && setRotationSecondValue)
            {
                Rotation = RotationFirstValue * (1 - interpolationValue) + RotationSecondValue * interpolationValue;
            }
            if (setWidthFirstValue && setWidthSecondValue)
            {
                Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
            }
            if (setXFirstValue && setXSecondValue)
            {
                X = XFirstValue * (1 - interpolationValue) + XSecondValue * interpolationValue;
            }
            if (setYFirstValue && setYSecondValue)
            {
                Y = YFirstValue * (1 - interpolationValue) + YSecondValue * interpolationValue;
            }
            if (interpolationValue < 1)
            {
                mCurrentVariableState = firstState;
            }
            else
            {
                mCurrentVariableState = secondState;
            }
            if (shouldSuspend)
            {
                ResumeLayout(suspendRecursively);
            }
        }
        #endregion
        #region State Interpolate To
        public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (SkiaTest.GumRuntimes.TextRuntime.VariableState fromState,SkiaTest.GumRuntimes.TextRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
        {
            FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from:0, to:1, duration:(float)secondsToTake, type:interpolationType, easing:easing );
            if (owner == null)
            {
                tweener.Owner = this;
            }
            else
            {
                tweener.Owner = owner;
            }
            tweener.PositionChanged = newPosition => this.InterpolateBetween(fromState, toState, newPosition);
            tweener.Start();
            StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
            return tweener;
        }
        public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
        {
            Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
            Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.States.First(item => item.Name == toState.ToString());
            FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
            if (owner == null)
            {
                tweener.Owner = this;
            }
            else
            {
                tweener.Owner = owner;
            }
            tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
            tweener.Ended += ()=> this.CurrentVariableState = toState;
            tweener.Start();
            StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
            return tweener;
        }
        public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
        {
            Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
            Gum.DataTypes.Variables.StateSave toAsStateSave = AddToCurrentValuesWithState(toState);
            FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
            if (owner == null)
            {
                tweener.Owner = this;
            }
            else
            {
                tweener.Owner = owner;
            }
            tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
            tweener.Ended += ()=> this.CurrentVariableState = toState;
            tweener.Start();
            StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
            return tweener;
        }
        #endregion
        #region State Animations
        #endregion
        public override void StopAnimations () 
        {
            base.StopAnimations();
        }
        public override FlatRedBall.Gum.Animation.GumAnimation GetAnimation (string animationName) 
        {
            return base.GetAnimation(animationName);
        }
        #region Get Current Values on State
        private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (VariableState state) 
        {
            Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
            switch(state)
            {
                case  VariableState.Default:
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Alpha",
                    Type = "int",
                    Value = Alpha
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Blue",
                    Type = "int",
                    Value = Blue
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "CustomFontFile",
                    Type = "string",
                    Value = CustomFontFile
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "ExposeChildrenEvents",
                    Type = "bool",
                    Value = ExposeChildrenEvents
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Font",
                    Type = "string",
                    Value = Font
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Font Scale",
                    Type = "float",
                    Value = FontScale
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "FontSize",
                    Type = "int",
                    Value = FontSize
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Green",
                    Type = "int",
                    Value = Green
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "HasEvents",
                    Type = "bool",
                    Value = HasEvents
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Height",
                    Type = "float",
                    Value = Height
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Height Units",
                    Type = "DimensionUnitType",
                    Value = HeightUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "HorizontalAlignment",
                    Type = "HorizontalAlignment",
                    Value = HorizontalAlignment
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "IsBold",
                    Type = "bool",
                    Value = IsBold
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "IsItalic",
                    Type = "bool",
                    Value = IsItalic
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "OutlineThickness",
                    Type = "int",
                    Value = OutlineThickness
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Red",
                    Type = "int",
                    Value = Red
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Rotation",
                    Type = "float",
                    Value = Rotation
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Text",
                    Type = "string",
                    Value = Text
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "UseCustomFont",
                    Type = "bool",
                    Value = UseCustomFont
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "UseFontSmoothing",
                    Type = "bool",
                    Value = UseFontSmoothing
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "VerticalAlignment",
                    Type = "VerticalAlignment",
                    Value = VerticalAlignment
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Visible",
                    Type = "bool",
                    Value = Visible
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Width",
                    Type = "float",
                    Value = Width
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Width Units",
                    Type = "DimensionUnitType",
                    Value = WidthUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X",
                    Type = "float",
                    Value = X
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X Origin",
                    Type = "HorizontalAlignment",
                    Value = XOrigin
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X Units",
                    Type = "PositionUnitType",
                    Value = XUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y",
                    Type = "float",
                    Value = Y
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y Origin",
                    Type = "VerticalAlignment",
                    Value = YOrigin
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y Units",
                    Type = "PositionUnitType",
                    Value = YUnits
                    }
                    );
                    break;
            }
            return newState;
        }
        private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (VariableState state) 
        {
            Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
            switch(state)
            {
                case  VariableState.Default:
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Alpha",
                    Type = "int",
                    Value = Alpha + 255
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Blue",
                    Type = "int",
                    Value = Blue + 255
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "CustomFontFile",
                    Type = "string",
                    Value = CustomFontFile
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "ExposeChildrenEvents",
                    Type = "bool",
                    Value = ExposeChildrenEvents
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Font",
                    Type = "string",
                    Value = Font
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Font Scale",
                    Type = "float",
                    Value = FontScale + 1f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "FontSize",
                    Type = "int",
                    Value = FontSize + 18
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Green",
                    Type = "int",
                    Value = Green + 255
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "HasEvents",
                    Type = "bool",
                    Value = HasEvents
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Height",
                    Type = "float",
                    Value = Height + 50f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Height Units",
                    Type = "DimensionUnitType",
                    Value = HeightUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "HorizontalAlignment",
                    Type = "HorizontalAlignment",
                    Value = HorizontalAlignment
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "IsBold",
                    Type = "bool",
                    Value = IsBold
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "IsItalic",
                    Type = "bool",
                    Value = IsItalic
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "OutlineThickness",
                    Type = "int",
                    Value = OutlineThickness + 0
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Red",
                    Type = "int",
                    Value = Red + 255
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Rotation",
                    Type = "float",
                    Value = Rotation + 0f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Text",
                    Type = "string",
                    Value = Text
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "UseCustomFont",
                    Type = "bool",
                    Value = UseCustomFont
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "UseFontSmoothing",
                    Type = "bool",
                    Value = UseFontSmoothing
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "VerticalAlignment",
                    Type = "VerticalAlignment",
                    Value = VerticalAlignment
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Visible",
                    Type = "bool",
                    Value = Visible
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Width",
                    Type = "float",
                    Value = Width + 100f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Width Units",
                    Type = "DimensionUnitType",
                    Value = WidthUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X",
                    Type = "float",
                    Value = X + 0f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X Origin",
                    Type = "HorizontalAlignment",
                    Value = XOrigin
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "X Units",
                    Type = "PositionUnitType",
                    Value = XUnits
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y",
                    Type = "float",
                    Value = Y + 0f
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y Origin",
                    Type = "VerticalAlignment",
                    Value = YOrigin
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Y Units",
                    Type = "PositionUnitType",
                    Value = YUnits
                    }
                    );
                    break;
            }
            return newState;
        }
        #endregion
        public override void ApplyState (Gum.DataTypes.Variables.StateSave state) 
        {
            bool matches = this.ElementSave.AllStates.Contains(state);
            if (matches)
            {
                var category = this.ElementSave.Categories.FirstOrDefault(item => item.States.Contains(state));
                if (category == null)
                {
                    if (state.Name == "Default") this.mCurrentVariableState = VariableState.Default;
                }
            }
            base.ApplyState(state);
        }
        public int Alpha
        {
            get
            {
                return ContainedText.Alpha;
            }
            set
            {
                ContainedText.Alpha = value;
            }
        }
        public int Blue
        {
            get
            {
                return ContainedText.Blue;
            }
            set
            {
                ContainedText.Blue = value;
            }
        }
        public float FontScale
        {
            get
            {
                return ContainedText.FontScale;
            }
            set
            {
                ContainedText.FontScale = value;
                UpdateLayout();
            }
        }
        public int Green
        {
            get
            {
                return ContainedText.Green;
            }
            set
            {
                ContainedText.Green = value;
            }
        }
        public RenderingLibrary.Graphics.HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return ContainedText.HorizontalAlignment;
            }
            set
            {
                ContainedText.HorizontalAlignment = value;
            }
        }
        public int? MaxLettersToShow
        {
            get
            {
                return ContainedText.MaxLettersToShow;
            }
            set
            {
                ContainedText.MaxLettersToShow = value;
            }
        }
        public int Red
        {
            get
            {
                return ContainedText.Red;
            }
            set
            {
                ContainedText.Red = value;
            }
        }
        public string Text
        {
            get
            {
                return ContainedText.RawText;
            }
            set
            {
                var widthBefore = ContainedText.WrappedTextWidth;
                var heightBefore = ContainedText.WrappedTextHeight;
                if (this.WidthUnits == Gum.DataTypes.DimensionUnitType.RelativeToChildren)
                {
                    // make it have no line wrap width before assignign the text:
                    ContainedText.Width = 0;
                }
                ContainedText.RawText = value;
                var shouldUpdate = widthBefore != ContainedText.WrappedTextWidth || heightBefore != ContainedText.WrappedTextHeight;
                if (shouldUpdate)
                {
                    UpdateLayout(true, int.MaxValue/2);
                }
            }
        }
        public RenderingLibrary.Graphics.VerticalAlignment VerticalAlignment
        {
            get
            {
                return ContainedText.VerticalAlignment;
            }
            set
            {
                ContainedText.VerticalAlignment = value;
            }
        }
        public Microsoft.Xna.Framework.Color Color
        {
            get
            {
                return ContainedText.Color;
            }
            set
            {
                ContainedText.Color = value;
            }
        }
        public RenderingLibrary.Graphics.BitmapFont BitmapFont
        {
            get
            {
                return ContainedText.BitmapFont;
            }
            set
            {
                ContainedText.BitmapFont = value;
            }
        }
        public System.Collections.Generic.List<string> WrappedText
        {
            get
            {
                return ContainedText.WrappedText;
            }
        }
        public override void SetInitialState () 
        {
            var wasSuppressed = this.IsLayoutSuspended;
            if(!wasSuppressed) this.SuspendLayout();
            this.CurrentVariableState = VariableState.Default;
            if(!wasSuppressed) this.ResumeLayout();
        }
        public RenderingLibrary.Graphics.TextRenderingPositionMode? OverrideTextRenderingPositionMode
        {
            get => mContainedText.OverrideTextRenderingPositionMode;
            set => mContainedText.OverrideTextRenderingPositionMode = value;
        }
    }
}
