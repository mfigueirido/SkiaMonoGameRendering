#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
#define SUPPORTS_GLUEVIEW_2
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace SkiaTest.Screens
{
    public partial class SkiaScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static SkiaTest.GumRuntimes.SkiaGumScreenRuntime SkiaGumScreen;
        
        private FlatRedBall.Math.PositionedObjectList<SkiaTest.Entities.SkiaEntity> SkiaEntityListInstance = new FlatRedBall.Math.PositionedObjectList<SkiaTest.Entities.SkiaEntity>();
        private SkiaTest.GumRuntimes.TextRuntime DebugTextInstance;
        private SkiaTest.Entities.MonoGameSprite MonoGameSpriteInstance;
        SkiaTest.FormsControls.Screens.SkiaGumScreenForms Forms;
        SkiaTest.GumRuntimes.SkiaGumScreenRuntime GumScreen;
        public SkiaScreen () 
        	: this ("SkiaScreen")
        {
        }
        public SkiaScreen (string contentManagerName) 
        	: base (contentManagerName)
        {
            SkiaEntityListInstance.Name = "SkiaEntityListInstance";
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SkiaEntityListInstance?.Clear();
            DebugTextInstance = SkiaGumScreen.GetGraphicalUiElementByName("DebugTextInstance") as SkiaTest.GumRuntimes.TextRuntime;
            MonoGameSpriteInstance = new SkiaTest.Entities.MonoGameSprite(ContentManagerName, false);
            MonoGameSpriteInstance.Name = "MonoGameSpriteInstance";
            MonoGameSpriteInstance.CreationSource = "Glue";
            GumScreen = SkiaGumScreen;
            Forms = new SkiaTest.FormsControls.Screens.SkiaGumScreenForms(SkiaGumScreen);
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            SkiaGumScreen.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            Factories.SkiaEntityFactory.Initialize(ContentManagerName);
            Factories.SkiaEntityFactory.AddList(SkiaEntityListInstance);
            MonoGameSpriteInstance.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            BeforeCustomInitialize?.Invoke();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                SkiaGumScreen?.AnimateSelf();
                for (int i = SkiaEntityListInstance.Count - 1; i > -1; i--)
                {
                    if (i < SkiaEntityListInstance.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        SkiaEntityListInstance[i].Activity();
                    }
                }
                MonoGameSpriteInstance.Activity();
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void ActivityEditMode () 
        {
            if (FlatRedBall.Screens.ScreenManager.IsInEditMode)
            {
                foreach (var item in FlatRedBall.SpriteManager.ManagedPositionedObjects)
                {
                    if (item is FlatRedBall.Entities.IEntity entity)
                    {
                        entity.ActivityEditMode();
                    }
                }
                CustomActivityEditMode();
                base.ActivityEditMode();
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.SkiaEntityFactory.Destroy();
            SkiaGumScreen.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            SkiaGumScreen = null;
            
            SkiaEntityListInstance.MakeOneWay();
            for (int i = SkiaEntityListInstance.Count - 1; i > -1; i--)
            {
                SkiaEntityListInstance[i].Destroy();
            }
            if (DebugTextInstance != null)
            {
                DebugTextInstance.RemoveFromManagers();
            }
            if (MonoGameSpriteInstance != null)
            {
                MonoGameSpriteInstance.Destroy();
                MonoGameSpriteInstance.Detach();
            }
            SkiaEntityListInstance.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (MonoGameSpriteInstance.Parent == null)
            {
                MonoGameSpriteInstance.Z = 1f;
            }
            else
            {
                MonoGameSpriteInstance.RelativeZ = 1f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            SkiaGumScreen.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            for (int i = SkiaEntityListInstance.Count - 1; i > -1; i--)
            {
                SkiaEntityListInstance[i].Destroy();
            }
            if (DebugTextInstance != null)
            {
                DebugTextInstance.RemoveFromManagers();
            }
            MonoGameSpriteInstance.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                MonoGameSpriteInstance.AssignCustomVariables(true);
            }
            if (MonoGameSpriteInstance.Parent == null)
            {
                MonoGameSpriteInstance.Z = 1f;
            }
            else
            {
                MonoGameSpriteInstance.RelativeZ = 1f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            for (int i = 0; i < SkiaEntityListInstance.Count; i++)
            {
                SkiaEntityListInstance[i].ConvertToManuallyUpdated();
            }
            MonoGameSpriteInstance.ConvertToManuallyUpdated();
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            if(SkiaGumScreen == null)
{
 var wasSuspended = Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended;
 Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true;
 SkiaGumScreen = (SkiaTest.GumRuntimes.SkiaGumScreenRuntime)GumRuntime.ElementSaveExtensions.CreateGueForElement(Gum.Managers.ObjectFinder.Self.GetElementSave("SkiaGumScreen"), true);
 Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = wasSuspended;
 if(!wasSuspended) { SkiaGumScreen.UpdateFontRecursive();SkiaGumScreen.UpdateLayout(); }
}
            SkiaTest.Entities.MonoGameSprite.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "SkiaGumScreen":
                    return SkiaGumScreen;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "SkiaGumScreen":
                    return SkiaGumScreen;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "SkiaGumScreen":
                    return SkiaGumScreen;
            }
            return null;
        }
        public static void Reload (object whatToReload) 
        {
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            SkiaGumScreen.UpdateLayout();
        }
        partial void CustomActivityEditMode();
    }
}
