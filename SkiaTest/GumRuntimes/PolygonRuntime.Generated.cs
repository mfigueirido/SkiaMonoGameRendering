using System.Linq;
namespace SkiaTest.GumRuntimes
{
    public partial class PolygonRuntime : Gum.Wireframe.GraphicalUiElement
    {
        public PolygonRuntime () 
        	: this(true, true)
        {
        }
        public PolygonRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
        {
            if (fullInstantiation)
            {
                Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.StandardElements.First(item => item.Name == "Polygon");
                this.ElementSave = elementSave;
                string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
            }
        }
        RenderingLibrary.Math.Geometry.LinePolygon mContainedPolygon;
        RenderingLibrary.Math.Geometry.LinePolygon ContainedPolygon
        {
            get
            {
                if (mContainedPolygon == null)
                {
                    mContainedPolygon = this.RenderableComponent as RenderingLibrary.Math.Geometry.LinePolygon;
                }
                return mContainedPolygon;
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
                        Green = 255;
                        Red = 255;
                        Visible = true;
                        X = 0f;
                        XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        Y = 0f;
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
            bool setGreenFirstValue = false;
            bool setGreenSecondValue = false;
            int GreenFirstValue= 0;
            int GreenSecondValue= 0;
            bool setRedFirstValue = false;
            bool setRedSecondValue = false;
            int RedFirstValue= 0;
            int RedSecondValue= 0;
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
                    setGreenFirstValue = true;
                    GreenFirstValue = 255;
                    setRedFirstValue = true;
                    RedFirstValue = 255;
                    if (interpolationValue < 1)
                    {
                        this.Visible = true;
                    }
                    setXFirstValue = true;
                    XFirstValue = 0f;
                    if (interpolationValue < 1)
                    {
                        this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    setYFirstValue = true;
                    YFirstValue = 0f;
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
                    setGreenSecondValue = true;
                    GreenSecondValue = 255;
                    setRedSecondValue = true;
                    RedSecondValue = 255;
                    if (interpolationValue >= 1)
                    {
                        this.Visible = true;
                    }
                    setXSecondValue = true;
                    XSecondValue = 0f;
                    if (interpolationValue >= 1)
                    {
                        this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                    }
                    setYSecondValue = true;
                    YSecondValue = 0f;
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
            if (setGreenFirstValue && setGreenSecondValue)
            {
                Green = FlatRedBall.Math.MathFunctions.RoundToInt(GreenFirstValue* (1 - interpolationValue) + GreenSecondValue * interpolationValue);
            }
            if (setRedFirstValue && setRedSecondValue)
            {
                Red = FlatRedBall.Math.MathFunctions.RoundToInt(RedFirstValue* (1 - interpolationValue) + RedSecondValue * interpolationValue);
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
        public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (SkiaTest.GumRuntimes.PolygonRuntime.VariableState fromState,SkiaTest.GumRuntimes.PolygonRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                    Name = "Green",
                    Type = "int",
                    Value = Green
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
                    Name = "Visible",
                    Type = "bool",
                    Value = Visible
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
                    Name = "Green",
                    Type = "int",
                    Value = Green + 255
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
                    Name = "Visible",
                    Type = "bool",
                    Value = Visible
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
                return ContainedPolygon.Color.A;
            }
            set
            {
                var color = ContainedPolygon.Color;
                color.A = (byte)value;
                ContainedPolygon.Color = color;
            }
        }
        public int Blue
        {
            get
            {
                return ContainedPolygon.Color.B;
            }
            set
            {
                var color = ContainedPolygon.Color;
                color.B = (byte)value;
                ContainedPolygon.Color = color;
            }
        }
        public int Green
        {
            get
            {
                return ContainedPolygon.Color.G;
            }
            set
            {
                var color = ContainedPolygon.Color;
                color.G = (byte)value;
                ContainedPolygon.Color = color;
            }
        }
        public int Red
        {
            get
            {
                return ContainedPolygon.Color.R;
            }
            set
            {
                var color = ContainedPolygon.Color;
                color.R = (byte)value;
                ContainedPolygon.Color = color;
            }
        }
        public Microsoft.Xna.Framework.Color Color
        {
            get
            {
                return ContainedPolygon.Color;
            }
            set
            {
                ContainedPolygon.Color = value;
            }
        }
        public override void SetInitialState () 
        {
            var wasSuppressed = this.IsLayoutSuspended;
            if(!wasSuppressed) this.SuspendLayout();
            this.CurrentVariableState = VariableState.Default;
            if(!wasSuppressed) this.ResumeLayout();
        }
    }
}
