namespace SkiaTest.FormsControls.Screens
{
    public partial class SkiaScreenForms
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
        public SkiaScreenForms () 
        {
            CustomInitialize();
        }
        public SkiaScreenForms (Gum.Wireframe.GraphicalUiElement visual) 
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
