using System.Linq;
namespace SkiaTest.GumRuntimes
{
    public partial class ContainerRuntime : Gum.Wireframe.GraphicalUiElement
    {
        public ContainerRuntime () 
        	: this(true, true)
        {
        }
        public ContainerRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
        {
            this.HasEvents = true;
            this.ExposeChildrenEvents = true;
            if (fullInstantiation)
            {
                Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.StandardElements.First(item => item.Name == "Container");
                this.ElementSave = elementSave;
                string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
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
                        ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        ClipsChildren = false;
                        ExposeChildrenEvents = true;
                        FlipHorizontal = false;
                        HasEvents = true;
                        Height = 150f;
                        HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        StackSpacing = 0f;
                        Visible = true;
                        Width = 150f;
                        WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        WrapsChildren = false;
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
            bool setHeightFirstValue = false;
            bool setHeightSecondValue = false;
            float HeightFirstValue= 0;
            float HeightSecondValue= 0;
            bool setStackSpacingFirstValue = false;
            bool setStackSpacingSecondValue = false;
            float StackSpacingFirstValue= 0;
            float StackSpacingSecondValue= 0;
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
                    if (interpolationValue < 1)
                    {
                        this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                    }
                    if (interpolationValue < 1)
                    {
                        this.ClipsChildren = false;
                    }
                    if (interpolationValue < 1)
                    {
                        this.ExposeChildrenEvents = true;
                    }
                    if (interpolationValue < 1)
                    {
                        this.FlipHorizontal = false;
                    }
                    if (interpolationValue < 1)
                    {
                        this.HasEvents = true;
                    }
                    setHeightFirstValue = true;
                    HeightFirstValue = 150f;
                    if (interpolationValue < 1)
                    {
                        this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    setStackSpacingFirstValue = true;
                    StackSpacingFirstValue = 0f;
                    if (interpolationValue < 1)
                    {
                        this.Visible = true;
                    }
                    setWidthFirstValue = true;
                    WidthFirstValue = 150f;
                    if (interpolationValue < 1)
                    {
                        this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    if (interpolationValue < 1)
                    {
                        this.WrapsChildren = false;
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
                    if (interpolationValue >= 1)
                    {
                        this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.ClipsChildren = false;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.ExposeChildrenEvents = true;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.FlipHorizontal = false;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.HasEvents = true;
                    }
                    setHeightSecondValue = true;
                    HeightSecondValue = 150f;
                    if (interpolationValue >= 1)
                    {
                        this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    setStackSpacingSecondValue = true;
                    StackSpacingSecondValue = 0f;
                    if (interpolationValue >= 1)
                    {
                        this.Visible = true;
                    }
                    setWidthSecondValue = true;
                    WidthSecondValue = 150f;
                    if (interpolationValue >= 1)
                    {
                        this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                    }
                    if (interpolationValue >= 1)
                    {
                        this.WrapsChildren = false;
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
            if (setHeightFirstValue && setHeightSecondValue)
            {
                Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
            }
            if (setStackSpacingFirstValue && setStackSpacingSecondValue)
            {
                StackSpacing = StackSpacingFirstValue * (1 - interpolationValue) + StackSpacingSecondValue * interpolationValue;
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
        public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (SkiaTest.GumRuntimes.ContainerRuntime.VariableState fromState,SkiaTest.GumRuntimes.ContainerRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                    Name = "Children Layout",
                    Type = "ChildrenLayout",
                    Value = ChildrenLayout
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Clips Children",
                    Type = "bool",
                    Value = ClipsChildren
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
                    Name = "FlipHorizontal",
                    Type = "bool",
                    Value = FlipHorizontal
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
                    Name = "StackSpacing",
                    Type = "float",
                    Value = StackSpacing
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
                    Name = "Wraps Children",
                    Type = "bool",
                    Value = WrapsChildren
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
                    Name = "Children Layout",
                    Type = "ChildrenLayout",
                    Value = ChildrenLayout
                    }
                    );
                    newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                    {
                    SetsValue = true,
                    Name = "Clips Children",
                    Type = "bool",
                    Value = ClipsChildren
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
                    Name = "FlipHorizontal",
                    Type = "bool",
                    Value = FlipHorizontal
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
                    Value = Height + 150f
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
                    Name = "StackSpacing",
                    Type = "float",
                    Value = StackSpacing + 0f
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
                    Value = Width + 150f
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
                    Name = "Wraps Children",
                    Type = "bool",
                    Value = WrapsChildren
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
        public override void SetInitialState () 
        {
            var wasSuppressed = this.IsLayoutSuspended;
            if(!wasSuppressed) this.SuspendLayout();
            this.CurrentVariableState = VariableState.Default;
            if(!wasSuppressed) this.ResumeLayout();
        }
    }
    
    public class ContainerRuntime<T> : ContainerRuntime where T : Gum.Wireframe.GraphicalUiElement, new()
    {
        public new System.Collections.Generic.IEnumerable<T> Children
        {
            get
            {
                foreach(T item in base.Children)
                {
                    yield return item;
                }
            }
        }

        public ContainerRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true) : base(fullInstantiation, tryCreateFormsObject)
        {
        }

        public void AddChild(T newChild)
        {
            base.Children.Add(newChild);
        }

        public void RemoveChild(T childToRemove)
        {
            base.Children.Remove(childToRemove);
        }

        public void ClearChildren() => base.Children.Clear();


        public T AddChild()
        {
            var child = new T();

            AddChild(child);

            return child;
        }
    }

}
