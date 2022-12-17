namespace SkiaTest.FormsControls.Screens
{
    public partial class SkiaGumScreenForms
    {
        private Gum.Wireframe.GraphicalUiElement Visual;
        public object BindingContext
        {
            get
            {
                return Visual.BindingContext;
            }
            set
            {
                Visual.BindingContext = value;
            }
        }
        public SkiaGumScreenForms () 
        {
            CustomInitialize();
        }
        public SkiaGumScreenForms (Gum.Wireframe.GraphicalUiElement visual) 
        {
            Visual = visual;
            ReactToVisualChanged();
            CustomInitialize();
        }
        private void ReactToVisualChanged () 
        {
        }
        partial void CustomInitialize();
    }
}
