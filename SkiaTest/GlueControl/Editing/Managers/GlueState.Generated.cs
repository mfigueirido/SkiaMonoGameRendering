#define IncludeSetVariable
#define SupportsEditMode
#define HasGum

using GlueControl;
using GlueControl.Dtos;
using GlueControl.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace GlueControl.Managers
{

   internal partial class GlueState
   {
       public static GlueState Self { get; }
       static GlueState() => Self = new GlueState();
      public GlueProjectSave CurrentGlueProject
      {
          get => ObjectFinder.Self.GlueProject;
      }
      public GlueElement CurrentElement
      {
          get => Editing.EditingManager.Self.CurrentGlueElement;
      }
      public NamedObjectSave CurrentNamedObjectSave
      {
           get {
return Editing.EditingManager.Self.CurrentNamedObjects.FirstOrDefault();
          }
      }
       public async Task<object> SetCurrentNamedObjectSave(NamedObjectSave namedObjectSave, GlueElement nosOwner)      {
          var parameter = new GlueCallsClassGenerationManager.GlueParameters { Value = namedObjectSave, Dependencies = new Dictionary<string, object> {{ "nosOwner", nosOwner }}};

          return await GlueCallsClassGenerationManager.ConvertToPropertyCallToGame(nameof(CurrentNamedObjectSave), typeof(NamedObjectSave), parameter, new GlueCallsClassGenerationManager.CallPropertyParameters
          {
              ReturnToPropertyType = false
          });
      }
   }
}
